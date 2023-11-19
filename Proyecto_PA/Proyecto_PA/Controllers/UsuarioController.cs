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
            long ConUsuario = long.Parse(Session["ConUsuario"].ToString());
            var datos = usuarioModel.ConsultaUsuario(ConUsuario);
            ViewBag.Rol = usuarioModel.ConsultaRol();
            return View(datos);
        }

        [HttpPost]
        public ActionResult PerfilUsuario(UsuarioEnt entidad)
        {
            var resp = usuarioModel.ActualizarUsuario(entidad);

            if (resp == "OK")
            {
                Session["Nombre"] = entidad.Nombre;
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
            long ConUsuario = long.Parse(Session["ConUsuario"].ToString());
            var datos = usuarioModel.ConsultaUsuarios().Where(x => x.ConUsuario != ConUsuario).ToList();
            return View(datos);
        }

        [HttpGet]
        public ActionResult ActualizarEstadoUsuario(long ConUsuario)
        {
            var entidad = new UsuarioEnt();
            entidad.ConUsuario = ConUsuario;

            var resp = usuarioModel.ActualizarEstadoUsuario(entidad);

            if (resp == "OK")
            {
                return RedirectToAction("ConsultaUsuarios", "Usuario");
            }
            else
            {
                ViewBag.MensajeUsuario = "No se pudo actualizar el estado del usuario";
                return View();
            }
        }

        [HttpGet]
        public ActionResult ActualizarUsuario(long ConUsuario)
        {
            ViewBag.Rol = usuarioModel.ConsultaRol();
            var datos = usuarioModel.ConsultaUsuario(ConUsuario);
            return View(datos);
        }

        [HttpPost]
        public ActionResult ActualizarUsuario(UsuarioEnt entidad)
        {
            var resp = usuarioModel.ActualizarUsuario(entidad);

            if (resp == "OK")
            {
                return RedirectToAction("ConsultaUsuarios", "Usuario");
            }
            else
            {
                ViewBag.MensajeUsuario = "No se pudo actualizar el estado del usuario";
                return View();
            }
        }
    }
}