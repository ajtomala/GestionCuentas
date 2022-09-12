using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs
{
    public class ClienteActualizarDTO
    {
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
        
        public string identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string contrasenia { get; set; }

        public bool estado { get; set; } = true;
    }
}
