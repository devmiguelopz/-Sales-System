using CapaTransversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class Producto
    {
            private static readonly Producto _instancia = new Producto();
            public static Producto Instancia
            {
                get { return Producto._instancia; }
            }
            public Int32 IdP { get; set; }
            public Int32 IdCategoria { get; set; }
            public String Productos { get; set; }
            public String Descripcion { get; set; }
            public String Marca { get; set; }
            public Int32 Stock { get; set; }
            public Decimal PrecioCompra { get; set; }
            public Decimal PrecioVenta { get; set; }
            public DateTime FechaVencimiento { get; set; }
    }
}
