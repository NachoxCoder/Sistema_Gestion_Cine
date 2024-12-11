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
using BE;

namespace UI
{
    public partial class Fr_GenerarOrdenCompra : Form
    {
        private readonly BLL_OrdenCompra gestorOrdenCompra;
        private readonly BLL_Proveedor gestorProveedor;
        private readonly BLL_Producto gestorProducto;
        private readonly BLL_Bitacora gestorBitacora;
        private readonly BE_Empleado usuarioActual;
        private BE_OrdenCompra ordenCompraActual;
        private List<BE_DetalleOrdenCompra> detallesOrden;

        public Fr_GenerarOrdenCompra(BE_Empleado usuario)
        {
            InitializeComponent();
            gestorOrdenCompra = new BLL_OrdenCompra();
            gestorProveedor = new BLL_Proveedor();
            gestorProducto = new BLL_Producto();
            gestorBitacora = new BLL_Bitacora();
            usuarioActual = usuario;
            detallesOrden = new List<BE_DetalleOrdenCompra>();
        }

        private void Fr_GenerarOrdenCompra_Load(object sender, EventArgs e)
        {
            ConfigurarGrillas();
            CargarProveedores();
            CargarProductos();
            InicializarOrdenCompra();
        }

        private void ConfigurarGrillas()
        {
            dgvDetalles.AutoGenerateColumns = false;
            dgvDetalles.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "Producto",
                    DataPropertyName = "NombreProducto",
                    HeaderText = "Producto"
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Cantidad",
                    DataPropertyName = "Cantidad",
                    HeaderText = "Cantidad"
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "PrecioUnitario",
                    DataPropertyName = "PrecioUnitario",
                    HeaderText = "Precio Unitario"
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Subtotal",
                    DataPropertyName = "Subtotal",
                    HeaderText = "Subtotal"
                }
            });
        }

        private void CargarProveedores()
        {
            cmbProveedor.DataSource = gestorProveedor.ListarProveedoresActivos();
            cmbProveedor.DisplayMember = "RazonSocial";
            cmbProveedor.ValueMember = "ID";
        }

        private void CargarProductos()
        {
            cmbProducto.DataSource = gestorProducto.Consultar();
            cmbProducto.DisplayMember = "NombreProducto";
            cmbProducto.ValueMember = "ID";
        }

        private void InicializarOrdenCompra()
        {
            ordenCompraActual = new BE_OrdenCompra
            {
                FechaOrdenCompra = DateTime.Now,
                EstadoOrdenCompra = "Pendiente",
                Detalles = new List<BE_DetalleOrdenCompra>()
            };
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarDetalle()) return;

                var producto = (BE_Producto)cmbProducto.SelectedItem;
                var detalle = new BE_DetalleOrdenCompra
                {
                    IdProducto = producto.ID,
                    Producto = producto,
                    Cantidad = (int)numCantidad.Value,
                    PrecioUnitario = numPrecioUnitario.Value
                };

                detallesOrden.Add(detalle);
                ActualizarGrilla();
                LimpiarForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private bool ValidarDetalle()
        {
            if (cmbProducto.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un producto");
                return false;
            }

            if (numCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0");
                return false;
            }

            if (numPrecioUnitario.Value <= 0)
            {
                MessageBox.Show("El precio unitario debe ser mayor a 0");
                return false;
            }

            return true;
        }

        private void ActualizarGrilla()
        {
            dgvDetalles.DataSource = null;
            dgvDetalles.DataSource = detallesOrden;

            lblTotal.Text = $"Total: ${detallesOrden.Sum(x => x.Subtotal):N2}";
        }

        private void LimpiarForm()
        {
            cmbProducto.SelectedIndex = -1;
            numCantidad.Value = 0;
            numPrecioUnitario.Value = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarOrden()) return;

                ordenCompraActual.IdProveedor = (int)cmbProveedor.SelectedValue;
                ordenCompraActual.Proveedor = (BE_Proveedor)cmbProveedor.SelectedItem;
                ordenCompraActual.Detalles = detallesOrden;
                ordenCompraActual.TotalOrdenCompra = detallesOrden.Sum(x => x.Subtotal);

                if (gestorOrdenCompra.Guardar(ordenCompraActual))
                {
                    MessageBox.Show("Orden de compra guardada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gestorBitacora.Log(usuarioActual, $"Genero Orden de Compra: {ordenCompraActual.ID}");
                    LimpiarForm();
                    InicializarOrdenCompra();
                    ActualizarGrilla();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ValidarOrden()
        {
            if (cmbProveedor.SelectedIndex == null)
            {
                MessageBox.Show("Debe seleccionar un proveedor");
                return false;
            }

            if (!detallesOrden.Any())
            {
                MessageBox.Show("Debe agregar al menos un producto a la orden de compra");
                return false;
            }

            return true;
        }

        private void numCantidad_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
