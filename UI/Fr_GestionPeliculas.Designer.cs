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
            dgvPeliculas = new DataGridView();
            dgvFunciones = new DataGridView();
            btnGuardarPelicula = new Button();
            btnEliminarPelicula = new Button();
            groupBox1 = new GroupBox();
            chkActiva = new CheckBox();
            numDuracion = new NumericUpDown();
            txtSinopsis = new TextBox();
            txtTitulo = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnModificarPelicula = new Button();
            groupBox2 = new GroupBox();
            dtpHoraFin = new DateTimePicker();
            dtpHoraInicio = new DateTimePicker();
            dtpFecha = new DateTimePicker();
            numPrecio = new NumericUpDown();
            label10 = new Label();
            label9 = new Label();
            cmbSala = new ComboBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            btnEliminarFuncion = new Button();
            btnModificarFuncion = new Button();
            btnNuevaFuncion = new Button();
            txtRating = new TextBox();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPeliculas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvFunciones).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDuracion).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPrecio).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(10, 18, 80);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1357, 60);
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
            lblTitle.Size = new Size(1357, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "GESTION DE PELICULAS Y FUNCIONES";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvPeliculas
            // 
            dgvPeliculas.AllowUserToAddRows = false;
            dgvPeliculas.AllowUserToDeleteRows = false;
            dgvPeliculas.ColumnHeadersHeight = 29;
            dgvPeliculas.Location = new Point(6, 26);
            dgvPeliculas.MultiSelect = false;
            dgvPeliculas.Name = "dgvPeliculas";
            dgvPeliculas.ReadOnly = true;
            dgvPeliculas.RowHeadersWidth = 51;
            dgvPeliculas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPeliculas.Size = new Size(665, 377);
            dgvPeliculas.TabIndex = 3;
            // 
            // dgvFunciones
            // 
            dgvFunciones.AllowUserToAddRows = false;
            dgvFunciones.AllowUserToDeleteRows = false;
            dgvFunciones.ColumnHeadersHeight = 29;
            dgvFunciones.Location = new Point(13, 26);
            dgvFunciones.MultiSelect = false;
            dgvFunciones.Name = "dgvFunciones";
            dgvFunciones.ReadOnly = true;
            dgvFunciones.RowHeadersWidth = 51;
            dgvFunciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFunciones.Size = new Size(623, 377);
            dgvFunciones.TabIndex = 4;
            // 
            // btnGuardarPelicula
            // 
            btnGuardarPelicula.BackColor = Color.Sienna;
            btnGuardarPelicula.FlatStyle = FlatStyle.Flat;
            btnGuardarPelicula.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGuardarPelicula.ForeColor = Color.White;
            btnGuardarPelicula.Location = new Point(12, 564);
            btnGuardarPelicula.Name = "btnGuardarPelicula";
            btnGuardarPelicula.Size = new Size(190, 40);
            btnGuardarPelicula.TabIndex = 7;
            btnGuardarPelicula.Text = "GUARDAR PELICULA";
            btnGuardarPelicula.UseVisualStyleBackColor = false;
            // 
            // btnEliminarPelicula
            // 
            btnEliminarPelicula.BackColor = Color.Sienna;
            btnEliminarPelicula.FlatStyle = FlatStyle.Flat;
            btnEliminarPelicula.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEliminarPelicula.ForeColor = Color.White;
            btnEliminarPelicula.Location = new Point(481, 564);
            btnEliminarPelicula.Name = "btnEliminarPelicula";
            btnEliminarPelicula.Size = new Size(190, 40);
            btnEliminarPelicula.TabIndex = 8;
            btnEliminarPelicula.Text = "ELIMINAR PELICULA";
            btnEliminarPelicula.UseVisualStyleBackColor = false;
            btnEliminarPelicula.Click += btnEliminarPelicula_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chkActiva);
            groupBox1.Controls.Add(numDuracion);
            groupBox1.Controls.Add(txtSinopsis);
            groupBox1.Controls.Add(txtTitulo);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnModificarPelicula);
            groupBox1.Controls.Add(dgvPeliculas);
            groupBox1.Controls.Add(btnEliminarPelicula);
            groupBox1.Controls.Add(btnGuardarPelicula);
            groupBox1.Location = new Point(0, 66);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(685, 610);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Peliculas";
            // 
            // chkActiva
            // 
            chkActiva.AutoSize = true;
            chkActiva.Location = new Point(554, 528);
            chkActiva.Name = "chkActiva";
            chkActiva.Size = new Size(72, 24);
            chkActiva.TabIndex = 18;
            chkActiva.Text = "Activa";
            chkActiva.UseVisualStyleBackColor = true;
            // 
            // numDuracion
            // 
            numDuracion.Location = new Point(86, 521);
            numDuracion.Name = "numDuracion";
            numDuracion.Size = new Size(150, 27);
            numDuracion.TabIndex = 17;
            // 
            // txtSinopsis
            // 
            txtSinopsis.Location = new Point(86, 462);
            txtSinopsis.Multiline = true;
            txtSinopsis.Name = "txtSinopsis";
            txtSinopsis.Size = new Size(569, 53);
            txtSinopsis.TabIndex = 16;
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(86, 416);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(569, 27);
            txtTitulo.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(246, 528);
            label4.Name = "label4";
            label4.Size = new Size(52, 20);
            label4.TabIndex = 13;
            label4.Text = "Rating";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 528);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 12;
            label3.Text = "Duracion";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 470);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 11;
            label2.Text = "Sinopsis";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 423);
            label1.Name = "label1";
            label1.Size = new Size(47, 20);
            label1.TabIndex = 10;
            label1.Text = "Titulo";
            // 
            // btnModificarPelicula
            // 
            btnModificarPelicula.BackColor = Color.Sienna;
            btnModificarPelicula.FlatStyle = FlatStyle.Flat;
            btnModificarPelicula.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnModificarPelicula.ForeColor = Color.White;
            btnModificarPelicula.Location = new Point(238, 564);
            btnModificarPelicula.Name = "btnModificarPelicula";
            btnModificarPelicula.Size = new Size(205, 40);
            btnModificarPelicula.TabIndex = 9;
            btnModificarPelicula.Text = "MODIFICAR PELICULA";
            btnModificarPelicula.UseVisualStyleBackColor = false;
            btnModificarPelicula.Click += btnModificarPelicula_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dtpHoraFin);
            groupBox2.Controls.Add(dtpHoraInicio);
            groupBox2.Controls.Add(dtpFecha);
            groupBox2.Controls.Add(numPrecio);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(cmbSala);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(btnEliminarFuncion);
            groupBox2.Controls.Add(btnModificarFuncion);
            groupBox2.Controls.Add(btnNuevaFuncion);
            groupBox2.Controls.Add(dgvFunciones);
            groupBox2.Location = new Point(691, 66);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(654, 610);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Funciones";
            // 
            // dtpHoraFin
            // 
            dtpHoraFin.CustomFormat = "HH:mm";
            dtpHoraFin.Format = DateTimePickerFormat.Custom;
            dtpHoraFin.Location = new Point(551, 419);
            dtpHoraFin.Name = "dtpHoraFin";
            dtpHoraFin.ShowUpDown = true;
            dtpHoraFin.Size = new Size(85, 27);
            dtpHoraFin.TabIndex = 21;
            // 
            // dtpHoraInicio
            // 
            dtpHoraInicio.CustomFormat = "HH:mm";
            dtpHoraInicio.Format = DateTimePickerFormat.Custom;
            dtpHoraInicio.Location = new Point(328, 419);
            dtpHoraInicio.Name = "dtpHoraInicio";
            dtpHoraInicio.ShowUpDown = true;
            dtpHoraInicio.Size = new Size(85, 27);
            dtpHoraInicio.TabIndex = 20;
            dtpHoraInicio.ValueChanged += dtpHoraDesde_ValueChanged;
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(66, 418);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(114, 27);
            dtpFecha.TabIndex = 19;
            // 
            // numPrecio
            // 
            numPrecio.Location = new Point(398, 502);
            numPrecio.Name = "numPrecio";
            numPrecio.Size = new Size(160, 27);
            numPrecio.TabIndex = 18;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(326, 505);
            label10.Name = "label10";
            label10.Size = new Size(50, 20);
            label10.TabIndex = 17;
            label10.Text = "Precio";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(13, 505);
            label9.Name = "label9";
            label9.Size = new Size(37, 20);
            label9.TabIndex = 16;
            label9.Text = "Sala";
            // 
            // cmbSala
            // 
            cmbSala.FormattingEnabled = true;
            cmbSala.Location = new Point(56, 502);
            cmbSala.Name = "cmbSala";
            cmbSala.Size = new Size(218, 28);
            cmbSala.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(461, 426);
            label8.Name = "label8";
            label8.Size = new Size(65, 20);
            label8.TabIndex = 14;
            label8.Text = "Hora Fin";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(234, 425);
            label7.Name = "label7";
            label7.Size = new Size(82, 20);
            label7.TabIndex = 13;
            label7.Text = "Hora Inicio";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 423);
            label6.Name = "label6";
            label6.Size = new Size(47, 20);
            label6.TabIndex = 12;
            label6.Text = "Fecha";
            // 
            // btnEliminarFuncion
            // 
            btnEliminarFuncion.BackColor = Color.Sienna;
            btnEliminarFuncion.FlatStyle = FlatStyle.Flat;
            btnEliminarFuncion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEliminarFuncion.ForeColor = Color.White;
            btnEliminarFuncion.Location = new Point(449, 563);
            btnEliminarFuncion.Name = "btnEliminarFuncion";
            btnEliminarFuncion.Size = new Size(190, 40);
            btnEliminarFuncion.TabIndex = 10;
            btnEliminarFuncion.Text = "ELIMINAR FUNCION";
            btnEliminarFuncion.UseVisualStyleBackColor = false;
            btnEliminarFuncion.Click += btnEliminarFuncion_Click;
            // 
            // btnModificarFuncion
            // 
            btnModificarFuncion.BackColor = Color.Sienna;
            btnModificarFuncion.FlatStyle = FlatStyle.Flat;
            btnModificarFuncion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnModificarFuncion.ForeColor = Color.White;
            btnModificarFuncion.Location = new Point(228, 563);
            btnModificarFuncion.Name = "btnModificarFuncion";
            btnModificarFuncion.Size = new Size(201, 40);
            btnModificarFuncion.TabIndex = 11;
            btnModificarFuncion.Text = "MODIFICAR FUNCION";
            btnModificarFuncion.UseVisualStyleBackColor = false;
            btnModificarFuncion.Click += btnModificarFuncion_Click;
            // 
            // btnNuevaFuncion
            // 
            btnNuevaFuncion.BackColor = Color.Sienna;
            btnNuevaFuncion.FlatStyle = FlatStyle.Flat;
            btnNuevaFuncion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNuevaFuncion.ForeColor = Color.White;
            btnNuevaFuncion.Location = new Point(13, 563);
            btnNuevaFuncion.Name = "btnNuevaFuncion";
            btnNuevaFuncion.Size = new Size(190, 40);
            btnNuevaFuncion.TabIndex = 10;
            btnNuevaFuncion.Text = "CREAR FUNCION";
            btnNuevaFuncion.UseVisualStyleBackColor = false;
            // 
            // txtRating
            // 
            txtRating.Location = new Point(304, 589);
            txtRating.Name = "txtRating";
            txtRating.Size = new Size(200, 27);
            txtRating.TabIndex = 18;
            // 
            // Fr_GestionPeliculas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1357, 688);
            Controls.Add(txtRating);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(pnlTop);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Fr_GestionPeliculas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Películas y Funciones";
            pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPeliculas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvFunciones).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDuracion).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPrecio).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvPeliculas;
        private System.Windows.Forms.DataGridView dgvFunciones;

        #endregion

        private Button btnGuardarPelicula;
        private Button btnEliminarPelicula;
        private GroupBox groupBox1;
        private Button btnModificarPelicula;
        private GroupBox groupBox2;
        private Button btnEliminarFuncion;
        private Button btnModificarFuncion;
        private Button btnNuevaFuncion;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label7;
        private Label label6;
        private NumericUpDown numPrecio;
        private Label label10;
        private Label label9;
        private ComboBox cmbSala;
        private Label label8;
        private CheckBox chkActiva;
        private NumericUpDown numDuracion;
        private TextBox txtSinopsis;
        private TextBox txtTitulo;
        private TextBox txtRating;
        private DateTimePicker dtpHoraInicio;
        private DateTimePicker dtpFecha;
        private DateTimePicker dtpHoraFin;
    }
}