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
   public class Usuario
    {
        #region Propiedades
        public string Nombre { get; set; }
        public string Perfil { get; set; }
        public string Contrasena { get; set; }
        public string RutEmpleado { get; set; }
        public string RutPasaporteCliente { get; set; }
        public string RutProveedor { get; set; }
        public int NumeroSecuencial { get; set; }
        public int LogIn { get; set; }

        public Cliente cliente;

        public Proveedor proveedor;

        public Empleado empleado;
        #endregion

        #region Constructor

        public Usuario()
        {
            this.Init();
        }

        //Constructor que recive el parametro xml para deserializar y contruir
        public Usuario(string xml)
        {
            Usuario u = Util.Deserializar<Usuario>(xml);

            Nombre = u.Nombre;
            Contrasena = u.Contrasena;
            RutPasaporteCliente = u.RutPasaporteCliente;
            RutEmpleado = u.RutEmpleado;
            RutProveedor = u.RutProveedor;
            Perfil = u.Perfil;
            LogIn = u.LogIn;

            cliente = u.cliente;
            proveedor = u.proveedor;
            empleado = u.empleado;
        }
        #endregion

        #region Metodos

        private void Init()
        {
            Nombre = string.Empty;
            Contrasena = string.Empty;
            RutPasaporteCliente = string.Empty;
            RutEmpleado = string.Empty;
            RutProveedor = string.Empty;
            cliente = null;
            proveedor = null;
            empleado = null;
            NumeroSecuencial = 0;
            LogIn = 0; 
        }

        //Metodo para serializar el objeto Usuario actual
        public string Serializar()
        {
            return Util.Serializar<Usuario>(this);
        }

        //Metodo para validar nombre de usuario y contraseña del usuario actual
        public bool Valida()
        {
            try
            {
                Dalc.USUARIOS usuario = CommonBC.Modelo.USUARIOS.Single(u => u.NOMBRE == Nombre);
                if (usuario.CONTRASENA == Contrasena)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Metodo para leer y recuperar datos
        public bool Read()
        {
            try
            {
                Dalc.USUARIOS usuario = CommonBC.Modelo.USUARIOS.Single(u => u.NOMBRE == Nombre);
                Contrasena = usuario.CONTRASENA;
                Perfil = usuario.PERFIL;
                RutPasaporteCliente = usuario.CLIENTE_R_P;
                RutEmpleado = usuario.EMPLEADO_RUT;
                RutProveedor = usuario.PROVEEDOR_RUT;
                LogIn = int.Parse(usuario.LOGIN.ToString());

                if (RutPasaporteCliente != "")
                {
                    Cliente cl = new Cliente();
                    cl.RutPasaporte = RutPasaporteCliente;
                    cl.Read();
                    cliente = cl;
                    
                }

                if (RutProveedor != "") {
                    Proveedor p = new Proveedor();
                    p.Rut = RutProveedor;
                    p.Leer();
                    proveedor = p;
                }

                if (RutEmpleado != "") {
                    Empleado e = new Empleado();
                    e.Rut = RutEmpleado;
                    e.Read();
                    empleado = e;

                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ReadByRut()
        {
            try
            {
                Dalc.USUARIOS usuario = new Dalc.USUARIOS();
                if (RutEmpleado != "")
                {
                    usuario = CommonBC.Modelo.USUARIOS.Single(u => u.EMPLEADO_RUT == RutEmpleado);
                }
                if (RutPasaporteCliente != "")
                {
                    usuario = CommonBC.Modelo.USUARIOS.Single(u => u.CLIENTE_R_P == RutPasaporteCliente);
                }
                if (RutProveedor != "")
                {
                    usuario = CommonBC.Modelo.USUARIOS.Single(u => u.PROVEEDOR_RUT == RutProveedor);
                }
                Nombre = usuario.NOMBRE;
                Contrasena = usuario.CONTRASENA;
                Perfil = usuario.PERFIL;
                RutPasaporteCliente = usuario.CLIENTE_R_P;
                RutEmpleado = usuario.EMPLEADO_RUT;
                RutProveedor = usuario.PROVEEDOR_RUT;
                LogIn = (int)usuario.LOGIN;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Create()
        {
            Dalc.USUARIOS usuario = new Dalc.USUARIOS();
            try
            {


                string tipo = string.Empty;
                if (RutPasaporteCliente != "")
                {
                    tipo = "c";
                }

                if (RutEmpleado != "")
                {
                    tipo = "e";
                }

                if (RutProveedor != "")
                {
                    tipo = "p";
                }
                if (GenerarNombreUs(tipo))
                {
                    usuario.NOMBRE = Nombre;
                    usuario.PERFIL = Perfil;
                    usuario.CONTRASENA = "1234";
                    usuario.LOGIN = 0;
                    usuario.EMPLEADO_RUT = RutEmpleado;
                    usuario.CLIENTE_R_P = RutPasaporteCliente;
                    usuario.PROVEEDOR_RUT = RutProveedor;
                    CommonBC.Modelo.USUARIOS.Add(usuario);
                    CommonBC.Modelo.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                CommonBC.Modelo.USUARIOS.Remove(usuario);
                return false;
            }

        }

        private bool GenerarNombreUs(string tipo)
        {
            string nombre = string.Empty;
            bool genera = false;
            if (tipo == "c")
            {
                Cliente c = new Cliente();
                c.RutPasaporte = RutPasaporteCliente;
                c.Read();

                nombre = string.Format("{0}.{1}{2}", c.Nombre.Substring(0, 1), c.ApellidoPaterno, c.ApellidoMaterno.Substring(0, 1)).ToLower();


            }

            if (tipo == "e")
            {
                Empleado e = new Empleado();
                e.Rut = RutEmpleado;
                e.Read();
                nombre = string.Format("{0}.{1}{2}", e.Nombre.Substring(0, 1), e.ApellidoPaterno, e.ApellidoMaterno.Substring(0, 1)).ToLower();

            }

            if (tipo == "p")
            {
                Proveedor p = new Proveedor();
                p.Rut = RutProveedor;
                p.Leer();
                nombre = string.Format("{0}.{1}", p.Nombre.Substring(0, 1), p.Rubro).ToLower();

            }
            string nombre1 = nombre;
            while (genera == false)
            {
                try
                {

                    Dalc.USUARIOS usuario = CommonBC.Modelo.USUARIOS.Single(u => u.NOMBRE == nombre);
                    genera = false;
                    NumeroSecuencial++;
                    nombre = string.Format(nombre1 + "" + NumeroSecuencial.ToString().PadLeft(2, '0'));
                }
                catch (Exception)
                {

                    genera = true;
                }
            }

            if (genera)
            {
                Nombre = nombre;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                Dalc.USUARIOS usuario = CommonBC.Modelo.USUARIOS.First(b => b.NOMBRE == Nombre);
                usuario.PERFIL = Perfil;
                usuario.CONTRASENA = Contrasena;
                usuario.LOGIN = LogIn;

                CommonBC.Modelo.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool LeerUsuarioPorClienteRut()
        {
            try
            {
                Dalc.USUARIOS usuario = CommonBC.Modelo.USUARIOS.Single(u => u.CLIENTE_R_P == RutPasaporteCliente);
                Nombre = usuario.NOMBRE;
                Contrasena = usuario.CONTRASENA;
                Perfil = usuario.PERFIL;
                RutPasaporteCliente = usuario.CLIENTE_R_P;
                RutEmpleado = usuario.EMPLEADO_RUT;
                RutProveedor = usuario.PROVEEDOR_RUT;

                if (RutPasaporteCliente != "")
                {
                    Cliente cl = new Cliente();
                    cl.RutPasaporte = RutPasaporteCliente;
                    cl.Read();
                    cliente = cl;

                }

                if (RutProveedor != "")
                {
                    Proveedor p = new Proveedor();
                    p.Rut = RutProveedor;
                    p.Leer();
                    proveedor = p;
                }

                if (RutEmpleado != "")
                {
                    Empleado e = new Empleado();
                    e.Rut = RutEmpleado;
                    e.Read();
                    empleado = e;

                }

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
                Dalc.USUARIOS u = new Dalc.USUARIOS();
                if (RutPasaporteCliente != "")
                {
                    u = CommonBC.Modelo.USUARIOS.First(us => us.CLIENTE_R_P == RutPasaporteCliente);
                }

                if (RutEmpleado != "")
                {
                    u = CommonBC.Modelo.USUARIOS.First(us => us.EMPLEADO_RUT == RutEmpleado);
                }

                if (RutProveedor != "")
                {
                    u = CommonBC.Modelo.USUARIOS.First(us => us.PROVEEDOR_RUT == RutProveedor);
                }
                CommonBC.Modelo.USUARIOS.Remove(u);
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

