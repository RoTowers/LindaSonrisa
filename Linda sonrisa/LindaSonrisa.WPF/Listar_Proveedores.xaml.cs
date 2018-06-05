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
using System.Windows.Shapes;

namespace LindaSonrisa.WPF
{
    /// <summary>
    /// Lógica de interacción para Listar_Proveedores.xaml
    /// </summary>
    public partial class Listar_Proveedores : MetroWindow
    {


        private LSservicio.ServicioLSClient _servicio;

        public Listar_Proveedores()
        {
            InitializeComponent();
            InicializarWCF();
            CargarDatos();
            cargarcboTipoFiltro();
        }

        private void cargarcboTipoFiltro()
        {
            List<string> filtro = new List<string>();
            filtro.Add("Seleccione");
            filtro.Add("Provincia");
            filtro.Add("Rubro");
            cboTipoFiltro.ItemsSource = filtro;
            cboTipoFiltro.SelectedIndex = 0;
            cboFiltro.IsEnabled = false;
        }

        private void CargarDatos()
        {
            string xml = _servicio.TraerProvall();
            List<Proveedor> p = Util.Deserializar<List<Proveedor>>(xml);
            dgProveedores.ItemsSource = p;
        }

        private void InicializarWCF()
        {
            _servicio = new LSservicio.ServicioLSClient();

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cboTipoFiltro.Text.Equals(""))
                {
                    MessageBox.Show("Rellene el campo con el rut a filtrar");
                }
                else
                {
                    /*  string rut = txtFiltro.Text;
                      Cliente cliente = new Cliente(_servicio.LeerClientePorRut(rut));
                      if (cliente.RutPasaporte == rut)
                      {
                          lista.Add(cliente);
                          dgLista.Items.Refresh();

                      }
                      else
                      {
                          MessageBox.Show("Rut no encontrado");

                      }
                      */
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Rut no encontrado");
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

        private void dgLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        

        private void Modificar(object sender, RoutedEventArgs e)
        {
            int val = dgProveedores.SelectedIndex;
            Proveedor p = (Proveedor)dgProveedores.Items[val];
            string id = p.Rut;
            Registro_Proveedores reg = new Registro_Proveedores(id);
            reg.Show();
            this.Close();
        }

        private async void Eliminar(object sender, RoutedEventArgs e)
        {
            int val = dgProveedores.SelectedIndex;
            Proveedor p = (Proveedor)dgProveedores.Items[val];
            string xml = p.Serializar();
            Usuario u = new Usuario();
            u.RutProveedor = p.Rut;
            string xml2 = u.Serializar();
            if (_servicio.EliminarUsuarioPorRut(xml2))
            {
                await this.ShowMessageAsync("Información", "Usuario Eliminado con Éxito");
                if (_servicio.EliminarProv(xml))
                {
                    await this.ShowMessageAsync("Información", "Proveedor Eliminado con Éxito");
                }
                else
                {
                    await this.ShowMessageAsync("Información", "Proveedor NO fue eliminado");
                }
            }else
            {
                await this.ShowMessageAsync("Información", "Usuario NO fue Eliminado");
            }
            
            CargarDatos();
        }

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            string filtro = cboTipoFiltro.SelectedItem.ToString();
            switch (filtro)
            {
                case "Provincia":
                    FiltrarPorProvincias();
                    break;
                case "Rubro":
                    FiltrarPorRubro();
                    break;
            }
        }

        private void FiltrarPorProvincias()
        {
            string provincia = cboFiltro.SelectedValue.ToString();

            string xml = _servicio.FiltrarProvedorPorProvincia(provincia);
            List<Proveedor> p = Util.Deserializar<List<Proveedor>>(xml);
            dgProveedores.ItemsSource = p;
        }

        private void FiltrarPorRubro()
        {
            string filtro = cboFiltro.SelectedItem.ToString();


            string xml = _servicio.FiltrarProvedorPorRubro(filtro);
            List<Proveedor> p = Util.Deserializar<List<Proveedor>>(xml);
            dgProveedores.ItemsSource = p;

        }

        private void cboTipoFiltro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboTipoFiltro.SelectedIndex != 0)
            {
                switch (cboTipoFiltro.SelectedIndex)
                {
                    case 1:
                        CargarProvincias();
                        break;

                    case 2:
                        CargarRubros();
                        break;
                }
                labelBuscarPor.Content = cboTipoFiltro.SelectedValue;
                cboFiltro.IsEnabled = true;
            }
            else
            {
                labelBuscarPor.Content = "Filtro";
                cboFiltro.IsEnabled = false;
            }
        }

        private void CargarRubros()
        {
            string xml = _servicio.TraerRubros();
            List<string> c = Util.Deserializar<List<string>>(xml);
            cboFiltro.ItemsSource = c;
            //cboFiltro.DisplayMemberPath = "NombreProvincia";
            cboFiltro.SelectedIndex = 0;
        }

        private void CargarProvincias()
        {
            string xml = _servicio.LeerTodasProvincias();
            List<Provincia> c = Util.Deserializar<List<Provincia>>(xml);
            cboFiltro.ItemsSource = c;
            cboFiltro.SelectedValuePath = "Id";
            // cboFiltro.DisplayMemberPath = "NombreProvincia";
            cboFiltro.SelectedIndex = 0;
        }

        private void btn_ver_todos_Click(object sender, RoutedEventArgs e)
        {
            CargarDatos();
        }
    }
}
