using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EstDatos_Lab01.Models;
using Libreria_Generics.Estruturas;
using System.IO;
using System.Diagnostics;
using System.Linq;

namespace EstDatos_Lab01.Controllers
{
    public class JugadoresController : Controller
    {
        public static ListaG<JugadoresModel> ListaGenJugadores = new ListaG<JugadoresModel>();
        public static List<JugadoresModel> ListaJugadores = new List<JugadoresModel>();
        public static Stopwatch Cronometro = new Stopwatch();
        public static long TiempoEjecucion;
        //Si MetodoSeleccionado = True -> Estan usando listas de C#
        //Si MetodoSeleccionado = False -> Estan usando listas genericas 
        public static bool MetodoSeleccionado;
        public static int IdJugadores = 1;

        //Escribir Log de Instrucciones en TXT
        public void EscribirLog (string Texto)
        {
            Texto = Texto + ". Tiempo de Ejecucion en -> " + Cronometro.ElapsedMilliseconds + " Milisegundos \n";
            string RutaTXT = @"Instrucciones.txt";
            System.IO.File.AppendAllText(RutaTXT, Texto);
        }

        // Importacion de Jugadores
        public ActionResult ImportacionJugadoresCS()
        {
            return View("ImportacionCSV");
        }

        // Pagina Principal
        public ActionResult Index()
        {
            System.IO.File.WriteAllText(@"Instrucciones.txt","      EJECUCIONES PRINCIPALES DEL PROGRAMA CON SU TIEMPO \n \n");
            return View();
        }

        //Seleccion De Lista Artesanal
        public ActionResult ListaGenerica()
        {
            MetodoSeleccionado = false;
            return View("ImportacionJugadoresCS");
        }

        //Seleccion De Lista C#
        public ActionResult ListadeCSharp()
        {
            MetodoSeleccionado = true;
            return View("ImportacionJugadoresCS");
        }

        //Mostrar Vista de Agregar Jugadores
        public ActionResult AgregarJugadoresCS()
        {
            return View();
        }

        //Mostrar Vista de Buscar Jugadores
        public ActionResult BuscarJugadoresCS()
        {
            if (MetodoSeleccionado)
            {
                ViewBag.Jugadores = ListaJugadores;
            }
            else
            {
                ViewBag.Jugadores = ListaGenJugadores;
            }
            return View();
        }

        //Mostrar Vista Eliminar Txt
        public ActionResult EliminarTXT()
        {
            if (MetodoSeleccionado)
            {
                ViewBag.Jugadores = ListaJugadores;
            }
            else
            {
                ViewBag.Jugadores = ListaGenJugadores;
            }
            return View();
        }

        //Metodo Buscar Jugador 
        public ActionResult BuscarJugador( string Buscar, string Texto)
        {
            Cronometro.Restart();
            JugadoresModel JugadorBuscar = new JugadoresModel();
            List<JugadoresModel> ListaEncontrados = new List<JugadoresModel>();
            ListaG<JugadoresModel> ListaBuscar = new ListaG<JugadoresModel>();
            if (Buscar == "N")
            {
                JugadorBuscar.Nombre = Texto;
                JugadorBuscar.Apellido = Texto;
                if (MetodoSeleccionado)
                    ListaEncontrados = ListaJugadores.FindAll(x => x.Nombre == JugadorBuscar.Nombre || x.Apellido == JugadorBuscar.Apellido);
                else
                    ListaBuscar = ListaGenJugadores.FindAll(JugadorBuscar.BuscaNombreApellido, JugadorBuscar, ListaGenJugadores);
            }
            else if (Buscar == "P")
            {
                JugadorBuscar.Posicion = Texto;
                if (MetodoSeleccionado)
                    ListaEncontrados = ListaJugadores.FindAll(x => x.Posicion == JugadorBuscar.Posicion);
                else
                    ListaBuscar = ListaGenJugadores.FindAll(JugadorBuscar.BuscarPosicion, JugadorBuscar, ListaGenJugadores);

            }
            else if (Buscar == "C")
            {
                    JugadorBuscar.Club = Texto;
                    if (MetodoSeleccionado)
                        ListaEncontrados = ListaJugadores.FindAll(x => x.Club == JugadorBuscar.Club);
                    else
                        ListaBuscar = ListaGenJugadores.FindAll(JugadorBuscar.BuscarClub, JugadorBuscar, ListaGenJugadores);
            }
            else if (Buscar == "SMayores")
            {
                try
                {
                    JugadorBuscar.Salario = Convert.ToInt32(Texto);
                    if (MetodoSeleccionado)
                        ListaEncontrados = ListaJugadores.FindAll(x => x.Salario > JugadorBuscar.Salario);
                    else
                        ListaBuscar = ListaGenJugadores.FindAll(JugadorBuscar.BuscaSalarioMayor, JugadorBuscar, ListaGenJugadores);
                }
                catch (Exception) { }
            }
            else if (Buscar == "SMenores")
            {
                try
                {
                    JugadorBuscar.Salario = Convert.ToInt32(Texto);
                    if (MetodoSeleccionado)
                        ListaEncontrados = ListaJugadores.FindAll(x => x.Salario < JugadorBuscar.Salario);
                    else
                        ListaBuscar = ListaGenJugadores.FindAll(JugadorBuscar.BuscaSalarioMenor, JugadorBuscar, ListaGenJugadores);
                }
                catch (Exception) { }
            }
            else
            {
                try
                {
                    JugadorBuscar.Salario = Convert.ToInt32(Texto);
                    if (MetodoSeleccionado)
                        ListaEncontrados = ListaJugadores.FindAll(x => x.Salario == JugadorBuscar.Salario);
                    else
                        ListaBuscar = ListaGenJugadores.FindAll(JugadorBuscar.BuscaSalarioIgual, JugadorBuscar, ListaGenJugadores);
                }
                catch (Exception) { }
            }
            if (MetodoSeleccionado)
            {
                ViewBag.Jugadores = ListaEncontrados;
            }
            else
            {
                ViewBag.Jugadores = ListaBuscar;
            }
            Cronometro.Stop();
            EscribirLog("Busqueda de Jugadores");
            return View("BuscarJugadoresCS");
        }

        //Crear Jugador Uno a Uno
        [HttpPost]
        public ActionResult CrearJugador(IFormCollection collection)
        {
            Cronometro.Restart();
            JugadoresModel NuevoJugador = new JugadoresModel();
            NuevoJugador.Nombre = collection["Nombre"];
            NuevoJugador.Apellido = collection["Apellido"];
            NuevoJugador.Salario = double.Parse(collection["Salario"]);
            NuevoJugador.Club = collection["Club"];
            NuevoJugador.Posicion = collection["Posicion"];
            //Utilizando Listas de C# 
            if (MetodoSeleccionado)
            {
                NuevoJugador.Id = ListaJugadores.Count + 1;
                ListaJugadores.Add(NuevoJugador);
                ViewBag.Jugadores = ListaJugadores;
            }
            //Utilizando Listas Genericas
            else
            {
                NuevoJugador.Id = IdJugadores;
                IdJugadores++;
                ListaGenJugadores.Add(NuevoJugador);
                ViewBag.Jugadores = ListaGenJugadores;
            }
            Cronometro.Stop();
            EscribirLog("Se Creo Un Jugador");
            return View("MostrarJugadores");
        }

        //Mostrar Lista por medio de boton
        public ActionResult MostrarJugadores() 
        {
            Cronometro.Restart();
            if (MetodoSeleccionado)
            {
                ViewBag.Jugadores = ListaJugadores;
            }
            else
            {
                ViewBag.Jugadores = ListaGenJugadores;
            }
            Cronometro.Stop();
            EscribirLog("Mostrar Lista de Jugadores");
            return View();
        }

        //Borrar Con TXT Jugadores
        [HttpPost]
        public IActionResult BorrarListaTXT(IFormFile ArchivoTXT)
        {
            Cronometro.Restart();
          List<JugadoresModel> BorrarJugadores = new List<JugadoresModel>();
            if (ArchivoTXT.FileName.Contains(".txt"))
            {
                using (var stream = new StreamReader(ArchivoTXT.OpenReadStream()))
                {
                    string Texto = stream.ReadToEnd();
                    foreach (string Fila in Texto.Split("\r\n"))
                    {
                        JugadoresModel Jugador = new JugadoresModel();
                        if (!string.IsNullOrEmpty(Fila))
                        {
                            Jugador.Nombre = Fila.Split(",")[2];
                            Jugador.Apellido = Fila.Split(",")[1];
                            Jugador.Club = Fila.Split(",")[0];
                            Jugador.Id = IdJugadores;
                            IdJugadores++;
                            BorrarJugadores.Add(Jugador);
                        }
                    }
                    //Utilizando Listas C#
                    if (MetodoSeleccionado)
                    {    
                    foreach (JugadoresModel Jugador in BorrarJugadores)
                    {
                        ListaJugadores.Remove(ListaJugadores.Find(x => x.Nombre == Jugador.Nombre & x.Apellido == Jugador.Apellido & x.Club == Jugador.Club));
                    }
                        ViewBag.Jugadores = ListaJugadores;
                    }
                    //Utilizando Listas Genericas
                    else
                    {
                        foreach (JugadoresModel Jugador in BorrarJugadores)
                        {
                            ListaGenJugadores.Delete(Jugador.BuscaTXT, Jugador);
                        }
                        ViewBag.Jugadores = ListaGenJugadores;
                    }
                }
                Cronometro.Stop();
                EscribirLog("Se Eliminaron Jugadores Desde TXT");
                return View("MostrarJugadores");
            }
            else
            {
                Cronometro.Stop();
                return View("EliminarTXT");
            }
        }

        //Vista de Importacion CSV
        [HttpPost]
        public IActionResult ImportarCSV(IFormFile ArchivoCargado)
        {
            if (ArchivoCargado.FileName.Contains(".csv"))
            {
                Cronometro.Restart();
                try
                {
                    using (var stream = new StreamReader(ArchivoCargado.OpenReadStream()))
                    {
                        string Texto = stream.ReadToEnd().Remove(0, 71);
                        foreach (string Fila in Texto.Split("\n"))
                        {
                            JugadoresModel Jugador = new JugadoresModel();
                            if (!string.IsNullOrEmpty(Fila))
                            {
                                Jugador.Nombre = Fila.Split(",")[2];
                                Jugador.Apellido = Fila.Split(",")[1];
                                try{Jugador.Salario = Convert.ToDouble(Fila.Split(",")[4]); }
                                catch (Exception){Jugador.Salario = 00.00;}
                                Jugador.Club = Fila.Split(",")[0];
                                Jugador.Posicion = Fila.Split(",")[3];
                                Jugador.Id = IdJugadores;
                                IdJugadores++;
                                //Utilizando Listas C#
                                if (MetodoSeleccionado)
                                {
                                    ListaJugadores.Add(Jugador);
                                    ViewBag.Jugadores = ListaJugadores;
                                }
                                //Utilizando Listas Genericas
                                else
                                {
                                    ListaGenJugadores.Add(Jugador);
                                    ViewBag.Jugadores = ListaGenJugadores;
                                }
                            }
                        }
                    }
                    Cronometro.Stop();
                    EscribirLog("Se Importaron Jugadores Desde CSV");
                    return View("MostrarJugadores");
                }
                catch (Exception){return View("ImportacionCSV");}
            }
            else { return View("ImportacionCSV");}
        } 
       
        // GET: Editar Jugadores 
        public ActionResult Editar(int id)
        {
            JugadoresModel Jugador = new JugadoresModel();
            Jugador.Id = id;
            if (MetodoSeleccionado)
            {
                Jugador = ListaJugadores.Where(x => x.Id == id).FirstOrDefault();
            }
            else
            {
                Jugador = ListaGenJugadores.FindID(Jugador.BuscarId, Jugador);
            }
            return View("EditarJugador", Jugador);
        }

        // POST: Jugadores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            JugadoresModel EditarJugador = new JugadoresModel();
            EditarJugador.Nombre = collection["Nombre"];
            EditarJugador.Apellido = collection["Apellido"];
            EditarJugador.Salario = double.Parse(collection["Salario"]);
            EditarJugador.Club = collection["Club"];
            EditarJugador.Posicion = collection["Posicion"];
            EditarJugador.Id = id;
            if (MetodoSeleccionado)
            {
                JugadoresModel Jugador = ListaJugadores.Where(x => x.Id == id).FirstOrDefault();
                int ubicacion = ListaJugadores.IndexOf(Jugador);
                ListaJugadores[ubicacion] = EditarJugador;
                ViewBag.Jugadores = ListaJugadores;
            }
            else
            {
                ListaGenJugadores.Edit(EditarJugador.BuscarId, EditarJugador);
                ViewBag.Jugadores = ListaGenJugadores;
            }
            return View("MostrarJugadores");
        }


        // GET: Jugadores/Delete/5
        public ActionResult Delete(int id)
        {
            JugadoresModel Jugador = new JugadoresModel();
            Jugador.Id = id;
            if (MetodoSeleccionado)
            {
                Jugador = ListaJugadores.Where(x => x.Id == id).FirstOrDefault();
            }
            else
            {
                 Jugador = ListaGenJugadores.FindID(Jugador.BuscarId, Jugador);
            }
            return View("EliminarJugadores", Jugador);
        }

        // POST: Jugadores/Delete/5
        [HttpPost]
        public ActionResult ConfirmarBorrar(int id, IFormCollection collection)
        {
            JugadoresModel Jugador = new JugadoresModel();
            Jugador.Id = Convert.ToInt32(collection["Id"]);
            //Utilizando Listas de C# 
            if (MetodoSeleccionado)
            {
                ListaJugadores.Remove(ListaJugadores.Where(x => x.Id == id).FirstOrDefault());
                ViewBag.Jugadores = ListaJugadores;
            }
            //Utilizando Listas Genericas
            else
            {
                ListaGenJugadores.Delete(Jugador.BuscarId, Jugador);
                ViewBag.Jugadores = ListaGenJugadores;
            }
            return View("MostrarJugadores");
        }
    }
}