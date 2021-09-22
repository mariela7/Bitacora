using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegocios.Clases
{
    public class ClaseServicios_IngenieriaSeguridad
    {
        //[IdServicio] [int] IDENTITY(1,1) NOT NULL,
        //[NombreServicio] [varchar](200) NOT NULL,
        //[PoseeTareas] [bit] NOT NULL,
        //[EstaActivo] [bit] NOT NULL,
        //[Audit_User] [varchar](20) NOT NULL,
        //[Audit_FechaUltimaModificacion] [datetime] NOT NULL,
        //[Audit_IpUsuario] [varchar](20) NOT NULL,

        public int IdServicio { get; set; }

        public string NombreServicio { get; set; }

        public bool PoseeTareas { get; set; }

        public bool EstaActivo { get; set; }

        public string Usuario { get; set; }

        public DateTime FechaUltimaModificacion { get; set; }

        public string Ip { get; set; }

    }
}
