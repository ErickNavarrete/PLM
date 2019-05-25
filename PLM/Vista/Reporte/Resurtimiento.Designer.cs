namespace PLM.Vista.Reporte
{
    partial class Resurtimiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resurtimiento));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.cbClientes = new MetroFramework.Controls.MetroComboBox();
            this.chbOpcion = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.pbResurtimiento = new MetroFramework.Controls.MetroProgressBar();
            this.clbOrdenTrabajo = new System.Windows.Forms.CheckedListBox();
            this.dtpFechaI = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaF = new System.Windows.Forms.DateTimePicker();
            this.tbOrdenTrabajo = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.dtpFechaOC = new System.Windows.Forms.DateTimePicker();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(22, 58);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(68, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Fecha del:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(330, 62);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(24, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Al:";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(22, 101);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(57, 19);
            this.metroLabel3.TabIndex = 5;
            this.metroLabel3.Text = "Clientes:";
            // 
            // cbClientes
            // 
            this.cbClientes.FormattingEnabled = true;
            this.cbClientes.ItemHeight = 23;
            this.cbClientes.Location = new System.Drawing.Point(125, 101);
            this.cbClientes.Name = "cbClientes";
            this.cbClientes.Size = new System.Drawing.Size(386, 29);
            this.cbClientes.TabIndex = 8;
            this.cbClientes.UseSelectable = true;
            // 
            // chbOpcion
            // 
            this.chbOpcion.AutoSize = true;
            this.chbOpcion.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chbOpcion.Location = new System.Drawing.Point(561, 101);
            this.chbOpcion.Name = "chbOpcion";
            this.chbOpcion.Size = new System.Drawing.Size(61, 19);
            this.chbOpcion.TabIndex = 9;
            this.chbOpcion.Text = "Todos";
            this.chbOpcion.UseSelectable = true;
            this.chbOpcion.Visible = false;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(22, 285);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(70, 19);
            this.metroLabel4.TabIndex = 10;
            this.metroLabel4.Text = "Fecha OC:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrint,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(633, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(73, 22);
            this.btnPrint.Text = "Imprimir";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(92, 22);
            this.toolStripButton1.Text = "Orden Venta";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // pbResurtimiento
            // 
            this.pbResurtimiento.Location = new System.Drawing.Point(22, 328);
            this.pbResurtimiento.Name = "pbResurtimiento";
            this.pbResurtimiento.Size = new System.Drawing.Size(558, 23);
            this.pbResurtimiento.TabIndex = 13;
            // 
            // clbOrdenTrabajo
            // 
            this.clbOrdenTrabajo.FormattingEnabled = true;
            this.clbOrdenTrabajo.Location = new System.Drawing.Point(125, 184);
            this.clbOrdenTrabajo.Name = "clbOrdenTrabajo";
            this.clbOrdenTrabajo.Size = new System.Drawing.Size(386, 64);
            this.clbOrdenTrabajo.TabIndex = 14;
            // 
            // dtpFechaI
            // 
            this.dtpFechaI.CustomFormat = "dd/MMMM/yyyy";
            this.dtpFechaI.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaI.Location = new System.Drawing.Point(125, 58);
            this.dtpFechaI.Name = "dtpFechaI";
            this.dtpFechaI.Size = new System.Drawing.Size(180, 20);
            this.dtpFechaI.TabIndex = 15;
            this.dtpFechaI.ValueChanged += new System.EventHandler(this.dtpFechaI_ValueChanged);
            // 
            // dtpFechaF
            // 
            this.dtpFechaF.CustomFormat = "dd/MMMM/yyyy";
            this.dtpFechaF.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaF.Location = new System.Drawing.Point(360, 58);
            this.dtpFechaF.Name = "dtpFechaF";
            this.dtpFechaF.Size = new System.Drawing.Size(180, 20);
            this.dtpFechaF.TabIndex = 16;
            this.dtpFechaF.ValueChanged += new System.EventHandler(this.dtpFechaF_ValueChanged);
            // 
            // tbOrdenTrabajo
            // 
            // 
            // 
            // 
            this.tbOrdenTrabajo.CustomButton.Image = null;
            this.tbOrdenTrabajo.CustomButton.Location = new System.Drawing.Point(358, 1);
            this.tbOrdenTrabajo.CustomButton.Name = "";
            this.tbOrdenTrabajo.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.tbOrdenTrabajo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbOrdenTrabajo.CustomButton.TabIndex = 1;
            this.tbOrdenTrabajo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbOrdenTrabajo.CustomButton.UseSelectable = true;
            this.tbOrdenTrabajo.CustomButton.Visible = false;
            this.tbOrdenTrabajo.Lines = new string[0];
            this.tbOrdenTrabajo.Location = new System.Drawing.Point(125, 156);
            this.tbOrdenTrabajo.MaxLength = 32767;
            this.tbOrdenTrabajo.Name = "tbOrdenTrabajo";
            this.tbOrdenTrabajo.PasswordChar = '\0';
            this.tbOrdenTrabajo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbOrdenTrabajo.SelectedText = "";
            this.tbOrdenTrabajo.SelectionLength = 0;
            this.tbOrdenTrabajo.SelectionStart = 0;
            this.tbOrdenTrabajo.ShortcutsEnabled = true;
            this.tbOrdenTrabajo.Size = new System.Drawing.Size(386, 29);
            this.tbOrdenTrabajo.TabIndex = 17;
            this.tbOrdenTrabajo.UseSelectable = true;
            this.tbOrdenTrabajo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbOrdenTrabajo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tbOrdenTrabajo.TextChanged += new System.EventHandler(this.tbOrdenTrabajo_TextChanged);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(22, 156);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(97, 19);
            this.metroLabel5.TabIndex = 18;
            this.metroLabel5.Text = "Orden Trabajo:";
            // 
            // dtpFechaOC
            // 
            this.dtpFechaOC.CustomFormat = "dd/MMMM/yyyy";
            this.dtpFechaOC.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaOC.Location = new System.Drawing.Point(125, 285);
            this.dtpFechaOC.Name = "dtpFechaOC";
            this.dtpFechaOC.Size = new System.Drawing.Size(180, 20);
            this.dtpFechaOC.TabIndex = 19;
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.metroCheckBox1.Location = new System.Drawing.Point(561, 166);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(61, 19);
            this.metroCheckBox1.TabIndex = 20;
            this.metroCheckBox1.Text = "Todos";
            this.metroCheckBox1.UseSelectable = true;
            this.metroCheckBox1.Visible = false;
            // 
            // Resurtimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 362);
            this.Controls.Add(this.metroCheckBox1);
            this.Controls.Add(this.dtpFechaOC);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.tbOrdenTrabajo);
            this.Controls.Add(this.dtpFechaF);
            this.Controls.Add(this.dtpFechaI);
            this.Controls.Add(this.clbOrdenTrabajo);
            this.Controls.Add(this.pbResurtimiento);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.chbOpcion);
            this.Controls.Add(this.cbClientes);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Resurtimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resurtimiento";
            this.Load += new System.EventHandler(this.Resurtimiento_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox cbClientes;
        private MetroFramework.Controls.MetroCheckBox chbOpcion;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnPrint;
        public MetroFramework.Controls.MetroProgressBar pbResurtimiento;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.CheckedListBox clbOrdenTrabajo;
        private System.Windows.Forms.DateTimePicker dtpFechaI;
        private System.Windows.Forms.DateTimePicker dtpFechaF;
        private MetroFramework.Controls.MetroTextBox tbOrdenTrabajo;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private System.Windows.Forms.DateTimePicker dtpFechaOC;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
    }
}