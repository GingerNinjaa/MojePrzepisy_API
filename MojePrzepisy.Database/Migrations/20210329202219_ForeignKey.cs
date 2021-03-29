using Microsoft.EntityFrameworkCore.Migrations;

namespace MojePrzepisy.Database.Migrations
{
    public partial class ForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Recepies_RecepieId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_PreparationSteps_Recepies_RecepieId",
                table: "PreparationSteps");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "PreparationSteps");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Ingredients");

            migrationBuilder.AlterColumn<int>(
                name: "RecepieId",
                table: "PreparationSteps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecepieId",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Recepies_RecepieId",
                table: "Ingredients",
                column: "RecepieId",
                principalTable: "Recepies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PreparationSteps_Recepies_RecepieId",
                table: "PreparationSteps",
                column: "RecepieId",
                principalTable: "Recepies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Recepies_RecepieId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_PreparationSteps_Recepies_RecepieId",
                table: "PreparationSteps");

            migrationBuilder.AlterColumn<int>(
                name: "RecepieId",
                table: "PreparationSteps",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "PreparationSteps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "RecepieId",
                table: "Ingredients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Recepies_RecepieId",
                table: "Ingredients",
                column: "RecepieId",
                principalTable: "Recepies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PreparationSteps_Recepies_RecepieId",
                table: "PreparationSteps",
                column: "RecepieId",
                principalTable: "Recepies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
