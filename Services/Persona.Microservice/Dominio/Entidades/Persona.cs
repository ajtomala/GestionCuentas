using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
   public abstract  class  Persona
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Personaid { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Nombre { get; set; }
       
        [Required]
        [StringLength(10, MinimumLength = 1)]
        public string Genero { get; set; }
        
        [Required]
        public int Edad { get; set; }
                
        [Required]
        [StringLength(10, MinimumLength = 1)]
        public string Identificacion { get; set; }
       
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Direccion { get; set; }
       
        [Required]
        [StringLength(10, MinimumLength = 1)]
        public string Telefono { get; set; }
    }
}
