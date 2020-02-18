using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Generics.Estruturas
{
    public abstract class EstruturaBase<T>
    {
        protected abstract void Insertar(T value);
        protected abstract void Borrar(Delegate delegado, T Valor);
        protected abstract T Obtener(Delegate delegado, T Valor);
    }
}
