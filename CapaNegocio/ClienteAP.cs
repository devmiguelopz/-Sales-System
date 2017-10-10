using CapaDominio;
using CapaPersistencia;
using CapaTransversal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAplicacion
{
    public class ClienteAP
    {
        private static readonly ClienteAP _instancia = new ClienteAP();
        public static ClienteAP Instancia
        {
            get { return ClienteAP._instancia; }
        }
        public DataTable ListarClientes()
        {
            try
            {
                DataTable TablaDatos = new DataTable();
                TablaDatos = ClienteDAO.Instancia.ListarClientes();
                return TablaDatos;

            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorAplicacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                return null;
            }
        }
        public String RegistrarCliente(String MensajeValidacionCliente, Cliente Cliente)
        {
            try
            {
                if (ManejadorErrores.Instancia.Error.Count == 0)
                {
                    if (MensajeValidacionCliente == ValidacionCampos.Correcta.GetStringValue())
                    {
                        MensajeValidacionCliente =  Cliente.Instancia.ValidarCampos(Cliente);
                        if (MensajeValidacionCliente == ValidacionCampos.Correcta.GetStringValue())
                        {
                            return ClienteDAO.Instancia.RegistrarCliente(Cliente);
                        }
                        else
                        {
                            return MensajeValidacionCliente;
                        }
                    }
                    else
                    {
                        return MensajeValidacionCliente;
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
    }

}
