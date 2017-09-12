using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace individual_net
{
    public class Recurso
    {
        public long Id { get; set; }
        public string Tipo { get; set; }
        public long ISBN { get; set; }
        public long ISAN { get; set; }
        public long ISMN { get; set; }
        public string Categoria { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Anio { get; set; }
    }
}