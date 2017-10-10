using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class Cargo
    {
            private static readonly Cargo _instancia = new Cargo();
            public static Cargo Instancia
            {
                    get { return Cargo._instancia; }
            }
            public Int32 IdCargo { get; set; }
            public String Descripcion { get; set; }
    }
}
