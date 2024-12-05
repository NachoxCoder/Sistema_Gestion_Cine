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
    public partial class Fr_GestionUsuarios : Form
    {
        private readonly BLL_Empleado gestorEmpleado;
        private readonly BLL_Bitacora gestorBitacora;
        private readonly BE_Empleado usuarioActual;
        private BE_Empleado empleadoSeleccionado;

        public Fr_GestionUsuarios(BE_Empleado usuario)
        {
            InitializeComponent();
            gestorEmpleado = new BLL_Empleado();
            gestorBitacora = new BLL_Bitacora();
            usuarioActual = usuario;
        }

        private void Fr_GestionUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            ConfigurarGrilla();
            btnEliminar.Enabled = false;
        }

        private void CargarUsuarios()
        {
            try
            {
                dgvUsuarios.DataSource = null;
                var usuarios = gestorEmpleado.Consultar();
                usuarios.RemoveAll(x => x.ID == usuarioActual.ID);
                dgvUsuarios.DataSource = usuarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}");
            }
        }

        private void ConfigurarGrilla()
        {
            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "Username",
                    DataPropertyName = "Username",
                    HeaderText = "Usuario"
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Nombre",
                    DataPropertyName = "Nombre",
                    HeaderText = "Nombre"
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Apellido",
                    DataPropertyName = "Apellido",
                    HeaderText = "Apellido"
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Area",
                    DataPropertyName = "Area",
                    HeaderText = "Area"
                }
            });
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarDatos()) return;

                if (empleadoSeleccionado == null)
                    empleadoSeleccionado = new BE_Empleado();

                empleadoSeleccionado.Username = txtUsername.Text;
                empleadoSeleccionado.Nombre = txtNombre.Text;
                empleadoSeleccionado.Apellido = txtApellido.Text;
                empleadoSeleccionado.Area = txtArea.Text;
                empleadoSeleccionado.Password = Servicio.Encriptacion.EncriptarPassword(txtPassword.Text);

                if (gestorEmpleado.Guardar(empleadoSeleccionado))
                {
                    MessageBox.Show("Empleado guardado correctamente");
                    gestorBitacora.Log(usuarioActual, $"Se ha guardado el empleado {empleadoSeleccionado.Username}");
                    CargarUsuarios();
                    LimpiarForm();
                }
                else
                {
                    MessageBox.Show("Error al guardar el empleado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el empleado: {ex.Message}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (empleadoSeleccionado != null)
                {
                    if (MessageBox.Show($"¿Está seguro que desea eliminar el empleado {empleadoSeleccionado.Username}?", "Eliminar empleado", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (gestorEmpleado.Borrar(empleadoSeleccionado))
                        {
                            MessageBox.Show("Empleado eliminado correctamente");
                            gestorBitacora.Log(usuarioActual, $"Se ha eliminado el empleado {empleadoSeleccionado.Username}");
                            CargarUsuarios();
                            LimpiarForm();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el empleado");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el empleado: {ex.Message}");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarForm();
            HabilitarControles(true);
            txtUsername.Focus();
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null)
            {
                empleadoSeleccionado = (BE_Empleado)dgvUsuarios.CurrentRow.DataBoundItem;
                MostrarEmpleado();
                HabilitarControles(false);
                btnEliminar.Enabled = true;
            }
        }

        private void MostrarEmpleado()
        {
            txtUsername.Text = empleadoSeleccionado.Username;
            txtNombre.Text = empleadoSeleccionado.Nombre;
            txtApellido.Text = empleadoSeleccionado.Apellido;
            txtArea.Text = empleadoSeleccionado.Area;
            txtPassword.Text = "*********";
        }

        private void LimpiarForm()
        {
            empleadoSeleccionado = null;
            txtUsername.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtArea.Clear();
            txtPassword.Clear();
            btnEliminar.Enabled = false;
            HabilitarControles(true);
        }

        private void HabilitarControles(bool habilitar)
        {
            txtUsername.ReadOnly = !habilitar;
            txtNombre.ReadOnly = !habilitar;
            txtApellido.ReadOnly = !habilitar;
            txtArea.ReadOnly = !habilitar;
            txtPassword.ReadOnly = !habilitar;
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtArea.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
                return false;
            }

            return true;
        }

        private void btnMostrarPassword_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void btnMostrarPassword_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }
    }
}
