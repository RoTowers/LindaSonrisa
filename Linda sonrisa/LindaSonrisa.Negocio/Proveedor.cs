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
    public class Proveedor
    {
        #region Propiedades
        public string Rut { get; set; }
        public string Dv { get; set; }
        public string Nombre { get; set; }
        public string Rubro { get; set; }
        public Nullable<decimal> Telefono { get; set; }
        public string Correo { get; set; }

        public Nullable<decimal> IdComuna { get; set; }
        public string Direccion { get; set; }

        public string RutDv { get; set; }
        public string NombreComuna { get; set; }
        #endregion

        #region Constructor
        public Proveedor()
        {
            this.init();
        }

        public string ObtenerRut()
        {
            RutDv = string.Format(Rut + "-" + Dv);
            return RutDv;


        }

        //Constructor que recive el parametro xml para deserializar y contruir
        public Proveedor(string xml)
        {
            Proveedor p = Util.Deserializar<Proveedor>(xml);
            Nombre = p.Nombre;
            Rubro = p.Rubro;
            Telefono = p.Telefono;
            Rut = p.Rut;
            IdComuna = p.IdComuna;
            Direccion = p.Direccion;
            Correo = p.Correo;
            Dv = p.Dv;
            RutDv = p.ObtenerRut();
            NombreComuna = p.ObtenerComuna();
        }

        public string ObtenerComuna()
        {
            Comuna c = new Comuna();
            try
            {
                c.Id = int.Parse(IdComuna.ToString());
                c.Read();
            }
            catch (Exception)
            {

                throw;
            }

            return c.NombreComuna;
        }
        #endregion

        #region Metodos
        private void init()
        {
            Rut = string.Empty;
            Nombre = string.Empty;
            Rubro = string.Empty;
            Telefono = 0;
            Correo = string.Empty;
            Dv = string.Empty;
            IdComuna = 0;
        }

        //Metodo para serializar el objeto Proveedor actual
        public string Serializar()
        {
            return Util.Serializar<Proveedor>(this);
        }

        public bool Crear()
        {
            Dalc.PROVEEDOR p = new Dalc.PROVEEDOR();
            try
            {

                p.RUT = Rut;
                p.NOMBRE = Nombre;
                p.CORREO = Correo;
                p.TELEFONO = Telefono;
                p.RUBRO = Rubro;
                p.ID_COMUNA = IdComuna;
                p.DV = Dv;
                p.DIRECCION = Direccion;

                CommonBC.Modelo.PROVEEDOR.Add(p);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                CommonBC.Modelo.PROVEEDOR.Remove(p);
                return false;
            }

        }

        public bool Actualizar()
        {
            Dalc.PROVEEDOR p = CommonBC.Modelo.PROVEEDOR.Single(prov => prov.RUT == Rut);

            try
            {
                p.NOMBRE = Nombre;
                p.RUT = Rut;
                p.CORREO = Correo;
                p.TELEFONO = Telefono;
                p.RUBRO = Rubro;
                p.ID_COMUNA = IdComuna;
                p.DV = Dv;
                p.DIRECCION = Direccion;

                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                CommonBC.Modelo.PROVEEDOR.Remove(p);
                return false;
            }
        }

        public bool Eliminar()
        {
            Dalc.PROVEEDOR p = CommonBC.Modelo.PROVEEDOR.Single(prov => prov.RUT == Rut);

            try
            {

                CommonBC.Modelo.PROVEEDOR.Remove(p);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Metodo para leer y recuperar datos
        public bool Leer()
        {
            try
            {
                Dalc.PROVEEDOR p = CommonBC.Modelo.PROVEEDOR.Single(prob => prob.RUT == Rut);


                Nombre = p.NOMBRE;
                Rubro = p.RUBRO;
                Telefono = p.TELEFONO;
                Correo = p.CORREO;
                IdComuna = p.ID_COMUNA;
                Dv = p.DV;
                Direccion = p.DIRECCION;


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}
