using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CapaTransversal
{
    public static class Enumerables
    {
        public static String GetStringValue(this Enum value)
        {
            string output = null;
            Type type = value.GetType();
            FieldInfo fi = type.GetField(value.ToString());
            StringValueAttribute[] attrs = fi.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
            if (attrs.Length > 0)
            {
                output = attrs[0].StringValue;
            }
            return output;
        }
    }
    public class StringValueAttribute : Attribute
    {
        public string StringValue { get; protected set; }
        public StringValueAttribute(string value)
        {
            this.StringValue = value;
        }
    }
    public enum ValidacionCampos
    {
        [StringValue("Validacion Correcta")]
        Correcta = 1,
        [StringValue("Validacion Incorrecta")]
        Incorrecta = 0
    }
    public enum MensajeErrorCapas
    {
        [StringValue("Error inesperado en la capa de Aplicacion. Revise el Logs de Error")]
        ErrorAplicacion = 1,
        [StringValue("Error inesperado en la capa de Persistencia. Revise el Logs de Error")]
        ErrorPersistencia = 2,
        [StringValue("Error inesperado en la capa de Dominio. Revise el Logs de Error")]
        ErrorDominio = 3,
        [StringValue("Error inesperado en la capa de Presentación. Revise el Logs de Error")]
        ErrorPresentacion = 4,
        [StringValue("Error inesperado en la capa de Transversal. Revise el Logs de Error")]
        ErrorTransversal = 5
    }
    public enum MensajeValidacionProducto
    {
        [StringValue("0")]
        ValorPorDefecto = 0,
        [StringValue("Por Favor Ingrese Nombre del Producto.")]
        CampoVacioNombreProducto = 1,
        [StringValue("Por Favor Ingrese Marca del Producto.")]
        CampoVacioMarcaProducto = 2,
        [StringValue("Por Favor Ingrese Precio de Compra del Producto.")]
        CampoVacioPrecioCompraProducto = 3,
        [StringValue("Por Favor Ingrese Precio de Venta del Producto")]
        CampoVacioPrecioVentaProducto = 4,
        [StringValue("Por Favor Ingrese Stock del Producto.")]
        CampoVacioStockProducto = 5
    }
    public enum MensajeValidacionDetalleVenta
    {
        [StringValue("0")]
        ValorPorDefecto = 0,
        [StringValue("Por Favor Ingrese I.G.V.")]
        IngreseIGV = 1,
        [StringValue("Stock Insuficiente para Realizar la Venta.")]
        StockInsuficiente= 2,
        [StringValue("Cantidad Ingresada no Válida.")]
        CantidadNoValidad = 3,
        [StringValue("Por Favor Ingrese Cantidad a Vender.")]
        IngreseCantidadVender = 4,
        [StringValue("Por Favor Busque el Producto a Vender.")]
        BusqueProductoVender = 5,
        [StringValue("Por Favor Busque el Cliente a Vender.")]
        BusqueClienteVender = 6
    }
    public enum MensajesVentas
    {
        [StringValue("SUB-TOTAL  S/.")]
        Subtotal = 1,
        [StringValue("      I.G.V.        %")]
        Igv = 2,
        [StringValue("     TOTAL     S/.")]
        Total = 3,
    }
    public enum MensajeValidacionCliente
    {
        [StringValue("Por Favor Ingrese el Nombre del Empleado.")]
        CampoVacioNombreCliente = 1,
        [StringValue("Por Favor Ingrese los Apellidos del Ciente.")]
        CampoVacioApellidoCliente = 2,
        [StringValue("Por Favor Ingrese la Dirección del Cliente.")]
        CampoVacioDireccionCliente = 3,
        [StringValue("Por Favor Ingrese el DNI del Cliente")]
        CampoVacioDNI = 4,
        [StringValue("Por Favor Ingrese el Telefono del Cliente.")]
        CampoVacioTelefonoCliente= 5,
        [StringValue("Por Favor Ingrese un DNI Correcto")]
        CampoIncorrectoDNI = 6,
        [StringValue("Por Favor Ingrese solo números en el Campo DNI")]
        CampoIncorrectoLetrasDNI = 7,
        [StringValue("Por Favor Ingrese solo letras en el Campo Apellido")]
        CampoIncorrectoNumerosApellido= 8,
        [StringValue("Por Favor Ingrese solo Letras en el Campo Nombre")]
        CampoIncorrectoNumerosNombre= 9,
    }
    public enum CompoCorrectoCliente
    {
        CampoCorrectoDNI = 8,
    }
    public enum MensajeValidacionCargo
    {
        [StringValue("Por Favor Ingrese Descripción del Cargo")]
        CampoVacioDescripcionCargo = 1,
    }
    public enum MensajeValidacionCategoria
    {
        [StringValue("Por Favor Ingrese Descripción de la Categoria")]
        CampoVacioDescripcionCategoria = 1,
    }
    public enum Proyecto
    {
        [StringValue("Sistema de Ventas.")]
        Sistema = 1,
        [StringValue("¿Está Seguro que Desea Salir.?")]
        Salir = 2,
        [StringValue("Debe Seleccionar la Fila a Editar.")]
        SeleccioneFila = 3,
        [StringValue(" - ")]
        EspaciadoEspacial = 4,
        [StringValue("Ingresar solo números")]
        SoloNumeros = 5,
        [StringValue("No Existe Ningún Elemento en la Lista.")]
        NoFila = 6,
    }
    public enum Transaccion
    {
        [StringValue("Correcta")]
        Correcta = 1,
        [StringValue("Incorrecta")]
        Incorrecta = 2
    }
    public enum CamposCategoria
    {
        [StringValue("IdCategoria")]
        IdCategoria = 1,
        [StringValue("Descripcion")]
        Descripcion = 2
    }
    public enum CamposEmpleado
    {
        [StringValue("IdEmpleado")]
        IdEmpleado = 1,
        [StringValue("IdCargo")]
        IdCargo = 2,
        [StringValue("Dni")]
        Dni = 3,
        [StringValue("Apellidos")]
        Apellidos = 4,
        [StringValue("Nombres")]
        Nombres = 5,
        [StringValue("Sexo")]
        Sexo = 6,
        [StringValue("FechaNac")]
        FechaNac = 7,
        [StringValue("Direccion")]
        Direccion = 8,
        [StringValue("EstadoCivil")]
        EstadoCivil = 9,
        [StringValue("Descripcion")]
        Descripcion = 10,
        [StringValue("NombreApellido")]
        NombreApellido = 11
    }
    public enum CamposCargo
    {
        [StringValue("IdCargo")]
        IdCargo = 1,
        [StringValue("Descripcion")]
        Descripcion = 2
    }
    public enum MensajeValidacionUsuario
    {
        [StringValue("Su Contraseña es Incorrecta.")]
        ClaveCampoVacio = 1,
        [StringValue("El Nombre de Usuario no Existe.")]
        UsuarioCampoVacio = 2,
        [StringValue("Por Favor Ingrese su Contraseña.")]
        ClaveVacio = 3,
        [StringValue("Por Favor Ingrese su Usuario.")]
        UsuarioVacio = 4
    }
    public enum ValorDefectoUsuario
    {
        [StringValue("Bienvenido Sr(a):")]
        ValorDefecto = 1,

    }
    public enum EstadoCivilEmpleado
    {
        [StringValue("S")]
        Soltero = 1,
        [StringValue("C")]
        Casado = 2,
        [StringValue("V")]
        Viudo = 3,
        [StringValue("D")]
        Divorciado = 4,
    }
    public enum SexoEmpleado
    {
        [StringValue("M")]
        Masculino = 1,
        [StringValue("F")]
        Femenino = 2,
    }
    public enum MensajeValidacionEmpleado
    {
  
        [StringValue("Por Favor Ingrese el Nombre del Empleado.")]
        CampoVacioNombreEmpleado = 1,
        [StringValue("Por Favor Ingrese los Apellidos del empleado.")]
        CampoVacioApellidoEmpleado= 2,
        [StringValue("Por Favor Ingrese la Dirección del Empleado.")]
        CampoVacioDireccionEmpleado= 3,
        [StringValue("Por Favor Ingrese el DNI del Empleado")]
        CampoVacioDNI= 4,
        [StringValue("Por Favor Ingrese un DNI Correcto")]
        CampoIncorrectoDNI = 5,
        [StringValue("Por Favor Ingrese solo números en el Campo DNI")]
        CampoIncorrectoLetrasDNI = 6,
        [StringValue("Por Favor Ingrese solo letras en el Campo Apellido")]
        CampoIncorrectoNumerosApellido = 7,
        [StringValue("Por Favor Ingrese solo Letras en el Campo Nombre")]
        CampoIncorrectoNumerosNombre = 8,
    }
    public enum Ventas
    {
        [StringValue("FACTURA")]
        Factura = 1,
        [StringValue("BOLETA DE VENTAS")]
        BoletaVentas= 2,
        [StringValue("Factura")]
        ComprobanteFactura = 3,
        [StringValue("Boleta")]
        ComprobanteBoleta = 4,
        [StringValue("Registrado Correctamente.")]
        MensajeCorrecto = 5
    }

}