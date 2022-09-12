using System;
using System.Collections.Generic;

 
namespace Dominio.Entidades
{
    public partial class Cliente
    {
        public Cliente()
        {
            Cuenta = new HashSet<Cuentum>();
        }

        public long Personaid { get; set; }
        public byte[] Contrasenia { get; set; }
        public bool Estado { get; set; }

        public virtual Persona Persona { get; set; }
        public virtual ICollection<Cuentum> Cuenta { get; set; }
    }
}
