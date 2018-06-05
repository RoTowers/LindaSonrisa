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
    public class ProvinciaCollection
    {
        public List<Provincia> ReadAll()
        {
            return ReadAll(CommonBC.Modelo.PROVINCIA.ToList<Dalc.PROVINCIA>());
        }

        private List<Provincia> ReadAll(List<Dalc.PROVINCIA> list)
        {
            List<Provincia> l = new List<Provincia>();

            foreach (Dalc.PROVINCIA i in list)
            {
                Provincia c = new Provincia();
                c.Id = int.Parse(i.ID.ToString());
                c.NombreProvincia = i.NOMBRE_PROVINCIA;

                l.Add(c);
            }
            return l;
        }
    }
}
