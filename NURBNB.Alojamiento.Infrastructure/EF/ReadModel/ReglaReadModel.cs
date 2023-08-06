using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Infrastructure.EF.ReadModel
{
    [Table("regla")]
    public class ReglaReadModel
    {
        [Key]
        [Column("reglaId")]
        public Guid Id { get; set; }

        [Required]
        [Column("propiedadId")]
        public Guid PropiedadId { get; set; }

        [Column("valor")]
        [StringLength(250)]
        [Required]
        public string valor { get; set; }
    }
}
