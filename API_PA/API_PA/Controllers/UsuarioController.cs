using API_PA.Entities;
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

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ConsultaUsuarios")]
        public List<TUsuario> ConsultaUsuarios()
        {
            try
            {
                using (var context = new PAEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    return (from x in context.TUsuario
                                 select x).ToList();
                    
                }
            }
            catch (Exception)
            {
                return new List<TUsuario>();
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ConsultaUsuario")]
        public TUsuario ConsultaUsuario(long ConUsuario)
        {
            try
            {
                using (var context = new PAEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    return (from x in context.TUsuario
                                 where x.ConUsuario == ConUsuario
                                 select x).FirstOrDefault();  
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("ActualizarUsuario")]
        public string ActualizarUsuario(UsuarioEnt entidad)
        {
            try
            {
                using (var context = new PAEntities())
                {
                    var datos = (from x in context.TUsuario
                                 where x.ConUsuario == entidad.ConUsuario
                                 select x).FirstOrDefault(); 

                    if (datos != null)
                    {
                        datos.Identificacion = entidad.Identificacion;
                        datos.Nombre = entidad.Nombre;
                        datos.Correo = entidad.Correo;
                        datos.Direccion = entidad.Direccion;
                        datos.Contrasenna = entidad.Contrasenna;

                        if (entidad.ConRol != 0)
                        {
                            datos.ConRol = entidad.ConRol;
                        }

                        context.SaveChanges();
                    }

                    return "OK";
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("ActualizarEstadoUsuario")]
        public string ActualizarEstadoUsuario(UsuarioEnt entidad)
        {
            try
            {
                using (var context = new PAEntities())
                {
                    var datos = (from x in context.TUsuario
                                 where x.ConUsuario == entidad.ConUsuario
                                 select x).FirstOrDefault();

                    if (datos != null)
                    {
                        datos.Estado = (datos.Estado == true ? false : true);
                        context.SaveChanges();
                    }

                    return "OK";
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

    }
}