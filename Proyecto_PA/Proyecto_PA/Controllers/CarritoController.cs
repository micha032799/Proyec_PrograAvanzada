using Proyecto_PA.Entities;
using Proyecto_PA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_PA.Controllers
{
    public class CarritoController : Controller
    {
        CarritoModel carritoModel = new CarritoModel();

        [HttpPost]
        public ActionResult RegistrarCarrito(long conProducto, int cantidad)
        {
            CarritoEnt entidad = new CarritoEnt();
            entidad.ConUsuario = long.Parse(Session["ConUsuario"].ToString());
            entidad.ConProducto = conProducto;
            entidad.Cantidad = cantidad;
            entidad.FechaCarrito = DateTime.Now;

            carritoModel.RegistrarCarrito(entidad);

            var datos = carritoModel.ConsultarCarrito(long.Parse(Session["ConUsuario"].ToString()));
            Session["Cant"] = datos.Sum(x => x.Cantidad);
            Session["Subt"] = datos.Sum(x => x.SubTotal);

            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ConsultarCarrito()
        {
            var datos = carritoModel.ConsultarCarrito(long.Parse(Session["ConUsuario"].ToString()));
            Session["Total"] = datos.Sum(x => x.Total);
            return View(datos);
        }
    }
}