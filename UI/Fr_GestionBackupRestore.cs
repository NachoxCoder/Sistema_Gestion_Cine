using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace UI
{
    public partial class Fr_GestionBackupRestore : Form
    {
        private readonly BLL_Bitacora gestorBitacora;
        private readonly BE_Empleado usuarioActual;
        private int backupEventcount = 0;
        private int restoreEventcount = 0;

        public Fr_GestionBackupRestore(BE_Empleado usuario)
        {
            InitializeComponent();
            gestorBitacora = new BLL_Bitacora();
            usuarioActual = usuario;
            ConfigurarGrilla();
        }

        private void ConfigurarGrilla()
        {
            dgvBackups.AutoGenerateColumns = false;
            dgvBackups.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn {Name = "Fecha", DataPropertyName = "Fecha", HeaderText = "Fecha Regsitro"},
                new DataGridViewTextBoxColumn {Name = "UsuarioId", DataPropertyName = "UsuarioId", HeaderText = "ID Usuario"},
                new DataGridViewTextBoxColumn {Name = "UsuarioNombre", DataPropertyName = "UsuarioNombre", HeaderText = "Nombre Usuario"},
                new DataGridViewTextBoxColumn {Name = "TipoEvento", DataPropertyName = "TipoEvento", HeaderText = "Evento"},
                new DataGridViewTextBoxColumn {Name = "EventoId", DataPropertyName = "EventoId", HeaderText = "ID Evento"}
            });
        }

        private void CargarHistorialBackups()
        {
            try
            {
                var registros = gestorBitacora.Consultar()
                    .Where(x => x.Evento.Contains("BACKUP") || x.Evento.Contains("RESTORE")).Select(x => new
                    {
                        Fecha = x.Fecha,
                        UsuarioId = x.UsuarioEmpleado?.ID,
                        UsuarioNombre = x.UsuarioEmpleado?.Username,
                        TipoEvento = x.Evento.Contains("BACKUP") ? "Backup" : "Restore",
                        EventoId = x.Evento.Contains("BACKUP") ? ++backupEventcount : ++restoreEventcount
                    }).OrderByDescending(x => x.Fecha).ToList();

                dgvBackups.DataSource = registros;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                string carpetaData = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DATA");
                string carpetaBackup = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BACKUP");
                string fechaBackup = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                string carpetaDestino = Path.Combine(carpetaBackup, $"Backup-{fechaBackup}");

                if (!Directory.Exists(carpetaBackup))
                    Directory.CreateDirectory(carpetaBackup);

                Directory.CreateDirectory(carpetaDestino);

                string[] archivosXML = Directory.GetFiles(carpetaData, "*.xml");
                string[] archivosExcluidos = {"Bitacora.xml", "Estado.xml", "Permiso.xml"};

                foreach (string archivo in archivosXML)
                {
                    string nombreArchivo = Path.GetFileName(archivo);
                    if (!archivosExcluidos.Contains(nombreArchivo))
                    {
                        File.Copy(archivo, Path.Combine(carpetaDestino, nombreArchivo), true);
                    }
                }

                gestorBitacora.Log(usuarioActual, "BACKUP DEL SISTEMA");
                MessageBox.Show("Backup realizado con éxito", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarHistorialBackups();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar backup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBackups.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un backup para restaurar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string fechaBackup = ((DateTime)dgvBackups.CurrentRow.Cells["Fecha"].Value)
                    .ToString("yyyy-MM-dd-HH-mm-ss");
                string carpetaBackup = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
                    "BACKUP", $"Backup-{fechaBackup}");
                string carpetaData = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DATA");

                if(!Directory.Exists(carpetaBackup))
                {
                    MessageBox.Show("No se encontró el backup seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string[] archivosBackup = Directory.GetFiles(carpetaBackup, "*.xml");
                foreach (string archivo in archivosBackup)
                {
                    string nombreArchivo = Path.GetFileName(archivo);
                    File.Copy(archivo, Path.Combine(carpetaData, nombreArchivo), true);
                }

                gestorBitacora.Log(usuarioActual, "RESTORE DEL SISTEMA");
                MessageBox.Show("Restore realizado con éxito", "Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarHistorialBackups();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar restore: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
