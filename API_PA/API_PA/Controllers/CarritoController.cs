using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_PA.Controllers
{

    public class CarritoController : ApiController
    {

            [System.Web.Http.HttpPost]
        [System.Web.Http.Route("RegistrarCarrito")]
        public string RegistrarCarrito(TCarrito tCarrito)
        {
            using (var context = new PAEntities())
            {
                var datos = (from x in context.TCarrito
                             where x.ConUsuario == tCarrito.ConUsuario
                             && x.ConProducto == tCarrito.ConProducto
                             select x).FirstOrDefault();

                if (datos == null)
                {
                    context.TCarrito.Add(tCarrito);
                    context.SaveChanges();
                }
                else
                {
                    datos.Cantidad = tCarrito.Cantidad;
                    context.SaveChanges();
                }

                return "OK";
            }
        }
        [HttpGet]
        [Route("ConsultarCarrito")]
        public object ConsultarCarrito(long q)
        {
            using (var context = new PAEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;
                return (from x in context.TCarrito
                        join y in context.TProducto on x.ConProducto equals y.ConProducto
                        where x.ConUsuario == q
                        select new
                        {
                            x.ConProducto,
                            x.ConCarrito,
                            x.ConUsuario,
                            x.Cantidad,
                            x.FechaCarrito,
                            y.Precio,
                            y.Nombre,
                            SubTotal = y.Precio * x.Cantidad,
                            Impuesto = (y.Precio * x.Cantidad) * 0.13M,
                            Total = (y.Precio * x.Cantidad) + (y.Precio * x.Cantidad) * 0.13M
                        }).ToList();
            }
        }
    }
}
