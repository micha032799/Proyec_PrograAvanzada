using API_PA.Entities;
using System.Linq;
using System.Web.Http;
using System;
using System.IO;
using System.Collections.Generic;

namespace API_PA.Controllers
{
    public class LoginController : ApiController
    {
        Utilitarios util = new Utilitarios();
        [HttpPost]
        [Route("RegistrarCuenta")]
        public string RegistrarCuenta(UsuarioEnt entidad)
        {
            try {
                using (var context = new PAEntities())
                {
                    //TUsuario user = new TUsuario();
                    //user.Identificacion = entidad.Identificacion;
                    //user.Nombre = entidad.Nombre;
                    //user.Correo = entidad.Correo;
                    //user.Contrasena = entidad.Contrasena;
                    //user.Estado = entidad.Estado;
                    //user.Direccion = entidad.Direccion;

                    //context.TUsuario.Add(user);
                    //context.SaveChanges();

                    context.RegistrarCuentaSP(entidad.Identificacion, entidad.Nombre, entidad.Correo, entidad.Contrasena);

                    return "Registro realizado exitosamente!";
                }
            }
            catch(Exception){
                return string.Empty;
            }
        }
        [HttpPost]
        [Route("IniciarSesion")]
        public IniciarSesionSP_Result IniciarSesion(UsuarioEnt entidad)
        {
            try {
                using (var context = new PAEntities())
                {
                    //var datos = (from x in context.TUsuario
                    //             where x.Correo == entidad.Correo
                    //             && x.Contrasena == entidad.Contrasena
                    //             && x.Estado == true
                    //             select x).FirstOrDefault();

                    return context.IniciarSesionSP(entidad.Correo, entidad.Contrasena).FirstOrDefault();
                }
            }
            catch (Exception){
                return null;
            }
        }
        [HttpPost]
        [Route("RecuperarCuenta")]
        public string RecuperarCuenta (UsuarioEnt entidad)
        {
            try
            {
                using (var context = new PAEntities())
                {
                    var datos = (from x in context.TUsuario
                                 where x.Identificacion == entidad.Identificacion
                                 select x).FirstOrDefault();

                    if (datos != null)
                    {
                        string urlHtml = AppDomain.CurrentDomain.BaseDirectory + "Templates\\mail.html";
                        string html = File.ReadAllText(urlHtml);

                        html = html.Replace("@@Nombre", datos.Nombre);
                        html = html.Replace("@@Contrasenna", datos.Contrasenna);

                        util.EnvioCorreos(datos.Correo, "Recuperar Contraseña", html);
                        return "OK";
                    }

                    return string.Empty;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
