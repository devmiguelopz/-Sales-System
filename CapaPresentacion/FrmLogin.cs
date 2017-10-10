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
using CapaDominio;
using CapaTransversal;
using CapaAplicacion;

namespace Capa_de_Presentacion
{
    public partial class FrmLogin : DevComponents.DotNetBar.Metro.MetroForm
    {
        private static FrmLogin _instancia;
        public static FrmLogin Instancia
        {
            get
            {
                if (_instancia == null || _instancia.IsDisposed)
                    _instancia = new FrmLogin();
                return _instancia;
            }
        }
        public FrmLogin()
        {
            InitializeComponent();
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (DevComponents.DotNetBar.MessageBoxEx.Show(Proyecto.Salir.GetStringValue(), Proyecto.Sistema.GetStringValue(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }

        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {

                String TransaccionUsuario = UsuarioAP.Instancia.VerificarUsuario(ValidacionCamposProducto(), LLenarObjetoUsuario());
                DevComponents.DotNetBar.MessageBoxEx.Show(TransaccionUsuario, Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormularioPrincipal(TransaccionUsuario);
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
        public Usuario LLenarObjetoUsuario()
        {
            try
            {
                Usuario Usuario = new Usuario();
                Usuario.Usuarios = txtUser.Text;
                Usuario.Clave = txtPassword.Text;
                return Usuario;
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                return null;
            }
        }
        public String ValidacionCamposProducto()
        {
            try
            {
                if (String.IsNullOrEmpty(txtUser.Text.Trim()))
                {
                    txtUser.Focus();
                    return MensajeValidacionUsuario.UsuarioCampoVacio.GetStringValue();
                }
                if (String.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    txtPassword.Focus();
                    return MensajeValidacionUsuario.ClaveCampoVacio.GetStringValue();
                }
                return ValidacionCampos.Correcta.GetStringValue();
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                return ValidacionCampos.Incorrecta.GetStringValue();
            }
        }
        public void FormularioPrincipal(String TransaccionUsuario)
        {
            try
            {
                if (TransaccionUsuario.Contains(ValorDefectoUsuario.ValorDefecto.GetStringValue()))
                {
                    FrmMenuPrincipal.Instancia.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {

                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
            }
        }
    }
}
