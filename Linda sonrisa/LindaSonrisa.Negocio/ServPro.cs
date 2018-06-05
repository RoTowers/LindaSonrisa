using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindaSonrisa.Negocio
{
    public class ServPro
    {
        public string FamiliaNombre { get; set; }
        public string TipoNombre { get; set; }
        public string ProductoNombre { get; set; }
        public int Cantidad { get; set; }
        public string ServicioNombre { get; set; }
        public int FamiliaId { get; set; }
        public int TipoId { get; set; }
        public string ProductoId { get; set; }
        public int idServicioProducto { get; set; }



        public ServPro()
        {

            idServicioProducto = 0;
            FamiliaNombre = string.Empty;
            TipoNombre = string.Empty;
            ServicioNombre = string.Empty;
            ProductoNombre = string.Empty;
            Cantidad = 0;
        }
    }
}