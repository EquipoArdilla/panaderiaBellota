//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace panaderia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class usuario
    {
        public usuario()
        {
            this.producto = new HashSet<producto>();
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string clave { get; set; }        
        public int rolusuarioId { get; set; }
    
        public virtual ICollection<producto> producto { get; set; }
        public virtual rolusuario rolusuario { get; set; }
    }
}
