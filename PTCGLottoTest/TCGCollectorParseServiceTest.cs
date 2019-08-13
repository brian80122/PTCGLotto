using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTCGLottoLibrary.Interfaces;
using PTCGLottoLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTCGLottoTest
{
    [TestClass]
    public class TCGCollectorParseServiceTest
    {
        private ITCGCollectorParseService _tCGCollectorParseService;
        public TCGCollectorParseServiceTest()
        {
            var services = new ServiceCollection();
            services.AddTransient<ITCGCollectorParseService, TCGCollectorParseService>();

            var serviceProvider = services.BuildServiceProvider();
            _tCGCollectorParseService = serviceProvider.GetService<ITCGCollectorParseService>();
        }

        [TestMethod]
        public void ParseListHtml()
        {
            var sourceHtml =
 @"<article id='card-12291' class='card card-list-item'>
    <div class='card-list-item-entry card-list-item-name'>
        <a href = '/cards/12291/pheromosa-buzzwole-gx-unbroken-bonds-1-214'
            class='card-list-item-entry-link'>Pheromosa &amp; Buzzwole-GX</a>
    </div>
    <div class='card-list-item-entry card-list-item-number'>
        <span class='card-list-item-entry-text'>1/214</span>
    </div>
    <div class='card-list-item-entry card-list-item-expansion'>
        <img src = 'https://cdn.tcgcollector.com/content/expansion-symbols/unbroken-bonds-142-49d9f1e1ed.png'
            alt='Unbroken Bonds' width='25' height='25'>
        <span class='card-list-item-entry-text'>Unbroken Bonds</span>
    </div>
    <div class='card-list-item-entry card-list-item-card-type'>
        <span class='card-list-item-entry-text'>Pokémon TAG TEAM, Pokémon-GX, Ultra Beast-Basic
        </span>
    </div>
    <div class='card-list-item-entry card-list-item-rarity'>
        <img src = 'https://cdn.tcgcollector.com/content/rarity-symbols/ultra-rare.svg'
            alt='Ultra Rare' width='15' height='15'>
        <span class='card-list-item-entry-text'>Ultra Rare</span>
    </div>
</article>";

            var result = _tCGCollectorParseService.ParseListHtml(sourceHtml);
            var compareObj = result.Cards[0];

            Assert.IsTrue(compareObj.Id == 12291 &&
                          compareObj.Name == "Pheromosa & Buzzwole-GX" &&
                          compareObj.No == 1 &&
                          compareObj.Rarity == "Ultra Rare" &&
                          compareObj.Expansion == "Unbroken Bonds");
            Assert.IsTrue(compareObj.CardType.Contains("Pokémon TAG TEAM"));
            Assert.IsTrue(compareObj.CardType.Contains("Pokémon-GX"));
            Assert.IsTrue(compareObj.CardType.Contains("UltraBeast-Basic"));
        }
    }
}
