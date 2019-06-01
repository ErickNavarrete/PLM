namespace PLM.Vista.Cotización
{
    partial class Cotizacion3
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.metroTextBox18 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel24 = new MetroFramework.Controls.MetroLabel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.CALIBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROVEEDOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MN_PROGRAMADA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.metroTextBox16 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel22 = new MetroFramework.Controls.MetroLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ANCHO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PESO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLOR_DESCRIPCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE_PROVEEDOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONSUMO_PROG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COSTO_USD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COSTO_MN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.metroTextBox18);
            this.groupBox5.Controls.Add(this.metroLabel24);
            this.groupBox5.Controls.Add(this.dataGridView2);
            this.groupBox5.Location = new System.Drawing.Point(6, 239);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1135, 198);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Etiq. Confección";
            // 
            // metroTextBox18
            // 
            // 
            // 
            // 
            this.metroTextBox18.CustomButton.Image = null;
            this.metroTextBox18.CustomButton.Location = new System.Drawing.Point(137, 1);
            this.metroTextBox18.CustomButton.Name = "";
            this.metroTextBox18.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox18.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox18.CustomButton.TabIndex = 1;
            this.metroTextBox18.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox18.CustomButton.UseSelectable = true;
            this.metroTextBox18.CustomButton.Visible = false;
            this.metroTextBox18.Lines = new string[0];
            this.metroTextBox18.Location = new System.Drawing.Point(214, 166);
            this.metroTextBox18.MaxLength = 32767;
            this.metroTextBox18.Name = "metroTextBox18";
            this.metroTextBox18.PasswordChar = '\0';
            this.metroTextBox18.ReadOnly = true;
            this.metroTextBox18.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox18.SelectedText = "";
            this.metroTextBox18.SelectionLength = 0;
            this.metroTextBox18.SelectionStart = 0;
            this.metroTextBox18.ShortcutsEnabled = true;
            this.metroTextBox18.Size = new System.Drawing.Size(159, 23);
            this.metroTextBox18.TabIndex = 17;
            this.metroTextBox18.UseSelectable = true;
            this.metroTextBox18.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox18.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel24
            // 
            this.metroLabel24.AutoSize = true;
            this.metroLabel24.Location = new System.Drawing.Point(6, 170);
            this.metroLabel24.Name = "metroLabel24";
            this.metroLabel24.Size = new System.Drawing.Size(177, 19);
            this.metroLabel24.TabIndex = 16;
            this.metroLabel24.Text = "Subtotal de Etiq. Confección:";
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CALIBRE,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.PROVEEDOR,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.MN_PROGRAMADA,
            this.dataGridViewTextBoxColumn9});
            this.dataGridView2.Location = new System.Drawing.Point(6, 19);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1123, 139);
            this.dataGridView2.TabIndex = 15;
            // 
            // CALIBRE
            // 
            this.CALIBRE.HeaderText = "CALIBRE";
            this.CALIBRE.Name = "CALIBRE";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "TIPO";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "COLOR / DESCRIPCIÓN";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // PROVEEDOR
            // 
            this.PROVEEDOR.HeaderText = "NOMBRE DEL PROVEEDOR";
            this.PROVEEDOR.Name = "PROVEEDOR";
            this.PROVEEDOR.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "CONSUMO PROGRAMADO";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "UNIDAD";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "COSTO USD PROG";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // MN_PROGRAMADA
            // 
            this.MN_PROGRAMADA.HeaderText = "COSTO MN PROG";
            this.MN_PROGRAMADA.Name = "MN_PROGRAMADA";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "TOTAL USD PROG";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.metroTextBox16);
            this.groupBox4.Controls.Add(this.metroLabel22);
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Location = new System.Drawing.Point(6, 17);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1135, 203);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Metales";
            // 
            // metroTextBox16
            // 
            // 
            // 
            // 
            this.metroTextBox16.CustomButton.Image = null;
            this.metroTextBox16.CustomButton.Location = new System.Drawing.Point(137, 1);
            this.metroTextBox16.CustomButton.Name = "";
            this.metroTextBox16.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox16.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox16.CustomButton.TabIndex = 1;
            this.metroTextBox16.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox16.CustomButton.UseSelectable = true;
            this.metroTextBox16.CustomButton.Visible = false;
            this.metroTextBox16.Lines = new string[0];
            this.metroTextBox16.Location = new System.Drawing.Point(214, 164);
            this.metroTextBox16.MaxLength = 32767;
            this.metroTextBox16.Name = "metroTextBox16";
            this.metroTextBox16.PasswordChar = '\0';
            this.metroTextBox16.ReadOnly = true;
            this.metroTextBox16.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox16.SelectedText = "";
            this.metroTextBox16.SelectionLength = 0;
            this.metroTextBox16.SelectionStart = 0;
            this.metroTextBox16.ShortcutsEnabled = true;
            this.metroTextBox16.Size = new System.Drawing.Size(159, 23);
            this.metroTextBox16.TabIndex = 14;
            this.metroTextBox16.UseSelectable = true;
            this.metroTextBox16.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox16.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel22
            // 
            this.metroLabel22.AutoSize = true;
            this.metroLabel22.Location = new System.Drawing.Point(6, 168);
            this.metroLabel22.Name = "metroLabel22";
            this.metroLabel22.Size = new System.Drawing.Size(128, 19);
            this.metroLabel22.TabIndex = 13;
            this.metroLabel22.Text = "Subtotal de Metales:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TIPO,
            this.ANCHO,
            this.PESO,
            this.COLOR_DESCRIPCION,
            this.NOMBRE_PROVEEDOR,
            this.CONSUMO_PROG,
            this.UNIDAD,
            this.COSTO_USD,
            this.COSTO_MN,
            this.TOTAL});
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1123, 139);
            this.dataGridView1.TabIndex = 0;
            // 
            // TIPO
            // 
            this.TIPO.HeaderText = "TIPO";
            this.TIPO.Name = "TIPO";
            // 
            // ANCHO
            // 
            this.ANCHO.HeaderText = "ANCHO";
            this.ANCHO.Name = "ANCHO";
            // 
            // PESO
            // 
            this.PESO.HeaderText = "PESO";
            this.PESO.Name = "PESO";
            // 
            // COLOR_DESCRIPCION
            // 
            this.COLOR_DESCRIPCION.HeaderText = "COLOR / DESCRIPCIÓN";
            this.COLOR_DESCRIPCION.Name = "COLOR_DESCRIPCION";
            // 
            // NOMBRE_PROVEEDOR
            // 
            this.NOMBRE_PROVEEDOR.HeaderText = "NOMBRE DEL PROVEEDOR";
            this.NOMBRE_PROVEEDOR.Name = "NOMBRE_PROVEEDOR";
            this.NOMBRE_PROVEEDOR.Width = 150;
            // 
            // CONSUMO_PROG
            // 
            this.CONSUMO_PROG.HeaderText = "CONSUMO PROGRAMADO";
            this.CONSUMO_PROG.Name = "CONSUMO_PROG";
            // 
            // UNIDAD
            // 
            this.UNIDAD.HeaderText = "UNIDAD";
            this.UNIDAD.Name = "UNIDAD";
            // 
            // COSTO_USD
            // 
            this.COSTO_USD.HeaderText = "COSTO USD PROG";
            this.COSTO_USD.Name = "COSTO_USD";
            // 
            // COSTO_MN
            // 
            this.COSTO_MN.HeaderText = "COSTO MN PROG";
            this.COSTO_MN.Name = "COSTO_MN";
            // 
            // TOTAL
            // 
            this.TOTAL.HeaderText = "TOTAL MN PROG";
            this.TOTAL.Name = "TOTAL";
            // 
            // Cotizacion3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Name = "Cotizacion3";
            this.Size = new System.Drawing.Size(1147, 454);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private MetroFramework.Controls.MetroTextBox metroTextBox18;
        private MetroFramework.Controls.MetroLabel metroLabel24;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CALIBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROVEEDOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn MN_PROGRAMADA;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.GroupBox groupBox4;
        private MetroFramework.Controls.MetroTextBox metroTextBox16;
        private MetroFramework.Controls.MetroLabel metroLabel22;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ANCHO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PESO;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLOR_DESCRIPCION;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE_PROVEEDOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONSUMO_PROG;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn COSTO_USD;
        private System.Windows.Forms.DataGridViewTextBoxColumn COSTO_MN;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL;
    }
}
