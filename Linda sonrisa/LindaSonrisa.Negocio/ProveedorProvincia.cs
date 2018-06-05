using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindaSonrisa.Negocio
{
    public class ProveedorProvincia
    {
        public string Rut { get; set; }
        public string Dv { get; set; }
        public string Nombre { get; set; }
        public string Rubro { get; set; }
        public Nullable<decimal> Telefono { get; set; }
        public string Correo { get; set; }

        public Nullable<decimal> IdComuna { get; set; }
        public string Direccion { get; set; }
    
        public string RutDv { get; set; }
        public string NombreComuna { get; set; }
        public Nullable<decimal> IdProvincia { get; set; }
    }
}
