namespace PLM.Vista
{
    partial class LoginVista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginVista));
            this.ElipseLogin = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnlGradient = new System.Windows.Forms.Panel();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.pbxOjo = new System.Windows.Forms.PictureBox();
            this.pbxConfig = new System.Windows.Forms.PictureBox();
            this.txtUser = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbxSalir = new System.Windows.Forms.PictureBox();
            this.txtPass = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.btnOk = new Bunifu.Framework.UI.BunifuThinButton2();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxOjo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // ElipseLogin
            // 
            this.ElipseLogin.ElipseRadius = 3;
            this.ElipseLogin.TargetControl = this;
            // 
            // pnlGradient
            // 
            this.pnlGradient.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlGradient.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGradient.Location = new System.Drawing.Point(0, 0);
            this.pnlGradient.Name = "pnlGradient";
            this.pnlGradient.Size = new System.Drawing.Size(229, 521);
            this.pnlGradient.TabIndex = 0;
            // 
            // pnlLogin
            // 
            this.pnlLogin.Controls.Add(this.pbxOjo);
            this.pnlLogin.Controls.Add(this.pbxConfig);
            this.pnlLogin.Controls.Add(this.txtUser);
            this.pnlLogin.Controls.Add(this.pictureBox1);
            this.pnlLogin.Controls.Add(this.pbxSalir);
            this.pnlLogin.Controls.Add(this.txtPass);
            this.pnlLogin.Controls.Add(this.btnOk);
            this.pnlLogin.Controls.Add(this.pictureBox5);
            this.pnlLogin.Controls.Add(this.bunifuCustomLabel3);
            this.pnlLogin.Controls.Add(this.pictureBox3);
            this.pnlLogin.Location = new System.Drawing.Point(228, 0);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(409, 521);
            this.pnlLogin.TabIndex = 17;
            // 
            // pbxOjo
            // 
            this.pbxOjo.Image = ((System.Drawing.Image)(resources.GetObject("pbxOjo.Image")));
            this.pbxOjo.Location = new System.Drawing.Point(346, 301);
            this.pbxOjo.Name = "pbxOjo";
            this.pbxOjo.Size = new System.Drawing.Size(22, 23);
            this.pbxOjo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxOjo.TabIndex = 31;
            this.pbxOjo.TabStop = false;
            this.pbxOjo.MouseLeave += new System.EventHandler(this.pbxOjo_MouseLeave);
            this.pbxOjo.MouseHover += new System.EventHandler(this.pbxOjo_MouseHover);
            // 
            // pbxConfig
            // 
            this.pbxConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxConfig.Image = ((System.Drawing.Image)(resources.GetObject("pbxConfig.Image")));
            this.pbxConfig.Location = new System.Drawing.Point(324, 12);
            this.pbxConfig.Name = "pbxConfig";
            this.pbxConfig.Size = new System.Drawing.Size(38, 34);
            this.pbxConfig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxConfig.TabIndex = 30;
            this.pbxConfig.TabStop = false;
            this.pbxConfig.Click += new System.EventHandler(this.pbxConfig_Click);
            // 
            // txtUser
            // 
            this.txtUser.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.txtUser.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUser.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.txtUser.BorderThickness = 2;
            this.txtUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUser.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUser.isPassword = false;
            this.txtUser.Location = new System.Drawing.Point(94, 254);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(250, 34);
            this.txtUser.TabIndex = 0;
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OkLogin);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::PLM.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(57, 254);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // pbxSalir
            // 
            this.pbxSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxSalir.Image = ((System.Drawing.Image)(resources.GetObject("pbxSalir.Image")));
            this.pbxSalir.Location = new System.Drawing.Point(368, 12);
            this.pbxSalir.Name = "pbxSalir";
            this.pbxSalir.Size = new System.Drawing.Size(30, 34);
            this.pbxSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxSalir.TabIndex = 27;
            this.pbxSalir.TabStop = false;
            this.pbxSalir.Click += new System.EventHandler(this.pbxSalir_Click);
            // 
            // txtPass
            // 
            this.txtPass.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.txtPass.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPass.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.txtPass.BorderThickness = 2;
            this.txtPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPass.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPass.isPassword = true;
            this.txtPass.Location = new System.Drawing.Point(94, 296);
            this.txtPass.Margin = new System.Windows.Forms.Padding(4);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(250, 34);
            this.txtPass.TabIndex = 1;
            this.txtPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPass.OnValueChanged += new System.EventHandler(this.txtPass_OnValueChanged);
            this.txtPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OkLogin);
            // 
            // btnOk
            // 
            this.btnOk.ActiveBorderThickness = 2;
            this.btnOk.ActiveCornerRadius = 5;
            this.btnOk.ActiveFillColor = System.Drawing.Color.White;
            this.btnOk.ActiveForecolor = System.Drawing.Color.SeaGreen;
            this.btnOk.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnOk.BackColor = System.Drawing.Color.White;
            this.btnOk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOk.BackgroundImage")));
            this.btnOk.ButtonText = "Acceder";
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.Color.Black;
            this.btnOk.IdleBorderThickness = 2;
            this.btnOk.IdleCornerRadius = 5;
            this.btnOk.IdleFillColor = System.Drawing.Color.White;
            this.btnOk.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.btnOk.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.btnOk.Location = new System.Drawing.Point(130, 407);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(154, 48);
            this.btnOk.TabIndex = 2;
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(57, 296);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(30, 34);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox5.TabIndex = 24;
            this.pictureBox5.TabStop = false;
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.Gray;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(103, 158);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(207, 45);
            this.bunifuCustomLabel3.TabIndex = 23;
            this.bunifuCustomLabel3.Text = "Iniciar Sesión";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::PLM.Properties.Resources.LogoRiosul;
            this.pictureBox3.Location = new System.Drawing.Point(130, 25);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(151, 130);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 22;
            this.pictureBox3.TabStop = false;
            // 
            // LoginVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(638, 521);
            this.ControlBox = false;
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.pnlGradient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginVista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.LoginVista_Load);
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxOjo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse ElipseLogin;
        private System.Windows.Forms.Panel pnlGradient;
        private System.Windows.Forms.Panel pnlLogin;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtPass;
        private Bunifu.Framework.UI.BunifuThinButton2 btnOk;
        private System.Windows.Forms.PictureBox pictureBox5;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbxSalir;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtUser;
        private System.Windows.Forms.PictureBox pbxConfig;
        private System.Windows.Forms.PictureBox pbxOjo;
    }
}