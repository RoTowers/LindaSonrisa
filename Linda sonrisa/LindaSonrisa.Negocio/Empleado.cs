/// <history> 
///     [Alexis Moya] 27/04/2018 Modificado
///     [Franco Retamal] 01/05/2018 Modificado
///     [Rodrigo Torres] 02/05/2018 Modificado
///     [Victor Loyola] 18/05/2018 Modificado
/// </history>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindaSonrisa.Negocio
{
    public class Empleado
    {

        #region Propiedades
        public string Rut { get; set; }
        public string Dv { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public decimal IdComuna { get; set; }
        public decimal IdCargo { get; set; }
        public string Direccion { get; set; }
        public Cargos Cargo { get; set; }
        #endregion

        #region Constructor
        public Empleado()
        {
            this.init();
        }

        //Constructor que recive el parametro xml para deserializar y contruir
        public Empleado(string xml)
        {
            Empleado e = Util.Deserializar<Empleado>(xml);
            Rut = e.Rut;
            Dv = e.Dv;
            Nombre = e.Nombre;
            ApellidoPaterno = e.ApellidoPaterno;
            ApellidoMaterno = e.ApellidoMaterno;
            IdComuna = e.IdComuna;
            IdCargo = e.IdCargo;
            Direccion = e.Direccion;
            Cargo = e.Cargo;
        }
        #endregion

        #region Metodos
        private void init()
        {
            Rut = string.Empty;
            Dv = string.Empty;
            Nombre = string.Empty;
            ApellidoPaterno = string.Empty;
            ApellidoMaterno = string.Empty;
            IdComuna = 0;
            IdCargo = 0;
            Direccion = string.Empty;
            Cargo = new Cargos();
        }


        //Metodo para serializar el objeto Empleado actual
        public string Serializar()
        {
            return Util.Serializar<Empleado>(this);
        }

        //Metodo para leer y recuperar datos
        public bool Read()
        {
            try
            {
                Dalc.EMPLEADO e = CommonBC.Modelo.EMPLEADO.First(emp => emp.RUT == Rut);

                Nombre = e.NOMBRE;
                Dv = e.DV;
                ApellidoPaterno = e.APELLIDO_P;
                ApellidoMaterno = e.APELLIDO_M;
                IdComuna = e.ID_COMUNA;
                IdCargo = e.ID_CARGO;
                Direccion = e.DIRECCION;
                Dalc.CARGO c = CommonBC.Modelo.CARGO.First(ca => ca.ID == IdCargo);
                Cargo.Id = int.Parse(c.ID.ToString());
                Cargo.Nombre = c.NOMBRE;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Metodo para crear empleado
        public bool Create()
        {
            Dalc.EMPLEADO e = new Dalc.EMPLEADO();
            try
            {
                e.RUT = Rut;
                e.DV = Dv;
                e.NOMBRE = Nombre;
                e.APELLIDO_P = ApellidoPaterno;
                e.APELLIDO_M = ApellidoMaterno;
                e.ID_COMUNA = IdComuna;
                e.ID_CARGO = IdCargo;
                e.DIRECCION = Direccion;

                CommonBC.Modelo.EMPLEADO.Add(e);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                CommonBC.Modelo.EMPLEADO.Remove(e);
                return false;
            }
        }

        //Metodo para actualizar empleado
        public bool Update()
        {
            try
            {
                Dalc.EMPLEADO e = CommonBC.Modelo.EMPLEADO.First(b => b.RUT == Rut);
                e.NOMBRE = Nombre;
                e.APELLIDO_P = ApellidoPaterno;
                e.APELLIDO_M = ApellidoMaterno;
                e.ID_COMUNA = IdComuna;
                e.ID_CARGO = IdCargo;
                e.DIRECCION = Direccion;

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
                Dalc.EMPLEADO e = CommonBC.Modelo.EMPLEADO.First(b => b.RUT == Rut);

                CommonBC.Modelo.EMPLEADO.Remove(e);
                CommonBC.Modelo.SaveChanges();

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
