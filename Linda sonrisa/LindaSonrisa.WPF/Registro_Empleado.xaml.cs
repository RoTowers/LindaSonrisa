using LindaSonrisa.Negocio;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para Registro_Empleado.xaml
    /// </summary>
    public partial class Registro_Empleado : MetroWindow
    {
        Microsoft.Office.Interop.Excel.Application _excel;
        Workbook work;

        public LSservicio.ServicioLSClient servicio;
        public string Rut { get; set; }

        public Registro_Empleado()
        {
            InitializeComponent();
            Iniciador();
        }

        public Registro_Empleado(string rut)
        {
            InitializeComponent();
            Iniciador();
            Rut = rut;
            CargarDatos();
        }

        private void CargarDatos()
        {
            if (Rut != null)
            {
                btnCrear.IsEnabled = false;
                Empleado emp = new Empleado();
                emp.Rut = Rut;
                string xml = emp.Serializar();
                xml = servicio.LeerEmpleado(xml);
                if (xml != null)
                {
                    emp = new Empleado(xml);
                    Cargos carg = new Cargos();
                    carg.Id = int.Parse(emp.IdCargo.ToString());
                    xml = carg.Serializar();
                    xml = servicio.LeerCargo(xml);
                    if (xml != null)
                    {
                        carg = new Cargos();
                        txt_Rut.Text = emp.Rut;
                        txt_Nombre.Text = emp.Nombre;
                        txt_Dv.Text = emp.Dv;
                        txt_ApellidoP.Text = emp.ApellidoPaterno;
                        txt_ApellidoM.Text = emp.ApellidoMaterno;
                        txt_Direccion.Text = emp.Direccion;
                        int val = 0;
                        for (int i = 0; i < cbo_Cargo.Items.Count; i++)
                        {
                            Cargos c = (Cargos)cbo_Cargo.Items[i];
                            if (c.Id == emp.IdCargo)
                            {
                                val = i;
                            }
                        }
                        cbo_Cargo.SelectedIndex = val;
                        Comuna com = new Comuna();
                        com.Id = int.Parse(emp.IdComuna.ToString());
                        xml = com.Serializar();
                        xml = servicio.LeerComuna(xml);
                        if (xml != null)
                        {
                            com = new Comuna(xml);
                            for (int i = 0; i < cbo_Ciudad.Items.Count; i++)
                            {
                                Provincia c = (Provincia)cbo_Ciudad.Items[i];
                                if (c.Id == com.IdProvincia)
                                {
                                    val = i;
                                }
                            }
                            cbo_Ciudad.SelectedIndex = val;

                            for (int i = 0; i < cbo_Comuna.Items.Count; i++)
                            {
                                Comuna c = (Comuna)cbo_Comuna.Items[i];
                                if (c.Id == int.Parse(emp.IdComuna.ToString()))
                                {
                                    val = i;
                                }
                            }
                            cbo_Comuna.SelectedIndex = val;
                        }

                       
                    }


                }
            }
        }

        //Inicia los combobox con los valores de base de datos, inicia el grid como hidden, desactiva el digito verificador
        public void Iniciador()
        {
            servicio = new LSservicio.ServicioLSClient();

            string xml = servicio.LeerTodasProvincias();

            List<Provincia> ciudades = Util.Deserializar<List<Provincia>>(xml);

            cbo_Ciudad.ItemsSource = ciudades;
            cbo_Ciudad.SelectedValuePath = "Id";

            string xmls = servicio.LeerTodosCargos();

            List<Cargos> cargos = Util.Deserializar<List<Cargos>>(xmls);

            cbo_Cargo.ItemsSource = cargos;
            cbo_Cargo.SelectedValuePath = "Id";
        }

        //Metodo para validar Rut
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

        private bool validarNoVacios()
        {
            bool resultado = true;
            int error = 0;

            if (txt_Rut.Text.Trim().Length <= 0)
            {
                error++;
            }
            if (txt_Nombre.Text.Trim().Length <= 0)
            {
                error++;
            }
            if (txt_ApellidoP.Text.Trim().Length <= 0)
            {
                error++;
            }
            if (txt_ApellidoM.Text.Trim().Length <= 0)
            {
                error++;
            }

            if (txt_Direccion.Text.Trim().Length <= 0)
            {
                error++;
            }
            if (cbo_Cargo.SelectedIndex < 0)
            {
                error++;
            }
            if (cbo_Comuna.SelectedIndex < 0)
            {
                error++;
            }
            if (error > 1)
            {
                resultado = false;
            }
            return resultado;

        }


        //Crea un empleado
        private async void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            if (validarNoVacios())
            {

                Empleado empleado = new Empleado();

                empleado.Rut = txt_Rut.Text.Trim();
                empleado.Dv = txt_Dv.Text;
                empleado.Nombre = txt_Nombre.Text.Trim();
                empleado.ApellidoPaterno = txt_ApellidoP.Text.Trim();
                empleado.ApellidoMaterno = txt_ApellidoM.Text.Trim();
                empleado.Direccion = txt_Direccion.Text.Trim();
                empleado.IdComuna = decimal.Parse(cbo_Comuna.SelectedValue.ToString());
                empleado.IdCargo = decimal.Parse(cbo_Cargo.SelectedValue.ToString());

                string xml = empleado.Serializar();

                if (esRutValido(txt_Rut.Text, txt_Dv.Text))
                {
                    try
                    {
                        if (servicio.CrearEmpleado(xml))
                        {

                            await this.ShowMessageAsync("Información", "Empleado creado en la base de datos");
                            Rut = empleado.Rut;
                            if (cbo_Cargo.SelectedValue.ToString() == "1")
                            {
                                Odontologo o = new Odontologo();
                                o.RutEmpleado = empleado.Rut;
                                xml = o.Serializar();
                                if (servicio.CrearOdontologo(xml))
                                {
                                    await this.ShowMessageAsync("Información", "Odontologo creado en la base de datos");
                                }
                                else
                                {
                                    await this.ShowMessageAsync("Información", "No se ha creado el Odontologo");
                                }
                            }
                        }
                        else
                        {
                            await this.ShowMessageAsync("Información", "Error, el empleado no se pudo crear");
                        }
                    }
                    catch (Exception)
                    {
                        await this.ShowMessageAsync("Información", "El empleado no se pudo crear en la base de datos");
                    }
                }
                else
                {
                    await this.ShowMessageAsync("Información", "Rut no es valido");
                }

            }
            else
            {
                await this.ShowMessageAsync("Información", "Todos los formularios deben tener un valor");
            }

            //string xmll = servicio.LeerTodosEmpleados();
            //List<Empleado> le = Util.Deserializar<List<Empleado>>(xmll);
            //gd_Empleados.ItemsSource = le;
        }

        //Cambio el combo de comunas en relacion a la ciudad seleccionada
        private void cbo_Ciudad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int valor = int.Parse(cbo_Ciudad.SelectedValue.ToString());

            string xml = servicio.LeerTodasComunasById(valor.ToString());

            List<Comuna> comuna = Util.Deserializar<List<Comuna>>(xml);

            cbo_Comuna.ItemsSource = comuna;
            cbo_Comuna.SelectedValuePath = "Id";

        }

        //Actualiza un empleado
        protected async void btnActualizar_Click(object sender, EventArgs e)
        {
            Empleado emp = new Empleado();
            emp.Rut = txt_Rut.Text;

            LSservicio.ServicioLSClient servicio = new LSservicio.ServicioLSClient();

            if (servicio.LeerEmpleado(emp.Serializar()) != null)
            {
                emp.Nombre = txt_Nombre.Text;
                emp.ApellidoPaterno = txt_ApellidoP.Text;
                emp.ApellidoMaterno = txt_ApellidoM.Text;
                emp.Direccion = txt_Direccion.Text;
                emp.IdComuna = decimal.Parse(cbo_Comuna.SelectedValue.ToString());
                emp.IdCargo = int.Parse(cbo_Cargo.SelectedValue.ToString());


                try
                {
                    if (servicio.ActualizarEmpleado(emp.Serializar()))
                    {
                        await this.ShowMessageAsync("Información", "Empleado actualizado exitosamente");
                    }
                    else
                    {
                        await this.ShowMessageAsync("Información", "Empleado no pudo ser actualizado");
                    }
                }
                catch (Exception)
                {
                    await this.ShowMessageAsync("Información", "Empleado no pudo ser actualizado");
                }
            }
            else
            {
                await this.ShowMessageAsync("Información", "El Empleado no existe");
            }

            //gd_Empleados.ItemsSource = servicio.LeerTodosEmpleados();
        }

        //Elimina un empleado
        protected async void btnEliminar_Click(object sender, EventArgs e)
        {
            Empleado emp = new Empleado();
            emp.Rut = txt_Rut.Text;

            LSservicio.ServicioLSClient servicio = new LSservicio.ServicioLSClient();

            //if (bib.Read())
            string xml = servicio.LeerEmpleado(emp.Serializar());
            if (xml != null)
            {
                emp = new Empleado(xml);
                xml = emp.Serializar();
                //if (bib.Delete())
                Usuario u = new Usuario();
                u.RutEmpleado = emp.Rut;
                string xml2 = u.Serializar();
                if (servicio.EliminarUsuarioPorRut(xml2))
                {
                    await this.ShowMessageAsync("Información", "Usuario Eliminado con Éxito");
                    if (emp.IdCargo.ToString() == "1")
                    {
                        Odontologo o = new Odontologo();
                        o.RutEmpleado = emp.Rut;
                        string xml3 = o.Serializar();
                        if (servicio.EliminarOdonPorRut(xml3))
                        {
                            await this.ShowMessageAsync("Información", "Odontologo eliminado exitosamente");
                        }else
                        {
                            await this.ShowMessageAsync("Información", "Odontologo NO eliminado");
                        }
                    }

                    if (servicio.EliminarEmpleado(xml))
                    {
                        await this.ShowMessageAsync("Información", "Empleado eliminado exitosamente");
                    }
                    else
                    {
                        await this.ShowMessageAsync("Información", "Empleado eliminado exitosamente");
                    }
                }
                else
                {
                    await this.ShowMessageAsync("Información", "Usuario NO Eliminado");
                }
            }
            else
            {
                await this.ShowMessageAsync("Información", "Empleado no existe");
            }

            //gd_Empleados.ItemsSource = servicio.LeerTodosEmpleados();
        }

        //Importa datos de un excel a la base de datos
        private async void btnImportar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                _excel = new Microsoft.Office.Interop.Excel.Application();
                work = _excel.Workbooks.Open(dialog.FileName);
                int Finicio, Ffin;
                Finicio = 1;

                Ffin = 3;
                int j = 1;

                Worksheet wh = (Worksheet)work.Sheets[1];
                for (int i = Finicio; i < Ffin; i++)
                {
                    Empleado p = new Empleado();
                    j = 1;
                    p.Rut = (((Range)wh.Cells[i, j]).Value2).ToString();
                    j++;
                    p.Nombre = (((Range)wh.Cells[i, j]).Value2).ToString();
                    j++;
                    p.ApellidoPaterno = (((Range)wh.Cells[i, j]).Value2).ToString();
                    j++;
                    p.ApellidoMaterno = (((Range)wh.Cells[i, j]).Value2).ToString();
                    j++;
                    p.IdComuna = int.Parse((((Range)wh.Cells[i, j]).Value2).ToString());
                    j++;
                    p.IdCargo = int.Parse((((Range)wh.Cells[i, j]).Value2).ToString());
                    j++;
                    p.Direccion = (((Range)wh.Cells[i, j]).Value2).ToString();

                    string xml = p.Serializar();
                    if (servicio.CrearEmpleado(xml))
                    {
                        await this.ShowMessageAsync("Información", "Empleado con rut: " + p.Rut + " insertado");
                    }
                    else
                    {
                        await this.ShowMessageAsync("Información", "Empleado con rut: " + p.Rut + " ya existe");
                    }
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

        private async void btnCrearUsuario_Click(object sender, RoutedEventArgs e)
        {
            Usuario u = new Usuario();
            u.RutEmpleado = Rut;
            string xml = u.Serializar();
            if (servicio.CrearUsuario(xml))
            {
                await this.ShowMessageAsync("Información", "Usuario Creado con Éxito");
                xml = servicio.LeerPorRut(xml);
                if (xml != null)
                {
                    u = new Usuario(xml);
                    txt_Usuario.Text = u.Nombre;
                    txt_Usuario.IsEnabled = false;
                }
            }

        }
    }
}

