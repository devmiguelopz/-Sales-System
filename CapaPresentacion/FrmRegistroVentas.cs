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
using CapaEntidad;


namespace Capa_de_Presentacion
{
    public partial class FrmRegistroVentas : DevComponents.DotNetBar.Metro.MetroForm
    {
        private List<DetalleVenta> lista = new List<DetalleVenta>();
        private static FrmRegistroVentas _instancia;
        public static FrmRegistroVentas Instancia
        {
            get
            {
                if (_instancia == null || _instancia.IsDisposed)
                    _instancia = new FrmRegistroVentas();
                return _instancia;
            }
        }
        public FrmRegistroVentas()
        {
            InitializeComponent();
        }
        private void rbnFactura_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbnFactura.Checked == true)
                {
                    lblTipo.Text = Ventas.Factura.GetStringValue();
                }
                else
                {
                    lblTipo.Text = Ventas.BoletaVentas.GetStringValue();
                }

            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.RegistrarLogs(ex, Convert.ToString(DateTime.Now));
                ManejadorErrores.Instancia.Error.Clear();
                MessageBoxEx.Show(ManejadorErrores.Instancia.Error[0].MensajeCliente,
                Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void rbnBoleta_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GenerarNumeroComprobante();
            }
            catch (Exception ex)
            {

                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                MessageBoxEx.Show(ManejadorErrores.Instancia.Error[0].MensajeCliente,
                Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                ManejadorErrores.Instancia.RegistrarLogs(ManejadorErrores.Instancia);
                ManejadorErrores.Instancia.Error.Clear();
            }

        }
        private void FrmVentas_Load(object sender, EventArgs e)
        {
            try
            {
                GenerarNumeroComprobante();
                GenerarIdVenta();
                GenerarSeriedeDocumento();
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                MessageBoxEx.Show(ManejadorErrores.Instancia.Error[0].MensajeCliente,
                Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ManejadorErrores.Instancia.RegistrarLogs(ManejadorErrores.Instancia);
                ManejadorErrores.Instancia.Error.Clear();
            }

        }
        private void GenerarIdVenta()
        {
            try
            {
                txtIdVenta.Text = VentaAP.Instancia.GenerarIdVenta();
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                MessageBoxEx.Show(ManejadorErrores.Instancia.Error[0].MensajeCliente, Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void GenerarSeriedeDocumento()
        {
            try
            {
                lblSerie.Text = VentaAP.Instancia.GenerarSerieDocumento();
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                MessageBoxEx.Show(ManejadorErrores.Instancia.Error[0].MensajeCliente, Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void GenerarNumeroComprobante()
        {
            try
            {
                lblNroCorrelativo.Text = VentaAP.Instancia.NumeroComprobante(rbnBoleta.Checked);
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                MessageBoxEx.Show(ManejadorErrores.Instancia.Error[0].MensajeCliente, Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            FrmListadoClientes.Instancia.Show();
        }
        private void FrmVentas_Activated(object sender, EventArgs e)
        {

            txtIdCliente.Text = Cliente.Instancia.IdCliente + "";
            txtDocIdentidad.Text = Cliente.Instancia.Dni;
            txtDatos.Text = Cliente.Instancia.Nombres + ", " + Cliente.Instancia.Apellidos;
            txtIdProducto.Text = Producto.Instancia.IdP + "";
            txtDescripcion.Text = Producto.Instancia.Productos;
            txtMarca.Text = Producto.Instancia.Marca;
            txtStock.Text = Producto.Instancia.Stock + "";
            txtPVenta.Text = Producto.Instancia.PrecioVenta + "";
        }
        private void btnBusquedaProducto_Click(object sender, EventArgs e)
        {
            FrmListadoProductos.Instancia.Show();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                DetalleVenta DetalleVenta = LLenarObjetoDetalleVenta();
                String TransaccionDetalleVenta = DetalleVentaAP.Instancia.ValidacionRegistrarVenta(ref DetalleVenta);
                if (TransaccionDetalleVenta == ValidacionCampos.Correcta.GetStringValue())
                {
                    LlenarGrilla(DetalleVenta);
                    Limpiar();
                }
                else
                {
                    MessageBoxEx.Show(TransaccionDetalleVenta, Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                MessageBoxEx.Show(ManejadorErrores.Instancia.Error[0].MensajeCliente, Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ManejadorErrores.Instancia.RegistrarLogs(ManejadorErrores.Instancia);
                ManejadorErrores.Instancia.Error.Clear();
            }
        }
        public DetalleVenta LLenarObjetoDetalleVenta()
        {
            try
            {
                DetalleVenta DetalleVenta = new DetalleVenta();
                DetalleVenta.Venta.Cliente.Dni = txtDocIdentidad.Text.Trim();
                DetalleVenta.Producto.Productos = txtDescripcion.Text;
                DetalleVenta.Cantidad = String.IsNullOrEmpty(txtCantidad.Text.Trim()) ? 0 : Convert.ToInt32(txtCantidad.Text);
                DetalleVenta.Producto.Descripcion = txtDescripcion.Text.Trim();
                DetalleVenta.Producto.Marca = txtMarca.Text.Trim();
                DetalleVenta.Producto.Stock = String.IsNullOrEmpty(txtStock.Text.Trim()) ? 0 : Convert.ToInt32(txtStock.Text);
                DetalleVenta.Producto.IdP = String.IsNullOrEmpty(txtIdProducto.Text.Trim()) ? 0 : Convert.ToInt32(txtIdProducto.Text);
                DetalleVenta.Venta.IdVenta = String.IsNullOrEmpty(txtIdVenta.Text.Trim()) ? 0 : Convert.ToInt32(txtIdVenta.Text);
                DetalleVenta.Producto.PrecioVenta = Convert.ToDecimal(txtPVenta.Text);
                DetalleVenta.Igv = String.IsNullOrEmpty(txtIgv.Text.Trim()) ? -1 : Convert.ToDecimal(txtIgv.Text);
                return DetalleVenta;
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                return null;
            }
        }
        private void LlenarGrilla(DetalleVenta DetalleVenta)
        {
            Decimal SumaSubTotal = 0; Decimal SumaIgv = 0; Decimal SumaTotal = 0;
            lista.Add(DetalleVenta);
            dataGridView1.Rows.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = lista[i].Venta.IdVenta;
                dataGridView1.Rows[i].Cells[1].Value = lista[i].Cantidad;
                dataGridView1.Rows[i].Cells[2].Value = lista[i].Producto.Descripcion;
                dataGridView1.Rows[i].Cells[3].Value = lista[i].producto.PrecioVenta;
                dataGridView1.Rows[i].Cells[4].Value = lista[i].SubTotal;
                dataGridView1.Rows[i].Cells[5].Value = lista[i].Producto.IdP;
                dataGridView1.Rows[i].Cells[6].Value = lista[i].Igv;
                SumaSubTotal += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                SumaIgv += Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
            }
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows[lista.Count + 1].Cells[3].Value = MensajesVentas.Subtotal.GetStringValue();
            dataGridView1.Rows[lista.Count + 1].Cells[4].Value = SumaSubTotal;
            dataGridView1.Rows.Add();
            dataGridView1.Rows[lista.Count + 2].Cells[3].Value = MensajesVentas.Igv.GetStringValue();
            dataGridView1.Rows[lista.Count + 2].Cells[4].Value = SumaIgv;
            dataGridView1.Rows.Add();
            dataGridView1.Rows[lista.Count + 3].Cells[3].Value = MensajesVentas.Total.GetStringValue();
            SumaTotal += SumaSubTotal + SumaIgv;
            dataGridView1.Rows[lista.Count + 3].Cells[4].Value = SumaTotal;
            dataGridView1.ClearSelection();
        }
        private void Limpiar()
        {
            txtDescripcion.Clear();
            txtIgv.Clear();
            txtMarca.Clear();
            txtStock.Clear();
            txtPVenta.Clear();
            txtCantidad.Clear();
            txtCantidad.Focus();
            Producto.Instancia.Productos = "";
            Producto.Instancia.Marca = "";
            Producto.Instancia.Stock = 0;
            Producto.Instancia.PrecioVenta = 0;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show(Proyecto.Salir.GetStringValue(), Proyecto.Sistema.GetStringValue(), MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Selected = true;
            }
        }
        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0 && Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value) != "")
                {
                    String TransaccionVentaGeneral = DetalleVentaAP.Instancia.RegistrarVentaGeneral(LlenarObjetoVenta());
                    MessageBoxEx.Show(TransaccionVentaGeneral, Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (TransaccionVentaGeneral == Ventas.MensajeCorrecto.GetStringValue())
                    {
                        GenerarIdVenta();
                        GenerarNumeroComprobante();
                        Limpiar1();
                    }
                }
                else
                {
                    MessageBoxEx.Show(Proyecto.NoFila.GetStringValue(), Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                MessageBoxEx.Show(ManejadorErrores.Instancia.Error[0].MensajeCliente, Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ManejadorErrores.Instancia.RegistrarLogs(ManejadorErrores.Instancia);
                ManejadorErrores.Instancia.Error.Clear();
            }
        }
        private DetalleVenta LlenarObjetoVenta()
        {
            try
            {
                DetalleVenta DetalleVenta = new DetalleVenta();
                Decimal Total = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    Total = Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                }
                DetalleVenta.Venta.TipoDocumento = rbnBoleta.Checked == true ? Ventas.BoletaVentas.GetStringValue() : Ventas.ComprobanteFactura.GetStringValue();
                DetalleVenta.Venta.Empleado.IdEmpleado = Usuario.Instancia.Empleado.IdEmpleado;
                DetalleVenta.Venta.Cliente.IdCliente = Cliente.Instancia.IdCliente;
                DetalleVenta.Venta.Serie = lblSerie.Text;
                DetalleVenta.Venta.NroComprobante = lblNroCorrelativo.Text;
                DetalleVenta.Venta.FechaVenta = Convert.ToDateTime(dateTimePicker1.Value);
                DetalleVenta.Venta.Total = Total;
                DetalleVenta.ListaDetalleVenta = LLenarListaDetalleVenta();
                return DetalleVenta;
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                return null;
            }
        }
        public tBaseDetalleVenta LLenarListaDetalleVenta()
        {
            try
            {
                List<DetalleVenta> DetalleVenta = new List<DetalleVenta>();
                tBaseDetalleVenta ListaDetalleVenta = new tBaseDetalleVenta();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    Decimal SumaIgv = 0; Decimal SumaSubTotal = 0;
                    if (Convert.ToString(dataGridView1.Rows[i].Cells[2].Value) != "")
                    {
                        SumaIgv += Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
                        SumaSubTotal += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                        ListaDetalleVenta.Add(new DetalleVenta
                        {
                            IdDetalleVenta = 0,
                            IdP = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value),
                            IdVenta = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value),
                            Cantidad = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value),
                            PUnitario = Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value),
                            Igv = SumaIgv,
                            SubTotal = SumaSubTotal,
                        });
                    }
                }
                return ListaDetalleVenta;
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add
                (new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                return null;
            }
        }
        private void Limpiar1()
        {
            txtIgv.Clear();
            txtCantidad.Clear();
            txtDocIdentidad.Clear();
            txtDatos.Clear();
            txtIdProducto.Clear();
            dataGridView1.Rows.Clear();
            rbnBoleta.Checked = true;
            Cliente.Instancia.Nombres = "";
            Cliente.Instancia.Apellidos = "";
            Cliente.Instancia.Dni = "";
            Cliente.Instancia.IdCliente = 0;
            lista.Clear();
        }
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBoxEx.Show(Proyecto.SoloNumeros.GetStringValue(), Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
                return;
            }
        }
        private void txtIgv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBoxEx.Show(Proyecto.SoloNumeros.GetStringValue(), Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
                return;
            }
        }
    }
}
