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
    public partial class frmPanelUsuario : Form
    {
        public frmPanelUsuario()
        {
            InitializeComponent();
            label1.Text = Session.nombre + " " + Session.apellido;
        }
        public static Partidas partidas = new Partidas();
        private void btnIniciarPartida_Click(object sender, EventArgs e)
        {
            
            DateTime FechaInicio = DateTime.Now;
            partidas.IdUsuario = Session.id;
            partidas.FechaInicio1 = FechaInicio;
            Controlador controlador = new Controlador();
            controlador.crtlPartidas(partidas);
            int partid = partidas.Id;

            frmPrincipal frm4 = new frmPrincipal(); //Hacer que se muestre la vista frmPrincipal.cs
            frm4.Visible = true;
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
            frmRegistroPartidas frm4 = new frmRegistroPartidas(); //Hacer que se muestre la vista frmPrincipal.cs
            frm4.Visible = true;
            this.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Modelo modelo = new Modelo();
            modelo.cambiarEstadoInactivo(Controlador.datosUsuario.Id);           
            frmLogin frm4 = new frmLogin();
            frm4.Visible = true;
            this.Visible = false;
        }
    }
}
