using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyePocket.Migrations
{
    /// <inheritdoc />
    public partial class FK2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagosCXC_CuentasXCobrar_DeudaCXCId",
                table: "PagosCXC");

            migrationBuilder.RenameColumn(
                name: "DeudaCXCId",
                table: "PagosCXC",
                newName: "CuentaPorCobrarCXCId");

            migrationBuilder.RenameIndex(
                name: "IX_PagosCXC_DeudaCXCId",
                table: "PagosCXC",
                newName: "IX_PagosCXC_CuentaPorCobrarCXCId");

            migrationBuilder.AddForeignKey(
                name: "FK_PagosCXC_CuentasXCobrar_CuentaPorCobrarCXCId",
                table: "PagosCXC",
                column: "CuentaPorCobrarCXCId",
                principalTable: "CuentasXCobrar",
                principalColumn: "CXCId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagosCXC_CuentasXCobrar_CuentaPorCobrarCXCId",
                table: "PagosCXC");

            migrationBuilder.RenameColumn(
                name: "CuentaPorCobrarCXCId",
                table: "PagosCXC",
                newName: "DeudaCXCId");

            migrationBuilder.RenameIndex(
                name: "IX_PagosCXC_CuentaPorCobrarCXCId",
                table: "PagosCXC",
                newName: "IX_PagosCXC_DeudaCXCId");

            migrationBuilder.AddForeignKey(
                name: "FK_PagosCXC_CuentasXCobrar_DeudaCXCId",
                table: "PagosCXC",
                column: "DeudaCXCId",
                principalTable: "CuentasXCobrar",
                principalColumn: "CXCId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
