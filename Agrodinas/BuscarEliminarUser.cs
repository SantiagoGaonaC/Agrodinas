using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agrodinas
{
    class BuscarEliminarUser //esta clase trabaja como modelo
    {
        //Mapeo Tabla Usuarios
        private int id;
        private string usuario;
        private string nombreUsuario;
        private string apellidoUsuario;
        private int idRol;
        private int Estado_idEstado;

        public int Id { get => id; set => id = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string ApellidoUsuario { get => apellidoUsuario; set => apellidoUsuario = value; }
        public int IdRol { get => idRol; set => idRol = value; }
        public int Estado_idEstado1 { get => Estado_idEstado; set => Estado_idEstado = value; }

    }
}
