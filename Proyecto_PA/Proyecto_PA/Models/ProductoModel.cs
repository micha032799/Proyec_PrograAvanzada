using Proyecto_PA.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace Proyecto_PA.Models
{
    public class ProductoModel
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];


        public List<ProductoEnt> ConsultarProductos()
        {
            using (var client = new HttpClient())
            {
                var url = urlApi + "ConsultarProductos";
                var res = client.GetAsync(url).Result;
                return res.Content.ReadFromJsonAsync<List<ProductoEnt>>().Result;
            }
        }

    }
}