using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindaSonrisa.Negocio
{
    public class TipoProducto
    {
        #region Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        public FamiliaProducto FamiliaProducto { get; set; }
        #endregion

        #region Constructores
        public TipoProducto()
        {
            this.Init();
        }

        public TipoProducto(string xml)
        {
            TipoProducto f = Util.Deserializar<TipoProducto>(xml);
            Id = f.Id;
            Nombre = f.Nombre;
            FamiliaProducto = f.FamiliaProducto;
        }
        #endregion

        #region Metodos
        private void Init()
        {
            Id = 0;
            Nombre = string.Empty;
            FamiliaProducto = null;
        }

        public string Serializar()
        {
            return Util.Serializar<TipoProducto>(this);
        }

        public bool Read()
        {
            try
            {
                Dalc.TIPO_DE_PRODUCTO tp = CommonBC.Modelo.TIPO_DE_PRODUCTO.First(fp => fp.ID == Id);
                Nombre = tp.NOMBRE;
                Dalc.FAMILIA_DE_PRODUCTOS f = CommonBC.Modelo.FAMILIA_DE_PRODUCTOS.First(fps => fps.ID == tp.FAMILIA_DE_PRODUCTOS_ID);
                FamiliaProducto = new FamiliaProducto();
                FamiliaProducto.Id = int.Parse(f.ID.ToString());
                FamiliaProducto.Nombre = f.NOMBRE;
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
        #endregion
    }
}
