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
    public partial class FrmRegistrarCategoria : DevComponents.DotNetBar.Metro.MetroForm
    {
        private static FrmRegistrarCategoria _instancia;
        public static FrmRegistrarCategoria Instancia
        {
            get
            {
                if (_instancia == null || _instancia.IsDisposed)
                    _instancia = new FrmRegistrarCategoria();
                return _instancia;
            }
        }
        public FrmRegistrarCategoria()
        {
            InitializeComponent();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (DevComponents.DotNetBar.MessageBoxEx.Show(Proyecto.Salir.GetStringValue(), Proyecto.Sistema.GetStringValue(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                String TransaccionProducto = CategoriaAP.Instancia.RegistrarCategoria(ValidacionCamposCategoria(), LLenarObjetoCategoria());
                DevComponents.DotNetBar.MessageBoxEx.Show(TransaccionProducto, Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmRegistroProductos.Instancia.ListarElementosCategoria();
                FrmListadoCategoria.Instancia.ListarCategorias();
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
            txtCategoria.Clear();
            txtCategoria.Focus();
        }
        private void FrmRegistrarCategoria_Load(object sender, EventArgs e)
        {
        }
        public String ValidacionCamposCategoria()
        {
            try
            {
                if (String.IsNullOrEmpty(txtCategoria.Text.Trim()))
                {
                    txtCategoria.Focus();
                    return MensajeValidacionProducto.CampoVacioNombreProducto.GetStringValue();
                }
                return ValidacionCampos.Correcta.GetStringValue();
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                return ValidacionCampos.Incorrecta.GetStringValue();
            }
        }
        public Categoria LLenarObjetoCategoria()
        {
            try
            {
                Categoria CategoriaCompraVenta = new Categoria();
                CategoriaCompraVenta.Descripcion = txtCategoria.Text.Trim(); ;
                CategoriaCompraVenta.IdC = String.IsNullOrEmpty(IdC.Text) ? 0 : Convert.ToInt32(IdC.Text);
                return CategoriaCompraVenta;
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                return null;
            }
        }
    }
}
