using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs
{
    public class CuentaEditarDTO
    {
        
        public decimal SaldoInicial { get; set; }
        public string Tipocuenta { get; set; }

        public bool Estado { get; set; }


    }
}
