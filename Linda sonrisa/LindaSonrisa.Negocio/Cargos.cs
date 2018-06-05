/// <history> 
///     [Victor Loyola] 23/05/2018 Modificado
/// </history> 
/// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindaSonrisa.Negocio
{
    public class Cargos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        #region Constructores
        public Cargos()
        {
            this.Init();
        }

        private void Init()
        {
            Id = 0;
            Nombre = string.Empty;
        }

        public Cargos(string xml)
        {
            Cargos c = Util.Deserializar<Cargos>(xml);

            Id = c.Id;
            Nombre = c.Nombre;
        }
        #endregion

        #region Metodos
        public string Serializar()
        {
            return Util.Serializar<Cargos>(this);
        }

        public bool Read()
        {
            try
            {
                Dalc.CARGO e = CommonBC.Modelo.CARGO.First(emp => emp.ID == Id);

                Nombre = e.NOMBRE;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Devuelve el nombre de los cargos en un string
        public override string ToString()
        {
            return string.Format("{0}", Nombre);
        }
        #endregion
    }
}
