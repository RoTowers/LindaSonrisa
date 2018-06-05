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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using LindaSonrisa.Negocio;
namespace LindaSonrisa.WPF
{
    /// <summary>
    /// Lógica de interacción para ListarServicios.xaml
    /// </summary>
    public partial class ListarServicios : MetroWindow
    {

        private LSservicio.ServicioLSClient _servicio;
        public ListarServicios()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            _servicio = new LSservicio.ServicioLSClient();

            CargarServicios();
        }

        private void CargarServicios()
        {
            List<Negocio.Servicio> serv = new List<Negocio.Servicio>();
            string xml = _servicio.LeerTodosLosServicios();

            serv = Util.Deserializar<List<Negocio.Servicio>>(xml);
            dgLista.ItemsSource = serv;
        }

        private void CargarServicioPorNombre(string val)
        {
            List<Servicio> serv = new List<Servicio>();
            string xml = _servicio.LeerServicioPorNombre(val);
            serv = Util.Deserializar<List<Servicio>>(xml);
            dgLista.ItemsSource = serv;
        }

        private void Modificar(object sender, RoutedEventArgs e)
        {

            int val = dgLista.SelectedIndex;
            Servicio p = (Servicio)dgLista.Items[val];
            decimal id = p.Id;
            RegistroServicio registroServicio = new RegistroServicio(id);
            registroServicio.txtNombreServicio.Text = p.Nombre;
            registroServicio.Show();
            this.Close();

        }

        private async void Eliminar(object sender, RoutedEventArgs e)
        {
            int val = dgLista.SelectedIndex;
            List<Servicio_Producto> list = new List<Servicio_Producto>();


            Servicio p = (Servicio)dgLista.Items[val];
            string xml = p.Serializar();


            string s = _servicio.LeerServicioProductoPorIdServicio(p.Id);
            list = Util.Deserializar<List<Servicio_Producto>>(s);

            foreach (var item in list)
            {
                Servicio_Producto sp = new Servicio_Producto();
                sp.Id = item.Id;
                string sps = sp.Serializar();
                _servicio.BorrarServicioProducto(sps);
            }
            if (_servicio.BorrarServicio(xml))
            {
                await this.ShowMessageAsync("Información", "Servicio Eliminado con Éxito");
            }
            else
            {
                await this.ShowMessageAsync("Información", "Servicio NO fue eliminado");
            }
            CargarServicios();
        }

        public bool Validar()
        {
            Limpiar();
            bool valido = true;
            string filtro = txtFiltro.Text.Trim();



            //Validacion Filtro

            if (filtro.Length.Equals(0))
            {
                lblNombreMsg.Visibility = Visibility;
                lblNombreMsg.ToolTip = string.Format("El nombre no puede estar vacío");
                valido = false;
            }




            return valido;
        }

        public void Limpiar()
        {
            lblNombreMsg.Visibility = Visibility.Hidden;
            lblNombreMsg.ToolTip = string.Format("");







        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {

            if (Validar())
            {

                string nombre = txtFiltro.Text;
                CargarServicioPorNombre(nombre);


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