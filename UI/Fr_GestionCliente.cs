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
    public partial class Fr_GestionCliente : Form
    {
        private readonly BLL_Cliente gestorCliente;
        private readonly BLL_Bitacora gestorBitacora;
        private BE_Empleado usuarioActual;
        private BE_Cliente clienteSeleccionado;

        public Fr_GestionCliente(BE_Empleado usuario)
        {
            InitializeComponent();
            gestorCliente = new BLL_Cliente();
            gestorBitacora = new BLL_Bitacora();
            usuarioActual = usuario;
        }

        private void Fr_GestionCliente_Load(object sender, EventArgs e)
        {
            CargarClientes();
            ConfigurarGrilla();
        }

        private void ConfigurarGrilla()
        {
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn {Name = "Nombre", DataPropertyName = "Nombre" },
                new DataGridViewTextBoxColumn {Name = "Apellido", DataPropertyName = "Apellido" },
                new DataGridViewTextBoxColumn {Name = "DNI", DataPropertyName = "DNI" },
                new DataGridViewTextBoxColumn {Name = "FechaNacimiento", DataPropertyName = "FechaNacimiento" },
                new DataGridViewTextBoxColumn {Name = "Email", DataPropertyName = "Email" },
                new DataGridViewTextBoxColumn {Name = "Telefono", DataPropertyName = "Telefono" },
                new DataGridViewTextBoxColumn {Name = "Direccion", DataPropertyName = "Direccion" }
            });
        }

        private void CargarClientes()
        {
            try
            {
                dgvClientes.DataSource = null;
                dgvClientes.DataSource = gestorCliente.Consultar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (clienteSeleccionado == null)
                    clienteSeleccionado = new BE_Cliente();

                clienteSeleccionado.Nombre = txtNombre.Text;
                clienteSeleccionado.Apellido = txtApellido.Text;
                clienteSeleccionado.DNI = txtDNI.Text;
                clienteSeleccionado.FechaNacimiento = dtpFechaNacimiento.Value;
                clienteSeleccionado.Email = txtEmail.Text;
                clienteSeleccionado.Telefono = txtTelefono.Text;
                clienteSeleccionado.Direccion = txtDireccion.Text;

                if (gestorCliente.Guardar(clienteSeleccionado))
                {
                    MessageBox.Show("Cliente guardado correctamente");
                    gestorBitacora.Log(usuarioActual, $"Se guardó el cliente: {clienteSeleccionado.NombreCompleto()}");
                    CargarClientes();
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar client:{ex.Message}");
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El nombre y apellido son obligatorios");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                MessageBox.Show("El DNI es obligatorio");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("El email es invalido");
                return false;
            }

            if (dtpFechaNacimiento.Value > DateTime.Today.AddYears(-16))
            {
                MessageBox.Show("La fecha de nacimiento debe ser ayor a 16 años");
                return false;
            }

            return true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (clienteSeleccionado != null)
                {
                    if (MessageBox.Show($"¿Está seguro que desea eliminar al cliente: " +
                        $"{clienteSeleccionado.NombreCompleto()}?", "Eliminar cliente", MessageBoxButtons.YesNo)
                        == DialogResult.Yes)
                    {
                        if (gestorCliente.Borrar(clienteSeleccionado))
                        {
                            MessageBox.Show("Cliente eliminado correctamente");
                            gestorBitacora.Log(usuarioActual, $"Se eliminó el cliente: " +
                                $"{clienteSeleccionado.NombreCompleto()}");
                            CargarClientes();
                            LimpiarFormulario();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar cliente: {ex.Message}");
            }
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                clienteSeleccionado = (BE_Cliente)dgvClientes.CurrentRow.DataBoundItem;
                MostrarCliente();
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
            }
        }

        private void MostrarCliente()
        {
            txtNombre.Text = clienteSeleccionado.Nombre;
            txtApellido.Text = clienteSeleccionado.Apellido;
            txtDNI.Text = clienteSeleccionado.DNI;
            dtpFechaNacimiento.Value = clienteSeleccionado.FechaNacimiento;
            txtEmail.Text = clienteSeleccionado.Email;
            txtTelefono.Text = clienteSeleccionado.Telefono;
            txtDireccion.Text = clienteSeleccionado.Direccion;
        }

        private void LimpiarFormulario()
        {
            clienteSeleccionado = null;
            txtNombre.Clear();
            txtApellido.Clear();
            txtDNI.Clear();
            dtpFechaNacimiento.Value = DateTime.Today.AddYears(-16);
            txtEmail.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarDatos()) return;

                if(clienteSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un cliente para modificar");
                    return;
                }

                if(clienteSeleccionado != null)
                {
                    clienteSeleccionado.Nombre = txtNombre.Text;
                    clienteSeleccionado.Apellido = txtApellido.Text;
                    clienteSeleccionado.DNI = txtDNI.Text;
                    clienteSeleccionado.FechaNacimiento = dtpFechaNacimiento.Value;
                    clienteSeleccionado.Email = txtEmail.Text;
                    clienteSeleccionado.Telefono = txtTelefono.Text;
                    clienteSeleccionado.Direccion = txtDireccion.Text;

                    if (gestorCliente.Modificar(clienteSeleccionado))
                    {
                        MessageBox.Show("Cliente modificado correctamente");
                        gestorBitacora.Log(usuarioActual, $"Se modificó el cliente: {clienteSeleccionado.NombreCompleto()}");
                        CargarClientes();
                        LimpiarFormulario();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar cliente: {ex.Message}");
            }
        }
    }
}
