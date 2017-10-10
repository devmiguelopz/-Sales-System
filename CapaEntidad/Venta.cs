using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class Venta
    {
            private static readonly Venta _instancia = new Venta();
            public static Venta Instancia
            {
                get { return Venta._instancia; }
            }
            public int IdVenta { get; set; }
            public string Serie { get; set; }
            public string NroComprobante { get; set; }
            public string TipoDocumento { get; set; }
            public DateTime FechaVenta { get; set; }
            public decimal Total { get; set; }
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
            public Cliente cliente;
            public Cliente Cliente
            {
                get
                {
                    if (cliente == null)
                    {
                        cliente = new Cliente();
                    } return cliente;
                }
                set
                {
                    cliente = value;
                }
            }
    }
}
