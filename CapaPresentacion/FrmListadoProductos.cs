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
    public partial class FrmListadoProductos : DevComponents.DotNetBar.Metro.MetroForm
    {
        //private Int16 Listado = 0;
        // SINGLETON PARA LA PAGINA LISTA DE PRODUCTOS.
        private static FrmListadoProductos _instancia;
        public static FrmListadoProductos Instancia
        {
            get
            {
                if (_instancia == null || _instancia.IsDisposed)
                    _instancia = new FrmListadoProductos();
                return _instancia;
            }
        }
        //-------
        public FrmListadoProductos()
        {
            InitializeComponent();
        }
        private void FrmProductos_Load(object sender, EventArgs e)
        {
            //timer1.Start(); //DAR COMIENZO AL TEMPORIZADOR PARA QUE CARGE EL EVENTO TIMER1_TICK
            //timer1.Interval = 5000; //CARGA EL EVENTO TIMER1_TICK
            ListarProductos();
        }
        public void ListarProductos()
        {
            DataTable TablaDatos = new DataTable();
            try
            {
                TablaDatos = ProductoAP.Instancia.ListarProductos();
                if (ManejadorErrores.Instancia.Error.Count == 0 && TablaDatos != null)
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
                dataGridView1.ClearSelection();
            }
        }
        private void LlenarTablaDatos(DataTable TablaDatos) 
        {
            try
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < TablaDatos.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(TablaDatos.Rows[i][0]);
                    dataGridView1.Rows[i].Cells[0].Value = TablaDatos.Rows[i][0].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = TablaDatos.Rows[i][1].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = TablaDatos.Rows[i][2].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = TablaDatos.Rows[i][3].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = TablaDatos.Rows[i][4].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = TablaDatos.Rows[i][5].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = TablaDatos.Rows[i][6].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = Convert.ToDateTime(TablaDatos.Rows[i][7].ToString()).ToShortDateString();
                }
            }
            catch (Exception ex)
            {

                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                DevComponents.DotNetBar.MessageBoxEx.Show(ManejadorErrores.Instancia.Error[0].MensajeCliente,
                Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Selected = true;
                //timer1.Stop();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (DevComponents.DotNetBar.MessageBoxEx.Show(Proyecto.Salir.GetStringValue(), Proyecto.Sistema.GetStringValue(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ManejadorErrores ManejoErrores = new ManejadorErrores();
            try
            {
                dataGridView1.ClearSelection();
                FrmRegistroProductos.Instancia.Show();
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
                dataGridView1.ClearSelection();
            }

        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    EditarCampos();
                }
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show(Proyecto.SeleccioneFila.GetStringValue(),
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
        private void EditarCampos() 
        {
            try
            {
                var Producto = FrmRegistroProductos.Instancia;
                Producto.txtIdP.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                Producto.IdC.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                Producto.txtProducto.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                Producto.txtMarca.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                Producto.txtPCompra.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                Producto.txtPVenta.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                Producto.txtStock.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                Producto.dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[7].Value.ToString());
                Producto.Show();
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {

                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                DevComponents.DotNetBar.MessageBoxEx.Show(ManejadorErrores.Instancia.Error[0].MensajeCliente,
                Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //switch (Listado)
            //{
            //    case 0: ListarProductos(); break;        
            //}
        }
        private void BusquedaProductos() {
            //DataTable dt = new DataTable();
            //try
            //{
            //    P.Marca = txtBuscarProducto.Text;
            //    dt = P.BusquedaProductos(P.Marca);
            //    dataGridView1.Rows.Clear();
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        dataGridView1.Rows.Add(dt.Rows[i][0]);
            //        dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
            //        dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
            //        dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
            //        dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
            //        dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
            //        dataGridView1.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();
            //        dataGridView1.Rows[i].Cells[6].Value = dt.Rows[i][6].ToString();
            //        dataGridView1.Rows[i].Cells[7].Value = Convert.ToDateTime(dt.Rows[i][7].ToString()).ToShortDateString();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //dataGridView1.ClearSelection();
        }
        private void txtBuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                BusquedaProductos();
                timer1.Stop();
            }
            else {
                ListarProductos();
                timer1.Start();
            }
        }

        //METODO QUE AL HACER ENTER EN LA FILA LO DESPINTE
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    dataGridView1.ClearSelection();
                }
                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Selected = true;
            }
        }
        //-----
        //METODO QUE AL HACER DOBLECLICK GUARDA LA INFORMACIÓN DEL OBJETO  EN EL SINGLETON PARA REUTILIZARLO.
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
                Producto.Instancia.IdP = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                Producto.Instancia.Productos = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                Producto.Instancia.Marca = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                Producto.Instancia.PrecioVenta = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[5].Value.ToString());
                Producto.Instancia.Stock = Convert.ToInt32(dataGridView1.CurrentRow.Cells[6].Value.ToString());
                this.Close();
        }
        //--
    }
}
