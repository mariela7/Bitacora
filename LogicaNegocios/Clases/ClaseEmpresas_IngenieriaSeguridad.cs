using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegocios.Clases
{
    public class ClaseEmpresas_IngenieriaSeguridad
    {
        //[IdEmpresa] [int] IDENTITY(1,1) NOT NULL,
        //[NombreEmpresa] [varchar](150) NOT NULL,
        //[Audit_User] [varchar](20) NOT NULL,
        //[Audit_FechaUltimaModificacion] [datetime] NOT NULL,
        //[Audit_IpUsuario] [varchar](20) NOT NULL,

        public int IdEmpresa { get; set; }

        public string NombreEmpresa { get; set; }

        public string Usuario { get; set; }

        public DateTime FechaUltimaModificacion { get; set; }

        public string Ip { get; set; }
    }
}
