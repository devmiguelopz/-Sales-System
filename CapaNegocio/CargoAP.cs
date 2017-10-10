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
    public class CargoAP
    {
        private static readonly CargoAP _instancia = new CargoAP();
        public static CargoAP Instancia
        {
            get { return CargoAP._instancia; }
        }
        public String RegistrarCargo(String MensajeValidacionCargo, Cargo Cargo)
        {
            try
            {
                if (ManejadorErrores.Instancia.Error.Count == 0)
                {
                    if (MensajeValidacionCargo == ValidacionCampos.Correcta.GetStringValue())
                    {
                        return CargoDAO.Instancia.RegistrarCargo(Cargo);
                    }
                    else
                    {
                        return MensajeValidacionCargo;
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
        public DataTable ListarCargos()
        {
            try
            {
                DataTable TablaDatos = new DataTable();
                TablaDatos = CargoDAO.Instancia.ListarCargos();
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
