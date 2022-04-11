using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDataAccess.Migrations
{
    public partial class fixTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "startOffer",
                table: "post",
                newName: "userPhone");

            migrationBuilder.RenameColumn(
                name: "bestOfferUserPhone",
                table: "post",
                newName: "userOffer");

            migrationBuilder.AddColumn<string>(
                name: "maxOffer",
                table: "contentPosts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "startOffer",
                table: "contentPosts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "maxOffer",
                table: "contentPosts");

            migrationBuilder.DropColumn(
                name: "startOffer",
                table: "contentPosts");

            migrationBuilder.RenameColumn(
                name: "userPhone",
                table: "post",
                newName: "startOffer");

            migrationBuilder.RenameColumn(
                name: "userOffer",
                table: "post",
                newName: "bestOfferUserPhone");
        }
    }
}
