using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyePocket.Migrations
{
    /// <inheritdoc />
    public partial class NumeroFacturaToOrdenVentas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "OrdenVentas");

            migrationBuilder.RenameColumn(
                name: "NCF",
                table: "OrdenVentas",
                newName: "NumeroFactura");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumeroFactura",
                table: "OrdenVentas",
                newName: "NCF");

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "OrdenVentas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
