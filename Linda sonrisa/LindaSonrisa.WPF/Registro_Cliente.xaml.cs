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
    /// Lógica de interacción para Registro_Cliente.xaml
    /// </summary>
    public partial class Registro_Cliente : MetroWindow
    {

        private LSservicio.ServicioLSClient _servicio;
        public string rutPasaporte { get; set; }
        public Registro_Cliente()
        {
            //asdfg
            InitializeComponent();
            Init();
            CargarDatos();

        }

        public Registro_Cliente(string rut)
        {
            InitializeComponent();
            Init();
            rutPasaporte = rut;
            CargarDatos();

        }

        private void txtRutPasaporte_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if ((bool)rbRut.IsChecked)
            {
                if (!char.IsDigit(e.Text, e.Text.Length - 1))
                    e.Handled = true;
            }
        }
        private void Init()
        {
            _servicio = new LSservicio.ServicioLSClient();
            CargarProvincias();
        }

        public void CargarProvincias()
        {
            ProvinciaCollection fpc = new ProvinciaCollection();
            string xml = _servicio.LeerTodasProvincias();
            List<Provincia> lfp = Util.Deserializar<List<Provincia>>(xml);

            cbCiudad.ItemsSource = lfp;
            cbCiudad.SelectedValuePath = "Id";

        }



        private bool esRutValido(string RUT, string DV)
        {
            var rut = RUT;
            var longitud = rut.Length;
            var factor = 2;
            var sumaProducto = 0;
            var con = 0;
            var caracter = 0;
            for (con = longitud - 1; con >= 0; con--)
            {
                caracter = Int32.Parse(rut.Substring(con, 1));
                sumaProducto += (factor * caracter);
                factor++; if (factor > 7) factor = 2;
            }
            var digitoAuxiliar = 11 - (sumaProducto % 11);
            var caracteres = "-123456789K0";
            var digitoCaracter = caracteres.Substring(digitoAuxiliar, 1);
            return DV.ToUpper().Equals(digitoCaracter);

        }
        private void CargarDatos()
        {
            if (rutPasaporte != null)
            {
                txtRutPasaporte.IsReadOnly = true;
                DV.IsReadOnly = true;
                btnAgregar.Visibility = Visibility.Hidden;
                Cliente clien = new Cliente();
                clien.RutPasaporte = rutPasaporte;
                string xml = clien.Serializar();
                xml = _servicio.LeerCliente(xml);
                if (xml != null)
                {
                    clien = new Cliente(xml);
                    Comuna tp = new Comuna();
                    tp.Id = (int)clien.IdComuna;
                    xml = tp.Serializar();
                    xml = _servicio.LeerComuna(xml);
                    if (xml != null)
                    {
                        tp = new Comuna(xml);
                        Usuario usu = new Usuario();
                        usu.RutPasaporteCliente = clien.RutPasaporte;

                        string u = usu.Serializar();
                        string xml1 = _servicio.LeerUsuarioPorClienteRut(u);
                        usu = new Usuario(xml1);
                        txtNombreCiente.Text = clien.Nombre;

                        txtApellidoMaterno.Text = clien.ApellidoMaterno;
                        txtApellidoPaterno.Text = clien.ApellidoPaterno;
                        txtDireccion.Text = clien.Direccion;
                        txtRutPasaporte.Text = clien.RutPasaporte;
                        txtUsuario.Text = usu.Nombre;
                        DV.Text = clien.Dv;
                        if (clien.RP.Equals("r"))
                        {
                            rbRut.IsChecked = true;
                        }
                        else
                        {
                            rbPasaporte.IsChecked = true;
                        }
                        int val = 0;
                        for (int i = 0; i < cbCiudad.Items.Count; i++)
                        {
                            Provincia p = (Provincia)cbCiudad.Items[i];
                            if (p.Id == tp.IdProvincia)
                            {
                                val = i;
                            }
                        }

                        cbCiudad.SelectedIndex = val;

                        for (int i = 0; i < cbComuna.Items.Count; i++)
                        {
                            Comuna p = (Comuna)cbComuna.Items[i];
                            if (p.Id == tp.Id)
                            {
                                val = i;
                            }
                        }


                        cbComuna.SelectedIndex = val;

                    }
                }

            }
            else
            {
                btnModificar.Visibility = Visibility.Hidden;
            }

        }

        private void cbCiudad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Comuna comuna = new Comuna();
            Provincia ciudad = (Provincia)cbCiudad.SelectedItem;
            string xml = _servicio.LeerTodasComunasById(ciudad.Id.ToString());
            List<Comuna> cm = Util.Deserializar<List<Comuna>>(xml);
            cbComuna.ItemsSource = cm;
            cbComuna.DisplayMemberPath = "NombreComuna";
        }

        public bool Validar()
        {
            Limpiar();
            bool valido = true;
            string rut = txtRutPasaporte.Text.Trim();
            string nombre = txtNombreCiente.Text.Trim();
            string apellidoP = txtApellidoPaterno.Text.Trim();
            string apellidoM = txtApellidoMaterno.Text.Trim();
            string direccion = txtDireccion.Text.Trim();
            string Dv = DV.Text.Trim();

            //Validacion Provincia
            if (cbCiudad.SelectedIndex == -1)
            {
                lblCiudadMsg.Visibility = Visibility.Visible;
                lblCiudadMsg.ToolTip = string.Format("Debe seleccionar una Provincia");
                valido = false;
            }
            //Validacion comuna
            if (cbComuna.SelectedIndex == -1)
            {
                lblComunaMsg.Visibility = Visibility;
                lblComunaMsg.ToolTip = string.Format("Debe seleccionar una Comuna");
                valido = false;
            }
            //Validacion rut pasaporte
            if (rut.Length < 7)
            {
                lblRutPasaporteMsg.Visibility = Visibility;
                lblRutPasaporteMsg.ToolTip = string.Format("Debe ingresar un rut o pasaporte valido");
                valido = false;
            }
            if ((bool)rbRut.IsChecked)
            {
                if (!esRutValido(rut, Dv))
                {
                    lblRutPasaporteMsg.Visibility = Visibility;
                    lblRutPasaporteMsg.ToolTip = string.Format("Debe ingresar un rut valido");
                    valido = false;
                }
            }
            else
            {
                if (txtRutPasaporte.Text.Length < 8 || txtRutPasaporte.Text.Length > 10)
                {

                    lblRutPasaporteMsg.Visibility = Visibility;
                    lblRutPasaporteMsg.ToolTip = string.Format("Debe ingresar un pasaporte valido");
                    valido = false;
                }
            }



            //Validacion nombre
            if (nombre.Length.Equals(0))
            {
                lblNombreMsg.Visibility = Visibility;
                lblNombreMsg.ToolTip = string.Format("El Nombre no puede estar vacío");
                valido = false;
            }


            //Validacion apellidos
            if (apellidoP.Length.Equals(0))
            {
                lblApellidoPMsg.Visibility = Visibility;
                lblApellidoPMsg.ToolTip = string.Format("El Apellido Paterno no puede estar vacío");
                valido = false;
            }
            if (apellidoM.Length.Equals(0))
            {
                lblApellidoMMsg.Visibility = Visibility;
                lblApellidoMMsg.ToolTip = string.Format("El Apellido Materno no puede estar vacío");
                valido = false;
            }

            //Validacion direccion
            if (direccion.Length.Equals(0))
            {
                lblDireccionMsg.Visibility = Visibility;
                lblDireccionMsg.ToolTip = string.Format("La direccion no puede estar vacía");
                valido = false;
            }






            return valido;
        }


        public void Limpiar()
        {
            lblRutPasaporteMsg.Visibility = Visibility.Hidden;
            lblRutPasaporteMsg.ToolTip = string.Format("");

            lblNombreMsg.Visibility = Visibility.Hidden;
            lblNombreMsg.ToolTip = string.Format("");

            lblApellidoPMsg.Visibility = Visibility.Hidden;
            lblApellidoPMsg.ToolTip = string.Format("");

            lblApellidoMMsg.Visibility = Visibility.Hidden;
            lblApellidoMMsg.ToolTip = string.Format("");

            lblDireccionMsg.Visibility = Visibility.Hidden;
            lblDireccionMsg.ToolTip = string.Format("");

            lblComunaMsg.Visibility = Visibility.Hidden;
            lblComunaMsg.ToolTip = string.Format("");

            lblCiudadMsg.Visibility = Visibility.Hidden;
            lblCiudadMsg.ToolTip = string.Format("");



        }

        private async void btnAgregar_Click(object sender, RoutedEventArgs e)
        {

            if (Validar())
            {
                Cliente cliente = new Cliente();

                cliente.RutPasaporte = txtRutPasaporte.Text;
                cliente.Nombre = txtNombreCiente.Text;
                cliente.ApellidoPaterno = txtApellidoPaterno.Text;
                cliente.ApellidoMaterno = txtApellidoMaterno.Text;
                cliente.Direccion = txtDireccion.Text;
                Comuna comuna = (Comuna)cbComuna.SelectedItem;
                cliente.IdComuna = comuna.Id;
                if ((bool)rbRut.IsChecked)
                {
                    cliente.RP = "r";
                }
                else
                {
                    cliente.RP = "p";
                }
                cliente.Dv = DV.Text;
                string xml = cliente.Serializar();

                if (_servicio.CrearClientes(xml))
                {
                    await this.ShowMessageAsync("Información", "Cliente Creado con Éxito");

                    Usuario u = new Usuario();
                    u.RutPasaporteCliente = cliente.RutPasaporte;
                    xml = u.Serializar();
                    if (_servicio.CrearUsuario(xml))
                    {
                        await this.ShowMessageAsync("Información", "Usuario Creado con Éxito");
                        xml = _servicio.LeerPorRut(xml);
                        u = new Usuario(xml);
                        txtUsuario.Text = u.Nombre;
                        txtUsuario.IsEnabled = false;
                    }
                    
                }
                else
                {
                    await this.ShowMessageAsync("Información", "Cliente No ha sido Creado, puede haber ocurrido un error o el Cliente ya existe");
                }
            }


        }





        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (Validar())
            {
                Cliente cliente = new Cliente();

                cliente.RutPasaporte = txtRutPasaporte.Text;
                cliente.Nombre = txtNombreCiente.Text;
                cliente.ApellidoPaterno = txtApellidoPaterno.Text;
                cliente.ApellidoMaterno = txtApellidoMaterno.Text;
                cliente.Direccion = txtDireccion.Text;
                Comuna comuna = (Comuna)cbComuna.SelectedItem;
                cliente.IdComuna = comuna.Id;
                if ((bool)rbRut.IsChecked)
                {
                    cliente.RP = "r";
                }
                else
                {
                    cliente.RP = "p";
                }

                string xml = cliente.Serializar();

                if (_servicio.ActualizarCliente(xml))
                {
                    await this.ShowMessageAsync("Información", "Cliente actualizado con Éxito");
                }
                else
                {
                    await this.ShowMessageAsync("Información", "Cliente No ha sido actualizado, puede haber ocurrido un error o el Cliente ya existe");
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
    }
}


