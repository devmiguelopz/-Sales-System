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
    public class VentaDAO
    {
        private static readonly VentaDAO _instancia = new VentaDAO();
        public static VentaDAO Instancia
        {
            get { return VentaDAO._instancia; }
        }
        public String NumeroComprobante(String Comprobante)
        {
            String TransaccionVenta = Transaccion.Correcta.GetStringValue();
            SqlCommand comando = null;
            try
            {
                comando = new SqlCommand("[Numero Correlativo]", Conexion.ObtenerConexion());
                comando.CommandType =CommandType.StoredProcedure;
                comando.Parameters.Add("@NroCorrelativo", SqlDbType.VarChar, 7).Direction = ParameterDirection.Output;
                comando.Parameters.AddWithValue("@TipoDocumento", Comprobante);
                comando.ExecuteNonQuery();
                TransaccionVenta = Convert.ToString((comando.Parameters["@NroCorrelativo"].Value));
            }
            catch (Exception ex)
            {
                TransaccionVenta = MensajeErrorCapas.ErrorPersistencia.GetStringValue();
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPersistencia.GetStringValue(), Convert.ToString(DateTime.Now)));
            }
            finally
            {
                Conexion.DisposarComando(comando);
            }
            return TransaccionVenta;
        }
        public String GenerarIdVenta()
        {
            String TransaccionVenta = Transaccion.Correcta.GetStringValue();
            SqlCommand comando = null;
            try
            {
                comando = new SqlCommand("GenerarIdVenta", Conexion.ObtenerConexion());
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@IdVenta", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                TransaccionVenta = Convert.ToString((comando.Parameters["@IdVenta"].Value));
            }
            catch (Exception ex)
            {
                TransaccionVenta = MensajeErrorCapas.ErrorPersistencia.GetStringValue();
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPersistencia.GetStringValue(), Convert.ToString(DateTime.Now)));
            }
            finally
            {
                Conexion.DisposarComando(comando);
            }
            return TransaccionVenta;
        }
        public String GenerarSerieDocumento()
        {
            String TransaccionVenta = Transaccion.Correcta.GetStringValue();
            SqlCommand comando = null;
            try
            {
                comando = new SqlCommand("[Serie Documento]", Conexion.ObtenerConexion());
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@Serie", SqlDbType.VarChar, 7).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                TransaccionVenta = Convert.ToString((comando.Parameters["@Serie"].Value));
            }
            catch (Exception ex)
            {
                TransaccionVenta = MensajeErrorCapas.ErrorPersistencia.GetStringValue();
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPersistencia.GetStringValue(), Convert.ToString(DateTime.Now)));
            }
            finally
            {
                Conexion.DisposarComando(comando);
            }
            return TransaccionVenta;
        }
    }
}
