using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EstDatos_Lab01.Models;

namespace EstDatos_Lab01.Controllers
{


    public class JugadoresController : Controller
    {

        public static List<JugadoresModel> ListaJugadores = new List<JugadoresModel>();
        //
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

        // POST: Jugadores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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