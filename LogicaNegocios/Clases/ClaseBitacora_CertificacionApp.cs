using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace LogicaNegocios.Clases
{
    public class ClaseBitacora_CertificacionApp
    {
        //[IdBitacora] [int] IDENTITY(1,1) NOT NULL,
        //[IdServicio] [int] NOT NULL,
        //[Fecha] [date] NOT NULL,
        //[Esfuerzo] [decimal](18, 2) NOT NULL,
        //[Responsable] [varchar](50) NOT NULL,
        //[Detalle] [xml] NOT NULL,

        public int IdBitacora { get; set; }

        public int IdServicio { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public decimal Esfuerzo { get; set; }

        public string Responsable { get; set; }

        public XmlNode Detalle { get; set; }
    }
}
