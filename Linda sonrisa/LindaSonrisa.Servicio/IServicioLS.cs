using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LindaSonrisa.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioLS
    {
        #region Usuarios
        [OperationContract]
        bool Validar(string xml);

        [OperationContract]
        string Leer(string xml);

        [OperationContract]
        bool ModificarUsuario(string xml);

        [OperationContract]
        string LeerUsuarioPorClienteRut(string xml);

        [OperationContract]
        bool CrearUsuario(string xml);

        [OperationContract]
        string LeerPorRut(string xml);

        [OperationContract]
        bool EliminarUsuarioPorRut(string xml);
        #endregion

        #region Producto
        [OperationContract]
        string LeerProductoPorNombre(string xml);

        [OperationContract]
        bool CrearProducto(string xml, string idFP);

        [OperationContract]
        string readAllProductos();

        [OperationContract]
        string readAllProductosByTipo(string val);

        [OperationContract]
        string LeerProducto(string xml);

        [OperationContract]
        bool EliminarProducto(string xml);

        [OperationContract]
        bool ActualizarProducto(string xml);

        #endregion

        #region TipoProducto
        [OperationContract]
        string readAllTipoProductoByFP(string val);

        [OperationContract]
        string readAllTipoProducto();

        [OperationContract]
        string LeerTipoProducto(string xml);

        [OperationContract]
        string LeerTipoProductoPorID(string id);
        #endregion

        #region Familia Producto
        [OperationContract]
        string readAllFamiliaProducto();

        [OperationContract]
        string readFamiliaProducto(string id);
        #endregion

        #region Empleados
        [OperationContract]
        bool ActualizarEmpleado(string xmlEmpleado);

        [OperationContract]
        bool CrearEmpleado(string xmlEmpleado);

        [OperationContract]
        bool EliminarEmpleado(string xmlEmpleado);

        [OperationContract]
        string LeerEmpleado(string xmlEmpleado);

        [OperationContract]
        string LeerTodosEmpleados();

        [OperationContract]
        string LeerTodosEmpleadosByNombre(string nombre);

        [OperationContract]
        string LeerTodosEmpleadosByApellidoP(string apellidoP);

        [OperationContract]
        string LeerTodosEmpleadosByApellidoM(string apellidoM);

        [OperationContract]
        string LeerTodosEmpleadosByDireccion(string direccion);

        [OperationContract]
        string LeerTodosEmpleadosByCargo(string cargo);

        [OperationContract]
        string LeerTodosEmpleadosByComuna(string comuna);
        #endregion

        #region Comunas
        //Metodo que retorna todas las comunas
        [OperationContract]
        string LeerTodasComunas();

        //Metodo que retorna las comunas de una ciudad
        [OperationContract]
        string LeerTodasComunasById(string id);

        [OperationContract]
        string LeerComuna(string xml);

        [OperationContract]
        string CantidadComunas();
        #endregion

        #region Provincia
        //Metodo que retorna las ciudades
        [OperationContract]
        string LeerTodasProvincias();

        [OperationContract]
        string LeerProvincia(string xml);
        #endregion

        #region Cargos
        //Metodo que retorna los cargos
        [OperationContract]
        string LeerTodosCargos();

        [OperationContract]
        string LeerCargo(string xmlcargo);
        #endregion

        #region Clientes
        [OperationContract]
        bool CrearClientes(string xml);

        [OperationContract]
        string LeerCliente(string xml);

        [OperationContract]
        bool BorrarCliente(string xml);

        [OperationContract]
        bool ActualizarCliente(string xml);

        [OperationContract]
        string LeerTodosLosClientes();

        [OperationContract]
        string LeerTodosLosClientesPorRutPasaporte(string val);
        #endregion

        #region Servicio
        [OperationContract]
        bool CreateServicio(string xml);

        [OperationContract]
        string LeerServicio(string xml);

        [OperationContract]
        string LeerTodosLosServicios();

        [OperationContract]
        string LeerServicioPorNombre(string val);


        [OperationContract]
        bool BorrarServicio(string xml);

        [OperationContract]
        bool ActualizarServicio(string xml);
        #endregion

        #region ServicioProducto
        [OperationContract]
        bool CreateServicioProducto(string xml);

        [OperationContract]
        string LeerTodosLosServiciosProducto();

        [OperationContract]
        string LeerServicioProductoPorIdServicio(decimal val);


        [OperationContract]
        bool BorrarServicioProducto(string xml);
        #endregion

        #region Proveedor
        [OperationContract]
        string TraerProveedor(string xml);

        [OperationContract]
        bool CrearProv(string xml);

        [OperationContract]
        bool ActualizarProv(string xml);

        [OperationContract]
        bool EliminarProv(string xml);

        [OperationContract]
        string TraerProvall();

        [OperationContract]
        string TraerRubros();

        [OperationContract]
        string FiltrarProvedorPorRubro(string rubro);

        [OperationContract]
        string FiltrarProvedorPorProvincia(string provincia);
        #endregion

        #region Odontologo
        [OperationContract]
        bool CrearOdontologo(string xml);

        [OperationContract]
        bool EliminarOdonPorRut(string xml);
        #endregion

        #region Estadisticas
        [OperationContract]
        string ComunasConMasClientes();
        #endregion
    }
}

