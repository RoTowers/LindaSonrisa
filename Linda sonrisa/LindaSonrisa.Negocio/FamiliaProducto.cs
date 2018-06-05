using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindaSonrisa.Negocio
{
    public class FamiliaProducto
    {
        #region Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        #endregion

        #region Constructores
        public FamiliaProducto()
        {
            this.Init();
        }

        public FamiliaProducto(string xml)
        {
            FamiliaProducto f = Util.Deserializar<FamiliaProducto>(xml);
            Id = f.Id;
            Nombre = f.Nombre;
        }
        #endregion

        #region Metodos
        public string Serializar()
        {
            return Util.Serializar<FamiliaProducto>(this);
        }


        private void Init()
        {
            Id = 0;
            Nombre = string.Empty;
        }

        public bool Read()
        {
            try
            {
                Dalc.FAMILIA_DE_PRODUCTOS f = CommonBC.Modelo.FAMILIA_DE_PRODUCTOS.First(fp => fp.ID == Id);
                Nombre = f.NOMBRE;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}",Nombre);
        }
        #endregion
    }
}
