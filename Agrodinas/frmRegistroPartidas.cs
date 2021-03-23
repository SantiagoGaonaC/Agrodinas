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
    public partial class frmRegistroPartidas : Form
    {
        public frmRegistroPartidas()
        {
            InitializeComponent();
            cargarTabla(Session.id.ToString());
           
        }

        private void frmRegistroPartidas_Load(object sender, EventArgs e)
        {
            
        }
        private void cargarTabla(string dato)
        {
            List<CrearPartidas> lista = new List<CrearPartidas>();
            ctrlPartidas _ctrlPartidas = new ctrlPartidas();
            dataGridView1.DataSource = _ctrlPartidas.consulta(dato);
        }
        private void cargarTablaPartida(string dato)
        {
            List<CrearDecisiones> lista = new List<CrearDecisiones>();
            ctrlDecisiones _ctrlDecisiones = new ctrlDecisiones();
            dataGridView2.DataSource = _ctrlDecisiones.consulta(dato);
        }

        

        private void btnBuscar_Click(object sender, EventArgs e)
        {           



            MySqlDataReader reader;
            string sql = "SELECT idUsuario FROM Partidas WHERE idPartida = '" + txtCampo.Text + "'";
            MySqlConnection conexionBD = Conexion.getConexion();
            conexionBD.Open();
            string x = "";
            MySqlCommand comando = new MySqlCommand(sql, conexionBD);
            reader = comando.ExecuteReader();
            if (reader.Read())
            {
                x = reader.GetString("idUsuario");
            }
            if (x.Equals(Session.id.ToString()))
            {
                cargarTablaPartida(txtCampo.Text);
            }
            else
            {
                MessageBox.Show("Esta partida no te pertenece");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Modelo modelo = new Modelo();
            modelo.cambiarEstadoInactivo(Controlador.datosUsuario.Id);
            MySqlConnection cerrarConexion = new MySqlConnection();
            cerrarConexion.Close();
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmPanelUsuario frm3 = new frmPanelUsuario(); //Hacer que se muestre la vista del panel admin
            frm3.Visible = true;
            this.Visible = false;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Decisión 1: Cultivar | Decisión 2: Regar | Decisión 3: Recoger\n"+ "Recurso 1: Agua (Litros) \n" +
                "Recurso 2: Semilla Maiz (Unidades) \nRecurso 3: Semilla Zanahoria (Unidades)\n" + "Recurso 4: Maiz (Unidades) \nRecurso 5: Zanahoria (Unidades)\n" +
                "Recurso 6: Maíz Tierno (Unidades)\n" + "Recurso 7: Maíz Podrido (Unidades) \nRecurso 8: Zanahoria Tierna (Unidades) \nRecurso 9: Maíz tierno (Unidades)", "Información Recurso | Decisiones", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
