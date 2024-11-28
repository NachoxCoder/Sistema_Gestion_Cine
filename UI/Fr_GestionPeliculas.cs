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
    public partial class Fr_GestionPeliculas : Form
    {
        private readonly BLL_Pelicula gestorPelicula;
        private readonly BLL_Funcion gestorFuncion;
        private readonly BLL_Sala gestorSala;
        private readonly BLL_Bitacora gestorBitacora;
        private BE_Empleado usuarioActual;
        private BE_Pelicula peliculaSeleccionada;

        public Fr_GestionPeliculas(BE_Empleado usuario)
        {
            InitializeComponent();
            gestorPelicula = new BLL_Pelicula();
            gestorFuncion = new BLL_Funcion();
            gestorSala = new BLL_Sala();
            gestorBitacora = new BLL_Bitacora();
            usuarioActual = usuario;
        }

        private void Fr_GestionPeliculas_Load(object sender, EventArgs e)
        {
            CargarPeliculas();
            CargarSalas();
            ConfigurarGrillas();
        }

        private void CargarPeliculas()
        {
            try
            {
                dgvPeliculas.DataSource = null;
                dgvPeliculas.DataSource = gestorPelicula.ListarPeliculasActivas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarSalas()
        {
            try
            {
                cmbSala.DataSource = gestorSala.Consultar();
                cmbSala.DisplayMember = "Nombre";
                cmbSala.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ConfigurarGrillas()
        {
            dgvFunciones.AutoGenerateColumns = false;
            dgvFunciones.Columns.AddRange(new DataGridViewTextBoxColumn[]
            {
                new DataGridViewTextBoxColumn {Name = "Fecha", DataPropertyName = "FechaFuncion"},
                new DataGridViewTextBoxColumn {Name = "Hora", DataPropertyName = "HoraFuncion"},
                new DataGridViewTextBoxColumn {Name = "Sala", DataPropertyName = "SalaNombre"},
                new DataGridViewTextBoxColumn {Name = "Precio", DataPropertyName = "Precio"},
                new DataGridViewTextBoxColumn {Name = "Activa", DataPropertyName = "EstaActiva"}
            });
        }

        private void btnGuardarPelicula_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarPelicula())
                {
                    if (peliculaSeleccionada == null)
                        peliculaSeleccionada = new BE_Pelicula();

                    peliculaSeleccionada.Titulo = txtTitulo.Text;
                    peliculaSeleccionada.Duracion = (int)numDuracion.Value;
                    peliculaSeleccionada.Sinopsis = txtSinopsis.Text;
                    peliculaSeleccionada.Rating = txtRating.Text;
                    peliculaSeleccionada.EstaActiva = chkActiva.Checked;

                    if (gestorPelicula.Guardar(peliculaSeleccionada))
                    {
                        MessageBox.Show("Pelicula guardada correctamente");
                        gestorBitacora.Log(usuarioActual,
                            $"Se guardó la película: {peliculaSeleccionada.Titulo}");
                        CargarPeliculas();
                        LimpiarFormularioPelicula();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar pelicula: {ex.Message}");
            }
        }

        private bool ValidarPelicula()
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("El título de la película es requerido");
                return false;
            }

            if (numDuracion.Value <= 0)
            {
                MessageBox.Show("La duracion debe ser mayor a 0");
                return false;
            }

            return true;
        }

        private void btnNuevaFuncion_Click(object sender, EventArgs e)
        {
            try
            {
                if (peliculaSeleccionada == null)
                {
                    MessageBox.Show("Debe seleccionar una película");
                    return;
                }

                var funcion = new BE_Funcion
                {
                    IdPelicula = peliculaSeleccionada.ID,
                    FechaFuncion = dtpFecha.Value.Date,
                    HoraFuncion = dtpHora.Value.TimeOfDay,
                    IdSala = (int)cmbSala.SelectedValue,
                    Precio = numPrecio.Value,
                    EstaActiva = true
                };

                if (gestorFuncion.Guardar(funcion))
                {
                    MessageBox.Show("Funcion agregada correctamente");
                    gestorBitacora.Log(usuarioActual,
                        $"Se guardó una función para la película: {peliculaSeleccionada.Titulo}");
                    CargarFunciones();
                    LimpiarFormularioFuncion();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar función: {ex.Message}");
            }
        }

        private void CargarFunciones()
        {
            if (peliculaSeleccionada != null)
            {
                dgvFunciones.DataSource = peliculaSeleccionada.Funciones;
            }
        }

        private void dgvPeliculas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPeliculas.CurrentRow != null)
            {
                peliculaSeleccionada = (BE_Pelicula)dgvPeliculas.CurrentRow.DataBoundItem;
                MostrarPelicula();
                CargarFunciones();
            }
        }

        private void MostrarPelicula() 
        {
            txtTitulo.Text = peliculaSeleccionada.Titulo;
            numDuracion.Value = peliculaSeleccionada.Duracion;
            txtSinopsis.Text = peliculaSeleccionada.Sinopsis;
            txtRating.Text = peliculaSeleccionada.Rating;
            chkActiva.Checked = peliculaSeleccionada.EstaActiva;
        }

        private void LimpiarFormularioPelicula()
        {
            peliculaSeleccionada = null;
            txtTitulo.Clear();
            numDuracion.Value = 0;
            txtSinopsis.Clear();
            txtRating.Clear();
            chkActiva.Checked = true;
        }

        private void LimpiarFormularioFuncion()
        {
            dtpFecha.Value = DateTime.Today;
            dtpHora.Value = DateTime.Now;
            cmbSala.SelectedIndex = 0;
            numPrecio.Value = 0;
        }
    }
}
