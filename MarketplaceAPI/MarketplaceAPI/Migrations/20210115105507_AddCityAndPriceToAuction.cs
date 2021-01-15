using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketplaceAPI.Migrations
{
    public partial class AddCityAndPriceToAuction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Auctions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "Auctions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Auctions");
        }
    }
}
