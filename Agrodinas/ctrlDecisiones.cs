using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agrodinas
{
    class ctrlDecisiones
    {
        public List<Object> consulta(string dato)
        {
            MySqlDataReader reader;
            List<Object> lista = new List<object>();
            string sql;
            sql = "SELECT idPartidas,idTipoDeDecisiones,idRecursos,CantidadDeRecurso FROM Decisiones WHERE idPartidas = '" + dato + "'";           
            
            
            try
            {

                MySqlConnection conexionBD = Conexion.getConexion();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    CrearDecisiones _decisiones = new CrearDecisiones();
                    _decisiones.IdPartidas = int.Parse(reader.GetString("idPartidas"));
                    _decisiones.IdTipoDeDecisiones = int.Parse(reader.GetString("idTipoDeDecisiones"));
                    _decisiones.IdRecursos = int.Parse(reader.GetString("IdRecursos"));
                    _decisiones.CantidadDeRecurso1 = int.Parse(reader.GetString("CantidadDeRecurso"));
                    lista.Add(_decisiones);
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
    

