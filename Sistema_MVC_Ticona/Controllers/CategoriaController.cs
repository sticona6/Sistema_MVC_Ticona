﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Sistema_MVC_Ticona.Models;

namespace Sistema_MVC_Ticona.Controllers
{
    public class CategoriaController : Controller
    {
        private Categoria categoria = new Categoria();
        // GET: Categoria
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(categoria.Listar());
            }
            else {
                return View(categoria.Buscar(criterio));
            }
        }
        //Accion Ver
        public ActionResult Ver(int id)
        {
            return View(categoria.Obtener(id));
        }
        //Accion Buscar
        public ActionResult Buscar(string criterio)
        {
            return View(
                criterio == null || criterio == "" 
                ? categoria.Listar() 
                : categoria.Buscar(criterio)
                );
        }
        //Accion AgregarEditar
        public ActionResult AgregarEditar(int id = 0) {
            return View(
                    id == 0 ? new Categoria()// Sirve para agregar una categoria nueva
                            : categoria.Obtener(id)//devuelve un objeto
                );
        }
        //Accion Guardar
        public ActionResult Guardar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoria.Guardar();
                return Redirect("~/Categoria");
            }
            else {
                return View("~/Views/Categoria/AgregarEditar.cshtml",categoria);
            }
        }
        //Accion eliminar
        public ActionResult Eliminar(int id) {
            categoria.categoria_id = id;
            categoria.Eliminar();
            return Redirect("~/Categoria");
        } 
    }
}