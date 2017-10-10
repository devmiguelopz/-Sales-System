using CapaDominio;
using CapaTransversal;
using CapaPersistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaAplicacion
{
    public class CategoriaAP
    {
        private static readonly CategoriaAP _instancia = new CategoriaAP();
        public static CategoriaAP Instancia
        {
            get { return CategoriaAP._instancia; }
        }
        public DataTable ListarCategoria() 
        {
            try 
	        {	        
		        DataTable TablaDatos = new DataTable();
                TablaDatos = CategoriaDAO.Instancia.ListarCategoria();
                return TablaDatos;
               
	        }
	        catch (Exception ex)
	        {

                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorAplicacion.GetStringValue(),Convert.ToString(DateTime.Now)));
                return null;
	        }
        }
        public String RegistrarCategoria(String MensajeValidacionCategoria, Categoria CategoriaProducto)
        {
            try
            {
                if (ManejadorErrores.Instancia.Error.Count == 0)
                {
                    if (MensajeValidacionCategoria == ValidacionCampos.Correcta.GetStringValue())
                    {
                        return CategoriaDAO.Instancia.RegistrarCategoria(CategoriaProducto);
                    }
                    else
                    {
                        return MensajeValidacionCategoria;
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
