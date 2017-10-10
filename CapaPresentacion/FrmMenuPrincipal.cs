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

namespace Capa_de_Presentacion
{
    public partial class FrmMenuPrincipal : DevComponents.DotNetBar.Metro.MetroForm
    {
        private static FrmMenuPrincipal _instancia;
        public static FrmMenuPrincipal Instancia
        {
            get
            {
                if (_instancia == null || _instancia.IsDisposed)
                    _instancia = new FrmMenuPrincipal();
                return _instancia;
            }
        }
        int EnviarFecha = 0;
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }
        private void FrmMenuPrincipal_Activated(object sender, EventArgs e)
        {
            lblUsuario.Text = Usuario.Instancia.Empleado.Nombres;
        }
        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            timer1.Interval = 500;
            timer1.Start();
        }
        private void btnProductos_Click(object sender, EventArgs e)
        {

            FrmListadoProductos.Instancia.Show();
        }
        private void btnClientes_Click(object sender, EventArgs e)
        {
            FrmListadoClientes.Instancia.Show();
        }
        private void btnVentas_Click(object sender, EventArgs e)
        {
            FrmRegistroVentas.Instancia.Show();
        }
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FrmRegistrarUsuarios.Instancia.Show();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            switch(EnviarFecha){
                case 0: CapturarFechaSistema(); break;
            }
        }
        private void CapturarFechaSistema() {
            lblFecha.Text = DateTime.Now.ToShortDateString();
            lblHora.Text = DateTime.Now.ToShortTimeString();
        }
        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            FrmListadoEmpleados.Instancia.Show();
        }
        private void FrmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void btnCargo_Click(object sender, EventArgs e)
        {
            FrmListadoCargos.Instancia.Show();
        }
        private void btnCategoria_Click(object sender, EventArgs e)
        {
            FrmListadoCategoria.Instancia.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
