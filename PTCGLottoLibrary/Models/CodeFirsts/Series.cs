using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTCGLottoLibrary.Models.CodeFirsts
{
    /// <summary>
    /// Card Series,like SUM&MOON, XY
    /// </summary>
    public class Series
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
