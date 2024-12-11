using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Fr_GestionFacturas : Form
    {
        private readonly BLL_Factura gestorFactura;
        private readonly BLL_OrdenCompra gestorOrdenCompra;
        private readonly BLL_Proveedor gestorProveedor;
        private readonly BLL_HistorialPago gestorHistorialPago;
        private readonly BLL_Bitacora gestorBitacora;
        private readonly BE_Empleado usuarioActual;
        private BE_Proveedor proveedorSeleccionado;
        private BE_OrdenCompra ordenCompraSeleccionada;

        public Fr_GestionFacturas(BE_Empleado usuario)
        {
            InitializeComponent();
            gestorFactura = new BLL_Factura();
            gestorOrdenCompra = new BLL_OrdenCompra();
            gestorProveedor = new BLL_Proveedor();
            gestorHistorialPago = new BLL_HistorialPago();
            gestorBitacora = new BLL_Bitacora();
            usuarioActual = usuario;
        }

        private void Fr_CargarFactura_Load(object sender, EventArgs e)
        {
            ConfigurarGrillas();
            CargarProveedores();
            CargarFacturas();
            LimpiarForm();
        }

        private void ConfigurarGrillas()
        {
            dgvOrdenCompra.AutoGenerateColumns = false;
            dgvOrdenCompra.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "ID",
                    DataPropertyName = "ID",
                    HeaderText = "Nro. Orden",
                    Width = 50
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "FechaOrdenCompra",
                    DataPropertyName = "FechaOrdenCompra",
                    HeaderText = "Fecha",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "TotalOrdenCompra",
                    DataPropertyName = "TotalOrdenCompra",
                    HeaderText = "Total",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "EstadoOrdenCompra",
                    DataPropertyName = "EstadoOrdenCompra",
                    HeaderText = "Estado",
                    Width = 100
                }
            });

            dgvFacturas.AutoGenerateColumns = false;
            dgvFacturas.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewColumn
                {
                    Name = "NumeroFactura",
                    DataPropertyName = "NumeroFactura",
                    HeaderText = "Nro. Factura",
                    Width = 50
                },
                new DataGridViewColumn
                {
                    Name = "FechaEmision",
                    DataPropertyName = "FechaEmision",
                    HeaderText = "Fecha",
                    Width = 100
                },
                new DataGridViewColumn
                {
                    Name = "Total",
                    DataPropertyName = "Total",
                    HeaderText = "Total",
                    Width = 100
                },
                new DataGridViewCheckBoxColumn
                {
                    Name = "EstaPagada",
                    DataPropertyName = "EstaPagada",
                    HeaderText = "Pagada",
                    Width = 50
                }
            });
        }

        private void CargarProveedores()
        {
            try
            {
                cmbProveedor.DataSource = gestorProveedor.ListarProveedoresActivos();
                cmbProveedor.DisplayMember = "RazonSocial";
                cmbProveedor.ValueMember = "ID";
                cmbProveedor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar proveedores: {ex.Message}");
            }
        }

        private void CargarFacturas()
        {
            try
            {
                if (proveedorSeleccionado != null)
                {
                    var facturas = gestorFactura.Consultar().FindAll(x => x.IdCliente == proveedorSeleccionado.ID);
                    dgvFacturas.DataSource = facturas;
                }
                else { dgvFacturas.DataSource = null; }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar facturas: {ex.Message}");
            }
        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProveedor.SelectedIndex != null)
            {
                proveedorSeleccionado = (BE_Proveedor)cmbProveedor.SelectedItem;
                CargarOrdenesCompra();
            }
        }

        private void CargarOrdenesCompra()
        {
            try
            {
                var ordenes = gestorOrdenCompra.Consultar()
                    .FindAll(x => x.IdProveedor == proveedorSeleccionado.ID && x.EstadoOrdenCompra == "Aprobado");

                dgvOrdenCompra.DataSource = ordenes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ordenes de compra: {ex.Message}");
            }
        }

        private void dgvOrdenCompra_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrdenCompra.CurrentRow != null)
            {
                ordenCompraSeleccionada = (BE_OrdenCompra)dgvOrdenCompra.CurrentRow.DataBoundItem;
                btnCargarFactura.Enabled = true;
            }
        }

        private void btnCargarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarDatos()) return;

                var factura = new BE_Factura
                {
                    NumeroFactura = txtNumeroFactura.Text,
                    IdCliente = proveedorSeleccionado.ID,
                    TipoFactura = "A",
                    FechaEmision = dtpFechaEmision.Value,
                    Subtotal = ordenCompraSeleccionada.TotalOrdenCompra,
                    IVA = ordenCompraSeleccionada.TotalOrdenCompra * 0.21m,
                    Total = ordenCompraSeleccionada.TotalOrdenCompra * 1.21m,
                };

                if (gestorFactura.Guardar(factura))
                {
                    ordenCompraSeleccionada.EstadoOrdenCompra = "Facturada";
                    gestorOrdenCompra.Guardar(ordenCompraSeleccionada);
                    gestorBitacora.Log(usuarioActual, $"Se ha generado la factura: {factura.NumeroFactura}");

                    if (MessageBox.Show("Factura generada correctamente. ¿Desea proceeder con el pago?",
                        "Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ProcesarPago(factura);
                    }

                    LimpiarForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnPagarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFacturas.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar una factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var factura = (BE_Factura)dgvFacturas.CurrentRow.DataBoundItem;

                if (factura.EstaPagada)
                {
                    MessageBox.Show("La factura ya se encuentra pagada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ProcesarPago(factura);
                CargarFacturas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProcesarPago(BE_Factura factura)
        {
            using (var frmPago = new Fr_GestionPagos(factura))
            {
                if (frmPago.ShowDialog() == DialogResult.OK)
                {
                    factura.EstaPagada = true;
                    gestorFactura.Guardar(factura);
                    gestorBitacora.Log(usuarioActual, $"Se ha registrado un pago de ${factura.Total} para la factura: {factura.NumeroFactura}");
                    MessageBox.Show("Pago registrado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNumeroFactura.Text))
            {
                MessageBox.Show("Debe ingresar un número de factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(proveedorSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(ordenCompraSeleccionada == null)
            {
                MessageBox.Show("Debe seleccionar una orden de compra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void LimpiarForm()
        {
            txtNumeroFactura.Clear();
            cmbProveedor.SelectedIndex = -1;
            dtpFechaEmision.Value = DateTime.Today;
            proveedorSeleccionado = null;
            ordenCompraSeleccionada = null;
            dgvOrdenCompra.DataSource = null;
            btnCargarFactura.Enabled = false;
        }
    }
}
