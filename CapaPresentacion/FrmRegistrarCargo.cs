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
    public partial class FrmRegistrarCargo : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FrmRegistrarCargo()
        {
            InitializeComponent();
        }
        private static FrmRegistrarCargo _instancia;
        public static FrmRegistrarCargo Instancia
        {
            get
            {
                if (_instancia == null || _instancia.IsDisposed)
                    _instancia = new FrmRegistrarCargo();
                return _instancia;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (DevComponents.DotNetBar.MessageBoxEx.Show(Proyecto.Salir.GetStringValue(), Proyecto.Sistema.GetStringValue(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                String TransaccionCargo = CargoAP.Instancia.RegistrarCargo(ValidacionCamposCargo(), LLenarObjetoCargo());
                DevComponents.DotNetBar.MessageBoxEx.Show(TransaccionCargo, Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmListadoCargos.Instancia.ListarCargos();
                FrmRegistrarEmpleados.Instancia.CargarElementosCargos();
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
            txtCargo.Text = "";
            txtIdC.Clear();
            txtCargo.Focus();
        }
        public String ValidacionCamposCargo()
        {
            try
            {
                if (String.IsNullOrEmpty(txtCargo.Text.Trim()))
                {
                    txtCargo.Focus();
                    return MensajeValidacionCargo.CampoVacioDescripcionCargo.GetStringValue();
                }

                return ValidacionCampos.Correcta.GetStringValue();
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                return ValidacionCampos.Incorrecta.GetStringValue();
            }
        }
        public Cargo LLenarObjetoCargo()
        {
            try
            {
                Cargo Cargo = new Cargo();
                Cargo.Descripcion = txtCargo.Text.Trim();
                Cargo.IdCargo = String.IsNullOrEmpty(txtIdC.Text) ? 0 : Convert.ToInt32(txtIdC.Text);
                return Cargo;
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                return null;
            }
        }
        private void FrmRegistrarCargo_Load(object sender, EventArgs e)
        {

        }
    }
}
