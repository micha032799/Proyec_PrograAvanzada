﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_PA.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult PerfilUsuario()
        {
            return View();
        }
    }
}