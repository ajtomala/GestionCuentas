using System;
using System.Collections.Generic;

 
namespace Dominio.Entidades
{
    public partial class Movimiento
    {
        public long Movimientoid { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipomovimiento { get; set; }
        public string Descripcion { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public long Cuentaid { get; set; }

        public virtual Cuentum Cuenta { get; set; }
    }
}
