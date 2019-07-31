using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PTCGLottoLibrary.Models.CodeFirsts
{
    public class PTCGLottoContext : IdentityDbContext<User>
    {
        public PTCGLottoContext(DbContextOptions<PTCGLottoContext> options) : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<Series> Serieses { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CoinTradeHistory> CoinTradeHistories { get; set; }
    }
}
