namespace PLM.Vista.Reporte
{
    partial class SurtimientoEntregado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SurtimientoEntregado));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.dtpFechaI = new System.Windows.Forms.DateTimePicker();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.dtpFechaF = new System.Windows.Forms.DateTimePicker();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.tbOrdenTrabajo = new MetroFramework.Controls.MetroTextBox();
            this.clbOrdenTrabajo = new System.Windows.Forms.CheckedListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnPrintRep = new System.Windows.Forms.ToolStripButton();
            this.pbResurtimiento = new MetroFramework.Controls.MetroProgressBar();
            this.cbClientes = new System.Windows.Forms.ComboBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(12, 55);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(130, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Fecha de Embarque:";
            // 
            // dtpFechaI
            // 
            this.dtpFechaI.CustomFormat = "dd/MMMM/yyyy";
            this.dtpFechaI.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaI.Location = new System.Drawing.Point(148, 54);
            this.dtpFechaI.Name = "dtpFechaI";
            this.dtpFechaI.Size = new System.Drawing.Size(180, 20);
            this.dtpFechaI.TabIndex = 16;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(334, 55);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(24, 19);
            this.metroLabel2.TabIndex = 17;
            this.metroLabel2.Text = "Al:";
            // 
            // dtpFechaF
            // 
            this.dtpFechaF.CustomFormat = "dd/MMMM/yyyy";
            this.dtpFechaF.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaF.Location = new System.Drawing.Point(364, 54);
            this.dtpFechaF.Name = "dtpFechaF";
            this.dtpFechaF.Size = new System.Drawing.Size(180, 20);
            this.dtpFechaF.TabIndex = 18;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(12, 104);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(57, 19);
            this.metroLabel3.TabIndex = 19;
            this.metroLabel3.Text = "Clientes:";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(12, 156);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(97, 19);
            this.metroLabel5.TabIndex = 23;
            this.metroLabel5.Text = "Orden Trabajo:";
            // 
            // tbOrdenTrabajo
            // 
            // 
            // 
            // 
            this.tbOrdenTrabajo.CustomButton.Image = null;
            this.tbOrdenTrabajo.CustomButton.Location = new System.Drawing.Point(368, 1);
            this.tbOrdenTrabajo.CustomButton.Name = "";
            this.tbOrdenTrabajo.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.tbOrdenTrabajo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbOrdenTrabajo.CustomButton.TabIndex = 1;
            this.tbOrdenTrabajo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbOrdenTrabajo.CustomButton.UseSelectable = true;
            this.tbOrdenTrabajo.CustomButton.Visible = false;
            this.tbOrdenTrabajo.Lines = new string[0];
            this.tbOrdenTrabajo.Location = new System.Drawing.Point(148, 156);
            this.tbOrdenTrabajo.MaxLength = 32767;
            this.tbOrdenTrabajo.Name = "tbOrdenTrabajo";
            this.tbOrdenTrabajo.PasswordChar = '\0';
            this.tbOrdenTrabajo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbOrdenTrabajo.SelectedText = "";
            this.tbOrdenTrabajo.SelectionLength = 0;
            this.tbOrdenTrabajo.SelectionStart = 0;
            this.tbOrdenTrabajo.ShortcutsEnabled = true;
            this.tbOrdenTrabajo.Size = new System.Drawing.Size(396, 29);
            this.tbOrdenTrabajo.TabIndex = 22;
            this.tbOrdenTrabajo.UseSelectable = true;
            this.tbOrdenTrabajo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbOrdenTrabajo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tbOrdenTrabajo.TextChanged += new System.EventHandler(this.tbOrdenTrabajo_TextChanged);
            // 
            // clbOrdenTrabajo
            // 
            this.clbOrdenTrabajo.FormattingEnabled = true;
            this.clbOrdenTrabajo.Location = new System.Drawing.Point(148, 184);
            this.clbOrdenTrabajo.Name = "clbOrdenTrabajo";
            this.clbOrdenTrabajo.Size = new System.Drawing.Size(396, 64);
            this.clbOrdenTrabajo.TabIndex = 21;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrintRep});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(582, 25);
            this.toolStrip1.TabIndex = 24;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnPrintRep
            // 
            this.btnPrintRep.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintRep.Image")));
            this.btnPrintRep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintRep.Name = "btnPrintRep";
            this.btnPrintRep.Size = new System.Drawing.Size(73, 22);
            this.btnPrintRep.Text = "Imprimir";
            this.btnPrintRep.Click += new System.EventHandler(this.btnPrintRep_Click);
            // 
            // pbResurtimiento
            // 
            this.pbResurtimiento.Location = new System.Drawing.Point(12, 284);
            this.pbResurtimiento.Name = "pbResurtimiento";
            this.pbResurtimiento.Size = new System.Drawing.Size(532, 23);
            this.pbResurtimiento.TabIndex = 25;
            // 
            // cbClientes
            // 
            this.cbClientes.FormattingEnabled = true;
            this.cbClientes.Location = new System.Drawing.Point(148, 102);
            this.cbClientes.Name = "cbClientes";
            this.cbClientes.Size = new System.Drawing.Size(396, 21);
            this.cbClientes.TabIndex = 26;
            // 
            // SurtimientoEntregado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 320);
            this.Controls.Add(this.cbClientes);
            this.Controls.Add(this.pbResurtimiento);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.tbOrdenTrabajo);
            this.Controls.Add(this.clbOrdenTrabajo);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.dtpFechaF);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.dtpFechaI);
            this.Controls.Add(this.metroLabel1);
            this.DoubleBuffered = true;
            this.Name = "SurtimientoEntregado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SurtimientoEntregado";
            this.Load += new System.EventHandler(this.SurtimientoEntregado_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.DateTimePicker dtpFechaI;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.DateTimePicker dtpFechaF;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox tbOrdenTrabajo;
        private System.Windows.Forms.CheckedListBox clbOrdenTrabajo;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnPrintRep;
        public MetroFramework.Controls.MetroProgressBar pbResurtimiento;
        private System.Windows.Forms.ComboBox cbClientes;
    }
}