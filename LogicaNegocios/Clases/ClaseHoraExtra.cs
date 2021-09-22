using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegocios.Clases
{
    public class ClaseHoraExtra
    {
        //CREATE TABLE SoloExtrasTmp(
        //ultimatix VARCHAR(10), 
        //usuarioRed VARCHAR(20),
        //nombreCompleto VARCHAR(110), 
        //supervisor CHAR(3),
        //dia VARCHAR(10),
        //fechaHoraInicio DATETIME,
        //fechaHoraFin DATETIME,
        //extra BIT,
        //tiempo TIME

        public char InsertUpdate { get; set; }

        public int IdRegistro { get; set; }

        public string Ultimatix { get; set; }

        public string UsuarioRed { get; set; }

        public string NombreCompleto { get; set; }

        public string Supervisor { get; set; }

        public int Mes { get; set; }

        public string Dia { get; set; }

        public DateTime FechaHoraInicio { get; set; }

        public DateTime FechaHoraFin { get; set; }

        public bool HoraExtra { get; set; }

        public TimeSpan Tiempo { get; set; }

        public bool? EsExtra { get; set; }

        public TimeSpan? HorasAprobadas { get; set; }

        public string Justificacion { get; set; }

        public bool? Aprobada { get; set; }
    }
}
