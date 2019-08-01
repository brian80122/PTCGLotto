using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTCGLottoLibrary.Models.CodeFirsts
{
    /// <summary>
    /// Users Card
    /// </summary>
    public class Collection
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Count { get; set; }

        public  User User { get; set; }

        public  Card Card { get; set; }
    }
}
