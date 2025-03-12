using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyePocket.Migrations
{
    /// <inheritdoc />
    public partial class FK14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuotasCXC_Estados_EstadoId",
                table: "CuotasCXC");

            migrationBuilder.DropIndex(
                name: "IX_CuotasCXC_EstadoId",
                table: "CuotasCXC");

            migrationBuilder.RenameColumn(
                name: "CXCId",
                table: "CuotasCXC",
                newName: "FK_CXCId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FK_CXCId",
                table: "CuotasCXC",
                newName: "CXCId");

            migrationBuilder.CreateIndex(
                name: "IX_CuotasCXC_EstadoId",
                table: "CuotasCXC",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CuotasCXC_Estados_EstadoId",
                table: "CuotasCXC",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "EstadoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
