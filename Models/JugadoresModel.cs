using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstDatos_Lab01.Models
{
    public class JugadoresModel: IComparable
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Salario { get; set; }
        public string Club { get; set; }
        public string Posicion { get; set; }

        public delegate JugadoresModel BuscarNombre(JugadoresModel Jugador1, JugadoresModel Jugador2);
        public delegate int BuscarApellido(JugadoresModel Jugador1, JugadoresModel Jugador2);

        
        
        public JugadoresModel()
        {

        }

        public int CompareTo(object obj)
        {
            JugadoresModel Jugador = obj as JugadoresModel;
            return this.id.CompareTo(Jugador.id);
        }
    }
}
