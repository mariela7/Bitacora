using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogicaNegocios.Clases;
using AccesoDatos;
using System.Xml;
using System.Data;

namespace LogicaNegocios.Metodos
{
    public class MetodoBitacora_CertificacionAplicaciones
    {
        public List<ClaseServicios_CertificacionAplicaciones> Bitacora_CertificacionApp_SelectServicios()
        {
            List<ClaseServicios_CertificacionAplicaciones> ListadoBitacoras = new List<ClaseServicios_CertificacionAplicaciones>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Bitacora_CertificacionApp_SelectServicios();

                foreach (var dato in i)
                {
                    ClaseServicios_CertificacionAplicaciones bitacora = new ClaseServicios_CertificacionAplicaciones();

                    bitacora.IdServicio = dato.Id;
                    bitacora.Nombre = dato.Nombre;
                    bitacora.Usuario = dato.AuditUser;
                    bitacora.Fecha = dato.AuditFecha;
                    bitacora.Machine = dato.AuditMachine;
                    ListadoBitacoras.Add(bitacora);
                }

                return ListadoBitacoras;
            }
        }

        public List<ClaseServiciosDetalle_CertificacionAplicaciones> Bitacora_CertificacionApp_SelectServiciosDetalles(int IdServicio)
        {
            List<ClaseServiciosDetalle_CertificacionAplicaciones> ListadoBitacoras = new List<ClaseServiciosDetalle_CertificacionAplicaciones>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Bitacora_CertificacionApp_SelectServiciosDetalles(IdServicio);

                foreach (var dato in i)
                {
                    ClaseServiciosDetalle_CertificacionAplicaciones bitacora = new ClaseServiciosDetalle_CertificacionAplicaciones();

                    bitacora.IdServicio = dato.IdServicio;
                    bitacora.Nombre = dato.Nombre;
                    bitacora.Orden = dato.Orden;
                    bitacora.Tipo = dato.Tipo;
                    bitacora.EsLista = dato.EsLista;
                    bitacora.IdLista = dato.IdLista;

                    if (dato.EsLista)
                    {
                        bitacora.Lista = Bitacora_CertificacionApp_SelectLista(dato.IdLista);
                    }

                    ListadoBitacoras.Add(bitacora);
                }

                return ListadoBitacoras;
            }
        }

        public List<ClaseLista_CertificacionAplicaciones> Bitacora_CertificacionApp_SelectLista(int IdLista)
        {
            List<ClaseLista_CertificacionAplicaciones> ListadoBitacoras = new List<ClaseLista_CertificacionAplicaciones>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Bitacora_CertificacionApp_SelectLista(IdLista);

                foreach (var dato in i)
                {
                    ClaseLista_CertificacionAplicaciones bitacora = new ClaseLista_CertificacionAplicaciones();

                    bitacora.IdLista = dato.IdLista;
                    bitacora.Valor = dato.Valor;
                    ListadoBitacoras.Add(bitacora);
                }

                return ListadoBitacoras;
            }
        }

        public int Bitacora_CertificacionApp_InsertLista(List<ClaseLista_CertificacionAplicaciones> ListaValores)
        {
            int id = 0;

            try
            {
                using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
                {
                    int idListaMax = a.BCA_Listas.Max(x => x.IdLista);
                    foreach (ClaseLista_CertificacionAplicaciones dato in ListaValores)
	                {
                        
                        var i = a.Bitacora_CertificacionApp_InsertLista(idListaMax+1, dato.NombreLista, dato.Valor);

                        foreach (var r in i)
                        {
                            id = Convert.ToInt32(r.ToString());
                        }
	                }                    
                }
            }
            catch (Exception)
            {
                id = -1;
                throw;
            }

            return id;
        }

        public List<ClaseLista_CertificacionAplicaciones> Bitacora_CertificacionApp_ListaSelectAll()
        {
            List<ClaseLista_CertificacionAplicaciones> ListadoListas = new List<ClaseLista_CertificacionAplicaciones>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Bitacora_CertificacionApp_ListaSelectAll();

                foreach (var dato in i)
                {
                    ClaseLista_CertificacionAplicaciones lista = new ClaseLista_CertificacionAplicaciones();

                    lista.IdLista = dato.IdLista;
                    lista.NombreLista = dato.NombreLista;
                    lista.Valor = dato.Valor;
                    
                    ListadoListas.Add(lista);
                }

                return ListadoListas;
            }
        }

        public void Bitacora_CertificacionApp_EditarLista(List<ClaseLista_CertificacionAplicaciones> ListadoListas)
        {
            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                foreach (var item in ListadoListas)
	            {
                    var i = a.Bitacora_CertificacionApp_EditarLista(item.IdLista, item.NombreLista, item.Valor);
	            }
            }
        }

        public int Bitacora_CertificacionApp_InsertarDetalle(List<ClaseBitacora_CertificacionAplicaciones> ValorDetalle)
        {
            int id = 0;

            try
            {
                using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
                {

                    foreach (ClaseBitacora_CertificacionAplicaciones item in ValorDetalle)
                    {
                        var i = a.Bitacora_CertificacionApp_InsertDetalle(item.IdServicio, item.Fecha, item.Esfuerzo, item.Responsable, item.Detalle.OuterXml.ToString());
                    }
                }
            }
            catch (Exception)
            {
                id = -1;
                throw;
            }

            return id;

        }


        public int Bitacora_CertificacionApp_UpdateDetalle(List<ClaseBitacora_CertificacionAplicaciones> ValorDetalle)
        {
            int id = 0;

            try
            {
                using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
                {

                    foreach (ClaseBitacora_CertificacionAplicaciones item in ValorDetalle)
                    {
                        var i = a.Bitacora_CertificacionApp_UpdateDetalle(item.IdBitacora, item.IdServicio, item.Fecha, item.Esfuerzo, item.Responsable, item.Detalle.OuterXml.ToString());
                    }
                }
            }
            catch (Exception)
            {
                id = -1;
                throw;
            }

            return id;

        }

        public List<ClaseBitacora_CertificacionAplicaciones> Bitacora_CertificacionApp_SelectByServicio(string responsable, int servicio, int mes, int anio)
        {
            List<ClaseBitacora_CertificacionAplicaciones> milista = new List<ClaseBitacora_CertificacionAplicaciones>();
            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Bitacora_CertificacionApp_SelectByServicio(responsable, mes, anio, servicio);

                foreach (var item in i)
                {
                    ClaseBitacora_CertificacionAplicaciones miclase = new ClaseBitacora_CertificacionAplicaciones();
                    miclase.IdBitacora = item.IdBitacora;
                    miclase.IdServicio = item.IdServicio;
                    miclase.Fecha = item.Fecha;
                    miclase.Esfuerzo = item.Esfuerzo;
                    miclase.Responsable = item.Responsable;

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(item.Detalle);
                    miclase.Detalle = doc;
                    milista.Add(miclase);

                }
            }


            return milista;
        }

        public List<ClaseBitacora_CertificacionAplicaciones> Bitacora_CertificacionApp_SelectByServicio_ALL(string responsable, int servicio, int mes, int anio)
        {
            List<ClaseBitacora_CertificacionAplicaciones> milista = new List<ClaseBitacora_CertificacionAplicaciones>();
            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Bitacora_CertificacionApp_SelectByServicio_ALL(responsable, mes, anio, servicio);

                foreach (var item in i)
                {
                    ClaseBitacora_CertificacionAplicaciones miclase = new ClaseBitacora_CertificacionAplicaciones();
                    miclase.IdBitacora = item.IdBitacora;
                    miclase.IdServicio = item.IdServicio;
                    miclase.Fecha = item.Fecha;
                    miclase.Esfuerzo = item.Esfuerzo;
                    miclase.Responsable = item.Responsable;

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(item.Detalle);
                    miclase.Detalle = doc;
                    milista.Add(miclase);

                }
            }


            return milista;
        }
    
    }
}
