using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegocios.Clases
{
    public class ClaseBitacora_IngenieriaSeguridad
    {
        //[IdRegistro] [int] IDENTITY(1,1) NOT NULL,
        //[IdCategoria] [int] NOT NULL,
        //[IdEmpresa] [int] NOT NULL,
        //[Fecha] [datetime] NOT NULL,
        //[FechaFin] [datetime] NOT NULL,
        //[Tarea] [varchar](max) NOT NULL,
        //[Frecuencia] [varchar](50) NOT NULL,
        //[Evidencia] [varchar](max) NOT NULL,
        //[ResponsableIS] [varchar](20) NOT NULL,
        //[Esfuerzo] [decimal](18, 2) NOT NULL,

        public int IdRegistro { get; set; }

        public int IdCategoria { get; set; }

        public int IdEmpresa { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public string Tarea { get; set; }

        public string Frecuencia { get; set; }

        public string Evidencia { get; set; }

        public string Responsable { get; set; }

        public decimal Esfuerzo { get; set; }

        public bool HoraExtra { get; set; }
    }
}
