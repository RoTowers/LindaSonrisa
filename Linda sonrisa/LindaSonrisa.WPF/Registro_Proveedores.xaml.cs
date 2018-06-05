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
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace LindaSonrisa.WPF
{
    /// <summary>
    /// Lógica de interacción para RegistroProveedor.xaml
    /// </summary>
    public partial class Registro_Proveedores : MetroWindow
    {

        Microsoft.Office.Interop.Excel.Application _excel;
        Workbook work;

        private string Rut { get; set; }


        private LSservicio.ServicioLSClient _servicio;


        public Registro_Proveedores()
        {
            InitializeComponent();
            _servicio = new LSservicio.ServicioLSClient();

            CargarDatos();



        }

        public Registro_Proveedores(string id)
        {
            InitializeComponent();
            button.Visibility = Visibility.Hidden;
            button3.Visibility = Visibility.Hidden;
            button4.Visibility = Visibility.Hidden;
            _servicio = new LSservicio.ServicioLSClient();
            Rut = id;
            txt_rut.Text = Rut;



            Proveedor p = new Proveedor();
            p.Rut = Rut;
            string xml = p.Serializar();
            xml = _servicio.TraerProveedor(xml);
            if (xml != null)
            {
                Proveedor proveedor = new Proveedor(xml);

                txt_Nombre.Text = proveedor.Nombre;
                txt_rubro.Text = proveedor.Rubro;
                txt_contacto.Text = proveedor.Telefono.ToString();
                txt_correo.Text = proveedor.Correo;
                txt_dv.Text = proveedor.Dv;
                txt_direccion.Text = proveedor.Direccion;
                CargarDatos();
                int val = 0;

                Comuna com = new Comuna();
                com.Id = int.Parse(proveedor.IdComuna.ToString());
                xml = com.Serializar();
                xml = _servicio.LeerComuna(xml);
                com = new Comuna(xml);
                // CargarDatos();
                for (int i = 0; i < cbcProvincia.Items.Count; i++)
                {
                    Provincia pr = (Provincia)cbcProvincia.Items[i];
                    if (com.provincia.Id == pr.Id)
                    {
                        val = i;
                    }
                }
                cbcProvincia.SelectedIndex = val;
                val = 0;
                for (int i = 0; i < cbcComuna.Items.Count; i++)
                {
                    Comuna c = (Comuna)cbcComuna.Items[i];
                    if (c.Id == proveedor.IdComuna)
                    {
                        val = i;
                    }
                }

                cbcComuna.SelectedIndex = val;

                Usuario u = new Usuario();
                u.RutProveedor = proveedor.Rut;
                xml = u.Serializar();
                xml = _servicio.LeerPorRut(xml);
                if (xml != null)
                {
                    u = new Usuario(xml);
                    txt_usuario.Text = u.Nombre;
                }
            }




        }



        private void CargarDatos()
        {
            string xml = _servicio.LeerTodasProvincias();
            List<Provincia> c = Util.Deserializar<List<Provincia>>(xml);
            cbcProvincia.ItemsSource = c;
            cbcProvincia.SelectedValuePath = "Id";
            cbcProvincia.SelectedIndex = 0;

        }








        private Boolean email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public bool Validar()
        {
            bool a;
            if (txt_rut.Text.Trim().Length == 8)
            {
                if (txt_dv.Text == "k" || txt_dv.Text == "K" || int.Parse(txt_dv.Text) >= 1 && int.Parse(txt_dv.Text) <= 9)
                {

                    if (txt_contacto.Text.Trim().Length == 9 && txt_Nombre.Text.Trim().Length > 0 && txt_rubro.Text.Trim().Length > 0)
                    {

                        string correo = txt_correo.Text;
                        if (email_bien_escrito(correo))
                        {
                            a = true;
                        }
                        else
                        {
                            a = false;
                        }

                    }
                    else
                    {
                        a = false;
                    }

                }
                else
                {
                    a = false;
                }
            }
            else
            {
                a = false;
            }
            return a;

        }

        private void RegistroServicio(object sender, RoutedEventArgs e)
        {
            RegistroServicio p2 = new RegistroServicio();
            p2.Show();
            this.Close();
        }

        private async void button4_Click(object sender, RoutedEventArgs e)
        {

            Proveedor p = new Proveedor();
            p.Rut = txt_rut.Text;
            string xml = p.Serializar();
            xml = _servicio.TraerProveedor(xml);
            if (xml != null)
            {
                Proveedor proveedor = new Proveedor(xml);

                txt_Nombre.Text = proveedor.Nombre;
                txt_rubro.Text = proveedor.Rubro;
                txt_contacto.Text = proveedor.Telefono.ToString();
                txt_correo.Text = proveedor.Correo;
                txt_dv.Text = proveedor.Dv;
                txt_direccion.Text = proveedor.Direccion;

                Usuario u = new Usuario();
                u.proveedor = proveedor;
                u.RutProveedor = u.proveedor.Rut;
                xml = u.Serializar();
                xml = _servicio.LeerPorRut(xml);

                //xml = u.Serializar();
                u = new Usuario(xml);
                txt_usuario.Text = u.Nombre;



                int val = 0;

                Comuna com = new Comuna();
                com.Id = int.Parse(proveedor.IdComuna.ToString());
                xml = com.Serializar();
                xml = _servicio.LeerComuna(xml);
                com = new Comuna(xml);
                for (int i = 0; i < cbcProvincia.Items.Count; i++)
                {
                    Provincia pr = (Provincia)cbcProvincia.Items[i];
                    if (com.provincia.Id == pr.Id)
                    {
                        val = i;
                    }
                }
                cbcProvincia.SelectedIndex = val;
                val = 0;
                for (int i = 0; i < cbcComuna.Items.Count; i++)
                {
                    Comuna c = (Comuna)cbcComuna.Items[i];
                    if (c.Id == proveedor.IdComuna)
                    {
                        val = i;
                    }
                }

                cbcComuna.SelectedIndex = val;




            }
            else
            {
                await this.ShowMessageAsync("Información", "el rut buscado no esta registrado, No se encontraron los datos");
            }

        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            if (Validar())
            {
                Proveedor p = new Proveedor();
                string rut = txt_rut.Text;
                p.Rut = rut;
                p.Dv = txt_dv.Text;
                string xml = p.Serializar();
                xml = _servicio.TraerProveedor(xml);
                if (xml == null)
                {


                    p.Nombre = txt_Nombre.Text;
                    p.Rubro = txt_rubro.Text;
                    p.Telefono = int.Parse(txt_contacto.Text);

                    int ab = int.Parse(cbcComuna.SelectedValue.ToString());
                    p.IdComuna = ab;
                    p.Direccion = txt_direccion.Text;
                    p.Correo = txt_correo.Text;

                    xml = p.Serializar();
                    _servicio.CrearProv(xml);
                    Usuario u = new Usuario();
                    u.Perfil = "Proveedor";
                    u.RutProveedor = p.Rut;
                    xml = u.Serializar();

                    if (_servicio.CrearUsuario(xml))
                    {
                        await this.ShowMessageAsync("Información", "Correcto, Usuario creado");
                        xml = _servicio.LeerPorRut(xml);

                        u = Util.Deserializar<Usuario>(xml);
                        txt_usuario.Text = u.Nombre;


                    }
                    else
                    {
                        await this.ShowMessageAsync("Información", "Error, Usuario no creado");
                    }

                    await this.ShowMessageAsync("Información", "Correcto, Proveedor creado");
                }
                else
                {
                    await this.ShowMessageAsync("Información", "el rut buscado  esta registrado, No se puede sobre escribir");
                }
            }
            else
            {
                await this.ShowMessageAsync("Información", "Datos incorrectos");
            }



        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            Proveedor p = new Proveedor();
            p.Rut = txt_rut.Text;
            string xml = p.Serializar();
            xml = _servicio.TraerProveedor(xml);
            if (xml != null)
            {
                Comuna comuna = (Comuna)cbcComuna.SelectedItem;


                p.Nombre = txt_Nombre.Text;
                p.Rubro = txt_rubro.Text;
                p.Telefono = int.Parse(txt_contacto.Text);
                p.Correo = txt_correo.Text;
                int ab = int.Parse(cbcComuna.SelectedValue.ToString());
                p.IdComuna = ab;
                p.Direccion = txt_direccion.Text;
                p.Dv = txt_dv.Text;
                xml = p.Serializar();
                _servicio.ActualizarProv(xml);
                await this.ShowMessageAsync("Información", "Correcto, Actualizado correctamente");
            }
            else
            {
                await this.ShowMessageAsync("Información", "el rut buscado no esta registrado, No se encontraron los datos");
            }
        }

        private async void button2_Click(object sender, RoutedEventArgs e)
        {
            Proveedor p = new Proveedor();
            p.Rut = txt_rut.Text;
            string xml = p.Serializar();
            xml = _servicio.TraerProveedor(xml);
            if (xml != null)
            {
                Usuario u = new Usuario();
                u.RutProveedor = p.Rut;
                string xml2 = u.Serializar();
                if (_servicio.EliminarUsuarioPorRut(xml2))
                {
                    await this.ShowMessageAsync("Información", "Correcto, Usuario eliminado");
                    if (_servicio.EliminarProv(xml))
                    {
                        await this.ShowMessageAsync("Información", "Correcto, Proveedor eliminado");
                    }else
                    {
                        await this.ShowMessageAsync("Información", "Error, Proveedor NO eliminado");
                    }

                }
                else
                {
                    await this.ShowMessageAsync("Información", "Error, Usuario NO eliminado");
                }
            }
            else
            {
                await this.ShowMessageAsync("Información", "el rut buscado no esta registrado, No se encontraron los datos");
            }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            txt_contacto.Text = "";
            txt_correo.Text = "";
            txt_Nombre.Text = "";
            txt_rubro.Text = "";
            txt_rut.Text = "";
            txt_dv.Text = "";
            txt_usuario.Text = "";

            txt_direccion.Text = "";
            cbcProvincia.SelectedIndex = 0;

        }


        private async void button3_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                _excel = new Microsoft.Office.Interop.Excel.Application();
                work = _excel.Workbooks.Open(dialog.FileName);
                int Finicio, Ffin;
                Finicio = 1;
                //cambiar para que usuario elija
                Ffin = 3;
                int j = 1;
                // Cfin = 5;
                Worksheet wh = (Worksheet)work.Sheets[1];
                string mensaje = string.Format("Se Crearon los siguiente Proveedores{0}", Environment.NewLine);
                string mensaje_error = string.Format("No se Crearon los siguiente Proveedores{0}", Environment.NewLine);
                string mensaje_usuarios = string.Format("Se Crearon los siguiente Usuarios{0}", Environment.NewLine);
                for (int i = Finicio; i <= Ffin; i++)
                {
                    //Nullable<decimal> val = 0;
                    Proveedor p = new Proveedor();
                    j = 1;
                    p.Rut = (((Range)wh.Cells[i, j]).Value2).ToString();
                    j++;
                    p.Dv = (((Range)wh.Cells[i, j]).Value2).ToString();
                    j++;
                    p.Nombre = (((Range)wh.Cells[i, j]).Value2).ToString();
                    j++;
                    p.Rubro = (((Range)wh.Cells[i, j]).Value2).ToString();
                    j++;
                    p.Telefono = int.Parse((((Range)wh.Cells[i, j]).Value2).ToString());
                    //p.Telefono = 2;
                    j++;
                    p.Correo = (((Range)wh.Cells[i, j]).Value2).ToString();
                    j++;
                    p.Direccion = (((Range)wh.Cells[i, j]).Value2).ToString();
                    j++;
                    p.IdComuna = int.Parse((((Range)wh.Cells[i, j]).Value2).ToString());
                    //p.IdComuna = 3;


                    string xml = p.Serializar();
                    if (_servicio.CrearProv(xml))
                    {
                        mensaje = mensaje+""+string.Format("Rut: {1} Nombre: {2}{0}", Environment.NewLine, p.Rut, p.Nombre);
                        Usuario u = new Usuario();
                        u.RutProveedor = p.Rut;
                        u.Perfil = "Proveedor";
                        xml = u.Serializar();
                        if (_servicio.CrearUsuario(xml))
                        {
                            xml = _servicio.LeerPorRut(xml);
                            if (xml != null)
                            {
                                u = new Usuario(xml);
                                mensaje_usuarios = mensaje_usuarios + "" + string.Format("Rut: {1} Nombre: {2} Usuario: {3}{0}", Environment.NewLine, p.Rut, p.Nombre, u.Nombre);
                            }
                        }
                    }
                    else
                    {
                        mensaje_error = mensaje_error + "" + string.Format("Rut: {1} Nombre: {2}{0}", Environment.NewLine, p.Rut, p.Nombre);
                    }
                }
                await this.ShowMessageAsync("Información", mensaje);
                await this.ShowMessageAsync("Información", mensaje_usuarios);
                await this.ShowMessageAsync("Información", mensaje_error);
            }
            else
            {
                await this.ShowMessageAsync("Información", "Se ha Cancelado la Operación");
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



        private void cbcProvincia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string a = cbcProvincia.SelectedValue.ToString();
            string xml = _servicio.LeerTodasComunasById(a);
            List<Comuna> cc = Util.Deserializar<List<Comuna>>(xml);
            cbcComuna.ItemsSource = cc;
            cbcComuna.SelectedValuePath = "Id";
            cbcComuna.SelectedIndex = 0;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


    }
}

