using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Ticona.Models;

namespace Sistema_MVC_Ticona.Controllers
{
    public class GaleriaController : Controller
    {
        private Galeria galeria = new Galeria();
        private Categoria categoria1 = new Categoria();
        // GET: Categoria
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(galeria.Listar());
            }
            else
            {
                return View(galeria.Buscar(criterio));
            }
        }
        //Accion Ver
        public ActionResult Ver(int id)
        {
            return View(galeria.Obtener(id));
        }
        //Accion Buscar
        public ActionResult Buscar(string criterio)
        {
            return View(
                criterio == null || criterio == ""
                ? galeria.Listar()
                : galeria.Buscar(criterio)
                );
        }
        //Accion AgregarEditar
        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Categoria1 = categoria1.Listar();
            return View(
                    id == 0 ? new Galeria() // Sirve para agregar una categoria nueva
                            : galeria.Obtener(id)//devuelve un objeto
                );
        }
        //Accion Guardar
        public ActionResult Guardar(Galeria galeria)
        {
            ViewBag.Categoria1 = categoria1.Listar();
            if (ModelState.IsValid)
            {
                galeria.Guardar();
                return Redirect("~/Galeria");
            }
            else
            {
                return View("~/Views/Galeria/AgregarEditar.cshtml", galeria);
            }
        }
        //Accion eliminar
        public ActionResult Eliminar(int id)
        {
            galeria.categoria_id = id;
            galeria.Eliminar();
            return Redirect("~/Galeria");
        }
    }
}