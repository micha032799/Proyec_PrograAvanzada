using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;
using Proyecto_PA.Entities;

namespace Proyecto_PA.Models
{
    public class UsuarioModel
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];
        public UsuarioEnt IniciarSesion(UsuarioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "IniciarSesion";
                JsonContent contenido = JsonContent.Create(entidad);
                var resp = client.PostAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<UsuarioEnt>().Result;
            }
        }

        public string RegistrarCuenta(UsuarioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "RegistrarCuenta";
                JsonContent contenido = JsonContent.Create(entidad);
                var resp = client.PostAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
        }

        public string RecuperarCuenta(UsuarioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "RecuperarCuenta";
                JsonContent contenido = JsonContent.Create(entidad);
                var resp = client.PostAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
        }


        public List<SelectListItem> ConsultaRol()
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "ConsultaRol";
                var resp = client.GetAsync(url).Result;
                return resp.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
            }
        }

        public List<UsuarioEnt> ConsultaUsuarios()
        {
            using (var client = new HttpClient())
            {
                var url = urlApi + "ConsultaUsuarios";
                var res = client.GetAsync(url).Result;
                return res.Content.ReadFromJsonAsync<List<UsuarioEnt>>().Result;
            }
        }

        public UsuarioEnt ConsultaUsuario()
        {
            using (var client = new HttpClient())
            {
                var url = urlApi + "ConsultaUsuario?ConUsuario=" + HttpContext.Current.Session["CodigoUsuario"];
                var res = client.GetAsync(url).Result;
                return res.Content.ReadFromJsonAsync<UsuarioEnt>().Result;
            }
        }

        public string ActualizarUsuario(UsuarioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "ActualizarUsuario";
                JsonContent contenido = JsonContent.Create(entidad);
                var resp = client.PutAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
        }
    }

}