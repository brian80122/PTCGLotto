using Microsoft.EntityFrameworkCore.Migrations;

namespace PTCGLottoBackend.Migrations
{
    public partial class AddCardImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Cards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Cards");
        }
    }
}
