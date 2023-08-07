using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NURBNB.Alojamiento.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIdDireccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "direccionId",
                table: "direccion",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "direccion",
                newName: "direccionId");
        }
    }
}
