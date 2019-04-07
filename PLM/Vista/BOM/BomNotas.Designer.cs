namespace PLM.Vista.BOM
{
    partial class BomNotas
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
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnGuardar = new DevComponents.DotNetBar.ButtonItem();
            this.btnCancelar = new DevComponents.DotNetBar.ButtonItem();
            this.grbNota = new System.Windows.Forms.GroupBox();
            this.txtNota = new MetroFramework.Controls.MetroTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.grbNota.SuspendLayout();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AccessibleDescription = "bar1 (bar1)";
            this.bar1.AccessibleName = "bar1";
            this.bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.bar1.AntiAlias = true;
            this.bar1.BackColor = System.Drawing.Color.Transparent;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnGuardar,
            this.btnCancelar});
            this.bar1.Location = new System.Drawing.Point(20, 60);
            this.bar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(797, 75);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 18;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::PLM.Properties.Resources.SaveTool;
            this.btnGuardar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Tag = "1";
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::PLM.Properties.Resources.Cancel;
            this.btnCancelar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Tag = "1";
            this.btnCancelar.Text = "Cancelar";
            // 
            // grbNota
            // 
            this.grbNota.Controls.Add(this.txtNota);
            this.grbNota.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbNota.Location = new System.Drawing.Point(20, 135);
            this.grbNota.Name = "grbNota";
            this.grbNota.Size = new System.Drawing.Size(797, 368);
            this.grbNota.TabIndex = 19;
            this.grbNota.TabStop = false;
            this.grbNota.Text = " Ingrese una nota para el BOM";
            // 
            // txtNota
            // 
            // 
            // 
            // 
            this.txtNota.CustomButton.Image = null;
            this.txtNota.CustomButton.Location = new System.Drawing.Point(443, 1);
            this.txtNota.CustomButton.Name = "";
            this.txtNota.CustomButton.Size = new System.Drawing.Size(347, 347);
            this.txtNota.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNota.CustomButton.TabIndex = 1;
            this.txtNota.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNota.CustomButton.UseSelectable = true;
            this.txtNota.CustomButton.Visible = false;
            this.txtNota.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNota.Lines = new string[0];
            this.txtNota.Location = new System.Drawing.Point(3, 16);
            this.txtNota.MaxLength = 32767;
            this.txtNota.Multiline = true;
            this.txtNota.Name = "txtNota";
            this.txtNota.PasswordChar = '\0';
            this.txtNota.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNota.SelectedText = "";
            this.txtNota.SelectionLength = 0;
            this.txtNota.SelectionStart = 0;
            this.txtNota.ShortcutsEnabled = true;
            this.txtNota.Size = new System.Drawing.Size(791, 349);
            this.txtNota.TabIndex = 37;
            this.txtNota.UseSelectable = true;
            this.txtNota.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNota.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // BomNotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 523);
            this.Controls.Add(this.grbNota);
            this.Controls.Add(this.bar1);
            this.MaximizeBox = false;
            this.Name = "BomNotas";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Notas del BOM";
            this.Load += new System.EventHandler(this.DetalleUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.grbNota.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnGuardar;
        private DevComponents.DotNetBar.ButtonItem btnCancelar;
        private System.Windows.Forms.GroupBox grbNota;
        private MetroFramework.Controls.MetroTextBox txtNota;
    }
}