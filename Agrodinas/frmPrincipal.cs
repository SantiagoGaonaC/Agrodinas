using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agrodinas
{
    public partial class frmPrincipal : Form
    {
        int aguaMax = 100000;
        int tipousuario;
        public frmPrincipal()
        {
            
            InitializeComponent();

            tipousuario = Session.id_tipo;
            
            actualizar();
        }
        
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
                       
        }
        public void actualizar()
        {
            agua1.Visible = false;
            agua2.Visible = false;
            agua3.Visible = false;
            agua4.Visible = false;
            agua5.Visible = false;
            agua6.Visible = false;
            agua7.Visible = false;
            agua8.Visible = false;

            label5.Text ="Señor/a: "+Controlador.datosUsuario.Nombre.ToString()+" "+Controlador.datosUsuario.Apellido.ToString();
            MySqlConnection conexion = Conexion.getConexion();

            MySqlCommand comando = new MySqlCommand("SELECT * FROM Recursos WHERE idRecursos = @idRecursos", conexion);

            comando.Parameters.AddWithValue("@idRecursos", "1");
            conexion.Open();
            String agua = "0";
            MySqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                agua = registro["CantidadDeRecurso"].ToString();

                label1.Text = agua;
            }
            conexion.Close();
            comando = new MySqlCommand("SELECT * FROM Recursos WHERE idRecursos = @idRecursos", conexion);
            comando.Parameters.AddWithValue("@idRecursos", "3");
            conexion.Open();
            String semillasZ;
            registro = comando.ExecuteReader();
            if (registro.Read())
            {
                semillasZ = registro["CantidadDeRecurso"].ToString();
                labelSemillasZ.Text = semillasZ;
            }
            conexion.Close();            
            int cantidadAgua = Convert.ToInt32(agua);
            double porc = Convert.ToDouble(cantidadAgua) / Convert.ToDouble(aguaMax);
            porc *= 100;


            comando = new MySqlCommand("SELECT * FROM Recursos WHERE idRecursos = @idRecursos", conexion);
            comando.Parameters.AddWithValue("@idRecursos", "2");
            conexion.Open();
            String semillasM;
            registro = comando.ExecuteReader();
            if (registro.Read())
            {
                semillasM = registro["CantidadDeRecurso"].ToString();
                labelSemillasM.Text = semillasM;
            }
            conexion.Close();


            if (porc >= 0 && porc < 12.5)
            {
                agua1.Visible = true;
            }else if(porc >= 12.5 && porc < 25)
            {
                agua2.Visible = true;
            }
            else if (porc >= 25 && porc < 37.5)
            {
                agua3.Visible = true;
            }
            else if (porc >= 37.5 && porc < 50)
            {
                agua4.Visible = true;
            }
            else if (porc >= 50 && porc < 62.5)
            {
                agua5.Visible = true;
            }
            else if (porc >= 62.5 && porc < 75)
            {
                agua6.Visible = true;
            }
            else if (porc >= 75 && porc < 87.5)
            {
                agua7.Visible = true;
            }
            else if (porc >= 87.5 && porc <= 100)
            {
                agua8.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            actualizar();
        }
        private void seRego()
        {
            
        }
        int contadorDeAgua = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            
            button1_Click(sender, e);

            MySqlConnection conexion = Conexion.getConexion();

            MySqlCommand comando = new MySqlCommand();

            conexion.Open();

            int Agua = Convert.ToInt32(label1.Text);

            int aguatextBox = Convert.ToInt32(textBox1.Text);
            contadorDeAgua += aguatextBox;
            int aguaTotal = Agua - aguatextBox;

            try
            {
                comando = new MySqlCommand("UPDATE Recursos SET CantidadDeRecurso='" + aguaTotal + "' WHERE idRecursos=1", conexion);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw;
            }
            crearDecision(aguatextBox,2,1);
            timer2.Enabled = true;
            seRego();
            textBox1.Clear();
            actualizar();            

        }

        public void btnSalir_Click(object sender, EventArgs e)
        {
            Modelo modelo = new Modelo();
            modelo.cambiarEstadoInactivo(Controlador.datosUsuario.Id);

            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            string sql = "SELECT idPartida FROM Partidas WHERE idUsuario = '" + Session.id + "' ORDER BY idPartida DESC LIMIT 1";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            int x = Convert.ToInt32(comando.ExecuteScalar());
            conexion.Close();
            DateTime FechaFinal = DateTime.Now;
            conexion.Open();
            sql = "UPDATE Partidas SET FechaDeFinalizacion = '" + FechaFinal.ToString("yyyy-MM-dd H:mm:ss") + "' WHERE idPartida = '" + x.ToString() + "'";
            comando = new MySqlCommand(sql, conexion);
            comando.ExecuteNonQuery();
            Application.Exit();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Visible)
            {
                pictureBox1.Visible = false;
            }
            else
            {
                pictureBox1.Visible = true;
            }            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }

        private void agua8_Click(object sender, EventArgs e)
        {

        }

        private void labelSemillas_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private int obtenerIdPartida()
        {
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            string sql = "SELECT idPartida FROM Partidas WHERE idUsuario = '" + Session.id + "' ORDER BY idPartida DESC LIMIT 1";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            int x = Convert.ToInt32(comando.ExecuteScalar());
            conexion.Close();
            return x;
        }
        private void crearDecision(int CantidadDeRecurso, int idTipoDeDecisiones, int idRecursos)
        {
            MySqlConnection conexio = Conexion.getConexion();
            conexio.Open();
            int idPartida = obtenerIdPartida();

            string sql = "INSERT INTO Decisiones(CantidadDeRecurso, idTipoDeDecisiones, idPartidas, idRecursos) VALUES(@CantidadDeRecurso,@idTipoDeDecisiones," + idPartida + ",@idRecursos)";
            MySqlCommand comando = new MySqlCommand(sql, conexio);
            comando.Parameters.AddWithValue("@CantidadDeRecurso", CantidadDeRecurso);
            comando.Parameters.AddWithValue("@idTipoDeDecisiones", idTipoDeDecisiones);
            comando.Parameters.AddWithValue("@idRecursos", idRecursos);
            comando.ExecuteNonQuery();
        }
        int semanas;
        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Agrodinas.Properties.Resources.brote;
            btnSalir.Enabled = false;
            labelTiempo.Text = semanas.ToString();
            label7.Visible = true;
            label8.Visible = true;            
            labelEstado.Visible = true;
            labelTiempo.Visible = true;

            semanas = 0;
            labelTiempo.Text = semanas.ToString();
            labelEstado.Text = "Tierno";
            imgEstado.Image = Agrodinas.Properties.Resources.puntoAmarillo;
            button5.Enabled = true;
            
            labelTiempo.Visible = true;
            ComboBox.Enabled = false;
            btnPlantar.Enabled = false;
            txtPlantaciones.Enabled = false;
            int idRecurso=0;
            if (ComboBox.SelectedIndex.Equals(0))
            {
                idRecurso = 2;
            }
            else
            {
                idRecurso = 3;
            }
            crearDecision(Convert.ToInt32(txtPlantaciones.Text),1,idRecurso);



            MySqlConnection conexion = Conexion.getConexion();

            MySqlCommand comando = new MySqlCommand();

            conexion.Open();

            int semillasZ = Convert.ToInt32(labelSemillasZ.Text);
            int semillasM = Convert.ToInt32(labelSemillasM.Text);
            int resta = Convert.ToInt32(txtPlantaciones.Text);
            int semillaTotal = 0;
            if (ComboBox.SelectedIndex.Equals(0))
            {
                try
                {
                    semillaTotal = semillasM - resta;
                    comando = new MySqlCommand("UPDATE Recursos SET CantidadDeRecurso='" + semillaTotal + "' WHERE idRecursos=2", conexion);
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    throw;
                }
                labelSemillasM.Text = semillaTotal.ToString();
            }
            else
            {
                try
                {
                    semillaTotal = semillasZ - resta;
                    comando = new MySqlCommand("UPDATE Recursos SET CantidadDeRecurso='" + semillaTotal + "' WHERE idRecursos=3", conexion);
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    throw;
                }
                labelSemillasZ.Text = semillaTotal.ToString();
            }                      

        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            btnSalir.Enabled = true;
            int idRecurso = 0;
            double recoleccion = 0;
            if (ComboBox.SelectedIndex.Equals(0))
            {
                if (labelEstado.Text.Equals("Tierno"))
                {
                    idRecurso = 6;
                }
                else if (labelEstado.Text.Equals("Maduro"))
                {
                    idRecurso = 4;
                }
                else
                {
                    idRecurso = 7;
                }
                recoleccion = Convert.ToDouble(txtPlantaciones.Text) / 10;
            }
            else
            {
                if (labelEstado.Text.Equals("Tierno"))
                {
                    idRecurso = 8;
                }
                else if (labelEstado.Text.Equals("Maduro"))
                {
                    idRecurso = 5;
                }
                else
                {
                    idRecurso = 9;
                }
                recoleccion = Convert.ToDouble(txtPlantaciones.Text) / 5;
            }

            crearDecision(Convert.ToInt32(recoleccion), 3,idRecurso);
            if (labelEstado.Text.Equals("Tierno"))
            {
                if (ComboBox.SelectedIndex == 0) //maiz
                {
                    var randomNumber = new Random().Next(100, 180); //gramos
                    double generado = Convert.ToDouble(randomNumber) * (0.001 / 1);
                    double totalRecoleccion = recoleccion * generado;
                    double z = totalRecoleccion / 80;
                    double y = z * 70000;
                    int w = Convert.ToInt32(y);
                    Partidas partida = new Partidas();
                    MySqlConnection conexion = Conexion.getConexion();
                    conexion.Open();
                    string sql = "SELECT idPartida FROM Partidas WHERE idUsuario = '" + Session.id + "' ORDER BY idPartida DESC LIMIT 1";
                    MySqlCommand comando = new MySqlCommand(sql, conexion);
                    int x = Convert.ToInt32(comando.ExecuteScalar());
                    conexion.Close();
                    conexion.Open();
                    string sql1 = "UPDATE Partidas SET Ventas = '" + w + "' WHERE idPartida = '" + x.ToString() + "'";
                    comando = new MySqlCommand(sql1, conexion);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Su cultivo se recogió en estado tierno, se recogió un total de: " + Convert.ToInt32(recoleccion).ToString() + " Unidades", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("El valor en el que se vendió fue: " + Convert.ToInt32(y).ToString() + " COP", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (ComboBox.SelectedIndex == 1) //zanahoria
                {
                    var randomNumber = new Random().Next(20, 40); //gramos
                    double generado = Convert.ToDouble(randomNumber) * (0.001 / 1);
                    double totalRecoleccion = recoleccion * generado;
                    double z = totalRecoleccion / 50;
                    double y = z * 65000;
                    int w = Convert.ToInt32(y);
                    Partidas partida = new Partidas();
                    MySqlConnection conexion = Conexion.getConexion();
                    conexion.Open();
                    string sql = "SELECT idPartida FROM Partidas WHERE idUsuario = '" + Session.id + "' ORDER BY idPartida DESC LIMIT 1";
                    MySqlCommand comando = new MySqlCommand(sql, conexion);
                    int x = Convert.ToInt32(comando.ExecuteScalar());
                    conexion.Close();
                    conexion.Open();
                    string sql1 = "UPDATE Partidas SET Ventas = '" + w + "' WHERE idPartida = '" + x.ToString() + "'";
                    comando = new MySqlCommand(sql1, conexion);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Su cultivo se recogió en estado tierno, se recogió un total de: " + Convert.ToInt32(recoleccion).ToString() + " Unidades", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("El valor en el que se vendió fue: " + Convert.ToInt32(y).ToString() + " COP", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            else if (labelEstado.Text.Equals("Maduro"))
            {
                if (ComboBox.SelectedIndex == 0) //maiz
                {
                    var randomNumber = new Random().Next(190, 500); //gramos
                    double generado = Convert.ToDouble(randomNumber) * (0.001 / 1);
                    double totalRecoleccion = recoleccion * generado;
                    double z = totalRecoleccion / 80;
                    double y = z * 70000;
                    int w = Convert.ToInt32(y);
                    //double x = (80 * 70000/ totalRecoleccion);                    
                    Partidas partida = new Partidas();
                    MySqlConnection conexion = Conexion.getConexion();
                    conexion.Open();
                    string sql = "SELECT idPartida FROM Partidas WHERE idUsuario = '" + Session.id + "' ORDER BY idPartida DESC LIMIT 1";
                    MySqlCommand comando = new MySqlCommand(sql, conexion);
                    int x = Convert.ToInt32(comando.ExecuteScalar());
                    conexion.Close();
                    conexion.Open();
                    string sql1 = "UPDATE Partidas SET Ventas = '"+ w + "' WHERE idPartida = '"+ x.ToString() + "'";
                    comando = new MySqlCommand(sql1, conexion);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Su cultivo se recogió en estado maduro, se recogió un total de: " + Convert.ToInt32(recoleccion).ToString() + " Unidades", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("El valor en el que se vendió fue: " + Convert.ToInt32(y).ToString()+" COP", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (ComboBox.SelectedIndex == 1) //zanahoria
                {
                    var randomNumber = new Random().Next(40, 100); //gramos
                    double generado = Convert.ToDouble(randomNumber) * (0.001 / 1);
                    double totalRecoleccion = recoleccion * generado;
                    double z = totalRecoleccion / 50;
                    double y = z * 65000;
                    int w = Convert.ToInt32(y);
                    //double x = (80 * 70000/ totalRecoleccion);                    
                    Partidas partida = new Partidas();
                    MySqlConnection conexion = Conexion.getConexion();
                    conexion.Open();
                    string sql = "SELECT idPartida FROM Partidas WHERE idUsuario = '" + Session.id + "' ORDER BY idPartida DESC LIMIT 1";
                    MySqlCommand comando = new MySqlCommand(sql, conexion);
                    int x = Convert.ToInt32(comando.ExecuteScalar());
                    conexion.Close();
                    conexion.Open();
                    string sql1 = "UPDATE Partidas SET Ventas = '" + w + "' WHERE idPartida = '" + x.ToString() + "'";
                    comando = new MySqlCommand(sql1, conexion);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Su cultivo se recogió en estado maduro, se recogió un total de: " + Convert.ToInt32(recoleccion).ToString() + " Unidades", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("El valor en el que se vendió fue: " + Convert.ToInt32(y).ToString() + " COP", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Su cultivo se recogió en estado podrido, se recogió un total de: " + Convert.ToInt32(recoleccion).ToString() + " Unidades", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("En estado podrido el valor de venta es 0 COP.");
                Partidas partida = new Partidas();
                MySqlConnection conexion = Conexion.getConexion();
                conexion.Open();
                string sql = "SELECT idPartida FROM Partidas WHERE idUsuario = '" + Session.id + "' ORDER BY idPartida DESC LIMIT 1";
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                int x = Convert.ToInt32(comando.ExecuteScalar());
                conexion.Close();
                conexion.Open();
                string sql1 = "UPDATE Partidas SET Ventas = '0' WHERE idPartida = '" + x.ToString() + "'";
                comando = new MySqlCommand(sql1, conexion);
                comando.ExecuteNonQuery();
            }

            label7.Visible = false;
            label8.Visible = false;
            labelEstado.Visible = false;
            labelTiempo.Visible = false;            
            imgEstado.Image = null;

            button4.Enabled = false;
            btnPlantar.Enabled = true;
            ComboBox.Enabled = true;
            txtPlantaciones.Enabled = true;
            actualizar();
            button5.Enabled = false;
            txtPlantaciones.Clear();
            ComboBox.SelectedIndex = 0;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            seRego();
            semanas +=1;
            labelTiempo.Text = semanas.ToString();
            if (ComboBox.SelectedIndex.Equals(0))
            {
                if (semanas>=0 && semanas <9)
                {
                    pictureBox2.Image = Agrodinas.Properties.Resources.brote;
                    labelEstado.Text = "Tierno";
                    imgEstado.Image = Agrodinas.Properties.Resources.puntoAmarillo;
                    pictureBox2.Width = pictureBox2.Width + 20;
                    pictureBox2.Height = pictureBox2.Height + 20;
                    pictureBox2.Location = new Point(pictureBox2.Location.X - 10, pictureBox2.Location.Y - 10);


                }
                else if (semanas == 9)
                {
                    pictureBox2.Image = Agrodinas.Properties.Resources._26f2a3986c5778e6046c478f26775e32_icono_de_dibujos_animados_de_ma__z_by_vexels;
                    labelEstado.Text = "Maduro";
                    imgEstado.Image = Agrodinas.Properties.Resources.puntoVerde;
                    pictureBox2.Width = 295;
                    pictureBox2.Height = 260;
                    pictureBox2.Location = new Point(787,121);

                }
                else if (semanas>=10 && semanas <12)
                    
                {
                    pictureBox2.Image = Agrodinas.Properties.Resources._26f2a3986c5778e6046c478f26775e32_icono_de_dibujos_animados_de_ma__z_by_vexels;
                    labelEstado.Text = "Maduro";
                    imgEstado.Image = Agrodinas.Properties.Resources.puntoVerde;
                    pictureBox2.Width = pictureBox2.Width + 20;
                    pictureBox2.Height = pictureBox2.Height + 20;
                    pictureBox2.Location = new Point(pictureBox2.Location.X - 10, pictureBox2.Location.Y - 10);
                }
                else
                {
                    pictureBox2.Width = 295;
                    pictureBox2.Height = 260;                    
                    pictureBox2.Image = Agrodinas.Properties.Resources.MaizPodrido;
                    labelEstado.Text = "Podrido";
                    imgEstado.Image = Agrodinas.Properties.Resources.puntoRojo;
                }
            }
            else
            {
                if (semanas >= 0 && semanas < 13)
                {
                    pictureBox2.Image = Agrodinas.Properties.Resources.brote;
                    labelEstado.Text = "Tierno";
                    imgEstado.Image = Agrodinas.Properties.Resources.puntoAmarillo;

                }
                else if (semanas >= 13 && semanas < 17)
                {
                    pictureBox2.Image = Agrodinas.Properties.Resources.zanahoria;
                    labelEstado.Text = "Maduro";
                    imgEstado.Image = Agrodinas.Properties.Resources.puntoVerde;
                }
                else
                {
                    pictureBox2.Image = Agrodinas.Properties.Resources.zanahoria;
                    labelEstado.Text = "Podrido";
                    imgEstado.Image = Agrodinas.Properties.Resources.puntoRojo;
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Modelo modelo = new Modelo();
            modelo.cambiarEstadoInactivo(Controlador.datosUsuario.Id);

            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            string sql = "SELECT idPartida FROM Partidas WHERE idUsuario = '" + Session.id + "' ORDER BY idPartida DESC LIMIT 1";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            int x = Convert.ToInt32(comando.ExecuteScalar());
            conexion.Close();
            DateTime FechaFinal = DateTime.Now;
            conexion.Open();
            sql = "UPDATE Partidas SET FechaDeFinalizacion = '" + FechaFinal.ToString("yyyy-MM-dd H:mm:ss") + "' WHERE idPartida = '" + x.ToString() + "'";
            comando = new MySqlCommand(sql, conexion);
            comando.ExecuteNonQuery();

            frmPanelUsuario frm3 = new frmPanelUsuario();
            frm3.Visible = true;
            this.Visible = false;
        }

        private void txtPlantaciones_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            if (pictureBox3.Visible)
            {
                pictureBox3.Visible = false;
                timer2.Enabled = false;
            }
            else
            {
                pictureBox3.Visible = true;
            }
            
        }
    }
}
