using API_PA.Entities;
using System.Linq;
using System.Web.Http;

namespace API_PA.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("RegistrarCuenta")]
        public string RegistrarCuenta(UsuarioEnt entidad)
        {
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

                context.RegistrarCuentaSP(entidad.Identificacion, entidad.Nombre, entidad.Correo, entidad.Contrasena, entidad.Estado, entidad.Direccion);

                return "Registro realizado exitosamente!";
            }
        }
        [HttpPost]
        [Route("IniciarSesion")]
        public IniciarSesionSP_Result IniciarSesion(UsuarioEnt entidad)
        {
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
    }
}
