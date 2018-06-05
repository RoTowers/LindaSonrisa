using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LindaSonrisa.Negocio;

namespace Prueba
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Hola");
            //Usuario u = new Usuario();
            //u.Nombre = "a.torresm";
            //u.Perfil = "Empleado";
            //u.Contrasena = "1234";
            //u.RutEmpleado = "19546823";
            ////u.RutPasaporteCliente = "19546843";
            ////u.RutProveedor = null;
            //if (u.Create())
            //{
            //    Console.WriteLine("Usuario Creado");
            //}
            //else
            //{
            //    Console.WriteLine("Usuario NO Creado");
            //}


            Reportes r = new Reportes();

            List<ReportesCSP> c = r.ComunasConMasClientes();

            Console.WriteLine("Comunas con mas solicitados: ");
            foreach (var i in c)
            {
                Console.WriteLine(i.Nombre + " " + i.Cantidad);
            }
            //List<ReportesCSP> a = r.ServicioMasSolicitado();
            //List<ReportesCSP> b = r.ReportePoducto();
            //Console.WriteLine("Servicios mas solicitados: ");
            //foreach (var i in a)
            //{
            //    Console.WriteLine(i.Nombre+" "+i.Cantidad+" "+i.ID);
            //}
            //Console.WriteLine();
            //Console.WriteLine("Productos mas ocupados: ");
            //foreach (var i in b)
            //{
            //    Console.WriteLine(i.Nombre +" "+ i.ID);
            //}

            Console.ReadKey();
        }
    }
}
