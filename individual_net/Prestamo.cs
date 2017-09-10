using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace individual_net
{
    public class Prestamo
    {
        public long Id { get; set; }
        public int IdPrestamo { get; set; }
        public string NIF { get; set; }
        public string ISBN { get; set; }
        public string ISAN { get; set; }
        public string ISMN { get; set; }
        public int idCopia { get; set; }
        public string Recepcion { get; set; }
        public string Devolucion { get; set; }
    }
}