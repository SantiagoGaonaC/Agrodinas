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
    public partial class frmAdminRecursos : Form
    {
        public frmAdminRecursos()
        {
            InitializeComponent();
            actualizar();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            actualizar();
        }
        private void actualizar()
        {
            MySqlDataReader reader;
            string sql = "SELECT CantidadDeRecurso FROM Recursos WHERE idRecursos = '1'";
            MySqlConnection conexionBD = Conexion.getConexion();
            conexionBD.Open();
            string x = "";
            MySqlCommand comando = new MySqlCommand(sql, conexionBD);            
            reader = comando.ExecuteReader();
            if (reader.Read())
            {
                x = reader.GetString("CantidadDeRecurso");
            }
            labelAgua.Text = x;

            sql = "SELECT CantidadDeRecurso FROM Recursos WHERE idRecursos = '2'";
            conexionBD = Conexion.getConexion();
            conexionBD.Open();
            x = "";
            comando = new MySqlCommand(sql, conexionBD);
            reader = comando.ExecuteReader();
            if (reader.Read())
            {
                x = reader.GetString("CantidadDeRecurso");
            }
            labelMaiz.Text = x;


            sql = "SELECT CantidadDeRecurso FROM Recursos WHERE idRecursos = '3'";
            conexionBD = Conexion.getConexion();
            conexionBD.Open();
            x = "";
            comando = new MySqlCommand(sql, conexionBD);
            reader = comando.ExecuteReader();
            if (reader.Read())
            {
                x = reader.GetString("CantidadDeRecurso");
            }
            labelZanahoria.Text = x;

            txtboxAgua.Clear();
            txtboxMaiz.Clear();
            txtboxZanahoria.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            frmMenuAdmin frm4 = new frmMenuAdmin(); 
            frm4.Visible = true;
            this.Visible = false;
        }
        private void actualizarAgua(int x)
        {            


            int aguaActual = Convert.ToInt32(labelAgua.Text);
            int aguaTotal = aguaActual - x;

            string sql = "UPDATE Recursos SET CantidadDeRecurso = '"+aguaTotal+"' WHERE idRecursos = '1'";
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.ExecuteNonQuery();
            actualizar();

        }
        private void actualizarMaiz(int x)
        {
            int maizActual = Convert.ToInt32(labelMaiz.Text);
            int maizTotal = maizActual - x;

            string sql = "UPDATE Recursos SET CantidadDeRecurso = '" + maizTotal + "' WHERE idRecursos = '2'";
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.ExecuteNonQuery();
            actualizar();
        }

        private void actualizarZanahoria(int x)
        {
            int zanahoriaActual = Convert.ToInt32(labelZanahoria.Text);
            int zanahoriaTotal = zanahoriaActual - x;

            string sql = "UPDATE Recursos SET CantidadDeRecurso = '" + zanahoriaTotal + "' WHERE idRecursos = '3'";
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.ExecuteNonQuery();
            actualizar();
        }
        private void btnQuitarAgua_Click(object sender, EventArgs e)
        {
            actualizarAgua(Convert.ToInt32(txtboxAgua.Text));
        }

        private void btnAgregarAgua_Click(object sender, EventArgs e)
        {
            actualizarAgua(Convert.ToInt32(txtboxAgua.Text)*-1);
        }

        private void btnQuitarMaiz_Click(object sender, EventArgs e)
        {
            actualizarMaiz(Convert.ToInt32(txtboxMaiz.Text));
        }

        private void btnAgregarMaiz_Click(object sender, EventArgs e)
        {
            actualizarMaiz(Convert.ToInt32(txtboxMaiz.Text)*-1);
        }

        private void btnQuitarZanahoria_Click(object sender, EventArgs e)
        {
            actualizarZanahoria(Convert.ToInt32(txtboxZanahoria.Text));
        }

        private void btnAgregarZanahoria_Click(object sender, EventArgs e)
        {
            actualizarZanahoria(Convert.ToInt32(txtboxZanahoria.Text)*-1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Modelo modelo = new Modelo();
            modelo.cambiarEstadoInactivo(Controlador.datosUsuario.Id);
            MySqlConnection cerrarConexion = new MySqlConnection();
            cerrarConexion.Close();
            Application.Exit();
        }
    }
}
