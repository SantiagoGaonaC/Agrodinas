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
    public partial class frmMenuAdmin : Form
    {
        public frmMenuAdmin()
        {
            InitializeComponent();
        }

        private void menuRegistrarUsuario_Click(object sender, EventArgs e)
        {
            frmRegistroAdmin frm2 = new frmRegistroAdmin(); //Hacer que se muestre la vista frmPrincipal.cs
            frm2.Visible = true;
            this.Visible = false;
        }

        private void EliminarUsuario_Click(object sender, EventArgs e)
        {
            frmAdministrarUsuarios frm3 = new frmAdministrarUsuarios(); //Hacer que se muestre la vista frmPrincipal.cs
            frm3.Visible = true;
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Modelo modelo = new Modelo();
            modelo.cambiarEstadoInactivo(Controlador.datosUsuario.Id);
            MySqlConnection cerrarConexion = new MySqlConnection();
            cerrarConexion.Close();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmEstadisticas frm4 = new frmEstadisticas(); //Hacer que se muestre la vista frmPrincipal.cs
            frm4.Visible = true;
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Modelo modelo = new Modelo();
            modelo.cambiarEstadoInactivo(Controlador.datosUsuario.Id);
            frmLogin frm4 = new frmLogin();
            frm4.Visible = true;
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmAdminRecursos frm4 = new frmAdminRecursos();
            frm4.Visible = true;
            this.Visible = false;
        }
    }
}
