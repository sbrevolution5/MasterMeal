using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterMealBlazor.Migrations
{
    public partial class _003nullreferencehuh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "measurementType",
                table: "Ingredient",
                newName: "MeasurementType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MeasurementType",
                table: "Ingredient",
                newName: "measurementType");
        }
    }
}
