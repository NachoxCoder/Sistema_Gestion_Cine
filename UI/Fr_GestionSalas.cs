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
    public partial class Fr_GestionSalas : Form
    {
        private readonly BLL_Sala gestorSala;
        private readonly BLL_Bitacora gestorBitacora;
        private readonly BLL_Butaca gestorButaca;
        private BE_Empleado usuarioActual;
        private BE_Sala salaSeleccionada;
        public Fr_GestionSalas(BE_Empleado usuario)
        {
            InitializeComponent();
            gestorSala = new BLL_Sala();
            gestorBitacora = new BLL_Bitacora();
            gestorButaca = new BLL_Butaca();
            usuarioActual = usuario;
        }

        private void Fr_GestionSalas_Load(object sender, EventArgs e)
        {
            CargarSalas();
            ConfigurarGrilla();
        }

        private void ConfigurarGrilla()
        {
            dgvSalas.AutoGenerateColumns = false;
            dgvSalas.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn {Name = "Nombre", DataPropertyName = "Nombre" },
                new DataGridViewTextBoxColumn {Name = "Capacidad", DataPropertyName = "Capacidad" },
                new DataGridViewCheckBoxColumn {Name = "Tiene3D", DataPropertyName = "Tiene3D" }
            });
        }

        private void CargarSalas()
        {
            try
            {
                dgvSalas.DataSource = null;
                dgvSalas.DataSource = gestorSala.Consultar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                try
                {
                    if (salaSeleccionada != null)
                    {
                        salaSeleccionada = new BE_Sala();

                        salaSeleccionada.Nombre = txtNombre.Text;
                        salaSeleccionada.Capacidad = (int)numCapacidad.Value;
                        salaSeleccionada.Tiene3D = chk3D.Checked;
                    }

                    if (gestorSala.Guardar(salaSeleccionada))
                    {
                        if (salaSeleccionada.ID == 0)
                        {
                            CrearButacas();
                        }

                        MessageBox.Show("Sala guardada correctamente");
                        gestorBitacora.Log(usuarioActual, $"Se guardó la sala {salaSeleccionada.Nombre}");
                        CargarSalas();
                        LimpiarFormulario();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar sala: {ex.Message}");
                }
            }
        }

        private void CrearButacas()
        {
            int filasTotal = (int)numFilas.Value;
            int butacasPorFila = (int)numButacasPorFila.Value;

            for (int fila = 0; fila < filasTotal; fila++)
            {
                string letraFila = ((char)('A' + fila)).ToString();

                for (int num = 1; num <= butacasPorFila; num++)
                {
                    var butaca = new BE_Butaca
                    {
                        IdSala = salaSeleccionada.ID,
                        Fila = letraFila,
                        Numero = num,
                        Disponible = true
                    };

                    gestorButaca.Guardar(butaca);
                }
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre de la sala no puede estar vacío");
                return false;
            }

            if (numCapacidad.Value <= 0)
            {
                MessageBox.Show("La capacidad de la sala debe ser mayor a 0");
                return false;
            }

            return true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (salaSeleccionada == null)
                {
                    if (MessageBox.Show("¿Está seguro que desea eliminar la sala seleccionada?",
                        "Eliminar Sala", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (gestorSala.Borrar(salaSeleccionada))
                        {
                            MessageBox.Show("Sala eliminada correctamente");
                            gestorBitacora.Log(usuarioActual, $"Se eliminó la sala: {salaSeleccionada.Nombre}");
                            CargarSalas();
                            LimpiarFormulario();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar sala: {ex.Message}");
            }
        }
        
        private void dgvSalas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSalas.CurrentRow != null)
            {
                salaSeleccionada = (BE_Sala)dgvSalas.CurrentRow.DataBoundItem;
                MostrarSala();

                pnlButacas.Visible = false;
            }
        }

        private void MostrarSala()
        {
            txtNombre.Text = salaSeleccionada.Nombre;
            numCapacidad.Value = salaSeleccionada.Capacidad;
            chk3D.Checked = salaSeleccionada.Tiene3D;
        }

        private void LimpiarFormulario()
        {
            salaSeleccionada = null;
            txtNombre.Clear();
            numCapacidad.Value = 0;
            chk3D.Checked = false;
            numFilas.Value = 0;
            numButacasPorFila.Value = 0;
            pnlButacas.Visible = true;
        }
    }
}
