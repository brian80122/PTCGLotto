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
        public long Id { get; set; }
        public long ProviderId { get; set; }
        public long ReceiverId { get; set; }
        public int Amount { get; set; }
        public int StatusId { get; set; }
    }
}
