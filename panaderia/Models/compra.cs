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
    
    public partial class compra
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int cantidad { get; set; }
        [Required]
        public int precio_neto { get; set; }
        
        public int proveedor_rut { get; set; }
        
        public int productoId { get; set; }
        
        public virtual proveedor proveedor { get; set; }
        
        public virtual producto producto { get; set; }
    }
}
