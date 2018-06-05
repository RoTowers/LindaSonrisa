using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindaSonrisa.Negocio
{
    public class ServiciosCollection
    {


        public List<Servicio> getAllByNombre(string val)
        {
            return getAll(CommonBC.Modelo.SERVICIO.Where(x => x.NOMBRE_SERVICIO == val).ToList<Dalc.SERVICIO>());
        }

        private List<Servicio> getAll(List<Dalc.SERVICIO> lista)
        {
            List<Servicio> servicio = new List<Servicio>();
            foreach (var i in lista)
            {
                Servicio p = new Servicio();
                p.Id = i.ID_SERVICIO;
                p.Nombre = i.NOMBRE_SERVICIO;



                servicio.Add(p);
            }
            return servicio;
        }

        public List<Servicio> getAll()
        {
            return getAll(CommonBC.Modelo.SERVICIO.ToList<Dalc.SERVICIO>());
        }
    }
}
