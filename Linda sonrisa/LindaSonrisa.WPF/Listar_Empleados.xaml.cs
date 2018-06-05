using LindaSonrisa.Negocio;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LindaSonrisa.WPF
{
    /// <summary>
    /// Lógica de interacción para Listar_Empleados.xaml
    /// </summary>
    /// 
    public partial class Listar_Empleados : MetroWindow
    {


        public LSservicio.ServicioLSClient servicio;

        public Listar_Empleados()
        {
            InitializeComponent();
            Init();
        }


        private void Init()
        {
            servicio = new LSservicio.ServicioLSClient();
            CargarFiltros();
            CargarEmpleados();
        }

        private void CargarFiltros()
        {
            cbo_Filtro.Items.Add("Rut");
            cbo_Filtro.Items.Add("Nombre");
            cbo_Filtro.Items.Add("Apellido Padre");
            cbo_Filtro.Items.Add("Apellido Madre");
            cbo_Filtro.Items.Add("Direccion");
            cbo_Filtro.Items.Add("Cargo");
            cbo_Filtro.Items.Add("Comuna");
        }

        private void CargarEmpleados()
        {
            List<Empleado> empleado = new List<Empleado>();
            string xml = servicio.LeerTodosEmpleados();
            empleado = Util.Deserializar<List<Empleado>>(xml);
            grd_Empleados.ItemsSource = empleado;
        }

        private void CargarEmpleadosByNombre(string nombre)
        {
            List<Empleado> empleado = new List<Empleado>();
            string xml = servicio.LeerTodosEmpleadosByNombre(nombre);
            empleado = Util.Deserializar<List<Empleado>>(xml);
            grd_Empleados.ItemsSource = empleado;
        }

        private void CargarEmpleadosByApellidoP(string apellidoP)
        {
            List<Empleado> empleado = new List<Empleado>();
            string xml = servicio.LeerTodosEmpleadosByApellidoP(apellidoP);
            empleado = Util.Deserializar<List<Empleado>>(xml);
            grd_Empleados.ItemsSource = empleado;
        }

        private void CargarEmpleadosByApellidoM(string apellidoM)
        {
            List<Empleado> empleado = new List<Empleado>();
            string xml = servicio.LeerTodosEmpleadosByApellidoM(apellidoM);
            empleado = Util.Deserializar<List<Empleado>>(xml);
            grd_Empleados.ItemsSource = empleado;
        }

        private void CargarEmpleadosByDireccion(string direccion)
        {
            List<Empleado> empleado = new List<Empleado>();
            string xml = servicio.LeerTodosEmpleadosByDireccion(direccion);
            empleado = Util.Deserializar<List<Empleado>>(xml);
            grd_Empleados.ItemsSource = empleado;
        }

        private void CargarEmpleadosByCargo(string cargo)
        {
            List<Empleado> empleado = new List<Empleado>();
            string xml = servicio.LeerTodosEmpleadosByCargo(cargo);
            empleado = Util.Deserializar<List<Empleado>>(xml);
            grd_Empleados.ItemsSource = empleado;
        }

        private void CargarEmpleadosByComuna(string comuna)
        {
            List<Empleado> empleado = new List<Empleado>();
            string xml = servicio.LeerTodosEmpleadosByComuna(comuna);
            empleado = Util.Deserializar<List<Empleado>>(xml);
            grd_Empleados.ItemsSource = empleado;
        }

        private void Modificar(object sender, RoutedEventArgs e)
        {
            int val = grd_Empleados.SelectedIndex;
            Empleado p = (Empleado)grd_Empleados.Items[val];
            string rut = p.Rut;
            Registro_Empleado reg = new Registro_Empleado(rut);
            reg.Show();
            this.Close();
        }

        private async void Eliminar(object sender, RoutedEventArgs e)
        {
            int val = grd_Empleados.SelectedIndex;
            Empleado p = (Empleado)grd_Empleados.Items[val];
            string xml = p.Serializar();
            Usuario u = new Usuario();
            u.RutEmpleado = p.Rut;
            string xml2 = u.Serializar();
            if (servicio.EliminarUsuarioPorRut(xml2))
            {
                await this.ShowMessageAsync("Información", "Usuario Eliminado con Éxito");
                if (p.IdCargo.ToString() == "1")
                {
                    Odontologo o = new Odontologo();
                    o.RutEmpleado = p.Rut;
                    string xml3 = o.Serializar();
                    if (servicio.EliminarOdonPorRut(xml3))
                    {
                        await this.ShowMessageAsync("Información", "Odontologo eliminado exitosamente");
                    }
                    else
                    {
                        await this.ShowMessageAsync("Información", "Odontologo NO eliminado");
                    }
                }
                if (servicio.EliminarEmpleado(xml))
                {
                    await this.ShowMessageAsync("Información", "Empleado eliminado con exito");
                }
                else
                {
                    await this.ShowMessageAsync("Información", "Empleado NO eliminado");
                }
            }else
            {
                await this.ShowMessageAsync("Información", "Usuario NO Eliminado");
            }
            CargarEmpleados();
        }

        private async void btn_salir_Click(object sender, RoutedEventArgs e)
        {
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Si",
                NegativeButtonText = "No"
            };

            var result = await this.ShowMessageAsync("Confirmación", "¿Estas Seguro De salir De la aplicación?",
            MahApps.Metro.Controls.Dialogs.MessageDialogStyle.AffirmativeAndNegative, mySettings);

            if (result == MessageDialogResult.Affirmative)
            {
                MainWindow ventana_main = new MainWindow();
                ventana_main.Show();
                this.Close();
            }

        }

        private void _RegistroProductos_Click(object sender, RoutedEventArgs e)
        {
            Registro_Producto rp = new Registro_Producto();
            rp.Show();
            this.Close();
        }

        private void _ListarProductos_Click(object sender, RoutedEventArgs e)
        {
            Listar_Productos lp = new Listar_Productos();
            lp.Show();
            this.Close();
        }

        private void _RegistroClientes_Click(object sender, RoutedEventArgs e)
        {
            Registro_Cliente rc = new Registro_Cliente();
            rc.Show();
            this.Close();
        }

        private void _ListarClientes_Click(object sender, RoutedEventArgs e)
        {
            ListarClientes lc = new ListarClientes();
            lc.Show();
            this.Close();
        }

        private void _RegistroProveedores_Click(object sender, RoutedEventArgs e)
        {
            Registro_Proveedores rps = new Registro_Proveedores();
            rps.Show();
            this.Close();
        }

        private void _ListarProveedores_Click(object sender, RoutedEventArgs e)
        {
            Listar_Proveedores lps = new Listar_Proveedores();
            lps.Show();
            this.Close();
        }

        private void _RegistroServicios_Click(object sender, RoutedEventArgs e)
        {
            RegistroServicio rs = new RegistroServicio();
            rs.Show();
            this.Close();
        }

        private void _ListarServicios_Click(object sender, RoutedEventArgs e)
        {
            ListarServicios ls = new ListarServicios();
            ls.Show();
            this.Close();
        }

        private void _RegistroEmpleados_Click(object sender, RoutedEventArgs e)
        {
            Registro_Empleado re = new Registro_Empleado();
            re.Show();
            this.Close();
        }

        private void _ListarEmpleados_Click(object sender, RoutedEventArgs e)
        {
            Listar_Empleados le = new Listar_Empleados();
            le.Show();
            this.Close();
        }

        private void _Estadisticas_Click(object sender, RoutedEventArgs e)
        {
            Estadisticas es = new Estadisticas();
            es.Show();
            this.Close();
        }

        private async void btn_Buscar_Click(object sender, RoutedEventArgs e)
        {
            if (cbo_Filtro.SelectedValue != null)
            {
                if (cbo_Filtro.SelectedIndex == 1)
                {
                    string val = txt_Filtro.Text.ToString();
                    CargarEmpleadosByNombre(val);
                }
                if (cbo_Filtro.SelectedIndex == 2)
                {
                    string val = txt_Filtro.Text.ToString();
                    CargarEmpleadosByApellidoP(val);
                }
                if (cbo_Filtro.SelectedIndex == 3)
                {
                    string val = txt_Filtro.Text.ToString();
                    CargarEmpleadosByApellidoM(val);
                }
                if (cbo_Filtro.SelectedIndex == 4)
                {
                    string val = txt_Filtro.Text.ToString();
                    CargarEmpleadosByDireccion(val);
                }
                if (cbo_Filtro.SelectedIndex == 5)
                {
                    string val = txt_Filtro.Text.ToString();
                    CargarEmpleadosByCargo(val);
                }
                if (cbo_Filtro.SelectedIndex == 6)
                {
                    string val = txt_Filtro.Text.ToString();
                    CargarEmpleadosByComuna(val);
                }
            }
            else
            {
                await this.ShowMessageAsync("Información", "No se ha seleccionado un valor para filtrar");
            }
        }
    }
}
