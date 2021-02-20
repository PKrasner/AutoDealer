using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealership.CatalogService.Migrations
{
    public partial class renameDescr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "CarModels",
                newName: "InfoText");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InfoText",
                table: "CarModels",
                newName: "Description");
        }
    }
}
