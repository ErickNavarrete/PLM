namespace PLM.Vista.Cotización
{
    partial class Cotizacion6
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.metroTextBox16 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel22 = new MetroFramework.Controls.MetroLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MANO_OBRA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRESUPUESTO_MN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PIEZAS_DIARIAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESGLOCE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COSTO_USD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COSTO_MN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.metroTextBox16);
            this.groupBox4.Controls.Add(this.metroLabel22);
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Location = new System.Drawing.Point(6, 17);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1135, 203);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Datos MO y Gastos";
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
            this.metroLabel22.Size = new System.Drawing.Size(180, 19);
            this.metroLabel22.TabIndex = 13;
            this.metroLabel22.Text = "Subtotal de Sueldos y Gastos:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MANO_OBRA,
            this.DESCRIPCION,
            this.PRESUPUESTO_MN,
            this.PIEZAS_DIARIAS,
            this.UNIDAD,
            this.DESGLOCE,
            this.COSTO_USD,
            this.COSTO_MN,
            this.TOTAL});
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1123, 139);
            this.dataGridView1.TabIndex = 0;
            // 
            // MANO_OBRA
            // 
            this.MANO_OBRA.HeaderText = "MANO DE OBRA";
            this.MANO_OBRA.Name = "MANO_OBRA";
            // 
            // DESCRIPCION
            // 
            this.DESCRIPCION.HeaderText = "DESCRIPCION";
            this.DESCRIPCION.Name = "DESCRIPCION";
            // 
            // PRESUPUESTO_MN
            // 
            this.PRESUPUESTO_MN.HeaderText = "PRESUPUESTO MN REAL";
            this.PRESUPUESTO_MN.Name = "PRESUPUESTO_MN";
            // 
            // PIEZAS_DIARIAS
            // 
            this.PIEZAS_DIARIAS.HeaderText = "PIEZAS DIARIAS";
            this.PIEZAS_DIARIAS.Name = "PIEZAS_DIARIAS";
            // 
            // UNIDAD
            // 
            this.UNIDAD.HeaderText = "UNIDAD";
            this.UNIDAD.Name = "UNIDAD";
            // 
            // DESGLOCE
            // 
            this.DESGLOCE.HeaderText = "DESGLOCE PRESUP";
            this.DESGLOCE.Name = "DESGLOCE";
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
            // Cotizacion6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox4);
            this.Name = "Cotizacion6";
            this.Size = new System.Drawing.Size(1147, 454);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private MetroFramework.Controls.MetroTextBox metroTextBox16;
        private MetroFramework.Controls.MetroLabel metroLabel22;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MANO_OBRA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPCION;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRESUPUESTO_MN;
        private System.Windows.Forms.DataGridViewTextBoxColumn PIEZAS_DIARIAS;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESGLOCE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COSTO_USD;
        private System.Windows.Forms.DataGridViewTextBoxColumn COSTO_MN;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL;
    }
}
