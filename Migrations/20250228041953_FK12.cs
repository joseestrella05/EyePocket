using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyePocket.Migrations
{
    /// <inheritdoc />
    public partial class FK12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuotasCXC_CuentasXCobrar_CXCId",
                table: "CuotasCXC");

            migrationBuilder.DropIndex(
                name: "IX_CuotasCXC_CXCId",
                table: "CuotasCXC");

            migrationBuilder.AddColumn<int>(
                name: "CuentasXCobrarCXCId",
                table: "CuotasCXC",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CuotasCXC_CuentasXCobrarCXCId",
                table: "CuotasCXC",
                column: "CuentasXCobrarCXCId");

            migrationBuilder.AddForeignKey(
                name: "FK_CuotasCXC_CuentasXCobrar_CuentasXCobrarCXCId",
                table: "CuotasCXC",
                column: "CuentasXCobrarCXCId",
                principalTable: "CuentasXCobrar",
                principalColumn: "CXCId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuotasCXC_CuentasXCobrar_CuentasXCobrarCXCId",
                table: "CuotasCXC");

            migrationBuilder.DropIndex(
                name: "IX_CuotasCXC_CuentasXCobrarCXCId",
                table: "CuotasCXC");

            migrationBuilder.DropColumn(
                name: "CuentasXCobrarCXCId",
                table: "CuotasCXC");

            migrationBuilder.CreateIndex(
                name: "IX_CuotasCXC_CXCId",
                table: "CuotasCXC",
                column: "CXCId");

            migrationBuilder.AddForeignKey(
                name: "FK_CuotasCXC_CuentasXCobrar_CXCId",
                table: "CuotasCXC",
                column: "CXCId",
                principalTable: "CuentasXCobrar",
                principalColumn: "CXCId");
        }
    }
}
