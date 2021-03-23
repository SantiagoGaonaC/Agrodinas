using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agrodinas
{
    class CrearPartidas
    {
        private int idPartida;        
        private string fechaInicio;
        private string ventas;

        public int IdPartida { get => idPartida; set => idPartida = value; }        
        public string FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public string Ventas { get => ventas; set => ventas = value; }
    }
}
