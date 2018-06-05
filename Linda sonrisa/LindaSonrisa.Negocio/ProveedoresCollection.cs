using LindaSonrisa.Dalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindaSonrisa.Negocio
{
    public class ProveedoresCollection
    {
        public List<Proveedor> ObtenerProveedores()
        {
            return TodosProveedores(CommonBC.Modelo.PROVEEDOR.ToList());
        }



        private List<Proveedor> TodosProveedores(List<PROVEEDOR> lista)
        {
            List<Proveedor> listaP = new List<Proveedor>();
            foreach (Dalc.PROVEEDOR p in lista)
            {
                Proveedor pr = new Proveedor();
                pr.Correo = p.CORREO;
                pr.Nombre = p.NOMBRE;
                pr.Rubro = p.RUBRO;
                pr.Rut = p.RUT;
                pr.Telefono = p.TELEFONO;
                pr.Dv = p.DV;
                pr.IdComuna = p.ID_COMUNA;
                pr.Direccion = p.DIRECCION;
                pr.RutDv = pr.ObtenerRut();
                pr.NombreComuna = pr.ObtenerComuna();
                listaP.Add(pr);

            }

            return listaP;
        }

        public List<string> ObtenerRubros()
        {
            return TodosRubros(CommonBC.Modelo.PROVEEDOR.ToList());
        }

        private List<string> TodosRubros(List<PROVEEDOR> list)
        {
            List<string> rubros = new List<string>();
            foreach (Dalc.PROVEEDOR p in list)
            {
                bool esta = false;
                string rubro = p.RUBRO.ToString();
                foreach (var item in rubros)
                {
                    if (item == rubro)
                    {
                        esta = true;
                    }
                }

                if (!esta)
                {
                    rubros.Add(rubro);
                }


            }

            return rubros;
        }

        public List<Proveedor> FiltrarPorRubros(string dato)
        {
            return FiltrarPorRubros(CommonBC.Modelo.PROVEEDOR.Where(p => p.RUBRO == dato).ToList());
        }


        private List<Proveedor> FiltrarPorRubros(List<PROVEEDOR> list)
        {

            List<Proveedor> listaP = new List<Proveedor>();
            foreach (Dalc.PROVEEDOR p in list)
            {
                Proveedor pr = new Proveedor();
                pr.Correo = p.CORREO;
                pr.Nombre = p.NOMBRE;
                pr.Rubro = p.RUBRO;
                pr.Rut = p.RUT;
                pr.Telefono = p.TELEFONO;
                pr.Dv = p.DV;
                pr.IdComuna = p.ID_COMUNA;
                pr.Direccion = p.DIRECCION;
                pr.RutDv = pr.ObtenerRut();
                pr.NombreComuna = pr.ObtenerComuna();
                listaP.Add(pr);

            }

            return listaP;
        }

        public List<Proveedor> FiltrarPorProvincia(string dato)
        {
            Nullable<decimal> val = decimal.Parse(dato);
           return FiltrarPorProvincia(CommonBC.Modelo.PROVEEDOR
                   .Join(CommonBC.Modelo.COMUNA,
                      prov => prov.ID_COMUNA,
                      com => com.ID,
                      (prov, com) => new ProveedorProvincia { Rut = prov.RUT, Dv = prov.DV, Nombre = prov.NOMBRE, Rubro = prov.RUBRO, Telefono = prov.TELEFONO, Correo = prov.CORREO, Direccion = prov.DIRECCION, IdComuna = prov.ID_COMUNA, IdProvincia = com.ID_PROVINCIA, NombreComuna = com.NOMBRE_COMUNA, RutDv = prov.RUT+"-"+prov.DV }) // selection
                   .Where(provAndcom => provAndcom.IdProvincia == val).ToList<ProveedorProvincia>());
        }

        private List<Proveedor> FiltrarPorProvincia(List<ProveedorProvincia> lista)
        {
            List<Proveedor> proveedores = new List<Proveedor>();
            foreach (ProveedorProvincia i in lista)
            {
                Proveedor p = new Proveedor();
                p.Rut = i.Rut;
                p.Dv = i.Dv;
                p.Nombre = i.Nombre;
                p.Rubro = i.Rubro;
                p.Telefono = i.Telefono;
                p.Correo = i.Correo;
                p.Direccion = i.Direccion;
                p.IdComuna = (int)i.IdComuna;
                p.NombreComuna = i.NombreComuna;
                p.RutDv = i.RutDv;

                proveedores.Add(p);
            }
            return proveedores;
        }
    }
}
