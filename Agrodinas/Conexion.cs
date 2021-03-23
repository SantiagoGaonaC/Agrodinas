using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agrodinas
{
    class Conexion
    {
        public static MySqlConnection getConexion()
        {
            string servidor = "IP BASE D EDATOS";
            string puerto = "PUERTO BASE DE DATOS";
            string usuario = "USUARIO BASE DE DATOS";
            string password = "CONTRAEÑA BASE DE DATOS";
            string bd = "NOMBRE BASE DE DATOS";

            string cadenaConexion = "server=" + servidor + "; port=" + puerto + "; user id=" + usuario + "; password=" + password + "; database=" + bd;

            MySqlConnection conexion = new MySqlConnection(cadenaConexion);

            return conexion;
        }
    }
}
