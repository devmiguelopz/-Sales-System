using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CapaPersistencia
{
    public class Conexion
    {

        public static void DisposarComando(SqlCommand comando)
        {
            try
            {
                if (comando != null)
                {
                    if (comando.Connection != null)
                    {
                        comando.Connection.Close();
                        comando.Connection.Dispose();
                    }
                    comando.Dispose();
                }
            }
            catch { } //don't blow up
        }
        public static SqlConnection ObtenerConexion()
        {
            String CadenaConexion = "";
            if (ConfigurationManager.ConnectionStrings["Proyecto"] != null)
            {
                CadenaConexion = ConfigurationManager.ConnectionStrings["Proyecto"].ConnectionString;
            }
            SqlConnection objConexion = new SqlConnection(CadenaConexion);
            objConexion.Open();
            return objConexion;
        }
    }
}
