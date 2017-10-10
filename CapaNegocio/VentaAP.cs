using CapaPersistencia;
using CapaTransversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAplicacion
{
    public class VentaAP
    {
        private static readonly VentaAP _instancia = new VentaAP();
        public static VentaAP Instancia
        {
            get { return VentaAP._instancia; }
        }
        public String NumeroComprobante(Boolean BoletaOFactura)
        {
            try
            {
                if (ManejadorErrores.Instancia.Error.Count == 0)
                {
                    if (BoletaOFactura == true)
                    {
                        return VentaDAO.Instancia.NumeroComprobante(Ventas.ComprobanteBoleta.GetStringValue());
                    }
                    else
                    {
                        return VentaDAO.Instancia.NumeroComprobante(Ventas.ComprobanteFactura.GetStringValue());
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
        public String GenerarIdVenta()
        {
            try
            {
                if (ManejadorErrores.Instancia.Error.Count == 0)
                {
                    return VentaDAO.Instancia.GenerarIdVenta();
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
        public String GenerarSerieDocumento()
        {
            try
            {
                if (ManejadorErrores.Instancia.Error.Count == 0)
                {
                    return VentaDAO.Instancia.GenerarSerieDocumento();
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
