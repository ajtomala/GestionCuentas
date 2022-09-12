using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Cliente : Persona
    {
        //[Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int ClienteId { get; set; }
        
                       
        [Required]
        public byte[] contrasenia { get; set; }

        [Required]
        public bool estado { get; set; }
       
    }
}
