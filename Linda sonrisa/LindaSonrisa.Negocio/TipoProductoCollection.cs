using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindaSonrisa.Negocio
{
    public class TipoProductoCollection
    {
        public List<TipoProducto> readAll()
        {
            return readAll(CommonBC.Modelo.TIPO_DE_PRODUCTO.ToList<Dalc.TIPO_DE_PRODUCTO>());
        }

        public List<TipoProducto> readAllBy(int id)
        {
            return readAll(CommonBC.Modelo.TIPO_DE_PRODUCTO.Where(x => x.FAMILIA_DE_PRODUCTOS_ID == id).ToList<Dalc.TIPO_DE_PRODUCTO>());
        }

        private List<TipoProducto> readAll(List<Dalc.TIPO_DE_PRODUCTO> listaFP)
        {
            List<TipoProducto> fpc = new List<TipoProducto>();
            foreach (var i in listaFP)
            {
                TipoProducto f = new TipoProducto();
                f.Id = int.Parse(i.ID.ToString());
                f.Nombre = i.NOMBRE;
                fpc.Add(f);
            }
            return fpc;
        }
    }
}
