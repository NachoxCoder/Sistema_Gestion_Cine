namespace UI
{
    partial class Fr_GestionFacturas
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
            lblNumeroFactura = new Label();
            txtNumeroFactura = new TextBox();
            lblProveedor = new Label();
            cmbProveedor = new ComboBox();
            lblFechaEmision = new Label();
            dtpFechaEmision = new DateTimePicker();
            lblOrdenCompra = new Label();
            dgvOrdenCompra = new DataGridView();
            btnCargarFactura = new Button();
            label1 = new Label();
            dgvFacturas = new DataGridView();
            btnPagarFactura = new Button();
            pnlTop.SuspendLayout();
            grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrdenCompra).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(10, 18, 80);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1360, 60);
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
            lblTitle.Size = new Size(1360, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "GESTIONAR FACTURAS";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpDatos
            // 
            grpDatos.Controls.Add(lblNumeroFactura);
            grpDatos.Controls.Add(txtNumeroFactura);
            grpDatos.Controls.Add(lblProveedor);
            grpDatos.Controls.Add(cmbProveedor);
            grpDatos.Controls.Add(lblFechaEmision);
            grpDatos.Controls.Add(dtpFechaEmision);
            grpDatos.Location = new Point(12, 70);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(736, 107);
            grpDatos.TabIndex = 1;
            grpDatos.TabStop = false;
            grpDatos.Text = "Datos de la Factura";
            // 
            // lblNumeroFactura
            // 
            lblNumeroFactura.Location = new Point(20, 30);
            lblNumeroFactura.Name = "lblNumeroFactura";
            lblNumeroFactura.Size = new Size(100, 23);
            lblNumeroFactura.TabIndex = 0;
            lblNumeroFactura.Text = "Nro. Factura:";
            // 
            // txtNumeroFactura
            // 
            txtNumeroFactura.Location = new Point(120, 27);
            txtNumeroFactura.Name = "txtNumeroFactura";
            txtNumeroFactura.Size = new Size(200, 27);
            txtNumeroFactura.TabIndex = 1;
            // 
            // lblProveedor
            // 
            lblProveedor.Location = new Point(340, 30);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(80, 23);
            lblProveedor.TabIndex = 2;
            lblProveedor.Text = "Proveedor:";
            // 
            // cmbProveedor
            // 
            cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedor.Location = new Point(420, 27);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(300, 28);
            cmbProveedor.TabIndex = 3;
            cmbProveedor.SelectedIndexChanged += cmbProveedor_SelectedIndexChanged;
            // 
            // lblFechaEmision
            // 
            lblFechaEmision.Location = new Point(20, 70);
            lblFechaEmision.Name = "lblFechaEmision";
            lblFechaEmision.Size = new Size(100, 23);
            lblFechaEmision.TabIndex = 4;
            lblFechaEmision.Text = "Fecha:";
            // 
            // dtpFechaEmision
            // 
            dtpFechaEmision.Format = DateTimePickerFormat.Short;
            dtpFechaEmision.Location = new Point(120, 67);
            dtpFechaEmision.Name = "dtpFechaEmision";
            dtpFechaEmision.Size = new Size(200, 27);
            dtpFechaEmision.TabIndex = 5;
            // 
            // lblOrdenCompra
            // 
            lblOrdenCompra.Location = new Point(12, 192);
            lblOrdenCompra.Name = "lblOrdenCompra";
            lblOrdenCompra.Size = new Size(238, 23);
            lblOrdenCompra.TabIndex = 2;
            lblOrdenCompra.Text = "Seleccione Orden de Compra:";
            // 
            // dgvOrdenCompra
            // 
            dgvOrdenCompra.AllowUserToAddRows = false;
            dgvOrdenCompra.AllowUserToDeleteRows = false;
            dgvOrdenCompra.ColumnHeadersHeight = 29;
            dgvOrdenCompra.Location = new Point(12, 218);
            dgvOrdenCompra.MultiSelect = false;
            dgvOrdenCompra.Name = "dgvOrdenCompra";
            dgvOrdenCompra.ReadOnly = true;
            dgvOrdenCompra.RowHeadersWidth = 51;
            dgvOrdenCompra.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrdenCompra.Size = new Size(736, 234);
            dgvOrdenCompra.TabIndex = 3;
            dgvOrdenCompra.SelectionChanged += dgvOrdenCompra_SelectionChanged;
            // 
            // btnCargarFactura
            // 
            btnCargarFactura.BackColor = Color.Sienna;
            btnCargarFactura.Enabled = false;
            btnCargarFactura.FlatStyle = FlatStyle.Flat;
            btnCargarFactura.ForeColor = Color.White;
            btnCargarFactura.Location = new Point(598, 478);
            btnCargarFactura.Name = "btnCargarFactura";
            btnCargarFactura.Size = new Size(150, 40);
            btnCargarFactura.TabIndex = 4;
            btnCargarFactura.Text = "CARGAR FACTURA";
            btnCargarFactura.UseVisualStyleBackColor = false;
            btnCargarFactura.Click += btnCargarFactura_Click;
            // 
            // label1
            // 
            label1.Location = new Point(765, 79);
            label1.Name = "label1";
            label1.Size = new Size(238, 23);
            label1.TabIndex = 5;
            label1.Text = "Facturas Cargadas en Sistema";
            // 
            // dgvFacturas
            // 
            dgvFacturas.AllowUserToAddRows = false;
            dgvFacturas.AllowUserToDeleteRows = false;
            dgvFacturas.ColumnHeadersHeight = 29;
            dgvFacturas.Location = new Point(765, 105);
            dgvFacturas.MultiSelect = false;
            dgvFacturas.Name = "dgvFacturas";
            dgvFacturas.ReadOnly = true;
            dgvFacturas.RowHeadersWidth = 51;
            dgvFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFacturas.Size = new Size(583, 347);
            dgvFacturas.TabIndex = 6;
            // 
            // btnPagarFactura
            // 
            btnPagarFactura.BackColor = Color.Sienna;
            btnPagarFactura.Enabled = false;
            btnPagarFactura.FlatStyle = FlatStyle.Flat;
            btnPagarFactura.ForeColor = Color.White;
            btnPagarFactura.Location = new Point(1198, 478);
            btnPagarFactura.Name = "btnPagarFactura";
            btnPagarFactura.Size = new Size(150, 40);
            btnPagarFactura.TabIndex = 7;
            btnPagarFactura.Text = "PAGAR FACTURA";
            btnPagarFactura.UseVisualStyleBackColor = false;
            btnPagarFactura.Click += btnPagarFactura_Click;
            // 
            // Fr_GestionFacturas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1360, 530);
            Controls.Add(btnPagarFactura);
            Controls.Add(dgvFacturas);
            Controls.Add(label1);
            Controls.Add(pnlTop);
            Controls.Add(grpDatos);
            Controls.Add(lblOrdenCompra);
            Controls.Add(dgvOrdenCompra);
            Controls.Add(btnCargarFactura);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Fr_GestionFacturas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cargar Factura";
            pnlTop.ResumeLayout(false);
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrdenCompra).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).EndInit();
            ResumeLayout(false);
        }

        private Panel pnlTop;
        private Label lblTitle;
        private GroupBox grpDatos;
        private Label lblNumeroFactura;
        private TextBox txtNumeroFactura;
        private Label lblProveedor;
        private ComboBox cmbProveedor;
        private Label lblFechaEmision;
        private DateTimePicker dtpFechaEmision;
        private Label lblOrdenCompra;
        private DataGridView dgvOrdenCompra;
        private Button btnCargarFactura;

        #endregion

        private Label label1;
        private DataGridView dgvFacturas;
        private Button btnPagarFactura;
    }
}