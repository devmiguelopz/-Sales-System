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

namespace Capa_de_Presentacion
{
    public partial class FrmListadoCargos : DevComponents.DotNetBar.Metro.MetroForm
    {
        //int Listado = 0;
        public FrmListadoCargos()
        {
            InitializeComponent();
        }
        private static FrmListadoCargos _instancia;
        public static FrmListadoCargos Instancia
        {
            get
            {
                if (_instancia == null || _instancia.IsDisposed)
                    _instancia = new FrmListadoCargos();
                return _instancia;
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ManejadorErrores ManejoErrores = new ManejadorErrores();
            try
            {
                dataGridView1.ClearSelection();
                FrmRegistrarCargo.Instancia.Show();
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
                var Cargo = FrmRegistrarCargo.Instancia;
                Cargo.txtIdC.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                Cargo.txtCargo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                Cargo.Show();
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {

                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                DevComponents.DotNetBar.MessageBoxEx.Show(ManejadorErrores.Instancia.Error[0].MensajeCliente,
                Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void FrmListadoCargos_Load(object sender, EventArgs e)
        {
            //timer1.Start();
            //timer1.Interval = 5000;
            ListarCargos();
            //dataGridView1.ClearSelection();
        }
        public void ListarCargos()
        {
            DataTable TablaDatos = new DataTable();
            try
            {
                TablaDatos = CargoAP.Instancia.ListarCargos();
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
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Selected = true;
                //timer1.Stop();
            }
        }
        private void txtBuscarCargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try{
            //    if (e.KeyChar == 13){
            //        BusquedaCargo();
            //    }else {
            //        ListarElementos();
            //    }
            //}catch (Exception ex){
            //    DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message);
            //}     
        }
        private void BusquedaCargo() {
            //try{
            //DataTable dt = new DataTable();
            //C.Descripcion = txtBuscarCargo.Text;
            //dt = C.BusquedaCargo(C.Descripcion);
            //dataGridView1.Rows.Clear();
            //for (int i = 0; i < dt.Rows.Count; i++){
            //    dataGridView1.Rows.Add(dt.Rows[i][0]);
            //    dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
            //    dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
            //}
            //}catch (Exception ex){
            //    DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message);
            //}
        }
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (datagridview1.selectedrows.count > 0){
            //    if (e.keychar == 13){
            //        dialogresult resultado = new system.windows.forms.dialogresult();
            //        resultado = devcomponents.dotnetbar.messageboxex.show("está seguro que desea editar está fila.", "sistema de ventas.", messageboxbuttons.yesno, messageboxicon.error);
            //        if (resultado == dialogresult.yes){
            //            if (datagridview1.selectedrows.count > 0){
            //                frmregistrarcargo c = new frmregistrarcargo();
            //                c.txtidc.text = datagridview1.currentrow.cells[0].value.tostring();
            //                c.txtcargo.text = datagridview1.currentrow.cells[1].value.tostring();
            //                if (datagridview1.selectedrows.count > 0)
            //                    program.evento = 1;
            //                else
            //                    program.evento = 0;
            //                datagridview1.clearselection();
            //                c.show();
            //            }
            //        }
            //    }
            //}
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (DevComponents.DotNetBar.MessageBoxEx.Show
                (Proyecto.Salir.GetStringValue(), Proyecto.Sistema.GetStringValue(), MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                this.Close();
            }        
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //switch (Listado) {
            //    case 0: ListarCargos(); break;
            //}
        }
    }
}
