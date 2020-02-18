using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Libreria_Generics;
using Libreria_Generics.Estruturas;

namespace Libreria_Generics.Estruturas
{
    public class ListaG<T> : EstruturaBase<T>, IEnumerable<T>
    {
        private Nodo<T> Inicio { get; set; }
        private Nodo<T> Fin { get; set; }

        public void Add(T value)
        {
            Insertar(value);
        }
        public void Delete(Delegate delegado, T Valor)
        {
            Borrar(delegado,Valor);
        }
        public T FindID(Delegate delegado, T Valor)
        {
          return Obtener(delegado, Valor);
        }

        protected override T Obtener(Delegate delegado, T Valor)
        {
            Nodo<T> NodoPivote = Inicio;
            while (Convert.ToInt32(delegado.DynamicInvoke(NodoPivote.Valor, Valor)) != 0)
            {

                NodoPivote = NodoPivote.Siguiente;

            }
            return NodoPivote.Valor;
        }
    

        protected override void Borrar(Delegate delegado, T Valor)
        {
            Nodo<T> NodoPivote = new Nodo<T>();
            NodoPivote = Inicio.Siguiente;
            if (Convert.ToInt32(delegado.DynamicInvoke(Inicio.Valor, Valor))== 0)
            {
                Inicio = Inicio.Siguiente;
            }
            if (Convert.ToInt32(delegado.DynamicInvoke(Fin.Valor, Valor)) == 0)
            {
                Fin = Fin.Anterior;
            }
            else
            {
                while (NodoPivote != Fin)
                {
                    
                    if (Convert.ToInt32(delegado.DynamicInvoke(NodoPivote.Valor, Valor)) == 0)
                    {
                        Nodo<T> NodoAnterior = NodoPivote.Anterior;
                        Nodo<T> NodoSiguiente = NodoPivote.Siguiente;
                        NodoSiguiente.Anterior = NodoSiguiente;
                        NodoAnterior.Siguiente = NodoSiguiente;
                        NodoPivote = Fin;
                    }
                    else
                    {
                        NodoPivote = NodoPivote.Siguiente;
                    }
                }
            }

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

        public IEnumerator<T> GetEnumerator()
        {
            Nodo<T> NodoAuxiliar = Inicio;

            while (NodoAuxiliar != null)
            {
                yield return NodoAuxiliar.Valor;
                NodoAuxiliar = NodoAuxiliar.Siguiente;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
