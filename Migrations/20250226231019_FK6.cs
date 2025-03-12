using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyePocket.Migrations
{
    /// <inheritdoc />
    public partial class FK6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MontoCuota",
                table: "CuotasCXC",
                newName: "SaldoFinal");

            migrationBuilder.AddColumn<double>(
                name: "Interes",
                table: "CuotasCXC",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PagoCapital",
                table: "CuotasCXC",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Interes",
                table: "CuotasCXC");

            migrationBuilder.DropColumn(
                name: "PagoCapital",
                table: "CuotasCXC");

            migrationBuilder.RenameColumn(
                name: "SaldoFinal",
                table: "CuotasCXC",
                newName: "MontoCuota");
        }
    }
}
