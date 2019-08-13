using Microsoft.EntityFrameworkCore;

namespace PTCGLottoLibrary.Models.CodeFirsts
{
    public class PTCGLottoContext : DbContext
    {
        public PTCGLottoContext(DbContextOptions<PTCGLottoContext> options) : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<Series> Serieses { get; set; }
        public DbSet<Expansion> Expansions { get; set; }
        public DbSet<Rarity> Rarities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // many to many
            modelBuilder.Entity<CardCardType>()
                        .HasKey(cct => new { cct.CardId, cct.CardTypeId });
            modelBuilder.Entity<CardCardType>()
                .HasOne(cct => cct.Card)
                .WithMany(c => c.CardCardTypes )
                .HasForeignKey(cct =>cct.CardId);
            modelBuilder.Entity<CardCardType>()
                .HasOne(cct => cct.CardType)
                .WithMany(ct => ct.CardCardTypes)
                .HasForeignKey(cct => cct.CardTypeId);
        }
    }
}
