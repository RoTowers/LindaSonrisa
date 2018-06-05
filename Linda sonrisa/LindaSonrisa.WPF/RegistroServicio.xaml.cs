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
using System.ComponentModel;

namespace LindaSonrisa.WPF
{
    /// <summary>
    /// Lógica de interacción para RegistroServicio.xaml
    /// </summary>
    public partial class RegistroServicio : MetroWindow
    {

        private LSservicio.ServicioLSClient _servicio;
        private List<ServPro> ServProlista;
        public decimal Id { get; set; }
        public RegistroServicio()
        {
            InitializeComponent();
            Init();
            btnModificar.Visibility = Visibility.Hidden;
        }

        public RegistroServicio(decimal id)
        {
            InitializeComponent();
            Id = id;
            Init();
            CargarDatos();

        }

        private void CargarDatos()
        {
            if (Id != 0)
            {
                btnCrear.Visibility = Visibility.Hidden;
                string xml = _servicio.LeerServicioProductoPorIdServicio(Id);

                List<Servicio_Producto> servicioProducto = Util.Deserializar<List<Servicio_Producto>>(xml);

                foreach (var item in servicioProducto)
                {
                    ServPro servPro = new ServPro();
                    Producto pro = new Producto();

                    pro.Id = item.IdProducto;
                    xml = pro.Serializar();
                    string xmlPro = _servicio.LeerProducto(xml);
                    pro = new Producto(xmlPro);

                    int id = pro.IdTipoProducto;
                    xml = _servicio.LeerTipoProductoPorID(id.ToString());
                    TipoProducto tipo = new TipoProducto(xml);

                    xml = _servicio.readFamiliaProducto(tipo.Id.ToString());
                    FamiliaProducto fami = new FamiliaProducto(xml);
                    Servicio ser = new Servicio();
                    ser.Id = Id;
                    xmlPro = ser.Serializar();
                    xml = _servicio.LeerServicio(xmlPro);
                    ser = new Servicio(xml);

                    servPro.ProductoId = pro.Id;
                    servPro.ProductoNombre = pro.Nombre;
                    servPro.Cantidad = (int)item.Cantidad;
                    servPro.TipoId = tipo.Id;
                    servPro.TipoNombre = tipo.Nombre;
                    servPro.FamiliaId = fami.Id;
                    servPro.FamiliaNombre = fami.Nombre;
                    servPro.ServicioNombre = ser.Nombre;
                    servPro.idServicioProducto = (int)item.Id;
                    ServProlista.Add(servPro);
                }
                dgServicio.ItemsSource = ServProlista;
                dgServicio.Items.Refresh();
            }

        }

        private void Init()
        {
            _servicio = new LSservicio.ServicioLSClient();
            ServProlista = new List<ServPro>();
            CargarFamiliaProducto();
        }

        public void CargarFamiliaProducto()
        {
            FamiliaProductoCollection fpc = new FamiliaProductoCollection();
            string xml = _servicio.readAllFamiliaProducto();
            List<FamiliaProducto> lfp = Util.Deserializar<List<FamiliaProducto>>(xml);

            cboFamiliaProducto.ItemsSource = lfp;
            cboFamiliaProducto.SelectedValuePath = "Id";

        }

        private void cboFamiliaProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int val = int.Parse(cboFamiliaProducto.SelectedValue.ToString());
            TipoProductoCollection fpc = new TipoProductoCollection();
            string xml = _servicio.readAllTipoProductoByFP(val.ToString());
            List<TipoProducto> lfp = Util.Deserializar<List<TipoProducto>>(xml);
            cbTipoProducto.ItemsSource = lfp;
            cbTipoProducto.SelectedValuePath = "Id";
        }

        public bool Validar()
        {
            Limpiar();
            bool valido = true;
            string servicio = txtNombreServicio.Text.Trim();
            string cantiad = txtCantidad.Text.Trim();


            //Validacion FamiliProducto
            if (cboFamiliaProducto.SelectedIndex == -1)
            {
                lblFamiliaMsg.Visibility = Visibility.Visible;
                lblFamiliaMsg.ToolTip = string.Format("Debe seleccionar una Familia de productos");
                valido = false;
            }
            //Validacion TipoProdcuto
            if (cbTipoProducto.SelectedIndex == -1)
            {
                lblTipoMsg.Visibility = Visibility;
                lblTipoMsg.ToolTip = string.Format("Debe seleccionar un tipo de producto");
                valido = false;
            }
            //Validacion Producto
            if (cbProducto.SelectedIndex == -1)
            {
                lblProductoMsg.Visibility = Visibility;
                lblProductoMsg.ToolTip = string.Format("Debe seleccionar un producto");
                valido = false;
            }


            //Validacion NombreServicio
            if (servicio.Length.Equals(0))
            {
                lblServicioMsg.Visibility = Visibility;
                lblServicioMsg.ToolTip = string.Format("El Nombre no puede estar vacío");
                valido = false;
            }

            //Validacion cantidad
            if (cantiad.Length.Equals(0))
            {
                lblCantidadMsg.Visibility = Visibility;
                lblCantidadMsg.ToolTip = string.Format("La cantidad no puede estar vacía");
                valido = false;
            }



            return valido;
        }

        public void Limpiar()
        {
            lblFamiliaMsg.Visibility = Visibility.Hidden;
            lblFamiliaMsg.ToolTip = string.Format("");

            lblTipoMsg.Visibility = Visibility.Hidden;
            lblTipoMsg.ToolTip = string.Format("");

            lblProductoMsg.Visibility = Visibility.Hidden;
            lblProductoMsg.ToolTip = string.Format("");

            lblServicioMsg.Visibility = Visibility.Hidden;
            lblServicioMsg.ToolTip = string.Format("");





        }

        private void Cargardg()
        {
            ServPro servPro = new ServPro();
            servPro.ServicioNombre = txtNombreServicio.Text;
            FamiliaProducto fami = (FamiliaProducto)cboFamiliaProducto.SelectedItem;
            TipoProducto tipo = (TipoProducto)cbTipoProducto.SelectedItem;
            Producto pro = (Producto)cbProducto.SelectedItem;
            servPro.FamiliaNombre = fami.Nombre;
            servPro.TipoNombre = tipo.Nombre;
            servPro.ProductoNombre = pro.Nombre;
            servPro.Cantidad = int.Parse(txtCantidad.Text);
            servPro.FamiliaId = fami.Id;
            servPro.TipoId = tipo.Id;
            servPro.ProductoId = pro.Id;
            ServProlista.Add(servPro);

            dgServicio.ItemsSource = ServProlista;
            dgServicio.Items.Refresh();
        }
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {

            if (Validar())
            {

                Cargardg();

            }
        }


        private void cbTipoProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTipoProducto.SelectedValue != null)
            {
                int val = int.Parse(cbTipoProducto.SelectedValue.ToString());
                ProductosCollection fpc = new ProductosCollection();
                string xml = _servicio.readAllProductosByTipo(val.ToString());
                List<Producto> lfp = Util.Deserializar<List<Producto>>(xml);
                cbProducto.ItemsSource = lfp;
                cbProducto.SelectedValuePath = "Id";
            }



        }

        private async void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            Servicio servicio = new Servicio();


            string xml = string.Empty;
            string idServicio = string.Empty;
            string idProducto = string.Empty;

            servicio.Nombre = txtNombreServicio.Text;
            xml = servicio.Serializar();
            if (_servicio.CreateServicio(xml))
            {
                idServicio = _servicio.LeerServicio(xml);
                int cont = 0;
                await this.ShowMessageAsync("Información", "Servicio Creado con Éxito");
                servicio = new Servicio(idServicio);
                foreach (var item in ServProlista)
                {
                    Servicio_Producto servicioProducto = new Servicio_Producto();
                    servicioProducto.IdServicio = servicio.Id;
                    Producto producto = new Producto();
                    producto.Nombre = item.ProductoNombre;
                    xml = producto.Serializar();
                    idProducto = _servicio.LeerProductoPorNombre(xml);
                    Producto prod = new Producto(idProducto);
                    servicioProducto.IdProducto = prod.Id;
                    servicioProducto.Cantidad = item.Cantidad;
                    xml = servicioProducto.Serializar();
                    if (_servicio.CreateServicioProducto(xml))
                    {
                        cont++;
                    }

                }
                if (cont == ServProlista.Count)
                {
                    await this.ShowMessageAsync("Información", "Se agregaron Todos los Productos al Servicio");
                }
                else
                {
                    await this.ShowMessageAsync("Información", "Hay Productos que no se agregaron al Servicio");
                }
            }
        }





        private async void Eliminar(object sender, RoutedEventArgs e)
        {
            if (Id != 0)
            {
                int val = dgServicio.SelectedIndex;
                ServPro p = (ServPro)dgServicio.Items[val];
                Servicio_Producto serp = new Servicio_Producto();
                serp.Id = p.idServicioProducto;
                string xml = serp.Serializar();
                ServProlista.Remove(p);
                if (_servicio.BorrarServicioProducto(xml))
                {
                    dgServicio.Items.Refresh();
                    await this.ShowMessageAsync("Información", "Producto fue Eliminado de la lista");
                }
            }
            else
            {
                int val = dgServicio.SelectedIndex;
                ServPro p = (ServPro)dgServicio.Items[val];
                ServProlista.Remove(p);

                await this.ShowMessageAsync("Información", "Producto fue Eliminado de la lista");

                dgServicio.Items.Refresh();
            }
        }

        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {


            if (txtNombreServicio.Text != "")
            {


                
                    Servicio servicio = new Servicio();


                    string xml = string.Empty;
                    string idServicio = string.Empty;
                    string idProducto = string.Empty;
                    servicio.Id = Id;
                    servicio.Nombre = txtNombreServicio.Text;
                    xml = servicio.Serializar();
                    if (_servicio.ActualizarServicio(xml))
                    {
                        idServicio = _servicio.LeerServicio(xml);
                        int cont = 0;
                        int cont1 = 0;
                        await this.ShowMessageAsync("Información", "Servicio Actualizado con Éxito");
                        servicio = new Servicio(idServicio);
                        foreach (var item in ServProlista)
                        {

                            if (item.idServicioProducto == 0)
                            {
                                cont1++;
                                Servicio_Producto servicioProducto = new Servicio_Producto();
                                servicioProducto.IdServicio = servicio.Id;
                                Producto producto = new Producto();
                                producto.Nombre = item.ProductoNombre;
                                xml = producto.Serializar();
                                idProducto = _servicio.LeerProductoPorNombre(xml);
                                Producto prod = new Producto(idProducto);
                                servicioProducto.IdProducto = prod.Id;
                                servicioProducto.Cantidad = item.Cantidad;
                                xml = servicioProducto.Serializar();
                                if (_servicio.CreateServicioProducto(xml))
                                {
                                    cont++;
                                }

                            }

                        }
                        if (cont == cont1)
                        {
                            await this.ShowMessageAsync("Información", "Se actualizaron Todos los Productos del Servicio");
                        }
                        else
                        {
                            await this.ShowMessageAsync("Información", "Hay Productos que no se actualizaron al Servicio");
                        }
                    }
            }
            else
            {
                lblServicioMsg.Visibility = Visibility.Visible;
                lblServicioMsg.ToolTip = "Debe Ingresar Nombre al Servicio";
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