/// <history> 
///     [Victor Loyola] 19/05/2018 Modificado
/// </history> 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindaSonrisa.Negocio
{
    public class Comuna
    {
        #region Propiedades
        public int Id { get; set; }
        public string NombreComuna { get; set; }
        public int IdProvincia { get; set; }
        public Provincia provincia { get; set; }
        #endregion

        #region Constructores
        public Comuna()
        {
            this.Init();
        }

        private void Init()
        {
            Id = 0;
            NombreComuna = string.Empty;
            IdProvincia = 0;
            provincia = new Provincia();
        }

        public Comuna(string xml)
        {
            Comuna c = Util.Deserializar<Comuna>(xml);

            Id = c.Id;
            NombreComuna = c.NombreComuna;
            IdProvincia = c.IdProvincia;
            provincia = c.provincia;
        }
        #endregion

        #region Metodos
        public string Serializar()
        {
            return Util.Serializar<Comuna>(this);
        }

        public bool Read()
        {
            try
            {
                Dalc.COMUNA c = CommonBC.Modelo.COMUNA.First(cl => cl.ID == Id);
                
                Id = int.Parse(c.ID.ToString());
                NombreComuna = c.NOMBRE_COMUNA;
                IdProvincia = (int)c.ID_PROVINCIA;
                Dalc.PROVINCIA cd = CommonBC.Modelo.PROVINCIA.First(x => x.ID == IdProvincia);
                provincia.Id = (int)cd.ID;
                provincia.NombreProvincia = cd.NOMBRE_PROVINCIA;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Devuelve el nombre de las comunas en un string
        public override string ToString()
        {
            return string.Format("{0}", NombreComuna);
        }
        #endregion
    }
}
