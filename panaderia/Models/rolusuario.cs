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
    
    public partial class rolusuario
    {
        public rolusuario()
        {
            this.usuario = new HashSet<usuario>();
        }
    
        public int Id { get; set; }
        [Required]
        public string rol { get; set; }
    
        public virtual ICollection<usuario> usuario { get; set; }
    }
}
