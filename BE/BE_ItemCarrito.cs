using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_ItemCarrito : BE_EntidadBase
    {
        public int IdCarrito { get; set; }
        public int IdBoleto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal 
        { 
            get{ return Cantidad * PrecioUnitario; }
        }
        public virtual BE_Boleto Boleto { get; set; }
        public virtual BE_CarritoCompra Carrito { get; set; }

        public BE_ItemCarrito()
        {
            Boleto = new BE_Boleto();
            Carrito = new BE_CarritoCompra();
        }
    }
}
