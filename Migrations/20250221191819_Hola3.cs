using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyePocket.Migrations
{
    /// <inheritdoc />
    public partial class Hola3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeudasId",
                table: "PagosCXC",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PagosCXC_DeudasId",
                table: "PagosCXC",
                column: "DeudasId");

            migrationBuilder.AddForeignKey(
                name: "FK_PagosCXC_Deudas_DeudasId",
                table: "PagosCXC",
                column: "DeudasId",
                principalTable: "Deudas",
                principalColumn: "DeudasId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagosCXC_Deudas_DeudasId",
                table: "PagosCXC");

            migrationBuilder.DropIndex(
                name: "IX_PagosCXC_DeudasId",
                table: "PagosCXC");

            migrationBuilder.DropColumn(
                name: "DeudasId",
                table: "PagosCXC");
        }
    }
}
