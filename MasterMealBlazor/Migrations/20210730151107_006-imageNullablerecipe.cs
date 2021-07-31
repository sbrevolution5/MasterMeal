using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterMealBlazor.Migrations
{
    public partial class _006imageNullablerecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_DBImage_ImageId",
                table: "Recipe");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Recipe",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_DBImage_ImageId",
                table: "Recipe",
                column: "ImageId",
                principalTable: "DBImage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_DBImage_ImageId",
                table: "Recipe");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Recipe",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_DBImage_ImageId",
                table: "Recipe",
                column: "ImageId",
                principalTable: "DBImage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
