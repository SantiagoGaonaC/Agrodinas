
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agrodinas
{
    class Modelo //transacciones a MySql
    {
        public int registro(Usuarios usuario) //retornar registro usuario o filas ingresadas a tabla
        {

            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();

            string sql = "INSERT INTO Usuarios (usuario, NombreDeUsuario, ApellidoDelUsuario, Clave, idRol, Estado_idEstado) VALUES(@usuario, @nombre, @apellido, @password, @id_tipo, @id_estado)";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@usuario", usuario.Usuario);
            comando.Parameters.AddWithValue("@nombre", usuario.Nombre);
            comando.Parameters.AddWithValue("@apellido", usuario.Apellido);
            comando.Parameters.AddWithValue("@password", usuario.Password);
            comando.Parameters.AddWithValue("@id_tipo", usuario.Id_tipo); //2
            comando.Parameters.AddWithValue("@id_estado", 1); //1=activo

            int resultado = comando.ExecuteNonQuery();
            return resultado;

        }

        public bool existeusuario(string usuario)
        {
            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open(); //abrimos conexion

            string sql = "SELECT idUsuario FROM Usuarios WHERE usuario LIKE @usuario";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@usuario", usuario);

            reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public Usuarios porusuario(string usuario)  //Consulta por nombre de usuario
        {
            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open(); //abrimos conexion

            string sql = "SELECT idUsuario, usuario, Clave, idRol, NombreDeUsuario, ApellidoDelUsuario FROM Usuarios WHERE usuario LIKE @usuario";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@usuario", usuario);

            reader = comando.ExecuteReader();

            Usuarios usr = null;

            while (reader.Read())
            {
                usr = new Usuarios();
                usr.Id = int.Parse(reader["idUsuario"].ToString());
                usr.Password = reader["Clave"].ToString();
                usr.Usuario = reader["usuario"].ToString();
                usr.Id_tipo = int.Parse(reader["idRol"].ToString());
                usr.Nombre = reader["NombreDeUsuario"].ToString();
                usr.Apellido = reader["ApellidoDelUsuario"].ToString();

            }
            return usr;
        }

        public void eliminarUsuario(string idUsuario)
        {
            Usuarios user = new Usuarios();
            user.Id = int.Parse(idUsuario);
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();

            string sql = "DELETE FROM Usuarios WHERE idUsuario = '" + user.Id + "'";

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show("Usuario eliminado.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al eliminar Usuario." + ex.Message);
            }
        }

        public void cambiarEstado(int idUsuario)
        {
            Usuarios user = new Usuarios();
            //user.Id = int.Parse(idUsuario);
            user.Id = idUsuario;
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            string sql = "UPDATE Usuarios SET Estado_idEstado = '1' WHERE idUsuario = '" + user.Id + "'"; //1

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al activar Usuario." + ex.Message);
            }
        }

        public void cambiarEstadoInactivo(int idUsuario)
        {
            Usuarios user = new Usuarios();
            //user.Id = int.Parse(idUsuario);
            user.Id = idUsuario;
            MySqlConnection conexionBD = Conexion.getConexion();
            conexionBD.Open();
            string sql = "UPDATE Usuarios SET Estado_idEstado = '2' WHERE idUsuario = '" + user.Id + "'"; //2
           
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al Inactivar Usuario." + ex.Message);
            }
        }
        
        public int InsertarPartidas(Partidas partida)
        {
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            string sql = "INSERT INTO Partidas (FechasDePartida,idUsuario) VALUES(@Fechainicio, @idUsuario)";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@Fechainicio", partida.FechaInicio1);
            comando.Parameters.AddWithValue("@idUsuario", partida.IdUsuario);
            //comando.Parameters.AddWithValue("@Fechafinal", partida.FechaFinal1);
            int resultado = comando.ExecuteNonQuery();
            return resultado;
        }

    }
}
