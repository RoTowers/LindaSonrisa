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
    
    public partial class PROVEEDOR
    {
        public PROVEEDOR()
        {
            this.ORDEN_DE_PEDIDO = new HashSet<ORDEN_DE_PEDIDO>();
            this.USUARIOS = new HashSet<USUARIOS>();
        }
    
        public string RUT { get; set; }
        public string DV { get; set; }
        public string NOMBRE { get; set; }
        public string RUBRO { get; set; }
        public Nullable<decimal> TELEFONO { get; set; }
        public string CORREO { get; set; }
        public string DIRECCION { get; set; }
        public Nullable<decimal> ID_COMUNA { get; set; }
    
        public virtual COMUNA COMUNA { get; set; }
        public virtual ICollection<ORDEN_DE_PEDIDO> ORDEN_DE_PEDIDO { get; set; }
        public virtual ICollection<USUARIOS> USUARIOS { get; set; }
    }
}
