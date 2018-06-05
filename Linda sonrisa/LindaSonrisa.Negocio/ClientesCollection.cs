using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindaSonrisa.Negocio
{
    public class ClientesCollection
    {

        public List<Cliente> getAllByRutPasaporte(string val)
        {
            return getAll(CommonBC.Modelo.CLIENTE.Where(x => x.RUT_PASAPORTE == val).ToList<Dalc.CLIENTE>());
        }

        private List<Cliente> getAll(List<Dalc.CLIENTE> lista)
        {
            List<Cliente> clientes = new List<Cliente>();
            foreach (var i in lista)
            {
                Cliente p = new Cliente();
                p.RutPasaporte = i.RUT_PASAPORTE;
                p.Nombre = i.NOMBRE;
                p.ApellidoPaterno = i.APELLIDO_P;
                p.ApellidoMaterno = i.APELLIDO_M;
                p.Direccion = i.DIRECCION;
                p.Dv = i.DV;
                p.IdComuna = i.ID_COMUNA;
                p.RP = i.R_P;


                clientes.Add(p);
            }
            return clientes;
        }

        public List<Cliente> getAll()
        {
            return getAll(CommonBC.Modelo.CLIENTE.ToList<Dalc.CLIENTE>());
        }


    }
}
