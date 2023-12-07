
using API_PA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;


namespace API_PA.Controllers
{
    public class ProductoController : ApiController
    {

        [HttpGet]
        [Route("ConsultarProductos")]
        public List<TProducto> ConsultarProductos()
        {
            using (var context = new PAEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;
                return context.TProducto.ToList();
            }
        }

        [HttpGet]
        [Route("ConsultaProducto")]
        public TProducto ConsultaProducto(long q)
        {
            using (var context = new PAEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;
                return (from x in context.TProducto
                        where x.ConProducto == q
                        select x).FirstOrDefault();
            }
        }

        [HttpPost]
        [Route("RegistrarProducto")]
        public long RegistrarProducto(TProducto tProducto)
        {
            using (var context = new PAEntities())
            {
                context.TProducto.Add(tProducto);
                context.SaveChanges();
                return tProducto.ConProducto;
            }
        }

        [HttpPut]
        [Route("ActualizarRutaImagen")]
        public string ActualizarRutaImagen(TProducto tProducto)
        {
            using (var context = new PAEntities())
            {
                var datos = context.TProducto.FirstOrDefault(x => x.ConProducto == tProducto.ConProducto);

                if (datos != null)
                {
                    datos.Imagen = tProducto.Imagen;
                    context.SaveChanges();
                }

                return "OK";
            }
        }

        [HttpPut]
        [Route("ActualizarProducto")]
        public string ActualizarProducto(TProducto tProducto)
        {
            using (var context = new PAEntities())
            {
                var datos = context.TProducto.Where(x => x.ConProducto == tProducto.ConProducto).FirstOrDefault();
                datos.Nombre = tProducto.Nombre;
                datos.Descripcion = tProducto.Descripcion;
                datos.Cantidad = tProducto.Cantidad;
                datos.Precio = tProducto.Precio;
                context.SaveChanges();
                return "OK";
            }
        }

        [HttpPut]
        [Route("ActualizarEstadoProducto")]
        public string ActualizarEstadoUsuario(TProducto tProducto)
        {
            using (var context = new PAEntities())
            {
                var datos = context.TProducto.Where(x => x.ConProducto == tProducto.ConProducto).FirstOrDefault();
                datos.Estado = (datos.Estado ? false : true);
                context.SaveChanges();
                return "OK";
            }
        }

    }
}