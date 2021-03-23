using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agrodinas
{
    public class Partidas
    {
        public static int id, idUsuario, ganancias, perdidas;
        public static DateTime FechaInicio, FechaFinal;
        
        public int Id { get => id; set => id = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public int Ganancias { get => ganancias; set => ganancias = value; }
        public int Perdidas { get => perdidas; set => perdidas = value; }
        public DateTime FechaInicio1 { get => FechaInicio; set => FechaInicio = value; }
        public DateTime FechaFinal1 { get => FechaFinal; set => FechaFinal = value; }
    }
}
