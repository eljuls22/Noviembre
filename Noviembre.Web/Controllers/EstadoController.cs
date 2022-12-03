﻿using Noviembre.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noviembre.Web.Controllers
{
    public class EstadoController : Controller
    {
        // GET: Estado
        public ActionResult Index()
        {
            List<Estado> estados = Estado.GetAll();
            return View(estados);
        }

        public ActionResult Registro(int id){
            Estado estado = Estado.GetById(id);
            Console.WriteLine(estado.Id);
            return View(estado);

        }
        public ActionResult Guardar(int id,string nombre){
            Estado.Guardar(id, nombre);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            Estado.Eliminar(id);
            return RedirectToAction("Index", "Estado");
        }
    }
}