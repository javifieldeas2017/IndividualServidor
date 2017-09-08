using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace individual_net
{
    public class Prestamo
    {
        public long Id { get; set; }
        public string IdPrestamo { get; set; }
        public string IdUsuario { get; set; }
        public string IdRecurso { get; set; }
        public string Recepcion { get; set; }
        public string Devolucion { get; set; }
    }
}