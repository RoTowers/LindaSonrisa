/// <history> 
///     [Victor Loyola] 19/05/2018 Modificado
/// </history> 
/// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindaSonrisa.Negocio
{
    public class Provincia
    {
        #region Propiedades
        public int Id { get; set; }
        public string NombreProvincia { get; set; }
        #endregion

        #region Constructores
        public Provincia()
        {
            this.Init();
        }

        private void Init()
        {
            Id = 0;
            NombreProvincia = string.Empty;
        }

        public Provincia(string xml)
        {
            Provincia c = Util.Deserializar<Provincia>(xml);

            Id = c.Id;
            NombreProvincia = c.NombreProvincia;
        }
        #endregion

        #region Metodos
        public string Serializar()
        {
            return Util.Serializar<Provincia>(this);
        }

        public bool Read()
        {
            try
            {
                Dalc.PROVINCIA c = CommonBC.Modelo.PROVINCIA.First(cl => cl.ID == Id);


                Id = int.Parse(c.ID.ToString());
                NombreProvincia = c.NOMBRE_PROVINCIA;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Devuelve el nombre de las ciudades en un string
        public override string ToString()
        {
            return string.Format("{0}", NombreProvincia);
        }
        #endregion
    }
}
