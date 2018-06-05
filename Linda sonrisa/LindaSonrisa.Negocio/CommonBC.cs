/// <history> 
///     [Alexis Moya] 27/04/2018 Modificado
///     [Franco Retamal] 01/05/2018 Modificado
///     [Rodrigo Torres] 02/05/2018 Modificado
/// </history> 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LindaSonrisa.Dalc;

namespace LindaSonrisa.Negocio
{
  public  class CommonBC
    {
        private static LindaSonrisaEntities _modelo;

        //Propiedad que instancia LindaSonrisaEntities en Modelo
        public static LindaSonrisaEntities Modelo
        {
            get
            {
                if (_modelo == null)
                {
                    _modelo = new LindaSonrisaEntities();
                }
                return _modelo;
            }
        }
    }
}
