using CapaTransversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class Cliente
    {
        private static readonly Cliente _instancia = new Cliente();
        public static Cliente Instancia
        {
            get { return Cliente._instancia; }
        }
        public Int32 IdCliente { get; set; }
        public String Dni { get; set; }
        public String Apellidos { get; set; }
        public String Nombres { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public String ValidarCampos(Cliente Cliente) 
        {
            String Mensaje = ValidacionCampos.Correcta.GetStringValue();
            try
            {
                if (!Regex.IsMatch(Cliente.Dni, @"[0-9]{1,9}(\.[0-9]{0,2})?$"))
                {
                    return MensajeValidacionCliente.CampoIncorrectoLetrasDNI.GetStringValue();
                }
                if (Cliente.Dni.Length != (Int32)CompoCorrectoCliente.CampoCorrectoDNI)
                {
                    return MensajeValidacionCliente.CampoIncorrectoDNI.GetStringValue();
                }
                if (!Regex.IsMatch(Cliente.Apellidos, @"^[a-zA-ZñÑáéíóúÁÉÍÓÚ ]*$"))
                {
                    return MensajeValidacionCliente.CampoIncorrectoNumerosApellido.GetStringValue();
                }
                if (!Regex.IsMatch(Cliente.Nombres, @"^[a-zA-ZñÑáéíóúÁÉÍÓÚ ]*$"))
                {
                    return MensajeValidacionCliente.CampoIncorrectoNumerosNombre.GetStringValue();
                }
                return Mensaje;
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorDominio.GetStringValue(), Convert.ToString(DateTime.Now)));
                return ManejadorErrores.Instancia.Error[0].MensajeCliente;
            }
        }
    }
}
