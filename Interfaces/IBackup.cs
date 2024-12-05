using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace Interfaces
{
    public interface IBackup
    {
        bool RealizarBackup(BE_Empleado usuario);
        bool RealizarRestore(string backupPath, BE_Empleado usuario);
    }
}
