using System;
using System.Collections.Generic;
using System.Text;
using Libreria_Generics;
using Libreria_Generics.Estruturas;

namespace Libreria_Generics.Estruturas
{
    public class ListaG<T> : EstruturaBase<T>
    {
        private Nodo<T> Inicio { get; set; }
        private Nodo<T> Fin { get; set; }
        public void Add(T value)
        {
            Insertar(value);
        }
        protected override void Borrar()
        {
            throw new NotImplementedException();
        }
       
        protected override void Insertar(T value)
        {
            Nodo<T> NuevoNodo = new Nodo<T>();

            NuevoNodo.Valor = value;

            if (Inicio == null)
            {
                Inicio = NuevoNodo;
                Fin = NuevoNodo;

                NuevoNodo.Anterior = null;
                NuevoNodo.Siguiente = null;
            }
            else
            {

                Fin.Siguiente = NuevoNodo;
                NuevoNodo.Anterior = Fin;
                Fin = NuevoNodo;

            }
        }

        protected override T Obtener()
        {
            throw new NotImplementedException();
        }
    }
}
