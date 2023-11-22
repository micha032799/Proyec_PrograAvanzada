﻿using Proyecto_PA.Entities;
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
        public ActionResult RegistrarProducto(HttpPostedFileBase ImgProducto ,  ProductoEnt entidad)
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
                    ViewBag.MensajeUsuario = "No se ha registrado el producto.";
                    return View();
                }
            }
    }
}
