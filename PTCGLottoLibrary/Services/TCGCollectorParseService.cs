using AngleSharp;
using PTCGLottoLibrary.Interfaces;
using PTCGLottoLibrary.Models.ServiceModels.CardParseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PTCGLottoLibrary.Services
{
    public class TCGCollectorParseService : ITCGCollectorParseService
    {
        public CardParseResult ParseListHtml(string sourceHtml)
        {
            var result = new CardParseResult()
            {
                Cards = new List<TempCard>()
            };
            var context = BrowsingContext.New(Configuration.Default);
            var document = context.OpenAsync(req => req.Content(sourceHtml))
                                  .Result;
            var articles = document.All.Where(c => c.LocalName == "article" && c.ClassList.Contains("card-list-item"));

            foreach (var article in articles)
            {
                var id = int.Parse(article.Id.Split('-')[1]);
                var childDivs = article.Children
                                       .Where(c => c.LocalName == "div")
                                       .ToList();
                var nameInHtmlEncode = childDivs.FirstOrDefault(c => c.ClassList.Contains("card-list-item-name"))
                                                .QuerySelector("a")
                                                .InnerHtml;
                var name = HttpUtility.HtmlDecode(nameInHtmlEncode);
                var no = childDivs.FirstOrDefault(c => c.ClassList.Contains("card-list-item-number"))
                                  .QuerySelector("span")
                                  .InnerHtml
                                  .Split('/')[0];

                var expansion = childDivs.FirstOrDefault(c => c.ClassList.Contains("card-list-item-expansion"))
                                         .QuerySelector("span")
                                         .InnerHtml;

                var cardTypes = childDivs.FirstOrDefault(c => c.ClassList.Contains("card-list-item-card-type"))
                                         .QuerySelector("span")
                                         .InnerHtml
                                         .Split(new string[] { ", " }, StringSplitOptions.None)
                                         .Select(c=>c.Replace("\n","")
                                                     .Trim())
                                         .ToArray();
                var rarity = childDivs.FirstOrDefault(c => c.ClassList.Contains("card-list-item-rarity"))
                                      .QuerySelector("span")
                                      .InnerHtml;

                var tempCard = new TempCard
                {
                    Id = id,
                    No = int.Parse(no),
                    CardType = cardTypes,
                    Expansion = expansion,
                    Name = name,
                    Rarity = rarity
                };

                result.Cards.Add(tempCard);
            }
            return result;
        }

        //取得 imageUrl
        public Dictionary<int, string> ParseImageHtml(string sourceHtml)
        {
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            var document = context.OpenAsync(req => req.Content(sourceHtml))
                                  .Result;
            var found = document.All
                                .Where(c => c.LocalName == "article" && c.ClassName.Contains("card-image-container"))
                                .ToList();
            var imageUrls = found.Select(c => c.QuerySelector("img")
                                               .GetAttribute("src"))
                                 .Select(u => new
                                 {
                                     Key = int.Parse(u.Split('/').Last().Split('-')[0]),
                                     Url = u
                                 })
                                 .ToDictionary(c => c.Key, c => c.Url);

            return imageUrls;
        }
    }
}
