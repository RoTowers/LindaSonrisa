using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindaSonrisa.Negocio
{
    public class Producto
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public int StockCritico { get; set; }
        public int PrecioCompra { get; set; }
        public int PrecioVenta { get; set; }
        public Nullable<DateTime> FechaVencimiento { get; set; }
        public int IdTipoProducto { get; set; }
        public int NumeroSecuencial { get; set; }

        public Producto()
        {
            this.Init();
        }

        private void Init()
        {
            Id = string.Empty;
            Nombre = string.Empty;
            Stock = 0;
            StockCritico = 0;
            PrecioCompra = 0;
            PrecioVenta = 0;
            FechaVencimiento = null;
            IdTipoProducto = 0;
            NumeroSecuencial = 0;
        }

        public Producto(string xml)
        {
            Producto p = Util.Deserializar<Producto>(xml);
            Id = p.Id;
            Nombre = p.Nombre;
            Stock = p.Stock;
            StockCritico = p.StockCritico;
            PrecioCompra = p.PrecioCompra;
            PrecioVenta = p.PrecioVenta;
            FechaVencimiento = p.FechaVencimiento;
            IdTipoProducto = p.IdTipoProducto;
        }

        public string Serializar()
        {
            return Util.Serializar<Producto>(this);
        }

        public bool GenerarId(int idFP)
        {
            //Id = IdTipoProducto + "" + PrecioCompra + "" + PrecioVenta;
            bool genera = false;
            string id = string.Empty;
            while (genera == false)
            {
                id = idFP.ToString().PadLeft(3, '0');
                id = id + "" + IdTipoProducto.ToString().PadLeft(3, '0');
                NumeroSecuencial = NumeroSecuencial + 1;
                id = id + "" + NumeroSecuencial.ToString().PadLeft(3, '0');
                try
                {
                    Dalc.PRODUCTO p = CommonBC.Modelo.PRODUCTO.First(pr => pr.ID == id);
                    genera = false;
                }
                catch (Exception ex)
                {
                    genera = true;
                }
            }

            if (genera)
            {
                //Debe estar en string, mientras, se utiliza int
                Id = id;
                return true;
            }else
            {
                return false;
            }
        }

        public bool Create(int idFP)
        {
            Dalc.PRODUCTO prod = new Dalc.PRODUCTO();
            
            try
            {
                if (GenerarId(idFP))
                {
                    prod.ID = Id;
                    prod.NOMBRE = Nombre;
                    prod.STOCK = Stock;
                    prod.STOCK_CRITICO = StockCritico;
                    prod.PRECIO_COMPRA = PrecioCompra;
                    prod.PRECIO_VENTA = PrecioVenta;
                    prod.FECHA_VENCIMIENTO = FechaVencimiento;
                    prod.TIPO_DE_PRODUCTO_ID = IdTipoProducto;
                }
                CommonBC.Modelo.PRODUCTO.Add(prod);
                CommonBC.Modelo.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                CommonBC.Modelo.PRODUCTO.Remove(prod);
                return false;
            }
        }

        public bool Read()
        {
            try
            {
                Dalc.PRODUCTO p = CommonBC.Modelo.PRODUCTO.First(pr => pr.ID == Id);

                Nombre = p.NOMBRE;
                Stock = int.Parse(p.STOCK.ToString());
                StockCritico = int.Parse(p.STOCK_CRITICO.ToString());
                PrecioCompra = int.Parse(p.PRECIO_COMPRA.ToString());
                PrecioVenta = int.Parse(p.PRECIO_VENTA.ToString());
                if (p.FECHA_VENCIMIENTO == null)
                {
                    FechaVencimiento = null;
                }
                else
                {
                    FechaVencimiento = DateTime.Parse(p.FECHA_VENCIMIENTO.Value.ToString());
                }
                IdTipoProducto = int.Parse(p.TIPO_DE_PRODUCTO_ID.ToString());

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                Dalc.PRODUCTO prod = CommonBC.Modelo.PRODUCTO.First(b => b.ID == Id);
                prod.NOMBRE = Nombre;
                prod.STOCK = Stock;
                prod.STOCK_CRITICO = StockCritico;
                prod.PRECIO_COMPRA = PrecioCompra;
                prod.PRECIO_VENTA = PrecioVenta;
                prod.FECHA_VENCIMIENTO = FechaVencimiento;
                prod.TIPO_DE_PRODUCTO_ID = IdTipoProducto;

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
                Dalc.PRODUCTO producto = CommonBC.Modelo.PRODUCTO.First(x => x.ID == Id);

                CommonBC.Modelo.PRODUCTO.Remove(producto);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool LeerProductoPorNombre()
        {
            try
            {
                Dalc.PRODUCTO p = CommonBC.Modelo.PRODUCTO.First(pr => pr.NOMBRE == Nombre);

                Id = p.ID;
                Nombre = p.NOMBRE;
                Stock = int.Parse(p.STOCK.ToString());
                StockCritico = int.Parse(p.STOCK_CRITICO.ToString());
                PrecioCompra = int.Parse(p.PRECIO_COMPRA.ToString());
                PrecioVenta = int.Parse(p.PRECIO_VENTA.ToString());
                if (p.FECHA_VENCIMIENTO == null)
                {
                    FechaVencimiento = null;
                }
                else
                {
                    FechaVencimiento = DateTime.Parse(p.FECHA_VENCIMIENTO.Value.ToString());
                }
                IdTipoProducto = int.Parse(p.TIPO_DE_PRODUCTO_ID.ToString());

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}", Nombre);
        }
    }
}
