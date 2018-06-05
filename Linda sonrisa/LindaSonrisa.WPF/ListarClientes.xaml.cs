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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using LindaSonrisa.Negocio;


namespace LindaSonrisa.WPF
{
    /// <summary>
    /// Lógica de interacción para ListarClientes.xaml
    /// </summary>
    public partial class ListarClientes : MetroWindow
    {

        private LSservicio.ServicioLSClient _servicio;
        public ListarClientes()
        {
            InitializeComponent();
            Init();


        }

        private void Init()
        {
            _servicio = new LSservicio.ServicioLSClient();

            CargarClientes();
        }

        private void CargarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            string xml = _servicio.LeerTodosLosClientes();
            clientes = Util.Deserializar<List<Cliente>>(xml);
            dgLista.ItemsSource = clientes;
        }

        private void CargarClientesPorRutPasaporte(string val)
        {
            List<Cliente> clientes = new List<Cliente>();
            string xml = _servicio.LeerTodosLosClientesPorRutPasaporte(val);
            clientes = Util.Deserializar<List<Cliente>>(xml);
            dgLista.ItemsSource = clientes;
        }

        private void Modificar(object sender, RoutedEventArgs e)
        {
            int val = dgLista.SelectedIndex;
            Cliente p = (Cliente)dgLista.Items[val];
            string id = p.RutPasaporte;
            Registro_Cliente registroCliente = new Registro_Cliente(id);
            registroCliente.Show();
            this.Close();
        }

        private async void Eliminar(object sender, RoutedEventArgs e)
        {
            int val = dgLista.SelectedIndex;
            Cliente p = (Cliente)dgLista.Items[val];
            string xml = p.Serializar();
            Usuario u = new Usuario();
            u.RutPasaporteCliente = p.RutPasaporte;
            string xml2 = u.Serializar();
            if (_servicio.EliminarUsuarioPorRut(xml2))
            {
                await this.ShowMessageAsync("Información", "Usuario Eliminado con Éxito");

                if (_servicio.BorrarCliente(xml))
                {
                    await this.ShowMessageAsync("Información", "Cliente Eliminado con Éxito");
                }
                else
                {
                    await this.ShowMessageAsync("Información", "Cliente NO fue eliminado");
                }
            }else
            {
                await this.ShowMessageAsync("Información", "Usuario NO Eliminado");
            }
            CargarClientes();
        }

        public async Task<bool> Validar()
        {
            Limpiar();
            bool valido = true;
            string filtro = txtFiltro.Text.Trim();



            //Validacion Filtro

            if (filtro.Length.Equals(0))
            {
                lblRutMsg.Visibility = Visibility;
                lblRutMsg.ToolTip = string.Format("El rut no puede estar vacío");
                valido = false;
            }




            return valido;
        }

        public void Limpiar()
        {
            lblRutMsg.Visibility = Visibility.Hidden;
            lblRutMsg.ToolTip = string.Format("");







        }

        private async void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (await Validar())
            {

                string rut = txtFiltro.Text;
                CargarClientesPorRutPasaporte(rut);


            }
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
    }
}

