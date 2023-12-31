﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_PA.Entities
{
    public class CarritoEnt
    {
        public long ConCarrito { get; set; }
        public long ConUsuario { get; set; }
        public long ConProducto { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaCarrito { get; set; }
        public decimal Precio { get; set; }
        public string Nombre { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }
    }
}