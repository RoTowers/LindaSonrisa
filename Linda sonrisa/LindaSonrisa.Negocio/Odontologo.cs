using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindaSonrisa.Negocio
{
    public class Odontologo
    {
        public int Id { get; set; }
        public string RutEmpleado { get; set; }


        #region Constructores
        public Odontologo()
        {
            this.Init();
        }

        private void Init()
        {
            Id = 0;
            RutEmpleado = string.Empty;
        }

        public Odontologo(string xml)
        {
            Odontologo c = Util.Deserializar<Odontologo>(xml);

            Id = c.Id;
            RutEmpleado = c.RutEmpleado;
        }
        #endregion

        #region Metodos
        public string Serializar()
        {
            return Util.Serializar<Odontologo>(this);
        }

        public bool Read()
        {
            try
            {
                Dalc.ODONTOLOGO c = CommonBC.Modelo.ODONTOLOGO.First(cl => cl.ID_ODONTOLOGO == Id);

                Id = int.Parse(c.ID_ODONTOLOGO.ToString());
                RutEmpleado = c.RUT_EMPLEADO;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Create()
        {
            Dalc.ODONTOLOGO e = new Dalc.ODONTOLOGO();
            try
            {
                e.ID_ODONTOLOGO = Id;
                e.RUT_EMPLEADO = RutEmpleado;

                CommonBC.Modelo.ODONTOLOGO.Add(e);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                CommonBC.Modelo.ODONTOLOGO.Remove(e);
                return false;
            }
        }

        //Metodo para actualizar empleado
        public bool Update()
        {
            try
            {
                Dalc.ODONTOLOGO e = CommonBC.Modelo.ODONTOLOGO.First(b => b.ID_ODONTOLOGO == Id);
                e.ID_ODONTOLOGO = Id;
                e.RUT_EMPLEADO = RutEmpleado;

                CommonBC.Modelo.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Metodo para borrar empleado
        public bool Delete()
        {
            try
            {
                Dalc.ODONTOLOGO e = CommonBC.Modelo.ODONTOLOGO.First(b => b.ID_ODONTOLOGO == Id);

                CommonBC.Modelo.ODONTOLOGO.Remove(e);
                CommonBC.Modelo.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteByRut()
        {
            try
            {
                Dalc.ODONTOLOGO e = CommonBC.Modelo.ODONTOLOGO.First(b => b.RUT_EMPLEADO == RutEmpleado);

                CommonBC.Modelo.ODONTOLOGO.Remove(e);
                CommonBC.Modelo.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //Devuelve el nombre de los odontologos en un string
        public override string ToString()
        {
            return string.Format("{0}", RutEmpleado);
        }
        #endregion

        //[21:52, 27/5/2018]
        //Ro Towers: este es un codigo que hice para crear un numero consecutivo
        //[21:52, 27 / 5 / 2018] 
        //Ro Towers: 
        public bool GenerarId(int idOdontologo)
        {
            ////Id = IdTipoProducto + "" + PrecioCompra + "" + PrecioVenta;
            //bool genera = false;
            //string id = string.Empty;
            //while (genera == false)
            //{
            //    id = idOdontologo.ToString().PadLeft(3, '0');
            //    id = id.ToString().PadLeft(3, '0');
            //    NumeroSecuencial = NumeroSecuencial + 1;
            //    id = id + "" + NumeroSecuencial.ToString().PadLeft(3, '0');
            //    try
            //    {
            //        Dalc.ODONTOLOGO p = CommonBC.Modelo.ODONTOLOGO.First(pr => pr.ID_ODONTOLOGO == int.Parse(id));
            //        genera = false;
            //    }
            //    catch (Exception ex)
            //    {
            //        genera = true;
            //    }
            //}

            //if (genera)
            //{
            //    //Debe estar en string, mientras, se utiliza int
            //    Id = int.Parse(id.ToString());
            //    return true;
            //}
            //else
            //{
            return false;
            //}
        }
    }
}
