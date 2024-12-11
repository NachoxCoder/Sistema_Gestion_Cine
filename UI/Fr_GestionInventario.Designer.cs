namespace UI
{
    partial class Fr_GestionInventario
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
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblStock = new Label();
            numStock = new NumericUpDown();
            lblPrecio = new Label();
            numPrecio = new NumericUpDown();
            btnGuardar = new Button();
            btnEliminar = new Button();
            dgvProductos = new DataGridView();
            lblAlerta = new Label();
            pnlTop.SuspendLayout();
            grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
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
            lblTitle.Text = "GESTIÓN DE INVENTARIO";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpDatos
            // 
            grpDatos.Controls.Add(lblNombre);
            grpDatos.Controls.Add(txtNombre);
            grpDatos.Controls.Add(lblDescripcion);
            grpDatos.Controls.Add(txtDescripcion);
            grpDatos.Controls.Add(lblStock);
            grpDatos.Controls.Add(numStock);
            grpDatos.Controls.Add(lblPrecio);
            grpDatos.Controls.Add(numPrecio);
            grpDatos.Location = new Point(12, 70);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(400, 200);
            grpDatos.TabIndex = 1;
            grpDatos.TabStop = false;
            grpDatos.Text = "Datos del Producto";
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(20, 30);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(100, 23);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(120, 27);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(260, 27);
            txtNombre.TabIndex = 1;
            // 
            // lblDescripcion
            // 
            lblDescripcion.Location = new Point(20, 70);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(100, 23);
            lblDescripcion.TabIndex = 2;
            lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(120, 67);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(260, 27);
            txtDescripcion.TabIndex = 3;
            // 
            // lblStock
            // 
            lblStock.Location = new Point(20, 110);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(100, 23);
            lblStock.TabIndex = 4;
            lblStock.Text = "Stock:";
            // 
            // numStock
            // 
            numStock.Location = new Point(120, 107);
            numStock.Name = "numStock";
            numStock.Size = new Size(120, 27);
            numStock.TabIndex = 5;
            // 
            // lblPrecio
            // 
            lblPrecio.Location = new Point(20, 150);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(100, 23);
            lblPrecio.TabIndex = 6;
            lblPrecio.Text = "Precio:";
            // 
            // numPrecio
            // 
            numPrecio.DecimalPlaces = 2;
            numPrecio.Location = new Point(120, 147);
            numPrecio.Name = "numPrecio";
            numPrecio.Size = new Size(120, 27);
            numPrecio.TabIndex = 7;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(10, 18, 80);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(12, 280);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(190, 40);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Red;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(222, 280);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(190, 40);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.ColumnHeadersHeight = 29;
            dgvProductos.Location = new Point(430, 70);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(550, 450);
            dgvProductos.TabIndex = 4;
            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
            // 
            // lblAlerta
            // 
            lblAlerta.AutoSize = true;
            lblAlerta.Location = new Point(12, 357);
            lblAlerta.Name = "lblAlerta";
            lblAlerta.Size = new Size(0, 20);
            lblAlerta.TabIndex = 5;
            // 
            // Fr_GestionInventario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 550);
            Controls.Add(lblAlerta);
            Controls.Add(pnlTop);
            Controls.Add(grpDatos);
            Controls.Add(btnGuardar);
            Controls.Add(btnEliminar);
            Controls.Add(dgvProductos);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Fr_GestionInventario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Inventario";
            pnlTop.ResumeLayout(false);
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel pnlTop;
        private Label lblTitle;
        private GroupBox grpDatos;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblStock;
        private NumericUpDown numStock;
        private Label lblPrecio;
        private NumericUpDown numPrecio;
        private Button btnGuardar;
        private Button btnEliminar;
        private DataGridView dgvProductos;

        #endregion

        private Label lblAlerta;
    }
}