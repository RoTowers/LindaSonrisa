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
    
    public partial class SITUACION_ECONOMICA
    {
        public SITUACION_ECONOMICA()
        {
            this.DOCUMENTO = new HashSet<DOCUMENTO>();
        }
    
        public string ID { get; set; }
        public string ESTADO { get; set; }
        public string CLIENTE_RUT { get; set; }
    
        public virtual CLIENTE CLIENTE { get; set; }
        public virtual ICollection<DOCUMENTO> DOCUMENTO { get; set; }
    }
}
