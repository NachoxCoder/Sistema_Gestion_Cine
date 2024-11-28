namespace UI
{
    partial class Fr_GestionPeliculas
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
            grpPelicula = new GroupBox();
            lblTitulo = new Label();
            txtTitulo = new TextBox();
            lblSinopsis = new Label();
            txtSinopsis = new TextBox();
            lblDuracion = new Label();
            numDuracion = new NumericUpDown();
            lblRating = new Label();
            txtRating = new TextBox();
            chkActiva = new CheckBox();
            btnGuardarPelicula = new Button();
            grpFuncion = new GroupBox();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            lblHora = new Label();
            dtpHora = new DateTimePicker();
            lblSala = new Label();
            cmbSala = new ComboBox();
            lblPrecio = new Label();
            numPrecio = new NumericUpDown();
            btnNuevaFuncion = new Button();
            dgvPeliculas = new DataGridView();
            dgvFunciones = new DataGridView();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDuracion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPeliculas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvFunciones).BeginInit();
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
            lblTitle.Text = "GESTIÓN DE PELÍCULAS Y FUNCIONES";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpPelicula
            // 
            grpPelicula.Location = new Point(12, 70);
            grpPelicula.Name = "grpPelicula";
            grpPelicula.Size = new Size(400, 300);
            grpPelicula.TabIndex = 1;
            grpPelicula.TabStop = false;
            grpPelicula.Text = "Datos de la Película";
            // 
            // lblTitulo
            // 
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(100, 23);
            lblTitulo.TabIndex = 0;
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(0, 0);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(100, 27);
            txtTitulo.TabIndex = 0;
            // 
            // lblSinopsis
            // 
            lblSinopsis.Location = new Point(0, 0);
            lblSinopsis.Name = "lblSinopsis";
            lblSinopsis.Size = new Size(100, 23);
            lblSinopsis.TabIndex = 0;
            // 
            // txtSinopsis
            // 
            txtSinopsis.Location = new Point(0, 0);
            txtSinopsis.Name = "txtSinopsis";
            txtSinopsis.Size = new Size(100, 27);
            txtSinopsis.TabIndex = 0;
            // 
            // lblDuracion
            // 
            lblDuracion.Location = new Point(0, 0);
            lblDuracion.Name = "lblDuracion";
            lblDuracion.Size = new Size(100, 23);
            lblDuracion.TabIndex = 0;
            // 
            // numDuracion
            // 
            numDuracion.Location = new Point(0, 0);
            numDuracion.Name = "numDuracion";
            numDuracion.Size = new Size(120, 27);
            numDuracion.TabIndex = 0;
            // 
            // lblRating
            // 
            lblRating.Location = new Point(0, 0);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(100, 23);
            lblRating.TabIndex = 0;
            // 
            // txtRating
            // 
            txtRating.Location = new Point(0, 0);
            txtRating.Name = "txtRating";
            txtRating.Size = new Size(100, 27);
            txtRating.TabIndex = 0;
            // 
            // chkActiva
            // 
            chkActiva.Location = new Point(0, 0);
            chkActiva.Name = "chkActiva";
            chkActiva.Size = new Size(104, 24);
            chkActiva.TabIndex = 0;
            // 
            // btnGuardarPelicula
            // 
            btnGuardarPelicula.Location = new Point(0, 0);
            btnGuardarPelicula.Name = "btnGuardarPelicula";
            btnGuardarPelicula.Size = new Size(75, 23);
            btnGuardarPelicula.TabIndex = 0;
            // 
            // grpFuncion
            // 
            grpFuncion.Location = new Point(12, 380);
            grpFuncion.Name = "grpFuncion";
            grpFuncion.Size = new Size(400, 250);
            grpFuncion.TabIndex = 2;
            grpFuncion.TabStop = false;
            grpFuncion.Text = "Nueva Función";
            // 
            // lblFecha
            // 
            lblFecha.Location = new Point(0, 0);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(100, 23);
            lblFecha.TabIndex = 0;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(0, 0);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(200, 27);
            dtpFecha.TabIndex = 0;
            // 
            // lblHora
            // 
            lblHora.Location = new Point(0, 0);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(100, 23);
            lblHora.TabIndex = 0;
            // 
            // dtpHora
            // 
            dtpHora.Location = new Point(0, 0);
            dtpHora.Name = "dtpHora";
            dtpHora.Size = new Size(200, 27);
            dtpHora.TabIndex = 0;
            // 
            // lblSala
            // 
            lblSala.Location = new Point(0, 0);
            lblSala.Name = "lblSala";
            lblSala.Size = new Size(100, 23);
            lblSala.TabIndex = 0;
            // 
            // cmbSala
            // 
            cmbSala.Location = new Point(0, 0);
            cmbSala.Name = "cmbSala";
            cmbSala.Size = new Size(121, 28);
            cmbSala.TabIndex = 0;
            // 
            // lblPrecio
            // 
            lblPrecio.Location = new Point(0, 0);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(100, 23);
            lblPrecio.TabIndex = 0;
            // 
            // numPrecio
            // 
            numPrecio.Location = new Point(0, 0);
            numPrecio.Name = "numPrecio";
            numPrecio.Size = new Size(120, 27);
            numPrecio.TabIndex = 0;
            // 
            // btnNuevaFuncion
            // 
            btnNuevaFuncion.Location = new Point(0, 0);
            btnNuevaFuncion.Name = "btnNuevaFuncion";
            btnNuevaFuncion.Size = new Size(75, 23);
            btnNuevaFuncion.TabIndex = 0;
            // 
            // dgvPeliculas
            // 
            dgvPeliculas.AllowUserToAddRows = false;
            dgvPeliculas.AllowUserToDeleteRows = false;
            dgvPeliculas.ColumnHeadersHeight = 29;
            dgvPeliculas.Location = new Point(430, 70);
            dgvPeliculas.MultiSelect = false;
            dgvPeliculas.Name = "dgvPeliculas";
            dgvPeliculas.ReadOnly = true;
            dgvPeliculas.RowHeadersWidth = 51;
            dgvPeliculas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPeliculas.Size = new Size(550, 250);
            dgvPeliculas.TabIndex = 3;
            // 
            // dgvFunciones
            // 
            dgvFunciones.AllowUserToAddRows = false;
            dgvFunciones.AllowUserToDeleteRows = false;
            dgvFunciones.ColumnHeadersHeight = 29;
            dgvFunciones.Location = new Point(430, 380);
            dgvFunciones.MultiSelect = false;
            dgvFunciones.Name = "dgvFunciones";
            dgvFunciones.ReadOnly = true;
            dgvFunciones.RowHeadersWidth = 51;
            dgvFunciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFunciones.Size = new Size(550, 250);
            dgvFunciones.TabIndex = 4;
            // 
            // Fr_GestionPeliculas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 650);
            Controls.Add(pnlTop);
            Controls.Add(grpPelicula);
            Controls.Add(grpFuncion);
            Controls.Add(dgvPeliculas);
            Controls.Add(dgvFunciones);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Fr_GestionPeliculas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Películas y Funciones";
            pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numDuracion).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPeliculas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvFunciones).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpPelicula;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label lblSinopsis;
        private System.Windows.Forms.TextBox txtSinopsis;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.NumericUpDown numDuracion;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.TextBox txtRating;
        private System.Windows.Forms.CheckBox chkActiva;
        private System.Windows.Forms.Button btnGuardarPelicula;
        private System.Windows.Forms.GroupBox grpFuncion;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.Label lblSala;
        private System.Windows.Forms.ComboBox cmbSala;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.NumericUpDown numPrecio;
        private System.Windows.Forms.Button btnNuevaFuncion;
        private System.Windows.Forms.DataGridView dgvPeliculas;
        private System.Windows.Forms.DataGridView dgvFunciones;
        #endregion
    }
}