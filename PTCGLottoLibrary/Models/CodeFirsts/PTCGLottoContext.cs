using Microsoft.EntityFrameworkCore;

namespace PTCGLottoLibrary.Models.CodeFirsts
{
    public class PTCGLottoContext : DbContext
    {
        public PTCGLottoContext(DbContextOptions<PTCGLottoContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Series> Serieses { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CoinTradeHistory> CoinTradeHistories { get; set; }
    }
}
