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
    /// Lógica de interacción para Registro_Producto.xaml
    /// </summary>
    public partial class Registro_Producto : MetroWindow
    {
        private LSservicio.ServicioLSClient _servicio;
        public string IdProducto { get; set; }
        public Registro_Producto()
        {
            InitializeComponent();
            Init();
        }

        public Registro_Producto(string id)
        {
            InitializeComponent();
            IdProducto = id;
            Init();
            CargarDatos();
        }

        private void CargarDatos()
        {
            if (IdProducto != null)
            {
                Producto prod = new Producto();
                prod.Id = IdProducto;
                string xml = prod.Serializar();
                xml = _servicio.LeerProducto(xml);
                if (xml != null)
                {
                    btnCrear.IsEnabled = false;
                    prod = new Producto(xml);
                    TipoProducto tp = new TipoProducto();
                    tp.Id = prod.IdTipoProducto;
                    xml = tp.Serializar();
                    xml = _servicio.LeerTipoProducto(xml);
                    if (xml != null)
                    {
                        tp = new TipoProducto(xml);
                        txtProducto.Text = prod.Nombre;
                        if (prod.FechaVencimiento != null)
                        {
                            dpFechaVenc.SelectedDate = prod.FechaVencimiento.Value;
                        }
                        txtStock.Text = prod.Stock.ToString();
                        txtStockCritico.Text = prod.StockCritico.ToString();
                        txtPrecioCompra.Text = prod.PrecioCompra.ToString();
                        txtPrecioVenta.Text = prod.PrecioVenta.ToString();
                        int val = 0;
                        for (int i = 0; i < cboFamiliaProducto.Items.Count; i++)
                        {
                            FamiliaProducto p = (FamiliaProducto)cboFamiliaProducto.Items[i];
                            if (p.Id == tp.FamiliaProducto.Id)
                            {
                                val = i;
                            }
                        }

                        cboFamiliaProducto.SelectedIndex = val;

                        for (int i = 0; i < cboTipoProducto.Items.Count; i++)
                        {
                            TipoProducto p = (TipoProducto)cboTipoProducto.Items[i];
                            if (p.Id == tp.Id)
                            {
                                val = i;
                            }
                        }

                        
                        cboTipoProducto.SelectedIndex = val;
                        //cboFamiliaProducto.SelectedIndex = 0;
                        //cboTipoProducto.SelectedIndex = 0;
                    }
                }

            }
        }

        private void Init()
        {
            _servicio = new LSservicio.ServicioLSClient();
            if (IdProducto == null)
            {
                btnModificar.IsEnabled = false;
                btnEliminar.IsEnabled = false;
            }
            else
            {
                btnModificar.IsEnabled = true;
                btnEliminar.IsEnabled = true;
            }
            CargarFamiliaProducto();
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

        private void cboFamiliaProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            int val = int.Parse(cboFamiliaProducto.SelectedValue.ToString());
            TipoProductoCollection fpc = new TipoProductoCollection();
            string xml = _servicio.readAllTipoProductoByFP(val.ToString());
            List<TipoProducto> lfp = Util.Deserializar<List<TipoProducto>>(xml);
            cboTipoProducto.ItemsSource = lfp;
            cboTipoProducto.SelectedValuePath = "Id";
        }

        private void txtStock_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        public async Task<bool> Validar()
        {
            Limpiar();
            bool valido = true;
            string stock = txtStock.Text.Trim();
            string stockcritico = txtStockCritico.Text.Trim();
            string preciocompra = txtPrecioCompra.Text.Trim();
            string precioventa = txtPrecioVenta.Text.Trim();
            string producto = txtProducto.Text.Trim();
            string fecha_nacimiento = dpFechaVenc.Text.Trim();

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
            //Validacion Stock
            if (stock.Length.Equals(0))
            {
                lblStockMsg.Visibility = Visibility;
                lblStockMsg.ToolTip = string.Format("El Stock debe contener un valor");
                valido = false;
            }
            else if (int.Parse(stock) < 0)
            {
                lblStockMsg.Visibility = Visibility;
                lblStockMsg.ToolTip = string.Format("El Stock debe ser mayor o igual a cero");
                valido = false;
            }

            //Validacion Stock Critico
            if (stockcritico.Length.Equals(0))
            {
                lblStockCriticoMsg.Visibility = Visibility;
                lblStockCriticoMsg.ToolTip = string.Format("El Stock Crítico debe contener un valor");
                valido = false;
            }
            else if (int.Parse(stockcritico) < 0)
            {
                lblStockCriticoMsg.Visibility = Visibility;
                lblStockCriticoMsg.ToolTip = string.Format("El Stock debe ser mayor o igual a cero");
                valido = false;
            }

            //Validacion Precio de Compra
            if (preciocompra.Length.Equals(0))
            {
                lblPrecioCompraMsg.Visibility = Visibility;
                lblPrecioCompraMsg.ToolTip = string.Format("El Precio de Compra debe contener un valor");
                valido = false;
            }
            else if (int.Parse(preciocompra) <= 0)
            {
                lblPrecioCompraMsg.Visibility = Visibility;
                lblPrecioCompraMsg.ToolTip = string.Format("El Precio de Compra debe ser mayor a cero");
                valido = false;
            }

            //Validacion Precio de Venta
            if (precioventa.Length.Equals(0))
            {
                lblPrecioVentaMsg.Visibility = Visibility;
                lblPrecioVentaMsg.ToolTip = string.Format("El Precio de Venta debe contener un valor");
                valido = false;
            }
            else if (int.Parse(precioventa) <= 0)
            {
                lblPrecioVentaMsg.Visibility = Visibility;
                lblPrecioVentaMsg.ToolTip = string.Format("El Precio de Venta debe ser mayor a cero");
                valido = false;
            }

            //Validacion Producto
            if (producto.Length.Equals(0))
            {
                lblProductoMsg.Visibility = Visibility;
                lblProductoMsg.ToolTip = string.Format("El Producto no puede estar vacío");
                valido = false;
            }

            //Validacion Fecha de Nacimiento
            if (!fecha_nacimiento.Length.Equals(0))
            {
                DateTime fvenc = DateTime.Now;
                if (!DateTime.TryParse(fecha_nacimiento, out fvenc))
                {
                    lblFechaVencimientoMsg.Visibility = Visibility;
                    lblFechaVencimientoMsg.ToolTip = string.Format("La fecha ingresada es Incorrecta");
                    valido = false;
                }
                else if (fvenc.Date <= DateTime.Today)
                {
                    lblFechaVencimientoMsg.Visibility = Visibility;
                    lblFechaVencimientoMsg.ToolTip = string.Format("La fecha ingresada debe ser Mayor a la fecha actual");
                    valido = false;
                }
            }
            else
            {
                if (valido)
                {
                    var mySettings = new MetroDialogSettings()
                    {
                        AffirmativeButtonText = "Si",
                        NegativeButtonText = "No"
                    };

                    var result = await this.ShowMessageAsync("Confirmación", "No ha ingresado una fecha de vencimiento, ¿Desea seguir sin ingresarla?",
                    MahApps.Metro.Controls.Dialogs.MessageDialogStyle.AffirmativeAndNegative, mySettings);

                    if (!(result == MessageDialogResult.Affirmative))
                    {
                        valido = false;
                    }
                    
                }
                
            }

            return valido;
        }

        public void Limpiar()
        {
            lblFamiliaProductoMsg.Visibility = Visibility.Hidden;
            lblFamiliaProductoMsg.ToolTip = string.Format("");

            lblTipoProductoMsg.Visibility = Visibility.Hidden;
            lblTipoProductoMsg.ToolTip = string.Format("");

            lblProductoMsg.Visibility = Visibility.Hidden;
            lblProductoMsg.ToolTip = string.Format("");

            lblFechaVencimientoMsg.Visibility = Visibility.Hidden;
            lblFechaVencimientoMsg.ToolTip = string.Format("");

            lblStockMsg.Visibility = Visibility.Hidden;
            lblStockMsg.ToolTip = string.Format("");

            lblStockCriticoMsg.Visibility = Visibility.Hidden;
            lblStockCriticoMsg.ToolTip = string.Format("");

            lblPrecioCompraMsg.Visibility = Visibility.Hidden;
            lblPrecioCompraMsg.ToolTip = string.Format("");

            lblPrecioVentaMsg.Visibility = Visibility.Hidden;
            lblPrecioVentaMsg.ToolTip = string.Format("");

        }

        private async void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            if (await Validar())
            {
                Producto p = new Producto();
                
                p.Nombre = txtProducto.Text;
                if (dpFechaVenc.SelectedDate == null)
                {
                    p.FechaVencimiento = null;
                }else
                {
                    p.FechaVencimiento = DateTime.Parse(dpFechaVenc.SelectedDate.ToString());
                }
                p.Stock = int.Parse(txtStock.Text);
                p.StockCritico = int.Parse(txtStockCritico.Text);
                p.PrecioCompra = int.Parse(txtPrecioCompra.Text);
                p.PrecioVenta = int.Parse(txtPrecioVenta.Text);
                p.IdTipoProducto = int.Parse(cboTipoProducto.SelectedValue.ToString());
                string xml = p.Serializar();
                //Se cambio el metodo para que envie la familia de producto y se genere el id antes de crear el producto
                if (_servicio.CrearProducto(xml, cboFamiliaProducto.SelectedValue.ToString()))
                {
                    await this.ShowMessageAsync("Información", "Producto Creado con Éxito");
                }else
                {
                    await this.ShowMessageAsync("Información", "Producto No ha sido Creado, puede haber ocurrido un error o el Producto ya existe");
                }
                
            }
            //txtPrecioCompra.
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

        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (await Validar())
            {
                if (IdProducto != null)
                {
                    Producto p = new Producto();
                    p.Id = IdProducto;
                    p.Nombre = txtProducto.Text;
                    if (dpFechaVenc.SelectedDate == null)
                    {
                        p.FechaVencimiento = null;
                    }
                    else
                    {
                        p.FechaVencimiento = DateTime.Parse(dpFechaVenc.SelectedDate.ToString());
                    }
                    p.Stock = int.Parse(txtStock.Text);
                    p.StockCritico = int.Parse(txtStockCritico.Text);
                    p.PrecioCompra = int.Parse(txtPrecioCompra.Text);
                    p.PrecioVenta = int.Parse(txtPrecioVenta.Text);
                    p.IdTipoProducto = int.Parse(cboTipoProducto.SelectedValue.ToString());
                    string xml = p.Serializar();
                    if (_servicio.ActualizarProducto(xml))
                    {
                        await this.ShowMessageAsync("Información", "Producto Modificado con Éxito");
                    }
                    else
                    {
                        await this.ShowMessageAsync("Información", "Producto No ha sido Modificado");
                    }
                }else
                {
                    await this.ShowMessageAsync("Información", "No se encuentra Producto a Modificar");
                }
            }
        }

        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Producto p = new Producto();
            p.Id = IdProducto;
            string xml = p.Serializar();
            if (_servicio.EliminarProducto(xml))
            {
                await this.ShowMessageAsync("Información", "Producto Eliminado con Éxito");
                IdProducto = null;
                btnEliminar.IsEnabled = false;
                btnModificar.IsEnabled = false;
                Limpiar();
                LimpiarControles();
                btnCrear.IsEnabled = true;
            }
            else
            {
                await this.ShowMessageAsync("Información", "Producto NO fue eliminado");
            }
        }

        public void LimpiarControles()
        {
            cboTipoProducto.ItemsSource = null;
            //cboFamiliaProducto.ItemsSource = null;
            cboFamiliaProducto.SelectedIndex = 0;
            txtProducto.Text = string.Empty;
            dpFechaVenc.SelectedDate = null;
            txtStock.Text = string.Empty;
            txtStockCritico.Text = string.Empty;
            txtPrecioCompra.Text = string.Empty;
            txtPrecioVenta.Text = string.Empty;
        }
    }
}
