using CapaDominio;
using CapaTransversal;
using CapaPersistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAplicacion
{
    public class ProductoAP
    {
        private static readonly ProductoAP _instancia = new ProductoAP();
        public static ProductoAP Instancia
        {
            get { return ProductoAP._instancia; }
        }
        public String RegistrarProducto(String MensajeValidacionProducto, Producto ProductoCompraVenta)
        {
            try
            {
                if (ManejadorErrores.Instancia.Error.Count == 0)
                {
                    if (MensajeValidacionProducto == ValidacionCampos.Correcta.GetStringValue())
                    {
                        return ProductoDAO.Instancia.RegistrarProducto(ProductoCompraVenta);
                    }
                    else 
                    {
                        return MensajeValidacionProducto;
                    }
                }
                else 
                {
                    return ManejadorErrores.Instancia.Error[0].MensajeCliente;
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorAplicacion.GetStringValue(),Convert.ToString(DateTime.Now)));
                return ManejadorErrores.Instancia.Error[0].MensajeCliente;
            }
        }
        public DataTable ListarProductos()
        {
            try
            {
                DataTable TablaDatos = new DataTable();
                TablaDatos = ProductoDAO.Instancia.ListarProductos();
                return TablaDatos;

            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorAplicacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                return null;
            }
        }

    }
}
