using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace API_PA.Controllers
{
    public class UsuarioController : ApiController
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ConsultaRol")]
        public List<System.Web.Mvc.SelectListItem> ConsultaRol()
        {
            try
            {
                using (var context = new PAEntities())
                {
                    var datos = (from x in context.TRol
                                 select x).ToList();

                    var respuesta = new List<System.Web.Mvc.SelectListItem>();
                    foreach (var item in datos)
                    {
                        respuesta.Add(new System.Web.Mvc.SelectListItem { Value = item.ConRol.ToString(), Text = item.Descripcion });
                    }

                    return respuesta;
                }
            }
            catch (Exception)
            {
                return new List<System.Web.Mvc.SelectListItem>();
            }
        }
    }
}