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
    
    public partial class ORDEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDEN()
        {
            this.DETALLE_ORDEN = new HashSet<DETALLE_ORDEN>();
        }
    
        public int ID_ORDEN { get; set; }
        public Nullable<int> ID_CLIENTE { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public decimal TOTAL { get; set; }
        public int ESTADO { get; set; }
    
        public virtual CLIENTE CLIENTE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_ORDEN> DETALLE_ORDEN { get; set; }
    }
}
