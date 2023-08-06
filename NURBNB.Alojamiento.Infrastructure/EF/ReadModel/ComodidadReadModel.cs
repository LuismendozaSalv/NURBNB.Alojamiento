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
        [Required]
        [Column("propiedadId")]
        public Guid PropiedadId { get; set; }

        [Column("valor")]
        [StringLength(250)]
        [Required]
        public string Valor { get; set; }
    }
}
