/// <history> 
///     [Alexis Moya] 27/04/2018 Modificado
///     [Franco Retamal] 01/05/2018 Modificado
///     [Rodrigo Torres] 02/05/2018 Modificado
/// </history> 

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
using LindaSonrisa.Negocio;

namespace LindaSonrisa.WPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private LSservicio.ServicioLSClient _servicio;
        public MainWindow()
        {
            InitializeComponent();
            InicializarWCF();
        }
        //Crea una instancia del servicio
        private void InicializarWCF()
        {
            _servicio = new LSservicio.ServicioLSClient();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            //Crea el objeto usuario y se llenan sus propiedades para validacion
            Usuario usuario = new Usuario();
            usuario.Nombre = txtUsuario.Text;
            usuario.Contrasena = txtContrasena.Password.ToString();

            //Se serializa el objeto usuario
            string xml = usuario.Serializar();

            //Se ocupa el metodo Validar del servicio y se le envia el objeto serializado de usuario
            if (_servicio.Validar(xml))
            {
                //En caso de que sea valido se obtiene el objeto usuario serializado con todas sus propiedades llenas
                xml = _servicio.Leer(xml);
                if (xml != null)
                {
                    //en caso de que haya podido leer el usuario, se deserializa
                    usuario = new Usuario(xml);
                    string nombre = string.Empty;
                    string texto = string.Empty;
                    //CambioContraseña p2 = new CambioContraseña();
                    Inicio ventana_inicio = new Inicio();

                    if (usuario.RutPasaporteCliente != "")
                    {
                        //Si el usuario es Cliente
                        nombre = string.Format("{0} {1} {2}", usuario.cliente.Nombre, usuario.cliente.ApellidoPaterno, usuario.cliente.ApellidoMaterno);
                        texto = usuario.cliente.Direccion;
                    }
                    else if (usuario.RutProveedor != "")
                    {
                        //Si el usuario es Provedor
                        nombre = string.Format("{0} ", usuario.proveedor.Nombre);
                        ventana_inicio.lblDescripcion.Content = "Rubro: ";
                        texto = usuario.proveedor.Rubro;
                    }
                    else
                    {
                        //Si el usuario es Empleado
                        nombre = string.Format("{0} {1} {2}", usuario.empleado.Nombre, usuario.empleado.ApellidoPaterno, usuario.empleado.ApellidoMaterno);
                        texto = usuario.empleado.Cargo.Nombre;
                    }

                    if (usuario.LogIn == 0)
                    {
                        Cambio_Contrasena cambio = new Cambio_Contrasena(usuario.Nombre, nombre);
                        cambio.Show();
                        this.Close();
                    }else
                    {
                        Inicio inicio = new Inicio();
                        Session.Usuario = usuario.Nombre;
                        Session.NombreCompleto = nombre;
                        Session.Perfil = usuario.Perfil;
                        inicio.Show();
                        this.Close();
                    }
                }
            }
            else
            {
                await this.ShowMessageAsync("Información", "Usuario no es valido, No se encontraron los datos");
            }
        }
    }
}
