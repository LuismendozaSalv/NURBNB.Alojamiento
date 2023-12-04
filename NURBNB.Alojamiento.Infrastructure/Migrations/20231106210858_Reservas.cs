using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NURBNB.Alojamiento.Infrastructure.Migrations
{
	/// <inheritdoc />
	public partial class Reservas : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "comodidad",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
					descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_comodidad", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "pais",
				columns: table => new
				{
					paisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
					paisCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_pais", x => x.paisId);
				});

			migrationBuilder.CreateTable(
				name: "propiedad",
				columns: table => new
				{
					propiedadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
					precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					tipoPropiedad = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
					personas = table.Column<int>(type: "int", nullable: false),
					camas = table.Column<int>(type: "int", nullable: false),
					habitaciones = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_propiedad", x => x.propiedadId);
				});

			migrationBuilder.CreateTable(
				name: "ciudad",
				columns: table => new
				{
					ciudadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
					paisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ciudad", x => x.ciudadId);
					table.ForeignKey(
						name: "FK_ciudad_pais_paisId",
						column: x => x.paisId,
						principalTable: "pais",
						principalColumn: "paisId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "foto",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					propiedadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					url = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_foto", x => x.Id);
					table.ForeignKey(
						name: "FK_foto_propiedad_propiedadId",
						column: x => x.propiedadId,
						principalTable: "propiedad",
						principalColumn: "propiedadId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "propiedadComodidad",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					comodidadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					propiedadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_propiedadComodidad", x => x.Id);
					table.ForeignKey(
						name: "FK_propiedadComodidad_comodidad_comodidadId",
						column: x => x.comodidadId,
						principalTable: "comodidad",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_propiedadComodidad_propiedad_propiedadId",
						column: x => x.propiedadId,
						principalTable: "propiedad",
						principalColumn: "propiedadId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "regla",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					propiedadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Value = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_regla", x => x.Id);
					table.ForeignKey(
						name: "FK_regla_propiedad_propiedadId",
						column: x => x.propiedadId,
						principalTable: "propiedad",
						principalColumn: "propiedadId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "reserva",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					propiedadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					fechaEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
					fechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
					estadoReserva = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_reserva", x => x.Id);
					table.ForeignKey(
						name: "FK_reserva_propiedad_propiedadId",
						column: x => x.propiedadId,
						principalTable: "propiedad",
						principalColumn: "propiedadId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "direccion",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					propiedadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					calle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
					avenida = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
					referencia = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
					latitud = table.Column<double>(type: "float", nullable: false),
					longitud = table.Column<double>(type: "float", nullable: false),
					ciudadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_direccion", x => x.Id);
					table.ForeignKey(
						name: "FK_direccion_ciudad_ciudadId",
						column: x => x.ciudadId,
						principalTable: "ciudad",
						principalColumn: "ciudadId",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_direccion_propiedad_propiedadId",
						column: x => x.propiedadId,
						principalTable: "propiedad",
						principalColumn: "propiedadId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_ciudad_paisId",
				table: "ciudad",
				column: "paisId");

			migrationBuilder.CreateIndex(
				name: "IX_direccion_ciudadId",
				table: "direccion",
				column: "ciudadId");

			migrationBuilder.CreateIndex(
				name: "IX_direccion_propiedadId",
				table: "direccion",
				column: "propiedadId",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_foto_propiedadId",
				table: "foto",
				column: "propiedadId");

			migrationBuilder.CreateIndex(
				name: "IX_propiedadComodidad_comodidadId",
				table: "propiedadComodidad",
				column: "comodidadId");

			migrationBuilder.CreateIndex(
				name: "IX_propiedadComodidad_propiedadId",
				table: "propiedadComodidad",
				column: "propiedadId");

			migrationBuilder.CreateIndex(
				name: "IX_regla_propiedadId",
				table: "regla",
				column: "propiedadId");

			migrationBuilder.CreateIndex(
				name: "IX_reserva_propiedadId",
				table: "reserva",
				column: "propiedadId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "direccion");

			migrationBuilder.DropTable(
				name: "foto");

			migrationBuilder.DropTable(
				name: "propiedadComodidad");

			migrationBuilder.DropTable(
				name: "regla");

			migrationBuilder.DropTable(
				name: "reserva");

			migrationBuilder.DropTable(
				name: "ciudad");

			migrationBuilder.DropTable(
				name: "comodidad");

			migrationBuilder.DropTable(
				name: "propiedad");

			migrationBuilder.DropTable(
				name: "pais");
		}
	}
}
