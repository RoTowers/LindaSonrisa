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
    
    public partial class PRODUCTO
    {
        public PRODUCTO()
        {
            this.ORDENES_PRODUCTO = new HashSet<ORDENES_PRODUCTO>();
            this.SERVICIO_PRODUCTO = new HashSet<SERVICIO_PRODUCTO>();
        }
    
        public string ID { get; set; }
        public string NOMBRE { get; set; }
        public Nullable<decimal> STOCK { get; set; }
        public Nullable<decimal> STOCK_CRITICO { get; set; }
        public Nullable<decimal> PRECIO_COMPRA { get; set; }
        public Nullable<decimal> PRECIO_VENTA { get; set; }
        public Nullable<System.DateTime> FECHA_VENCIMIENTO { get; set; }
        public decimal TIPO_DE_PRODUCTO_ID { get; set; }
    
        public virtual ICollection<ORDENES_PRODUCTO> ORDENES_PRODUCTO { get; set; }
        public virtual TIPO_DE_PRODUCTO TIPO_DE_PRODUCTO { get; set; }
        public virtual ICollection<SERVICIO_PRODUCTO> SERVICIO_PRODUCTO { get; set; }
    }
}
