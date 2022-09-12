using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs
{
    public class CuentaActualizarDTO
    {
        public string Numcuenta { get; }
        public string Tipocuenta { get; set; }
        public decimal Saldoinicial { get; set; }
        public bool Estado { get; set; }
    }
}
