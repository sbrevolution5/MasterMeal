using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterMeal.Migrations
{
    public partial class _003specificMeasure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Fraction",
                table: "QIngredient",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MassMeasurementUnit",
                table: "QIngredient",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MeasurementType",
                table: "QIngredient",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VolumeMeasurementUnit",
                table: "QIngredient",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fraction",
                table: "QIngredient");

            migrationBuilder.DropColumn(
                name: "MassMeasurementUnit",
                table: "QIngredient");

            migrationBuilder.DropColumn(
                name: "MeasurementType",
                table: "QIngredient");

            migrationBuilder.DropColumn(
                name: "VolumeMeasurementUnit",
                table: "QIngredient");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
