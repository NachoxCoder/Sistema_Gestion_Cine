namespace UI
{
    partial class Fr_VentaBoletos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpClient;
        private System.Windows.Forms.TextBox txtClientDNI;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.DataGridView dgvFunciones;
        private System.Windows.Forms.FlowLayoutPanel panelButacas;
        private System.Windows.Forms.ListBox lstBxButacasSeleccionadas;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnCompletarVenta;

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
            grpClient = new GroupBox();
            txtClientDNI = new TextBox();
            btnBuscarCliente = new Button();
            dgvFunciones = new DataGridView();
            panelButacas = new FlowLayoutPanel();
            lstBxButacasSeleccionadas = new ListBox();
            lblTotal = new Label();
            btnCompletarVenta = new Button();
            pnlTop.SuspendLayout();
            grpClient.SuspendLayout();
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
            pnlTop.Size = new Size(624, 60);
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
            lblTitle.Size = new Size(624, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "VENTA DE BOLETOS";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpClient
            // 
            grpClient.Controls.Add(txtClientDNI);
            grpClient.Controls.Add(btnBuscarCliente);
            grpClient.Location = new Point(12, 70);
            grpClient.Name = "grpClient";
            grpClient.Size = new Size(300, 100);
            grpClient.TabIndex = 1;
            grpClient.TabStop = false;
            grpClient.Text = "Datos del Cliente";
            // 
            // txtClientDNI
            // 
            txtClientDNI.Location = new Point(20, 40);
            txtClientDNI.Name = "txtClientDNI";
            txtClientDNI.PlaceholderText = "DNI del Cliente";
            txtClientDNI.Size = new Size(180, 27);
            txtClientDNI.TabIndex = 0;
            // 
            // btnBuscarCliente
            // 
            btnBuscarCliente.Location = new Point(210, 39);
            btnBuscarCliente.Name = "btnBuscarCliente";
            btnBuscarCliente.Size = new Size(70, 27);
            btnBuscarCliente.TabIndex = 1;
            btnBuscarCliente.Text = "Buscar";
            // 
            // dgvFunciones
            // 
            dgvFunciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFunciones.ColumnHeadersHeight = 29;
            dgvFunciones.Location = new Point(12, 180);
            dgvFunciones.MultiSelect = false;
            dgvFunciones.Name = "dgvFunciones";
            dgvFunciones.RowHeadersWidth = 51;
            dgvFunciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFunciones.Size = new Size(600, 200);
            dgvFunciones.TabIndex = 2;
            // 
            // panelButacas
            // 
            panelButacas.BorderStyle = BorderStyle.FixedSingle;
            panelButacas.Location = new Point(12, 390);
            panelButacas.Name = "panelButacas";
            panelButacas.Size = new Size(400, 200);
            panelButacas.TabIndex = 3;
            // 
            // lstBxButacasSeleccionadas
            // 
            lstBxButacasSeleccionadas.Location = new Point(422, 390);
            lstBxButacasSeleccionadas.Name = "lstBxButacasSeleccionadas";
            lstBxButacasSeleccionadas.Size = new Size(190, 144);
            lstBxButacasSeleccionadas.TabIndex = 4;
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotal.Location = new Point(422, 537);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(190, 30);
            lblTotal.TabIndex = 5;
            lblTotal.Text = "Total: $0.00";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnCompletarVenta
            // 
            btnCompletarVenta.BackColor = Color.Sienna;
            btnCompletarVenta.FlatStyle = FlatStyle.Flat;
            btnCompletarVenta.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCompletarVenta.ForeColor = Color.White;
            btnCompletarVenta.Location = new Point(422, 570);
            btnCompletarVenta.Name = "btnCompletarVenta";
            btnCompletarVenta.Size = new Size(190, 40);
            btnCompletarVenta.TabIndex = 6;
            btnCompletarVenta.Text = "COMPLETAR VENTA";
            btnCompletarVenta.UseVisualStyleBackColor = false;
            // 
            // Fr_VentaBoletos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 610);
            Controls.Add(pnlTop);
            Controls.Add(grpClient);
            Controls.Add(dgvFunciones);
            Controls.Add(panelButacas);
            Controls.Add(lstBxButacasSeleccionadas);
            Controls.Add(lblTotal);
            Controls.Add(btnCompletarVenta);
            Name = "Fr_VentaBoletos";
            Text = "Fr_VentaBoletos";
            pnlTop.ResumeLayout(false);
            grpClient.ResumeLayout(false);
            grpClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFunciones).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}