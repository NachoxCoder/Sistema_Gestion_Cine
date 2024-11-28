using BE;
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

namespace UI
{
    public partial class Fr_MenuPrincipal : Form
    {
        private BE_Empleado usuarioActual;
        private readonly BLL_Permiso gestorPermiso;
        private readonly BLL_Bitacora gestorBitacora;
        public Fr_MenuPrincipal(BE_Empleado usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            gestorPermiso = new BLL_Permiso();
            gestorBitacora = new BLL_Bitacora();
        }

        private void Fr_MenuPrincipal_Load(object sender, EventArgs e)
        {
            CargarMenuSegunPermisos();
            Text = $"Bienvenido {usuarioActual.Nombre} {usuarioActual.Apellido}";
            gestorBitacora.Log(usuarioActual, "Inicio de sesión");
        }

        private void CargarMenuSegunPermisos()
        {
            //Cargar los permisos del usuario
            usuarioActual.listaPermisos = gestorPermiso.ListarPermisosUsuario(usuarioActual);

            //Configurar el Menu de acuerdo a los permisos que posee el usuario logeado
            foreach (ToolStripMenuItem menuItem in menuStrip.Items)
            {
                bool tienePermiso = false;
                foreach (ToolStripMenuItem subItem in menuItem.DropDownItems)
                {
                    if (usuarioActual.TienePermiso(subItem.Tag?.ToString()))
                    {
                        subItem.Visible = true;
                        tienePermiso = true;
                    }
                    else
                    {
                        subItem.Visible = false;
                    }
                }
                menuItem.Visible = tienePermiso || menuItem.Text == "Archivo";
            }
        }

        private void CargarForm<T>() where T : Form, new()
        {
            var form = new T();
            form.MdiParent = this;
            form.Show();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gestorBitacora.Log(usuarioActual, "Cierre de sesión");
            Close();
            new Fr_Login().Show();
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gestorBitacora.Log(usuarioActual, "Salio de Sistema");
            Application.Exit();
        }
    }
}
