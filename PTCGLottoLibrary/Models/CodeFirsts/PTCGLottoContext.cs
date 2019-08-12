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


            //var rarityList = new List<Rarity>() {
            //                     new Rarity() { Id = 1, Name = "Common", Value = 1 },
            //                     new Rarity() { Id = 2, Name = "Uncommon", Value = 2 },
            //                     new Rarity() { Id = 3, Name = "Rare", Value = 3 }
            //                    };

            //modelBuilder.Entity<Rarity>()
            //            .HasData(rarityList);

            //var cardTypeList = new List<CardType>() {
            //                     new CardType() { Id = 1, Name = "Pokemon" },
            //                     new CardType() { Id = 2, Name = "Supporter" },
            //                     new CardType() { Id = 3, Name = "Energy" },
            //                     new CardType() { Id = 4, Name = "Item" },
            //                     new CardType() { Id = 5, Name = "Stadium" }
            //                    };
            //modelBuilder.Entity<CardType>()
            //            .HasData(cardTypeList);

            //ICardParseSerivce cardParseService = new CardParseSerivce();

            //var datas = cardParseService.ReadFiles("../PTCGLottoLibrary/StaticFiles/CardDatas");
            //var parseResults = cardParseService.ParseCards(datas);

            //var series = parseResults.Select(c => c.Series)
            //                         .Distinct()
            //                         .Select((s,i)=> new Series()
            //                         {
            //                             Id = i + 1,
            //                             Name = s
            //                         });
            //modelBuilder.Entity<Series>()
            //            .HasData(series);


            //var expansions = parseResults.SelectMany(pr => pr.Cards.Select(
            //                                                               c => new { pr.Series, c.Expansion }
            //                                                              )
            //                                                       .Distinct()
            //                                                       .Select(
            //                                                               (e, i) => new Expansion()
            //                                                               {
            //                                                                   Id = i + 1,
            //                                                                   Name = e.Expansion,
            //                                                                   Price = 100,
            //                                                                   SeriesId = series.FirstOrDefault(s => s.Name == pr.Series).Id
            //                                                               }
            //                                                              )
            //                                      );
            //modelBuilder.Entity<Expansion>()
            //            .HasData(expansions);

            //var cardCount = 0;
            //foreach (var parseResult in parseResults)
            //{
            //    var cards = parseResult.Cards.Select(c =>
            //    {
            //        cardCount += 1;
            //        return new Card()
            //        {
            //            Id = cardCount,
            //            Name = c.Name,
            //            No = c.No,
            //            CardTypeId = cardTypeList.FirstOrDefault(ct => ct.Name == c.CardType).Id,
            //            RarityId = rarityList.FirstOrDefault(rt => rt.Name == c.Rarity).Id,
            //            ExpansionId = expansions.FirstOrDefault(ep => ep.Name == c.Expansion).Id
            //        };
            //    });

            //    modelBuilder.Entity<Card>()
            //                .HasData(cards);
            //}
        }
    }
}
