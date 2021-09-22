using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegocios.Clases
{
    public class ClaseCategorias_IngenieriaSeguridad
    {
        //[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
        //[DescripcionCategoria] [varchar](200) NOT NULL,
        //[EstaActivo] [bit] NULL,
        //[IdServicio] [int] NULL,
        //[Audit_User] [varchar](20) NOT NULL,
        //[Audit_FechaUltimaModificacion] [datetime] NOT NULL,
        //[Audit_IpUsuario] [varchar](20) NOT NULL,

        public int IdCategoria { get; set; }

        public string DescripcionCategoria { get; set; }

        public bool EstaActivo { get; set; }

        public int IdServicio { get; set; }

        public string Usuario { get; set; }

        public DateTime FechaUltimaModificacion { get; set; }

        public string Ip { get; set; }
    }
}
