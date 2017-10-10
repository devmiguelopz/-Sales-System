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
using CapaAplicacion;
using CapaTransversal;
using CapaDominio;
using CapaPresentacion;

namespace Capa_de_Presentacion
{
    public partial class FrmRegistroProductos : DevComponents.DotNetBar.Metro.MetroForm
    {
        private static FrmRegistroProductos _instancia;
        public static FrmRegistroProductos Instancia
        {
            get
            {
                if (_instancia == null || _instancia.IsDisposed)
                    _instancia = new FrmRegistroProductos();
                return _instancia;
            }
        }
        public FrmRegistroProductos()
        {
            InitializeComponent();
        }
        private void FrmRegistroProductos_Load(object sender, EventArgs e)
        {
            ListarElementosCategoria();
        }
        public void ListarElementosCategoria()
        {
            DataTable TablaDatos = new DataTable();

            try
            {
                TablaDatos = CategoriaAP.Instancia.ListarCategoria();
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
                if ((String.IsNullOrEmpty(IdC.Text.Trim()) ? false : true) == true)
                {
                    cbxCategoria.DisplayMember = CamposCategoria.Descripcion.GetStringValue();
                    cbxCategoria.ValueMember = CamposCategoria.IdCategoria.GetStringValue();
                    cbxCategoria.DataSource = TablaDatos;
                    cbxCategoria.SelectedValue = IdC.Text;
                }
                else
                {
                    cbxCategoria.DisplayMember = CamposCategoria.Descripcion.GetStringValue();
                    cbxCategoria.ValueMember = CamposCategoria.IdCategoria.GetStringValue();
                    cbxCategoria.DataSource = TablaDatos;
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                DevComponents.DotNetBar.MessageBoxEx.Show(ManejadorErrores.Instancia.Error[0].MensajeCliente,
                Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                String TransaccionProducto = ProductoAP.Instancia.RegistrarProducto(ValidacionCamposProducto(), LLenarObjetoProducto());
                DevComponents.DotNetBar.MessageBoxEx.Show(TransaccionProducto, Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmListadoProductos.Instancia.ListarProductos();

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
        private void btnCategoria_Click(object sender, EventArgs e)
        {
            FrmRegistrarCategoria.Instancia.Show();
        }
        private void Limpiar()
        {
            txtProducto.Text = "";
            txtMarca.Clear();
            txtPCompra.Clear();
            txtPVenta.Clear();
            IdC.Clear();
            txtIdP.Clear();
            txtStock.Clear();
            dateTimePicker1.Value = DateTime.Now;
            txtProducto.Focus();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (DevComponents.DotNetBar.MessageBoxEx.Show(Proyecto.Salir.GetStringValue(), Proyecto.Sistema.GetStringValue(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }

        }
        private void txtPCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.txtPCompra.Text.Contains('.'))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
        }
        private void txtPVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.txtPVenta.Text.Contains('.'))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
        }
        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
        }
        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8)
            //    e.Handled = false;
            //else
            //    e.Handled = true;
        }
        public String ValidacionCamposProducto()
        {
            try
            {
                if (String.IsNullOrEmpty(txtProducto.Text.Trim()))
                {
                    txtProducto.Focus();
                    return MensajeValidacionProducto.CampoVacioNombreProducto.GetStringValue();
                }
                if (String.IsNullOrEmpty(txtMarca.Text.Trim()))
                {
                    txtMarca.Focus();
                    return MensajeValidacionProducto.CampoVacioMarcaProducto.GetStringValue();
                }
                if (String.IsNullOrEmpty(txtPCompra.Text.Trim()))
                {
                    txtPCompra.Focus();
                    return MensajeValidacionProducto.CampoVacioPrecioCompraProducto.GetStringValue();
                }
                if (String.IsNullOrEmpty(txtPVenta.Text.Trim()))
                {
                    txtPVenta.Focus();
                    return MensajeValidacionProducto.CampoVacioPrecioVentaProducto.GetStringValue();
                }
                if (String.IsNullOrEmpty(txtStock.Text.Trim()))
                {
                    txtStock.Focus();
                    return MensajeValidacionProducto.CampoVacioStockProducto.GetStringValue();
                }
                return ValidacionCampos.Correcta.GetStringValue();
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                return ValidacionCampos.Incorrecta.GetStringValue();
            }
        }
        public Producto LLenarObjetoProducto()
        {
            try
            {
                Producto ProductoCompraVenta = new Producto();
                ProductoCompraVenta.Productos = txtProducto.Text.Trim();
                ProductoCompraVenta.Marca = txtMarca.Text.Trim();
                ProductoCompraVenta.PrecioCompra = String.IsNullOrEmpty(txtPCompra.Text) ? 0 : Convert.ToDecimal(txtPCompra.Text);
                ProductoCompraVenta.PrecioVenta = String.IsNullOrEmpty(txtPVenta.Text) ? 0 : Convert.ToDecimal(txtPVenta.Text);
                ProductoCompraVenta.Stock = String.IsNullOrEmpty(txtStock.Text) ? 0 : Convert.ToInt32(txtStock.Text);
                ProductoCompraVenta.IdCategoria = Convert.ToInt32(cbxCategoria.SelectedValue);
                ProductoCompraVenta.FechaVencimiento = Convert.ToDateTime(dateTimePicker1.Value);
                ProductoCompraVenta.IdP = String.IsNullOrEmpty(txtIdP.Text) ? 0 : Convert.ToInt32(txtIdP.Text);
                return ProductoCompraVenta;
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                return null;
            }
        }
    }
}
