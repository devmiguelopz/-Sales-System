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
    public partial class FrmListadoClientes : DevComponents.DotNetBar.Metro.MetroForm
    {
        //int Listado = 0;
        private static FrmListadoClientes _instancia;
        public static FrmListadoClientes Instancia
        {
            get
            {
                if (_instancia == null || _instancia.IsDisposed)
                    _instancia = new FrmListadoClientes();
                return _instancia;
            }
        }
        public FrmListadoClientes()
        {
            InitializeComponent();
        }
        private void FrmListadoClientes_Load(object sender, EventArgs e)
        {
            //timer1.Start();
            //timer1.Interval = 5000;
            ListarClientes();
        }
        public void ListarClientes()
        {
            DataTable TablaDatos = new DataTable();
            try
            {
                TablaDatos = ClienteAP.Instancia.ListarClientes();
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
                }
            }
            catch (Exception ex)
            {

                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                DevComponents.DotNetBar.MessageBoxEx.Show(ManejadorErrores.Instancia.Error[0].MensajeCliente,
                Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ManejadorErrores ManejoErrores = new ManejadorErrores();
            try
            {
                dataGridView1.ClearSelection();
                FrmRegistroCliente.Instancia.Show();
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
        private void btnActualizar_Click(object sender, EventArgs e)
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
                var Cliente = FrmRegistroCliente.Instancia;
                Cliente.TxtIdCliente.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                Cliente.txtDni.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                Cliente.txtApellidos.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                Cliente.txtNombres.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                Cliente.txtDireccion.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                Cliente.txtTelefono.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                Cliente.txtDni.Focus();
                Cliente.Show();
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {

                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                DevComponents.DotNetBar.MessageBoxEx.Show(ManejadorErrores.Instancia.Error[0].MensajeCliente,
                Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //    timer1.Start();
                //MessageBox.Show("Se Prisiono la tecla enter");


        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //dataGridView1.ClearSelection();
            //if (e.KeyChar == 13)
            //{
            //    DataTable dt = new DataTable();
            //    C.Dni = txtBuscarCliente.Text;
            //    dt = C.BuscarCliente(C.Dni);
            //    try
            //    {
            //        dataGridView1.Rows.Clear();
            //        for (int i = 0; i < dt.Rows.Count; i++)
            //        {
            //            dataGridView1.Rows.Add(dt.Rows[i][0]);
            //            dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
            //            dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
            //            dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
            //            dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
            //            dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
            //            dataGridView1.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();
            //        }
            //        dataGridView1.ClearSelection();
            //        timer1.Stop();
            //    }
            //    catch (Exception ex)
            //    {
            //        DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message);
            //    }
            //}
            //else {
            //    ListarClientes();
            //    timer1.Start();
            //}
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
            if (DevComponents.DotNetBar.MessageBoxEx.Show
                (Proyecto.Salir.GetStringValue(), Proyecto.Sistema.GetStringValue(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //switch (listado)
            //{
            //    case 0: listarclientes(); break;
            //}
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Cliente.Instancia.IdCliente = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Cliente.Instancia.Dni = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Cliente.Instancia.Apellidos = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            Cliente.Instancia.Nombres = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            this.Close();
        }
    }
}
