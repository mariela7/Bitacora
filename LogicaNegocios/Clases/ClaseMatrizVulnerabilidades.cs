using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegocios.Clases
{
    public class ClaseMatrizVulnerabilidades
    {
        public int IdEmpresa { get; set; }

        //[IdVulnerabilidad] [int] IDENTITY(1,1) NOT NULL,
        public int IdVulnerabilidad { get; set; }

        //[CodigoUnico] [varchar](60) NULL,
        public string CodigoUnico { get; set; }

        //[CodigoProveedor] [varchar](60) NULL,
        public string CodigoProveedor { get; set; }

        //[CodigoSiTcs] [varchar](60) NULL,
        public string CodigoSiTCS { get; set; }

        //[Proveedor] [varchar](50) NULL,
        public string Proveedor { get; set; }

        //[FechaDeIdentificacion] [datetime] NULL,
        public DateTime FechaIdentificacion { get; set; }

        //[DocumentoFuente] [varchar](300) NULL,
        public string DocumentoFuente { get; set; }

        //[Aplicacion] [varchar](100) NULL,
        public string Aplicacion { get; set; }

        //[Nivel] [varchar](50) NULL,
        public string Nivel { get; set; }

        //[ActivoConLaVulnerabilidad] [varchar](50) NULL,
        public string Activo { get; set; }

        //[EquipoOModulo] [varchar](50) NULL,
        public string EquipoModulo { get; set; }

        //[TipoVulnerabilidad] [varchar](50) NULL,
        public string TipoVulnerabilidad { get; set; }

        //[Descripcion] [varchar](max) NULL,
        public string Descripcion { get; set; }

        //[Impacto] [varchar](10) NULL,
        public string Impacto { get; set; }

        //[Probabilidad] [varchar](10) NULL,
        public string Probabilidad { get; set; }

        //[Criticidad] [varchar](10) NULL,
        public string Criticidad { get; set; }

        //[Recomendacion] [varchar](max) NULL,
        public string Recomendacion { get; set; }

        //[Estado] [varchar](20) NULL,
        public string Estado { get; set; }

        //[FechaCierre] [datetime] NULL,
        public DateTime FechaCierre { get; set; }

        //[TipoDeCierre] [varchar](10) NULL,
        public string TipoCierre { get; set; }

        //[CodigoDeSolucion] [varchar](100) NULL,
        public string CodigoSolucion { get; set; }

        //[ResponsableSI] [varchar](50) NULL,
        public string ResponsableSI { get; set; }
    }
}
