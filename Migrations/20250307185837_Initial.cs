using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EyePocket.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Compras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Precio",
                table: "Compras",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "EstadoCXP",
                columns: table => new
                {
                    EstadoCXPId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCXP", x => x.EstadoCXPId);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPagos",
                columns: table => new
                {
                    MetodoPagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPagos", x => x.MetodoPagoId);
                });

            migrationBuilder.CreateTable(
                name: "CXP",
                columns: table => new
                {
                    CuentaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacturaId = table.Column<int>(type: "int", nullable: false),
                    EstadoCXPId = table.Column<int>(type: "int", nullable: false),
                    SaldoPendiente = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UltimoPago = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MetodoPagoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CXP", x => x.CuentaId);
                    table.ForeignKey(
                        name: "FK_CXP_EstadoCXP_EstadoCXPId",
                        column: x => x.EstadoCXPId,
                        principalTable: "EstadoCXP",
                        principalColumn: "EstadoCXPId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CXP_MetodoPagos_MetodoPagoId",
                        column: x => x.MetodoPagoId,
                        principalTable: "MetodoPagos",
                        principalColumn: "MetodoPagoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EstadoCXP",
                columns: new[] { "EstadoCXPId", "descripcion" },
                values: new object[,]
                {
                    { 1, "Pagada" },
                    { 2, "Pendiente" },
                    { 3, "Retrasada" },
                    { 4, "Aceptada" },
                    { 5, "Rechazada" }
                });

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "EstadoId",
                keyValue: 2,
                column: "Nombre",
                value: "Aprobado");

            migrationBuilder.InsertData(
                table: "MetodoPagos",
                columns: new[] { "MetodoPagoId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Pago por Cuota" },
                    { 2, "Efectivo" },
                    { 3, "Transferencia Bancaria" },
                    { 4, "Tarjeta de crédito" },
                    { 5, "Cheque" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CXP_EstadoCXPId",
                table: "CXP",
                column: "EstadoCXPId");

            migrationBuilder.CreateIndex(
                name: "IX_CXP_MetodoPagoId",
                table: "CXP",
                column: "MetodoPagoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CXP");

            migrationBuilder.DropTable(
                name: "EstadoCXP");

            migrationBuilder.DropTable(
                name: "MetodoPagos");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Compras");

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "EstadoId",
                keyValue: 2,
                column: "Nombre",
                value: "Aprobrado");
        }
    }
}
