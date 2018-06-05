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
using System.Windows.Shapes;
using LindaSonrisa.Negocio;

namespace LindaSonrisa.WPF
{
    /// <summary>
    /// Lógica de interacción para Listar_Productos.xaml
    /// </summary>
    public partial class Listar_Productos : MetroWindow
    {
        private LSservicio.ServicioLSClient _servicio;

        public Listar_Productos()
        {
            InitializeComponent();
            Init();
        }

        public void Limpiar()
        {
            lblFamiliaProductoMsg.Visibility = Visibility.Hidden;
            lblFamiliaProductoMsg.ToolTip = string.Format("");

            lblTipoProductoMsg.Visibility = Visibility.Hidden;
            lblTipoProductoMsg.ToolTip = string.Format("");
        }

        public async Task<bool> Validar()
        {
            Limpiar();
            bool valido = true;
            //Validacion Familia de Producto
            if (cboFamiliaProducto.SelectedIndex == -1)
            {
                lblFamiliaProductoMsg.Visibility = Visibility.Visible;
                lblFamiliaProductoMsg.ToolTip = string.Format("Debe seleccionar una Familia de Producto");
                valido = false;
            }
            if (cboTipoProducto.SelectedIndex == -1)
            {
                lblTipoProductoMsg.Visibility = Visibility;
                lblTipoProductoMsg.ToolTip = string.Format("Debe seleccionar una Familia de Producto");
                valido = false;
            }

            return valido;
        }

        private void Init()
        {
            _servicio = new LSservicio.ServicioLSClient();
            CargarFamiliaProducto();
            //CargarTiposProductos();
            CargarProductos();
        }

        private void CargarProductos()
        {
            List<Producto> productos = new List<Producto>();
            string xml = _servicio.readAllProductos();
            productos = Util.Deserializar<List<Producto>>(xml);
            dgProductos.ItemsSource = productos;
        }

        public void CargarFamiliaProducto()
        {
            FamiliaProductoCollection fpc = new FamiliaProductoCollection();
            string xml = _servicio.readAllFamiliaProducto();
            List<FamiliaProducto> lfp = Util.Deserializar<List<FamiliaProducto>>(xml);
            //cboFamiliaProducto.IsEditable = true;
            //cboFamiliaProducto.IsTextSearchEnabled = true;
            //cboFamiliaProducto.IsDropDownOpen = true;
            //cboFamiliaProducto.StaysOpenOnEdit = true;
            //cboFamiliaProducto.focus
            cboFamiliaProducto.ItemsSource = lfp;
            cboFamiliaProducto.SelectedValuePath = "Id";

        }

        private void CargarProductosByTipo(int val)
        {
            List<Producto> productos = new List<Producto>();
            string xml = _servicio.readAllProductosByTipo(val.ToString());
            productos = Util.Deserializar<List<Producto>>(xml);
            dgProductos.ItemsSource = productos;
        }


        private void HamburgerMenuControl_OnItemClick(object sender, ItemClickEventArgs e)
        {
            //// set the content
            //this.HamburgerMenuControl.Content = e.ClickedItem;
            ////switch (int.Parse(e.ClickedItem.ToString()))
            ////{
            ////    case 1:
            ////        MainWindow m = new MainWindow();
            ////        m.Show();
            ////        this.Close();
            ////        break;
            ////    case 2:
            ////        MainWindow ventana_main = new MainWindow();
            ////        ventana_main.Show();
            ////        this.Close();
            ////        break;
            ////    default:
            ////        break;
            ////}

            //this.HamburgerMenuControl.IsPaneOpen = false;
        }

        private void Modificar(object sender, RoutedEventArgs e)
        {
            int val = dgProductos.SelectedIndex;
            Producto p = (Producto)dgProductos.Items[val];
            string id = p.Id;
            Registro_Producto reg = new Registro_Producto(id);
            reg.Show();
            this.Close();
        }

        private async void Eliminar(object sender, RoutedEventArgs e)
        {
            int val = dgProductos.SelectedIndex;
            Producto p = (Producto)dgProductos.Items[val];
            string xml = p.Serializar();
            if (_servicio.EliminarProducto(xml))
            {
                await this.ShowMessageAsync("Información", "Producto Eliminado con Éxito");
            }else
            {
                await this.ShowMessageAsync("Información", "Producto NO fue eliminado");
            }
            CargarProductos();
        }

        private async void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            if (await Validar())
            {
                if (cboTipoProducto.SelectedValue != null)
                {
                    int val = int.Parse(cboTipoProducto.SelectedValue.ToString());
                    CargarProductosByTipo(val);
                }
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

        private void cboFamiliaProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int val = int.Parse(cboFamiliaProducto.SelectedValue.ToString());
            TipoProductoCollection fpc = new TipoProductoCollection();
            string xml = _servicio.readAllTipoProductoByFP(val.ToString());
            List<TipoProducto> lfp = Util.Deserializar<List<TipoProducto>>(xml);
            cboTipoProducto.ItemsSource = lfp;
            cboTipoProducto.SelectedValuePath = "Id";
        }
    }
}
