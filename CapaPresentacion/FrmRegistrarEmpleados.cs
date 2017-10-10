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
    public partial class FrmRegistrarEmpleados : DevComponents.DotNetBar.Metro.MetroForm
    {
        private static FrmRegistrarEmpleados _instancia;
        public static FrmRegistrarEmpleados Instancia
        {
            get
            {
                if (_instancia == null || _instancia.IsDisposed)
                    _instancia = new FrmRegistrarEmpleados();
                return _instancia;
            }
        }
        //int Listado = 0;
        public FrmRegistrarEmpleados()
        {
            InitializeComponent();
        }
        private void FrmRegistrarEmpleados_Load(object sender, EventArgs e)
        {
            //timer1.Start();
            //timer1.Interval = 1000;
            CargarElementosCargos();
        }
        public void CargarElementosCargos()
        {
            DataTable TablaDatos = new DataTable();

            try
            {
                TablaDatos = CargoAP.Instancia.ListarCargos();
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
                if (Empleado.Instancia.Cargo.IdCargo != 0)
                {
                    comboBox1.DisplayMember = CamposCargo.Descripcion.GetStringValue();
                    comboBox1.ValueMember = CamposCargo.IdCargo.GetStringValue();
                    comboBox1.DataSource = TablaDatos;
                    comboBox1.SelectedValue = Empleado.Instancia.Cargo.IdCargo;
                }
                else
                {
                    comboBox1.DisplayMember = CamposCargo.Descripcion.GetStringValue();
                    comboBox1.ValueMember = CamposCargo.IdCargo.GetStringValue();
                    comboBox1.DataSource = TablaDatos;
                    cbxEstadoCivil.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                DevComponents.DotNetBar.MessageBoxEx.Show(ManejadorErrores.Instancia.Error[0].MensajeCliente,
                Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            FrmRegistrarCargo.Instancia.Show();
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {

                String TransaccionEmpleado = EmpleadoAP.Instancia.RegistrarEmpleado(ValidacionCamposEmpleado(), LLenarObjetoempleado());
                DevComponents.DotNetBar.MessageBoxEx.Show(TransaccionEmpleado, Proyecto.Sistema.GetStringValue(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmListadoEmpleados.Instancia.ListarEmpleados();
                FrmRegistrarUsuarios.Instancia.ListarElementosEmpleados();
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
            cbxEstadoCivil.SelectedIndex = 0;
            txtApellidos.Clear();
            txtDireccion.Clear();
            txtDni.Clear();
            txtNombres.Clear();
            rbnMasculino.Checked = true;
            dateTimePicker1.Value = DateTime.Now;
            txtIdE.Clear();
            //Program.IdCargo = 0;
            comboBox1.SelectedIndex = 0;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //switch (Listado) {
            //    case 0: CargarElementosCargos(); break;
            //}
        }
        public Empleado LLenarObjetoempleado()
        {
            try
            {
                Empleado Empleado = new Empleado();
                Empleado.IdEmpleado = String.IsNullOrEmpty(txtIdE.Text) ? 0 : Convert.ToInt32(txtIdE.Text);
                Empleado.Cargo.IdCargo = Convert.ToInt32(comboBox1.SelectedValue);
                Empleado.Dni = txtDni.Text;
                Empleado.Apellidos = txtApellidos.Text;
                Empleado.Nombres = txtNombres.Text;
                Empleado.Sexo = rbnMasculino.Checked == true ? Convert.ToChar(SexoEmpleado.Masculino.GetStringValue()) : Convert.ToChar(SexoEmpleado.Femenino.GetStringValue());
                Empleado.FechaNacimiento = Convert.ToDateTime(dateTimePicker1.Value);
                Empleado.Direccion = txtDireccion.Text; ;
                switch (cbxEstadoCivil.SelectedIndex)
                {
                    case 0: Empleado.EstadoCivil = Convert.ToChar(EstadoCivilEmpleado.Soltero.GetStringValue()); break;
                    case 1: Empleado.EstadoCivil = Convert.ToChar(EstadoCivilEmpleado.Casado.GetStringValue()); break;
                    case 2: Empleado.EstadoCivil = Convert.ToChar(EstadoCivilEmpleado.Divorciado.GetStringValue()); break;
                    case 3: Empleado.EstadoCivil = Convert.ToChar(EstadoCivilEmpleado.Viudo.GetStringValue()); break;
                }
                return Empleado;
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                return null;
            }
        }
        public String ValidacionCamposEmpleado()
        {
            try
            {
                if (String.IsNullOrEmpty(txtDni.Text.Trim()))
                {
                    txtDni.Focus();
                    return MensajeValidacionEmpleado.CampoVacioDNI.GetStringValue();
                }
                if (String.IsNullOrEmpty(txtApellidos.Text.Trim()))
                {
                    txtApellidos.Focus();
                    return MensajeValidacionEmpleado.CampoVacioApellidoEmpleado.GetStringValue();
                }
                if (String.IsNullOrEmpty(txtNombres.Text.Trim()))
                {
                    txtNombres.Focus();
                    return MensajeValidacionEmpleado.CampoVacioNombreEmpleado.GetStringValue();
                }
                if (String.IsNullOrEmpty(txtDireccion.Text.Trim()))
                {
                    txtDireccion.Focus();
                    return MensajeValidacionEmpleado.CampoVacioDireccionEmpleado.GetStringValue();
                }
                return ValidacionCampos.Correcta.GetStringValue();
            }
            catch (Exception ex)
            {
                ManejadorErrores.Instancia.Error.Add(new ManejadorErrores.Errores(ex, MensajeErrorCapas.ErrorPresentacion.GetStringValue(), Convert.ToString(DateTime.Now)));
                return ValidacionCampos.Incorrecta.GetStringValue();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DevComponents.DotNetBar.MessageBoxEx.Show
                (Proyecto.Salir.GetStringValue(), Proyecto.Sistema.GetStringValue(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
