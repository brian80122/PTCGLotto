using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PTCGLottoLibrary.Models.CodeFirsts;
using PTCGLottoLibrary.Models.ServiceModels.CardParseService;

namespace PTCGLottoLibrary.Services
{
    public class CardParseSerivce : ICardParseSerivce
    {
        public CardParseSerivce()
        {
            
        }

        public List<List<string>> ReadFiles(string basePath)
        {
            var datas = new List<List<string>>();
            var filePaths = Directory.GetFiles(basePath);
            foreach (var filePath in filePaths)
            {
                var data = File.ReadAllText(filePath)
                               .Split(
                                       new[] { "\r\n", "\r", "\n" },
                                       StringSplitOptions.None
                                     );
                datas.Add(data.ToList());
            }

            return datas;
        }
        public List<CardParseResult> ParseCards(List<List<string>> datas)
        {
            var results = new List<CardParseResult>();
            foreach (var data in datas)
            {
                results.Add(ParseCard(data));
            }

            return results;
        }

        public CardParseResult ParseCard(List<string> cardData)
        {
            cardData = cardData.Select(c => c.Trim())
                               .ToList();
            var result = new CardParseResult
            {
                Series = cardData.First(),
                Cards = new List<TempCard>()
            };
            cardData.RemoveAt(0);

            if (cardData.Count % 7 != 0)
            {
                throw new Exception("data format error");
            }
            while (cardData.Count > 0)
            {
                /*
                Pheromosa & Buzzwole-GX
                1/214
                Unbroken Bonds
                Unbroken Bonds
                Pokemon TAG TEAM, Pokemon-GX, Ultra Beast - Basic
                Ultra Rare
                Ultra Rare
                */
                var tempCard = new TempCard()
                {
                    Name = cardData[0],
                    No = int.Parse(cardData[1].Split('/')[0]),
                    Expansion = cardData[2]
                };

                var cardTypeData = cardData[4];
                var cardType = "";
                if (cardTypeData.Contains("Item") || cardTypeData.Contains("Tool"))
                {
                    cardType = "Item";
                }
                else if (cardTypeData.Contains("Pokemon") || cardTypeData.Contains("Ultra Beast"))
                {
                    cardType = "Pokemon";
                }
                else if (cardTypeData.Contains("Supporter"))
                {
                    cardType = "Supporter";
                }
                else if (cardTypeData.Contains("Energy"))
                {
                    cardType = "Energy";
                }
                else if (cardTypeData.Contains("Stadium"))
                {
                    cardType = "Stadium";
                }

                tempCard.CardType = cardType;

                var cardRarity = cardData[5];
                if (cardRarity.Contains("Rare"))
                {
                    cardRarity = "Rare";
                }
                tempCard.Rarity = cardRarity;


                result.Cards.Add(tempCard);
                cardData.RemoveRange(0, 7);
            }

            return result;
        }
    }
}
