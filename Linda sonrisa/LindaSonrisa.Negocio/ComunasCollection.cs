/// <history> 
///     [Victor Loyola] 20/05/2018 Modificado
/// </history> 
/// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindaSonrisa.Negocio
{
    public class ComunasCollection
    {
        public List<Comuna> getComunas()
        {
            return getTodasComunas(CommonBC.Modelo.COMUNA.ToList<Dalc.COMUNA>());
        }

        public List<Comuna> getComunasByCiudad(int id)
        {
            return getTodasComunas(CommonBC.Modelo.COMUNA.Where(x => x.ID_PROVINCIA == id).ToList<Dalc.COMUNA>());
        }

        private List<Comuna> getTodasComunas(List<Dalc.COMUNA> list)
        {
            List<Comuna> l = new List<Comuna>();
            //string xmlComuna = string.Empty;

            foreach (Dalc.COMUNA i in list)
            {
                Comuna c = new Comuna(/*xmlComuna*/);
                c.Id = int.Parse(i.ID.ToString());
                c.NombreComuna = i.NOMBRE_COMUNA;
                c.IdProvincia = int.Parse(i.ID_PROVINCIA.ToString());
                c.provincia = null;

                l.Add(c);
            }
            return l;
        }
    }
}
