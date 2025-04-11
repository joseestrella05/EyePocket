using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyePocket.Migrations
{
    /// <inheritdoc />
    public partial class SincronizacionRendermode20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CierreCajaCierreId",
                table: "OrdenVenta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CierreCaja",
                columns: table => new
                {
                    CierreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MontoApertura = table.Column<double>(type: "float", nullable: false),
                    CantidadDeVentas = table.Column<int>(type: "int", nullable: false),
                    MontoDeVentas = table.Column<double>(type: "float", nullable: false),
                    MontoDeCierre = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CierreCaja", x => x.CierreId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenVenta_CierreCajaCierreId",
                table: "OrdenVenta",
                column: "CierreCajaCierreId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenVenta_CierreCaja_CierreCajaCierreId",
                table: "OrdenVenta",
                column: "CierreCajaCierreId",
                principalTable: "CierreCaja",
                principalColumn: "CierreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenVenta_CierreCaja_CierreCajaCierreId",
                table: "OrdenVenta");

            migrationBuilder.DropTable(
                name: "CierreCaja");

            migrationBuilder.DropIndex(
                name: "IX_OrdenVenta_CierreCajaCierreId",
                table: "OrdenVenta");

            migrationBuilder.DropColumn(
                name: "CierreCajaCierreId",
                table: "OrdenVenta");
        }
    }
}
