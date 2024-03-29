﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PTCGLottoLibrary.Models.CodeFirsts;

namespace PTCGLottoBackend.Migrations
{
    [DbContext(typeof(PTCGLottoContext))]
    [Migration("20190813034559_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PTCGLottoLibrary.Models.CodeFirsts.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExpansionId");

                    b.Property<int>("IdentityId");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name");

                    b.Property<int>("No");

                    b.Property<int>("RarityId");

                    b.HasKey("Id");

                    b.HasIndex("ExpansionId");

                    b.HasIndex("RarityId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("PTCGLottoLibrary.Models.CodeFirsts.CardCardType", b =>
                {
                    b.Property<int>("CardId");

                    b.Property<int>("CardTypeId");

                    b.HasKey("CardId", "CardTypeId");

                    b.HasIndex("CardTypeId");

                    b.ToTable("CardCardType");
                });

            modelBuilder.Entity("PTCGLottoLibrary.Models.CodeFirsts.CardType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("CardTypes");
                });

            modelBuilder.Entity("PTCGLottoLibrary.Models.CodeFirsts.Expansion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("Price");

                    b.Property<int>("SeriesId");

                    b.HasKey("Id");

                    b.HasIndex("SeriesId");

                    b.ToTable("Expansions");
                });

            modelBuilder.Entity("PTCGLottoLibrary.Models.CodeFirsts.Rarity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.ToTable("Rarities");
                });

            modelBuilder.Entity("PTCGLottoLibrary.Models.CodeFirsts.Series", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Serieses");
                });

            modelBuilder.Entity("PTCGLottoLibrary.Models.CodeFirsts.Card", b =>
                {
                    b.HasOne("PTCGLottoLibrary.Models.CodeFirsts.Expansion", "Expansion")
                        .WithMany()
                        .HasForeignKey("ExpansionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PTCGLottoLibrary.Models.CodeFirsts.Rarity", "Rarity")
                        .WithMany()
                        .HasForeignKey("RarityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PTCGLottoLibrary.Models.CodeFirsts.CardCardType", b =>
                {
                    b.HasOne("PTCGLottoLibrary.Models.CodeFirsts.Card", "Card")
                        .WithMany("CardCardTypes")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PTCGLottoLibrary.Models.CodeFirsts.CardType", "CardType")
                        .WithMany("CardCardTypes")
                        .HasForeignKey("CardTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PTCGLottoLibrary.Models.CodeFirsts.Expansion", b =>
                {
                    b.HasOne("PTCGLottoLibrary.Models.CodeFirsts.Series", "Series")
                        .WithMany()
                        .HasForeignKey("SeriesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
