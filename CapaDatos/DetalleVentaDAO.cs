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
    public class DetalleVentaDAO
    {
        private static readonly DetalleVentaDAO _instancia = new DetalleVentaDAO();
        public static DetalleVentaDAO Instancia
        {
            get { return DetalleVentaDAO._instancia; }
        }
        public String RegistrarVentaGeneral(DetalleVenta DetalleVenta)
        {
            String TransaccionVentaGeneral = Transaccion.Correcta.GetStringValue();
            SqlCommand comando = null;
            try
            {
                comando = new SqlCommand("RegistrarMasivoVenta", Conexion.ObtenerConexion());
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                comando.Parameters.AddWithValue("@IdEmpleado", DetalleVenta.venta.Empleado.IdEmpleado);
                comando.Parameters.AddWithValue("@IdCliente", DetalleVenta.venta.Cliente.IdCliente);
                comando.Parameters.AddWithValue("@Serie", DetalleVenta.venta.Serie);
                comando.Parameters.AddWithValue("@NroDocumento", DetalleVenta.venta.NroComprobante);
                comando.Parameters.AddWithValue("@TipoDocumento", DetalleVenta.venta.TipoDocumento);
                comando.Parameters.AddWithValue("@FechaVenta", DetalleVenta.venta.FechaVenta);
                comando.Parameters.AddWithValue("@Total", DetalleVenta.venta.Total);
                comando.Parameters.Add(new SqlParameter { ParameterName = "@TABLA_TIPO_DETALLEVENTA", Value = DetalleVenta.ListaDetalleVenta, SqlDbType = SqlDbType.Structured, TypeName = "dbo.TipoDetalleVenta" });
                comando.ExecuteNonQuery();
                TransaccionVentaGeneral = Convert.ToString((comando.Parameters["@Mensaje"].Value));
            }
            catch (Exception ex)
            {
                TransaccionVentaGeneral = MensajeErrorCapas.ErrorPersistencia.GetStringValue();
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPersistencia.GetStringValue(), Convert.ToString(DateTime.Now)));
            }
            finally
            {
                Conexion.DisposarComando(comando);
            }
            return TransaccionVentaGeneral;
        }
    }
}
