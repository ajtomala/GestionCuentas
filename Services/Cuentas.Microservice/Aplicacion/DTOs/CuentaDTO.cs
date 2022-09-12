using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs
{
   public class CuentaDTO
    {
        public string identificacion { get; set; }
        public string numcuenta { get; set; }
        public string tipocuenta { get; set; }
        public decimal saldoinicial { get; set; }
      
    }
}
