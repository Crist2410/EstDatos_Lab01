using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EstDatos_Lab01.Models;
using Libreria_Generics.Estruturas;
using System.IO;
using System.Diagnostics;


namespace EstDatos_Lab01.Controllers
{


    public class JugadoresController : Controller
    {
       public static ListaG<JugadoresModel> ListaGenJugadores = new ListaG<JugadoresModel>();
        public static List<JugadoresModel> ListaJugadores = new List<JugadoresModel>();
          
        //Si MetodoSeleccionado = True -> Estan usando listas de C#
        //Si MetodoSeleccionado = False -> Estan usando listas genericas 
        public static bool MetodoSeleccionado;
        public static int IdJugadores = 1;
        

        public ActionResult ListaGenerica()
        {
            MetodoSeleccionado = false ;
            return View("ImportacionJugadoresCS");
        }

        public ActionResult ListadeCSharp()
        {
            MetodoSeleccionado = true;
            return View("ImportacionJugadoresCS");
        }
        [HttpPost]
        public ActionResult CrearJugador(IFormCollection collection)
        {
            JugadoresModel NuevoJugador = new JugadoresModel();
            NuevoJugador.Nombre = collection["Nombre"];
            NuevoJugador.Apellido = collection["Apellido"];
            NuevoJugador.Salario = int.Parse(collection["Salario"]);
            NuevoJugador.Club = collection["Club"];
            NuevoJugador.Posicion = collection["Posicion"];
            NuevoJugador.id = IdJugadores;
            IdJugadores++;
            //Utilizando Listas de C# 
            if (MetodoSeleccionado)
            {
                ListaJugadores.Add(NuevoJugador);
                ViewBag.Jugadores = ListaJugadores;
            }
            //Utilizando Listas Genericas
            else
            {
                ListaGenJugadores.Add(NuevoJugador);
                ViewBag.Jugadores = ListaGenJugadores;
            }
            return View("MostrarJugadores");
        }
        //Mostrar Lista por medio de boton
        public ActionResult MostrarJugadores() 
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

       [HttpPost]
        //Vista de Importacion CSV
        public ActionResult ImportarCSV(string ArchivoCargado)
        {
            try
            {
                string Dirreccion = @""+ ArchivoCargado;
                string Texto = System.IO.File.ReadAllText(Dirreccion);
                foreach (string Fila in Texto.Split("\n"))
                {
                    JugadoresModel Jugador = new JugadoresModel();
                    if (!string.IsNullOrEmpty(Fila))
                    {
                        Jugador.Nombre = Fila.Split(";")[0];
                        Jugador.Apellido = Fila.Split(";")[1];
                        Jugador.Salario = Convert.ToInt32(Fila.Split(";")[2]);
                        Jugador.Club = Fila.Split(";")[3];
                        Jugador.Posicion = Fila.Split(";")[4];
                        Jugador.id = IdJugadores;
                        IdJugadores++;
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
                return View("MostrarJugadores");
            }
            catch (Exception)
            {

                return View("ImportacionJugadoresCS");
            }

            
        }
            // GET: Agregar Jugadores
            public ActionResult AgregarJugadoresCS()
        {
            return View();
        }
        // Importacion de Jugadores
        public ActionResult ImportacionJugadoresCS()
        {
            return View("ImportacionCSV");
        }
        // GET: Jugadores
        public ActionResult Index()
        {
            return View();
        }
        // GET: Jugadores/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Jugadores/Create
        public ActionResult Create()
        {
            return View();
        }

       

        // GET: Jugadores/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Jugadores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Jugadores/Delete/5
        public ActionResult Delete(JugadoresModel Jugador)
        {
            
            ViewBag.model = ListaGenJugadores.FindID(Jugador); 
            return View("EliminarJugadores");
        }

        // POST: Jugadores/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}