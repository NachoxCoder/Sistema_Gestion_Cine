namespace UI
{
    partial class Fr_Dashboard
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
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            pnlTop = new Panel();
            lblTitle = new Label();
            chartVentasMensuales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartPeliculas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            groupBox1 = new GroupBox();
            dtpHasta = new DateTimePicker();
            dtpDesde = new DateTimePicker();
            btnExportar = new Button();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            lblVentasPeriodo = new Label();
            lblVentasDiaria = new Label();
            lblMembresiasActivas = new Label();
            lblTotalClientes = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            groupBox3 = new GroupBox();
            chartOcupacion = new System.Windows.Forms.DataVisualization.Charting.Chart();
            dgvLowStock = new DataGridView();
            groupBox4 = new GroupBox();
            lblAlertaLowStock = new Label();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartVentasMensuales).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartPeliculas).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartOcupacion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLowStock).BeginInit();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(10, 18, 80);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1344, 60);
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
            lblTitle.Size = new Size(1344, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "DASHBOARD";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chartVentasMensuales
            // 
            chartVentasMensuales.Location = new Point(862, 26);
            chartVentasMensuales.Name = "chartVentasMensuales";
            chartVentasMensuales.Size = new Size(416, 242);
            chartVentasMensuales.TabIndex = 2;
            title1.Name = "Title1";
            title1.Text = "Ventas Mensuales";
            chartVentasMensuales.Titles.Add(title1);
            // 
            // chartPeliculas
            // 
            chartPeliculas.Location = new Point(6, 26);
            chartPeliculas.Name = "chartPeliculas";
            chartPeliculas.Size = new Size(400, 242);
            chartPeliculas.TabIndex = 3;
            title2.Name = "Title1";
            title2.Text = "Películas Más Vistas";
            chartPeliculas.Titles.Add(title2);
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dtpHasta);
            groupBox1.Controls.Add(dtpDesde);
            groupBox1.Controls.Add(btnExportar);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 66);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(255, 149);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Fecha de Reporte";
            // 
            // dtpHasta
            // 
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(79, 64);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(158, 27);
            dtpHasta.TabIndex = 7;
            // 
            // dtpDesde
            // 
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(79, 26);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(158, 27);
            dtpDesde.TabIndex = 0;
            // 
            // btnExportar
            // 
            btnExportar.BackColor = Color.Sienna;
            btnExportar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExportar.ForeColor = Color.White;
            btnExportar.Location = new Point(105, 110);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(120, 33);
            btnExportar.TabIndex = 5;
            btnExportar.Text = "Exportar PDF";
            btnExportar.UseVisualStyleBackColor = false;
            btnExportar.Click += btnExportar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 69);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 6;
            label2.Text = "Fecha";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 29);
            label1.Name = "label1";
            label1.Size = new Size(51, 20);
            label1.TabIndex = 5;
            label1.Text = "Desde";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblVentasPeriodo);
            groupBox2.Controls.Add(lblVentasDiaria);
            groupBox2.Controls.Add(lblMembresiasActivas);
            groupBox2.Controls.Add(lblTotalClientes);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(295, 66);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1017, 149);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Metricas";
            // 
            // lblVentasPeriodo
            // 
            lblVentasPeriodo.AutoSize = true;
            lblVentasPeriodo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblVentasPeriodo.ForeColor = Color.Sienna;
            lblVentasPeriodo.Location = new Point(776, 83);
            lblVentasPeriodo.Name = "lblVentasPeriodo";
            lblVentasPeriodo.Size = new Size(24, 28);
            lblVentasPeriodo.TabIndex = 7;
            lblVentasPeriodo.Text = "0";
            // 
            // lblVentasDiaria
            // 
            lblVentasDiaria.AutoSize = true;
            lblVentasDiaria.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblVentasDiaria.ForeColor = Color.Sienna;
            lblVentasDiaria.Location = new Point(543, 83);
            lblVentasDiaria.Name = "lblVentasDiaria";
            lblVentasDiaria.Size = new Size(24, 28);
            lblVentasDiaria.TabIndex = 6;
            lblVentasDiaria.Text = "0";
            // 
            // lblMembresiasActivas
            // 
            lblMembresiasActivas.AutoSize = true;
            lblMembresiasActivas.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblMembresiasActivas.ForeColor = Color.Sienna;
            lblMembresiasActivas.Location = new Point(305, 83);
            lblMembresiasActivas.Name = "lblMembresiasActivas";
            lblMembresiasActivas.Size = new Size(24, 28);
            lblMembresiasActivas.TabIndex = 5;
            lblMembresiasActivas.Text = "0";
            // 
            // lblTotalClientes
            // 
            lblTotalClientes.AutoSize = true;
            lblTotalClientes.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalClientes.ForeColor = Color.Sienna;
            lblTotalClientes.Location = new Point(51, 83);
            lblTotalClientes.Name = "lblTotalClientes";
            lblTotalClientes.Size = new Size(24, 28);
            lblTotalClientes.TabIndex = 4;
            lblTotalClientes.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.Location = new Point(776, 33);
            label6.Name = "label6";
            label6.Size = new Size(186, 23);
            label6.TabIndex = 3;
            label6.Text = "Monto Ventas Periodo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.Location = new Point(521, 33);
            label5.Name = "label5";
            label5.Size = new Size(182, 23);
            label5.TabIndex = 2;
            label5.Text = "Monto Ventas del Dia";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(282, 33);
            label4.Name = "label4";
            label4.Size = new Size(161, 23);
            label4.TabIndex = 1;
            label4.Text = "Membesias Activas";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(23, 33);
            label3.Name = "label3";
            label3.Size = new Size(204, 23);
            label3.TabIndex = 0;
            label3.Text = "Total Clientes Atendidos";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(chartOcupacion);
            groupBox3.Controls.Add(chartPeliculas);
            groupBox3.Controls.Add(chartVentasMensuales);
            groupBox3.Location = new Point(12, 222);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1303, 289);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "Graficos";
            // 
            // chartOcupacion
            // 
            chartOcupacion.Location = new Point(429, 26);
            chartOcupacion.Name = "chartOcupacion";
            chartOcupacion.Size = new Size(416, 242);
            chartOcupacion.TabIndex = 4;
            title3.Name = "Title1";
            title3.Text = "Ocupacion Salas";
            chartOcupacion.Titles.Add(title3);
            // 
            // dgvLowStock
            // 
            dgvLowStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLowStock.Location = new Point(6, 26);
            dgvLowStock.Name = "dgvLowStock";
            dgvLowStock.RowHeadersWidth = 51;
            dgvLowStock.Size = new Size(821, 223);
            dgvLowStock.TabIndex = 11;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(dgvLowStock);
            groupBox4.Location = new Point(397, 517);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(860, 271);
            groupBox4.TabIndex = 12;
            groupBox4.TabStop = false;
            groupBox4.Text = "Low Stock Productos";
            // 
            // lblAlertaLowStock
            // 
            lblAlertaLowStock.AutoSize = true;
            lblAlertaLowStock.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblAlertaLowStock.Location = new Point(18, 543);
            lblAlertaLowStock.Name = "lblAlertaLowStock";
            lblAlertaLowStock.Size = new Size(0, 28);
            lblAlertaLowStock.TabIndex = 13;
            // 
            // Fr_Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1344, 778);
            Controls.Add(lblAlertaLowStock);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(pnlTop);
            Name = "Fr_Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartVentasMensuales).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartPeliculas).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartOcupacion).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLowStock).EndInit();
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentasMensuales;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPeliculas;


        #endregion

        private GroupBox groupBox1;
        private Button btnExportar;
        private Label label2;
        private Label label1;
        private DateTimePicker dtpHasta;
        private DateTimePicker dtpDesde;
        private GroupBox groupBox2;
        private Label label4;
        private Label label3;
        private Label lblMembresiasActivas;
        private Label lblTotalClientes;
        private Label label6;
        private Label label5;
        private Label lblVentasPeriodo;
        private Label lblVentasDiaria;
        private GroupBox groupBox3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOcupacion;
        private DataGridView dgvLowStock;
        private GroupBox groupBox4;
        private Label lblAlertaLowStock;
    }
}