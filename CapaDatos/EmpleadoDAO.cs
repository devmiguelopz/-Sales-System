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
    public class EmpleadoDAO
    {
        private static readonly EmpleadoDAO _instancia = new EmpleadoDAO();
        public static EmpleadoDAO Instancia
        {
            get { return EmpleadoDAO._instancia; }
        }
        public String RegistrarEmpleado(Empleado Empleado)
        {
            String TransaccionEmpleado = Transaccion.Correcta.GetStringValue();
            SqlCommand comando = null;
            try
            {
                comando = new SqlCommand("MantenimientoEmpleados", Conexion.ObtenerConexion());
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                comando.Parameters.AddWithValue("@IdEmpleado", Empleado.IdEmpleado);
                comando.Parameters.AddWithValue("@IdCargo", Empleado.Cargo.IdCargo);
                comando.Parameters.AddWithValue("@Dni", Empleado.Dni);
                comando.Parameters.AddWithValue("@Apellidos", Empleado.Apellidos);
                comando.Parameters.AddWithValue("@Nombres", Empleado.Nombres);
                comando.Parameters.AddWithValue("@Sexo", Empleado.Sexo);
                comando.Parameters.AddWithValue("@FechaNac", Empleado.FechaNacimiento);
                comando.Parameters.AddWithValue("@Direccion", Empleado.Direccion);
                comando.Parameters.AddWithValue("@EstadoCivil", Empleado.EstadoCivil);
                comando.ExecuteNonQuery();
                TransaccionEmpleado = Convert.ToString((comando.Parameters["@Mensaje"].Value));
            }
            catch (Exception ex)
            {
                TransaccionEmpleado = MensajeErrorCapas.ErrorPersistencia.GetStringValue();
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPersistencia.GetStringValue(), Convert.ToString(DateTime.Now)));
            }
            finally
            {
                Conexion.DisposarComando(comando);
            }
            return TransaccionEmpleado;
        }
        public DataTable ListarEmpleados()
        {
            DataTable TablaDatos = new DataTable();
            SqlCommand comando = null;
            try
            {
                comando = new SqlCommand("ListadoEmpleados", Conexion.ObtenerConexion());
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
        public DataTable InformacionEmpleado(Int32 Id)
        {
            DataTable TablaDatos = new DataTable();
            SqlCommand comando = null;
            try
            {
                comando = new SqlCommand("ListaInformacionEmpleados", Conexion.ObtenerConexion());
                comando.Parameters.AddWithValue("@IdEmpleado", Id);
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
        public DataTable ListarEmpleadosTotal()
        {
            DataTable TablaDatos = new DataTable();
            SqlCommand Comando = null;
            try
            {
                Comando = new SqlCommand("ListadoEmpleados", Conexion.ObtenerConexion());
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
