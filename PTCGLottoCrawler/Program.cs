using AngleSharp;
using Microsoft.Extensions.DependencyInjection;
using PTCGLottoLibrary.Interfaces;
using PTCGLottoLibrary.Models.ServiceModels.CardParseService;
using PTCGLottoLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PTCGLottoCrawler
{
    class Program
    {
        static IHttpClientFactory  _httpClientFactory { get; set; }
        static ITCGCollectorParseService _tCGCollectorParseService { get; set; }
        static void Main(string[] args)
        {
            SetUp();
            var parseingDictionary = new Dictionary<int, string>()
            {
                { 142, "SUM & MOON" },
                { 143, "SUM & MOON" }
            };
            var parseResults = new List<CardParseResult>();
            foreach (var parseingReq in parseingDictionary)
            {
                var parseResult = ParseCards(parseingReq.Key);
                parseResult.Series = parseingReq.Value;

                if (parseResults.Count > 0 && parseResults.Any(c => c.Series == parseResult.Series))
                {
                    var sameSeries = parseResults.FirstOrDefault(c => c.Series == parseResult.Series);
                }
                else
                {
                    parseResults.Add(parseResult);
                }
            }
        }


        private static void SetUp()
        {
            var servicesProvider = new ServiceCollection()
                                       .AddHttpClient()
                                       .AddSingleton<ITCGCollectorParseService, TCGCollectorParseService>()
                                       .BuildServiceProvider();
            _httpClientFactory = servicesProvider.GetRequiredService<IHttpClientFactory>();
            _tCGCollectorParseService = servicesProvider.GetRequiredService<ITCGCollectorParseService>();
        }

        private static async Task<string> CalltcgcollectorWebsite(int expansionNo, bool displayImage = false)
        {
            var url = $"https://www.tcgcollector.com/cards?expansion-{expansionNo}=on";
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            if (displayImage)
            {
                //該站藉由 cookie 決定呈現方式
                request.Headers.Add("Cookie", "display=images");
            }

            var result = await client.SendAsync(request);
            var content = await result.Content
                                      .ReadAsStringAsync();

            return content;
        }

        private static CardParseResult ParseCards(int expansionNo)
        {
            var listContent = CalltcgcollectorWebsite(expansionNo, false)
                              .Result;
            var cardParseResult = _tCGCollectorParseService.ParseListHtml(listContent);

            var imageContent = CalltcgcollectorWebsite(expansionNo, true)
                               .Result;
            var imageUrlDictionary = _tCGCollectorParseService.ParseImageHtml(imageContent);

            foreach (var card in cardParseResult.Cards)
            {
                card.ImageUrl = imageUrlDictionary[card.No];
            }

            return cardParseResult;
        }

        //private static void ParseImage(int expansionNo)
        //{
        //    var content = CalltcgcollectorWebsite(expansionNo, true)
        //                  .Result;
        //    #region AngleSharp
        //    var config = Configuration.Default;
        //    var context = BrowsingContext.New(config);
        //    var document = context.OpenAsync(req => req.Content(content))
        //                          .Result;
        //    var found = document.All
        //                        .Where(c => c.LocalName == "article" && c.ClassName.Contains("card-image-container"))
        //                        .ToList();
        //    var imageUrls = found.Select(c => c.QuerySelector("img")
        //                                       .GetAttribute("src"))
        //                         .Select(u => new
        //                         {
        //                             Key = $"{u.Split("/").Last().Split("-")[0]}",
        //                             Url = u
        //                         })
        //                         .ToList();
        //    #endregion
        //}
    }
}
