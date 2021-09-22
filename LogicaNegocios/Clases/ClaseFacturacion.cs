using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegocios.Clases
{
    public class ClaseFacturacion
    {
        //Empresa string
        //Mes string
        //Fecha string
        //Servicio string
        //Tarea string
        //Responsable string
        //Horas string
        //Evidencia double

        public string Empresa { get; set; }

        public string Mes { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public string Servicio { get; set; }

        public string Tarea { get; set; }

        public string Responsable { get; set; }

        public double Horas { get; set; }

        public string Evidencia { get; set; }
    }
}
