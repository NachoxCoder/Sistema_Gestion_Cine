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
    public partial class Fr_GestionProveedores : Form
    {
        private readonly BLL_Proveedor gestorProveedor;
        private readonly BLL_Bitacora gestorBitacora;
        private readonly BE_Empleado usuarioActual;
        private BE_Proveedor proveedorSeleccionado;
        public Fr_GestionProveedores(BE_Empleado usuario)
        {
            InitializeComponent();
            gestorProveedor = new BLL_Proveedor();
            gestorBitacora = new BLL_Bitacora();
            usuarioActual = usuario;
        }

        private void Fr_GestionProveedores_Load(object sender, EventArgs e)
        {
            CargarProveedores();
            ConfigurarGrilla();
            LimpiarForm();
        }

        private void CargarProveedores()
        {
            try
            {
                dgvProveedores.DataSource = null;
                dgvProveedores.DataSource = gestorProveedor.Consultar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar proveedores: {ex.Message}");
            }
        }

        private void ConfigurarGrilla()
        {
            dgvProveedores.AutoGenerateColumns = false;
            dgvProveedores.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "CUIT",
                    DataPropertyName = "CUIT",
                    HeaderText = "CUIT",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "RazonSocial",
                    DataPropertyName = "RazonSocial",
                    HeaderText = "Razon Social",
                    Width = 200
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Direccion",
                    DataPropertyName = "Direccion",
                    HeaderText = "Direccion",
                    Width = 200
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Telefono",
                    DataPropertyName = "Telefono",
                    HeaderText = "Telefono",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Email",
                    DataPropertyName = "Email",
                    HeaderText = "Email",
                    Width = 150
                },
                new DataGridViewCheckBoxColumn
                {
                    Name = "EstaActivo",
                    DataPropertyName = "EstaActivo",
                    HeaderText = "Activo",
                    Width = 50
                }
            });
        }

        private void LimpiarForm()
        {
            txtCUIT.Clear();
            txtRazonSocial.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            chkActivo.Checked = true;
            proveedorSeleccionado = null;
            btnEliminar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (proveedorSeleccionado == null)
                {
                    proveedorSeleccionado = new BE_Proveedor();
                }

                proveedorSeleccionado.CUIT = txtCUIT.Text;
                proveedorSeleccionado.RazonSocial = txtRazonSocial.Text;
                proveedorSeleccionado.DireccionProveedor = txtDireccion.Text;
                proveedorSeleccionado.TelefonoProveedor = txtTelefono.Text;
                proveedorSeleccionado.EmailProveedor = txtEmail.Text;
                proveedorSeleccionado.EstaActivo = chkActivo.Checked;

                if (gestorProveedor.Guardar(proveedorSeleccionado))
                {
                    MessageBox.Show("Proveedor guardado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gestorBitacora.Log(usuarioActual, $"Se ha guardado el proveedor: {proveedorSeleccionado.RazonSocial}");
                    CargarProveedores();
                    LimpiarForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (proveedorSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show($"¿Está seguro que desea eliminar el proveedor {proveedorSeleccionado.RazonSocial}?",
                    "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (gestorProveedor.Borrar(proveedorSeleccionado))
                    {
                        MessageBox.Show("Proveedor eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gestorBitacora.Log(usuarioActual, $"Se ha eliminado el proveedor: {proveedorSeleccionado.RazonSocial}");
                        CargarProveedores();
                        LimpiarForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar proveedor: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow != null)
            {
                proveedorSeleccionado = (BE_Proveedor)dgvProveedores.CurrentRow.DataBoundItem;
                MostrarProveedor();
                btnEliminar.Enabled = true;
            }
        }

        private void MostrarProveedor()
        {
            txtCUIT.Text = proveedorSeleccionado.CUIT;
            txtRazonSocial.Text = proveedorSeleccionado.RazonSocial;
            txtDireccion.Text = proveedorSeleccionado.DireccionProveedor;
            txtTelefono.Text = proveedorSeleccionado.TelefonoProveedor;
            txtEmail.Text = proveedorSeleccionado.EmailProveedor;
            chkActivo.Checked = proveedorSeleccionado.EstaActivo;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarForm();
        }
    }
}
