using CapaAplicacion;
using CapaTransversal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_de_Presentacion
{
    public partial class FrmListadoCategoria : DevComponents.DotNetBar.Metro.MetroForm
    {

        private static FrmListadoCategoria _instancia;
        public static FrmListadoCategoria Instancia
        {
            get
            {
                if (_instancia == null || _instancia.IsDisposed)
                    _instancia = new FrmListadoCategoria();
                return _instancia;
            }
        }
        public FrmListadoCategoria()
        {
            InitializeComponent();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ManejadorErrores ManejoErrores = new ManejadorErrores();
            try
            {
                dataGridView1.ClearSelection();
                FrmRegistrarCategoria.Instancia.Show();
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
        private void FrmListadoCategoria_Load(object sender, EventArgs e)
        {
            ListarCategorias();
        }
        public void ListarCategorias()
        {
            DataTable TablaDatos = new DataTable();
            try
            {
                TablaDatos = CategoriaAP.Instancia.ListarCategoria();
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
            dataGridView1.Rows[dataGridView1.CurrentRow.Index].Selected = true;
        }
        private void txtBuscarCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 13)
            //{
            //    ListarBusqueda();
            //}
            //else {
            //    ListarCategorias();
            //}
        }
        private void ListarBusqueda()
        {
            //try
            //{
            //DataTable dt = new DataTable();
            //clsCategoria C = new clsCategoria();
            //C.Descripcion = txtBuscarCategoria.Text;
            //dt = C.BuscarCategoria(C.Descripcion);
            //dataGridView1.Rows.Clear();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    dataGridView1.Rows.Add(dt.Rows[i][0]);
            //    dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
            //    dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
            //}
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

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
                var Categoria = FrmRegistrarCategoria.Instancia;
                Categoria.IdC.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                Categoria.txtCategoria.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                Categoria.Show();
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {

                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                DevComponents.DotNetBar.MessageBoxEx.Show(ManejadorErrores.Instancia.Error[0].MensajeCliente,
                Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (DevComponents.DotNetBar.MessageBoxEx.Show
                (Proyecto.Salir.GetStringValue(), Proyecto.Sistema.GetStringValue(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
