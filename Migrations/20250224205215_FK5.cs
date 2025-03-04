using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyePocket.Migrations
{
    /// <inheritdoc />
    public partial class FK5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagosCXC_CuentasXCobrar_DeudaCXCId",
                table: "PagosCXC");

            migrationBuilder.DropIndex(
                name: "IX_PagosCXC_DeudaCXCId",
                table: "PagosCXC");

            migrationBuilder.DropColumn(
                name: "DeudaCXCId",
                table: "PagosCXC");

            migrationBuilder.CreateIndex(
                name: "IX_PagosCXC_CXCId",
                table: "PagosCXC",
                column: "CXCId");

            migrationBuilder.AddForeignKey(
                name: "FK_PagosCXC_CuentasXCobrar_CXCId",
                table: "PagosCXC",
                column: "CXCId",
                principalTable: "CuentasXCobrar",
                principalColumn: "CXCId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagosCXC_CuentasXCobrar_CXCId",
                table: "PagosCXC");

            migrationBuilder.DropIndex(
                name: "IX_PagosCXC_CXCId",
                table: "PagosCXC");

            migrationBuilder.AddColumn<int>(
                name: "DeudaCXCId",
                table: "PagosCXC",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PagosCXC_DeudaCXCId",
                table: "PagosCXC",
                column: "DeudaCXCId");

            migrationBuilder.AddForeignKey(
                name: "FK_PagosCXC_CuentasXCobrar_DeudaCXCId",
                table: "PagosCXC",
                column: "DeudaCXCId",
                principalTable: "CuentasXCobrar",
                principalColumn: "CXCId");
        }
    }
}
