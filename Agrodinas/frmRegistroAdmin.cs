using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Agrodinas
{
    public partial class frmRegistroAdmin : Form
    {
        public frmRegistroAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios(); //crear instancia de la clase usuario esa clase contiene las propiedades que se usan de la tabla usuario
            usuario.Usuario = txtUsuario.Text;
            usuario.Apellido = txtApellido.Text;
            usuario.ConPassword = txtConPasword.Text;
            usuario.Nombre = txtNombre.Text;
            usuario.Password = txtPassword.Text;
            usuario.Id_tipo = txtIdRol.SelectedIndex + 1;

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
            frmMenuAdmin frm3 = new frmMenuAdmin(); //Hacer que se muestre la vista frmPrincipal.cs
            frm3.Visible = true;
            this.Visible = false;
        }

        private void txtConPasword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Modelo modelo = new Modelo();
            modelo.cambiarEstadoInactivo(Controlador.datosUsuario.Id);
            MySqlConnection cerrarConexion = new MySqlConnection();
            cerrarConexion.Close();
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
