namespace Capa_de_Presentacion
{
    partial class FrmRegistroVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNroCorrelativo = new System.Windows.Forms.Label();
            this.lblSerie = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbnFactura = new System.Windows.Forms.RadioButton();
            this.rbnBoleta = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnBusqueda = new System.Windows.Forms.Button();
            this.txtDocIdentidad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDatos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtIgv = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnBusquedaProducto = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPVenta = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IdD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIdVenta = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnRegistrarVenta = new System.Windows.Forms.Button();
            this.btnEliminarItem = new System.Windows.Forms.Button();
            this.txtIdProducto = new System.Windows.Forms.TextBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblNroCorrelativo);
            this.panel1.Controls.Add(this.lblSerie);
            this.panel1.Controls.Add(this.lblTipo);
            this.panel1.Location = new System.Drawing.Point(656, 25);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 145);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(297, 50);
            this.label3.TabIndex = 3;
            this.label3.Text = "R.U.C. 20486546126";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(105, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "-";
            // 
            // lblNroCorrelativo
            // 
            this.lblNroCorrelativo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroCorrelativo.ForeColor = System.Drawing.Color.Red;
            this.lblNroCorrelativo.Location = new System.Drawing.Point(168, 101);
            this.lblNroCorrelativo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNroCorrelativo.Name = "lblNroCorrelativo";
            this.lblNroCorrelativo.Size = new System.Drawing.Size(117, 34);
            this.lblNroCorrelativo.TabIndex = 1;
            this.lblNroCorrelativo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSerie
            // 
            this.lblSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerie.Location = new System.Drawing.Point(10, 101);
            this.lblSerie.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(86, 34);
            this.lblSerie.TabIndex = 1;
            // 
            // lblTipo
            // 
            this.lblTipo.BackColor = System.Drawing.Color.DimGray;
            this.lblTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTipo.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(-2, 50);
            this.lblTipo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(299, 41);
            this.lblTipo.TabIndex = 0;
            this.lblTipo.Text = "BOLETA DE VENTA";
            this.lblTipo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbnFactura);
            this.groupBox1.Controls.Add(this.rbnBoleta);
            this.groupBox1.Font = new System.Drawing.Font("Consolas", 12F);
            this.groupBox1.Location = new System.Drawing.Point(18, 19);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(288, 75);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo Documento";
            // 
            // rbnFactura
            // 
            this.rbnFactura.AutoSize = true;
            this.rbnFactura.Location = new System.Drawing.Point(171, 35);
            this.rbnFactura.Margin = new System.Windows.Forms.Padding(4);
            this.rbnFactura.Name = "rbnFactura";
            this.rbnFactura.Size = new System.Drawing.Size(90, 23);
            this.rbnFactura.TabIndex = 3;
            this.rbnFactura.Text = "Factura";
            this.rbnFactura.UseVisualStyleBackColor = true;
            this.rbnFactura.CheckedChanged += new System.EventHandler(this.rbnFactura_CheckedChanged);
            // 
            // rbnBoleta
            // 
            this.rbnBoleta.AutoSize = true;
            this.rbnBoleta.Checked = true;
            this.rbnBoleta.Location = new System.Drawing.Point(26, 35);
            this.rbnBoleta.Margin = new System.Windows.Forms.Padding(4);
            this.rbnBoleta.Name = "rbnBoleta";
            this.rbnBoleta.Size = new System.Drawing.Size(81, 23);
            this.rbnBoleta.TabIndex = 2;
            this.rbnBoleta.TabStop = true;
            this.rbnBoleta.Text = "Boleta";
            this.rbnBoleta.UseVisualStyleBackColor = true;
            this.rbnBoleta.CheckedChanged += new System.EventHandler(this.rbnBoleta_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 53);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Font = new System.Drawing.Font("Consolas", 12F);
            this.groupBox2.Location = new System.Drawing.Point(338, 19);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(300, 75);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fecha de Venta";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(40, 27);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(250, 26);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnBusqueda);
            this.groupBox3.Controls.Add(this.txtDocIdentidad);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtDatos);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Font = new System.Drawing.Font("Consolas", 12F);
            this.groupBox3.Location = new System.Drawing.Point(18, 104);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(620, 120);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cliente";
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.Location = new System.Drawing.Point(470, 31);
            this.btnBusqueda.Margin = new System.Windows.Forms.Padding(4);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(140, 34);
            this.btnBusqueda.TabIndex = 4;
            this.btnBusqueda.Text = "Buscar";
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // txtDocIdentidad
            // 
            this.txtDocIdentidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocIdentidad.Location = new System.Drawing.Point(174, 34);
            this.txtDocIdentidad.Margin = new System.Windows.Forms.Padding(4);
            this.txtDocIdentidad.Name = "txtDocIdentidad";
            this.txtDocIdentidad.ReadOnly = true;
            this.txtDocIdentidad.Size = new System.Drawing.Size(257, 26);
            this.txtDocIdentidad.TabIndex = 3;
            this.txtDocIdentidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 34);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "Doc. Identidad:";
            // 
            // txtDatos
            // 
            this.txtDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDatos.Location = new System.Drawing.Point(128, 73);
            this.txtDatos.Margin = new System.Windows.Forms.Padding(4);
            this.txtDatos.Name = "txtDatos";
            this.txtDatos.ReadOnly = true;
            this.txtDatos.Size = new System.Drawing.Size(482, 26);
            this.txtDatos.TabIndex = 1;
            this.txtDatos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sr (a):";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtIgv);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.btnBusquedaProducto);
            this.groupBox4.Controls.Add(this.btnAgregar);
            this.groupBox4.Controls.Add(this.txtCantidad);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtPVenta);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txtStock);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txtMarca);
            this.groupBox4.Controls.Add(this.txtDescripcion);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Font = new System.Drawing.Font("Consolas", 12F);
            this.groupBox4.Location = new System.Drawing.Point(18, 232);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(936, 134);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Producto";
            // 
            // txtIgv
            // 
            this.txtIgv.Location = new System.Drawing.Point(698, 83);
            this.txtIgv.Margin = new System.Windows.Forms.Padding(4);
            this.txtIgv.Name = "txtIgv";
            this.txtIgv.Size = new System.Drawing.Size(56, 26);
            this.txtIgv.TabIndex = 13;
            this.txtIgv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIgv_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Consolas", 12F);
            this.label12.Location = new System.Drawing.Point(609, 87);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 19);
            this.label12.TabIndex = 12;
            this.label12.Text = "I.G.V(%):";
            // 
            // btnBusquedaProducto
            // 
            this.btnBusquedaProducto.Font = new System.Drawing.Font("Consolas", 12F);
            this.btnBusquedaProducto.Location = new System.Drawing.Point(802, 34);
            this.btnBusquedaProducto.Margin = new System.Windows.Forms.Padding(4);
            this.btnBusquedaProducto.Name = "btnBusquedaProducto";
            this.btnBusquedaProducto.Size = new System.Drawing.Size(112, 34);
            this.btnBusquedaProducto.TabIndex = 11;
            this.btnBusquedaProducto.Text = "Buscar";
            this.btnBusquedaProducto.UseVisualStyleBackColor = true;
            this.btnBusquedaProducto.Click += new System.EventHandler(this.btnBusquedaProducto_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Consolas", 12F);
            this.btnAgregar.Location = new System.Drawing.Point(783, 80);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(132, 44);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(499, 84);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(4);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(102, 26);
            this.txtCantidad.TabIndex = 9;
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(402, 87);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 19);
            this.label10.TabIndex = 8;
            this.label10.Text = "Cantidad:";
            // 
            // txtPVenta
            // 
            this.txtPVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPVenta.Location = new System.Drawing.Point(282, 83);
            this.txtPVenta.Margin = new System.Windows.Forms.Padding(4);
            this.txtPVenta.Name = "txtPVenta";
            this.txtPVenta.ReadOnly = true;
            this.txtPVenta.Size = new System.Drawing.Size(112, 26);
            this.txtPVenta.TabIndex = 7;
            this.txtPVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(190, 86);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 19);
            this.label9.TabIndex = 6;
            this.label9.Text = "P. Venta:";
            // 
            // txtStock
            // 
            this.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStock.Location = new System.Drawing.Point(82, 85);
            this.txtStock.Margin = new System.Windows.Forms.Padding(4);
            this.txtStock.Name = "txtStock";
            this.txtStock.ReadOnly = true;
            this.txtStock.Size = new System.Drawing.Size(94, 26);
            this.txtStock.TabIndex = 5;
            this.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 86);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 19);
            this.label8.TabIndex = 4;
            this.label8.Text = "Stock:";
            // 
            // txtMarca
            // 
            this.txtMarca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMarca.Location = new System.Drawing.Point(554, 34);
            this.txtMarca.Margin = new System.Windows.Forms.Padding(4);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.ReadOnly = true;
            this.txtMarca.Size = new System.Drawing.Size(200, 26);
            this.txtMarca.TabIndex = 3;
            this.txtMarca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Location = new System.Drawing.Point(140, 35);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(306, 26);
            this.txtDescripcion.TabIndex = 2;
            this.txtDescripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(480, 41);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 19);
            this.label7.TabIndex = 1;
            this.label7.Text = "Marca:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 37);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Descripción:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdD,
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3,
            this.Column5,
            this.Column6});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.GridColor = System.Drawing.Color.DimGray;
            this.dataGridView1.Location = new System.Drawing.Point(18, 390);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.RowHeadersWidth = 60;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.Size = new System.Drawing.Size(938, 181);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // IdD
            // 
            this.IdD.HeaderText = "IdV";
            this.IdD.Name = "IdD";
            this.IdD.ReadOnly = true;
            this.IdD.Visible = false;
            this.IdD.Width = 30;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "CANTIDAD";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "DESCRIPCIÓN";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 230;
            // 
            // Column4
            // 
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column4.HeaderText = "PRECIO UNITARIO";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 215;
            // 
            // Column3
            // 
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.HeaderText = "IMPORTE";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 230;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "IdP";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            this.Column5.Width = 30;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "IGV";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // txtIdVenta
            // 
            this.txtIdVenta.Location = new System.Drawing.Point(1152, 76);
            this.txtIdVenta.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdVenta.Name = "txtIdVenta";
            this.txtIdVenta.Size = new System.Drawing.Size(74, 26);
            this.txtIdVenta.TabIndex = 17;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Consolas", 12F);
            this.btnSalir.Location = new System.Drawing.Point(828, 596);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(112, 37);
            this.btnSalir.TabIndex = 18;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnRegistrarVenta
            // 
            this.btnRegistrarVenta.Font = new System.Drawing.Font("Consolas", 12F);
            this.btnRegistrarVenta.Location = new System.Drawing.Point(631, 596);
            this.btnRegistrarVenta.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegistrarVenta.Name = "btnRegistrarVenta";
            this.btnRegistrarVenta.Size = new System.Drawing.Size(189, 37);
            this.btnRegistrarVenta.TabIndex = 19;
            this.btnRegistrarVenta.Text = "&Registrar Venta";
            this.btnRegistrarVenta.UseVisualStyleBackColor = true;
            this.btnRegistrarVenta.Click += new System.EventHandler(this.btnRegistrarVenta_Click);
            // 
            // btnEliminarItem
            // 
            this.btnEliminarItem.Font = new System.Drawing.Font("Consolas", 12F);
            this.btnEliminarItem.Location = new System.Drawing.Point(463, 596);
            this.btnEliminarItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminarItem.Name = "btnEliminarItem";
            this.btnEliminarItem.Size = new System.Drawing.Size(165, 37);
            this.btnEliminarItem.TabIndex = 20;
            this.btnEliminarItem.Text = "&Eliminar Item";
            this.btnEliminarItem.UseVisualStyleBackColor = true;
            // 
            // txtIdProducto
            // 
            this.txtIdProducto.Location = new System.Drawing.Point(1152, 114);
            this.txtIdProducto.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdProducto.Name = "txtIdProducto";
            this.txtIdProducto.Size = new System.Drawing.Size(74, 26);
            this.txtIdProducto.TabIndex = 21;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Location = new System.Drawing.Point(1152, 114);
            this.txtIdCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(74, 26);
            this.txtIdCliente.TabIndex = 21;
            // 
            // FrmRegistroVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(978, 644);
            this.Controls.Add(this.txtIdProducto);
            this.Controls.Add(this.txtIdCliente);
            this.Controls.Add(this.btnEliminarItem);
            this.Controls.Add(this.btnRegistrarVenta);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtIdVenta);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmRegistroVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Ventas";
            this.Activated += new System.EventHandler(this.FrmVentas_Activated);
            this.Load += new System.EventHandler(this.FrmVentas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNroCorrelativo;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbnFactura;
        private System.Windows.Forms.RadioButton rbnBoleta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtDatos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBusqueda;
        private System.Windows.Forms.TextBox txtDocIdentidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnBusquedaProducto;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPVenta;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtIdVenta;
        private System.Windows.Forms.TextBox txtIgv;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnRegistrarVenta;
        private System.Windows.Forms.Button btnEliminarItem;
        private System.Windows.Forms.TextBox txtIdProducto;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}