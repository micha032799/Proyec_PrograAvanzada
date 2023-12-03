
using API_PA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;


namespace API_PA.Controllers
{
    public class ProductoController : ApiController
    {


        // GET: api/TProductoes

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ConsultarProductos")]
        public List<TProducto> ConsultarProductos()
        {
            using (var context = new PAEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;
                return context.TProducto.ToList();
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("RegistrarProducto")]
        public long RegistrarProducto(TProducto tProducto)
        {
            using (var context = new PAEntities())
            {
                context.TProducto.Add(tProducto);
                context.SaveChanges();
                return tProducto.ConProducto;
            }
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("ActualizarRutaImagen")]
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

            /*
            private PAEntities db = new PAEntities();

            // GET: api/TProductoes
            public IQueryable<TProducto> GetTProducto()
            {
                return db.TProducto;
            }

            // GET: api/TProductoes/5
            [ResponseType(typeof(TProducto))]
            public IHttpActionResult GetTProducto(long id)
            {
                TProducto tProducto = db.TProducto.Find(id);
                if (tProducto == null)
                {
                    return NotFound();
                }

                return Ok(tProducto);
            }

            // PUT: api/TProductoes/5
            [ResponseType(typeof(void))]
            public IHttpActionResult PutTProducto(long id, TProducto tProducto)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != tProducto.ConProducto)
                {
                    return BadRequest();
                }

                db.Entry(tProducto).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TProductoExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return StatusCode(HttpStatusCode.NoContent);
            }

            // POST: api/TProductoes
            [ResponseType(typeof(TProducto))]
            public IHttpActionResult PostTProducto(TProducto tProducto)
            {

                db.TProducto.Add(tProducto);
                db.SaveChanges();

                return CreatedAtRoute("DefaultApi", new { id = tProducto.ConProducto }, tProducto);
            }

            // DELETE: api/TProductoes/5
            [ResponseType(typeof(TProducto))]
            public IHttpActionResult DeleteTProducto(long id)
            {
                TProducto tProducto = db.TProducto.Find(id);
                if (tProducto == null)
                {
                    return NotFound();
                }

                db.TProducto.Remove(tProducto);
                db.SaveChanges();

                return Ok(tProducto);
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }

            private bool TProductoExists(long id)
            {
                return db.TProducto.Count(e => e.ConProducto == id) > 0;
            }
            */
        }

    }
}