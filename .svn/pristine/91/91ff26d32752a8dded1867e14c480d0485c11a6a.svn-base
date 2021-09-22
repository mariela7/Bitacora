using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AccesoDatos;
using LogicaNegocios.Clases;
using System.Xml;

namespace LogicaNegocios.Metodos
{
    public class MetodoGeneral
    {
        public List<int> ObtenerAnos()
        {
            List<int> Listado = new List<int>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.ObtenerAno();

                foreach (var dato in i)
                {
                    int ano;

                    ano = dato.Value;                    

                    Listado.Add(ano);
                }

                return Listado;
            }
        }
        
        public List<string> GetAutorizados()
        {
            List<string> miLista = new List<string>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Autorizados_List();

                foreach (var dato in i)
                {
                    miLista.Add(dato);
                }

                return miLista;
            }
        
        }

        public List<ClaseFacturacion> ReporteFacturacionByMes(string mes, int ano, int idEmpresa, string empresa)
        {
            List<ClaseFacturacion> Listado = new List<ClaseFacturacion>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Reporte_Facturacion(mes, ano, idEmpresa, empresa);

                foreach (var dato in i)
                {
                    ClaseFacturacion objeto = new ClaseFacturacion();

                    /*Empresa	Mes	Fecha	Servicio	Tarea	Responsable	Horas	Evidencia*/

                    objeto.Empresa = dato.Empresa;
                    objeto.Mes = dato.Mes;
                    objeto.FechaInicio = Convert.ToDateTime(dato.FechaInicio);
                    objeto.FechaFin = Convert.ToDateTime(dato.FechaFin);
                    objeto.Servicio = dato.Servicio;
                    objeto.Tarea = dato.Tarea;
                    objeto.Responsable = dato.Responsable;
                    objeto.Horas = Convert.ToDouble(dato.Horas);
                    objeto.Evidencia = dato.Evidencia;
                    Listado.Add(objeto);
                }

                return Listado;
            }
        }

        public ClaseParametros Parametros_SelectByCodigo(string codigo)
        {
            ClaseParametros miClase = new ClaseParametros();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Parametros_SelectByCodigo(codigo);

                foreach (var item in i)
                {
                    miClase.Nombre = item.Nombre;
                    miClase.Codigo = item.Codigo.ToString();
                    miClase.Valor = item.Valor;
                }
            }
            return miClase;
        }

        public List<ClaseHoraIngresada> ReporteHorasIngresadas(string mes, int ano)
        {
            List<ClaseHoraIngresada> Listado = new List<ClaseHoraIngresada>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Reporte_HorasIngresadas(mes, ano);

                foreach (var dato in i)
                {
                    ClaseHoraIngresada objeto = new ClaseHoraIngresada();

                    /*Empresa	Mes	Fecha	Servicio	Tarea	Responsable	Horas	Evidencia*/

                    objeto.Empresa = dato.Empresa;
                    objeto.Responsable = dato.UsuarioRed;
                    objeto.Esfuerzo = dato.Esfuerzo;
                    Listado.Add(objeto);
                }

                return Listado;
            }
        }

        public List<ClaseBitacora_CertificacionApp> ReporteTodosLosProyectos(string empresa, DateTime fechaInicio, DateTime fechaFin, string proyecto)
        {
            List<ClaseBitacora_CertificacionApp> Listado = new List<ClaseBitacora_CertificacionApp>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Reporte_Proeyctos(empresa, fechaInicio, fechaFin, proyecto);

                foreach (var item in i)
                {
                    ClaseBitacora_CertificacionApp miclase = new ClaseBitacora_CertificacionApp();
                    miclase.IdBitacora = item.IdBitacora;
                    miclase.IdServicio = item.IdServicio;
                    miclase.FechaInicio = item.FechaInicio;
                    miclase.FechaFin = item.FechaFin;
                    miclase.Esfuerzo = item.Esfuerzo;
                    miclase.Responsable = item.Responsable;

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(item.Detalle);
                    miclase.Detalle = doc;

                    Listado.Add(miclase);
                }

                return Listado;
            }
        }
    }
}
