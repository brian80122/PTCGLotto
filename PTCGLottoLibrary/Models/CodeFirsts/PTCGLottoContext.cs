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
        public DbSet<Expansion> Expansions { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CoinTradeHistory> CoinTradeHistories { get; set; }
        public DbSet<Rarity> Rarities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rarity>()
                        .HasData(
                                 new Rarity() { Id = 1, Name = "Common", Value = 1 },
                                 new Rarity() { Id = 2, Name = "Uncommon", Value = 2 },
                                 new Rarity() { Id = 3, Name = "Rare", Value = 3 }
                                );
            modelBuilder.Entity<CardType>()
                        .HasData(
                                 new CardType() { Id = 1, Name = "Pokémon" },
                                 new CardType() { Id = 2, Name = "Trainer" },
                                 new CardType() { Id = 3, Name = "Energy" }
                                );
        }
    }
}
