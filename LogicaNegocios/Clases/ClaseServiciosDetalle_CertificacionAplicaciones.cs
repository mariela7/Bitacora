using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegocios.Clases
{
    public class ClaseServiciosDetalle_CertificacionAplicaciones
    {
        public int IdServicio { get; set; }
        public int Orden { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public bool EsLista { get; set; }
        public int IdLista { get; set; }

        public List<ClaseLista_CertificacionAplicaciones> Lista { get; set; }
    }
}
