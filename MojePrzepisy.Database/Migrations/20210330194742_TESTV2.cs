using Microsoft.EntityFrameworkCore.Migrations;

namespace MojePrzepisy.Database.Migrations
{
    public partial class TESTV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recepies_Users_UserId",
                table: "Recepies");

            migrationBuilder.DropIndex(
                name: "IX_Recepies_UserId",
                table: "Recepies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Recepies_UserId",
                table: "Recepies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recepies_Users_UserId",
                table: "Recepies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
