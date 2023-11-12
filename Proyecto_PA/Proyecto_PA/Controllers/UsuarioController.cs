using Proyecto_PA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Proyecto_PA.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioModel usuarioModel = new UsuarioModel();

        [HttpGet]
        public ActionResult PerfilUsuario()
        {
            ViewBag.Rol = usuarioModel.ConsultaRol();
            return View();
        }
    }
}