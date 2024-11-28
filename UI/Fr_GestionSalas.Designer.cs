namespace UI
{
    partial class Fr_GestionSalas
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
            grpDatos = new GroupBox();
            txtNombre = new TextBox();
            lblNombre = new Label();
            numCapacidad = new NumericUpDown();
            lblCapacidad = new Label();
            chk3D = new CheckBox();
            pnlButacas = new Panel();
            lblFilas = new Label();
            numFilas = new NumericUpDown();
            lblButacasPorFila = new Label();
            numButacasPorFila = new NumericUpDown();
            btnGuardar = new Button();
            btnEliminar = new Button();
            dgvSalas = new DataGridView();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCapacidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numFilas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numButacasPorFila).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSalas).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(10, 18, 80);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(850, 60);
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
            lblTitle.Size = new Size(850, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "GESTIÓN DE SALAS";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpDatos
            // 
            grpDatos.Location = new Point(12, 70);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(400, 160);
            grpDatos.TabIndex = 1;
            grpDatos.TabStop = false;
            grpDatos.Text = "Datos de la Sala";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(120, 27);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(260, 27);
            txtNombre.TabIndex = 0;
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(20, 30);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(100, 23);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // numCapacidad
            // 
            numCapacidad.Location = new Point(120, 62);
            numCapacidad.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numCapacidad.Name = "numCapacidad";
            numCapacidad.Size = new Size(120, 27);
            numCapacidad.TabIndex = 0;
            // 
            // lblCapacidad
            // 
            lblCapacidad.Location = new Point(20, 65);
            lblCapacidad.Name = "lblCapacidad";
            lblCapacidad.Size = new Size(100, 23);
            lblCapacidad.TabIndex = 0;
            lblCapacidad.Text = "Capacidad:";
            // 
            // chk3D
            // 
            chk3D.AutoSize = true;
            chk3D.Location = new Point(120, 97);
            chk3D.Name = "chk3D";
            chk3D.Size = new Size(104, 24);
            chk3D.TabIndex = 0;
            chk3D.Text = "Soporte 3D";
            // 
            // pnlButacas
            // 
            pnlButacas.BorderStyle = BorderStyle.FixedSingle;
            pnlButacas.Location = new Point(12, 240);
            pnlButacas.Name = "pnlButacas";
            pnlButacas.Size = new Size(400, 100);
            pnlButacas.TabIndex = 2;
            // 
            // lblFilas
            // 
            lblFilas.Location = new Point(20, 15);
            lblFilas.Name = "lblFilas";
            lblFilas.Size = new Size(100, 23);
            lblFilas.TabIndex = 0;
            lblFilas.Text = "Filas:";
            // 
            // numFilas
            // 
            numFilas.Location = new Point(120, 12);
            numFilas.Maximum = new decimal(new int[] { 26, 0, 0, 0 });
            numFilas.Name = "numFilas";
            numFilas.Size = new Size(80, 27);
            numFilas.TabIndex = 0;
            // 
            // lblButacasPorFila
            // 
            lblButacasPorFila.Location = new Point(20, 50);
            lblButacasPorFila.Name = "lblButacasPorFila";
            lblButacasPorFila.Size = new Size(100, 23);
            lblButacasPorFila.TabIndex = 0;
            lblButacasPorFila.Text = "Butacas por fila:";
            // 
            // numButacasPorFila
            // 
            numButacasPorFila.Location = new Point(120, 47);
            numButacasPorFila.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numButacasPorFila.Name = "numButacasPorFila";
            numButacasPorFila.Size = new Size(80, 27);
            numButacasPorFila.TabIndex = 0;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(10, 18, 80);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(12, 350);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(190, 40);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Red;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(222, 350);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(190, 40);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // dgvSalas
            // 
            dgvSalas.AllowUserToAddRows = false;
            dgvSalas.AllowUserToDeleteRows = false;
            dgvSalas.ColumnHeadersHeight = 29;
            dgvSalas.Location = new Point(430, 70);
            dgvSalas.MultiSelect = false;
            dgvSalas.Name = "dgvSalas";
            dgvSalas.ReadOnly = true;
            dgvSalas.RowHeadersWidth = 51;
            dgvSalas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSalas.Size = new Size(400, 320);
            dgvSalas.TabIndex = 5;
            // 
            // Fr_GestionSalas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 420);
            Controls.Add(pnlTop);
            Controls.Add(grpDatos);
            Controls.Add(pnlButacas);
            Controls.Add(btnGuardar);
            Controls.Add(btnEliminar);
            Controls.Add(dgvSalas);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Fr_GestionSalas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Salas";
            pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numCapacidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)numFilas).EndInit();
            ((System.ComponentModel.ISupportInitialize)numButacasPorFila).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSalas).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.NumericUpDown numCapacidad;
        private System.Windows.Forms.Label lblCapacidad;
        private System.Windows.Forms.CheckBox chk3D;
        private System.Windows.Forms.Panel pnlButacas;
        private System.Windows.Forms.Label lblFilas;
        private System.Windows.Forms.NumericUpDown numFilas;
        private System.Windows.Forms.Label lblButacasPorFila;
        private System.Windows.Forms.NumericUpDown numButacasPorFila;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvSalas;
        #endregion
    }
}