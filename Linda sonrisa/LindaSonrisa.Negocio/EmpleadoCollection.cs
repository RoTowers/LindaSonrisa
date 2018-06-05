/// <history> 
///     [Victor Loyola] 23/05/2018 Modificado
/// </history> 
/// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LindaSonrisa.Dalc;

namespace LindaSonrisa.Negocio
{
    public class EmpleadoCollection
    {
        public List<Empleado> Read()
        {
            return ReadAll(CommonBC.Modelo.EMPLEADO.ToList());
        }

        public List<Empleado> ReadAllByNombre(string nombre)
        {
            return ReadAll(CommonBC.Modelo.EMPLEADO.Where(x => x.NOMBRE == nombre).ToList<Dalc.EMPLEADO>());
        }

        public List<Empleado> ReadAllByApellidoP(string apellidoP)
        {
            return ReadAll(CommonBC.Modelo.EMPLEADO.Where(x => x.APELLIDO_P == apellidoP).ToList<Dalc.EMPLEADO>());
        }

        public List<Empleado> ReadAllByApellidoM(string apellidoM)
        {
            return ReadAll(CommonBC.Modelo.EMPLEADO.Where(x => x.APELLIDO_M == apellidoM).ToList<Dalc.EMPLEADO>());
        }

        public List<Empleado> ReadAllByDireccion(string direccion)
        {
            return ReadAll(CommonBC.Modelo.EMPLEADO.Where(x => x.DIRECCION == direccion).ToList<Dalc.EMPLEADO>());
        }

        public List<Empleado> ReadAllByCargo(int cargo)
        {
            return ReadAll(CommonBC.Modelo.EMPLEADO.Where(x => x.ID_CARGO == cargo).ToList<Dalc.EMPLEADO>());
        }

        public List<Empleado> ReadAllByComuna(int comuna)
        {
            return ReadAll(CommonBC.Modelo.EMPLEADO.Where(x => x.ID_COMUNA == comuna).ToList<Dalc.EMPLEADO>());
        }

        private List<Empleado> ReadAll(List<EMPLEADO> lista)
        {
            List<Empleado> listaE = new List<Empleado>();
            foreach (Dalc.EMPLEADO p in lista)
            {
                Empleado e = new Empleado();
                e.Rut = p.RUT;
                e.Nombre = p.NOMBRE;
                e.ApellidoPaterno = p.APELLIDO_P;
                e.ApellidoMaterno = p.APELLIDO_M;
                e.IdComuna = p.ID_COMUNA;
                e.IdCargo = p.ID_CARGO;
                e.Direccion = p.DIRECCION;

                listaE.Add(e);
            }
            return listaE;
        }
    }
}
