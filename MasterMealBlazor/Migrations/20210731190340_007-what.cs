using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterMealBlazor.Migrations
{
    public partial class _007what : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DBImage_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Meal_DBImage_ImageId",
                table: "Meal");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_DBImage_ImageId",
                table: "Recipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DBImage",
                table: "DBImage");

            migrationBuilder.RenameTable(
                name: "DBImage",
                newName: "Image");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Recipe",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Image",
                table: "Image",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Image_ImageId",
                table: "AspNetUsers",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_Image_ImageId",
                table: "Meal",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Image_ImageId",
                table: "Recipe",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Image_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Meal_Image_ImageId",
                table: "Meal");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Image_ImageId",
                table: "Recipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Image",
                table: "Image");

            migrationBuilder.RenameTable(
                name: "Image",
                newName: "DBImage");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Recipe",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DBImage",
                table: "DBImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DBImage_ImageId",
                table: "AspNetUsers",
                column: "ImageId",
                principalTable: "DBImage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_DBImage_ImageId",
                table: "Meal",
                column: "ImageId",
                principalTable: "DBImage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_DBImage_ImageId",
                table: "Recipe",
                column: "ImageId",
                principalTable: "DBImage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
