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
            this.dtpFechaI = new MetroFramework.Controls.MetroDateTime();
            this.dtpFechaF = new MetroFramework.Controls.MetroDateTime();
            this.cbClientes = new MetroFramework.Controls.MetroComboBox();
            this.chbOpcion = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.dtpFechaOC = new MetroFramework.Controls.MetroDateTime();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
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
            this.metroLabel2.Location = new System.Drawing.Point(301, 62);
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
            // dtpFechaI
            // 
            this.dtpFechaI.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaI.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaI.Location = new System.Drawing.Point(96, 54);
            this.dtpFechaI.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtpFechaI.Name = "dtpFechaI";
            this.dtpFechaI.Size = new System.Drawing.Size(180, 29);
            this.dtpFechaI.TabIndex = 6;
            // 
            // dtpFechaF
            // 
            this.dtpFechaF.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaF.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaF.Location = new System.Drawing.Point(374, 58);
            this.dtpFechaF.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtpFechaF.Name = "dtpFechaF";
            this.dtpFechaF.Size = new System.Drawing.Size(180, 29);
            this.dtpFechaF.TabIndex = 7;
            // 
            // cbClientes
            // 
            this.cbClientes.FormattingEnabled = true;
            this.cbClientes.ItemHeight = 23;
            this.cbClientes.Location = new System.Drawing.Point(96, 101);
            this.cbClientes.Name = "cbClientes";
            this.cbClientes.Size = new System.Drawing.Size(386, 29);
            this.cbClientes.TabIndex = 8;
            this.cbClientes.UseSelectable = true;
            // 
            // chbOpcion
            // 
            this.chbOpcion.AutoSize = true;
            this.chbOpcion.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chbOpcion.Location = new System.Drawing.Point(520, 101);
            this.chbOpcion.Name = "chbOpcion";
            this.chbOpcion.Size = new System.Drawing.Size(60, 19);
            this.chbOpcion.TabIndex = 9;
            this.chbOpcion.Text = "Todas";
            this.chbOpcion.UseSelectable = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(22, 212);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(70, 19);
            this.metroLabel4.TabIndex = 10;
            this.metroLabel4.Text = "Fecha OC:";
            // 
            // dtpFechaOC
            // 
            this.dtpFechaOC.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaOC.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaOC.Location = new System.Drawing.Point(96, 212);
            this.dtpFechaOC.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtpFechaOC.Name = "dtpFechaOC";
            this.dtpFechaOC.Size = new System.Drawing.Size(180, 29);
            this.dtpFechaOC.TabIndex = 11;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrint});
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
            // 
            // Resurtimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 293);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dtpFechaOC);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.chbOpcion);
            this.Controls.Add(this.cbClientes);
            this.Controls.Add(this.dtpFechaF);
            this.Controls.Add(this.dtpFechaI);
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
        private MetroFramework.Controls.MetroDateTime dtpFechaI;
        private MetroFramework.Controls.MetroDateTime dtpFechaF;
        private MetroFramework.Controls.MetroComboBox cbClientes;
        private MetroFramework.Controls.MetroCheckBox chbOpcion;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroDateTime dtpFechaOC;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnPrint;
    }
}