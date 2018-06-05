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
    /// Lógica de interacción para CambioContraseña.xaml
    /// </summary>
    public partial class Cambio_Contrasena : MetroWindow
    {
        private string NombreUsuario { get; set; }
        private LSservicio.ServicioLSClient _servicio;

        public Cambio_Contrasena()
        {
            InitializeComponent();
        }

        public Cambio_Contrasena(string nombre, string nombrecompleto)
        {
            InitializeComponent();
            NombreUsuario = nombre;
            txtNombreCompleto.Text = string.Format("({0}) {1}", nombre, nombrecompleto);
            _servicio = new LSservicio.ServicioLSClient();
        }

        public void Limpiar()
        {
            lblContrasenaMsg.Visibility = Visibility.Hidden;
            lblContrasenaMsg.ToolTip = string.Format("");

            lblNuevaContrasenaMsg.Visibility = Visibility.Hidden;
            lblNuevaContrasenaMsg.ToolTip = string.Format("");

            lblCNuevaContrasenaMsg.Visibility = Visibility.Hidden;
            lblCNuevaContrasenaMsg.ToolTip = string.Format("");
        }

        public bool Validar()
        {
            Limpiar();
            bool valido = true;
            string contrasena = txtContrasena.Password.Trim();
            string nuevacontrasena = txtNuevaContrasena.Password.Trim();
            string cnuevacontrasena = txtCNuevaContrasena.Password.Trim();

            //Validacion Contraseña antigua
            if (contrasena.Length.Equals(0))
            {
                lblContrasenaMsg.Visibility = Visibility;
                lblContrasenaMsg.ToolTip = string.Format("Debe Ingresar su Contraseña Sin espacios");
                valido = false;
            }
            else if (contrasena.Length < 4 || contrasena.Length > 15)
            {
                lblContrasenaMsg.Visibility = Visibility;
                lblContrasenaMsg.ToolTip = string.Format("La Contraseña debe ser entre 4 y 15 caracteres Sin espacios");
                valido = false;
            }else
            {
                Negocio.Usuario u = new Negocio.Usuario();
                u.Nombre = NombreUsuario;
                u.Contrasena = contrasena;
                string xml = u.Serializar();
                if (!_servicio.Validar(xml))
                {
                    lblContrasenaMsg.Visibility = Visibility;
                    lblContrasenaMsg.ToolTip = string.Format("La Contraseña Ingresada No corresponde con la contraseña registrada en el sistema");
                    valido = false;
                }else
                {
                    //Validacion contraseña nueva
                    if (nuevacontrasena.Length.Equals(0))
                    {
                        lblNuevaContrasenaMsg.Visibility = Visibility;
                        lblNuevaContrasenaMsg.ToolTip = string.Format("Debe Ingresar una Nueva Contraseña Sin Espacios");
                        valido = false;
                    }
                    else if (nuevacontrasena.Length < 6 || nuevacontrasena.Length > 15)
                    {
                        lblNuevaContrasenaMsg.Visibility = Visibility;
                        lblNuevaContrasenaMsg.ToolTip = string.Format("La Contraseña debe ser entre 6 y 15 caracteres");
                        valido = false;
                    }
                    else
                    {
                        if (valido && nuevacontrasena.Equals(contrasena))
                        {
                            lblNuevaContrasenaMsg.Visibility = Visibility;
                            lblNuevaContrasenaMsg.ToolTip = string.Format("La Nueva Contraseña no debe ser igual a la Contraseña ya registrada en el Sistema");
                            valido = false;
                        }
                    }

                    //Validacion de Confirmacion de la nueva contraseña
                    if (!cnuevacontrasena.Equals(nuevacontrasena))
                    {
                        lblCNuevaContrasenaMsg.Visibility = Visibility;
                        lblCNuevaContrasenaMsg.ToolTip = string.Format("La Contraseña debe ser igual a La Nueva Contraseña");
                        valido = false;
                    }
                }
            }

            return valido;
        }

        private async void btn_cambiarC_Click(object sender, RoutedEventArgs e)
        {
            if (Validar())
            {
                Negocio.Usuario u = new Negocio.Usuario();
                u.Nombre = NombreUsuario;
                string xml = u.Serializar();
                xml = _servicio.Leer(xml);
                if (xml != null)
                {
                    u = new Negocio.Usuario(xml);
                    u.Contrasena = txtNuevaContrasena.Password.ToString();
                    u.LogIn = 1;
                    xml = u.Serializar();
                    if (_servicio.ModificarUsuario(xml))
                    {
                        await this.ShowMessageAsync("Información", "La Contraseña se ha Cambiado con Éxito");
                        Inicio inicio = new Inicio();
                        inicio.Show();
                        this.Close();
                    }
                    else
                    {
                        await this.ShowMessageAsync("Información", "La Contraseña no se ha Cambiado");
                    }
                }
                else
                {
                    await this.ShowMessageAsync("Información", "No se ha Encontrado el Usuario");
                }
            }
        }
    }
}
