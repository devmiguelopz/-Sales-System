using CapaDominio;
using CapaTransversal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPersistencia
{
    public class UsuarioDAO
    {
        private static readonly UsuarioDAO _instancia = new UsuarioDAO();
        public static UsuarioDAO Instancia
        {
            get { return UsuarioDAO._instancia; }
        }
        public String VerificarUsuario(Usuario Usuario)
        {
            String TransaccionUsuario = Transaccion.Correcta.GetStringValue();
            SqlCommand comando = null;
            try
            {
                comando = new SqlCommand("IniciarSesion", Conexion.ObtenerConexion());
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Usuario", Usuario.Usuarios);
                comando.Parameters.AddWithValue("@Contraseña", Usuario.Clave);
                comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                TransaccionUsuario = Convert.ToString((comando.Parameters["@Mensaje"].Value));
            }
            catch (Exception ex)
            {
                TransaccionUsuario = MensajeErrorCapas.ErrorPersistencia.GetStringValue();
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPersistencia.GetStringValue(), Convert.ToString(DateTime.Now)));
            }
            finally
            {
                Conexion.DisposarComando(comando);
            }
            return TransaccionUsuario;
        }
        public String RegistrarUsuario(Usuario Usuario)
        {
            String TransaccionUsuario= Transaccion.Correcta.GetStringValue();
            SqlCommand comando = null;
            try
            {
                comando = new SqlCommand("RegistrarUsuario", Conexion.ObtenerConexion());
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                comando.Parameters.AddWithValue("@IdEmpleado", Usuario.Empleado.IdEmpleado);
                comando.Parameters.AddWithValue("@Usuario", Usuario.Usuarios);
                comando.Parameters.AddWithValue("@Contraseña", Usuario.Clave);
                comando.ExecuteNonQuery();
                TransaccionUsuario = Convert.ToString((comando.Parameters["@Mensaje"].Value));
            }
            catch (Exception ex)
            {
                TransaccionUsuario = MensajeErrorCapas.ErrorPersistencia.GetStringValue();
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPersistencia.GetStringValue(), Convert.ToString(DateTime.Now)));
            }
            finally
            {
                Conexion.DisposarComando(comando);
            }
            return TransaccionUsuario;
        }
    }
}
