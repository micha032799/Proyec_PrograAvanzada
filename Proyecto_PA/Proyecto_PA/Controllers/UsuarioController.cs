using Proyecto_PA.Entities;
using Proyecto_PA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
             var datos = usuarioModel.ConsultaUsuario();
            ViewBag.Rol = usuarioModel.ConsultaRol();
            return View(datos);
        }

        [HttpPost]
        public ActionResult PerfilUsuario(UsuarioEnt entidad)
        {
            var resp = usuarioModel.ActualizarUsuario(entidad);

            if (resp == "OK")
            {
                Session["NombreUsuario"] = entidad.Nombre;
                return RedirectToAction("PerfilUsuario", "Usuario");
            }
            else
            {
                ViewBag.Rol = usuarioModel.ConsultaRol();
                ViewBag.MensajeUsuario = "No se pudo actualizar la información de su perfil";
                return View();
            }
        }

        [HttpGet]
        public ActionResult ConsultaUsuarios()
        {
            long ConUsuario = long.Parse(Session["CodigoUsuario"].ToString());
            var datos = usuarioModel.ConsultaUsuarios().Where(x => x.ConUsuario != ConUsuario).ToList();
            return View(datos);
        }
    }
}