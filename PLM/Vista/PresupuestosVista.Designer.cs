namespace PLM.Vista
{
    partial class PresupuestosVista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PresupuestosVista));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lblDiario = new MetroFramework.Controls.MetroLabel();
            this.txtDiario = new MetroFramework.Controls.MetroTextBox();
            this.lblMO = new MetroFramework.Controls.MetroLabel();
            this.txtMO = new MetroFramework.Controls.MetroTextBox();
            this.lblPrest = new MetroFramework.Controls.MetroLabel();
            this.lblAdmon = new MetroFramework.Controls.MetroLabel();
            this.lblProd = new MetroFramework.Controls.MetroLabel();
            this.txtProd = new MetroFramework.Controls.MetroTextBox();
            this.txtPrest = new MetroFramework.Controls.MetroTextBox();
            this.txtVarios = new MetroFramework.Controls.MetroTextBox();
            this.txtVentas = new MetroFramework.Controls.MetroTextBox();
            this.txtAdmon = new MetroFramework.Controls.MetroTextBox();
            this.lblVentas = new MetroFramework.Controls.MetroLabel();
            this.lblVarios = new MetroFramework.Controls.MetroLabel();
            this.txtIdPresupuestos = new MetroFramework.Controls.MetroTextBox();
            this.lblIdPresupuestos = new MetroFramework.Controls.MetroLabel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelBuscar = new System.Windows.Forms.Panel();
            this.btnBuscar = new MetroFramework.Controls.MetroButton();
            this.txtBusqueda = new MetroFramework.Controls.MetroTextBox();
            this.lblBusqueda = new MetroFramework.Controls.MetroLabel();
            this.panelAccion = new System.Windows.Forms.Panel();
            this.btnEliminar = new Bunifu.Framework.UI.BunifuTileButton();
            this.bunifuTileButton1 = new Bunifu.Framework.UI.BunifuTileButton();
            this.Actualizar = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnAlta = new Bunifu.Framework.UI.BunifuTileButton();
            this.dtDatos = new System.Windows.Forms.DataGridView();
            this.panelMenu.SuspendLayout();
            this.panelBuscar.SuspendLayout();
            this.panelAccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            // 
            // lblDiario
            // 
            this.lblDiario.AutoSize = true;
            this.lblDiario.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblDiario.Location = new System.Drawing.Point(485, 548);
            this.lblDiario.Name = "lblDiario";
            this.lblDiario.Size = new System.Drawing.Size(45, 19);
            this.lblDiario.TabIndex = 76;
            this.lblDiario.Text = "Diario";
            // 
            // txtDiario
            // 
            this.txtDiario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // 
            // 
            // 
            this.txtDiario.CustomButton.Image = null;
            this.txtDiario.CustomButton.Location = new System.Drawing.Point(90, 1);
            this.txtDiario.CustomButton.Name = "";
            this.txtDiario.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtDiario.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDiario.CustomButton.TabIndex = 1;
            this.txtDiario.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDiario.CustomButton.UseSelectable = true;
            this.txtDiario.CustomButton.Visible = false;
            this.txtDiario.Lines = new string[0];
            this.txtDiario.Location = new System.Drawing.Point(485, 575);
            this.txtDiario.Margin = new System.Windows.Forms.Padding(8, 8, 20, 8);
            this.txtDiario.MaxLength = 25;
            this.txtDiario.Name = "txtDiario";
            this.txtDiario.PasswordChar = '\0';
            this.txtDiario.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDiario.SelectedText = "";
            this.txtDiario.SelectionLength = 0;
            this.txtDiario.SelectionStart = 0;
            this.txtDiario.ShortcutsEnabled = true;
            this.txtDiario.Size = new System.Drawing.Size(112, 23);
            this.txtDiario.TabIndex = 77;
            this.txtDiario.UseSelectable = true;
            this.txtDiario.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDiario.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblMO
            // 
            this.lblMO.AutoSize = true;
            this.lblMO.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblMO.Location = new System.Drawing.Point(625, 548);
            this.lblMO.Name = "lblMO";
            this.lblMO.Size = new System.Drawing.Size(86, 19);
            this.lblMO.TabIndex = 78;
            this.lblMO.Text = "M.O. Directa";
            // 
            // txtMO
            // 
            // 
            // 
            // 
            this.txtMO.CustomButton.Image = null;
            this.txtMO.CustomButton.Location = new System.Drawing.Point(90, 1);
            this.txtMO.CustomButton.Name = "";
            this.txtMO.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtMO.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMO.CustomButton.TabIndex = 1;
            this.txtMO.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMO.CustomButton.UseSelectable = true;
            this.txtMO.CustomButton.Visible = false;
            this.txtMO.Lines = new string[0];
            this.txtMO.Location = new System.Drawing.Point(625, 575);
            this.txtMO.Margin = new System.Windows.Forms.Padding(8, 8, 20, 8);
            this.txtMO.MaxLength = 25;
            this.txtMO.Name = "txtMO";
            this.txtMO.PasswordChar = '\0';
            this.txtMO.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMO.SelectedText = "";
            this.txtMO.SelectionLength = 0;
            this.txtMO.SelectionStart = 0;
            this.txtMO.ShortcutsEnabled = true;
            this.txtMO.Size = new System.Drawing.Size(112, 23);
            this.txtMO.TabIndex = 79;
            this.txtMO.UseSelectable = true;
            this.txtMO.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMO.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblPrest
            // 
            this.lblPrest.AutoSize = true;
            this.lblPrest.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblPrest.Location = new System.Drawing.Point(765, 548);
            this.lblPrest.Name = "lblPrest";
            this.lblPrest.Size = new System.Drawing.Size(85, 19);
            this.lblPrest.TabIndex = 80;
            this.lblPrest.Text = "Prestaciones";
            // 
            // lblAdmon
            // 
            this.lblAdmon.AutoSize = true;
            this.lblAdmon.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblAdmon.Location = new System.Drawing.Point(764, 624);
            this.lblAdmon.Name = "lblAdmon";
            this.lblAdmon.Size = new System.Drawing.Size(54, 19);
            this.lblAdmon.TabIndex = 81;
            this.lblAdmon.Text = "Admon";
            // 
            // lblProd
            // 
            this.lblProd.AutoSize = true;
            this.lblProd.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblProd.Location = new System.Drawing.Point(346, 624);
            this.lblProd.Name = "lblProd";
            this.lblProd.Size = new System.Drawing.Size(38, 19);
            this.lblProd.TabIndex = 82;
            this.lblProd.Text = "Prod";
            // 
            // txtProd
            // 
            // 
            // 
            // 
            this.txtProd.CustomButton.Image = null;
            this.txtProd.CustomButton.Location = new System.Drawing.Point(89, 1);
            this.txtProd.CustomButton.Name = "";
            this.txtProd.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtProd.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtProd.CustomButton.TabIndex = 1;
            this.txtProd.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtProd.CustomButton.UseSelectable = true;
            this.txtProd.CustomButton.Visible = false;
            this.txtProd.Lines = new string[0];
            this.txtProd.Location = new System.Drawing.Point(346, 651);
            this.txtProd.Margin = new System.Windows.Forms.Padding(8, 8, 20, 8);
            this.txtProd.MaxLength = 25;
            this.txtProd.Name = "txtProd";
            this.txtProd.PasswordChar = '\0';
            this.txtProd.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtProd.SelectedText = "";
            this.txtProd.SelectionLength = 0;
            this.txtProd.SelectionStart = 0;
            this.txtProd.ShortcutsEnabled = true;
            this.txtProd.Size = new System.Drawing.Size(111, 23);
            this.txtProd.TabIndex = 83;
            this.txtProd.UseSelectable = true;
            this.txtProd.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtProd.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtPrest
            // 
            // 
            // 
            // 
            this.txtPrest.CustomButton.Image = null;
            this.txtPrest.CustomButton.Location = new System.Drawing.Point(89, 1);
            this.txtPrest.CustomButton.Name = "";
            this.txtPrest.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPrest.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPrest.CustomButton.TabIndex = 1;
            this.txtPrest.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPrest.CustomButton.UseSelectable = true;
            this.txtPrest.CustomButton.Visible = false;
            this.txtPrest.Lines = new string[0];
            this.txtPrest.Location = new System.Drawing.Point(764, 575);
            this.txtPrest.Margin = new System.Windows.Forms.Padding(8, 8, 20, 8);
            this.txtPrest.MaxLength = 25;
            this.txtPrest.Name = "txtPrest";
            this.txtPrest.PasswordChar = '\0';
            this.txtPrest.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPrest.SelectedText = "";
            this.txtPrest.SelectionLength = 0;
            this.txtPrest.SelectionStart = 0;
            this.txtPrest.ShortcutsEnabled = true;
            this.txtPrest.Size = new System.Drawing.Size(111, 23);
            this.txtPrest.TabIndex = 84;
            this.txtPrest.UseSelectable = true;
            this.txtPrest.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPrest.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtVarios
            // 
            // 
            // 
            // 
            this.txtVarios.CustomButton.Image = null;
            this.txtVarios.CustomButton.Location = new System.Drawing.Point(89, 1);
            this.txtVarios.CustomButton.Name = "";
            this.txtVarios.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtVarios.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtVarios.CustomButton.TabIndex = 1;
            this.txtVarios.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtVarios.CustomButton.UseSelectable = true;
            this.txtVarios.CustomButton.Visible = false;
            this.txtVarios.Lines = new string[0];
            this.txtVarios.Location = new System.Drawing.Point(625, 651);
            this.txtVarios.Margin = new System.Windows.Forms.Padding(8, 8, 20, 8);
            this.txtVarios.MaxLength = 10;
            this.txtVarios.Name = "txtVarios";
            this.txtVarios.PasswordChar = '\0';
            this.txtVarios.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtVarios.SelectedText = "";
            this.txtVarios.SelectionLength = 0;
            this.txtVarios.SelectionStart = 0;
            this.txtVarios.ShortcutsEnabled = true;
            this.txtVarios.Size = new System.Drawing.Size(111, 23);
            this.txtVarios.TabIndex = 85;
            this.txtVarios.UseSelectable = true;
            this.txtVarios.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtVarios.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtVentas
            // 
            // 
            // 
            // 
            this.txtVentas.CustomButton.Image = null;
            this.txtVentas.CustomButton.Location = new System.Drawing.Point(90, 1);
            this.txtVentas.CustomButton.Name = "";
            this.txtVentas.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtVentas.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtVentas.CustomButton.TabIndex = 1;
            this.txtVentas.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtVentas.CustomButton.UseSelectable = true;
            this.txtVentas.CustomButton.Visible = false;
            this.txtVentas.Lines = new string[0];
            this.txtVentas.Location = new System.Drawing.Point(485, 651);
            this.txtVentas.Margin = new System.Windows.Forms.Padding(8, 8, 20, 8);
            this.txtVentas.MaxLength = 25;
            this.txtVentas.Name = "txtVentas";
            this.txtVentas.PasswordChar = '\0';
            this.txtVentas.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtVentas.SelectedText = "";
            this.txtVentas.SelectionLength = 0;
            this.txtVentas.SelectionStart = 0;
            this.txtVentas.ShortcutsEnabled = true;
            this.txtVentas.Size = new System.Drawing.Size(112, 23);
            this.txtVentas.TabIndex = 86;
            this.txtVentas.UseSelectable = true;
            this.txtVentas.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtVentas.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtAdmon
            // 
            // 
            // 
            // 
            this.txtAdmon.CustomButton.Image = null;
            this.txtAdmon.CustomButton.Location = new System.Drawing.Point(89, 1);
            this.txtAdmon.CustomButton.Name = "";
            this.txtAdmon.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtAdmon.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAdmon.CustomButton.TabIndex = 1;
            this.txtAdmon.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAdmon.CustomButton.UseSelectable = true;
            this.txtAdmon.CustomButton.Visible = false;
            this.txtAdmon.Lines = new string[0];
            this.txtAdmon.Location = new System.Drawing.Point(764, 651);
            this.txtAdmon.Margin = new System.Windows.Forms.Padding(8, 8, 20, 8);
            this.txtAdmon.MaxLength = 25;
            this.txtAdmon.Name = "txtAdmon";
            this.txtAdmon.PasswordChar = '\0';
            this.txtAdmon.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAdmon.SelectedText = "";
            this.txtAdmon.SelectionLength = 0;
            this.txtAdmon.SelectionStart = 0;
            this.txtAdmon.ShortcutsEnabled = true;
            this.txtAdmon.Size = new System.Drawing.Size(111, 23);
            this.txtAdmon.TabIndex = 87;
            this.txtAdmon.UseSelectable = true;
            this.txtAdmon.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAdmon.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblVentas
            // 
            this.lblVentas.AutoSize = true;
            this.lblVentas.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblVentas.Location = new System.Drawing.Point(485, 624);
            this.lblVentas.Name = "lblVentas";
            this.lblVentas.Size = new System.Drawing.Size(51, 19);
            this.lblVentas.TabIndex = 88;
            this.lblVentas.Text = "Ventas";
            // 
            // lblVarios
            // 
            this.lblVarios.AutoSize = true;
            this.lblVarios.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblVarios.Location = new System.Drawing.Point(625, 624);
            this.lblVarios.Name = "lblVarios";
            this.lblVarios.Size = new System.Drawing.Size(47, 19);
            this.lblVarios.TabIndex = 89;
            this.lblVarios.Text = "Varios";
            // 
            // txtIdPresupuestos
            // 
            // 
            // 
            // 
            this.txtIdPresupuestos.CustomButton.Image = null;
            this.txtIdPresupuestos.CustomButton.Location = new System.Drawing.Point(89, 1);
            this.txtIdPresupuestos.CustomButton.Name = "";
            this.txtIdPresupuestos.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtIdPresupuestos.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtIdPresupuestos.CustomButton.TabIndex = 1;
            this.txtIdPresupuestos.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtIdPresupuestos.CustomButton.UseSelectable = true;
            this.txtIdPresupuestos.CustomButton.Visible = false;
            this.txtIdPresupuestos.Lines = new string[0];
            this.txtIdPresupuestos.Location = new System.Drawing.Point(346, 575);
            this.txtIdPresupuestos.Margin = new System.Windows.Forms.Padding(8, 8, 20, 8);
            this.txtIdPresupuestos.MaxLength = 10;
            this.txtIdPresupuestos.Name = "txtIdPresupuestos";
            this.txtIdPresupuestos.PasswordChar = '\0';
            this.txtIdPresupuestos.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtIdPresupuestos.SelectedText = "";
            this.txtIdPresupuestos.SelectionLength = 0;
            this.txtIdPresupuestos.SelectionStart = 0;
            this.txtIdPresupuestos.ShortcutsEnabled = true;
            this.txtIdPresupuestos.Size = new System.Drawing.Size(111, 23);
            this.txtIdPresupuestos.TabIndex = 90;
            this.txtIdPresupuestos.UseSelectable = true;
            this.txtIdPresupuestos.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtIdPresupuestos.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblIdPresupuestos
            // 
            this.lblIdPresupuestos.AutoSize = true;
            this.lblIdPresupuestos.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblIdPresupuestos.Location = new System.Drawing.Point(346, 548);
            this.lblIdPresupuestos.Name = "lblIdPresupuestos";
            this.lblIdPresupuestos.Size = new System.Drawing.Size(103, 19);
            this.lblIdPresupuestos.TabIndex = 91;
            this.lblIdPresupuestos.Text = "ID Presupuesto";
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.panelBuscar);
            this.panelMenu.Controls.Add(this.panelAccion);
            this.panelMenu.Controls.Add(this.dtDatos);
            this.panelMenu.Controls.Add(this.lblIdPresupuestos);
            this.panelMenu.Controls.Add(this.txtIdPresupuestos);
            this.panelMenu.Controls.Add(this.lblVarios);
            this.panelMenu.Controls.Add(this.lblVentas);
            this.panelMenu.Controls.Add(this.txtAdmon);
            this.panelMenu.Controls.Add(this.txtVentas);
            this.panelMenu.Controls.Add(this.txtVarios);
            this.panelMenu.Controls.Add(this.txtPrest);
            this.panelMenu.Controls.Add(this.txtProd);
            this.panelMenu.Controls.Add(this.lblProd);
            this.panelMenu.Controls.Add(this.lblAdmon);
            this.panelMenu.Controls.Add(this.lblPrest);
            this.panelMenu.Controls.Add(this.txtMO);
            this.panelMenu.Controls.Add(this.lblMO);
            this.panelMenu.Controls.Add(this.txtDiario);
            this.panelMenu.Controls.Add(this.lblDiario);
            this.panelMenu.Location = new System.Drawing.Point(23, 63);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1234, 720);
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
            this.panelBuscar.TabIndex = 97;
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
            this.panelAccion.Controls.Add(this.bunifuTileButton1);
            this.panelAccion.Controls.Add(this.Actualizar);
            this.panelAccion.Controls.Add(this.btnAlta);
            this.panelAccion.Location = new System.Drawing.Point(21, 59);
            this.panelAccion.Name = "panelAccion";
            this.panelAccion.Size = new System.Drawing.Size(568, 148);
            this.panelAccion.TabIndex = 96;
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
            // bunifuTileButton1
            // 
            this.bunifuTileButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTileButton1.color = System.Drawing.Color.Transparent;
            this.bunifuTileButton1.colorActive = System.Drawing.Color.Transparent;
            this.bunifuTileButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTileButton1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuTileButton1.ForeColor = System.Drawing.Color.SteelBlue;
            this.bunifuTileButton1.Image = global::PLM.Properties.Resources.Atras;
            this.bunifuTileButton1.ImagePosition = 25;
            this.bunifuTileButton1.ImageZoom = 50;
            this.bunifuTileButton1.LabelPosition = 51;
            this.bunifuTileButton1.LabelText = "Atras";
            this.bunifuTileButton1.Location = new System.Drawing.Point(0, 0);
            this.bunifuTileButton1.Margin = new System.Windows.Forms.Padding(6);
            this.bunifuTileButton1.Name = "bunifuTileButton1";
            this.bunifuTileButton1.Size = new System.Drawing.Size(130, 142);
            this.bunifuTileButton1.TabIndex = 23;
            this.bunifuTileButton1.Click += new System.EventHandler(this.bunifuTileButton1_Click);
            // 
            // Actualizar
            // 
            this.Actualizar.BackColor = System.Drawing.Color.Transparent;
            this.Actualizar.color = System.Drawing.Color.Transparent;
            this.Actualizar.colorActive = System.Drawing.Color.Transparent;
            this.Actualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Actualizar.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Actualizar.ForeColor = System.Drawing.Color.SteelBlue;
            this.Actualizar.Image = global::PLM.Properties.Resources.Save;
            this.Actualizar.ImagePosition = 25;
            this.Actualizar.ImageZoom = 50;
            this.Actualizar.LabelPosition = 51;
            this.Actualizar.LabelText = "Guardar";
            this.Actualizar.Location = new System.Drawing.Point(284, 0);
            this.Actualizar.Margin = new System.Windows.Forms.Padding(6);
            this.Actualizar.Name = "Actualizar";
            this.Actualizar.Size = new System.Drawing.Size(130, 142);
            this.Actualizar.TabIndex = 25;
            this.Actualizar.Click += new System.EventHandler(this.btnGuardar_Click);
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
            this.dtDatos.TabIndex = 95;
            this.dtDatos.SelectionChanged += new System.EventHandler(this.dtDatos_SelectionChanged);
            // 
            // PresupuestosVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PresupuestosVista";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Catálogo Presupuesto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PresupuestosVista_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelBuscar.ResumeLayout(false);
            this.panelBuscar.PerformLayout();
            this.panelAccion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private MetroFramework.Controls.MetroLabel lblDiario;
        private MetroFramework.Controls.MetroTextBox txtDiario;
        private MetroFramework.Controls.MetroLabel lblMO;
        private MetroFramework.Controls.MetroTextBox txtMO;
        private MetroFramework.Controls.MetroLabel lblPrest;
        private MetroFramework.Controls.MetroLabel lblAdmon;
        private MetroFramework.Controls.MetroLabel lblProd;
        private MetroFramework.Controls.MetroTextBox txtProd;
        private MetroFramework.Controls.MetroTextBox txtPrest;
        private MetroFramework.Controls.MetroTextBox txtVarios;
        private MetroFramework.Controls.MetroTextBox txtVentas;
        private MetroFramework.Controls.MetroTextBox txtAdmon;
        private MetroFramework.Controls.MetroLabel lblVentas;
        private MetroFramework.Controls.MetroLabel lblVarios;
        private MetroFramework.Controls.MetroTextBox txtIdPresupuestos;
        private MetroFramework.Controls.MetroLabel lblIdPresupuestos;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelBuscar;
        private MetroFramework.Controls.MetroButton btnBuscar;
        private MetroFramework.Controls.MetroTextBox txtBusqueda;
        private MetroFramework.Controls.MetroLabel lblBusqueda;
        private System.Windows.Forms.Panel panelAccion;
        private Bunifu.Framework.UI.BunifuTileButton btnEliminar;
        private Bunifu.Framework.UI.BunifuTileButton bunifuTileButton1;
        private Bunifu.Framework.UI.BunifuTileButton Actualizar;
        private Bunifu.Framework.UI.BunifuTileButton btnAlta;
        private System.Windows.Forms.DataGridView dtDatos;
    }
}