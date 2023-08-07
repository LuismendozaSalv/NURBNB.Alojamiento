using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NURBNB.Alojamiento.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "valor",
                table: "regla",
                newName: "Value");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "regla",
                newName: "valor");
        }
    }
}
