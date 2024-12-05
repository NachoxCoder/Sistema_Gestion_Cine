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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Fr_Dashboard";

            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tlpMetricas = new System.Windows.Forms.TableLayoutPanel();
            this.pnlVentasHoy = new System.Windows.Forms.Panel();
            this.lblVentasHoy = new System.Windows.Forms.Label();
            this.lblTituloVentas = new System.Windows.Forms.Label();
            this.pnlClientes = new System.Windows.Forms.Panel();
            this.lblTotalClientes = new System.Windows.Forms.Label();
            this.lblTituloClientes = new System.Windows.Forms.Label();
            this.pnlMembresias = new System.Windows.Forms.Panel();
            this.lblMembresiasActivas = new System.Windows.Forms.Label();
            this.lblTituloMembresias = new System.Windows.Forms.Label();
            this.pnlFunciones = new System.Windows.Forms.Panel();
            this.lblFuncionesActivas = new System.Windows.Forms.Label();
            this.lblTituloFunciones = new System.Windows.Forms.Label();
            this.chartVentasMensuales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPeliculas = new System.Windows.Forms.DataVisualization.Charting.Chart();

            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(10, 18, 80);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 60;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Sienna;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Text = "DASHBOARD";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpMetricas
            // 
            this.tlpMetricas.ColumnCount = 4;
            this.tlpMetricas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMetricas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMetricas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMetricas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMetricas.Controls.Add(this.pnlVentasHoy, 0, 0);
            this.tlpMetricas.Controls.Add(this.pnlClientes, 1, 0);
            this.tlpMetricas.Controls.Add(this.pnlMembresias, 2, 0);
            this.tlpMetricas.Controls.Add(this.pnlFunciones, 3, 0);
            this.tlpMetricas.Location = new System.Drawing.Point(12, 76);
            this.tlpMetricas.Height = 100;
            this.tlpMetricas.Dock = System.Windows.Forms.DockStyle.Top;

            // Charts
            this.chartVentasMensuales.Location = new System.Drawing.Point(12, 188);
            this.chartVentasMensuales.Size = new System.Drawing.Size(600, 400);
            this.chartVentasMensuales.Titles.Add("Ventas Mensuales");

            this.chartPeliculas.Location = new System.Drawing.Point(618, 188);
            this.chartPeliculas.Size = new System.Drawing.Size(400, 400);
            this.chartPeliculas.Titles.Add("Películas Más Vistas");

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.tlpMetricas);
            this.Controls.Add(this.chartVentasMensuales);
            this.Controls.Add(this.chartPeliculas);
            this.Name = "Fr_Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tlpMetricas;
        private System.Windows.Forms.Panel pnlVentasHoy;
        private System.Windows.Forms.Label lblVentasHoy;
        private System.Windows.Forms.Label lblTituloVentas;
        private System.Windows.Forms.Panel pnlClientes;
        private System.Windows.Forms.Label lblTotalClientes;
        private System.Windows.Forms.Label lblTituloClientes;
        private System.Windows.Forms.Panel pnlMembresias;
        private System.Windows.Forms.Label lblMembresiasActivas;
        private System.Windows.Forms.Label lblTituloMembresias;
        private System.Windows.Forms.Panel pnlFunciones;
        private System.Windows.Forms.Label lblFuncionesActivas;
        private System.Windows.Forms.Label lblTituloFunciones;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentasMensuales;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPeliculas;


        #endregion
    }
}