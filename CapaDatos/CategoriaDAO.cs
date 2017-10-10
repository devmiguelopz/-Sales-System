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
    public class CategoriaDAO
    {
        private static readonly CategoriaDAO _instancia = new CategoriaDAO();
        public static CategoriaDAO Instancia
        {
            get { return CategoriaDAO._instancia; }
        }
        public DataTable ListarCategoria() 
        {
            DataTable TablaDatos = new DataTable();
            SqlCommand comando = null;
            try
            {
                comando = new SqlCommand("ListarCategoria", Conexion.ObtenerConexion());
                comando.CommandType = CommandType.StoredProcedure;
                TablaDatos.Load(comando.ExecuteReader());
            }
            catch (Exception ex)
            {
                TablaDatos = null;
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPersistencia.GetStringValue(), Convert.ToString(DateTime.Now)));
            }
            finally
            {
                Conexion.DisposarComando(comando);
            }
            return TablaDatos;
        }
        public String RegistrarCategoria(Categoria CategoriaProducto)
        {
            String TransaccionCategoria = Transaccion.Correcta.GetStringValue();
            SqlCommand comando = null;
            try
            {
                comando = new SqlCommand("RegistrarActualizarCategoria", Conexion.ObtenerConexion());
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                comando.Parameters.AddWithValue("@IdCategoria", CategoriaProducto.IdC);
                comando.Parameters.AddWithValue("@Descripcion", CategoriaProducto.Descripcion);
                comando.ExecuteNonQuery();
                TransaccionCategoria = Convert.ToString((comando.Parameters["@Mensaje"].Value));
            }
            catch (Exception ex)
            {
                TransaccionCategoria = MensajeErrorCapas.ErrorPersistencia.GetStringValue();
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPersistencia.GetStringValue(), Convert.ToString(DateTime.Now)));
            }
            finally
            {
                Conexion.DisposarComando(comando);
            }
            return TransaccionCategoria;
        }
    }
}
