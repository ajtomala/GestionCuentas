using System;
using System.Collections.Generic;

#nullable disable

namespace Dominio.Entidades
{
    public partial class Persona
    {
        public long Personaid { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
