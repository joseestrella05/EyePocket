using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyePocket.Migrations
{
    /// <inheritdoc />
    public partial class FK4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagosCXC_CuentasXCobrar_DeudaCXCId",
                table: "PagosCXC");

            migrationBuilder.AlterColumn<int>(
                name: "DeudaCXCId",
                table: "PagosCXC",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PagosCXC_CuentasXCobrar_DeudaCXCId",
                table: "PagosCXC",
                column: "DeudaCXCId",
                principalTable: "CuentasXCobrar",
                principalColumn: "CXCId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagosCXC_CuentasXCobrar_DeudaCXCId",
                table: "PagosCXC");

            migrationBuilder.AlterColumn<int>(
                name: "DeudaCXCId",
                table: "PagosCXC",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
