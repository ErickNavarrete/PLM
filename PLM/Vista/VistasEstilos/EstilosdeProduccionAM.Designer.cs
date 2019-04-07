namespace PLM.Vista.VistasEstilos
{
    partial class EstilosdeProduccionAM 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EstilosdeProduccionAM));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelAccion = new System.Windows.Forms.Panel();
            this.btnEliminar = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnAtras = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnActualizar = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnAlta = new Bunifu.Framework.UI.BunifuTileButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdioDynamics = new MetroFramework.Controls.MetroRadioButton();
            this.rdioPLM = new MetroFramework.Controls.MetroRadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtDatosDyn = new System.Windows.Forms.DataGridView();
            this.grbEstilos = new System.Windows.Forms.GroupBox();
            this.dtDatosPLM = new System.Windows.Forms.DataGridView();
            this.panelMenu.SuspendLayout();
            this.panelAccion.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDatosDyn)).BeginInit();
            this.grbEstilos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDatosPLM)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.panelAccion);
            this.panelMenu.Controls.Add(this.groupBox2);
            this.panelMenu.Controls.Add(this.groupBox1);
            this.panelMenu.Controls.Add(this.grbEstilos);
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
            this.panelAccion.Location = new System.Drawing.Point(-3, 53);
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
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
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
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdioDynamics);
            this.groupBox2.Controls.Add(this.rdioPLM);
            this.groupBox2.Location = new System.Drawing.Point(777, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(431, 77);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Edición de datos ";
            // 
            // rdioDynamics
            // 
            this.rdioDynamics.AutoSize = true;
            this.rdioDynamics.Checked = true;
            this.rdioDynamics.Location = new System.Drawing.Point(139, 35);
            this.rdioDynamics.Name = "rdioDynamics";
            this.rdioDynamics.Size = new System.Drawing.Size(119, 15);
            this.rdioDynamics.Style = MetroFramework.MetroColorStyle.Green;
            this.rdioDynamics.TabIndex = 1;
            this.rdioDynamics.TabStop = true;
            this.rdioDynamics.Text = "Sistema Dynamics";
            this.rdioDynamics.UseSelectable = true;
            this.rdioDynamics.CheckedChanged += new System.EventHandler(this.rdioDynamics_CheckedChanged);
            // 
            // rdioPLM
            // 
            this.rdioPLM.AutoSize = true;
            this.rdioPLM.Location = new System.Drawing.Point(28, 35);
            this.rdioPLM.Name = "rdioPLM";
            this.rdioPLM.Size = new System.Drawing.Size(91, 15);
            this.rdioPLM.Style = MetroFramework.MetroColorStyle.Green;
            this.rdioPLM.TabIndex = 0;
            this.rdioPLM.Text = "Sistema PLM";
            this.rdioPLM.UseSelectable = true;
            this.rdioPLM.CheckedChanged += new System.EventHandler(this.rdioPLM_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtDatosDyn);
            this.groupBox1.Location = new System.Drawing.Point(632, 207);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 449);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estilos de Producción [Dynamics] ";
            // 
            // dtDatosDyn
            // 
            this.dtDatosDyn.AllowUserToAddRows = false;
            this.dtDatosDyn.AllowUserToDeleteRows = false;
            this.dtDatosDyn.BackgroundColor = System.Drawing.Color.White;
            this.dtDatosDyn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtDatosDyn.Enabled = false;
            this.dtDatosDyn.Location = new System.Drawing.Point(19, 35);
            this.dtDatosDyn.Name = "dtDatosDyn";
            this.dtDatosDyn.ReadOnly = true;
            this.dtDatosDyn.Size = new System.Drawing.Size(535, 393);
            this.dtDatosDyn.TabIndex = 1;
            this.dtDatosDyn.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtDatosDyn_CellDoubleClick);
            // 
            // grbEstilos
            // 
            this.grbEstilos.Controls.Add(this.dtDatosPLM);
            this.grbEstilos.Location = new System.Drawing.Point(29, 207);
            this.grbEstilos.Name = "grbEstilos";
            this.grbEstilos.Size = new System.Drawing.Size(579, 449);
            this.grbEstilos.TabIndex = 4;
            this.grbEstilos.TabStop = false;
            this.grbEstilos.Text = "Estilos de Producción [PLM] ";
            // 
            // dtDatosPLM
            // 
            this.dtDatosPLM.AllowUserToAddRows = false;
            this.dtDatosPLM.AllowUserToDeleteRows = false;
            this.dtDatosPLM.BackgroundColor = System.Drawing.Color.White;
            this.dtDatosPLM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtDatosPLM.Enabled = false;
            this.dtDatosPLM.Location = new System.Drawing.Point(19, 35);
            this.dtDatosPLM.Name = "dtDatosPLM";
            this.dtDatosPLM.ReadOnly = true;
            this.dtDatosPLM.Size = new System.Drawing.Size(538, 393);
            this.dtDatosPLM.TabIndex = 1;
            // 
            // EstilosdeProduccionAM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 788);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EstilosdeProduccionAM";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Catálogo estilos de producción";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.EstilosdeProduccionAM_Activated);
            this.Load += new System.EventHandler(this.EstilosdeProduccionAM_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelAccion.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtDatosDyn)).EndInit();
            this.grbEstilos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtDatosPLM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroRadioButton rdioDynamics;
        private MetroFramework.Controls.MetroRadioButton rdioPLM;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtDatosDyn;
        private System.Windows.Forms.GroupBox grbEstilos;
        private System.Windows.Forms.DataGridView dtDatosPLM;
        private System.Windows.Forms.Panel panelAccion;
        private Bunifu.Framework.UI.BunifuTileButton btnEliminar;
        private Bunifu.Framework.UI.BunifuTileButton btnAtras;
        private Bunifu.Framework.UI.BunifuTileButton btnActualizar;
        private Bunifu.Framework.UI.BunifuTileButton btnAlta;
    }
}