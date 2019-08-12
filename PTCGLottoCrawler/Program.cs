using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PTCGLottoCrawler.Models;
using PTCGLottoCrawler.Extensions;
using PTCGLottoLibrary.Interfaces;
using PTCGLottoLibrary.Models;
using PTCGLottoLibrary.Models.CodeFirsts;
using PTCGLottoLibrary.Models.ServiceModels.CardParseService;
using PTCGLottoLibrary.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PTCGLottoCrawler
{
    class Program
    {
        static IHttpClientFactory _httpClientFactory { get; set; }
        static ITCGCollectorParseService _tCGCollectorParseService { get; set; }
        static PTCGLottoContext _pTCGLottoContext { get; set; }

        static void Main(string[] args)
        {
            SetUp();
            var parseingDictionary = new Dictionary<int, string>()
            {
                { 142, "SUM & MOON" },
                { 143, "SUM & MOON" }
            };

            //parseCards
            var parseResults = new List<CardParseResult>();
            foreach (var parseingReq in parseingDictionary)
            {
                var parseResult = ParseCards(parseingReq.Key);
                parseResult.Series = parseingReq.Value;
                parseResults.Add(parseResult);
            }

            //InsertToDb
            try
            {
                var serieses = parseResults.Select(c => c.Series)
                                           .Distinct();
                foreach (var series in serieses)
                {
                    if (!_pTCGLottoContext.Serieses.Any(c => c.Name == series))
                    {
                        _pTCGLottoContext.Serieses.Add(new Series()
                        {
                            Name = series
                        });
                    }
                }
                _pTCGLottoContext.SaveChanges();

                var expansions = parseResults.SelectMany(pr => pr.Cards.Select(c => new Expansion()
                {
                    Series = _pTCGLottoContext.Serieses.FirstOrDefault(s => s.Name == pr.Series),
                    Name = c.Expansion
                })).Distinct(c => c.Name);

                foreach (var expansion in expansions)
                {
                    if (!_pTCGLottoContext.Expansions.Any(c => c.Name == expansion.Name && c.Series == expansion.Series))
                    {
                        expansion.Price = 100;
                        _pTCGLottoContext.Expansions.Add(expansion);
                    }
                }
                _pTCGLottoContext.SaveChanges();

                var cardTypes = parseResults.SelectMany(pr => pr.Cards
                                                                .SelectMany(c => c.CardType
                                                                              .Select(ct => new CardType()
                                                                              {
                                                                                  Name = ct
                                                                              })
                                                                       )
                                                      )
                                            .Distinct(c => c.Name);

                foreach (var cardType in cardTypes)
                {
                    if (!_pTCGLottoContext.CardTypes.Any(c => c.Name == cardType.Name))
                    {
                        _pTCGLottoContext.CardTypes.Add(cardType);
                    }
                }
                _pTCGLottoContext.SaveChanges();

                var realities = parseResults.SelectMany(pr => pr.Cards
                                                                .Select(c => new Rarity()
                                                                {
                                                                    Name = c.Rarity
                                                                })
                                                       ).Distinct(c => c.Name);
                foreach (var reality in realities)
                {
                    if (!_pTCGLottoContext.Rarities.Any(c => c.Name == reality.Name))
                    {
                        _pTCGLottoContext.Rarities.Add(reality);
                    }
                }
                _pTCGLottoContext.SaveChanges();


                var cards = parseResults.SelectMany(pr => pr.Cards.Select(c => new Card()
                {
                    Expansion = _pTCGLottoContext.Expansions.FirstOrDefault(e => e.Name == c.Expansion && e.Series.Name == pr.Series),
                    ImageUrl = c.ImageUrl,
                    IdentityId = c.Id,
                    Name = c.Name,
                    No = c.No,
                    Rarity = _pTCGLottoContext.Rarities.FirstOrDefault(r => r.Name == c.Rarity),
                    CardCardTypes = c.CardType.Select(ct => new CardCardType()
                    {
                        CardId = c.Id,
                        CardTypeId = _pTCGLottoContext.CardTypes
                                                      .FirstOrDefault(pct => pct.Name == ct)
                                                      .Id
                    }).ToList()
                }));
                foreach (var card in cards)
                {
                    if (!_pTCGLottoContext.Cards.Any(c => c.IdentityId == card.IdentityId))
                    {
                        _pTCGLottoContext.Cards.Add(card);
                    }
                }
                _pTCGLottoContext.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }


        private static void SetUp()
        {

            var servicesProvider = new ServiceCollection()
                                       .AddHttpClient()
                                       .AddSingleton<ITCGCollectorParseService, TCGCollectorParseService>()
                                       .AddDbContext<PTCGLottoContext>(options => options.UseSqlServer(ReadFromAppSettings().Get<AppSettingsModel>()
                                                                                                                            .ConnectionString))
                                       .BuildServiceProvider();
            _httpClientFactory = servicesProvider.GetRequiredService<IHttpClientFactory>();
            _tCGCollectorParseService = servicesProvider.GetRequiredService<ITCGCollectorParseService>();
            _pTCGLottoContext = servicesProvider.GetRequiredService<PTCGLottoContext>();
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

        public static IConfigurationRoot ReadFromAppSettings()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();
        }
    }
}
