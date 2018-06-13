using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using panaderia.Models;

    public class CombosSelecciona
    {
        public List<producto> producto { get; set; }
        public List<medida> medida { get; set; }
        public List<receta> receta { get; set; }
        public List<detalle_receta> detalle_receta { get; set; }
        public int? idSeleccionado { get; internal set; }

    }
