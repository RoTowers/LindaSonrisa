using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LindaSonrisa.Dalc;

namespace LindaSonrisa.Negocio
{
    public class ProductosCollection
    {
        public List<Producto> getAll()
        {
            return getAll(CommonBC.Modelo.PRODUCTO.ToList<Dalc.PRODUCTO>());
        }

        public List<Producto> getAllByTipo(int val)
        {
            return getAll(CommonBC.Modelo.PRODUCTO.Where(x => x.TIPO_DE_PRODUCTO_ID == val).ToList<Dalc.PRODUCTO>());
        }

        private List<Producto> getAll(List<Dalc.PRODUCTO> lista)
        {
            List<Producto> productos = new List<Producto>();
            foreach (var i in lista)
            {
                Producto p = new Producto();
                p.Id = i.ID;
                p.Nombre = i.NOMBRE;
                p.Stock = int.Parse(i.STOCK.ToString());
                p.StockCritico = int.Parse(i.STOCK_CRITICO.ToString());
                p.PrecioCompra = int.Parse(i.PRECIO_COMPRA.ToString());
                p.PrecioVenta = int.Parse(i.PRECIO_VENTA.ToString());
                if (i.FECHA_VENCIMIENTO == null)
                {
                    p.FechaVencimiento = null;
                }
                else
                {
                    p.FechaVencimiento = DateTime.Parse(i.FECHA_VENCIMIENTO.Value.ToString());
                }
                p.IdTipoProducto = int.Parse(i.TIPO_DE_PRODUCTO_ID.ToString());

                productos.Add(p);
            }
            return productos;
        }
    }
}
