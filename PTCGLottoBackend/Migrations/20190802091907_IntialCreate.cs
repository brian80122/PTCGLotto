using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PTCGLottoBackend.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Coin = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rarities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rarities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Serieses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serieses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expansions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    SeriesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expansions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expansions_Serieses_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Serieses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoinTradeHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<int>(nullable: false),
                    Memo = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoinTradeHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoinTradeHistories_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoinTradeHistories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    No = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ExpansionId = table.Column<int>(nullable: false),
                    CardTypeId = table.Column<int>(nullable: false),
                    RarityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_CardTypes_CardTypeId",
                        column: x => x.CardTypeId,
                        principalTable: "CardTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cards_Expansions_ExpansionId",
                        column: x => x.ExpansionId,
                        principalTable: "Expansions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cards_Rarities_RarityId",
                        column: x => x.RarityId,
                        principalTable: "Rarities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Count = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    CardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collections_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Collections_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CardTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pokemon" },
                    { 2, "Supporter" },
                    { 3, "Energy" },
                    { 4, "Item" },
                    { 5, "Stadium" }
                });

            migrationBuilder.InsertData(
                table: "Rarities",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { 1, "Common", 1 },
                    { 2, "Uncommon", 2 },
                    { 3, "Rare", 3 }
                });

            migrationBuilder.InsertData(
                table: "Serieses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "SUN & MOON" });

            migrationBuilder.InsertData(
                table: "Expansions",
                columns: new[] { "Id", "Name", "Price", "SeriesId" },
                values: new object[] { 1, "Unbroken Bonds", 100, 1 });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CardTypeId", "ExpansionId", "Name", "No", "RarityId" },
                values: new object[,]
                {
                    { 1, 1, 1, "Pheromosa & Buzzwole-GX", 1, 3 },
                    { 149, 1, 1, "Persian-GX", 149, 3 },
                    { 150, 1, 1, "Doduo", 150, 1 },
                    { 151, 1, 1, "Dodrio", 151, 2 },
                    { 152, 1, 1, "Lickitung", 152, 1 },
                    { 153, 1, 1, "Lickilicky", 153, 3 },
                    { 154, 1, 1, "Porygon", 154, 1 },
                    { 155, 1, 1, "Porygon", 155, 1 },
                    { 156, 1, 1, "Porygon2", 156, 2 },
                    { 157, 1, 1, "Porygon-Z", 157, 3 },
                    { 158, 1, 1, "Snorlax", 158, 3 },
                    { 159, 1, 1, "Glameow", 159, 1 },
                    { 160, 1, 1, "Purugly", 160, 3 },
                    { 161, 1, 1, "Happiny", 161, 2 },
                    { 162, 1, 1, "Chatot", 162, 2 },
                    { 163, 1, 1, "Celesteela-GX", 163, 3 },
                    { 164, 4, 1, "Beast Bringer", 164, 2 },
                    { 165, 4, 1, "Chip-Chip Ice Axe", 165, 2 },
                    { 166, 4, 1, "Devolution Spray Z", 166, 2 },
                    { 167, 4, 1, "Dusk Stone", 167, 2 },
                    { 168, 5, 1, "Dust Island", 168, 2 },
                    { 169, 4, 1, "Electromagnetic Radar", 169, 2 },
                    { 170, 4, 1, "Energy Spinner", 170, 2 },
                    { 171, 4, 1, "Fairy Charm Ability", 171, 2 },
                    { 172, 4, 1, "Fairy Charm Lightning", 172, 2 },
                    { 173, 4, 1, "Fire Crystal", 173, 2 },
                    { 148, 1, 1, "Persian", 148, 3 },
                    { 174, 2, 1, "Giovanni's Exile", 174, 2 },
                    { 147, 1, 1, "Meowth", 147, 1 },
                    { 145, 1, 1, "Spearow", 145, 1 },
                    { 120, 1, 1, "Lucario & Melmetal-GX", 120, 3 },
                    { 121, 1, 1, "Alolan Diglett", 121, 1 },
                    { 122, 1, 1, "Alolan Dugtrio", 122, 3 },
                    { 123, 1, 1, "Aron", 123, 1 },
                    { 124, 1, 1, "Lairon", 124, 2 },
                    { 125, 1, 1, "Aggron", 125, 3 },
                    { 126, 1, 1, "Lucario", 126, 3 },
                    { 127, 1, 1, "Genesect", 127, 3 },
                    { 128, 1, 1, "Meltan", 128, 1 },
                    { 129, 1, 1, "Melmetal", 129, 3 },
                    { 130, 1, 1, "Gardevoir & Sylveon-GX", 130, 3 },
                    { 131, 1, 1, "Cleffa", 131, 2 },
                    { 132, 1, 1, "Clefairy", 132, 1 },
                    { 133, 1, 1, "Clefable", 133, 3 },
                    { 134, 1, 1, "Jigglypuff", 134, 1 },
                    { 135, 1, 1, "Wigglytuff", 135, 3 },
                    { 136, 1, 1, "Togepi", 136, 1 },
                    { 137, 1, 1, "Togetic", 137, 2 },
                    { 138, 1, 1, "Togekiss", 138, 3 },
                    { 139, 1, 1, "Cottonee", 139, 1 },
                    { 140, 1, 1, "Whimsicott-GX", 140, 3 },
                    { 141, 1, 1, "Spritzee", 141, 1 },
                    { 142, 1, 1, "Aromatisse", 142, 3 },
                    { 143, 1, 1, "Rattata", 143, 1 },
                    { 144, 1, 1, "Raticate", 144, 2 },
                    { 146, 1, 1, "Fearow", 146, 2 },
                    { 175, 2, 1, "Green's Exploration", 175, 2 },
                    { 176, 2, 1, "Janine", 176, 2 },
                    { 177, 2, 1, "Koga's Trap", 177, 2 },
                    { 208, 1, 1, "Celesteela-GX", 208, 3 },
                    { 209, 2, 1, "Green's Exploration", 209, 3 },
                    { 210, 2, 1, "Janine", 210, 3 },
                    { 211, 2, 1, "Koga's Trap", 211, 3 },
                    { 212, 2, 1, "Molayne", 212, 3 },
                    { 213, 2, 1, "Red's Challenge", 213, 3 },
                    { 214, 2, 1, "Welder", 214, 3 },
                    { 215, 1, 1, "Pheromosa & Buzzwole-GX", 215, 3 },
                    { 216, 1, 1, "Venomoth-GX", 216, 3 },
                    { 217, 1, 1, "Reshiram & Charizard-GX", 217, 3 },
                    { 218, 1, 1, "Blastoise-GX", 218, 3 },
                    { 219, 1, 1, "Dedenne-GX", 219, 3 },
                    { 220, 1, 1, "Muk & Alolan Muk-GX", 220, 3 },
                    { 221, 1, 1, "Marshadow & Machamp-GX", 221, 3 },
                    { 222, 1, 1, "Greninja & Zoroark-GX", 222, 3 },
                    { 223, 1, 1, "Honchkrow-GX", 223, 3 },
                    { 224, 1, 1, "Lucario & Melmetal-GX", 224, 3 },
                    { 225, 1, 1, "Gardevoir & Sylveon-GX", 225, 3 },
                    { 226, 1, 1, "Whimsicott-GX", 226, 3 },
                    { 227, 1, 1, "Persian-GX", 227, 3 },
                    { 228, 1, 1, "Celesteela-GX", 228, 3 },
                    { 229, 4, 1, "Beast Bringer", 229, 3 },
                    { 230, 4, 1, "Electromagnetic Radar", 230, 3 },
                    { 231, 4, 1, "Fire Crystal", 231, 3 },
                    { 232, 4, 1, "Metal Core Barrier", 232, 3 },
                    { 207, 1, 1, "Persian-GX", 207, 3 },
                    { 206, 1, 1, "Whimsicott-GX", 206, 3 },
                    { 205, 1, 1, "Gardevoir & Sylveon-GX", 205, 3 },
                    { 204, 1, 1, "Gardevoir & Sylveon-GX", 204, 3 },
                    { 178, 2, 1, "Lt. Surge's Strategy", 178, 2 },
                    { 179, 5, 1, "Martial Arts Dojo", 179, 2 },
                    { 180, 4, 1, "Metal Core Barrier", 180, 2 },
                    { 181, 2, 1, "Molayne", 181, 2 },
                    { 182, 4, 1, "Pokegear 3.0", 182, 2 },
                    { 183, 5, 1, "Power Plant", 183, 2 },
                    { 184, 2, 1, "Red's Challenge", 184, 3 },
                    { 185, 2, 1, "Samson Oak", 185, 2 },
                    { 186, 4, 1, "Stealthy Hood", 186, 2 },
                    { 187, 4, 1, "Surprise Box", 187, 2 },
                    { 188, 2, 1, "Ultra Forest Kartenvoy", 188, 2 },
                    { 189, 2, 1, "Welder", 189, 2 },
                    { 119, 1, 1, "Malamar", 119, 3 },
                    { 190, 3, 1, "Triple Acceleration Energy", 190, 2 },
                    { 192, 1, 1, "Pheromosa & Buzzwole-GX", 192, 3 },
                    { 193, 1, 1, "Venomoth-GX", 193, 3 },
                    { 194, 1, 1, "Reshiram & Charizard-GX", 194, 3 },
                    { 195, 1, 1, "Dedenne-GX", 195, 3 },
                    { 196, 1, 1, "Muk & Alolan Muk-GX", 196, 3 },
                    { 197, 1, 1, "Muk & Alolan Muk-GX", 197, 3 },
                    { 198, 1, 1, "Marshadow & Machamp-GX", 198, 3 },
                    { 199, 1, 1, "Marshadow & Machamp-GX", 199, 3 },
                    { 200, 1, 1, "Greninja & Zoroark-GX", 200, 3 },
                    { 201, 1, 1, "Greninja & Zoroark-GX", 201, 3 },
                    { 202, 1, 1, "Honchkrow-GX", 202, 3 },
                    { 203, 1, 1, "Lucario & Melmetal-GX", 203, 3 },
                    { 191, 1, 1, "Pheromosa & Buzzwole-GX", 191, 3 },
                    { 118, 1, 1, "Inkay", 118, 1 },
                    { 117, 1, 1, "Greninja", 117, 3 },
                    { 116, 1, 1, "Krookodile", 116, 3 },
                    { 32, 1, 1, "Blacephalon", 32, 3 },
                    { 33, 1, 1, "Squirtle", 33, 1 },
                    { 34, 1, 1, "Wartortle", 34, 2 },
                    { 35, 1, 1, "Blastoise-GX", 35, 3 },
                    { 36, 1, 1, "Poliwag", 36, 1 },
                    { 37, 1, 1, "Poliwag", 37, 1 },
                    { 38, 1, 1, "Poliwhirl", 38, 2 },
                    { 39, 1, 1, "Poliwrath", 39, 3 },
                    { 40, 1, 1, "Tentacool", 40, 1 },
                    { 41, 1, 1, "Tentacruel", 41, 2 },
                    { 42, 1, 1, "Slowpoke", 42, 1 },
                    { 43, 1, 1, "Slowbro", 43, 3 },
                    { 44, 1, 1, "Seel", 44, 1 },
                    { 45, 1, 1, "Dewgong", 45, 3 },
                    { 46, 1, 1, "Krabby", 46, 1 },
                    { 47, 1, 1, "Kingler", 47, 3 },
                    { 48, 1, 1, "Goldeen", 48, 1 },
                    { 49, 1, 1, "Seaking", 49, 3 },
                    { 50, 1, 1, "Kyurem", 50, 3 },
                    { 51, 1, 1, "Froakie", 51, 1 },
                    { 52, 1, 1, "Frogadier", 52, 2 },
                    { 53, 1, 1, "Pyukumuku", 53, 2 },
                    { 54, 1, 1, "Pikachu", 54, 1 },
                    { 55, 1, 1, "Raichu", 55, 3 },
                    { 56, 1, 1, "Stunfisk", 56, 3 },
                    { 31, 1, 1, "Salazzle", 31, 3 },
                    { 30, 1, 1, "Salandit", 30, 1 },
                    { 29, 1, 1, "Incineroar", 29, 3 },
                    { 28, 1, 1, "Torracat", 28, 2 },
                    { 2, 1, 1, "Caterpie", 2, 1 },
                    { 3, 1, 1, "Metapod", 3, 2 },
                    { 4, 1, 1, "Butterfree", 4, 3 },
                    { 5, 1, 1, "Oddish", 5, 1 },
                    { 6, 1, 1, "Oddish", 6, 1 },
                    { 7, 1, 1, "Gloom", 7, 2 },
                    { 8, 1, 1, "Vileplume", 8, 3 },
                    { 9, 1, 1, "Venonat", 9, 1 },
                    { 10, 1, 1, "Venonat", 10, 1 },
                    { 11, 1, 1, "Venomoth", 11, 3 },
                    { 12, 1, 1, "Venomoth-GX", 12, 3 },
                    { 13, 1, 1, "Bellsprout", 13, 1 },
                    { 57, 1, 1, "Dedenne-GX", 57, 3 },
                    { 14, 1, 1, "Weepinbell", 14, 2 },
                    { 16, 1, 1, "Tangela", 16, 1 },
                    { 17, 1, 1, "Tangrowth", 17, 3 },
                    { 18, 1, 1, "Grubbin", 18, 1 },
                    { 19, 1, 1, "Kartana", 19, 3 },
                    { 20, 1, 1, "Reshiram & Charizard-GX", 20, 3 },
                    { 21, 1, 1, "Growlithe", 21, 1 },
                    { 22, 1, 1, "Arcanine", 22, 3 },
                    { 23, 1, 1, "Darumaka", 23, 1 },
                    { 24, 1, 1, "Darmanitan", 24, 3 },
                    { 25, 1, 1, "Volcanion", 25, 3 },
                    { 26, 1, 1, "Litten", 26, 1 },
                    { 27, 1, 1, "Litten", 27, 1 },
                    { 15, 1, 1, "Victreebel", 15, 3 },
                    { 233, 4, 1, "Pokegear 3.0", 233, 3 },
                    { 58, 1, 1, "Charjabug", 58, 2 },
                    { 60, 1, 1, "Zeraora", 60, 3 },
                    { 91, 1, 1, "Marowak", 91, 3 },
                    { 92, 1, 1, "Rhyhorn", 92, 1 },
                    { 93, 1, 1, "Rhyhorn", 93, 1 },
                    { 94, 1, 1, "Rhydon", 94, 2 },
                    { 95, 1, 1, "Rhyperior", 95, 3 },
                    { 96, 1, 1, "Wooper", 96, 1 },
                    { 97, 1, 1, "Quagsire", 97, 3 },
                    { 98, 1, 1, "Gligar", 98, 1 },
                    { 99, 1, 1, "Gliscor", 99, 2 },
                    { 100, 1, 1, "Tyrogue", 100, 2 },
                    { 101, 1, 1, "Hitmontop", 101, 2 },
                    { 102, 1, 1, "Riolu", 102, 1 },
                    { 103, 1, 1, "Landorus", 103, 3 },
                    { 104, 1, 1, "Crabrawler", 104, 1 },
                    { 105, 1, 1, "Crabominable", 105, 3 },
                    { 106, 1, 1, "Stakataka", 106, 3 },
                    { 107, 1, 1, "Greninja & Zoroark-GX", 107, 3 },
                    { 108, 1, 1, "Murkrow", 108, 1 },
                    { 109, 1, 1, "Honchkrow-GX", 109, 3 },
                    { 110, 1, 1, "Carvanha", 110, 1 },
                    { 111, 1, 1, "Sharpedo", 111, 3 },
                    { 112, 1, 1, "Spiritomb", 112, 3 },
                    { 113, 1, 1, "Sandile", 113, 1 },
                    { 114, 1, 1, "Sandile", 114, 1 },
                    { 115, 1, 1, "Krokorok", 115, 2 },
                    { 90, 1, 1, "Cubone", 90, 1 },
                    { 89, 1, 1, "Golem", 89, 3 },
                    { 88, 1, 1, "Graveler", 88, 2 },
                    { 87, 1, 1, "Geodude", 87, 1 },
                    { 61, 1, 1, "Muk & Alolan Muk-GX", 61, 3 },
                    { 62, 1, 1, "Ekans", 62, 1 },
                    { 63, 1, 1, "Arbok", 63, 3 },
                    { 64, 1, 1, "Zubat", 64, 1 },
                    { 65, 1, 1, "Golbat", 65, 2 },
                    { 66, 1, 1, "Crobat", 66, 3 },
                    { 67, 1, 1, "Gastly", 67, 1 },
                    { 68, 1, 1, "Gastly", 68, 1 },
                    { 69, 1, 1, "Haunter", 69, 2 },
                    { 70, 1, 1, "Gengar", 70, 3 },
                    { 71, 1, 1, "Drowzee", 71, 1 },
                    { 72, 1, 1, "Hypno", 72, 3 },
                    { 59, 1, 1, "Vikavolt", 59, 3 },
                    { 73, 1, 1, "Koffing", 73, 1 },
                    { 75, 1, 1, "Mewtwo", 75, 3 },
                    { 76, 1, 1, "Mew", 76, 3 },
                    { 77, 1, 1, "Misdreavus", 77, 1 },
                    { 78, 1, 1, "Mismagius", 78, 3 },
                    { 79, 1, 1, "Espurr", 79, 1 },
                    { 80, 1, 1, "Meowstic", 80, 3 },
                    { 81, 1, 1, "Marshadow", 81, 3 },
                    { 82, 1, 1, "Marshadow & Machamp-GX", 82, 3 },
                    { 83, 1, 1, "Sandshrew", 83, 1 },
                    { 84, 1, 1, "Sandslash", 84, 3 },
                    { 85, 1, 1, "Diglett", 85, 1 },
                    { 86, 1, 1, "Dugtrio", 86, 3 },
                    { 74, 1, 1, "Weezing", 74, 3 },
                    { 234, 3, 1, "Triple Acceleration Energy", 234, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CardTypeId",
                table: "Cards",
                column: "CardTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_ExpansionId",
                table: "Cards",
                column: "ExpansionId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_RarityId",
                table: "Cards",
                column: "RarityId");

            migrationBuilder.CreateIndex(
                name: "IX_CoinTradeHistories_StatusId",
                table: "CoinTradeHistories",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CoinTradeHistories_UserId",
                table: "CoinTradeHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_CardId",
                table: "Collections",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_UserId",
                table: "Collections",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expansions_SeriesId",
                table: "Expansions",
                column: "SeriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CoinTradeHistories");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CardTypes");

            migrationBuilder.DropTable(
                name: "Expansions");

            migrationBuilder.DropTable(
                name: "Rarities");

            migrationBuilder.DropTable(
                name: "Serieses");
        }
    }
}
