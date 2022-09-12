using System;
using System.Collections.Generic;

#nullable disable

namespace Dominio.Entidades
{
    public partial class Cuentum
    {
        public Cuentum()
        {
            Movimientos = new HashSet<Movimiento>();
        }

        public long Cuentaid { get; set; }
        public string Numcuenta { get; set; }
        public string Tipocuenta { get; set; }
        public decimal Saldoinicial { get; set; }
        public bool Estado { get; set; }
        public long Clienteid { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
