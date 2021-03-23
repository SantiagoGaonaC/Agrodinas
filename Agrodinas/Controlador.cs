using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agrodinas
{
    class Controlador
    {
        
        public string ctrlRegistro(Usuarios usuario)
        {
            Modelo modelo = new Modelo();
            string respuesta = "";

            if (string.IsNullOrEmpty(usuario.Usuario) || string.IsNullOrEmpty(usuario.Nombre) || string.IsNullOrEmpty(usuario.Apellido) || string.IsNullOrEmpty(usuario.Password) || string.IsNullOrEmpty(usuario.ConPassword))
            {
                respuesta = "Llene todo los campos";
            } else
            {
                if (usuario.Password == usuario.ConPassword) //no repita usuario
                {
                    if (modelo.existeusuario(usuario.Usuario)) //si existe usuario para que no repita
                    {
                        respuesta = "El usuario ya existe";
                    } else
                    {
                        usuario.Password = generarSHA1(usuario.Password);
                        modelo.registro(usuario);
                    }
                } else
                {
                    respuesta = "Las contraseñas no coinciden";
                }
            }
            return respuesta;

        }

        public static Usuarios datosUsuario = null;
        public string ctrlLogin(string usuario, string password)
        {
            Modelo modelo = new Modelo();
            string respuesta = "";

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                respuesta = "Debe llenar todos los campos";
            }
            else
            {
                datosUsuario = modelo.porusuario(usuario);
                if (datosUsuario == null)
                {
                    respuesta = "El usuario no existe";
                }
                else  //Primero miramos si existe el usuario en la BD || si existe envia la info de ese registro
                {
                    if (datosUsuario.Password != generarSHA1(password))
                    {
                        respuesta = "El usuario y/o contraseña no coinciden";
                    }
                    else
                    {
                        //
                        //Session session = new Session();
                        Session.id = datosUsuario.Id;
                        Session.usuario = usuario;
                        Session.nombre = datosUsuario.Nombre;
                        Session.apellido = datosUsuario.Apellido;
                        Session.id_tipo = datosUsuario.Id_tipo;

                        //Usuario Activo
                        Modelo activo = new Modelo();
                        activo.cambiarEstado(datosUsuario.Id);



                        //Modelo inactivo = new Modelo();
                        //inactivo.cambiarEstadoInactivo(datosUsuario.Id);

                    }
                }
            }
            return respuesta;
        }

        private string generarSHA1(string cadena) //convertir String en SHA1 para cargar en base de datos cifrada
        {
            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(cadena);
            byte[] result;

            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();

            result = sha.ComputeHash(data);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(result[i].ToString("x"));
            }

            return sb.ToString();
        }

        public List<Object> consulta(string dato)
        {
            //metodo que retorna una lista de objetos
            MySqlDataReader reader;
            List<Object> lista = new List<object>();

            string sql;

            if (dato == null)
            {
                sql = "SELECT idUsuario, NombreDeUsuario, ApellidoDelUsuario, usuario, idRol, Estado_idEstado FROM Usuarios ORDER BY idUsuario ASC";
            } else
            {
                //sql = "SELECT idUsuario, NombreDeUsuario, ApellidoDelUsuario, usuario, idRol, Estado_idEstado FROM Usuarios WHERE usuario LIKE '%"+dato+ "%' OR idUsuario ORDER BY idUsuario ASC";
                sql = "SELECT idUsuario, NombreDeUsuario, ApellidoDelUsuario, usuario, idRol, Estado_idEstado FROM Usuarios WHERE usuario LIKE '%" + dato + "%' " +
                    "OR idUsuario LIKE '%" + dato + "%' OR NombreDeUsuario LIKE '%" + dato + "%' " +
                    "OR ApellidoDelUsuario LIKE '%" + dato + "%' OR idRol LIKE '%" + dato + "%' " +
                    "OR Estado_idEstado LIKE '%" + dato + "%' ORDER BY idUsuario ASC"; //busque un campo que contenga a alguna de esas palabras de busqueda
            }

            try
            {
                MySqlConnection conexion = Conexion.getConexion();
                conexion.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    BuscarEliminarUser _usuario = new BuscarEliminarUser();
                    _usuario.Id = int.Parse(reader.GetString("idUsuario"));
                    _usuario.NombreUsuario = reader.GetString("NombreDeUsuario");
                    _usuario.ApellidoUsuario = reader.GetString("ApellidoDelUsuario");
                    _usuario.Usuario = reader.GetString("usuario");
                    _usuario.IdRol = int.Parse(reader.GetString("idRol"));
                    _usuario.Estado_idEstado1 = int.Parse(reader.GetString("Estado_idEstado"));

                    lista.Add(_usuario); //por cada lista voy agregando como una fila y hago mapeo correspondiente a la tabla usuario

                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return lista;
        }
        

        public string crtlPartidas(Partidas partidas)
        {
            Modelo modelo = new Modelo();
            string respuesta = "";
            modelo.InsertarPartidas(partidas);
            
            return respuesta;
        }

        public string crtlPartidasInactivo(Partidas partidas)
        {
            Modelo modelo = new Modelo();
            string respuesta = "";
            modelo.InsertarPartidas(partidas);
            
            return respuesta;
        }

        public void cargarPartidas(DataGridView dgv)
        {
            
        }


    }
}