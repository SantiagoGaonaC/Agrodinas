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
    public partial class frmAdministrarUsuarios : Form
    {
        public frmAdministrarUsuarios()
        {
            InitializeComponent();
            cargarTabla(null);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string dato = txtCampo.Text;
            cargarTabla(dato);
        }

        private void cargarTabla(string dato)
        {
            List<BuscarEliminarUser> lista = new List<BuscarEliminarUser>();
            Controlador _controlador = new Controlador();
            dataGridView1.DataSource = _controlador.consulta(dato);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminarUser_Click(object sender, EventArgs e)
        {
            Modelo modelo = new Modelo();
            modelo.eliminarUsuario(txtEliminar.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMenuAdmin frm3 = new frmMenuAdmin(); 
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }

        private void frmAdministrarUsuarios_Load(object sender, EventArgs e)
        {

        }
    }
}

