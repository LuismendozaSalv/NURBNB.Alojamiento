using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Infrastructure.EF.ReadModel
{
	[Table("comodidad")]
	public class ComodidadReadModel
	{
		[Key]
		[Column("Id")]
		public Guid Id { get; set; }

		[Column("nombre")]
		[StringLength(250)]
		[Required]
		public string Nombre { get; set; }

		[Column("descripcion")]
		[StringLength(250)]
		[Required]
		public string Descripcion { get; set; }
	}
}
