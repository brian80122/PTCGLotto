using System;
using System.Collections.Generic;
using System.Text;

namespace PTCGLottoLibrary.Models.ServiceModels.CardParseService
{
    public class CardParseResult
    {
        public string Series { get; set; }
        public List<TempCard> Cards { get; set; }
    }

    public class TempCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Expansion { get; set; }
        public string[] CardType { get; set; }
        public string Rarity { get; set; }
        public int No { get; set; }

        public string ImageUrl { get; set; }
    }
}
