using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Movimiento
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long movimientoid { get; set; }

         
        [Required]
        public DateTime fecha { get; set; }

        [StringLength(20)]
        [Required]
        public string tipomovimiento { get; set; }

        [StringLength(20)]
        [Required]
        public string descripcion { get; set; }


        [Column(TypeName = "decimal(12,2)")]
        [Required]
        public decimal valor { get; set; }


        [Column(TypeName = "decimal(12,2)")]
        [Required]
        public bool saldo { get; set; }

        [ForeignKey("cuentaid")]
        [Required]
        public long cuentaid { get; set; }

        public Cuenta cuenta { get; set; }

    }
}
