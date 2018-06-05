using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindaSonrisa.Negocio
{
    public class Servicio_Producto
    {
        public decimal Id { get; set; }
        public string IdProducto { get; set; }
        public decimal IdServicio { get; set; }
        public Nullable<decimal> Cantidad { get; set; }

        public Servicio_Producto()
        {
            Id = 0;
            IdProducto = string.Empty;
            IdServicio = 0;
            Cantidad = 0;
        }

        public Servicio_Producto(string xml)
        {
            Servicio_Producto c = Util.Deserializar<Servicio_Producto>(xml);
            Id = c.Id;
            IdProducto = c.IdProducto;
            IdServicio = c.IdServicio;
            Cantidad = c.Cantidad;
        }


        public string Serializar()
        {
            return Util.Serializar<Servicio_Producto>(this);
        }

        public bool Create()
        {
            Dalc.SERVICIO_PRODUCTO servicioProducto = new Dalc.SERVICIO_PRODUCTO();
            try
            {

                //servicioProducto.ID = Id;
                servicioProducto.PRODUCTO_ID = IdProducto.ToString();
                servicioProducto.ID_SERVICIO = IdServicio;
                servicioProducto.CANTIDAD = Cantidad;
                CommonBC.Modelo.SERVICIO_PRODUCTO.Add(servicioProducto);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                CommonBC.Modelo.SERVICIO_PRODUCTO.Remove(servicioProducto);
                return false;
            }
        }


        public bool Update()
        {
            try
            {
                Dalc.SERVICIO_PRODUCTO servicioProducto = CommonBC.Modelo.SERVICIO_PRODUCTO.First(c => c.ID == Id);

                servicioProducto.ID_SERVICIO = IdServicio;
                servicioProducto.PRODUCTO_ID = IdProducto.ToString();
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public bool Delete()
        {
            try
            {
                Dalc.SERVICIO_PRODUCTO servicioProducto = CommonBC.Modelo.SERVICIO_PRODUCTO.First(x => x.ID == Id);

                CommonBC.Modelo.SERVICIO_PRODUCTO.Remove(servicioProducto);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool Read()
        {
            try
            {
                Dalc.SERVICIO_PRODUCTO p = CommonBC.Modelo.SERVICIO_PRODUCTO.First(pr => pr.ID == Id);

                IdProducto = p.PRODUCTO_ID;
                IdServicio = p.ID_SERVICIO;


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
