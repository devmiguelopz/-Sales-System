using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class Usuario
    {
            private static readonly Usuario _instancia = new Usuario();
            public static Usuario Instancia
            {
                get { return Usuario._instancia; }
            }
            public string Usuarios { get; set; }
            public string Clave { get; set; }
            public Empleado empleado;
            public Empleado Empleado
            {
                get
                {
                    if (empleado == null)
                    {
                        empleado = new Empleado();
                    } return empleado;
                }
                set
                {
                    empleado = value;
                }
            }
    }
}
