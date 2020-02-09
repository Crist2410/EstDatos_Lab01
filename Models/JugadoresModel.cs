using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstDatos_Lab01.Models
{
    public class Jugadores
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Salario { get; set; }
        public string Club { get; set; }
        public string Posicion { get; set; }

        public Jugadores()
        {

        }
    }
}
