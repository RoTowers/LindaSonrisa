//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LindaSonrisa.Dalc
{
    using System;
    using System.Collections.Generic;
    
    public partial class ORDEN_DE_PEDIDO
    {
        public ORDEN_DE_PEDIDO()
        {
            this.ORDENES_PRODUCTO = new HashSet<ORDENES_PRODUCTO>();
        }
    
        public decimal ID { get; set; }
        public string EMPLEADO_RUT { get; set; }
        public string PROVEEDOR_RUT { get; set; }
    
        public virtual EMPLEADO EMPLEADO { get; set; }
        public virtual PROVEEDOR PROVEEDOR { get; set; }
        public virtual ICollection<ORDENES_PRODUCTO> ORDENES_PRODUCTO { get; set; }
    }
}
