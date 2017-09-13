using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace individual_net
{
    public class Prestamo
    {
        public long Id { get; set; }
        public long IdPrestamo { get; set; }
        public string NIF { get; set; }
        public long ISBN { get; set; }
        public long ISAN { get; set; }
        public long ISMN { get; set; }
        public string Recepcion { get; set; }
        public string Devolucion { get; set; }
    }
}