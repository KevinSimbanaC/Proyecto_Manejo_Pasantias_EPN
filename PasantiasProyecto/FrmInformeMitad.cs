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
    public partial class FrmInformeMitad : Form
    {
        Solicitud pasantia;
        Tutor tutor = new Tutor();
        InformeMitadPeriodo informe = new InformeMitadPeriodo();
        String opcion;
        
        public FrmInformeMitad(Solicitud s,Tutor t,InformeMitadPeriodo i,String op)
        {
            InitializeComponent();
            pasantia = s;
            tutor = t;
            informe = i;
            opcion = op;
        }

        private void FrmInformeMitad_Load(object sender, EventArgs e)
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
            txtNombreUsuario.Text = informe.Solicitud.Practicante.NombreUsuario;
            txtCarrera.Text = informe.Solicitud.Practicante.Carrera;

            txtPreparacionTecnica.Text = informe.PreparacionTecnica;
            txtCapacidadAprendizaje.Text = informe.CapacidadAprendizaje;
            if (informe.Creatividad) rbCreatividadSI.Checked = true;
            else rbCreatividadNO.Checked = true;

            if (informe.Puntualidad) rbPuntualidadSI.Checked = true;
            else rbPuntualidadNO.Checked = true;

            if (informe.Adaptacion) rbAdaptacionSI.Checked = true;
            else rbAdaptacionNO.Checked = true;

            if (informe.Responsabilidad) rbResponsabilidaSI.Checked = true;
            else rbResponsabilidadNO.Checked = true;

            LlenarFechasVisitas();
            
        }

        private void LlenarFechasVisitas()
        {
            ///
        }

        private void CargarEncabezado()
        {
            txtnombreEmpresa.Text = pasantia.Empresa.NombreEmpresa;
            txtDireccion.Text = pasantia.Empresa.Direccion;
            txtTelefono.Text = pasantia.Empresa.Telefono;
            txtFax.Text = pasantia.Empresa.Fax;
            txtCorreo.Text = pasantia.Empresa.CorreoElectronico;
            txtNombreUsuario.Text = pasantia.Practicante.NombreUsuario;
            txtCarrera.Text = pasantia.Practicante.Carrera;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            switch (opcion)
            {
                case "crear":
                    informe.PreparacionTecnica = txtPreparacionTecnica.Text;
                    informe.CapacidadAprendizaje = txtCapacidadAprendizaje.Text;
                    if (rbCreatividadSI.Checked) informe.Creatividad = true;
                    if (rbPuntualidadSI.Checked) informe.Puntualidad = true;
                    if (rbAdaptacionSI.Checked) informe.Adaptacion = true;
                    if (rbResponsabilidaSI.Checked) informe.Responsabilidad = true;

                    if (DAOTUTOR.CrearInforme(informe, pasantia, tutor) > 0) MessageBox.Show("Informe Guardado");
                    else MessageBox.Show("Fallo");

                    break;
                case "editar":
                    informe.PreparacionTecnica = txtPreparacionTecnica.Text;
                    informe.CapacidadAprendizaje = txtCapacidadAprendizaje.Text;
                    if (rbCreatividadSI.Checked) informe.Creatividad = true;
                    if (rbPuntualidadSI.Checked) informe.Puntualidad = true;
                    if (rbAdaptacionSI.Checked) informe.Adaptacion = true;
                    if (rbResponsabilidaSI.Checked) informe.Responsabilidad = true;
                    if (DAOTUTOR.EditarInforme(informe) > 0) MessageBox.Show("Informe Actualizado");
                    else MessageBox.Show("Fallo");


                    break;
                default:
                    break;
            }
            this.Close();
        }
    }
}
