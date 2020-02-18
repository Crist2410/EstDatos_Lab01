using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstDatos_Lab01.Models
{
    public class JugadoresModel: IComparable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public double Salario { get; set; }
        public string Club { get; set; }
        public string Posicion { get; set; }
        public int id { get; set; }

        

        public Comparison<JugadoresModel> BuscarId = delegate (JugadoresModel Jugador1, JugadoresModel Jugador2)
        {
            return Jugador1.Id.CompareTo(Jugador2.Id);
        };
        public Comparison<JugadoresModel> BuscarNombre = delegate (JugadoresModel Jugador1, JugadoresModel Jugador2)
        {
            return Jugador1.Nombre.CompareTo(Jugador2.Nombre);
        };
        public Comparison<JugadoresModel> BuscarApellido = delegate (JugadoresModel Jugador1, JugadoresModel Jugador2)
        {
            return Jugador1.Apellido.CompareTo(Jugador2.Apellido);
        };
        public Comparison<JugadoresModel> BuscaSalario = delegate (JugadoresModel Jugador1, JugadoresModel Jugador2)
        {
            return Jugador1.Salario.CompareTo(Jugador2.Salario);
        };
        public Comparison<JugadoresModel> BuscaClub = delegate (JugadoresModel Jugador1, JugadoresModel Jugador2)
        {
            return Jugador1.Club.CompareTo(Jugador2.Club);
        };
        public Comparison<JugadoresModel> BuscaPosicion = delegate (JugadoresModel Jugador1, JugadoresModel Jugador2)
        {
            return Jugador1.Posicion.CompareTo(Jugador2.Posicion);
        };


        public JugadoresModel()
        {

        }

        public int CompareTo(object obj)
        {
            var comparer = ((JugadoresModel)obj).Id;

            return comparer < Id ? 1 : comparer == Id ? 0 : -1;

            throw new NotImplementedException();
        }

    }
}
