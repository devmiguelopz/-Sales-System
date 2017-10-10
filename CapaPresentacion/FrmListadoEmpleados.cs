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

namespace Capa_de_Presentacion
{
    public partial class FrmListadoEmpleados : DevComponents.DotNetBar.Metro.MetroForm
    {
        private static FrmListadoEmpleados _instancia;
        public static FrmListadoEmpleados Instancia
        {
            get
            {
                if (_instancia == null || _instancia.IsDisposed)
                    _instancia = new FrmListadoEmpleados();
                return _instancia;
            }
        }
        //int Listado = 0;
        public FrmListadoEmpleados()
        {
            InitializeComponent();
        }
        private void FrmListadoEmpleados_Load(object sender, EventArgs e)
        {
            //timer1.Start();
            //timer1.Interval = 1000;
            ListarEmpleados();
            //dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
        }
        public void ListarEmpleados()
        {
            DataTable TablaDatos = new DataTable();
            try
            {
                TablaDatos = EmpleadoAP.Instancia.ListarEmpleadosTotal();
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
                    dataGridView1.Rows[i].Cells[6].Value = Convert.ToDateTime(TablaDatos.Rows[i][6].ToString()).ToShortDateString();
                    dataGridView1.Rows[i].Cells[7].Value = TablaDatos.Rows[i][7].ToString();
                    dataGridView1.Rows[i].Cells[8].Value = TablaDatos.Rows[i][8].ToString();
                    dataGridView1.Rows[i].Cells[9].Value = TablaDatos.Rows[i][9].ToString();
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
                FrmRegistrarEmpleados.Instancia.Show();
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
                var Trabajador = FrmRegistrarEmpleados.Instancia;
                Trabajador.txtIdE.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                Empleado.Instancia.Cargo.IdCargo = Int32.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                Trabajador.txtDni.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                Trabajador.txtApellidos.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                Trabajador.txtNombres.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                Trabajador.rbnMasculino.Checked = dataGridView1.CurrentRow.Cells[5].Value.ToString() == SexoEmpleado.Masculino.GetStringValue() ? true : false;
                Trabajador.rbnFemenino.Checked = dataGridView1.CurrentRow.Cells[5].Value.ToString() == SexoEmpleado.Femenino.GetStringValue() ? true : false;
                Trabajador.dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[6].Value.ToString());
                Trabajador.txtDireccion.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                if (dataGridView1.CurrentRow.Cells[8].Value.ToString() == EstadoCivilEmpleado.Soltero.GetStringValue())
                {
                    Trabajador.cbxEstadoCivil.SelectedIndex = 0;
                }
                else if (dataGridView1.CurrentRow.Cells[8].Value.ToString() == EstadoCivilEmpleado.Casado.GetStringValue())
                {
                    Trabajador.cbxEstadoCivil.SelectedIndex = 1;
                }

                else if (dataGridView1.CurrentRow.Cells[8].Value.ToString() == EstadoCivilEmpleado.Divorciado.GetStringValue())
                {
                    Trabajador.cbxEstadoCivil.SelectedIndex = 2;
                }
                else
                {
                    Trabajador.cbxEstadoCivil.SelectedIndex = 3;
                }
                Trabajador.Show();
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            //switch(Listado){
            //    case 0: ListarEmpleados(); break;
            //}
        }
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Selected = true;
                //timer1.Stop();
            }
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //if (DevComponents.DotNetBar.MessageBoxEx.Show("¿Desea Crear Una Cuenta de Usuario Para este Empleado.?","Sistema de Ventas.", MessageBoxButtons.YesNoCancel) == DialogResult.Yes) {
            //    FrmRegistrarUsuarios U = new FrmRegistrarUsuarios();
            //    Program.IdEmpleado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            //    U.lblEmpleado.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString() + ", " +
            //                         dataGridView1.CurrentRow.Cells[4].Value.ToString();
            //    U.lblDni.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            //    U.lblCargo.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            //    U.Show();
            //}
        }
        private void txtDatos_TextChanged(object sender, EventArgs e)
        {
            //if (txtDatos.TextLength>0)
            //{

            //    DataTable dt = new DataTable();
            //    E.Nombres = txtDatos.Text;
            //    dt = E.BuscarEmpleado(E.Nombres);
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
            //            dataGridView1.Rows[i].Cells[6].Value = Convert.ToDateTime(dt.Rows[i][6].ToString()).ToShortDateString();
            //            dataGridView1.Rows[i].Cells[7].Value = dt.Rows[i][7].ToString();
            //            dataGridView1.Rows[i].Cells[8].Value = dt.Rows[i][8].ToString();
            //            dataGridView1.Rows[i].Cells[9].Value = dt.Rows[i][9].ToString();
            //        }
            //        dataGridView1.ClearSelection();
            //        timer1.Stop();
            //    }
            //    catch (Exception ex)
            //    {
            //        DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message);
            //    }
            //}
            //else
            //{
            //    ListarEmpleados();
            //}
           
        }
        
    }
}
