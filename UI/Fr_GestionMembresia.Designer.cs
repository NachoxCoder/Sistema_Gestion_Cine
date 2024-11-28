namespace UI
{
    partial class Fr_GestionMembresia
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
            pnlTop = new Panel();
            lblTitle = new Label();
            grpCliente = new GroupBox();
            lblDNI = new Label();
            txtDNI = new TextBox();
            btnBuscarCliente = new Button();
            lblNombre = new Label();
            txtNombre = new TextBox();
            grpMembresia = new GroupBox();
            lblTipo = new Label();
            cmbTipoMembresia = new ComboBox();
            lblFechaInicio = new Label();
            dtpFechaInicio = new DateTimePicker();
            lblFechaFin = new Label();
            dtpFechaFin = new DateTimePicker();
            chkActiva = new CheckBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            dgvMembresias = new DataGridView();
            pnlTop.SuspendLayout();
            grpCliente.SuspendLayout();
            grpMembresia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMembresias).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(10, 18, 80);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1000, 60);
            pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Sienna;
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1000, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "GESTIÓN DE MEMBRESÍAS";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpCliente
            // 
            grpCliente.Controls.Add(lblDNI);
            grpCliente.Controls.Add(txtDNI);
            grpCliente.Controls.Add(btnBuscarCliente);
            grpCliente.Controls.Add(lblNombre);
            grpCliente.Controls.Add(txtNombre);
            grpCliente.Location = new Point(12, 70);
            grpCliente.Name = "grpCliente";
            grpCliente.Size = new Size(400, 120);
            grpCliente.TabIndex = 1;
            grpCliente.TabStop = false;
            grpCliente.Text = "Datos del Cliente";
            // 
            // lblDNI
            // 
            lblDNI.Location = new Point(20, 30);
            lblDNI.Name = "lblDNI";
            lblDNI.Size = new Size(100, 23);
            lblDNI.TabIndex = 0;
            lblDNI.Text = "DNI:";
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(100, 27);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(200, 27);
            txtDNI.TabIndex = 1;
            // 
            // btnBuscarCliente
            // 
            btnBuscarCliente.Location = new Point(310, 26);
            btnBuscarCliente.Name = "btnBuscarCliente";
            btnBuscarCliente.Size = new Size(70, 27);
            btnBuscarCliente.TabIndex = 2;
            btnBuscarCliente.Text = "Buscar";
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(20, 65);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(100, 23);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(100, 62);
            txtNombre.Name = "txtNombre";
            txtNombre.ReadOnly = true;
            txtNombre.Size = new Size(280, 27);
            txtNombre.TabIndex = 4;
            // 
            // grpMembresia
            // 
            grpMembresia.Controls.Add(lblTipo);
            grpMembresia.Controls.Add(cmbTipoMembresia);
            grpMembresia.Controls.Add(lblFechaInicio);
            grpMembresia.Controls.Add(dtpFechaInicio);
            grpMembresia.Controls.Add(lblFechaFin);
            grpMembresia.Controls.Add(dtpFechaFin);
            grpMembresia.Controls.Add(chkActiva);
            grpMembresia.Location = new Point(12, 200);
            grpMembresia.Name = "grpMembresia";
            grpMembresia.Size = new Size(400, 180);
            grpMembresia.TabIndex = 2;
            grpMembresia.TabStop = false;
            grpMembresia.Text = "Datos de Membresía";
            // 
            // lblTipo
            // 
            lblTipo.Location = new Point(20, 30);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(100, 23);
            lblTipo.TabIndex = 0;
            lblTipo.Text = "Tipo:";
            // 
            // cmbTipoMembresia
            // 
            cmbTipoMembresia.Location = new Point(120, 27);
            cmbTipoMembresia.Name = "cmbTipoMembresia";
            cmbTipoMembresia.Size = new Size(260, 28);
            cmbTipoMembresia.TabIndex = 1;
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.Location = new Point(20, 65);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(100, 23);
            lblFechaInicio.TabIndex = 2;
            lblFechaInicio.Text = "Fecha Inicio:";
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Location = new Point(120, 62);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(260, 27);
            dtpFechaInicio.TabIndex = 3;
            // 
            // lblFechaFin
            // 
            lblFechaFin.Location = new Point(20, 100);
            lblFechaFin.Name = "lblFechaFin";
            lblFechaFin.Size = new Size(100, 23);
            lblFechaFin.TabIndex = 4;
            lblFechaFin.Text = "Fecha Fin:";
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Location = new Point(120, 97);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(260, 27);
            dtpFechaFin.TabIndex = 5;
            // 
            // chkActiva
            // 
            chkActiva.AutoSize = true;
            chkActiva.Location = new Point(120, 132);
            chkActiva.Name = "chkActiva";
            chkActiva.Size = new Size(150, 24);
            chkActiva.TabIndex = 6;
            chkActiva.Text = "Membresía Activa";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(10, 18, 80);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(12, 390);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(190, 40);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Red;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(222, 390);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(190, 40);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "CANCELAR MEMBRESÍA";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // dgvMembresias
            // 
            dgvMembresias.AllowUserToAddRows = false;
            dgvMembresias.AllowUserToDeleteRows = false;
            dgvMembresias.ColumnHeadersHeight = 29;
            dgvMembresias.Location = new Point(430, 70);
            dgvMembresias.MultiSelect = false;
            dgvMembresias.Name = "dgvMembresias";
            dgvMembresias.ReadOnly = true;
            dgvMembresias.RowHeadersWidth = 51;
            dgvMembresias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMembresias.Size = new Size(550, 360);
            dgvMembresias.TabIndex = 5;
            // 
            // Fr_GestionMembresia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 450);
            Controls.Add(pnlTop);
            Controls.Add(grpCliente);
            Controls.Add(grpMembresia);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Controls.Add(dgvMembresias);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Fr_GestionMembresia";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Membresías";
            pnlTop.ResumeLayout(false);
            grpCliente.ResumeLayout(false);
            grpCliente.PerformLayout();
            grpMembresia.ResumeLayout(false);
            grpMembresia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMembresias).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpCliente;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.GroupBox grpMembresia;
        private System.Windows.Forms.ComboBox cmbTipoMembresia;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.CheckBox chkActiva;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dgvMembresias;
    

        #endregion
    }
}