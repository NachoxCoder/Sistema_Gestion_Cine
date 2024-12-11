using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Backup : IBackupService
    {
        private const string BACKUP_PATH = @".\BACKUP";
        private const string DATA_PATH = @".\DATA";
        private readonly BLL_Bitacora gestorBitacora;
        private readonly string[] excludedFiles = {"Bitacora.xml", "Estado.xml", "Permiso.xml"};
        public BLL_Backup()
        {
            gestorBitacora = new BLL_Bitacora();
            if(!Directory.Exists(BACKUP_PATH))
            {
                Directory.CreateDirectory(BACKUP_PATH);
            }
        }

        public bool RealizarBackup(string usuarioId)
        {
            try
            {
                string timeStamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                string backupFolder = Path.Combine(BACKUP_PATH, $"Backup-{timeStamp}");
                Directory.CreateDirectory(backupFolder);

                foreach (string file in Directory.GetFiles(DATA_PATH, "*.xml")
                    .Where(f => !excludedFiles.Contains(Path.GetFileName(f))))
                {
                    File.Copy(file, Path.Combine(backupFolder, Path.GetFileName(file)), true);
                }

                gestorBitacora.LogById(int.Parse(usuarioId), $"Backup realizado con éxito en {backupFolder}");
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al realizar el backup", ex);
            }
        }

        public bool RealizarRestore(string backupPath, string usuarioId)
        {
            try
            {
                if (!Directory.Exists(backupPath))
                {
                    throw new Exception("El backup seleccionado no existe");
                }

                foreach (string file in Directory.GetFiles(backupPath, "*.xml"))
                {
                    File.Copy(file, Path.Combine(DATA_PATH, Path.GetFileName(file)), true);
                }

                gestorBitacora.LogById(int.Parse(usuarioId), $"Restore realizado con éxito desde: {backupPath}");
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al realizar el restore", ex);
            }
        }

        public string[] ListarBackups()
        {
            return Directory.GetDirectories(BACKUP_PATH);
        }
    }
}
