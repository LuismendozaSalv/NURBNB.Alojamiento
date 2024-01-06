using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NURBNB.Alojamiento.Infrastructure.EF.ReadModel
{
	[Table("ciudad")]
	public class CiudadReadModel
	{
		[Key]
		[Column("ciudadId")]
		public Guid Id { get; set; }

		[Column("nombre")]
		[StringLength(250)]
		[Required]
		public string Nombre { get; set; }

		[Required]
		[Column("paisId")]
		public Guid PaisId { get; set; }
		public PaisReadModel Pais { get; set; }
	}
}
