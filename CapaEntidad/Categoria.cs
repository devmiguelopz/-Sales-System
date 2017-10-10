using CapaTransversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class Categoria
    {
            private static readonly Categoria _instancia = new Categoria();
            public static Categoria Instancia
            {
                get { return Categoria._instancia; }
            }
            public Int32 IdC { get; set; }
            public Int32 IdCategoria { get; set; }
            public String Descripcion { get; set; }
            public Boolean ValidarCategoriaId(ref ManejadorErrores ManejoErrores, String IdCategoria) 
            {
                try
                {
                    if (String.IsNullOrEmpty(IdCategoria)) 
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {

                    ManejoErrores.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorDominio.GetStringValue(),Convert.ToString(DateTime.Now)));
                    return false;
                }
            }
            public Int32 ValidacionCategoriaId(ref ManejadorErrores ManejoErrores, String CategoriaId)
            {
                try
                {
                    if (String.IsNullOrEmpty(CategoriaId))
                    {
                        return Convert.ToInt32(0);
                    }

                }
                catch (Exception ex)
                {
                    ManejoErrores.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorDominio.GetStringValue(), Convert.ToString(DateTime.Now)));

                }
                return Convert.ToInt32(CategoriaId);
            }
            public String ValidacionCategoria(ref ManejadorErrores ManejoErrores, Categoria CategoriaProducto)
            {
                String Mensaje = ValidacionCampos.Correcta.GetStringValue();
                try
                {
                    if (String.IsNullOrEmpty(CategoriaProducto.Descripcion))
                    {
                        return MensajeValidacionCategoria.CampoVacioDescripcionCategoria.GetStringValue();
                    }
                }
                catch (Exception ex)
                {
                    ManejoErrores.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorDominio.GetStringValue(), Convert.ToString(DateTime.Now)));
                    Mensaje = ValidacionCampos.Incorrecta.GetStringValue();

                }
                return Mensaje;

            }
    }
}
