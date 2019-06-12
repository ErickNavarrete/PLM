namespace PLM.Vista
{
    partial class ManoDeObraVista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManoDeObraVista));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.txtDescripcion = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtIdManoDeObra = new MetroFramework.Controls.MetroTextBox();
            this.lblIdManoDeObra = new MetroFramework.Controls.MetroLabel();
            this.dtDatos = new System.Windows.Forms.DataGridView();
            this.panelMenu.SuspendLayout();
            this.panelAccion.SuspendLayout();
            this.panelBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.panelAccion);
            this.panelMenu.Controls.Add(this.panelBuscar);
            this.panelMenu.Controls.Add(this.txtDescripcion);
            this.panelMenu.Controls.Add(this.metroLabel2);
            this.panelMenu.Controls.Add(this.txtIdManoDeObra);
            this.panelMenu.Controls.Add(this.lblIdManoDeObra);
            this.panelMenu.Controls.Add(this.dtDatos);
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
            this.panelAccion.TabIndex = 79;
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
            // panelBuscar
            // 
            this.panelBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBuscar.Controls.Add(this.btnBuscar);
            this.panelBuscar.Controls.Add(this.txtBusqueda);
            this.panelBuscar.Controls.Add(this.lblBusqueda);
            this.panelBuscar.Location = new System.Drawing.Point(891, 139);
            this.panelBuscar.Name = "panelBuscar";
            this.panelBuscar.Size = new System.Drawing.Size(289, 65);
            this.panelBuscar.TabIndex = 78;
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
            this.txtDescripcion.Location = new System.Drawing.Point(641, 574);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.txtDescripcion.MaxLength = 25;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.PasswordChar = '\0';
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDescripcion.SelectedText = "";
            this.txtDescripcion.SelectionLength = 0;
            this.txtDescripcion.SelectionStart = 0;
            this.txtDescripcion.ShortcutsEnabled = true;
            this.txtDescripcion.Size = new System.Drawing.Size(151, 23);
            this.txtDescripcion.TabIndex = 25;
            this.txtDescripcion.UseSelectable = true;
            this.txtDescripcion.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDescripcion.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(641, 546);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(79, 19);
            this.metroLabel2.TabIndex = 10;
            this.metroLabel2.Text = "Descripción";
            // 
            // txtIdManoDeObra
            // 
            // 
            // 
            // 
            this.txtIdManoDeObra.CustomButton.Image = null;
            this.txtIdManoDeObra.CustomButton.Location = new System.Drawing.Point(129, 1);
            this.txtIdManoDeObra.CustomButton.Name = "";
            this.txtIdManoDeObra.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtIdManoDeObra.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtIdManoDeObra.CustomButton.TabIndex = 1;
            this.txtIdManoDeObra.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtIdManoDeObra.CustomButton.UseSelectable = true;
            this.txtIdManoDeObra.CustomButton.Visible = false;
            this.txtIdManoDeObra.Lines = new string[0];
            this.txtIdManoDeObra.Location = new System.Drawing.Point(467, 574);
            this.txtIdManoDeObra.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.txtIdManoDeObra.MaxLength = 25;
            this.txtIdManoDeObra.Name = "txtIdManoDeObra";
            this.txtIdManoDeObra.PasswordChar = '\0';
            this.txtIdManoDeObra.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtIdManoDeObra.SelectedText = "";
            this.txtIdManoDeObra.SelectionLength = 0;
            this.txtIdManoDeObra.SelectionStart = 0;
            this.txtIdManoDeObra.ShortcutsEnabled = true;
            this.txtIdManoDeObra.Size = new System.Drawing.Size(151, 23);
            this.txtIdManoDeObra.TabIndex = 11;
            this.txtIdManoDeObra.UseSelectable = true;
            this.txtIdManoDeObra.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtIdManoDeObra.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblIdManoDeObra
            // 
            this.lblIdManoDeObra.AutoSize = true;
            this.lblIdManoDeObra.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblIdManoDeObra.Location = new System.Drawing.Point(462, 546);
            this.lblIdManoDeObra.Name = "lblIdManoDeObra";
            this.lblIdManoDeObra.Size = new System.Drawing.Size(115, 19);
            this.lblIdManoDeObra.TabIndex = 8;
            this.lblIdManoDeObra.Text = "Id Mano de Obra";
            // 
            // dtDatos
            // 
            this.dtDatos.AllowUserToAddRows = false;
            this.dtDatos.AllowUserToDeleteRows = false;
            this.dtDatos.BackgroundColor = System.Drawing.Color.White;
            this.dtDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtDatos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtDatos.Location = new System.Drawing.Point(45, 213);
            this.dtDatos.Name = "dtDatos";
            this.dtDatos.ReadOnly = true;
            this.dtDatos.Size = new System.Drawing.Size(1135, 312);
            this.dtDatos.TabIndex = 7;
            this.dtDatos.SelectionChanged += new System.EventHandler(this.dtDatos_SelectionChanged);
            // 
            // ManoDeObraVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManoDeObraVista";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Catálogo Mano de Obra";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ManoDeObraVista_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelAccion.ResumeLayout(false);
            this.panelBuscar.ResumeLayout(false);
            this.panelBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private MetroFramework.Controls.MetroTextBox txtDescripcion;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtIdManoDeObra;
        private MetroFramework.Controls.MetroLabel lblIdManoDeObra;
        private System.Windows.Forms.DataGridView dtDatos;
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