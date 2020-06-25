using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;

namespace PasantiasProyecto
{
    public partial class FrmVisualizarEstudiante : Form
    {
        List<Usuario> usuarios = new List<Usuario>();
        public FrmVisualizarEstudiante()
        {
            InitializeComponent();
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmVisualizarEstudiante_Load(object sender, EventArgs e)
        {
            usuarios = DAOUsuario.obtenerUsuarios();
            dgvEstudiante.ColumnCount = 4;
            dgvEstudiante.Columns[0].Name = "Id Practicante";
            dgvEstudiante.Columns[1].Name = "Nombre";
            dgvEstudiante.Columns[2].Name = "User";
            dgvEstudiante.Columns[3].Name = "Contraseña";

            dgvEstudiante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void LlenarData()
        {

        }

       
    }
}
