namespace PLM.Vista
{
    partial class TrimsVista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrimsVista));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelBuscar = new System.Windows.Forms.Panel();
            this.btnBuscar = new MetroFramework.Controls.MetroButton();
            this.txtBusqueda = new MetroFramework.Controls.MetroTextBox();
            this.lblBusqueda = new MetroFramework.Controls.MetroLabel();
            this.panelAccion = new System.Windows.Forms.Panel();
            this.btnEliminar = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnAtras = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnActualizar = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnAlta = new Bunifu.Framework.UI.BunifuTileButton();
            this.cmbDepartamentos = new MetroFramework.Controls.MetroComboBox();
            this.cmbSegmentos = new MetroFramework.Controls.MetroComboBox();
            this.txtSecuencia = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.lblSegmento = new MetroFramework.Controls.MetroLabel();
            this.lblDepartamento = new MetroFramework.Controls.MetroLabel();
            this.dtDatos = new System.Windows.Forms.DataGridView();
            this.txtDescripcion = new MetroFramework.Controls.MetroTextBox();
            this.txtIdTrim = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.lblIdTrims = new MetroFramework.Controls.MetroLabel();
            this.panelMenu.SuspendLayout();
            this.panelBuscar.SuspendLayout();
            this.panelAccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.panelBuscar);
            this.panelMenu.Controls.Add(this.panelAccion);
            this.panelMenu.Controls.Add(this.cmbDepartamentos);
            this.panelMenu.Controls.Add(this.cmbSegmentos);
            this.panelMenu.Controls.Add(this.txtSecuencia);
            this.panelMenu.Controls.Add(this.metroLabel4);
            this.panelMenu.Controls.Add(this.lblSegmento);
            this.panelMenu.Controls.Add(this.lblDepartamento);
            this.panelMenu.Controls.Add(this.dtDatos);
            this.panelMenu.Controls.Add(this.txtDescripcion);
            this.panelMenu.Controls.Add(this.txtIdTrim);
            this.panelMenu.Controls.Add(this.metroLabel2);
            this.panelMenu.Controls.Add(this.lblIdTrims);
            this.panelMenu.Location = new System.Drawing.Point(23, 63);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1234, 725);
            this.panelMenu.TabIndex = 0;
            // 
            // panelBuscar
            // 
            this.panelBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBuscar.Controls.Add(this.btnBuscar);
            this.panelBuscar.Controls.Add(this.txtBusqueda);
            this.panelBuscar.Controls.Add(this.lblBusqueda);
            this.panelBuscar.Location = new System.Drawing.Point(891, 136);
            this.panelBuscar.Name = "panelBuscar";
            this.panelBuscar.Size = new System.Drawing.Size(289, 65);
            this.panelBuscar.TabIndex = 75;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.BackgroundImage")));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscar.Location = new System.Drawing.Point(256, 39);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(30, 23);
            this.btnBuscar.TabIndex = 43;
            this.btnBuscar.UseSelectable = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBusqueda
            // 
            // 
            // 
            // 
            this.txtBusqueda.CustomButton.Image = null;
            this.txtBusqueda.CustomButton.Location = new System.Drawing.Point(129, 1);
            this.txtBusqueda.CustomButton.Name = "";
            this.txtBusqueda.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtBusqueda.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBusqueda.CustomButton.TabIndex = 1;
            this.txtBusqueda.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBusqueda.CustomButton.UseSelectable = true;
            this.txtBusqueda.CustomButton.Visible = false;
            this.txtBusqueda.Lines = new string[0];
            this.txtBusqueda.Location = new System.Drawing.Point(99, 39);
            this.txtBusqueda.MaxLength = 32767;
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.PasswordChar = '\0';
            this.txtBusqueda.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBusqueda.SelectedText = "";
            this.txtBusqueda.SelectionLength = 0;
            this.txtBusqueda.SelectionStart = 0;
            this.txtBusqueda.ShortcutsEnabled = true;
            this.txtBusqueda.Size = new System.Drawing.Size(151, 23);
            this.txtBusqueda.TabIndex = 42;
            this.txtBusqueda.UseSelectable = true;
            this.txtBusqueda.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBusqueda.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtBusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBusqueda_KeyDown);
            // 
            // lblBusqueda
            // 
            this.lblBusqueda.AutoSize = true;
            this.lblBusqueda.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblBusqueda.Location = new System.Drawing.Point(24, 41);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Size = new System.Drawing.Size(69, 19);
            this.lblBusqueda.TabIndex = 41;
            this.lblBusqueda.Text = "Busqueda";
            // 
            // panelAccion
            // 
            this.panelAccion.Controls.Add(this.btnEliminar);
            this.panelAccion.Controls.Add(this.btnAtras);
            this.panelAccion.Controls.Add(this.btnActualizar);
            this.panelAccion.Controls.Add(this.btnAlta);
            this.panelAccion.Location = new System.Drawing.Point(21, 59);
            this.panelAccion.Name = "panelAccion";
            this.panelAccion.Size = new System.Drawing.Size(568, 148);
            this.panelAccion.TabIndex = 58;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.color = System.Drawing.Color.Transparent;
            this.btnEliminar.colorActive = System.Drawing.Color.Transparent;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnEliminar.Image = global::PLM.Properties.Resources.Delete;
            this.btnEliminar.ImagePosition = 25;
            this.btnEliminar.ImageZoom = 50;
            this.btnEliminar.LabelPosition = 51;
            this.btnEliminar.LabelText = "Eliminar";
            this.btnEliminar.Location = new System.Drawing.Point(426, 0);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(6);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(130, 142);
            this.btnEliminar.TabIndex = 26;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.Transparent;
            this.btnAtras.color = System.Drawing.Color.Transparent;
            this.btnAtras.colorActive = System.Drawing.Color.Transparent;
            this.btnAtras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtras.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnAtras.Image = global::PLM.Properties.Resources.Atras;
            this.btnAtras.ImagePosition = 25;
            this.btnAtras.ImageZoom = 50;
            this.btnAtras.LabelPosition = 51;
            this.btnAtras.LabelText = "Atras";
            this.btnAtras.Location = new System.Drawing.Point(0, 0);
            this.btnAtras.Margin = new System.Windows.Forms.Padding(6);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(130, 142);
            this.btnAtras.TabIndex = 23;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.Transparent;
            this.btnActualizar.color = System.Drawing.Color.Transparent;
            this.btnActualizar.colorActive = System.Drawing.Color.Transparent;
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnActualizar.Image = global::PLM.Properties.Resources.Save;
            this.btnActualizar.ImagePosition = 25;
            this.btnActualizar.ImageZoom = 50;
            this.btnActualizar.LabelPosition = 51;
            this.btnActualizar.LabelText = "Guardar";
            this.btnActualizar.Location = new System.Drawing.Point(284, 0);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(6);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(130, 142);
            this.btnActualizar.TabIndex = 25;
            this.btnActualizar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAlta
            // 
            this.btnAlta.BackColor = System.Drawing.Color.Transparent;
            this.btnAlta.color = System.Drawing.Color.Transparent;
            this.btnAlta.colorActive = System.Drawing.Color.Transparent;
            this.btnAlta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlta.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlta.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnAlta.Image = global::PLM.Properties.Resources.Nuevo;
            this.btnAlta.ImagePosition = 25;
            this.btnAlta.ImageZoom = 50;
            this.btnAlta.LabelPosition = 51;
            this.btnAlta.LabelText = "Nuevo";
            this.btnAlta.Location = new System.Drawing.Point(142, 0);
            this.btnAlta.Margin = new System.Windows.Forms.Padding(6);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(130, 142);
            this.btnAlta.TabIndex = 24;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click_1);
            // 
            // cmbDepartamentos
            // 
            this.cmbDepartamentos.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cmbDepartamentos.FormattingEnabled = true;
            this.cmbDepartamentos.ItemHeight = 19;
            this.cmbDepartamentos.Location = new System.Drawing.Point(564, 570);
            this.cmbDepartamentos.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.cmbDepartamentos.Name = "cmbDepartamentos";
            this.cmbDepartamentos.Size = new System.Drawing.Size(151, 25);
            this.cmbDepartamentos.Style = MetroFramework.MetroColorStyle.Green;
            this.cmbDepartamentos.TabIndex = 52;
            this.cmbDepartamentos.UseSelectable = true;
            // 
            // cmbSegmentos
            // 
            this.cmbSegmentos.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cmbSegmentos.FormattingEnabled = true;
            this.cmbSegmentos.ItemHeight = 19;
            this.cmbSegmentos.Location = new System.Drawing.Point(738, 570);
            this.cmbSegmentos.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.cmbSegmentos.Name = "cmbSegmentos";
            this.cmbSegmentos.Size = new System.Drawing.Size(151, 25);
            this.cmbSegmentos.Style = MetroFramework.MetroColorStyle.Green;
            this.cmbSegmentos.TabIndex = 51;
            this.cmbSegmentos.UseSelectable = true;
            // 
            // txtSecuencia
            // 
            // 
            // 
            // 
            this.txtSecuencia.CustomButton.Image = null;
            this.txtSecuencia.CustomButton.Location = new System.Drawing.Point(46, 1);
            this.txtSecuencia.CustomButton.Name = "";
            this.txtSecuencia.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtSecuencia.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSecuencia.CustomButton.TabIndex = 1;
            this.txtSecuencia.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSecuencia.CustomButton.UseSelectable = true;
            this.txtSecuencia.CustomButton.Visible = false;
            this.txtSecuencia.Lines = new string[0];
            this.txtSecuencia.Location = new System.Drawing.Point(917, 572);
            this.txtSecuencia.Margin = new System.Windows.Forms.Padding(8, 8, 20, 8);
            this.txtSecuencia.MaxLength = 10;
            this.txtSecuencia.Name = "txtSecuencia";
            this.txtSecuencia.PasswordChar = '\0';
            this.txtSecuencia.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSecuencia.SelectedText = "";
            this.txtSecuencia.SelectionLength = 0;
            this.txtSecuencia.SelectionStart = 0;
            this.txtSecuencia.ShortcutsEnabled = true;
            this.txtSecuencia.Size = new System.Drawing.Size(68, 23);
            this.txtSecuencia.TabIndex = 50;
            this.txtSecuencia.UseSelectable = true;
            this.txtSecuencia.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSecuencia.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(917, 545);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(68, 19);
            this.metroLabel4.TabIndex = 49;
            this.metroLabel4.Text = "Secuencia";
            // 
            // lblSegmento
            // 
            this.lblSegmento.AutoSize = true;
            this.lblSegmento.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblSegmento.Location = new System.Drawing.Point(738, 545);
            this.lblSegmento.Name = "lblSegmento";
            this.lblSegmento.Size = new System.Drawing.Size(71, 19);
            this.lblSegmento.TabIndex = 48;
            this.lblSegmento.Text = "Segmento";
            // 
            // lblDepartamento
            // 
            this.lblDepartamento.AutoSize = true;
            this.lblDepartamento.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblDepartamento.Location = new System.Drawing.Point(564, 545);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new System.Drawing.Size(98, 19);
            this.lblDepartamento.TabIndex = 47;
            this.lblDepartamento.Text = "Departamento";
            // 
            // dtDatos
            // 
            this.dtDatos.AllowUserToAddRows = false;
            this.dtDatos.AllowUserToDeleteRows = false;
            this.dtDatos.BackgroundColor = System.Drawing.Color.White;
            this.dtDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtDatos.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtDatos.Location = new System.Drawing.Point(45, 213);
            this.dtDatos.Name = "dtDatos";
            this.dtDatos.ReadOnly = true;
            this.dtDatos.Size = new System.Drawing.Size(1135, 312);
            this.dtDatos.TabIndex = 40;
            this.dtDatos.SelectionChanged += new System.EventHandler(this.dtDatos_SelectionChanged);
            // 
            // txtDescripcion
            // 
            // 
            // 
            // 
            this.txtDescripcion.CustomButton.Image = null;
            this.txtDescripcion.CustomButton.Location = new System.Drawing.Point(129, 1);
            this.txtDescripcion.CustomButton.Name = "";
            this.txtDescripcion.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtDescripcion.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDescripcion.CustomButton.TabIndex = 1;
            this.txtDescripcion.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDescripcion.CustomButton.UseSelectable = true;
            this.txtDescripcion.CustomButton.Visible = false;
            this.txtDescripcion.Lines = new string[0];
            this.txtDescripcion.Location = new System.Drawing.Point(390, 572);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(8, 8, 20, 8);
            this.txtDescripcion.MaxLength = 25;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.PasswordChar = '\0';
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDescripcion.SelectedText = "";
            this.txtDescripcion.SelectionLength = 0;
            this.txtDescripcion.SelectionStart = 0;
            this.txtDescripcion.ShortcutsEnabled = true;
            this.txtDescripcion.Size = new System.Drawing.Size(151, 23);
            this.txtDescripcion.TabIndex = 46;
            this.txtDescripcion.UseSelectable = true;
            this.txtDescripcion.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDescripcion.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtIdTrim
            // 
            // 
            // 
            // 
            this.txtIdTrim.CustomButton.Image = null;
            this.txtIdTrim.CustomButton.Location = new System.Drawing.Point(129, 1);
            this.txtIdTrim.CustomButton.Name = "";
            this.txtIdTrim.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtIdTrim.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtIdTrim.CustomButton.TabIndex = 1;
            this.txtIdTrim.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtIdTrim.CustomButton.UseSelectable = true;
            this.txtIdTrim.CustomButton.Visible = false;
            this.txtIdTrim.Lines = new string[0];
            this.txtIdTrim.Location = new System.Drawing.Point(211, 572);
            this.txtIdTrim.Margin = new System.Windows.Forms.Padding(8, 8, 20, 8);
            this.txtIdTrim.MaxLength = 10;
            this.txtIdTrim.Name = "txtIdTrim";
            this.txtIdTrim.PasswordChar = '\0';
            this.txtIdTrim.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtIdTrim.SelectedText = "";
            this.txtIdTrim.SelectionLength = 0;
            this.txtIdTrim.SelectionStart = 0;
            this.txtIdTrim.ShortcutsEnabled = true;
            this.txtIdTrim.Size = new System.Drawing.Size(151, 23);
            this.txtIdTrim.TabIndex = 44;
            this.txtIdTrim.UseSelectable = true;
            this.txtIdTrim.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtIdTrim.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(390, 545);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(79, 19);
            this.metroLabel2.TabIndex = 45;
            this.metroLabel2.Text = "Descripción";
            // 
            // lblIdTrims
            // 
            this.lblIdTrims.AutoSize = true;
            this.lblIdTrims.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblIdTrims.Location = new System.Drawing.Point(211, 545);
            this.lblIdTrims.Name = "lblIdTrims";
            this.lblIdTrims.Size = new System.Drawing.Size(54, 19);
            this.lblIdTrims.TabIndex = 43;
            this.lblIdTrims.Text = "Id-Trim";
            // 
            // TrimsVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TrimsVista";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Catálogo Trims";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TrimsVista_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelBuscar.ResumeLayout(false);
            this.panelBuscar.PerformLayout();
            this.panelAccion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private MetroFramework.Controls.MetroComboBox cmbDepartamentos;
        private MetroFramework.Controls.MetroComboBox cmbSegmentos;
        private MetroFramework.Controls.MetroTextBox txtSecuencia;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel lblSegmento;
        private MetroFramework.Controls.MetroLabel lblDepartamento;
        private System.Windows.Forms.DataGridView dtDatos;
        private MetroFramework.Controls.MetroTextBox txtDescripcion;
        private MetroFramework.Controls.MetroTextBox txtIdTrim;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel lblIdTrims;
        private System.Windows.Forms.Panel panelAccion;
        private Bunifu.Framework.UI.BunifuTileButton btnEliminar;
        private Bunifu.Framework.UI.BunifuTileButton btnAtras;
        private Bunifu.Framework.UI.BunifuTileButton btnActualizar;
        private Bunifu.Framework.UI.BunifuTileButton btnAlta;
        private System.Windows.Forms.Panel panelBuscar;
        private MetroFramework.Controls.MetroButton btnBuscar;
        private MetroFramework.Controls.MetroTextBox txtBusqueda;
        private MetroFramework.Controls.MetroLabel lblBusqueda;
    }
}