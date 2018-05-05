using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Ticona.Models;

namespace Sistema_MVC_Ticona.Controllers
{
    public class DocumentoController : Controller
    {
        private Documento documento = new Documento();
        private Categoria categoria = new Categoria();

        // GET: Categoria
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(documento.Listar());
            }
            else
            {
                return View(documento.Buscar(criterio));
            }
        }
        //Accion Ver
        public ActionResult Ver(int id)
        {
            return View(documento.Obtener(id));
        }
        //Accion Buscar
        public ActionResult Buscar(string criterio)
        {
            return View(
                criterio == null || criterio == ""
                ? documento.Listar()
                : documento.Buscar(criterio)
                );
        }
        //Accion AgregarEditar
        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Categoria = categoria.Listar();
            return View(
                    id == 0 ? new Documento() // Sirve para agregar una categoria nueva
                            : documento.Obtener(id)//devuelve un objeto
                );
        }
        //Accion Guardar
        public ActionResult Guardar(Documento documento)
        {
            if (ModelState.IsValid)
            {
                documento.Guardar();
                return Redirect("~/Documento");
            }
            else
            {
                return View("~/Views/Documento/AgregarEditar.cshtml", documento);
            }
        }
        //Accion eliminar
        public ActionResult Eliminar(int id)
        {
            documento.categoria_id = id;
            documento.Eliminar();
            return Redirect("~/Documento");
        }
    }
}