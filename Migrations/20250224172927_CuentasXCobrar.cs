using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyePocket.Migrations
{
    /// <inheritdoc />
    public partial class CuentasXCobrar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagosCXC_Deudas_DeudasId",
                table: "PagosCXC");

            migrationBuilder.DropTable(
                name: "Deudas");

            migrationBuilder.RenameColumn(
                name: "DeudasId",
                table: "PagosCXC",
                newName: "DeudaCXCId");

            migrationBuilder.RenameIndex(
                name: "IX_PagosCXC_DeudasId",
                table: "PagosCXC",
                newName: "IX_PagosCXC_DeudaCXCId");

            migrationBuilder.CreateTable(
                name: "CuentasXCobrar",
                columns: table => new
                {
                    CXCId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenVentaId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    Periodos = table.Column<int>(type: "int", nullable: false),
                    Capital = table.Column<double>(type: "float", nullable: false),
                    Interes = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentasXCobrar", x => x.CXCId);
                    table.ForeignKey(
                        name: "FK_CuentasXCobrar_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuentasXCobrar_OrdenVenta_OrdenVentaId",
                        column: x => x.OrdenVentaId,
                        principalTable: "OrdenVenta",
                        principalColumn: "OrdenVentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuotasCXC",
                columns: table => new
                {
                    CuotaCXCID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CXCId = table.Column<int>(type: "int", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MontoCuota = table.Column<double>(type: "float", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    CuentasXCobrarCXCId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuotasCXC", x => x.CuotaCXCID);
                    table.ForeignKey(
                        name: "FK_CuotasCXC_CuentasXCobrar_CuentasXCobrarCXCId",
                        column: x => x.CuentasXCobrarCXCId,
                        principalTable: "CuentasXCobrar",
                        principalColumn: "CXCId");
                    table.ForeignKey(
                        name: "FK_CuotasCXC_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuentasXCobrar_EstadoId",
                table: "CuentasXCobrar",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_CuentasXCobrar_OrdenVentaId",
                table: "CuentasXCobrar",
                column: "OrdenVentaId");

            migrationBuilder.CreateIndex(
                name: "IX_CuotasCXC_CuentasXCobrarCXCId",
                table: "CuotasCXC",
                column: "CuentasXCobrarCXCId");

            migrationBuilder.CreateIndex(
                name: "IX_CuotasCXC_EstadoId",
                table: "CuotasCXC",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PagosCXC_CuentasXCobrar_DeudaCXCId",
                table: "PagosCXC",
                column: "DeudaCXCId",
                principalTable: "CuentasXCobrar",
                principalColumn: "CXCId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagosCXC_CuentasXCobrar_DeudaCXCId",
                table: "PagosCXC");

            migrationBuilder.DropTable(
                name: "CuotasCXC");

            migrationBuilder.DropTable(
                name: "CuentasXCobrar");

            migrationBuilder.RenameColumn(
                name: "DeudaCXCId",
                table: "PagosCXC",
                newName: "DeudasId");

            migrationBuilder.RenameIndex(
                name: "IX_PagosCXC_DeudaCXCId",
                table: "PagosCXC",
                newName: "IX_PagosCXC_DeudasId");

            migrationBuilder.CreateTable(
                name: "Deudas",
                columns: table => new
                {
                    DeudasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    OrdenVentaId = table.Column<int>(type: "int", nullable: false),
                    Capital = table.Column<float>(type: "real", nullable: false),
                    Interes = table.Column<float>(type: "real", nullable: false),
                    Periodos = table.Column<int>(type: "int", nullable: false),
                    SaldoPendiente = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deudas", x => x.DeudasId);
                    table.ForeignKey(
                        name: "FK_Deudas_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deudas_OrdenVenta_OrdenVentaId",
                        column: x => x.OrdenVentaId,
                        principalTable: "OrdenVenta",
                        principalColumn: "OrdenVentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deudas_EstadoId",
                table: "Deudas",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Deudas_OrdenVentaId",
                table: "Deudas",
                column: "OrdenVentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PagosCXC_Deudas_DeudasId",
                table: "PagosCXC",
                column: "DeudasId",
                principalTable: "Deudas",
                principalColumn: "DeudasId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
