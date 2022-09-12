using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class Cuenta
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long cuentaid { get; set; }

        [StringLength(20)]
        [Required]
        public string numcuenta { get; set; }

        [StringLength(20)]
        [Required]
        public string tipocuenta { get; set; }


        [Column(TypeName = "decimal(12,2)")]
        [Required]
        public decimal saldoinicial { get; set; }


        [Required]
        public bool estado { get; set; }

        [ForeignKey("clienteid")]
        [Required]
        public long clienteid { get; set; }

        public Cliente cliente { get; set; }
        public List<Movimiento> movimientos { get; set; }

    }
}
