using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IBackupService
    {
        bool RealizarBackup(string usuarioId);
        bool RealizarRestore(string backupPath, string usuarioId);
        string[] ListarBackups();
    }
}
