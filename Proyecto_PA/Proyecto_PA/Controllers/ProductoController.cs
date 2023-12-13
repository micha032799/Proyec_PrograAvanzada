using Proyecto_PA.Entities;
using Proyecto_PA.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_PA.Controllers
{
    public class ProductoController : Controller
    {
        ProductoModel productoModel = new ProductoModel();
        CarritoModel carritoModel = new CarritoModel();

        public ActionResult ListaProductos()
        {
            var datos = productoModel.ConsultarProductos().Where(x => x.Estado == true && x.Cantidad > 0).ToList();
            return View(datos);
        }

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

        [HttpPost]
        public ActionResult RegistrarProducto(HttpPostedFileBase ImgProducto, ProductoEnt entidad)
        {
            entidad.Imagen = string.Empty;
            entidad.Estado = true;

            long conProducto = productoModel.RegistrarProducto(entidad);

            if (conProducto > 0)
            {
                string extension = Path.GetExtension(Path.GetFileName(ImgProducto.FileName));
                string ruta = AppDomain.CurrentDomain.BaseDirectory + "Images\\" + conProducto + extension;
                ImgProducto.SaveAs(ruta);

                entidad.Imagen = "/Images/" + conProducto + extension;
                entidad.ConProducto = conProducto;

                productoModel.ActualizarRutaImagen(entidad);

                return RedirectToAction("ConsultarProductos", "Producto");
            }
            else
            {
                ViewBag.MensajeUsuario = "No se ha registrado el producto";
                return View();
            }
        }

        [HttpGet]
        public ActionResult ActualizarEstadoProducto(long q)
        {
            var entidad = new ProductoEnt();
            entidad.ConProducto = q;

            string respuesta = productoModel.ActualizarEstadoProducto(entidad);

            if (respuesta == "OK")
            {
                return RedirectToAction("ConsultarProductos", "Producto");
            }
            else
            {
                ViewBag.MensajeUsuario = "No se ha podido cambiar el estado del producto";
                return View();
            }
        }

        [HttpGet]
        public ActionResult ActualizarProducto(long q)
        {
            var datos = productoModel.ConsultaProducto(q);
            return View(datos);
        }

        [HttpPost]
        public ActionResult ActualizarProducto(HttpPostedFileBase ImgProducto, ProductoEnt entidad)
        {
            string respuesta = productoModel.ActualizarProducto(entidad);

            if (respuesta == "OK")
            {
                if (ImgProducto != null)
                {
                    string extension = Path.GetExtension(Path.GetFileName(ImgProducto.FileName));
                    string ruta = AppDomain.CurrentDomain.BaseDirectory + "Images\\" + entidad.ConProducto + extension;
                    ImgProducto.SaveAs(ruta);

                    entidad.Imagen = "/Images/" + entidad.ConProducto + extension;
                    entidad.ConProducto = entidad.ConProducto;

                    productoModel.ActualizarRutaImagen(entidad);
                }

                var datos = carritoModel.ConsultarCarrito(long.Parse(Session["ConUsuario"].ToString()));
                Session["Cant"] = datos.Sum(x => x.Cantidad);
                Session["Subt"] = datos.Sum(x => x.SubTotal);

                return RedirectToAction("ConsultarProductos", "Producto");
            }
            else
            {
                ViewBag.MensajeUsuario = "No se ha podido actualizar la información del producto";
                return View();
            }
        }


    }
}