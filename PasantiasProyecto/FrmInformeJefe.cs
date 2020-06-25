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
    public partial class FrmInformeJefe : Form
    {

        Solicitud pasantia;
        Jefe jefe = new Jefe();
        InformeJefe informe = new InformeJefe();
        String opcion;

        public FrmInformeJefe(Solicitud s, Jefe j, InformeJefe i, String op)
        {
            InitializeComponent();
            pasantia = s;
            jefe = j;
            informe = i;
            opcion = op;
        }
        private void FrmInformeJefe_Load(object sender, EventArgs e)
        {
            if (opcion.Equals("crear"))
            {
                CargarEncabezado();
            }

            if (opcion.Equals("ver"))
            {
                btnGuardar.Visible = false;
                btnCancelar.Text = "Salir";
                CargarInforme();
            }
            if (opcion.Equals("editar"))
            {
                CargarInforme();
            }
        }
        private void CargarInforme()
        {
            txtnombreEmpresa.Text = informe.Solicitud.Empresa.NombreEmpresa;
            txtDireccion.Text = informe.Solicitud.Empresa.Direccion;
            txtTelefono.Text = informe.Solicitud.Empresa.Telefono;
            txtFax.Text = informe.Solicitud.Empresa.Fax;
            txtCorreo.Text = informe.Solicitud.Empresa.CorreoElectronico;
            txtNombrePracticante.Text = informe.Solicitud.Practicante.NombreUsuario;
            txtCarrera.Text = informe.Solicitud.Practicante.Carrera;
            txtCedula.Text = informe.Solicitud.Practicante.Cedula;
        

        }
        private void CargarEncabezado()
        {
            txtnombreEmpresa.Text = pasantia.Empresa.NombreEmpresa;
            txtDireccion.Text = pasantia.Empresa.Direccion;
            txtTelefono.Text = pasantia.Empresa.Telefono;
            txtFax.Text = pasantia.Empresa.Fax;
            txtCorreo.Text = pasantia.Empresa.CorreoElectronico;
            txtNombrePracticante.Text = pasantia.Practicante.NombreUsuario;
            txtCarrera.Text = pasantia.Practicante.Carrera;
            txtCedula.Text = pasantia.Practicante.Cedula;

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            switch (opcion)
            {
                case "crear":
                    informe.AreaAsignada = txtAreaAsignada.Text;
                    informe.Horario = txtHorario.Text;
                    informe.ActividadesDesarrolladas = txtActividadesDesarolladas.Text;
                    informe.Fortalezas = txtFortalezas.Text;
                    informe.Debilidades = txtDebilidades.Text;
                    informe.Evaluacion = cbxAsitencia.SelectedValue.ToString();
                    informe.Motivacion = cbxMotivacion.SelectedValue.ToString();
                    informe.Desempenio = cbxDesempeño.SelectedValue.ToString();
                    if (rbContactoTutorSI.Checked) informe.ContactoTutor = true;
                    if (rbContactoTutorNO.Checked) informe.ContactoTutor = false;

                    //if (DAOJefe.CrearInforme(informe, pasantia, jefe) > 0) MessageBox.Show("Informe Guardado");
                    //else MessageBox.Show("Fallo");

                    break;
                case "editar":
                   
                    /*if (DAOTUTOR.EditarInforme(informe) > 0) MessageBox.Show("Informe Actualizado");
                    else MessageBox.Show("Fallo");*/


                    break;
                default:
                    break;
            }
            this.Close();
        }
    }
}
