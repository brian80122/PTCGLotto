using System;
using System.Collections.Generic;
using System.Text;

namespace PTCGLottoLibrary.Models.CodeFirsts
{
    public class CardCardType
    {
        public int CardId { get; set; }
        public Card Card { get; set; }
        public int CardTypeId { get; set; }
        public CardType CardType { get; set; }
    }
}
