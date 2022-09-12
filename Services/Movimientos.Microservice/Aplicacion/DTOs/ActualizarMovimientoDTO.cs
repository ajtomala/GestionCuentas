using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs
{
    public class ActualizarMovimientoDTO
    {
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }

        public string TipoMovimiento { get; set; }
        public decimal Valor { get; set; }

        public decimal Saldo { get; set; }
    }
}
