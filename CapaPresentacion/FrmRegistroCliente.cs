using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CapaTransversal;
using CapaDominio;
using CapaAplicacion;
namespace Capa_de_Presentacion
{
    public partial class FrmRegistroCliente : DevComponents.DotNetBar.Metro.MetroForm
    {
        private static FrmRegistroCliente _instancia;
        public static FrmRegistroCliente Instancia
        {
            get
            {
                if (_instancia == null || _instancia.IsDisposed)
                    _instancia = new FrmRegistroCliente();
                return _instancia;
            }
        }
        public FrmRegistroCliente()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                String TransaccionCliente = ClienteAP.Instancia.RegistrarCliente(ValidacionCamposCliente(), LLenarObjetoCliente());
                DevComponents.DotNetBar.MessageBoxEx.Show(TransaccionCliente, Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmListadoClientes.Instancia.ListarClientes();
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                DevComponents.DotNetBar.MessageBoxEx.Show(ManejadorErrores.Instancia.Error[0].MensajeCliente,
                Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ManejadorErrores.Instancia.RegistrarLogs(ManejadorErrores.Instancia);
                ManejadorErrores.Instancia.Error.Clear();
            }
        }
        private void Limpiar()
        {
            txtDni.Text = "";
            txtApellidos.Clear();
            txtNombres.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtDni.Focus();
        }
        private void FrmRegistroCliente_Load(object sender, EventArgs e)
        {
            txtDni.Focus();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (DevComponents.DotNetBar.MessageBoxEx.Show
                (Proyecto.Salir.GetStringValue(), Proyecto.Sistema.GetStringValue(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }
        private void FrmRegistroCliente_Activated(object sender, EventArgs e)
        {
            txtDni.Focus();
        }
        public String ValidacionCamposCliente()
        {
            try
            {
                if (String.IsNullOrEmpty(txtDni.Text.Trim()))
                {
                    txtDni.Focus();
                    return MensajeValidacionCliente.CampoVacioDNI.GetStringValue();
                }
                if (String.IsNullOrEmpty(txtApellidos.Text.Trim()))
                {
                    txtApellidos.Focus();
                    return MensajeValidacionCliente.CampoVacioApellidoCliente.GetStringValue();
                }
                if (String.IsNullOrEmpty(txtNombres.Text.Trim()))
                {
                    txtNombres.Focus();
                    return MensajeValidacionCliente.CampoVacioNombreCliente.GetStringValue();
                }
                if (String.IsNullOrEmpty(txtDireccion.Text.Trim()))
                {
                    txtDireccion.Focus();
                    return MensajeValidacionCliente.CampoVacioDireccionCliente.GetStringValue();
                }
                if (String.IsNullOrEmpty(txtTelefono.Text.Trim()))
                {
                    txtTelefono.Focus();
                    return MensajeValidacionCliente.CampoVacioTelefonoCliente.GetStringValue();
                }
                return ValidacionCampos.Correcta.GetStringValue();
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                return ValidacionCampos.Incorrecta.GetStringValue();
            }
        }
        public Cliente LLenarObjetoCliente()
        {
            try
            {
                Cliente Cliente = new Cliente();
                Cliente.Dni = txtDni.Text.Trim();
                Cliente.Apellidos = txtApellidos.Text.Trim();
                Cliente.Nombres = txtNombres.Text.Trim();
                Cliente.Direccion = txtDireccion.Text.Trim();
                Cliente.Telefono = txtTelefono.Text.Trim();
                Cliente.IdCliente = String.IsNullOrEmpty(TxtIdCliente.Text) ? 0 : Convert.ToInt32(TxtIdCliente.Text);
                return Cliente;
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                return null;
            }
        }
    }
}
