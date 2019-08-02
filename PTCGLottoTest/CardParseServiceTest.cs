using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTCGLottoLibrary;
using PTCGLottoLibrary.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PTCGLottoTest
{
    [TestClass]
    public class CardParseServiceTest
    {
        private ICardParseSerivce _cardParseSerivce;
        public CardParseServiceTest()
        {
            var services = new ServiceCollection();
            services.AddTransient<ICardParseSerivce, CardParseSerivce>();

            var serviceProvider = services.BuildServiceProvider();
            _cardParseSerivce = serviceProvider.GetService<ICardParseSerivce>();
        }

        [TestMethod]
        public void TestReadFile()
        {
            var basePath = Path.Combine("StaticFiles", "CardDatas");
            var datas = _cardParseSerivce.ReadFiles(basePath);
            Assert.IsTrue(datas.Count > 0);
        }

        [TestMethod]
        public void TestParseCard()
        {
            var sampleData = @"SUN & MOON
                               Pheromosa & Buzzwole-GX
                               1/214
                               Unbroken Bonds
                               Unbroken Bonds
                               Pokemon TAG TEAM, Pokemon-GX, Ultra Beast - Basic
                               Ultra Rare
                               Ultra Rare
                               Chip-Chip Ice Axe
                               165/214
                               Unbroken Bonds
                               Unbroken Bonds
                               Item
                               Uncommon
                               Uncommon
                               Giovanni's Exile
                               174/214
                               Unbroken Bonds
                               Unbroken Bonds
                               Supporter
                               Uncommon
                               Uncommon"
                               .Split(
                                   new[] { "\r\n", "\r", "\n" },
                                   StringSplitOptions.None
                             );
            var result = _cardParseSerivce.ParseCard(sampleData.ToList());
            Assert.IsTrue(result.Series == "SUN & MOON");
            var firstCard = result.Cards[0];
            Assert.IsTrue(
                          firstCard.Name == "Pheromosa & Buzzwole-GX" &&
                          firstCard.CardType == "Pokemon" &&
                          firstCard.No == 1 &&
                          firstCard.Rarity == "Rare" &&
                          firstCard.Expansion == "Unbroken Bonds"
                          );

            var secondCard = result.Cards[1];
            Assert.IsTrue(
                          secondCard.Name == "Chip-Chip Ice Axe" &&
                          secondCard.CardType == "Item" &&
                          secondCard.No == 165 &&
                          secondCard.Rarity == "Uncommon" &&
                          secondCard.Expansion == "Unbroken Bonds"
                          );

            var thirdCard = result.Cards[2];
            Assert.IsTrue(
                         thirdCard.Name == "Giovanni's Exile" &&
                         thirdCard.CardType == "Supporter" &&
                         thirdCard.No == 174 &&
                         thirdCard.Rarity == "Uncommon" &&
                         thirdCard.Expansion == "Unbroken Bonds"
                         );
        }

        [TestMethod]
        public void TestParseCards()
        {
            var datas = _cardParseSerivce.ReadFiles("StaticFiles/CardDatas");
            var result = _cardParseSerivce.ParseCards(datas);
        }
    }
}
