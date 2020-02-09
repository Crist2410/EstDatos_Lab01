using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Generics.Estruturas
{
    public abstract class EstruturaBase<T>
    {
        protected abstract void Insertar(T value);
        protected abstract void Borrar();
        protected abstract T Obtener();
    }
}
