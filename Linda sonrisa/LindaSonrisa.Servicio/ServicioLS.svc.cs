/// <history> 
///     [Alexis Moya] 27/04/2018 Modificado
///     [Franco Retamal] 01/05/2018 Modificado
///     [Rodrigo Torres] 02/05/2018 Modificado
/// </history>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using LindaSonrisa.Negocio;

namespace LindaSonrisa.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioLS" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioLS.svc o ServicioLS.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioLS : IServicioLS
    {
        //Metodo que lee y serializa el parametro xml

        #region Usuarios
        //Usuarios
        public string Leer(string xml)
        {
            Usuario u = new Usuario(xml);
            if (u.Read())
            {
                return u.Serializar();
            }
            else
            {
                return null;
            }
        }

        public string LeerPorRut(string xml)
        {
            Usuario u = new Usuario(xml);
            if (u.ReadByRut())
            {
                return u.Serializar();
            }
            else
            {
                return null;
            }
        }

        public bool Validar(string xml)
        {
            Usuario u = new Usuario(xml);
            return u.Valida();
        }


        public bool ModificarUsuario(string xml)
        {
            Usuario u = new Usuario(xml);
            return u.Update();
        }

        public string LeerUsuarioPorClienteRut(string xml)
        {

            Usuario u = new Usuario(xml);
            if (u.LeerUsuarioPorClienteRut())
            {
                return u.Serializar();
            }
            else
            {

                return u.Serializar();
            }
        }

        public bool CrearUsuario(string xml)
        {
            Usuario u = new Usuario(xml);
            if (u.Create())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EliminarUsuarioPorRut(string xml)
        {
            Usuario u = new Usuario(xml);
            if (u.DeleteByRut())
            {
                return true;
            }else
            {
                return false;
            }
        }
        #endregion

        #region Productos
        //Productos
        public string LeerProductoPorNombre(string xml)
        {
            Producto pro = new Producto(xml);
            pro.LeerProductoPorNombre();
            return pro.Serializar();
        }

        public bool CrearProducto(string xml, string idFP)
        {
            Producto p = new Producto(xml);
            return p.Create(int.Parse(idFP));
        }

        public string readAllProductos()
        {
            ProductosCollection p = new ProductosCollection();
            string xml = Util.Serializar<List<Producto>>(p.getAll());
            return xml;
        }

        public string readAllProductosByTipo(string val)
        {
            ProductosCollection pc = new ProductosCollection();
            List<Producto> lpc = pc.getAllByTipo(int.Parse(val));
            string xml = Util.Serializar<List<Producto>>(lpc);
            return xml;
        }

        public string LeerProducto(string xml)
        {
            Producto p = new Producto(xml);
            if (p.Read())
            {
                return p.Serializar();
            }
            else
            {
                return null;
            }
        }

        public bool ActualizarProducto(string xml)
        {
            Producto p = new Producto(xml);
            return p.Update();
        }

        public bool EliminarProducto(string xml)
        {
            Producto p = new Producto(xml);
            return p.Delete();
        }

        #endregion

        #region TipoProducto
        //TipoProducto
        public string readAllTipoProductoByFP(string val)
        {
            TipoProductoCollection tpc = new TipoProductoCollection();
            List<TipoProducto> ltpc = tpc.readAllBy(int.Parse(val));
            string xml = Util.Serializar<List<TipoProducto>>(ltpc);
            return xml;
        }

        public string readAllTipoProducto()
        {
            TipoProductoCollection tpc = new TipoProductoCollection();
            List<TipoProducto> ltpc = tpc.readAll();
            string xml = Util.Serializar<List<TipoProducto>>(ltpc);
            return xml;
        }

        public string LeerTipoProducto(string xml)
        {
            TipoProducto tp = new TipoProducto(xml);
            if (tp.Read())
            {
                return tp.Serializar();
            }
            else
            {
                return null;
            }
        }

        public string LeerTipoProductoPorID(string id)
        {
            TipoProducto tipo = new TipoProducto();
            tipo.Id = int.Parse(id);
            tipo.Read();
            return tipo.Serializar();
        }
        #endregion

        #region FamiliaProducto
        //FamiliaProducto
        public string readAllFamiliaProducto()
        {
            FamiliaProductoCollection fpc = new FamiliaProductoCollection();
            List<FamiliaProducto> lfpc = fpc.readAll();
            string xml = Util.Serializar<List<FamiliaProducto>>(lfpc);
            return xml;
        }

        public string readFamiliaProducto(string id)
        {
            FamiliaProducto fp = new FamiliaProducto();
            fp.Id = int.Parse(id);
            fp.Read();
            return fp.Serializar();
        }
        #endregion

        #region Empleado
        //Victor Encargado de estos metodos
        public bool ActualizarEmpleado(string xmlEmpleado)
        {
            //Se deserializa primero
            Empleado empleado = new Empleado(xmlEmpleado);
            empleado = Util.Deserializar<Empleado>(xmlEmpleado);
            return empleado.Update();
        }

        //Metodo para crear Empleado
        public bool CrearEmpleado(string xmlEmpleado)
        {
            Empleado empleado = new Empleado(xmlEmpleado);
            return empleado.Create();
        }

        //Metodo para eliminar empleado
        public bool EliminarEmpleado(string xmlEmpleado)
        {
            Empleado empleado = new Empleado(xmlEmpleado);

            return empleado.Delete();
        }

        //Metodo que retorna los datos de 1 empleado
        public string LeerEmpleado(string xmlEmpleado)
        {
            Empleado empleado = new Empleado(xmlEmpleado);

            if (empleado.Read())
            {
                return empleado.Serializar();
            }
            else
            {
                return null;
            }
        }

        //Metodo que retorna todos los empleados
        public string LeerTodosEmpleados()
        {
            EmpleadoCollection lista = new EmpleadoCollection();
            return Util.Serializar<List<Empleado>>(lista.Read());
        }

        public string LeerTodosEmpleadosByNombre(string nombre)
        {
            EmpleadoCollection lista = new EmpleadoCollection();
            return Util.Serializar<List<Empleado>>(lista.ReadAllByNombre((nombre)));
        }

        public string LeerTodosEmpleadosByApellidoP(string apellidoP)
        {
            EmpleadoCollection lista = new EmpleadoCollection();
            return Util.Serializar<List<Empleado>>(lista.ReadAllByApellidoP((apellidoP)));
        }

        public string LeerTodosEmpleadosByApellidoM(string apellidoM)
        {
            EmpleadoCollection lista = new EmpleadoCollection();
            return Util.Serializar<List<Empleado>>(lista.ReadAllByApellidoM((apellidoM)));
        }

        public string LeerTodosEmpleadosByDireccion(string direccion)
        {
            EmpleadoCollection lista = new EmpleadoCollection();
            return Util.Serializar<List<Empleado>>(lista.ReadAllByDireccion((direccion)));
        }

        public string LeerTodosEmpleadosByCargo(string cargo)
        {
            EmpleadoCollection lista = new EmpleadoCollection();
            return Util.Serializar<List<Empleado>>(lista.ReadAllByCargo((int.Parse(cargo))));
        }

        public string LeerTodosEmpleadosByComuna(string comuna)
        {
            EmpleadoCollection lista = new EmpleadoCollection();
            return Util.Serializar<List<Empleado>>(lista.ReadAllByComuna((int.Parse(comuna))));
        }
        #endregion

        #region Comunas
        //Metodo que retorna todas las comunas
        public string LeerTodasComunas()
        {
            ComunasCollection lista = new ComunasCollection();
            return Util.Serializar<List<Comuna>>(lista.getComunas());
        }

        public string CantidadComunas()
        {
            ComunasCollection lista = new ComunasCollection();
            int a = lista.getComunas().Count;
            return a.ToString();
        }

        //Metodo que retorna las comunas de una ciudad
        public string LeerTodasComunasById(string id)
        {
            ComunasCollection lista = new ComunasCollection();
            return Util.Serializar<List<Comuna>>(lista.getComunasByCiudad(int.Parse(id)));
        }

        public string LeerComuna(string xml)
        {
            Comuna comuna = new Comuna(xml);
            if (comuna.Read())
            {
                return comuna.Serializar();
            }
            else
            {
                return null;

            }
        }
        #endregion

        #region Provincia
        //Metodo que retorna las Provincias
        public string LeerTodasProvincias()
        {
            ProvinciaCollection lista = new ProvinciaCollection();
            return Util.Serializar<List<Provincia>>(lista.ReadAll());
        }

        public string LeerProvincia(string xml)
        {
            Provincia prov = new Provincia(xml);
            prov.Read();
            return prov.Serializar();
        }
        #endregion

        #region Cargos
        //Metodo que retorna los cargos
        public string LeerTodosCargos()
        {
            CargosCollection lista = new CargosCollection();
            return Util.Serializar<List<Cargos>>(lista.getCargos());
        }

        public string LeerCargo(string xmlcargo)
        {
            Cargos cargo = new Cargos(xmlcargo);

            if (cargo.Read())
            {
                return cargo.Serializar();
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region Clientes
        public bool CrearClientes(string xml)
        {
            Cliente cliente = new Cliente(xml);
            return cliente.Create();
        }


        public string LeerCliente(string xml)
        {
            Cliente cliente = new Cliente(xml);
            cliente.Read();
            return cliente.Serializar();


        }

        public bool BorrarCliente(string xml)
        {
            Cliente cliente = new Cliente(xml);
            return cliente.Delete();

        }

        public bool ActualizarCliente(string xml)
        {
            Cliente cliente = new Cliente(xml);
            return cliente.Update();
        }

        public string LeerTodosLosClientes()
        {
            ClientesCollection p = new ClientesCollection();
            string xml = Util.Serializar<List<Cliente>>(p.getAll());
            return xml;
        }

        public string LeerTodosLosClientesPorRutPasaporte(string val)
        {
            ClientesCollection pc = new ClientesCollection();
            List<Cliente> lpc = pc.getAllByRutPasaporte(val);
            string xml = Util.Serializar<List<Cliente>>(lpc);
            return xml;
        }
        #endregion

        #region Servicio
        public bool CreateServicio(string xml)
        {
            Negocio.Servicio serv = new Negocio.Servicio(xml);
            return serv.Create();

        }

        public string LeerServicio(string xml)
        {
            Negocio.Servicio servicio = new Negocio.Servicio(xml);
            servicio.Read();
            return servicio.Serializar();
        }


        public string LeerTodosLosServicios()
        {
            ServiciosCollection sc = new ServiciosCollection();
            return Util.Serializar<List<Negocio.Servicio>>(sc.getAll());
        }

        public string LeerServicioPorNombre(string val)
        {
            ServiciosCollection sc = new ServiciosCollection();
            List<Negocio.Servicio> lpc = sc.getAllByNombre(val);
            string xml = Util.Serializar<List<Negocio.Servicio>>(lpc);
            return xml;
        }

        public bool BorrarServicio(string xml)
        {
            Negocio.Servicio serv = new Negocio.Servicio(xml);
            return serv.Delete();
        }

        public bool ActualizarServicio(string xml)
        {
            Negocio.Servicio serv = new Negocio.Servicio(xml);
            return serv.Update();
        }
        #endregion

        #region ServicioProducto
        public bool CreateServicioProducto(string xml)
        {
            Servicio_Producto servpro = new Servicio_Producto(xml);
            return servpro.Create();
        }


        public string LeerTodosLosServiciosProducto()
        {
            ServicioProductoCollection sc = new ServicioProductoCollection();
            return Util.Serializar<List<Negocio.Servicio_Producto>>(sc.getAll());
        }


        public string LeerServicioProductoPorIdServicio(decimal val)
        {
            ServicioProductoCollection sc = new ServicioProductoCollection();
            List<Negocio.Servicio_Producto> lpc = sc.getAllByIdServicio(val);
            string xml = Util.Serializar<List<Negocio.Servicio_Producto>>(lpc);
            return xml;
        }



        public bool BorrarServicioProducto(string xml)
        {
            Negocio.Servicio_Producto serv = new Negocio.Servicio_Producto(xml);
            return serv.Delete();
        }
        #endregion

        #region Proveedor
        public string TraerProveedor(string xml)
        {
            Proveedor p = new Proveedor(xml);
            if (p.Leer())
            {
                return p.Serializar();
            }
            else
            {
                return null;
            }

        }

        public bool CrearProv(string xml)
        {
            Proveedor p = new Proveedor(xml);
            if (p.Crear())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ActualizarProv(string xml)
        {
            Proveedor p = new Proveedor(xml);
            if (p.Actualizar())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EliminarProv(string xml)
        {
            Proveedor p = new Proveedor(xml);
            if (p.Eliminar())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string TraerProvall()
        {
            ProveedoresCollection p = new ProveedoresCollection();
            List<Proveedor> listap = new List<Proveedor>();
            listap = p.ObtenerProveedores();
            string xml = Util.Serializar<List<Proveedor>>(listap);

            return xml;
        }

        public string TraerRubros()
        {
            ProveedoresCollection p = new ProveedoresCollection();
            List<string> listap = new List<string>();
            listap = p.ObtenerRubros();
            string xml = Util.Serializar<List<string>>(listap);

            return xml;
        }

        public string FiltrarProvedorPorRubro(string rubro)
        {
            ProveedoresCollection pc = new ProveedoresCollection();
            List<Proveedor> listap = new List<Proveedor>();
            listap = pc.FiltrarPorRubros(rubro);
            string xml = Util.Serializar<List<Proveedor>>(listap);
            return xml;
        }

        public string FiltrarProvedorPorProvincia(string provincia)
        {
            ProveedoresCollection pc = new ProveedoresCollection();
            List<Proveedor> listap = new List<Proveedor>();
            listap = pc.FiltrarPorProvincia(provincia);
            string xml = Util.Serializar<List<Proveedor>>(listap);
            return xml;
        }

        #endregion

        #region Odontologo

        public bool CrearOdontologo(string xml)
        {
            Odontologo o = new Odontologo(xml);
            return o.Create();
        }

        public bool EliminarOdonPorRut(string xml)
        {
            Odontologo o = new Odontologo(xml);
            return o.DeleteByRut();
        }
        #endregion

        #region Estadisticas
        public string ComunasConMasClientes()
        {
            Reportes r = new Reportes();

            List<ReportesCSP> c = r.ComunasConMasClientes();

            return Util.Serializar<List<ReportesCSP>>(c);
        }
        #endregion
    }
}
