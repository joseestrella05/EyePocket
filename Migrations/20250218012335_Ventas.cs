using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyePocket.Migrations
{
    /// <inheritdoc />
    public partial class Ventas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MetodoPago",
                columns: table => new
                {
                    MetodoPagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPago", x => x.MetodoPagoId);
                });

            migrationBuilder.CreateTable(
                name: "OrdenVentas",
                columns: table => new
                {
                    OrdenVentaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MontoTotal = table.Column<double>(type: "float", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    NCF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RNC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenVentas", x => x.OrdenVentaId);
                    table.ForeignKey(
                        name: "FK_OrdenVentas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenVentasDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<double>(type: "float", nullable: false),
                    OrdenVentaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenVentasDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_OrdenVentasDetalle_OrdenVentas_OrdenVentaId",
                        column: x => x.OrdenVentaId,
                        principalTable: "OrdenVentas",
                        principalColumn: "OrdenVentaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenVentasDetalle_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenVentas_ClienteId",
                table: "OrdenVentas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenVentasDetalle_OrdenVentaId",
                table: "OrdenVentasDetalle",
                column: "OrdenVentaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenVentasDetalle_ProductoId",
                table: "OrdenVentasDetalle",
                column: "ProductoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MetodoPago");

            migrationBuilder.DropTable(
                name: "OrdenVentasDetalle");

            migrationBuilder.DropTable(
                name: "OrdenVentas");
        }
    }
}
