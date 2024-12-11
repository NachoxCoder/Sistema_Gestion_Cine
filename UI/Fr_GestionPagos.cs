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
    public partial class Fr_GestionPagos : Form
    {
        private readonly BLL_HistorialPago gestorHistorialPago;
        private readonly BE_Factura facturaActual;
        public Fr_GestionPagos(BE_Factura factura)
        {
            InitializeComponent();
            gestorHistorialPago = new BLL_HistorialPago();
            facturaActual = factura;
        }

        private void Fr_GestionPagos_Load(object sender, EventArgs e)
        {
            ConfigurarMetodosPago();
            MostrarDatosFactura();
        }

        private void ConfigurarMetodosPago()
        {
            cmbMetodoPago.Items.AddRange(new string[]
            { "Tarjeta de Crédito", "Tarjeta de Débito", "Transferencia Bancaria" });
            cmbMetodoPago.SelectedIndex = 0;
        }

        private void MostrarDatosFactura()
        {
            txtNumeroFactura.Text = facturaActual.NumeroFactura;
            txtFecha.Text = facturaActual.FechaEmision.ToString("dd/MM/yyyy");
            txtMonto.Text = facturaActual.Total.ToString("N2");
        }

        private void cmbMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlTransferencia.Visible = cmbMetodoPago.SelectedIndex == 0;
            pnlTarjeta.Visible = cmbMetodoPago.SelectedIndex > 0;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarDatos()) return;

                var pago = new BE_HistorialPago
                {
                    IdFactura = facturaActual.ID,
                    FechaPago = DateTime.Now,
                    Monto = facturaActual.Total,
                    MetodoPago = cmbMetodoPago.Text,
                    NumeroTransaccion = GenerarNumeroTransaccion(),
                    Estado = "Aprobado"

                };

                if(gestorHistorialPago.Guardar(pago))
                {
                    MessageBox.Show("Pago registrado con éxito");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Error al registrar el pago");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ValidarDatos()
        {
            if (cmbMetodoPago.SelectedIndex == 0)
            {
                if (string.IsNullOrWhiteSpace(txtCBU.Text) || string.IsNullOrWhiteSpace(txtTitular.Text))
                {
                    MessageBox.Show("Complete los datos para realizar la transferencia");
                    return false;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtNumeroTarjeta.Text) || string.IsNullOrWhiteSpace(txtVencimiento.Text) ||
                    string.IsNullOrWhiteSpace(txtCVV.Text))
                {
                    MessageBox.Show("Complete los datos para realizar el pago con tarjeta");
                    return false;
                }
            }
            return true;
        }

        private string GenerarNumeroTransaccion()
        {
            return $"TR{DateTime.Now:yyyyMMddHHmmss}{new Random().Next(1000, 9999)}";
        }
    }
}
