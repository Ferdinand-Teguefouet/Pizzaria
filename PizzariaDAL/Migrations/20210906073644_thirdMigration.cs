using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzariaDAL.Migrations
{
    public partial class thirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commande_Client_ClientId",
                table: "Commande");

            migrationBuilder.DropForeignKey(
                name: "FK_PlatCommande_Commande_commandeId",
                table: "PlatCommande");

            migrationBuilder.DropForeignKey(
                name: "FK_PlatCommande_Plats_PlatId",
                table: "PlatCommande");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlatCommande",
                table: "PlatCommande");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commande",
                table: "Commande");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.RenameTable(
                name: "PlatCommande",
                newName: "PlatCommandes");

            migrationBuilder.RenameTable(
                name: "Commande",
                newName: "Commandes");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "Clients");

            migrationBuilder.RenameIndex(
                name: "IX_PlatCommande_PlatId",
                table: "PlatCommandes",
                newName: "IX_PlatCommandes_PlatId");

            migrationBuilder.RenameIndex(
                name: "IX_PlatCommande_commandeId",
                table: "PlatCommandes",
                newName: "IX_PlatCommandes_commandeId");

            migrationBuilder.RenameIndex(
                name: "IX_Commande_ClientId",
                table: "Commandes",
                newName: "IX_Commandes_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlatCommandes",
                table: "PlatCommandes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commandes",
                table: "Commandes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_Clients_ClientId",
                table: "Commandes",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlatCommandes_Commandes_commandeId",
                table: "PlatCommandes",
                column: "commandeId",
                principalTable: "Commandes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlatCommandes_Plats_PlatId",
                table: "PlatCommandes",
                column: "PlatId",
                principalTable: "Plats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_Clients_ClientId",
                table: "Commandes");

            migrationBuilder.DropForeignKey(
                name: "FK_PlatCommandes_Commandes_commandeId",
                table: "PlatCommandes");

            migrationBuilder.DropForeignKey(
                name: "FK_PlatCommandes_Plats_PlatId",
                table: "PlatCommandes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlatCommandes",
                table: "PlatCommandes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commandes",
                table: "Commandes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "PlatCommandes",
                newName: "PlatCommande");

            migrationBuilder.RenameTable(
                name: "Commandes",
                newName: "Commande");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Client");

            migrationBuilder.RenameIndex(
                name: "IX_PlatCommandes_PlatId",
                table: "PlatCommande",
                newName: "IX_PlatCommande_PlatId");

            migrationBuilder.RenameIndex(
                name: "IX_PlatCommandes_commandeId",
                table: "PlatCommande",
                newName: "IX_PlatCommande_commandeId");

            migrationBuilder.RenameIndex(
                name: "IX_Commandes_ClientId",
                table: "Commande",
                newName: "IX_Commande_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlatCommande",
                table: "PlatCommande",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commande",
                table: "Commande",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commande_Client_ClientId",
                table: "Commande",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlatCommande_Commande_commandeId",
                table: "PlatCommande",
                column: "commandeId",
                principalTable: "Commande",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlatCommande_Plats_PlatId",
                table: "PlatCommande",
                column: "PlatId",
                principalTable: "Plats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
