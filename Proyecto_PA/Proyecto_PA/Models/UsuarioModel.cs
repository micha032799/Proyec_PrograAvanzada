using Proyecto_PA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}