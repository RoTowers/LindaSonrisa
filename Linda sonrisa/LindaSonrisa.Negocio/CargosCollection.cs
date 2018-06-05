using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LindaSonrisa.Dalc;

namespace LindaSonrisa.Negocio
{
    public class CargosCollection
    {
        public List<Cargos> getCargos()
        {
            return getTodosCargos(CommonBC.Modelo.CARGO.ToList<Dalc.CARGO>());
        }


        private List<Cargos> getTodosCargos(List<Dalc.CARGO> list)
        {
            List<Cargos> l = new List<Cargos>();

            foreach (Dalc.CARGO i in list)
            {
                Cargos c = new Cargos();
                c.Id = int.Parse(i.ID.ToString());
                c.Nombre = i.NOMBRE;

                l.Add(c);
            }
            return l;
        }
    }
}
