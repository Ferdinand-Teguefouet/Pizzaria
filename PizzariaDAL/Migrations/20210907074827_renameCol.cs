using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzariaDAL.Migrations
{
    public partial class renameCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plats_categories_CategorieId",
                table: "Plats");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Plats");

            migrationBuilder.AlterColumn<int>(
                name: "CategorieId",
                table: "Plats",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Plats_categories_CategorieId",
                table: "Plats",
                column: "CategorieId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plats_categories_CategorieId",
                table: "Plats");

            migrationBuilder.AlterColumn<int>(
                name: "CategorieId",
                table: "Plats",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Plats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Plats_categories_CategorieId",
                table: "Plats",
                column: "CategorieId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
