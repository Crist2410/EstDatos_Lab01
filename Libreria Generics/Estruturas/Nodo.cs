using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Generics.Estruturas
{
    class Nodo<T>
    {
        public Nodo<T> Anterior { get; set; }
        public Nodo<T> Siguiente { get; set; }
        public T Valor { get; set; }
    }
}
