/// <history> 
///     [Alexis Moya] 27/04/2018 Modificado
///     [Franco Retamal] 01/05/2018 Modificado
///     [Rodrigo Torres] 02/05/2018 Modificado
/// </history> 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindaSonrisa.Negocio
{
    public class Cliente
    {
        #region Propiedades
        public string RutPasaporte { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Direccion { get; set; }
        public decimal IdComuna { get; set; }
        public string Dv { get; set; }

        public string RP { get; set; }
        #endregion

        #region Contructor
        public Cliente()
        {
            this.init();
        }

        //Constructor que recive el parametro xml para deserializar y contruir
        public Cliente(String xml)
        {

            Cliente c = Util.Deserializar<Cliente>(xml);

            Nombre = c.Nombre;
            ApellidoPaterno = c.ApellidoPaterno;
            ApellidoMaterno = c.ApellidoMaterno;
            RutPasaporte = c.RutPasaporte;
            Direccion = c.Direccion;
            IdComuna = c.IdComuna;
            Dv = c.Dv;

            RP = c.RP;

        }
        #endregion

        #region Metodos
        private void init()
        {
            //asdsdasdas
            Nombre = string.Empty;
            ApellidoPaterno = string.Empty;
            ApellidoMaterno = string.Empty;
            RutPasaporte = string.Empty;
            Direccion = string.Empty;
            IdComuna = 0;
            Dv = string.Empty;

            RP = string.Empty;
        }

        //Metodo para serializar el objeto cliente actual
        public string Serializar()
        {
            return Util.Serializar<Cliente>(this);
        }

        //Metodo para leer y recuperar datos
        public bool Read()
        {
            try
            {
                Dalc.CLIENTE c = CommonBC.Modelo.CLIENTE.Single(cl => cl.RUT_PASAPORTE == RutPasaporte);

                Nombre = c.NOMBRE;
                ApellidoPaterno = c.APELLIDO_P;
                ApellidoMaterno = c.APELLIDO_M;
                RutPasaporte = c.RUT_PASAPORTE;
                Direccion = c.DIRECCION;
                IdComuna = c.ID_COMUNA;
                Dv = c.DV;
                RP = c.R_P;

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
                Dalc.CLIENTE c = CommonBC.Modelo.CLIENTE.First(cl => cl.RUT_PASAPORTE == RutPasaporte);

                c.NOMBRE = Nombre;
                c.APELLIDO_P = ApellidoPaterno;
                c.APELLIDO_M = ApellidoMaterno;
                c.RUT_PASAPORTE = RutPasaporte;
                c.DIRECCION = Direccion;
                c.ID_COMUNA = IdComuna;
                Dv = c.DV;
                c.R_P = RP;

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
                Dalc.CLIENTE cliente = CommonBC.Modelo.CLIENTE.First(c => c.RUT_PASAPORTE == RutPasaporte);

                CommonBC.Modelo.CLIENTE.Remove(cliente);
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
            Dalc.CLIENTE c = new Dalc.CLIENTE();
            try
            {

                c.NOMBRE = Nombre;
                c.APELLIDO_P = ApellidoPaterno;
                c.APELLIDO_M = ApellidoMaterno;
                c.RUT_PASAPORTE = RutPasaporte;
                c.DIRECCION = Direccion;
                c.ID_COMUNA = IdComuna;
                c.DV = Dv;

                c.R_P = RP;

                CommonBC.Modelo.CLIENTE.Add(c);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                CommonBC.Modelo.CLIENTE.Remove(c);
                return false;
            }

        }
        #endregion
    }
}
