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
    public partial class frmEstadisticas : Form
    {
        public frmEstadisticas()
        {
            InitializeComponent();

            // Jugadores Conectados
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            //string sql = "SELECT count(*) FROM Usuarios WHERE Estado_idEstado = '1'";
            string sql = "SELECT COUNT(*) FROM Usuarios WHERE Estado_idEstado = '1' AND idRol = '2'";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            int x = Convert.ToInt32(comando.ExecuteScalar());
            lblConectados.Text = x.ToString();

            // Jugadores Desconectados 2
            string sql2 = "SELECT COUNT(*) FROM Usuarios WHERE Estado_idEstado = '2' AND idRol = '2'";
            MySqlCommand comando2 = new MySqlCommand(sql2, conexion);
            int x2 = Convert.ToInt32(comando2.ExecuteScalar());
            lblDesconectado.Text = x2.ToString();

            //Total Jugadores Registrados 3
            string sql3 = "SELECT COUNT(*) FROM Usuarios WHERE idRol = '2'";
            MySqlCommand comando3 = new MySqlCommand(sql3, conexion);
            int x3 = Convert.ToInt32(comando3.ExecuteScalar());
            lblTotalRegistrados.Text = x3.ToString();

            //Admin Conectados 4
            string sql4 = "SELECT COUNT(*) FROM Usuarios WHERE Estado_idEstado = '1' AND idRol = '1'";
            MySqlCommand comando4 = new MySqlCommand(sql4, conexion);
            int x4 = Convert.ToInt32(comando4.ExecuteScalar());
            lblAdminConectados.Text = x4.ToString();

            // Admin Desconectados 5
            string sql5 = "SELECT COUNT(*) FROM Usuarios WHERE Estado_idEstado = '2' AND idRol = '1'";
            MySqlCommand comando5 = new MySqlCommand(sql5, conexion);
            int x5 = Convert.ToInt32(comando5.ExecuteScalar());
            lblAdminDesconectados.Text = x5.ToString();

            //Total Jugadores Registrados 6
            string sql6 = "SELECT COUNT(*) FROM Usuarios WHERE idRol = '1'";
            MySqlCommand comando6 = new MySqlCommand(sql6, conexion);
            int x6 = Convert.ToInt32(comando6.ExecuteScalar());
            lblTotalAdminRegistrados.Text = x6.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMenuAdmin frm = new frmMenuAdmin(); //Hacer que se muestre la vista frmPrincipal.cs
            frm.Visible = true;
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmRegistroAdmin frm3 = new frmRegistroAdmin(); //Hacer que se muestre la vista del panel admin
            frm3.Visible = true;
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmAdministrarUsuarios frm3 = new frmAdministrarUsuarios(); //Hacer que se muestre la vista del panel admin
            frm3.Visible = true;
            this.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmEstadisticas frm4 = new frmEstadisticas(); //Hacer que se muestre la vista frmPrincipal.cs
            frm4.Visible = true;
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Modelo modelo = new Modelo();
            modelo.cambiarEstadoInactivo(Controlador.datosUsuario.Id);
            MySqlConnection cerrarConexion = new MySqlConnection();
            cerrarConexion.Close();
            Application.Exit();
        }

        private void lblConectados_Click(object sender, EventArgs e)
        {
            //MySqlConnection conexion = Conexion.getConexion();
            //conexion.Open();
            ////string sql = "SELECT count(*) FROM Usuarios WHERE Estado_idEstado = '1'";
            //string sql = "SELECT COUNT(*) FROM Usuarios WHERE Estado_idEstado = '1' AND idRol = '2'";
            //MySqlCommand comando = new MySqlCommand(sql, conexion);
            //int x = Convert.ToInt32(comando.ExecuteScalar());
            //lblConectados.Text = x.ToString();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmMenuAdmin frm = new frmMenuAdmin(); //Hacer que se muestre la vista frmPrincipal.cs
            frm.Visible = true;
            this.Visible = false;
        }
    }
}