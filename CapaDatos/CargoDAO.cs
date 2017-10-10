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
    public class CargoDAO
    {
        private static readonly CargoDAO _instancia = new CargoDAO();
        public static CargoDAO Instancia
        {
            get { return CargoDAO._instancia; }
        }
        public String RegistrarCargo(Cargo Cargo)
        {
            String TransaccionProducto = Transaccion.Correcta.GetStringValue();
            SqlCommand comando = null;
            try
            {
                comando = new SqlCommand("RegistrarActualizarCargo", Conexion.ObtenerConexion());
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                comando.Parameters.AddWithValue("@IdCargo", Cargo.IdCargo);
                comando.Parameters.AddWithValue("@Descripcion", Cargo.Descripcion);
                comando.ExecuteNonQuery();
                TransaccionProducto = Convert.ToString((comando.Parameters["@Mensaje"].Value));
            }
            catch (Exception ex)
            {
                TransaccionProducto = MensajeErrorCapas.ErrorPersistencia.GetStringValue();
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPersistencia.GetStringValue(), Convert.ToString(DateTime.Now)));
            }
            finally
            {
                Conexion.DisposarComando(comando);
            }
            return TransaccionProducto;
        }
        public DataTable ListarCargos()
        {
            DataTable TablaDatos = new DataTable();
            SqlCommand Comando = null;
            try
            {
                Comando = new SqlCommand("ListarCargo", Conexion.ObtenerConexion());
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
    }
}
