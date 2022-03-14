using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDataAccess.Migrations
{
    public partial class removeFromTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "user");

            migrationBuilder.DropColumn(
                name: "email",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "user",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "user",
                newName: "fullname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "phone",
                table: "user",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "fullname",
                table: "user",
                newName: "lastName");

            migrationBuilder.AddColumn<string>(
                name: "age",
                table: "user",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "user",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
