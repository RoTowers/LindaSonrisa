using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LindaSonrisaWPF
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LSservicio.ServicioLSClient _servicio;
        public MainWindow()
        {
            InitializeComponent();
            InicializarWCF();
        }

        private void InicializarWCF()
        {
            _servicio = new LSservicio.ServicioLSClient();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            LindaSonrisa.Negocio.Usuario usuario = new LindaSonrisa.Negocio.Usuario();
            usuario.NOMBRE = txtUsuario.Text;
            usuario.CONTRASENA = txtContrasena.Text;

            string xml = usuario.Serializar();

            if (_servicio.Validar(xml))
            {

                xml = _servicio.Leer(xml);
                if (xml != null)
                {

                    usuario = new LindaSonrisa.Negocio.Usuario(xml);
                    lblValida.Content = string.Format("{0} {1} ", usuario.NOMBRE, usuario.PERFIL);

                }
            }
            else
            {
                lblValida.Content = "Usuario no es valido";
                lblMensaje.Content = "No se encontraron los datos";
            }
        }
    }
}
