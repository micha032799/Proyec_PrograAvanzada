//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API_PA
{
    using System;
    using System.Collections.Generic;
    
    public partial class TDetalle
    {
        public long ConDetalle { get; set; }
        public long ConMaestro { get; set; }
        public long ConProducto { get; set; }
        public int CantidadCompra { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal Impuesto { get; set; }
    
        public virtual TMaestro TMaestro { get; set; }
        public virtual TProducto TProducto { get; set; }
    }
}
