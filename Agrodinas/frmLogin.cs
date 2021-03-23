using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agrodinas
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        
        public static string usuario;
        public static string password;
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            usuario = txtUsuario.Text;
            password = txtPassword.Text;          

            try
            {
                Controlador ctrl = new Controlador();  // control = controlador °
                string respuesta = ctrl.ctrlLogin(usuario, password);
                if(respuesta.Length > 0) //si da un mensaje y es mayor a 0 si está enviando un mensaje
                {
                    MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (Session.id_tipo == 1)
                    {
                        frmMenuAdmin frmadmin = new frmMenuAdmin();
                        frmadmin.Visible = true;
                        this.Visible = false;
                    }
                    else
                    {
                        //frmPrincipal frm = new frmPrincipal(); //Hacer que se muestre la vista frmPrincipal.cs
                        //frm.Visible = true;
                        //this.Visible = false;

                        frmPanelUsuario frm4 = new frmPanelUsuario(); //Hacer que se muestre la vista frmPrincipal.cs
                        frm4.Visible = true;
                        this.Visible = false;

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmRegistro cambioF = new frmRegistro();
            cambioF.Visible = true;
            this.Visible = false;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            usuario = txtUsuario.Text;
            password = txtPassword.Text;

            try
            {
                Controlador ctrl = new Controlador();  // control = controlador °
                string respuesta = ctrl.ctrlLogin(usuario, password);
                if (respuesta.Length > 0) //si da un mensaje y es mayor a 0 si está enviando un mensaje
                {
                    MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (Session.id_tipo == 1)
                    {
                        frmMenuAdmin frmadmin = new frmMenuAdmin();
                        frmadmin.Visible = true;
                        this.Visible = false;
                    }
                    else
                    {
                        //frmPrincipal frm = new frmPrincipal(); //Hacer que se muestre la vista frmPrincipal.cs
                        //frm.Visible = true;
                        //this.Visible = false;

                        frmPanelUsuario frm4 = new frmPanelUsuario(); //Hacer que se muestre la vista frmPrincipal.cs
                        frm4.Visible = true;
                        this.Visible = false;

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}