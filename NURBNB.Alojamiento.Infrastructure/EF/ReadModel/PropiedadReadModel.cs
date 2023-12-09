using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Infrastructure.EF.ReadModel
{
	[Table("propiedad")]
	public class PropiedadReadModel
	{
		[Key]
		[Column("propiedadId")]
		public Guid Id { get; set; }

		[Column("titulo")]
		[StringLength(100)]
		[Required]
		public string Titulo { get; set; }

		[Column("descripcion")]
		[StringLength(250)]
		[Required]
		public string Descripcion { get; set; }

		[Required]
		[Column("precio", TypeName = "decimal(18,2)")]
		public decimal Precio { get; set; }

		[Required]
		[Column("tipoPropiedad")]
		[MaxLength(25)]
		public string TipoPropiedad { get; set; }

		[Required]
		[Column("personas")]
		public int Personas { get; set; }

		[Required]
		[Column("camas")]
		public int Camas { get; set; }

		[Required]
		[Column("habitaciones")]
		public int Habitaciones { get; set; }

		[Required]
		[Column("usuarioId")]
		public Guid UsuarioId { get; set; }
		public DireccionReadModel? Direccion { get; set; }
		public List<FotoReadModel>? Fotos { get; set; }
		public List<ReglaReadModel>? Reglas { get; set; }
		public List<PropiedadComodidadReadModel>? Comodidades { get; set; }
		public List<ReservaReadModel>? Reservas { get; set; }
	}
}
