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
    /// Lógica de interacción para Orden_Pedido.xaml
    /// </summary>
    public partial class Orden_Pedido : MetroWindow
    {
        public Orden_Pedido()
        {
            InitializeComponent();
        }

        private async void btn_salir_Click(object sender, RoutedEventArgs e)
        {
            await this.ShowMessageAsync("Salir", "¿Estas Seguro De salir De la aplicaccion?");
            MainWindow ventana_main = new MainWindow();
            ventana_main.Show();
            this.Close();

        }

        private void txtCantidad_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }
    }
}
