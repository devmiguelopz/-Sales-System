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
    public partial class FrmRegistrarUsuarios : DevComponents.DotNetBar.Metro.MetroForm
    {

        private static FrmRegistrarUsuarios _instancia;
        public static FrmRegistrarUsuarios Instancia
        {
            get
            {
                if (_instancia == null || _instancia.IsDisposed)
                    _instancia = new FrmRegistrarUsuarios();
                return _instancia;
            }
        }
        public FrmRegistrarUsuarios()
        {
            InitializeComponent();
        }
        private void FrmRegistrarUsuarios_Load(object sender, EventArgs e)
        {

            ListarElementosEmpleados();
        }
        public void ListarElementosEmpleados()
        {
            DataTable TablaDatos = new DataTable();

            try
            {
                TablaDatos = EmpleadoAP.Instancia.ListarEmpleados();
                if (TablaDatos != null && ManejadorErrores.Instancia.Error.Count == 0)
                {
                    LlenarTablaDatos(TablaDatos);
                }
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show(ManejadorErrores.Instancia.Error[0].MensajeCliente,
                    Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                DevComponents.DotNetBar.MessageBoxEx.Show(ManejadorErrores.Instancia.Error[0].MensajeCliente,
                Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                ManejadorErrores.Instancia.RegistrarLogs(ManejadorErrores.Instancia);
                ManejadorErrores.Instancia.Error.Clear();
            }
        }
        private void LlenarTablaDatos(DataTable TablaDatos)
        {
            try
            {
                if ((String.IsNullOrEmpty(TxtIdEmpleado.Text.Trim()) ? false : true) == true)
                {
                    comboBox1.DisplayMember = CamposEmpleado.NombreApellido.GetStringValue() ;
                    comboBox1.ValueMember = CamposEmpleado.IdEmpleado.GetStringValue();
                    comboBox1.DataSource = TablaDatos;
                    comboBox1.SelectedValue = TxtIdEmpleado.Text;
                }
                else
                {
                    comboBox1.DisplayMember = CamposEmpleado.NombreApellido.GetStringValue();
                    comboBox1.ValueMember = CamposEmpleado.IdEmpleado.GetStringValue();
                    comboBox1.DataSource = TablaDatos;
                    lblDni.Text= TablaDatos.Rows[0][2].ToString();
                    lblCargo.Text = TablaDatos.Rows[0][9].ToString();
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                DevComponents.DotNetBar.MessageBoxEx.Show(ManejadorErrores.Instancia.Error[0].MensajeCliente,
                Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {

                String TransaccionUsuario = UsuarioAP.Instancia.RegistrarUsuario(ValidacionCamposUsuario(), LLenarObjetoUsuario());
                DevComponents.DotNetBar.MessageBoxEx.Show(TransaccionUsuario, Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void Limpiar() {
            txtPassword.Clear();
            txtUser.Clear();
            //Program.IdEmpleado = 0;
            txtUser.Focus();
            lblCargo.Text = "";
            lblDni.Text = "";
        }
        public Usuario LLenarObjetoUsuario()
        {
            try
            {
                Usuario Usuario = new Usuario();
                Usuario.Usuarios = txtUser.Text;
                Usuario.Clave = txtPassword.Text;
                Usuario.Empleado.IdEmpleado = (Int32)comboBox1.SelectedValue;
                return Usuario;
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                return null;
            }
        }
        public String ValidacionCamposUsuario()
        {
            try
            {
                if (String.IsNullOrEmpty(txtUser.Text.Trim()))
                {
                    txtUser.Focus();
                    return MensajeValidacionUsuario.UsuarioVacio.GetStringValue();
                }
                if (String.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    txtPassword.Focus();
                    return MensajeValidacionUsuario.ClaveVacio.GetStringValue();
                }
                return ValidacionCampos.Correcta.GetStringValue();
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                return ValidacionCampos.Incorrecta.GetStringValue();
            }
        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        private void btnCategoria_Click_1(object sender, EventArgs e)
        {
            FrmRegistrarEmpleados.Instancia.Show();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable TablaDatos = new DataTable();
            try
            {
                if ((Int32)comboBox1.SelectedValue != 0)
                {
                    TablaDatos = EmpleadoAP.Instancia.InformacionEmpleado((Int32)comboBox1.SelectedValue);
                    if (TablaDatos != null && ManejadorErrores.Instancia.Error.Count == 0)
                    {
                        lblDni.Text = TablaDatos.Rows[0][2].ToString();
                        lblCargo.Text = TablaDatos.Rows[0][9].ToString();
                    }
                    else
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show(ManejadorErrores.Instancia.Error[0].MensajeCliente,
                        Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else 
                {
                    return;
                }

            }
            catch (Exception ex)
            {

                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                DevComponents.DotNetBar.MessageBoxEx.Show(ManejadorErrores.Instancia.Error[0].MensajeCliente,
                Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                ManejadorErrores.Instancia.RegistrarLogs(ManejadorErrores.Instancia);
                ManejadorErrores.Instancia.Error.Clear();
            }
        }

    }
}
