using CapaEntidad;
using CapaTransversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class DetalleVenta
    {
            private static readonly DetalleVenta _instancia = new DetalleVenta();
            public static DetalleVenta Instancia
            {
                get { return DetalleVenta._instancia; }
            }
            public Int32 IdDetalleVenta { get; set; }        
            public Producto producto;
            public Producto Producto 
            {
                get 
                    {
                        if (producto==null)
                        {
                            producto = new Producto(); 
                        }
                        return producto;
                    }
                set 
                    {
                        producto = value;
                    }
            }
            public Venta venta;
            public Venta Venta
            {
                get
                {
                    if (venta == null)
                    {
                        venta = new Venta();
                    }
                    return venta;
                }
                set
                {
                    venta = value;
                }
            }
            public Int32 Cantidad { get; set; }
            public Decimal PUnitario { get; set; }
            public Decimal Igv { get; set; }
            public Decimal SubTotal { get; set; }
            public String ValidacionRegistrarVenta(ref DetalleVenta DetalleVenta)
            {
                try
                {
                    if (String.IsNullOrEmpty(DetalleVenta.Venta.Cliente.Dni.Trim()))
                    {
                        return MensajeValidacionDetalleVenta.BusqueClienteVender.GetStringValue();
                    }
                    if (String.IsNullOrEmpty(DetalleVenta.Producto.Productos.Trim()))
                    {
                        return MensajeValidacionDetalleVenta.BusqueProductoVender.GetStringValue();
                    }
                    if (DetalleVenta.Cantidad<=0)
                    {
                        return MensajeValidacionDetalleVenta.IngreseCantidadVender.GetStringValue();
                    }
                    if (DetalleVenta.Producto.Stock<=DetalleVenta.Cantidad)
                    {
                        return MensajeValidacionDetalleVenta.StockInsuficiente.GetStringValue();
                    }
                    if (DetalleVenta.Igv<0)
                    {
                        return MensajeValidacionDetalleVenta.IngreseIGV.GetStringValue();
                    }
                    DetalleVenta.SubTotal = (Convert.ToDecimal(DetalleVenta.Producto.PrecioVenta) * Convert.ToInt32(DetalleVenta.Cantidad)) / ((Convert.ToDecimal(DetalleVenta.Igv) / 100) + 1);
                    DetalleVenta.Igv = Math.Round(Convert.ToDecimal(DetalleVenta.SubTotal) * (Convert.ToDecimal(DetalleVenta.Igv) / 100), 2);
                    DetalleVenta.SubTotal = Math.Round(DetalleVenta.SubTotal, 2);
                    DetalleVenta.Producto.Descripcion = DetalleVenta.Producto.Descripcion + Proyecto.EspaciadoEspacial.GetStringValue() + DetalleVenta.Producto.Marca;
                    return ValidacionCampos.Correcta.GetStringValue();
                }
                catch (Exception ex)
                {
                    ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                    return ValidacionCampos.Incorrecta.GetStringValue();
                }
            }
            public Int32 IdP { get; set; }
            public Int32 IdVenta { get; set; }
            public tBaseDetalleVenta ListaDetalleVenta { get; set; }
    }
}
