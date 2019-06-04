namespace PLM.Vista
{
    partial class SegundasVista
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SegundasVista));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelAccion = new System.Windows.Forms.Panel();
            this.btnEliminar = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnAtras = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnActualizar = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnAlta = new Bunifu.Framework.UI.BunifuTileButton();
            this.panelBuscar = new System.Windows.Forms.Panel();
            this.btnBuscar = new MetroFramework.Controls.MetroButton();
            this.txtBusqueda = new MetroFramework.Controls.MetroTextBox();
            this.lblBusqueda = new MetroFramework.Controls.MetroLabel();
            this.lblFalt = new MetroFramework.Controls.MetroLabel();
            this.lblAvios = new MetroFramework.Controls.MetroLabel();
            this.txtLav = new MetroFramework.Controls.MetroTextBox();
            this.dtDatos = new System.Windows.Forms.DataGridView();
            this.txtAvios = new MetroFramework.Controls.MetroTextBox();
            this.lblCliente = new MetroFramework.Controls.MetroLabel();
            this.txtFalt = new MetroFramework.Controls.MetroTextBox();
            this.txtCliente = new MetroFramework.Controls.MetroTextBox();
            this.txtConf = new MetroFramework.Controls.MetroTextBox();
            this.lblTela = new MetroFramework.Controls.MetroLabel();
            this.txtProc = new MetroFramework.Controls.MetroTextBox();
            this.txtTela = new MetroFramework.Controls.MetroTextBox();
            this.lblProc = new MetroFramework.Controls.MetroLabel();
            this.lblConf = new MetroFramework.Controls.MetroLabel();
            this.lblLav = new MetroFramework.Controls.MetroLabel();
            this.panelMenu.SuspendLayout();
            this.panelAccion.SuspendLayout();
            this.panelBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.panelAccion);
            this.panelMenu.Controls.Add(this.panelBuscar);
            this.panelMenu.Controls.Add(this.lblFalt);
            this.panelMenu.Controls.Add(this.lblAvios);
            this.panelMenu.Controls.Add(this.txtLav);
            this.panelMenu.Controls.Add(this.dtDatos);
            this.panelMenu.Controls.Add(this.txtAvios);
            this.panelMenu.Controls.Add(this.lblCliente);
            this.panelMenu.Controls.Add(this.txtFalt);
            this.panelMenu.Controls.Add(this.txtCliente);
            this.panelMenu.Controls.Add(this.txtConf);
            this.panelMenu.Controls.Add(this.lblTela);
            this.panelMenu.Controls.Add(this.txtProc);
            this.panelMenu.Controls.Add(this.txtTela);
            this.panelMenu.Controls.Add(this.lblProc);
            this.panelMenu.Controls.Add(this.lblConf);
            this.panelMenu.Controls.Add(this.lblLav);
            this.panelMenu.Location = new System.Drawing.Point(23, 63);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1234, 714);
            this.panelMenu.TabIndex = 0;
            // 
            // panelAccion
            // 
            this.panelAccion.Controls.Add(this.btnEliminar);
            this.panelAccion.Controls.Add(this.btnAtras);
            this.panelAccion.Controls.Add(this.btnActualizar);
            this.panelAccion.Controls.Add(this.btnAlta);
            this.panelAccion.Location = new System.Drawing.Point(21, 53);
            this.panelAccion.Name = "panelAccion";
            this.panelAccion.Size = new System.Drawing.Size(568, 148);
            this.panelAccion.TabIndex = 78;
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
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click_1);
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
            // panelBuscar
            // 
            this.panelBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBuscar.Controls.Add(this.btnBuscar);
            this.panelBuscar.Controls.Add(this.txtBusqueda);
            this.panelBuscar.Controls.Add(this.lblBusqueda);
            this.panelBuscar.Location = new System.Drawing.Point(891, 136);
            this.panelBuscar.Name = "panelBuscar";
            this.panelBuscar.Size = new System.Drawing.Size(289, 65);
            this.panelBuscar.TabIndex = 77;
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
            // lblFalt
            // 
            this.lblFalt.AutoSize = true;
            this.lblFalt.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblFalt.Location = new System.Drawing.Point(785, 542);
            this.lblFalt.Name = "lblFalt";
            this.lblFalt.Size = new System.Drawing.Size(31, 19);
            this.lblFalt.TabIndex = 33;
            this.lblFalt.Text = "Falt";
            // 
            // lblAvios
            // 
            this.lblAvios.AutoSize = true;
            this.lblAvios.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblAvios.Location = new System.Drawing.Point(722, 542);
            this.lblAvios.Name = "lblAvios";
            this.lblAvios.Size = new System.Drawing.Size(42, 19);
            this.lblAvios.TabIndex = 32;
            this.lblAvios.Text = "Avios";
            // 
            // txtLav
            // 
            // 
            // 
            // 
            this.txtLav.CustomButton.Image = null;
            this.txtLav.CustomButton.Location = new System.Drawing.Point(11, 1);
            this.txtLav.CustomButton.Name = "";
            this.txtLav.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtLav.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtLav.CustomButton.TabIndex = 1;
            this.txtLav.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtLav.CustomButton.UseSelectable = true;
            this.txtLav.CustomButton.Visible = false;
            this.txtLav.Lines = new string[0];
            this.txtLav.Location = new System.Drawing.Point(600, 569);
            this.txtLav.Margin = new System.Windows.Forms.Padding(8, 8, 20, 8);
            this.txtLav.MaxLength = 10;
            this.txtLav.Name = "txtLav";
            this.txtLav.PasswordChar = '\0';
            this.txtLav.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtLav.SelectedText = "";
            this.txtLav.SelectionLength = 0;
            this.txtLav.SelectionStart = 0;
            this.txtLav.ShortcutsEnabled = true;
            this.txtLav.Size = new System.Drawing.Size(33, 23);
            this.txtLav.TabIndex = 31;
            this.txtLav.UseSelectable = true;
            this.txtLav.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtLav.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // dtDatos
            // 
            this.dtDatos.AllowUserToAddRows = false;
            this.dtDatos.AllowUserToDeleteRows = false;
            this.dtDatos.BackgroundColor = System.Drawing.Color.White;
            this.dtDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtDatos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtDatos.Location = new System.Drawing.Point(45, 213);
            this.dtDatos.Name = "dtDatos";
            this.dtDatos.ReadOnly = true;
            this.dtDatos.Size = new System.Drawing.Size(1135, 312);
            this.dtDatos.TabIndex = 19;
            this.dtDatos.SelectionChanged += new System.EventHandler(this.dtDatos_SelectionChanged);
            // 
            // txtAvios
            // 
            // 
            // 
            // 
            this.txtAvios.CustomButton.Image = null;
            this.txtAvios.CustomButton.Location = new System.Drawing.Point(20, 1);
            this.txtAvios.CustomButton.Name = "";
            this.txtAvios.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtAvios.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAvios.CustomButton.TabIndex = 1;
            this.txtAvios.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAvios.CustomButton.UseSelectable = true;
            this.txtAvios.CustomButton.Visible = false;
            this.txtAvios.Lines = new string[0];
            this.txtAvios.Location = new System.Drawing.Point(722, 569);
            this.txtAvios.Margin = new System.Windows.Forms.Padding(8, 8, 20, 8);
            this.txtAvios.MaxLength = 10;
            this.txtAvios.Name = "txtAvios";
            this.txtAvios.PasswordChar = '\0';
            this.txtAvios.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAvios.SelectedText = "";
            this.txtAvios.SelectionLength = 0;
            this.txtAvios.SelectionStart = 0;
            this.txtAvios.ShortcutsEnabled = true;
            this.txtAvios.Size = new System.Drawing.Size(42, 23);
            this.txtAvios.TabIndex = 30;
            this.txtAvios.UseSelectable = true;
            this.txtAvios.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAvios.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblCliente.Location = new System.Drawing.Point(327, 542);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(51, 19);
            this.lblCliente.TabIndex = 20;
            this.lblCliente.Text = "Cliente";
            // 
            // txtFalt
            // 
            // 
            // 
            // 
            this.txtFalt.CustomButton.Image = null;
            this.txtFalt.CustomButton.Location = new System.Drawing.Point(11, 1);
            this.txtFalt.CustomButton.Name = "";
            this.txtFalt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtFalt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtFalt.CustomButton.TabIndex = 1;
            this.txtFalt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtFalt.CustomButton.UseSelectable = true;
            this.txtFalt.CustomButton.Visible = false;
            this.txtFalt.Lines = new string[0];
            this.txtFalt.Location = new System.Drawing.Point(783, 569);
            this.txtFalt.Margin = new System.Windows.Forms.Padding(8, 8, 20, 8);
            this.txtFalt.MaxLength = 10;
            this.txtFalt.Name = "txtFalt";
            this.txtFalt.PasswordChar = '\0';
            this.txtFalt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFalt.SelectedText = "";
            this.txtFalt.SelectionLength = 0;
            this.txtFalt.SelectionStart = 0;
            this.txtFalt.ShortcutsEnabled = true;
            this.txtFalt.Size = new System.Drawing.Size(33, 23);
            this.txtFalt.TabIndex = 29;
            this.txtFalt.UseSelectable = true;
            this.txtFalt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtFalt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtCliente
            // 
            // 
            // 
            // 
            this.txtCliente.CustomButton.Image = null;
            this.txtCliente.CustomButton.Location = new System.Drawing.Point(26, 1);
            this.txtCliente.CustomButton.Name = "";
            this.txtCliente.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCliente.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCliente.CustomButton.TabIndex = 1;
            this.txtCliente.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCliente.CustomButton.UseSelectable = true;
            this.txtCliente.CustomButton.Visible = false;
            this.txtCliente.Lines = new string[0];
            this.txtCliente.Location = new System.Drawing.Point(327, 569);
            this.txtCliente.Margin = new System.Windows.Forms.Padding(8, 8, 20, 8);
            this.txtCliente.MaxLength = 32767;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.PasswordChar = '\0';
            this.txtCliente.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCliente.SelectedText = "";
            this.txtCliente.SelectionLength = 0;
            this.txtCliente.SelectionStart = 0;
            this.txtCliente.ShortcutsEnabled = true;
            this.txtCliente.Size = new System.Drawing.Size(123, 23);
            this.txtCliente.TabIndex = 21;
            this.txtCliente.UseSelectable = true;
            this.txtCliente.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCliente.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtConf
            // 
            // 
            // 
            // 
            this.txtConf.CustomButton.Image = null;
            this.txtConf.CustomButton.Location = new System.Drawing.Point(16, 1);
            this.txtConf.CustomButton.Name = "";
            this.txtConf.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtConf.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtConf.CustomButton.TabIndex = 1;
            this.txtConf.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtConf.CustomButton.UseSelectable = true;
            this.txtConf.CustomButton.Visible = false;
            this.txtConf.Lines = new string[0];
            this.txtConf.Location = new System.Drawing.Point(539, 569);
            this.txtConf.Margin = new System.Windows.Forms.Padding(8, 8, 20, 8);
            this.txtConf.MaxLength = 10;
            this.txtConf.Name = "txtConf";
            this.txtConf.PasswordChar = '\0';
            this.txtConf.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtConf.SelectedText = "";
            this.txtConf.SelectionLength = 0;
            this.txtConf.SelectionStart = 0;
            this.txtConf.ShortcutsEnabled = true;
            this.txtConf.Size = new System.Drawing.Size(38, 23);
            this.txtConf.TabIndex = 28;
            this.txtConf.UseSelectable = true;
            this.txtConf.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtConf.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblTela
            // 
            this.lblTela.AutoSize = true;
            this.lblTela.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblTela.Location = new System.Drawing.Point(479, 542);
            this.lblTela.Name = "lblTela";
            this.lblTela.Size = new System.Drawing.Size(32, 19);
            this.lblTela.TabIndex = 22;
            this.lblTela.Text = "Tela";
            // 
            // txtProc
            // 
            // 
            // 
            // 
            this.txtProc.CustomButton.Image = null;
            this.txtProc.CustomButton.Location = new System.Drawing.Point(11, 1);
            this.txtProc.CustomButton.Name = "";
            this.txtProc.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtProc.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtProc.CustomButton.TabIndex = 1;
            this.txtProc.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtProc.CustomButton.UseSelectable = true;
            this.txtProc.CustomButton.Visible = false;
            this.txtProc.Lines = new string[0];
            this.txtProc.Location = new System.Drawing.Point(661, 569);
            this.txtProc.Margin = new System.Windows.Forms.Padding(8, 8, 20, 8);
            this.txtProc.MaxLength = 10;
            this.txtProc.Name = "txtProc";
            this.txtProc.PasswordChar = '\0';
            this.txtProc.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtProc.SelectedText = "";
            this.txtProc.SelectionLength = 0;
            this.txtProc.SelectionStart = 0;
            this.txtProc.ShortcutsEnabled = true;
            this.txtProc.Size = new System.Drawing.Size(33, 23);
            this.txtProc.TabIndex = 27;
            this.txtProc.UseSelectable = true;
            this.txtProc.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtProc.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtTela
            // 
            // 
            // 
            // 
            this.txtTela.CustomButton.Image = null;
            this.txtTela.CustomButton.Location = new System.Drawing.Point(11, 1);
            this.txtTela.CustomButton.Name = "";
            this.txtTela.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtTela.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTela.CustomButton.TabIndex = 1;
            this.txtTela.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTela.CustomButton.UseSelectable = true;
            this.txtTela.CustomButton.Visible = false;
            this.txtTela.Lines = new string[0];
            this.txtTela.Location = new System.Drawing.Point(478, 569);
            this.txtTela.Margin = new System.Windows.Forms.Padding(8, 8, 20, 8);
            this.txtTela.MaxLength = 25;
            this.txtTela.Name = "txtTela";
            this.txtTela.PasswordChar = '\0';
            this.txtTela.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTela.SelectedText = "";
            this.txtTela.SelectionLength = 0;
            this.txtTela.SelectionStart = 0;
            this.txtTela.ShortcutsEnabled = true;
            this.txtTela.Size = new System.Drawing.Size(33, 23);
            this.txtTela.TabIndex = 23;
            this.txtTela.UseSelectable = true;
            this.txtTela.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTela.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblProc
            // 
            this.lblProc.AutoSize = true;
            this.lblProc.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblProc.Location = new System.Drawing.Point(658, 542);
            this.lblProc.Name = "lblProc";
            this.lblProc.Size = new System.Drawing.Size(36, 19);
            this.lblProc.TabIndex = 26;
            this.lblProc.Text = "Proc";
            // 
            // lblConf
            // 
            this.lblConf.AutoSize = true;
            this.lblConf.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblConf.Location = new System.Drawing.Point(539, 542);
            this.lblConf.Name = "lblConf";
            this.lblConf.Size = new System.Drawing.Size(38, 19);
            this.lblConf.TabIndex = 24;
            this.lblConf.Text = "Conf";
            // 
            // lblLav
            // 
            this.lblLav.AutoSize = true;
            this.lblLav.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblLav.Location = new System.Drawing.Point(600, 542);
            this.lblLav.Name = "lblLav";
            this.lblLav.Size = new System.Drawing.Size(30, 19);
            this.lblLav.TabIndex = 25;
            this.lblLav.Text = "Lav";
            // 
            // SegundasVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SegundasVista";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Catálogo 2das y % de faltantes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SegundasVista_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelAccion.ResumeLayout(false);
            this.panelBuscar.ResumeLayout(false);
            this.panelBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel panelMenu;
        private MetroFramework.Controls.MetroLabel lblFalt;
        private MetroFramework.Controls.MetroLabel lblAvios;
        private MetroFramework.Controls.MetroTextBox txtLav;
        private System.Windows.Forms.DataGridView dtDatos;
        private MetroFramework.Controls.MetroTextBox txtAvios;
        private MetroFramework.Controls.MetroLabel lblCliente;
        private MetroFramework.Controls.MetroTextBox txtFalt;
        private MetroFramework.Controls.MetroTextBox txtCliente;
        private MetroFramework.Controls.MetroTextBox txtConf;
        private MetroFramework.Controls.MetroLabel lblTela;
        private MetroFramework.Controls.MetroTextBox txtProc;
        private MetroFramework.Controls.MetroTextBox txtTela;
        private MetroFramework.Controls.MetroLabel lblProc;
        private MetroFramework.Controls.MetroLabel lblConf;
        private MetroFramework.Controls.MetroLabel lblLav;
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