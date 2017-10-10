using CapaDominio;
using CapaPersistencia;
using CapaTransversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAplicacion
{
    public class DetalleVentaAP
    {
        private static readonly DetalleVentaAP _instancia = new DetalleVentaAP();
        public static DetalleVentaAP Instancia
        {
            get { return DetalleVentaAP._instancia; }
        }
        public String ValidacionRegistrarVenta(ref DetalleVenta DetalleVenta)
        {
            try
            {
                if (ManejadorErrores.Instancia.Error.Count == 0)
                {
                    String MensajeValidacionRegistrarVenta = DetalleVenta.Instancia.ValidacionRegistrarVenta( ref DetalleVenta);
                    if (MensajeValidacionRegistrarVenta == ValidacionCampos.Correcta.GetStringValue())
                    {
                        return MensajeValidacionRegistrarVenta;
                    }
                    else
                    {
                        return MensajeValidacionRegistrarVenta;
                    }
                }
                else
                {
                    return ManejadorErrores.Instancia.Error[0].MensajeCliente;
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorAplicacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                return ManejadorErrores.Instancia.Error[0].MensajeCliente;
            }
        }
        public String RegistrarVentaGeneral(DetalleVenta DetalleVenta)
        {
            try
            {
                if (ManejadorErrores.Instancia.Error.Count == 0)
                {

                        return DetalleVentaDAO.Instancia.RegistrarVentaGeneral(DetalleVenta);
                }
                else
                {
                    return ManejadorErrores.Instancia.Error[0].MensajeCliente;
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorAplicacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                return ManejadorErrores.Instancia.Error[0].MensajeCliente;
            }
        }
    }
}
