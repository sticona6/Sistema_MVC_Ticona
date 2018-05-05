using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Ticona.Models;

namespace Sistema_MVC_Ticona.Controllers
{
    public class PersonaController : Controller
    {
        private Persona persona = new Persona();
        // GET: Categoria
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(persona.Listar());
            }
            else
            {
                return View(persona.Buscar(criterio));
            }
        }
        //Accion Ver
        public ActionResult Ver(int id)
        {
            return View(persona.Obtener(id));
        }
        //Accion Buscar
        public ActionResult Buscar(string criterio)
        {
            return View(
                criterio == null || criterio == ""
                ? persona.Listar()
                : persona.Buscar(criterio)
                );
        }
        //Accion AgregarEditar
        public ActionResult AgregarEditar(int id = 0)
        {
            return View(
                    id == 0 ? new Persona() // Sirve para agregar una categoria nueva
                            : persona.Obtener(id)//devuelve un objeto
                );
        }
        //Accion Guardar
        public ActionResult Guardar(Persona persona)
        {
            if (ModelState.IsValid)
            {
                persona.Guardar();
                return Redirect("~/Persona");
            }
            else
            {
                return View("~/Views/Persona/AgregarEditar.cshtml", persona);
            }
        }
        //Accion eliminar
        public ActionResult Eliminar(int id)
        {
            persona.persona_id = id;
            persona.Eliminar();
            return Redirect("~/Persona");
        }
    }
}