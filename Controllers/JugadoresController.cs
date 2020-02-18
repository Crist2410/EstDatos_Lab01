using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EstDatos_Lab01.Models;
using Libreria_Generics.Estruturas;

namespace EstDatos_Lab01.Controllers
{


    public class JugadoresController : Controller
    {
       public static ListaG<JugadoresModel> ListaGenJugadores = new ListaG<JugadoresModel>();
       public static List<JugadoresModel> ListaJugadores = new List<JugadoresModel>();

        public ActionResult MostrarListaJugadores() 
        {
            ViewBag.Jugadores = ListaJugadores;
            return View("MostrarJugadores");
        }
        public ActionResult MostrarTabla(IFormCollection collection)
        {
            JugadoresModel NuevoJugador = new JugadoresModel();

            NuevoJugador.Nombre = collection["Nombre"];
            NuevoJugador.Apellido = collection["Apellido"];
            NuevoJugador.Salario = int.Parse(collection["Salario"]);
            NuevoJugador.Club = collection["Club"];
            NuevoJugador.Posicion = collection["Posicion"];

            ListaJugadores.Add(NuevoJugador);
            ViewBag.Jugadores = ListaJugadores;
            return View("MostrarJugadores");
        }

        public ActionResult BorrarJugador(JugadoresModel Jugador)
        {
            return View("EliminarJugador");
        }



        // GET: Agregar Jugadores
        public ActionResult AgregarJugadoresCS()
        {
            return View();
        }
        // Iportacion de Jugadores
        public ActionResult ImportacionJugadoresCS()
        {
            return View();
        }
        // GET: Jugadores
        public ActionResult Index()
        {
            return View();
        }
        //Agregar jugadoes 
        [HttpPost]
        public IActionResult CreateJugador(IFormCollection collection)
        {
            JugadoresModel jugadores = new JugadoresModel();

            jugadores.Nombre = collection["Nombre"];
            jugadores.Apellido = collection["Apellido"];
            jugadores.Salario = int.Parse(collection["Salario"]);
            jugadores.Posicion = collection["Posicion"];
            jugadores.Club = collection["Club"];
            jugadores.id = ListaJugadores.Count + 1;

            ListaJugadores.Add(jugadores);
            ViewBag.Jugadores = ListaJugadores;
            return View("MostrarJugadores");
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
        public ActionResult Delete(int id)
        {
            JugadoresModel Jugador = new JugadoresModel();
            Jugador = ListaJugadores.Where(x => x.id == id).FirstOrDefault();
            return View("EliminarJugadores", Jugador);
        }

        // POST: Jugadores/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ListaJugadores.RemoveAll(x => x.id == id);
                if (true)
                {
                    return RedirectToAction("MostrarJugadores");
                }
                
            }
            catch
            {
                return View();
            }
        }
    }
}