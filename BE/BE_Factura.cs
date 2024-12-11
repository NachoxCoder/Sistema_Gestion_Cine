using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Factura : BE_EntidadBase
    {
        public string NumeroFactura{ get; set; }
        public BE_Cliente Cliente { get; set; }
        public int IdCliente { get; set; }
        public string TipoFactura { get; set; }
        public ICollection<BE_DetalleFactura> Detalles { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal IVA { get; set; }
        public DateTime FechaEmision { get; set; }
        public string MetodoPago { get; set; }
        public bool EstaPagada { get; set; }

        public virtual ICollection<BE_Boleto> Boletos
        {
            get; set;
        }

        public BE_Factura()
        {
            Detalles = new List<BE_DetalleFactura>();
            FechaEmision = DateTime.Now;
        }

        public void CalcularTotal()
        {
            Subtotal = Detalles.Sum(d => d.Subtotal);
            IVA = Subtotal * 0.21m;
            Total = Subtotal + IVA;
        }

        public void AgregarDetalle(BE_DetalleFactura detalle)
        {
            Detalles.Add(detalle);
            CalcularTotal();
        }

        public override string ToString()
        {
            return $"Factura N° {NumeroFactura} - {FechaEmision:dd/MM/yyyy} - Total: ${Total:N2}";
        }
    }
}
