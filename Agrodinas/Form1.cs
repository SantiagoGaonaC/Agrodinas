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
    public partial class frmRegistro : Form
    {
        public frmRegistro()
        {
            InitializeComponent();
        }

        private void Asociatify_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Usuarios usuario = new Usuarios(); //crear instancia de la clase usuario esa clase contiene las propiedades que se usan de la tabla usuario
            usuario.Usuario = txtUsuario.Text;
            usuario.Apellido = txtApellido.Text;
            usuario.ConPassword = txtConPasword.Text;
            usuario.Nombre = txtNombre.Text;
            usuario.Password = txtPassword.Text;
            usuario.Id_tipo = 2;

            try
            {
                Controlador control = new Controlador();
                string respuesta = control.ctrlRegistro(usuario);

                if (respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Usuario Registrado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmLogin cambioL = new frmLogin();
            cambioL.Visible = true;
            this.Visible = false;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios(); //crear instancia de la clase usuario esa clase contiene las propiedades que se usan de la tabla usuario
            usuario.Usuario = txtUsuario.Text;
            usuario.Apellido = txtApellido.Text;
            usuario.ConPassword = txtConPasword.Text;
            usuario.Nombre = txtNombre.Text;
            usuario.Password = txtPassword.Text;
            usuario.Id_tipo = 2;

            try
            {
                Controlador control = new Controlador();
                string respuesta = control.ctrlRegistro(usuario);

                if (respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Usuario Registrado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
