using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTCGLottoLibrary.Models.CodeFirsts
{
    /// <summary>
    /// Cards
    /// </summary>
    public class Card
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// IdentityId in Total PTCG Cards
        /// </summary>
        public int IdentityId { get; set; }

        /// <summary>
        /// No in this explansion
        /// </summary>
        public int No { get; set; }
        public string Name { get; set; }

        public int ExpansionId { get; set; }
        public Expansion Expansion { get; set; }

        public int RarityId { get; set; }
        public Rarity Rarity { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<CardCardType> CardCardTypes { get; set; }
    }
}
