namespace UI
{
    partial class Fr_MenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boletosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem membresiasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peliculasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bitacoraToolStripMenuItem;

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
            menuStrip = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesionToolStripMenuItem = new ToolStripMenuItem();
            salirSistemaToolStripMenuItem = new ToolStripMenuItem();
            ventasToolStripMenuItem = new ToolStripMenuItem();
            boletosToolStripMenuItem = new ToolStripMenuItem();
            membresiasToolStripMenuItem = new ToolStripMenuItem();
            administracionToolStripMenuItem = new ToolStripMenuItem();
            gestionDePeliculasToolStripMenuItem = new ToolStripMenuItem();
            gestionDeFuncionesToolStripMenuItem = new ToolStripMenuItem();
            gestionDeSalasToolStripMenuItem = new ToolStripMenuItem();
            dashboardToolStripMenuItem = new ToolStripMenuItem();
            sistemaToolStripMenuItem = new ToolStripMenuItem();
            gestionDeEmpleadosToolStripMenuItem = new ToolStripMenuItem();
            gestionDePermisosYRolesToolStripMenuItem = new ToolStripMenuItem();
            gestionDeBackupsToolStripMenuItem = new ToolStripMenuItem();
            comprasToolStripMenuItem = new ToolStripMenuItem();
            gestionDeInventarioToolStripMenuItem = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.BackColor = Color.Sienna;
            menuStrip.ForeColor = Color.White;
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, ventasToolStripMenuItem, administracionToolStripMenuItem, sistemaToolStripMenuItem, comprasToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 28);
            menuStrip.TabIndex = 1;
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cerrarSesionToolStripMenuItem, salirSistemaToolStripMenuItem });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(73, 24);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // cerrarSesionToolStripMenuItem
            // 
            cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            cerrarSesionToolStripMenuItem.Size = new Size(179, 26);
            cerrarSesionToolStripMenuItem.Text = "Cerrar Sesion";
            // 
            // salirSistemaToolStripMenuItem
            // 
            salirSistemaToolStripMenuItem.Name = "salirSistemaToolStripMenuItem";
            salirSistemaToolStripMenuItem.Size = new Size(179, 26);
            salirSistemaToolStripMenuItem.Text = "Salir Sistema";
            // 
            // ventasToolStripMenuItem
            // 
            ventasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { boletosToolStripMenuItem, membresiasToolStripMenuItem });
            ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            ventasToolStripMenuItem.Size = new Size(66, 24);
            ventasToolStripMenuItem.Text = "Ventas";
            // 
            // boletosToolStripMenuItem
            // 
            boletosToolStripMenuItem.Name = "boletosToolStripMenuItem";
            boletosToolStripMenuItem.Size = new Size(172, 26);
            boletosToolStripMenuItem.Text = "Boletos";
            // 
            // membresiasToolStripMenuItem
            // 
            membresiasToolStripMenuItem.Name = "membresiasToolStripMenuItem";
            membresiasToolStripMenuItem.Size = new Size(172, 26);
            membresiasToolStripMenuItem.Text = "Membresias";
            // 
            // administracionToolStripMenuItem
            // 
            administracionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gestionDePeliculasToolStripMenuItem, gestionDeFuncionesToolStripMenuItem, gestionDeSalasToolStripMenuItem, dashboardToolStripMenuItem });
            administracionToolStripMenuItem.Name = "administracionToolStripMenuItem";
            administracionToolStripMenuItem.Size = new Size(156, 24);
            administracionToolStripMenuItem.Text = "Administración Cine";
            // 
            // gestionDePeliculasToolStripMenuItem
            // 
            gestionDePeliculasToolStripMenuItem.Name = "gestionDePeliculasToolStripMenuItem";
            gestionDePeliculasToolStripMenuItem.Size = new Size(232, 26);
            gestionDePeliculasToolStripMenuItem.Text = "Gestion de Peliculas";
            // 
            // gestionDeFuncionesToolStripMenuItem
            // 
            gestionDeFuncionesToolStripMenuItem.Name = "gestionDeFuncionesToolStripMenuItem";
            gestionDeFuncionesToolStripMenuItem.Size = new Size(232, 26);
            gestionDeFuncionesToolStripMenuItem.Text = "Gestion de Funciones";
            // 
            // gestionDeSalasToolStripMenuItem
            // 
            gestionDeSalasToolStripMenuItem.Name = "gestionDeSalasToolStripMenuItem";
            gestionDeSalasToolStripMenuItem.Size = new Size(232, 26);
            gestionDeSalasToolStripMenuItem.Text = "Gestion de Salas";
            // 
            // dashboardToolStripMenuItem
            // 
            dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            dashboardToolStripMenuItem.Size = new Size(232, 26);
            dashboardToolStripMenuItem.Text = "Dashboard";
            // 
            // sistemaToolStripMenuItem
            // 
            sistemaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gestionDeEmpleadosToolStripMenuItem, gestionDePermisosYRolesToolStripMenuItem, gestionDeBackupsToolStripMenuItem });
            sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            sistemaToolStripMenuItem.Size = new Size(75, 24);
            sistemaToolStripMenuItem.Text = "Sistema";
            // 
            // gestionDeEmpleadosToolStripMenuItem
            // 
            gestionDeEmpleadosToolStripMenuItem.Name = "gestionDeEmpleadosToolStripMenuItem";
            gestionDeEmpleadosToolStripMenuItem.Size = new Size(276, 26);
            gestionDeEmpleadosToolStripMenuItem.Text = "Gestion de Empleados";
            // 
            // gestionDePermisosYRolesToolStripMenuItem
            // 
            gestionDePermisosYRolesToolStripMenuItem.Name = "gestionDePermisosYRolesToolStripMenuItem";
            gestionDePermisosYRolesToolStripMenuItem.Size = new Size(276, 26);
            gestionDePermisosYRolesToolStripMenuItem.Text = "Gestion de Permisos y Roles";
            // 
            // gestionDeBackupsToolStripMenuItem
            // 
            gestionDeBackupsToolStripMenuItem.Name = "gestionDeBackupsToolStripMenuItem";
            gestionDeBackupsToolStripMenuItem.Size = new Size(276, 26);
            gestionDeBackupsToolStripMenuItem.Text = "Gestion de Backups";
            // 
            // comprasToolStripMenuItem
            // 
            comprasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gestionDeInventarioToolStripMenuItem });
            comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            comprasToolStripMenuItem.Size = new Size(82, 24);
            comprasToolStripMenuItem.Text = "Compras";
            // 
            // gestionDeInventarioToolStripMenuItem
            // 
            gestionDeInventarioToolStripMenuItem.Name = "gestionDeInventarioToolStripMenuItem";
            gestionDeInventarioToolStripMenuItem.Size = new Size(233, 26);
            gestionDeInventarioToolStripMenuItem.Text = "Gestion de Inventario";
            // 
            // Fr_MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Name = "Fr_MenuPrincipal";
            Text = "Fr_MenuPrincipal";
            WindowState = FormWindowState.Maximized;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStripMenuItem comprasToolStripMenuItem;
        private ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private ToolStripMenuItem salirSistemaToolStripMenuItem;
        private ToolStripMenuItem gestionDePeliculasToolStripMenuItem;
        private ToolStripMenuItem gestionDeFuncionesToolStripMenuItem;
        private ToolStripMenuItem gestionDeSalasToolStripMenuItem;
        private ToolStripMenuItem gestionDeEmpleadosToolStripMenuItem;
        private ToolStripMenuItem gestionDePermisosYRolesToolStripMenuItem;
        private ToolStripMenuItem gestionDeBackupsToolStripMenuItem;
        private ToolStripMenuItem gestionDeInventarioToolStripMenuItem;
        private ToolStripMenuItem dashboardToolStripMenuItem;
    }
}