using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyePocket.Migrations
{
    /// <inheritdoc />
    public partial class FKPROVEDORES : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Proveedor",
                table: "Productos");

            migrationBuilder.AddColumn<int>(
                name: "ProveedorId",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ProveedorId",
                table: "Productos",
                column: "ProveedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Provedores_ProveedorId",
                table: "Productos",
                column: "ProveedorId",
                principalTable: "Provedores",
                principalColumn: "ProvedorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Provedores_ProveedorId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_ProveedorId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "ProveedorId",
                table: "Productos");

            migrationBuilder.AddColumn<string>(
                name: "Proveedor",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
