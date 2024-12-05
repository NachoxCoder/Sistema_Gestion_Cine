namespace UI
{
    partial class Fr_GestionPermisos
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
            pnlTrees = new Panel();
            groupBox3 = new GroupBox();
            btnRemoverPermisoUsuario = new Button();
            btnAsignarPermisoUsuario = new Button();
            btnAsignarRolUsuario = new Button();
            btnRemoverRolUsuario = new Button();
            groupBox2 = new GroupBox();
            btnAsignarPermiso = new Button();
            btnQuitarPermiso = new Button();
            groupBox1 = new GroupBox();
            btnCrearRol = new Button();
            btnEliminarRol = new Button();
            txtNombreRol = new TextBox();
            grpUsuarios = new GroupBox();
            tvUsuarios = new TreeView();
            grpRoles = new GroupBox();
            tvRoles = new TreeView();
            grpPermisos = new GroupBox();
            tvPermisos = new TreeView();
            grpRolesPermisos = new GroupBox();
            tvRolesPermisos = new TreeView();
            grpUsuariosPermisos = new GroupBox();
            tvUsuariosPermisos = new TreeView();
            pnlTop.SuspendLayout();
            pnlTrees.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            grpUsuarios.SuspendLayout();
            grpRoles.SuspendLayout();
            grpPermisos.SuspendLayout();
            grpRolesPermisos.SuspendLayout();
            grpUsuariosPermisos.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(10, 18, 80);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1200, 60);
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
            lblTitle.Size = new Size(1200, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "GESTIÓN DE PERMISOS";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlTrees
            // 
            pnlTrees.Controls.Add(groupBox3);
            pnlTrees.Controls.Add(groupBox2);
            pnlTrees.Controls.Add(groupBox1);
            pnlTrees.Controls.Add(grpUsuarios);
            pnlTrees.Controls.Add(grpRoles);
            pnlTrees.Controls.Add(grpPermisos);
            pnlTrees.Controls.Add(grpRolesPermisos);
            pnlTrees.Controls.Add(grpUsuariosPermisos);
            pnlTrees.Dock = DockStyle.Fill;
            pnlTrees.Location = new Point(0, 0);
            pnlTrees.Name = "pnlTrees";
            pnlTrees.Padding = new Padding(10);
            pnlTrees.Size = new Size(1200, 700);
            pnlTrees.TabIndex = 1;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnRemoverPermisoUsuario);
            groupBox3.Controls.Add(btnAsignarPermisoUsuario);
            groupBox3.Controls.Add(btnAsignarRolUsuario);
            groupBox3.Controls.Add(btnRemoverRolUsuario);
            groupBox3.Location = new Point(10, 424);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(293, 111);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Usuario";
            // 
            // btnRemoverPermisoUsuario
            // 
            btnRemoverPermisoUsuario.Location = new Point(147, 68);
            btnRemoverPermisoUsuario.Name = "btnRemoverPermisoUsuario";
            btnRemoverPermisoUsuario.Size = new Size(136, 25);
            btnRemoverPermisoUsuario.TabIndex = 6;
            btnRemoverPermisoUsuario.Text = "Remover Permiso";
            btnRemoverPermisoUsuario.Click += btnRemoverPermisoUsuario_Click;
            // 
            // btnAsignarPermisoUsuario
            // 
            btnAsignarPermisoUsuario.Location = new Point(147, 27);
            btnAsignarPermisoUsuario.Name = "btnAsignarPermisoUsuario";
            btnAsignarPermisoUsuario.Size = new Size(136, 25);
            btnAsignarPermisoUsuario.TabIndex = 5;
            btnAsignarPermisoUsuario.Text = "Asignar Permiso";
            btnAsignarPermisoUsuario.Click += btnAsignarPermisoUsuario_Click;
            // 
            // btnAsignarRolUsuario
            // 
            btnAsignarRolUsuario.Location = new Point(6, 28);
            btnAsignarRolUsuario.Name = "btnAsignarRolUsuario";
            btnAsignarRolUsuario.Size = new Size(124, 25);
            btnAsignarRolUsuario.TabIndex = 3;
            btnAsignarRolUsuario.Text = "Asignar Rol";
            btnAsignarRolUsuario.Click += btnAsignarRolUsuario_Click;
            // 
            // btnRemoverRolUsuario
            // 
            btnRemoverRolUsuario.Location = new Point(6, 68);
            btnRemoverRolUsuario.Name = "btnRemoverRolUsuario";
            btnRemoverRolUsuario.Size = new Size(124, 25);
            btnRemoverRolUsuario.TabIndex = 4;
            btnRemoverRolUsuario.Text = "Remover Rol";
            btnRemoverRolUsuario.Click += btnRemoverRolUsuario_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnAsignarPermiso);
            groupBox2.Controls.Add(btnQuitarPermiso);
            groupBox2.Location = new Point(682, 424);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(336, 111);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Permiso";
            // 
            // btnAsignarPermiso
            // 
            btnAsignarPermiso.Location = new Point(6, 28);
            btnAsignarPermiso.Name = "btnAsignarPermiso";
            btnAsignarPermiso.Size = new Size(183, 25);
            btnAsignarPermiso.TabIndex = 3;
            btnAsignarPermiso.Text = "Asignar Permiso a Rol";
            btnAsignarPermiso.Click += btnAsignarPermiso_Click;
            // 
            // btnQuitarPermiso
            // 
            btnQuitarPermiso.Location = new Point(6, 68);
            btnQuitarPermiso.Name = "btnQuitarPermiso";
            btnQuitarPermiso.Size = new Size(183, 25);
            btnQuitarPermiso.TabIndex = 4;
            btnQuitarPermiso.Text = "Remover Permiso a Rol";
            btnQuitarPermiso.Click += btnQuitarPermiso_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCrearRol);
            groupBox1.Controls.Add(btnEliminarRol);
            groupBox1.Controls.Add(txtNombreRol);
            groupBox1.Location = new Point(326, 424);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(336, 111);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Rol";
            // 
            // btnCrearRol
            // 
            btnCrearRol.Location = new Point(6, 26);
            btnCrearRol.Name = "btnCrearRol";
            btnCrearRol.Size = new Size(100, 25);
            btnCrearRol.TabIndex = 1;
            btnCrearRol.Text = "Crear Rol";
            btnCrearRol.Click += btnCrearRol_Click;
            // 
            // btnEliminarRol
            // 
            btnEliminarRol.Location = new Point(6, 68);
            btnEliminarRol.Name = "btnEliminarRol";
            btnEliminarRol.Size = new Size(100, 25);
            btnEliminarRol.TabIndex = 2;
            btnEliminarRol.Text = "Eliminar Rol";
            btnEliminarRol.Click += btnEliminarRol_Click;
            // 
            // txtNombreRol
            // 
            txtNombreRol.Location = new Point(112, 26);
            txtNombreRol.Name = "txtNombreRol";
            txtNombreRol.PlaceholderText = "Nombre del nuevo rol";
            txtNombreRol.Size = new Size(200, 27);
            txtNombreRol.TabIndex = 0;
            // 
            // grpUsuarios
            // 
            grpUsuarios.Controls.Add(tvUsuarios);
            grpUsuarios.Location = new Point(10, 66);
            grpUsuarios.Name = "grpUsuarios";
            grpUsuarios.Size = new Size(220, 352);
            grpUsuarios.TabIndex = 0;
            grpUsuarios.TabStop = false;
            grpUsuarios.Text = "Usuarios";
            // 
            // tvUsuarios
            // 
            tvUsuarios.Location = new Point(3, 26);
            tvUsuarios.Name = "tvUsuarios";
            tvUsuarios.Size = new Size(211, 320);
            tvUsuarios.TabIndex = 0;
            // 
            // grpRoles
            // 
            grpRoles.Controls.Add(tvRoles);
            grpRoles.Location = new Point(251, 66);
            grpRoles.Name = "grpRoles";
            grpRoles.Size = new Size(220, 352);
            grpRoles.TabIndex = 1;
            grpRoles.TabStop = false;
            grpRoles.Text = "Roles";
            // 
            // tvRoles
            // 
            tvRoles.Location = new Point(4, 26);
            tvRoles.Name = "tvRoles";
            tvRoles.Size = new Size(211, 320);
            tvRoles.TabIndex = 1;
            // 
            // grpPermisos
            // 
            grpPermisos.Controls.Add(tvPermisos);
            grpPermisos.Location = new Point(477, 66);
            grpPermisos.Name = "grpPermisos";
            grpPermisos.Size = new Size(220, 352);
            grpPermisos.TabIndex = 2;
            grpPermisos.TabStop = false;
            grpPermisos.Text = "Permisos";
            // 
            // tvPermisos
            // 
            tvPermisos.Location = new Point(0, 26);
            tvPermisos.Name = "tvPermisos";
            tvPermisos.Size = new Size(211, 320);
            tvPermisos.TabIndex = 2;
            // 
            // grpRolesPermisos
            // 
            grpRolesPermisos.Controls.Add(tvRolesPermisos);
            grpRolesPermisos.Location = new Point(703, 66);
            grpRolesPermisos.Name = "grpRolesPermisos";
            grpRolesPermisos.Size = new Size(220, 352);
            grpRolesPermisos.TabIndex = 3;
            grpRolesPermisos.TabStop = false;
            grpRolesPermisos.Text = "Roles y sus Permisos";
            // 
            // tvRolesPermisos
            // 
            tvRolesPermisos.Location = new Point(0, 26);
            tvRolesPermisos.Name = "tvRolesPermisos";
            tvRolesPermisos.Size = new Size(211, 320);
            tvRolesPermisos.TabIndex = 3;
            // 
            // grpUsuariosPermisos
            // 
            grpUsuariosPermisos.Controls.Add(tvUsuariosPermisos);
            grpUsuariosPermisos.Location = new Point(929, 66);
            grpUsuariosPermisos.Name = "grpUsuariosPermisos";
            grpUsuariosPermisos.Size = new Size(229, 352);
            grpUsuariosPermisos.TabIndex = 4;
            grpUsuariosPermisos.TabStop = false;
            grpUsuariosPermisos.Text = "Usuarios y sus Roles y Permisos";
            // 
            // tvUsuariosPermisos
            // 
            tvUsuariosPermisos.Location = new Point(0, 26);
            tvUsuariosPermisos.Name = "tvUsuariosPermisos";
            tvUsuariosPermisos.Size = new Size(223, 320);
            tvUsuariosPermisos.TabIndex = 3;
            // 
            // Fr_GestionPermisos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 700);
            Controls.Add(pnlTop);
            Controls.Add(pnlTrees);
            Name = "Fr_GestionPermisos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Permisos";
            pnlTop.ResumeLayout(false);
            pnlTrees.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            grpUsuarios.ResumeLayout(false);
            grpRoles.ResumeLayout(false);
            grpPermisos.ResumeLayout(false);
            grpRolesPermisos.ResumeLayout(false);
            grpUsuariosPermisos.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel pnlTop;
        private Label lblTitle;
        private Panel pnlTrees;
        private GroupBox grpUsuarios;
        private GroupBox grpRoles;
        private GroupBox grpPermisos;
        private GroupBox grpRolesPermisos;
        private GroupBox grpUsuariosPermisos;
        private TextBox txtNombreRol;
        private Button btnCrearRol;
        private Button btnEliminarRol;
        private Button btnAsignarPermiso;
        private Button btnQuitarPermiso;


        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button btnAsignarRolUsuario;
        private Button btnRemoverRolUsuario;
        private Button btnRemoverPermisoUsuario;
        private Button btnAsignarPermisoUsuario;
        private TreeView tvUsuarios;
        private TreeView tvRoles;
        private TreeView tvPermisos;
        private TreeView tvRolesPermisos;
        private TreeView tvUsuariosPermisos;
    }
}