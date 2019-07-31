using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PTCGLottoLibrary.Models.CodeFirsts
{
    public class CoinTradeHistory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Amount { get; set; }

        public string Memo { get; set; }

        public  User User { get; set; }
       
        public  Status Status { get; set; }
    }
}
