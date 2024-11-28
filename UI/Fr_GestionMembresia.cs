using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;

namespace UI
{
    public partial class Fr_GestionMembresia : Form
    {
        private readonly BLL_Membresia gestorMembresia;
        private readonly BLL_Cliente gestorCliente;
        private readonly BLL_Bitacora gestorBitacora;
        private BE_Cliente clienteSeleccionado;
        private BE_Membresia membresiaSeleccionada;
        private BE_Empleado usuarioActual;

        public Fr_GestionMembresia(BE_Empleado usuario)
        {
            InitializeComponent();
            gestorMembresia = new BLL_Membresia();
            gestorCliente = new BLL_Cliente();
            gestorBitacora = new BLL_Bitacora();
            usuarioActual = usuario;
        }

        private void Fr_GestionMembresia_Load(object sender, EventArgs e)
        {
            ConfigurarControles();
            CargarMembresias();
        }

        private void ConfigurarControles()
        {
            cmbTipoMembresia.DataSource = Enum.GetValues(typeof(TipoMembresia));
            dgvMembresias.AutoGenerateColumns = false;
            dgvMembresias.Columns.AddRange(new DataGridViewColumn[] {
                new DataGridViewColumn{Name = "Cliente", DataPropertyName = "Cliente.NombreCompleto"},
                new DataGridViewColumn{Name = "TipoMembresia", DataPropertyName = "Tipo"},
                new DataGridViewColumn{Name = "FechaInicio", DataPropertyName = "FechaInicio"},
                new DataGridViewColumn{Name = "FechaFin", DataPropertyName = "FechaFin"},
                new DataGridViewCheckBoxColumn{Name = "Activa", DataPropertyName = "EstaActiva"},
            });
        }

        private void CargarMembresias()
        {
            dgvMembresias.DataSource = gestorMembresia.Consultar();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                MessageBox.Show("Debe ingresar un DNI para buscar un cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clienteSeleccionado = gestorCliente.Consultar().Find(x => x.DNI == txtDNI.Text.Trim());

            if (clienteSeleccionado == null)
            {
                MessageBox.Show("No se encontró ningun cliente con el DNI ingresado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtNombre.Text = clienteSeleccionado.NombreCompleto();
            var membresia = gestorMembresia.Consultar()
                            .Find(x => x.IdCliente == clienteSeleccionado.ID && x.EstaActiva);

            if (membresia != null)
            {
                membresiaSeleccionada = membresia;
                MostrarDatosMembresia();
            }
        }

        private void MostrarDatosMembresia()
        {
            if (membresiaSeleccionada != null)
            {
               cmbTipoMembresia.SelectedItem = membresiaSeleccionada.Tipo;
               dtpFechaInicio.Value = membresiaSeleccionada.FechaInicio;
               dtpFechaFin.Value = membresiaSeleccionada.FechaFin;
               chkActiva.Checked = membresiaSeleccionada.EstaActiva;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un cliente para continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (membresiaSeleccionada == null)
                {
                    membresiaSeleccionada = new BE_Membresia();
                }
                
                membresiaSeleccionada.IdCliente = clienteSeleccionado.ID;
                membresiaSeleccionada.Tipo = (TipoMembresia)cmbTipoMembresia.SelectedItem;
                membresiaSeleccionada.FechaInicio = dtpFechaInicio.Value;
                membresiaSeleccionada.FechaFin = dtpFechaFin.Value;
                membresiaSeleccionada.EstaActiva = chkActiva.Checked;

                if (gestorMembresia.Guardar(membresiaSeleccionada))
                {
                    MessageBox.Show("Membresía guardada correctamente", "Membresía Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gestorBitacora.Log(usuarioActual, $"Se ha creado una membresía para el cliente: " +
                        $"{clienteSeleccionado.NombreCompleto()}");
                    CargarMembresias();
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al guardar la membresia: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (membresiaSeleccionada != null && membresiaSeleccionada.EstaActiva)
            {
                if (MessageBox.Show("La membresía actual está activa, desea cancelarla?", "Cancelar Membresía",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (gestorMembresia.CancelarMembresia(membresiaSeleccionada))
                    {
                        MessageBox.Show("Membresía cancelada correctamente", "Membresía Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gestorBitacora.Log(usuarioActual, $"Se ha cancelado la membresía para el cliente: " +
                        $"{clienteSeleccionado.NombreCompleto()}");
                        CargarMembresias();
                        LimpiarFormulario();
                    }
                }
            }
        }

        private void LimpiarFormulario()
        {
            txtDNI.Clear();
            txtNombre.Clear();
            cmbTipoMembresia.SelectedIndex = 0;
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today.AddMonths(1);
            chkActiva.Checked = true;
            clienteSeleccionado = null;
            membresiaSeleccionada = null;
        }

        private void dgvMembresias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMembresias.CurrentRow != null)
            {
                membresiaSeleccionada = (BE_Membresia)dgvMembresias.CurrentRow.DataBoundItem;
                clienteSeleccionado = membresiaSeleccionada.Cliente;
                txtDNI.Text = clienteSeleccionado.DNI;
                txtNombre.Text = clienteSeleccionado.NombreCompleto();
                MostrarDatosMembresia();
            }
        }
    }
}
