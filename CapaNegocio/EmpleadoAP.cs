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
    public class EmpleadoAP
    {
        private static readonly EmpleadoAP _instancia = new EmpleadoAP();
        public static EmpleadoAP Instancia
        {
            get { return EmpleadoAP._instancia; }
        }
        public String RegistrarEmpleado(String MensajeValidacionEmpleado, Empleado Empleado)
        {
            try
            {
                if (ManejadorErrores.Instancia.Error.Count == 0)
                {
                    if (MensajeValidacionEmpleado == ValidacionCampos.Correcta.GetStringValue())
                    {
                        MensajeValidacionEmpleado = Empleado.Instancia.ValidarCampos(Empleado);
                        if (MensajeValidacionEmpleado == ValidacionCampos.Correcta.GetStringValue())
                        {
                            return EmpleadoDAO.Instancia.RegistrarEmpleado(Empleado);
                        }
                        else
                        {
                            return MensajeValidacionEmpleado;
                        }
                    }
                    else
                    {
                        return MensajeValidacionEmpleado;
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
        public DataTable ListarEmpleados()
        {
            try
            {
                DataTable TablaDatos = new DataTable();
                TablaDatos = EmpleadoDAO.Instancia.ListarEmpleados();
                return TablaDatos;

            }
            catch (Exception ex)
            {

                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorAplicacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                return null;
            }
        }
        public DataTable InformacionEmpleado(Int32 Id)
        {
            try
            {
                DataTable TablaDatos = new DataTable();
                TablaDatos = EmpleadoDAO.Instancia.InformacionEmpleado(Id);
                return TablaDatos;

            }
            catch (Exception ex)
            {

                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorAplicacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                return null;
            }
        }
        public DataTable ListarEmpleadosTotal()
        {
            try
            {
                DataTable TablaDatos = new DataTable();
                TablaDatos = EmpleadoDAO.Instancia.ListarEmpleadosTotal();
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
