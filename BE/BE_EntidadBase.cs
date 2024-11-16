using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace BE
{
    public abstract class BE_EntidadBase : IEntidad
    {
        public int ID { get; set; }
    }
}
