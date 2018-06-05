using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LindaSonrisa.Dalc;

namespace LindaSonrisa.Negocio
{
    public class FamiliaProductoCollection
    {
        public List<FamiliaProducto> readAll()
        {
            return readAll(CommonBC.Modelo.FAMILIA_DE_PRODUCTOS.ToList<Dalc.FAMILIA_DE_PRODUCTOS>());
        }

        private List<FamiliaProducto> readAll(List<FAMILIA_DE_PRODUCTOS> listaFP)
        {
            List<FamiliaProducto> fpc = new List<FamiliaProducto>();
            foreach (var i in listaFP)
            {
                FamiliaProducto f = new FamiliaProducto();
                f.Id = int.Parse(i.ID.ToString());
                f.Nombre = i.NOMBRE;
                fpc.Add(f);
            }
            return fpc;
        }
    }
}
