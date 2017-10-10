using CapaTransversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class Empleado
    {
        private static readonly Empleado _instancia = new Empleado();
        public static Empleado Instancia
        {
            get { return Empleado._instancia; }
        }
        public int IdEmpleado { get; set; }
        public String Dni { get; set; }
        public String Apellidos { get; set; }
        public String Nombres { get; set; }
        public Char Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public String Direccion { get; set; }
        public Char EstadoCivil { get; set; }
        public Cargo cargo;
        public Cargo Cargo
        {
            get
            {
                if (cargo == null)
                {
                    cargo = new Cargo();
                } return cargo;
            }
            set
            {
                cargo = value;
            }
        }
        public String ValidarCampos(Empleado Empleado)
        {
            String Mensaje = ValidacionCampos.Correcta.GetStringValue();
            try
            {
                if (!Regex.IsMatch(Empleado.Dni, @"[0-9]{1,9}(\.[0-9]{0,2})?$"))
                {
                    return MensajeValidacionEmpleado.CampoIncorrectoLetrasDNI.GetStringValue();
                }
                if (Empleado.Dni.Length != (Int32)CompoCorrectoCliente.CampoCorrectoDNI)
                {
                    return MensajeValidacionEmpleado.CampoIncorrectoDNI.GetStringValue();
                }
                if (!Regex.IsMatch(Empleado.Apellidos, @"^[a-zA-ZñÑáéíóúÁÉÍÓÚ ]*$"))
                {
                    return MensajeValidacionEmpleado.CampoIncorrectoNumerosApellido.GetStringValue();
                }
                if (!Regex.IsMatch(Empleado.Nombres, @"^[a-zA-ZñÑáéíóúÁÉÍÓÚ ]*$"))
                {
                    return MensajeValidacionEmpleado.CampoIncorrectoNumerosNombre.GetStringValue();
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
