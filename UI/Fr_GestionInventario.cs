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
    public partial class Fr_GestionInventario : Form
    {
        private readonly BLL_Producto gestorProducto;
        private readonly BLL_OrdenCompra gestorOrdenCompra;
        private readonly BLL_Bitacora gestorBitacora;
        private readonly BE_Empleado usuarioActual;
        private BE_Producto productoSeleccionado;

        public Fr_GestionInventario(BE_Empleado usuario)
        {
            InitializeComponent();
            gestorProducto = new BLL_Producto();
            gestorOrdenCompra = new BLL_OrdenCompra();
            gestorBitacora = new BLL_Bitacora();
            usuarioActual = usuario;
        }

        private void Fr_GestionInventario_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();
            CargarProductos();
            CargarProductosBajoStock();
        }

        private void ConfigurarGrilla()
        {
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn {Name = "Nombre", DataPropertyName = "NombreProducto", HeaderText = "Producto"},
                new DataGridViewTextBoxColumn {Name = "Descripcion", DataPropertyName = "DescripcionProducto", HeaderText = "Descripcion"},
                new DataGridViewTextBoxColumn {Name = "Precio", DataPropertyName = "PrecioProducto", HeaderText = "Precio Unitario"},
                new DataGridViewTextBoxColumn {Name = "Stock", DataPropertyName = "Stock", HeaderText = "Stock Actual"}
            });
        }

        private void CargarProductos()
        {
            try
            {
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = gestorProducto.Consultar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProductosBajoStock()
        {
            try
            {
                var productosBajoStock = gestorProducto.ListarProductosBajoStock();
                if (productosBajoStock.Any())
                {
                    lblAlerta.Text = $"Hay {productosBajoStock.Count} productos con stock bajo";
                    lblAlerta.ForeColor = Color.Red;
                    lblAlerta.Visible = true;
                }
                else
                {
                    lblAlerta.Text = "No hay productos con stock bajo";
                    lblAlerta.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarDatos()) return;

                if (productoSeleccionado == null)
                {
                    productoSeleccionado = new BE_Producto
                    {
                        NombreProducto = txtNombre.Text,
                        DescripcionProducto = txtDescripcion.Text,
                        PrecioProducto = numPrecio.Value,
                        Stock = (int)numStock.Value
                    };

                    if (gestorProducto.Guardar(productoSeleccionado))
                    {
                        gestorBitacora.Log(usuarioActual, $"Producto: {productoSeleccionado.NombreProducto} agregado");
                        MessageBox.Show("Producto creado con éxito", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarProductos();
                        CargarProductosBajoStock();
                        LimpiarForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese un nombre para el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Ingrese una descripción para el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (numPrecio.Value <= 0)
            {
                MessageBox.Show("Ingrese un precio mayor a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (numStock.Value < 0)
            {
                MessageBox.Show("El stock NO puede ser negativo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void LimpiarForm()
        {
            productoSeleccionado = null;
            txtNombre.Clear();
            txtDescripcion.Clear();
            numPrecio.Value = 0;
            numStock.Value = 0;
            btnEliminar.Enabled = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (productoSeleccionado == null)
                {
                    MessageBox.Show("Seleccione un producto para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var ordenesActivas = gestorOrdenCompra.Consultar()
                    .Any(o => o.Detalles.Any(d => d.IdProducto == productoSeleccionado.ID &&
                    o.EstadoOrdenCompra == "Pendiente"));

                if (ordenesActivas)
                {
                    MessageBox.Show("No se puede eliminar un producto incluido en ordenes de compra pendientes",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("¿Está seguro que desea eliminar el producto seleccionado?",
                    "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (gestorProducto.Borrar(productoSeleccionado))
                    {
                        gestorBitacora.Log(usuarioActual, $"Producto: {productoSeleccionado.NombreProducto} eliminado");
                        MessageBox.Show("Producto eliminado con éxito", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarProductos();
                        CargarProductosBajoStock();
                        LimpiarForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvProductos.CurrentRow != null)
            {
                productoSeleccionado = (BE_Producto)dgvProductos.CurrentRow.DataBoundItem;
                txtNombre.Text = productoSeleccionado.NombreProducto;
                txtDescripcion.Text = productoSeleccionado.DescripcionProducto;
                numPrecio.Value = productoSeleccionado.PrecioProducto;
                numStock.Value = productoSeleccionado.Stock;
                btnEliminar.Enabled = true;
            }
        }
    }
}
