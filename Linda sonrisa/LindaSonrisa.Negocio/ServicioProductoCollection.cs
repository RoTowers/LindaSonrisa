using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindaSonrisa.Negocio
{
    public class ServicioProductoCollection
    {

        public List<Servicio_Producto> getAllByIdServicio(decimal val)
        {
            return getAll(CommonBC.Modelo.SERVICIO_PRODUCTO.Where(x => x.ID_SERVICIO == val).ToList<Dalc.SERVICIO_PRODUCTO>());
        }

        private List<Servicio_Producto> getAll(List<Dalc.SERVICIO_PRODUCTO> lista)
        {
            List<Servicio_Producto> serviciop = new List<Servicio_Producto>();
            foreach (var i in lista)
            {
                Servicio_Producto p = new Servicio_Producto();
                p.Id = i.ID;
                p.IdProducto = i.PRODUCTO_ID;
                p.IdServicio = i.ID_SERVICIO;
                p.Cantidad = i.CANTIDAD;


                serviciop.Add(p);
            }
            return serviciop;
        }

        public List<Servicio_Producto> getAll()
        {
            return getAll(CommonBC.Modelo.SERVICIO_PRODUCTO.ToList<Dalc.SERVICIO_PRODUCTO>());
        }
    }
}
