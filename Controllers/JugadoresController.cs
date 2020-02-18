﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EstDatos_Lab01.Models;
using Libreria_Generics.Estruturas;
using System.Web;
using System.IO;
using System.Diagnostics;
using System.Linq;

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
        public ActionResult AgregarJugadoresCS()
        {
            
            return View();
        }
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
        public ActionResult BuscarJugador( string Buscar, string Texto)
        {
            if (MetodoSeleccionado)
            {
                ViewBag.Jugadores = ListaJugadores;
            }
            else
            {
                ViewBag.Jugadores = ListaGenJugadores;
            }
            return View("BuscarJugadoresCS");
        }

        [HttpPost]
        public ActionResult CrearJugador(IFormCollection collection)
        {
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

        //Borrar Con TXT Jugadores
        [HttpPost]
        public IActionResult BorrarListaTXT(IFormFile ArchivoTXT)
        {
          List<JugadoresModel> BorrarJugadores = new List<JugadoresModel>();
            //try
            //{
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
                    if (MetodoSeleccionado)
                    {
                    //Aqui tenes que trabajar 
                    //Pone tu logica aqui y solo aqui 
                    //los jugadores a borrar ya estan cargados en la lista Borrar jugadores
                    //No podes buscar lo jugadores por Id porque no tiene ID 

                        ViewBag.Jugadores = ListaJugadores;
                    }
                    //Utilizando Listas Genericas
                    else
                    {
                        foreach  (JugadoresModel Jugador in BorrarJugadores)
                        {

                            ListaGenJugadores.Delete(Jugador.BuscaTXT, Jugador);
                        }
                        ViewBag.Jugadores = ListaGenJugadores;
                    }
                }
                return View("MostrarJugadores");
            //}
            //catch (Exception)
            //{

            //    return View("ImportacionJugadoresCS");
            //}
        }


        //Vista de Importacion CSV
        [HttpPost]
        public IActionResult ImportarCSV(IFormFile ArchivoCargado)
        {
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
                            try
                            {
                                Jugador.Salario = Convert.ToDouble(Fila.Split(",")[4]);
                            }
                            catch (Exception)
                            {
                                Jugador.Salario = 00.00;
                            }

                            Jugador.Club = Fila.Split(",")[0];
                            Jugador.Posicion = Fila.Split(",")[3];
                            Jugador.Id = IdJugadores;
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
                }
                return View("MostrarJugadores");
            }
            catch (Exception)
            {

                return View("ImportacionJugadoresCS");
            }

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
        
       
        // GET: Jugadores/Edit/5
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
                ListaJugadores.IndexOf(ListaJugadores.Where(x => x.Id == id).FirstOrDefault());
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
            return View("EliminarJugadores",Jugador);
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