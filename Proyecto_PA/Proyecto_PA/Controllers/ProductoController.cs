using Proyecto_PA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_PA.Controllers
{
    public class ProductoController : Controller
    {
        ProductoModel productoModel = new ProductoModel();


        [HttpGet]
        public ActionResult ConsultarProductos()
        {
            var datos = productoModel.ConsultarProductos();
            return View(datos);
        }

        [HttpGet]
        public ActionResult RegistrarProducto()
        {
            return View();
        }
    }
 }
