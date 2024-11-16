namespace UI
{
    partial class Fr_Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnMostrarPassword;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.PictureBox picLogo;

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
            pnlTop = new Panel();
            lblTitle = new Label();
            btnSalir = new Button();
            picLogo = new PictureBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnMostrarPassword = new Button();
            btnIngresar = new Button();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.Sienna;
            pnlTop.Controls.Add(btnSalir);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(800, 55);
            pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(800, 39);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "SISTEMA DE GESTIÓN CINEMATOGRÁFICA";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSalir
            // 
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(0, 0);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(30, 30);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "✖";
            btnSalir.Click += btnIngresar_Click;
            // 
            // picLogo
            // 
            picLogo.Location = new Point(92, 168);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(120, 120);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 1;
            picLogo.TabStop = false;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.Location = new Point(282, 180);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Usuario";
            txtUsername.Size = new Size(250, 34);
            txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(282, 214);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Contraseña";
            txtPassword.Size = new Size(250, 34);
            txtPassword.TabIndex = 3;
            // 
            // btnMostrarPassword
            // 
            btnMostrarPassword.FlatStyle = FlatStyle.Flat;
            btnMostrarPassword.Location = new Point(532, 214);
            btnMostrarPassword.Name = "btnMostrarPassword";
            btnMostrarPassword.Size = new Size(30, 30);
            btnMostrarPassword.TabIndex = 4;
            btnMostrarPassword.Text = "👁";
            btnMostrarPassword.MouseDown += btnMostrarPassword_MouseDown;
            btnMostrarPassword.MouseUp += btnMostrarPassword_MouseUp;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.Sienna;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(282, 248);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(250, 40);
            btnIngresar.TabIndex = 5;
            btnIngresar.Text = "INGRESAR";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // Fr_Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(798, 445);
            Controls.Add(picLogo);
            Controls.Add(txtUsername);
            Controls.Add(txtPassword);
            Controls.Add(btnMostrarPassword);
            Controls.Add(btnIngresar);
            Controls.Add(pnlTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Fr_Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fr_Login";
            pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}