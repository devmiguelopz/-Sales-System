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
    public class ClienteDAO
    {
        private static readonly ClienteDAO _instancia = new ClienteDAO();
        public static ClienteDAO Instancia
        {
            get { return ClienteDAO._instancia; }
        }
        public DataTable ListarClientes()
        {
            DataTable TablaDatos = new DataTable();
            SqlCommand Comando = null;
            try
            {
                Comando = new SqlCommand("ListarClientes", Conexion.ObtenerConexion());
                Comando.CommandType = CommandType.StoredProcedure;
                TablaDatos.Load(Comando.ExecuteReader());
            }
            catch (Exception ex)
            {
                TablaDatos = null;
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPersistencia.GetStringValue(), Convert.ToString(DateTime.Now)));
            }
            finally
            {
                Conexion.DisposarComando(Comando);
            }
            return TablaDatos;
        }
        public String RegistrarCliente(Cliente Cliente)
        {
            String TransaccionCliente = Transaccion.Correcta.GetStringValue();
            SqlCommand comando = null;
            try
            {
                comando = new SqlCommand("RegistrarActualizarCliente", Conexion.ObtenerConexion());
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                comando.Parameters.AddWithValue("@Idcliente", Cliente.IdCliente);
                comando.Parameters.AddWithValue("@DNI", Cliente.Dni);
                comando.Parameters.AddWithValue("@Apellidos", Cliente.Apellidos);
                comando.Parameters.AddWithValue("@Nombres", Cliente.Nombres);
                comando.Parameters.AddWithValue("@Direccion", Cliente.Direccion);
                comando.Parameters.AddWithValue("@Telefono", Cliente.Telefono);

                comando.ExecuteNonQuery();
                TransaccionCliente = Convert.ToString((comando.Parameters["@Mensaje"].Value));
            }
            catch (Exception ex)
            {
                TransaccionCliente = MensajeErrorCapas.ErrorPersistencia.GetStringValue();
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPersistencia.GetStringValue(), Convert.ToString(DateTime.Now)));
            }
            finally
            {
                Conexion.DisposarComando(comando);
            }
            return TransaccionCliente;
        }
    }
}
