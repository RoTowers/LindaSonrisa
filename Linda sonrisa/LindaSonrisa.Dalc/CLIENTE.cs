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
    
    public partial class CLIENTE
    {
        public CLIENTE()
        {
            this.BOLETA = new HashSet<BOLETA>();
            this.RESERVA = new HashSet<RESERVA>();
            this.SITUACION_ECONOMICA = new HashSet<SITUACION_ECONOMICA>();
            this.USUARIOS = new HashSet<USUARIOS>();
        }
    
        public string RUT_PASAPORTE { get; set; }
        public string DV { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO_P { get; set; }
        public string APELLIDO_M { get; set; }
        public string DIRECCION { get; set; }
        public decimal ID_COMUNA { get; set; }
        public string R_P { get; set; }
    
        public virtual ICollection<BOLETA> BOLETA { get; set; }
        public virtual COMUNA COMUNA { get; set; }
        public virtual ICollection<RESERVA> RESERVA { get; set; }
        public virtual ICollection<SITUACION_ECONOMICA> SITUACION_ECONOMICA { get; set; }
        public virtual ICollection<USUARIOS> USUARIOS { get; set; }
    }
}
