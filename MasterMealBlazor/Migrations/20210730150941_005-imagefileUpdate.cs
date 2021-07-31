using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MasterMealBlazor.Migrations
{
    public partial class _005imagefileUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ImageFile_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Meal_ImageFile_ImageId",
                table: "Meal");

            migrationBuilder.DropTable(
                name: "ImageFile");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Recipe",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DBImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImageData = table.Column<byte[]>(type: "bytea", nullable: true),
                    ContentType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBImage", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_ImageId",
                table: "Recipe",
                column: "ImageId");

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
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "DBImage");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_ImageId",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Recipe");

            migrationBuilder.CreateTable(
                name: "ImageFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContentType = table.Column<string>(type: "text", nullable: true),
                    ImageData = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageFile", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ImageFile_ImageId",
                table: "AspNetUsers",
                column: "ImageId",
                principalTable: "ImageFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_ImageFile_ImageId",
                table: "Meal",
                column: "ImageId",
                principalTable: "ImageFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
