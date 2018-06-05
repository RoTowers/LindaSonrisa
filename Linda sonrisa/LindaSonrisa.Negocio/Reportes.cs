using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LindaSonrisa.Negocio
{
    public class Reportes
    {
        public List<ReportesCSP> ComunasConMasClientes()
        {
            //var cont = from a in CommonBC.Modelo.CLIENTE
            //             join b in CommonBC.Modelo.COMUNA
            //             on a.ID_COMUNA equals b.ID
            //             group b by b.NOMBRE_COMUNA into comunaGrupo
            //             select comunaGrupo.Count();
            //var max = cont.Max();

            //var cont2 = from a in CommonBC.Modelo.CLIENTE
            //           join b in CommonBC.Modelo.COMUNA
            //           on a.ID_COMUNA equals b.ID
            //            group b by b.NOMBRE_COMUNA into comunaGrupo
            //            where comunaGrupo.Count() == max
            //            select b.NOMBRE_COMUNA;


            //return cont2;
            //var nombre = new System.Data.Objects.ObjectParameter("nombre", typeof(String));
            //var cant = new System.Data.Objects.ObjectParameter("cantidad", OracleDbType.RefCursor);
            //CommonBC.Modelo.COMUNA_CLIENTES(nombre, cant);
            //Console.WriteLine(nombre.Value + " " + cant.Value);
            //Oracle.ManagedDataAccess.Client.OracleParameter dependents_c = new Oracle.ManagedDataAccess.Client.OracleParameter();
            //dependents_c.OracleDbType = OracleDbType.RefCursor;
            //dependents_c.Direction = ParameterDirection.Output;

            //CommonBC.Modelo.SERVICIO_MAS_SOLICITADO();


            //var maximo = from b in CommonBC.Modelo.COMUNA
            //             select b.NOMBRE_COMUNA;
            //return maximo.ToList();

            //var max = from a in CommonBC.Modelo.CLIENTE
            //          group a.ID_COMUNA by a.ID_COMUNA into g
            //          select g.Count().Max();


            //Devuelve el maximo de clientes por comuna
            var max = CommonBC.Modelo.CLIENTE.GroupBy(x => x.ID_COMUNA)
                      .Select(x => x.Count()).Max();

            //Devuelve el nombre de la comuna y la cantidad de clientes, de la comuna con mas clientes
            var commonData = from a in CommonBC.Modelo.CLIENTE
                             join b in CommonBC.Modelo.COMUNA on
                             a.ID_COMUNA
                             equals
                             b.ID
                             group b.NOMBRE_COMUNA by b.NOMBRE_COMUNA into g
                             where g.Count() == max
                             select new ReportesCSP{Nombre = g.Key, Cantidad = g.Count()};
            return commonData.ToList();
        }

        public List<ReportesCSP> ServicioMasSolicitado()
        {
            //devuelve la cantidad maxima de servicios pedidos agrupados por servicio
            var max = CommonBC.Modelo.DETALLE.GroupBy(x => x.ID_SERVICIO)
                      .Select(x => x.Count()).Max();

            //Devuelve el nombre de la comuna y la cantidad de clientes, de la comuna con mas clientes
            var commonData = from a in CommonBC.Modelo.DETALLE
                             join b in CommonBC.Modelo.SERVICIO on
                             a.ID_SERVICIO
                             equals
                             b.ID_SERVICIO
                             group b by b.NOMBRE_SERVICIO into g
                             where g.Count() == max
                             select new ReportesCSP { Nombre = g.Key, Cantidad = g.Count(), ID = g.FirstOrDefault().ID_SERVICIO.ToString()};
            return commonData.ToList();
        }

        public List<ReportesCSP> ReportePoducto()
        {
            
            List<ReportesCSP> rp = ServicioMasSolicitado();
            List<ReportesCSP> rp2 = new List<ReportesCSP>();
            List<ReportesCSP> rp3 = new List<ReportesCSP>();
            //Se revisará los productos por servicio y en iteraciones en caso de haber mas de un servicio como el mas solicitado
            foreach (var i in rp)
            {
                var commonData = from a in CommonBC.Modelo.SERVICIO_PRODUCTO
                                 join b in CommonBC.Modelo.PRODUCTO on
                                 a.PRODUCTO_ID
                                 equals
                                 b.ID
                                 where a.ID_SERVICIO == int.Parse(i.ID)
                                 select new ReportesCSP { Nombre = b.NOMBRE, ID = b.ID };
                rp3 = commonData.ToList();
                //Codigo que verificará que no se repitan los productos
                for (int j = 0; j < rp3.Count; j++)
                {
                    if (!rp2.Exists(x => x.ID == rp3[j].ID))
                    {
                        rp2.Add(rp3[j]);
                    }
                }
            }
            return rp2;
        }
    }
}
