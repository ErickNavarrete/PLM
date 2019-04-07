namespace PLM.Vista.BOM
{
    partial class BomTarea
    {/// <summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BomTarea));
            this.grbEstilos = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new MetroFramework.Controls.MetroButton();
            this.btnDetalleUsu = new MetroFramework.Controls.MetroButton();
            this.txtPO = new MetroFramework.Controls.MetroTextBox();
            this.txtHilos = new MetroFramework.Controls.MetroTextBox();
            this.lblStatus = new MetroFramework.Controls.MetroLabel();
            this.lblEtapa = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtEstilo = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtNroBom = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtBOM = new System.Windows.Forms.DataGridView();
            this.SEGMENTOS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS = new System.Windows.Forms.DataGridViewImageColumn();
            this.TRIM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEM_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CATEGORY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROVEEDOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CANTIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COSTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOTAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbAcción = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new MetroFramework.Controls.MetroButton();
            this.btnCancelar = new MetroFramework.Controls.MetroButton();
            this.grbEstilos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtBOM)).BeginInit();
            this.grbAcción.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbEstilos
            // 
            this.grbEstilos.Controls.Add(this.btnBuscar);
            this.grbEstilos.Controls.Add(this.btnDetalleUsu);
            this.grbEstilos.Controls.Add(this.txtPO);
            this.grbEstilos.Controls.Add(this.txtHilos);
            this.grbEstilos.Controls.Add(this.lblStatus);
            this.grbEstilos.Controls.Add(this.lblEtapa);
            this.grbEstilos.Controls.Add(this.metroLabel6);
            this.grbEstilos.Controls.Add(this.metroLabel10);
            this.grbEstilos.Controls.Add(this.metroLabel9);
            this.grbEstilos.Controls.Add(this.metroLabel8);
            this.grbEstilos.Controls.Add(this.metroLabel5);
            this.grbEstilos.Controls.Add(this.metroLabel4);
            this.grbEstilos.Controls.Add(this.metroLabel3);
            this.grbEstilos.Controls.Add(this.txtEstilo);
            this.grbEstilos.Controls.Add(this.metroLabel2);
            this.grbEstilos.Controls.Add(this.txtNroBom);
            this.grbEstilos.Controls.Add(this.metroLabel1);
            this.grbEstilos.Location = new System.Drawing.Point(23, 78);
            this.grbEstilos.Name = "grbEstilos";
            this.grbEstilos.Size = new System.Drawing.Size(1115, 153);
            this.grbEstilos.TabIndex = 1;
            this.grbEstilos.TabStop = false;
            this.grbEstilos.Text = "Registro PLM";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.BackgroundImage")));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscar.Location = new System.Drawing.Point(250, 92);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(30, 23);
            this.btnBuscar.TabIndex = 52;
            this.btnBuscar.UseSelectable = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnDetalleUsu
            // 
            this.btnDetalleUsu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDetalleUsu.BackgroundImage")));
            this.btnDetalleUsu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDetalleUsu.Location = new System.Drawing.Point(524, 90);
            this.btnDetalleUsu.Name = "btnDetalleUsu";
            this.btnDetalleUsu.Size = new System.Drawing.Size(30, 23);
            this.btnDetalleUsu.TabIndex = 51;
            this.btnDetalleUsu.UseSelectable = true;
            this.btnDetalleUsu.Click += new System.EventHandler(this.btnDetalleUsu_Click);
            // 
            // txtPO
            // 
            // 
            // 
            // 
            this.txtPO.CustomButton.Image = null;
            this.txtPO.CustomButton.Location = new System.Drawing.Point(68, 1);
            this.txtPO.CustomButton.Name = "";
            this.txtPO.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPO.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPO.CustomButton.TabIndex = 1;
            this.txtPO.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPO.CustomButton.UseSelectable = true;
            this.txtPO.CustomButton.Visible = false;
            this.txtPO.Lines = new string[0];
            this.txtPO.Location = new System.Drawing.Point(1009, 65);
            this.txtPO.Margin = new System.Windows.Forms.Padding(5);
            this.txtPO.MaxLength = 32767;
            this.txtPO.Name = "txtPO";
            this.txtPO.PasswordChar = '\0';
            this.txtPO.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPO.SelectedText = "";
            this.txtPO.SelectionLength = 0;
            this.txtPO.SelectionStart = 0;
            this.txtPO.ShortcutsEnabled = true;
            this.txtPO.Size = new System.Drawing.Size(90, 23);
            this.txtPO.TabIndex = 50;
            this.txtPO.UseSelectable = true;
            this.txtPO.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPO.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtHilos
            // 
            // 
            // 
            // 
            this.txtHilos.CustomButton.Image = null;
            this.txtHilos.CustomButton.Location = new System.Drawing.Point(68, 1);
            this.txtHilos.CustomButton.Name = "";
            this.txtHilos.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtHilos.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtHilos.CustomButton.TabIndex = 1;
            this.txtHilos.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtHilos.CustomButton.UseSelectable = true;
            this.txtHilos.CustomButton.Visible = false;
            this.txtHilos.Lines = new string[0];
            this.txtHilos.Location = new System.Drawing.Point(1009, 98);
            this.txtHilos.Margin = new System.Windows.Forms.Padding(5);
            this.txtHilos.MaxLength = 32767;
            this.txtHilos.Name = "txtHilos";
            this.txtHilos.PasswordChar = '\0';
            this.txtHilos.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtHilos.SelectedText = "";
            this.txtHilos.SelectionLength = 0;
            this.txtHilos.SelectionStart = 0;
            this.txtHilos.ShortcutsEnabled = true;
            this.txtHilos.Size = new System.Drawing.Size(90, 23);
            this.txtHilos.TabIndex = 49;
            this.txtHilos.UseSelectable = true;
            this.txtHilos.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtHilos.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(1005, 36);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(5);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 0);
            this.lblStatus.TabIndex = 48;
            // 
            // lblEtapa
            // 
            this.lblEtapa.AutoSize = true;
            this.lblEtapa.Location = new System.Drawing.Point(1005, 12);
            this.lblEtapa.Margin = new System.Windows.Forms.Padding(5);
            this.lblEtapa.Name = "lblEtapa";
            this.lblEtapa.Size = new System.Drawing.Size(0, 0);
            this.lblEtapa.TabIndex = 47;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel6.Location = new System.Drawing.Point(351, 90);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(172, 25);
            this.metroLabel6.TabIndex = 45;
            this.metroLabel6.Text = "DETALLE USUARIO";
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(933, 127);
            this.metroLabel10.Margin = new System.Windows.Forms.Padding(5);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(50, 19);
            this.metroLabel10.TabIndex = 44;
            this.metroLabel10.Text = "NOTAS";
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(933, 98);
            this.metroLabel9.Margin = new System.Windows.Forms.Padding(5);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(44, 19);
            this.metroLabel9.TabIndex = 43;
            this.metroLabel9.Text = "HILOS";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(933, 65);
            this.metroLabel8.Margin = new System.Windows.Forms.Padding(5);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(28, 19);
            this.metroLabel8.TabIndex = 42;
            this.metroLabel8.Text = "PO";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(933, 36);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(5);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(51, 19);
            this.metroLabel5.TabIndex = 39;
            this.metroLabel5.Text = "STATUS";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(933, 12);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(5);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(45, 19);
            this.metroLabel4.TabIndex = 38;
            this.metroLabel4.Text = "ETAPA";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(50, 90);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(198, 25);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "CONSULTA DE ESTILO";
            // 
            // txtEstilo
            // 
            // 
            // 
            // 
            this.txtEstilo.CustomButton.Image = null;
            this.txtEstilo.CustomButton.Location = new System.Drawing.Point(137, 1);
            this.txtEstilo.CustomButton.Name = "";
            this.txtEstilo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtEstilo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtEstilo.CustomButton.TabIndex = 1;
            this.txtEstilo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtEstilo.CustomButton.UseSelectable = true;
            this.txtEstilo.CustomButton.Visible = false;
            this.txtEstilo.Lines = new string[0];
            this.txtEstilo.Location = new System.Drawing.Point(395, 42);
            this.txtEstilo.MaxLength = 32767;
            this.txtEstilo.Name = "txtEstilo";
            this.txtEstilo.PasswordChar = '\0';
            this.txtEstilo.PromptText = "Presiona F3 para busqueda";
            this.txtEstilo.ReadOnly = true;
            this.txtEstilo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEstilo.SelectedText = "";
            this.txtEstilo.SelectionLength = 0;
            this.txtEstilo.SelectionStart = 0;
            this.txtEstilo.ShortcutsEnabled = true;
            this.txtEstilo.Size = new System.Drawing.Size(159, 23);
            this.txtEstilo.TabIndex = 3;
            this.txtEstilo.UseSelectable = true;
            this.txtEstilo.WaterMark = "Presiona F3 para busqueda";
            this.txtEstilo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtEstilo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(332, 44);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(57, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "ID-Estilo";
            // 
            // txtNroBom
            // 
            // 
            // 
            // 
            this.txtNroBom.CustomButton.Image = null;
            this.txtNroBom.CustomButton.Location = new System.Drawing.Point(137, 1);
            this.txtNroBom.CustomButton.Name = "";
            this.txtNroBom.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtNroBom.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNroBom.CustomButton.TabIndex = 1;
            this.txtNroBom.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNroBom.CustomButton.UseSelectable = true;
            this.txtNroBom.CustomButton.Visible = false;
            this.txtNroBom.Lines = new string[0];
            this.txtNroBom.Location = new System.Drawing.Point(121, 42);
            this.txtNroBom.MaxLength = 32767;
            this.txtNroBom.Name = "txtNroBom";
            this.txtNroBom.PasswordChar = '\0';
            this.txtNroBom.PromptText = "Generación automatica";
            this.txtNroBom.ReadOnly = true;
            this.txtNroBom.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNroBom.SelectedText = "";
            this.txtNroBom.SelectionLength = 0;
            this.txtNroBom.SelectionStart = 0;
            this.txtNroBom.ShortcutsEnabled = true;
            this.txtNroBom.Size = new System.Drawing.Size(159, 23);
            this.txtNroBom.TabIndex = 1;
            this.txtNroBom.UseSelectable = true;
            this.txtNroBom.WaterMark = "Generación automatica";
            this.txtNroBom.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNroBom.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(32, 44);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(86, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Nro de BOM";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtBOM);
            this.groupBox1.Location = new System.Drawing.Point(23, 237);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1118, 165);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " BOM ";
            // 
            // DtBOM
            // 
            this.DtBOM.AllowUserToAddRows = false;
            this.DtBOM.AllowUserToDeleteRows = false;
            this.DtBOM.BackgroundColor = System.Drawing.Color.White;
            this.DtBOM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtBOM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SEGMENTOS,
            this.STATUS,
            this.TRIM,
            this.ITEM_CODE,
            this.CATEGORY,
            this.DESCRIPCION,
            this.COLOR,
            this.PROVEEDOR,
            this.CANTIDAD,
            this.COSTO,
            this.UM,
            this.NOTAS});
            this.DtBOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtBOM.Location = new System.Drawing.Point(3, 16);
            this.DtBOM.Name = "DtBOM";
            this.DtBOM.Size = new System.Drawing.Size(1112, 146);
            this.DtBOM.TabIndex = 0;
            this.DtBOM.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtBOM_CellContentClick);
            this.DtBOM.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtBOM_CellContentClick_1);
            // 
            // SEGMENTOS
            // 
            this.SEGMENTOS.HeaderText = "SEGMENTOS";
            this.SEGMENTOS.Name = "SEGMENTOS";
            this.SEGMENTOS.ReadOnly = true;
            // 
            // STATUS
            // 
            this.STATUS.HeaderText = "ESTADO";
            this.STATUS.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.STATUS.Name = "STATUS";
            this.STATUS.ReadOnly = true;
            // 
            // TRIM
            // 
            this.TRIM.HeaderText = "TRIM";
            this.TRIM.Name = "TRIM";
            this.TRIM.ReadOnly = true;
            // 
            // ITEM_CODE
            // 
            this.ITEM_CODE.HeaderText = "ITEM CODE";
            this.ITEM_CODE.Name = "ITEM_CODE";
            this.ITEM_CODE.ReadOnly = true;
            // 
            // CATEGORY
            // 
            this.CATEGORY.HeaderText = "CATEGORY";
            this.CATEGORY.Name = "CATEGORY";
            this.CATEGORY.ReadOnly = true;
            // 
            // DESCRIPCION
            // 
            this.DESCRIPCION.HeaderText = "DESCRIPCION";
            this.DESCRIPCION.Name = "DESCRIPCION";
            this.DESCRIPCION.ReadOnly = true;
            // 
            // COLOR
            // 
            this.COLOR.HeaderText = "COLOR";
            this.COLOR.Name = "COLOR";
            this.COLOR.ReadOnly = true;
            // 
            // PROVEEDOR
            // 
            this.PROVEEDOR.HeaderText = "PROVEEDOR";
            this.PROVEEDOR.Name = "PROVEEDOR";
            this.PROVEEDOR.ReadOnly = true;
            // 
            // CANTIDAD
            // 
            this.CANTIDAD.HeaderText = "CANTIDAD";
            this.CANTIDAD.Name = "CANTIDAD";
            this.CANTIDAD.ReadOnly = true;
            // 
            // COSTO
            // 
            this.COSTO.HeaderText = "COSTO";
            this.COSTO.Name = "COSTO";
            this.COSTO.ReadOnly = true;
            // 
            // UM
            // 
            this.UM.HeaderText = "UM";
            this.UM.Name = "UM";
            this.UM.ReadOnly = true;
            // 
            // NOTAS
            // 
            this.NOTAS.HeaderText = "NOTAS";
            this.NOTAS.Name = "NOTAS";
            this.NOTAS.ReadOnly = true;
            // 
            // grbAcción
            // 
            this.grbAcción.Controls.Add(this.btnGuardar);
            this.grbAcción.Controls.Add(this.btnCancelar);
            this.grbAcción.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grbAcción.Location = new System.Drawing.Point(20, 424);
            this.grbAcción.Name = "grbAcción";
            this.grbAcción.Size = new System.Drawing.Size(1127, 72);
            this.grbAcción.TabIndex = 3;
            this.grbAcción.TabStop = false;
            this.grbAcción.Text = "Acción";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(832, 22);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(132, 38);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseSelectable = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(970, 22);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(132, 38);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseSelectable = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // BomTarea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 516);
            this.Controls.Add(this.grbAcción);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbEstilos);
            this.MaximizeBox = false;
            this.Name = "BomTarea";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "BOM";
            this.Load += new System.EventHandler(this.BomTarea_Load);
            this.grbEstilos.ResumeLayout(false);
            this.grbEstilos.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtBOM)).EndInit();
            this.grbAcción.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbEstilos;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtEstilo;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtNroBom;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DtBOM;
        private System.Windows.Forms.GroupBox grbAcción;
        private MetroFramework.Controls.MetroButton btnCancelar;
        private MetroFramework.Controls.MetroButton btnGuardar;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel lblStatus;
        private MetroFramework.Controls.MetroLabel lblEtapa;
        private MetroFramework.Controls.MetroTextBox txtPO;
        private MetroFramework.Controls.MetroTextBox txtHilos;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEGMENTOS;
        private System.Windows.Forms.DataGridViewImageColumn STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRIM;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEM_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CATEGORY;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPCION;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROVEEDOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANTIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn COSTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn UM;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOTAS;
        private MetroFramework.Controls.MetroButton btnBuscar;
        private MetroFramework.Controls.MetroButton btnDetalleUsu;
    }
}