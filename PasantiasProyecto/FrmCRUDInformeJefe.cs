using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaDatos;
namespace PasantiasProyecto
{
    public partial class FrmCRUDInformeJefe : Form
    {
        Jefe jefe = new Jefe();
        List<Solicitud> solicituds = new List<Solicitud>();
        List<InformeJefe> informeJefe = new List<InformeJefe>();

        public FrmCRUDInformeJefe(Jefe j)
        {
            InitializeComponent();
            jefe = j;
        }

        private void FrmCRUDInformeJefe_Load(object sender, EventArgs e)
        {
            jefe.IdJefe = 1;
            solicituds = DAOJefe.ObtenerListaPracticantes(jefe);
            foreach (var item in solicituds)
            {
                lstSolicitud.Items.Add(item);
            }

            CargarInformes();
        }
        private void CargarInformes()
        {
            lstInformeMitad.Items.Clear();
            informeJefe = DAOJefe.ObtenerInformesJefe(jefe);
            foreach (var item in informeJefe)
            {
                lstInformeMitad.Items.Add(item);
            }
        }

        private void btnCrearInforme_Click(object sender, EventArgs e)
        {
            Solicitud s = (Solicitud)lstSolicitud.SelectedItem;
            if (s == null)
            {
                MessageBox.Show("Escoja un Practicante", "Pasantias", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmInformeJefe frmInformeJefe = new FrmInformeJefe(s,jefe, new InformeJefe(), "crear");
                frmInformeJefe.ShowDialog();
                CargarInformes();
            }
        }
    }
}
