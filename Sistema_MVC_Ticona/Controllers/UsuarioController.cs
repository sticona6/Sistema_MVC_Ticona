using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Ticona.Models;

namespace Sistema_MVC_Ticona.Controllers
{
    public class UsuarioController : Controller
    {
        private Usuario usuario = new Usuario();
        private Persona persona = new Persona();
        // GET: Categoria
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(usuario.Listar());
            }
            else
            {
                return View(usuario.Buscar(criterio));
            }
        }
        //Accion Ver
        public ActionResult Ver(int id)
        {
            return View(usuario.Obtener(id));
        }
        //Accion Buscar
        public ActionResult Buscar(string criterio)
        {
            return View(
                criterio == null || criterio == ""
                ? usuario.Listar()
                : usuario.Buscar(criterio)
                );
        }
        //Accion AgregarEditar
        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Persona = persona.Listar();
            return View(
                    id == 0 ? new Usuario() // Sirve para agregar una categoria nueva
                            : usuario.Obtener(id)//devuelve un objeto
                );
        }
        //Accion Guardar
        public ActionResult Guardar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Guardar();
                return Redirect("~/Usuario");
            }
            else
            {
                return View("~/Views/Usuario/AgregarEditar.cshtml",usuario);
            }
        }
        //Accion eliminar
        public ActionResult Eliminar(int id)
        {
            usuario.usuario_id = id;
            usuario.Eliminar();
            return Redirect("~/Usuario");
        }
    }
}