using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CapaDatos;
using CapaNegocio;

namespace PasantiasProyecto
{
    public partial class FrmPrincipal : Form
    {
        List<Usuario> usuarios = new List<Usuario>();
        //Arrastrar formulario
        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hand, int wmsg, int wparam, int lparam);
        public FrmPrincipal()
        {
            
            InitializeComponent();
        }
          //Ojo
        
        //private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparas, int lparm);

        private void btnOpcione_Click(object sender, EventArgs e)
        {
            if (PnlIzquierdo.Width==239)
            {
                PnlIzquierdo.Width = 97;
            }
            else
            {
                PnlIzquierdo.Width = 239;
            }
                
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnMaximixar_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Maximized;
            btnMinimizar.Visible = true;
            btnMaximixar.Visible = false;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMinimizar.Visible = false;
            btnMaximixar.Visible = true;
        }

        private void btnOcultar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Metodo click

        public void AbrirFrm(object frmHijo )
        {
            if (this.PnlContenedor.Controls.Count>0)
            {
                this.PnlContenedor.Controls.RemoveAt(0);
            }
            Form fh = frmHijo as Form;
            fh.TopLevel = false;    //tOP LEVEL infdica si la ventana debe mostrarse como nivel superior
            fh.Dock = DockStyle.Fill;    //para acoplar al panel primario
            this.PnlContenedor.Controls.Add(fh);  //agregamos al contenedor el hijo
            this.PnlContenedor.Tag = fh;    //obtengo los objetos del contenedor
            fh.Show();
        }
        private void btnValidarSolicitud_Click(object sender, EventArgs e)
        {
            AbrirFrm(new FrmValidarSolicitud());   //le enviamos lo que queremos abrir
        }

        private void btnAdministrarTutor_Click(object sender, EventArgs e)
        {

            AbrirFrm(new FrmCRUDtutor());
        }

        private void btnVisualizarEstudiante_Click(object sender, EventArgs e)
        {
            AbrirFrm(new FrmVisualizarEstudiante());
        }
        private void btnLLenarEncuesta_Click(object sender, EventArgs e)
        {
            AbrirFrm(new FrmCuestionario());
        }

        private void btnVerPasantia_Click(object sender, EventArgs e)
        {
            AbrirFrm(new FrmVerPasantia());
        }

        private void btnInformeSemestral_Click(object sender, EventArgs e)
        {
            AbrirFrm(new FrmInformeSemestral());
        }

        private void btnSolicitud_Click(object sender, EventArgs e)
        {
            AbrirFrm(new FrmVerEmpresas(this,new Practicante()));
        }

        private void btnRegistrarAsistencia_Click(object sender, EventArgs e)
        {
            AbrirFrm(new FrmRegistroDeAsistencia());
        }

        private void btnInformeMitad_Click(object sender, EventArgs e)
        {
            //Tutor t = new Tutor();
            //t.NombreUsuario = "sadds";
             AbrirFrm(new FrmCRUDInformeMitad(new Tutor()));
        }
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void PnlTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        
    }
}
