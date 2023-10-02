using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_PA.Entities
{
    public class UsuarioEnt
    {
        public String Identificacion {  get; set; }
        public String Nombre { get; set;}
        public String Correo { get; set; }
        public String Contrasenna { get; set; }
    }
}