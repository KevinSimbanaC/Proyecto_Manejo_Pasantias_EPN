﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CapaNegocio;
using CapaDatos;

namespace PasantiasProyecto
{
    public partial class FrmLogin : Form
    {
        List<Usuario> usuarios = new List<Usuario>();
        Usuario admi = new Usuario(1, "administrador", "1234", "admi", "", "", "");
        public FrmLogin()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg,int wparam, int lparam);
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            usuarios = DAOUsuario.obtenerUsuarios();

            foreach (var i in usuarios)
            {
                System.Console.WriteLine(i);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(txtUserName.Text == "UserName")
            {
                txtUserName.Text = "";


            }
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if(txtUserName.Text == "")
            {
                txtUserName.Text = "UserName";
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int aux = 0;
            if(txtUserName.Text == "admi" && txtPassword.Text == "1234")
            {
                FrmPrincipal frmPrincipal = new FrmPrincipal();
                frmPrincipal.Show();
                this.Hide();
                
                aux = 1;
            }

            foreach(var i in usuarios)
            {
                if(i.Login == txtUserName.Text && i.Contrasenia == txtPassword.Text)
                {
                    if(i is Practicante)
                    {
                        MessageBox.Show("Es practicante");
                        aux = 1;
                    }
                    if(i is Decano)
                    {
                        MessageBox.Show("Es Decano");
                        aux = 1;
                    }
                    if(i is Subdecano)
                    {
                        MessageBox.Show("Es Subdecano");
                        aux = 1;
                    }
                    if (i is Tutor)
                    {
                        MessageBox.Show("Es Tutor");
                        aux = 1;
                    }
                    if (i is Jefe)
                    {
                        MessageBox.Show("Es Jefe");
                        aux = 1;
                    }
                    if (i is JefeDepartamento)
                    {
                        MessageBox.Show("Es Jefe de Departamento");
                        aux = 1;
                    }
                    
                }
                
            }
            if (aux == 0)
            {
                MessageBox.Show("Las credenciales son incorrectas");
            }
        }
    }
}
