using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindaSonrisa.Negocio
{
    public class Servicio
    {
        public decimal Id { get; set; }
        public string Nombre { get; set; }



        public Servicio()
        {
            Id = 0;
            Nombre = string.Empty;
        }

        public Servicio(String xml)
        {

            Servicio c = Util.Deserializar<Servicio>(xml);

            Id = c.Id;
            Nombre = c.Nombre;

        }


        public string Serializar()
        {
            return Util.Serializar<Servicio>(this);
        }



        public bool Create()
        {
            Dalc.SERVICIO servicio = new Dalc.SERVICIO();
            try
            {

                servicio.ID_SERVICIO = Id;
                servicio.NOMBRE_SERVICIO = Nombre;

                CommonBC.Modelo.SERVICIO.Add(servicio);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                CommonBC.Modelo.SERVICIO.Remove(servicio);
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                Dalc.SERVICIO servicio = CommonBC.Modelo.SERVICIO.First(c => c.ID_SERVICIO == Id);

                servicio.NOMBRE_SERVICIO = Nombre;
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
                Dalc.SERVICIO servicio = CommonBC.Modelo.SERVICIO.First(x => x.ID_SERVICIO == Id);

                CommonBC.Modelo.SERVICIO.Remove(servicio);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool Read()
        {
            try
            {
                Dalc.SERVICIO p = CommonBC.Modelo.SERVICIO.First(pr => pr.NOMBRE_SERVICIO == Nombre);

                Nombre = p.NOMBRE_SERVICIO;
                Id = p.ID_SERVICIO;


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
