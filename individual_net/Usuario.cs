using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace individual_net
{
    public class Usuario
    {
        public long Id { get; set; }
        public string IdUsuario { get; set; }
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public int Telefono { get; set; }
    }
}