namespace UI
{
    partial class Fr_GestionBackupRestore
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
            dgvBackups = new DataGridView();
            btnBackup = new Button();
            btnRestore = new Button();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBackups).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(10, 18, 80);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Margin = new Padding(3, 4, 3, 4);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(914, 80);
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
            lblTitle.Size = new Size(914, 80);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "GESTIÓN DE BACKUP";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvBackups
            // 
            dgvBackups.AllowUserToAddRows = false;
            dgvBackups.AllowUserToDeleteRows = false;
            dgvBackups.ColumnHeadersHeight = 29;
            dgvBackups.Location = new Point(14, 101);
            dgvBackups.Margin = new Padding(3, 4, 3, 4);
            dgvBackups.MultiSelect = false;
            dgvBackups.Name = "dgvBackups";
            dgvBackups.ReadOnly = true;
            dgvBackups.RowHeadersWidth = 51;
            dgvBackups.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBackups.Size = new Size(887, 376);
            dgvBackups.TabIndex = 1;
            // 
            // btnBackup
            // 
            btnBackup.BackColor = Color.FromArgb(10, 18, 80);
            btnBackup.FlatStyle = FlatStyle.Flat;
            btnBackup.ForeColor = Color.White;
            btnBackup.Location = new Point(14, 491);
            btnBackup.Margin = new Padding(3, 4, 3, 4);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(171, 53);
            btnBackup.TabIndex = 2;
            btnBackup.Text = "Realizar Backup";
            btnBackup.UseVisualStyleBackColor = false;
            btnBackup.Click += btnBackup_Click;
            // 
            // btnRestore
            // 
            btnRestore.BackColor = Color.Sienna;
            btnRestore.FlatStyle = FlatStyle.Flat;
            btnRestore.ForeColor = Color.White;
            btnRestore.Location = new Point(210, 491);
            btnRestore.Margin = new Padding(3, 4, 3, 4);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(171, 53);
            btnRestore.TabIndex = 3;
            btnRestore.Text = "Realizar Restore";
            btnRestore.UseVisualStyleBackColor = false;
            // 
            // Fr_GestionBackupRestore
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 557);
            Controls.Add(pnlTop);
            Controls.Add(dgvBackups);
            Controls.Add(btnBackup);
            Controls.Add(btnRestore);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Fr_GestionBackupRestore";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Backup";
            pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBackups).EndInit();
            ResumeLayout(false);
        }

        private Panel pnlTop;
        private Label lblTitle;
        private DataGridView dgvBackups;
        private Button btnBackup;
        private Button btnRestore;

        #endregion
    }
}