namespace UI
{
    partial class Fr_GestionPagos
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
            grpFactura = new GroupBox();
            lblNumeroFactura = new Label();
            txtNumeroFactura = new TextBox();
            lblFecha = new Label();
            txtFecha = new TextBox();
            lblMonto = new Label();
            txtMonto = new TextBox();
            grpPago = new GroupBox();
            lblMetodoPago = new Label();
            cmbMetodoPago = new ComboBox();
            pnlTransferencia = new Panel();
            lblCBU = new Label();
            txtCBU = new TextBox();
            lblTitular = new Label();
            txtTitular = new TextBox();
            pnlTarjeta = new Panel();
            lblNumeroTarjeta = new Label();
            txtNumeroTarjeta = new TextBox();
            lblVencimiento = new Label();
            txtVencimiento = new TextBox();
            lblCVV = new Label();
            txtCVV = new TextBox();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            pnlTop.SuspendLayout();
            grpFactura.SuspendLayout();
            grpPago.SuspendLayout();
            pnlTransferencia.SuspendLayout();
            pnlTarjeta.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(10, 18, 80);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(500, 60);
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
            lblTitle.Size = new Size(500, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "PROCESAR PAGO";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpFactura
            // 
            grpFactura.Controls.Add(lblNumeroFactura);
            grpFactura.Controls.Add(txtNumeroFactura);
            grpFactura.Controls.Add(lblFecha);
            grpFactura.Controls.Add(txtFecha);
            grpFactura.Controls.Add(lblMonto);
            grpFactura.Controls.Add(txtMonto);
            grpFactura.Location = new Point(12, 70);
            grpFactura.Name = "grpFactura";
            grpFactura.Size = new Size(476, 120);
            grpFactura.TabIndex = 1;
            grpFactura.TabStop = false;
            grpFactura.Text = "Datos de la Factura";
            // 
            // lblNumeroFactura
            // 
            lblNumeroFactura.Location = new Point(20, 30);
            lblNumeroFactura.Name = "lblNumeroFactura";
            lblNumeroFactura.Size = new Size(100, 23);
            lblNumeroFactura.TabIndex = 0;
            lblNumeroFactura.Text = "Número:";
            // 
            // txtNumeroFactura
            // 
            txtNumeroFactura.Location = new Point(120, 30);
            txtNumeroFactura.Name = "txtNumeroFactura";
            txtNumeroFactura.ReadOnly = true;
            txtNumeroFactura.Size = new Size(200, 27);
            txtNumeroFactura.TabIndex = 1;
            // 
            // lblFecha
            // 
            lblFecha.Location = new Point(20, 60);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(100, 23);
            lblFecha.TabIndex = 2;
            lblFecha.Text = "Fecha:";
            // 
            // txtFecha
            // 
            txtFecha.Location = new Point(120, 60);
            txtFecha.Name = "txtFecha";
            txtFecha.ReadOnly = true;
            txtFecha.Size = new Size(200, 27);
            txtFecha.TabIndex = 3;
            // 
            // lblMonto
            // 
            lblMonto.Location = new Point(20, 90);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(100, 23);
            lblMonto.TabIndex = 4;
            lblMonto.Text = "Monto Total:";
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(120, 90);
            txtMonto.Name = "txtMonto";
            txtMonto.ReadOnly = true;
            txtMonto.Size = new Size(200, 27);
            txtMonto.TabIndex = 5;
            // 
            // grpPago
            // 
            grpPago.Controls.Add(lblMetodoPago);
            grpPago.Controls.Add(cmbMetodoPago);
            grpPago.Controls.Add(pnlTransferencia);
            grpPago.Controls.Add(pnlTarjeta);
            grpPago.Location = new Point(12, 200);
            grpPago.Name = "grpPago";
            grpPago.Size = new Size(476, 200);
            grpPago.TabIndex = 2;
            grpPago.TabStop = false;
            grpPago.Text = "Datos del Pago";
            // 
            // lblMetodoPago
            // 
            lblMetodoPago.Location = new Point(20, 30);
            lblMetodoPago.Name = "lblMetodoPago";
            lblMetodoPago.Size = new Size(100, 23);
            lblMetodoPago.TabIndex = 0;
            lblMetodoPago.Text = "Método:";
            // 
            // cmbMetodoPago
            // 
            cmbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodoPago.Location = new Point(120, 27);
            cmbMetodoPago.Name = "cmbMetodoPago";
            cmbMetodoPago.Size = new Size(200, 28);
            cmbMetodoPago.TabIndex = 1;
            cmbMetodoPago.SelectedIndexChanged += cmbMetodoPago_SelectedIndexChanged;
            // 
            // pnlTransferencia
            // 
            pnlTransferencia.Controls.Add(lblCBU);
            pnlTransferencia.Controls.Add(txtCBU);
            pnlTransferencia.Controls.Add(lblTitular);
            pnlTransferencia.Controls.Add(txtTitular);
            pnlTransferencia.Location = new Point(20, 70);
            pnlTransferencia.Name = "pnlTransferencia";
            pnlTransferencia.Size = new Size(440, 100);
            pnlTransferencia.TabIndex = 2;
            // 
            // lblCBU
            // 
            lblCBU.Location = new Point(0, 10);
            lblCBU.Name = "lblCBU";
            lblCBU.Size = new Size(100, 23);
            lblCBU.TabIndex = 0;
            lblCBU.Text = "CBU:";
            // 
            // txtCBU
            // 
            txtCBU.Location = new Point(100, 7);
            txtCBU.Name = "txtCBU";
            txtCBU.Size = new Size(300, 27);
            txtCBU.TabIndex = 1;
            // 
            // lblTitular
            // 
            lblTitular.Location = new Point(0, 45);
            lblTitular.Name = "lblTitular";
            lblTitular.Size = new Size(100, 23);
            lblTitular.TabIndex = 2;
            lblTitular.Text = "Titular:";
            // 
            // txtTitular
            // 
            txtTitular.Location = new Point(100, 42);
            txtTitular.Name = "txtTitular";
            txtTitular.Size = new Size(300, 27);
            txtTitular.TabIndex = 3;
            // 
            // pnlTarjeta
            // 
            pnlTarjeta.Controls.Add(lblNumeroTarjeta);
            pnlTarjeta.Controls.Add(txtNumeroTarjeta);
            pnlTarjeta.Controls.Add(lblVencimiento);
            pnlTarjeta.Controls.Add(txtVencimiento);
            pnlTarjeta.Controls.Add(lblCVV);
            pnlTarjeta.Controls.Add(txtCVV);
            pnlTarjeta.Location = new Point(20, 70);
            pnlTarjeta.Name = "pnlTarjeta";
            pnlTarjeta.Size = new Size(440, 100);
            pnlTarjeta.TabIndex = 3;
            pnlTarjeta.Visible = false;
            // 
            // lblNumeroTarjeta
            // 
            lblNumeroTarjeta.Location = new Point(0, 10);
            lblNumeroTarjeta.Name = "lblNumeroTarjeta";
            lblNumeroTarjeta.Size = new Size(100, 23);
            lblNumeroTarjeta.TabIndex = 0;
            lblNumeroTarjeta.Text = "Número:";
            // 
            // txtNumeroTarjeta
            // 
            txtNumeroTarjeta.Location = new Point(100, 7);
            txtNumeroTarjeta.Name = "txtNumeroTarjeta";
            txtNumeroTarjeta.Size = new Size(200, 27);
            txtNumeroTarjeta.TabIndex = 1;
            // 
            // lblVencimiento
            // 
            lblVencimiento.Location = new Point(0, 45);
            lblVencimiento.Name = "lblVencimiento";
            lblVencimiento.Size = new Size(100, 23);
            lblVencimiento.TabIndex = 2;
            lblVencimiento.Text = "Vencimiento:";
            // 
            // txtVencimiento
            // 
            txtVencimiento.Location = new Point(100, 42);
            txtVencimiento.Name = "txtVencimiento";
            txtVencimiento.Size = new Size(100, 27);
            txtVencimiento.TabIndex = 3;
            // 
            // lblCVV
            // 
            lblCVV.Location = new Point(210, 45);
            lblCVV.Name = "lblCVV";
            lblCVV.Size = new Size(50, 23);
            lblCVV.TabIndex = 4;
            lblCVV.Text = "CVV:";
            // 
            // txtCVV
            // 
            txtCVV.Location = new Point(260, 42);
            txtCVV.MaxLength = 4;
            txtCVV.Name = "txtCVV";
            txtCVV.Size = new Size(60, 27);
            txtCVV.TabIndex = 5;
            // 
            // btnConfirmar
            // 
            btnConfirmar.BackColor = Color.Sienna;
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.Location = new Point(268, 420);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(100, 35);
            btnConfirmar.TabIndex = 3;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(388, 420);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 35);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            // 
            // Fr_GestionPagos
            // 
            AcceptButton = btnConfirmar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(500, 470);
            Controls.Add(pnlTop);
            Controls.Add(grpFactura);
            Controls.Add(grpPago);
            Controls.Add(btnConfirmar);
            Controls.Add(btnCancelar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Fr_GestionPagos";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Fr_GestionPagos";
            pnlTop.ResumeLayout(false);
            grpFactura.ResumeLayout(false);
            grpFactura.PerformLayout();
            grpPago.ResumeLayout(false);
            pnlTransferencia.ResumeLayout(false);
            pnlTransferencia.PerformLayout();
            pnlTarjeta.ResumeLayout(false);
            pnlTarjeta.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlTop;
        private Label lblTitle;
        private GroupBox grpFactura;
        private Label lblNumeroFactura;
        private TextBox txtNumeroFactura;
        private Label lblFecha;
        private TextBox txtFecha;
        private Label lblMonto;
        private TextBox txtMonto;
        private GroupBox grpPago;
        private Label lblMetodoPago;
        private ComboBox cmbMetodoPago;
        private Panel pnlTransferencia;
        private Label lblCBU;
        private TextBox txtCBU;
        private Label lblTitular;
        private TextBox txtTitular;
        private Panel pnlTarjeta;
        private Label lblNumeroTarjeta;
        private TextBox txtNumeroTarjeta;
        private Label lblVencimiento;
        private TextBox txtVencimiento;
        private Label lblCVV;
        private TextBox txtCVV;
        private Button btnConfirmar;
        private Button btnCancelar;

        #endregion
    }
}