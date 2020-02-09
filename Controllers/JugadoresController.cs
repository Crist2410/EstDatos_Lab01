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
       public static ListaG<Jugadores> ListaGenJugadores = new ListaG<Jugadores>();
       public static List<Jugadores> L_Jugadores = new List<Jugadores>();

        //
        public ActionResult MostrarTabla()
        {
            ViewBag.Jugadores = L_Jugadores;
            return View("MostrarJugadores");
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
            Jugadores jugadores = new Jugadores();

            jugadores.Nombre = collection["Nombre"];
            jugadores.Apellido = collection["Apellido"];
            jugadores.Salario = int.Parse(collection["Salario"]);
            jugadores.Posicion = collection["Posicion"];
            jugadores.Club = collection["Club"];

            ListaGenJugadores.Add(jugadores);
            L_Jugadores.Add(jugadores);
            ViewBag.Jugadores = L_Jugadores;
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
            return View();
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