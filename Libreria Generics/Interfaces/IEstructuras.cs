using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Generics.Estruturas
{
    interface IEstructuras<T>
    {
        void Insertar();
        void Borrar();
        T Obetener();
    }
}
