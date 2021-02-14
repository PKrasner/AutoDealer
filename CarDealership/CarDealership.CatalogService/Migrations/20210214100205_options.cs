using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealership.CatalogService.Migrations
{
    public partial class options : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_CarManufacturers_CarManufacturerId",
                table: "CarModels");

            migrationBuilder.AlterColumn<int>(
                name: "CarManufacturerId",
                table: "CarModels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CarModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CarOptionGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinOptions = table.Column<int>(type: "int", nullable: false),
                    MaxOptions = table.Column<int>(type: "int", nullable: false),
                    CarModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarOptionGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarOptionGroups_CarModels_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarOptionGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarOptions_CarOptionGroups_CarOptionGroupId",
                        column: x => x.CarOptionGroupId,
                        principalTable: "CarOptionGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarOptionGroups_CarModelId",
                table: "CarOptionGroups",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CarOptions_CarOptionGroupId",
                table: "CarOptions",
                column: "CarOptionGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_CarManufacturers_CarManufacturerId",
                table: "CarModels",
                column: "CarManufacturerId",
                principalTable: "CarManufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_CarManufacturers_CarManufacturerId",
                table: "CarModels");

            migrationBuilder.DropTable(
                name: "CarOptions");

            migrationBuilder.DropTable(
                name: "CarOptionGroups");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "CarModels");

            migrationBuilder.AlterColumn<int>(
                name: "CarManufacturerId",
                table: "CarModels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_CarManufacturers_CarManufacturerId",
                table: "CarModels",
                column: "CarManufacturerId",
                principalTable: "CarManufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
