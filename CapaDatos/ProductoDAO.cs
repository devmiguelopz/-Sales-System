using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaTransversal;
using CapaDominio;
using System.Data.SqlClient;
using System.Data;

namespace CapaPersistencia
{
    public class ProductoDAO
    {
        private static readonly ProductoDAO _instancia = new ProductoDAO();
        public static ProductoDAO Instancia
        {
            get { return ProductoDAO._instancia; }
        }

        public String RegistrarProducto(Producto ProductoCompraVenta)
        {
            String TransaccionProducto = Transaccion.Correcta.GetStringValue();
            SqlCommand comando = null;
            try
            {
                comando = new SqlCommand("RegistrarActualizarProducto", Conexion.ObtenerConexion());
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                comando.Parameters.AddWithValue("@IdProducto", ProductoCompraVenta.IdP);
                comando.Parameters.AddWithValue("@IdCategoria", ProductoCompraVenta.IdCategoria);
                comando.Parameters.AddWithValue("@Nombre", ProductoCompraVenta.Productos);
                comando.Parameters.AddWithValue("@Marca", ProductoCompraVenta.Marca);
                comando.Parameters.AddWithValue("@Stock", ProductoCompraVenta.Stock);
                comando.Parameters.AddWithValue("@PrecioCompra", ProductoCompraVenta.PrecioCompra);
                comando.Parameters.AddWithValue("@PrecioVenta", ProductoCompraVenta.PrecioVenta);
                comando.Parameters.AddWithValue("@FechaVencimiento", ProductoCompraVenta.FechaVencimiento);
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
        public DataTable ListarProductos()
        {
            DataTable TablaDatos = new DataTable();
            SqlCommand Comando = null;
            try
            {
                Comando = new SqlCommand("ListadoProductos", Conexion.ObtenerConexion());
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
