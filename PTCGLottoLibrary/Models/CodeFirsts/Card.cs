using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTCGLottoLibrary.Models.CodeFirsts
{
    /// <summary>
    /// Cards
    /// </summary>
    public class Card
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int No { get; set; }
        public string Name { get; set; }

        public int ExpansionId { get; set; }
        public Expansion Expansion { get; set; }

        public int CardTypeId { get; set; }
        public  CardType CardType { get; set; }

        public int RarityId { get; set; }
        public Rarity Rarity { get; set; }
    }
}
