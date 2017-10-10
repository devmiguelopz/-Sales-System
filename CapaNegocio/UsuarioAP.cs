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
    public class UsuarioAP
    {
        private static readonly UsuarioAP _instancia = new UsuarioAP();
        public static UsuarioAP Instancia
        {
            get { return UsuarioAP._instancia; }
        }
        public String VerificarUsuario(String MensajeValidaUsuario, Usuario Usuario)
        {
            try
            {
                if (ManejadorErrores.Instancia.Error.Count == 0)
                {
                    if (MensajeValidaUsuario == ValidacionCampos.Correcta.GetStringValue())
                    {
                        String[] VerificarUsuario;
                        VerificarUsuario = UsuarioDAO.Instancia.VerificarUsuario(Usuario).Split('/');
                        if (VerificarUsuario[0] == MensajeValidacionUsuario.ClaveCampoVacio.GetStringValue() || VerificarUsuario[0] == MensajeValidacionUsuario.UsuarioCampoVacio.GetStringValue())
                        {
                            return VerificarUsuario[0];
                        }
                        else
                        {
                            Usuario.Instancia.Empleado.IdEmpleado = Convert.ToInt32(VerificarUsuario[2]);
                            Usuario.Instancia.Empleado.Nombres = VerificarUsuario[1];
                            return VerificarUsuario[0];
                        }
                    }
                    else
                    {
                        return MensajeValidaUsuario;
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
        public String RegistrarUsuario(String MensajeValidacionUsuario, Usuario Usuario)
        {
            try
            {
                if (ManejadorErrores.Instancia.Error.Count == 0)
                {
                    if (MensajeValidacionUsuario == ValidacionCampos.Correcta.GetStringValue())
                    {
                        return UsuarioDAO.Instancia.RegistrarUsuario(Usuario);
                    }
                    else
                    {
                        return MensajeValidacionUsuario;
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
