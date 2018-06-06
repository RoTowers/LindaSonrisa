using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindaSonrisa.Negocio
{
    public class Horario
    {
        public decimal Id { get; set; }
        public Nullable<System.DateTime> DiaAtencion { get; set; }
        public Nullable<System.DateTime> HoraAtencion { get; set; }
        public decimal IdServicio { get; set; }
        public decimal IdOdontologo { get; set; }

        public Horario()
        {
            this.Init();
        }



        public Horario(string xml)
        {
            Horario r = Util.Deserializar<Horario>(xml);
            Id = r.Id;
            DiaAtencion = r.DiaAtencion;
            HoraAtencion = r.HoraAtencion;
            IdServicio = r.IdServicio;
            IdOdontologo = r.IdOdontologo;
        }

        private void Init()
        {
            Id = 0;
            DiaAtencion = DateTime.Now;
            HoraAtencion = DateTime.Now;
            IdServicio = 0;
            IdOdontologo = 0;
        }

        public string Serializar()
        {
            return Util.Serializar<Horario>(this);
        }

        //Metodo para leer y recuperar datos
        public bool Read()
        {
            try
            {
                Dalc.HORARIO r = CommonBC.Modelo.HORARIO.Single(rx => rx.ID == Id);

                Id = r.ID;
                DiaAtencion = r.DIA_ATENCION;
                HoraAtencion = r.HORA_ATENCION;
                IdServicio = r.ID_SERVICIO;
                IdOdontologo = r.ID_ODONTOLOGO;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool LeerPorIdServicio()
        {
            try
            {
                Dalc.HORARIO r = CommonBC.Modelo.HORARIO.Single(rx => rx.ID_SERVICIO == IdServicio);

                Id = r.ID;
                DiaAtencion = r.DIA_ATENCION;
                HoraAtencion = r.HORA_ATENCION;
                IdServicio = r.ID_SERVICIO;
                IdOdontologo = r.ID_ODONTOLOGO;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }




        public bool Update()
        {
            try
            {
                Dalc.HORARIO r = CommonBC.Modelo.HORARIO.First(rx => rx.ID == Id);

                r.ID = Id;
                r.DIA_ATENCION = DiaAtencion;
                r.HORA_ATENCION = HoraAtencion;
                r.ID_SERVICIO = IdServicio;
                r.ID_ODONTOLOGO = IdOdontologo;


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
                Dalc.HORARIO r = CommonBC.Modelo.HORARIO.First(rx => rx.ID == Id);

                CommonBC.Modelo.HORARIO.Remove(r);
                CommonBC.Modelo.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }


        }

        public bool Create()
        {
            Dalc.HORARIO r = new Dalc.HORARIO();
            try
            {


                r.ID = Id;
                r.DIA_ATENCION = DiaAtencion;
                r.HORA_ATENCION = HoraAtencion;
                r.ID_SERVICIO = IdServicio;
                r.ID_ODONTOLOGO = IdOdontologo;

                CommonBC.Modelo.HORARIO.Add(r);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                CommonBC.Modelo.HORARIO.Remove(r);
                return false;
            }

        }

    }
}