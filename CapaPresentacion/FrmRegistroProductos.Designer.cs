namespace Capa_de_Presentacion
{
    partial class FrmRegistroProductos
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPCompra = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPVenta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxCategoria = new System.Windows.Forms.ComboBox();
            this.btnCategoria = new System.Windows.Forms.Button();
            this.IdC = new System.Windows.Forms.TextBox();
            this.txtIdP = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F);
            this.label1.Location = new System.Drawing.Point(39, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Producto";
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(42, 92);
            this.txtProducto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(374, 26);
            this.txtProducto.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F);
            this.label2.Location = new System.Drawing.Point(39, 130);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Marca";
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(42, 155);
            this.txtMarca.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(374, 26);
            this.txtMarca.TabIndex = 3;
            this.txtMarca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMarca_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 259);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "P. Compra";
            // 
            // txtPCompra
            // 
            this.txtPCompra.Location = new System.Drawing.Point(42, 278);
            this.txtPCompra.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPCompra.Name = "txtPCompra";
            this.txtPCompra.Size = new System.Drawing.Size(102, 26);
            this.txtPCompra.TabIndex = 5;
            this.txtPCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPCompra_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(181, 259);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "P. Venta";
            // 
            // txtPVenta
            // 
            this.txtPVenta.Location = new System.Drawing.Point(185, 278);
            this.txtPVenta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPVenta.Name = "txtPVenta";
            this.txtPVenta.Size = new System.Drawing.Size(94, 26);
            this.txtPVenta.TabIndex = 7;
            this.txtPVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPVenta_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(311, 259);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Stock";
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(315, 278);
            this.txtStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(103, 26);
            this.txtStock.TabIndex = 9;
            this.txtStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStock_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 12F);
            this.label6.Location = new System.Drawing.Point(39, 191);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "Fecha Vencimiento";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(42, 214);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(372, 26);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Consolas", 12F);
            this.btnGuardar.Location = new System.Drawing.Point(482, 92);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(112, 34);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "&Grabar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Consolas", 12F);
            this.btnCancelar.Location = new System.Drawing.Point(482, 151);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(112, 34);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "&Salir";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 12F);
            this.label7.Location = new System.Drawing.Point(39, 11);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 19);
            this.label7.TabIndex = 14;
            this.label7.Text = "Categoria";
            // 
            // cbxCategoria
            // 
            this.cbxCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCategoria.FormattingEnabled = true;
            this.cbxCategoria.Location = new System.Drawing.Point(42, 34);
            this.cbxCategoria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxCategoria.Name = "cbxCategoria";
            this.cbxCategoria.Size = new System.Drawing.Size(256, 27);
            this.cbxCategoria.TabIndex = 15;
            // 
            // btnCategoria
            // 
            this.btnCategoria.Location = new System.Drawing.Point(307, 33);
            this.btnCategoria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCategoria.Name = "btnCategoria";
            this.btnCategoria.Size = new System.Drawing.Size(112, 34);
            this.btnCategoria.TabIndex = 16;
            this.btnCategoria.Text = "&Categoria";
            this.btnCategoria.UseVisualStyleBackColor = true;
            this.btnCategoria.Click += new System.EventHandler(this.btnCategoria_Click);
            // 
            // IdC
            // 
            this.IdC.BackColor = System.Drawing.SystemColors.Control;
            this.IdC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.IdC.Location = new System.Drawing.Point(633, 218);
            this.IdC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.IdC.Name = "IdC";
            this.IdC.Size = new System.Drawing.Size(26, 19);
            this.IdC.TabIndex = 17;
            this.IdC.Visible = false;
            // 
            // txtIdP
            // 
            this.txtIdP.Location = new System.Drawing.Point(777, 53);
            this.txtIdP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIdP.Name = "txtIdP";
            this.txtIdP.Size = new System.Drawing.Size(61, 26);
            this.txtIdP.TabIndex = 18;
            // 
            // FrmRegistroProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(621, 347);
            this.Controls.Add(this.txtIdP);
            this.Controls.Add(this.IdC);
            this.Controls.Add(this.btnCategoria);
            this.Controls.Add(this.cbxCategoria);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPVenta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPCompra);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProducto);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FrmRegistroProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro Productos";
            this.Load += new System.EventHandler(this.FrmRegistroProductos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCategoria;
        public System.Windows.Forms.TextBox txtProducto;
        public System.Windows.Forms.TextBox txtMarca;
        public System.Windows.Forms.TextBox txtPCompra;
        public System.Windows.Forms.TextBox txtPVenta;
        public System.Windows.Forms.TextBox txtStock;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.ComboBox cbxCategoria;
        public System.Windows.Forms.TextBox IdC;
        public System.Windows.Forms.TextBox txtIdP;
    }
}