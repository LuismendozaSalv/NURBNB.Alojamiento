using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NURBNB.Alojamiento.Infrastructure.Migrations
{
	/// <inheritdoc />
	public partial class AgregarUsuarioId : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<Guid>(
				name: "usuarioId",
				table: "propiedad",
				type: "uniqueidentifier",
				nullable: false,
				defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "usuarioId",
				table: "propiedad");
		}
	}
}
