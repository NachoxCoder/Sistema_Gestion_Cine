using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_DetalleFactura : BE_EntidadBase
    {
        public int IdFactura { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public virtual BE_Factura Factura { get; set; }

        public BE_DetalleFactura()
        {
            Cantidad = 1;
            PrecioUnitario = 0;
            Subtotal = 0;
        }
        public BE_DetalleFactura(string descripcion, int cantidad, decimal precioUnitario)
        {
            Descripcion = descripcion;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            CalcularSubtotal();
        }
        public void CalcularSubtotal() 
        {
            Subtotal = Cantidad * PrecioUnitario;
        }

        public override string ToString()
        {
            return $"{Descripcion} - {Cantidad} x ${PrecioUnitario:N2} = ${Subtotal:N2}";
        }
    }
}
