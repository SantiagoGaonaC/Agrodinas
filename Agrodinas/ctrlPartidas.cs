using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agrodinas
{
    class ctrlPartidas 
    {
        public List<Object> consulta(string dato)
        {
            MySqlDataReader reader;
            List<Object> lista = new List<object>();
            string sql;

            sql = "SELECT idPartida, idUsuario, FechasDePartida, Ventas FROM Partidas WHERE idUsuario = '" + dato + "'";
            try
            {                
                MySqlConnection conexionBD = Conexion.getConexion();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    CrearPartidas _partidas = new CrearPartidas();
                    _partidas.IdPartida = int.Parse(reader.GetString("idPartida"));                    
                    _partidas.FechaInicio = reader.GetString("FechasDePartida");
                    try
                    {
                        _partidas.Ventas = reader.GetString("Ventas") + " COP";
                    }
                    catch (Exception)
                    {
                        _partidas.Ventas = "Sin ventas";
                    }
                    
                    lista.Add(_partidas);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return lista;
        }
    }
}
