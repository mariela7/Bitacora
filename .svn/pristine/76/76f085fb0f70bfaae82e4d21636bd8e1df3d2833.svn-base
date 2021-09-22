using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LogicaNegocios.Clases;
using AccesoDatos;
using System.Data;

namespace LogicaNegocios.Metodos
{
    public class MetodoBitacora_IngenieriaSeguridad
    {
        #region OperacionesBasicas
        //[dbo].[Bitacora_IngenieriaSeguridad_Insert]
        public int Bitacora_IngenieriaSeguridad_Insert(ClaseBitacora_IngenieriaSeguridad bitacora)
        {
            int id = 0;

            try
            {
                using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
                {
                    var i = a.Bitacora_IngenieriaSeguridad_Insert(bitacora.IdCategoria, bitacora.IdEmpresa, bitacora.FechaInicio, bitacora.FechaFin, bitacora.Tarea, bitacora.Frecuencia, bitacora.Evidencia, bitacora.Responsable, bitacora.Esfuerzo, bitacora.HoraExtra);

                    foreach (var r in i)
                    {
                        id = Convert.ToInt32(r.ToString());
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
        
        //[dbo].[Bitacora_IngenieriaSeguridad_Update]
        public int Bitacora_IngenieriaSeguridad_Update(ClaseBitacora_IngenieriaSeguridad bitacora)
        {
            int id = 0;

            try
            {
                using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
                {
                    var i = a.Bitacora_IngenieriaSeguridad_Update(bitacora.IdRegistro,
                                                                  bitacora.IdCategoria,
                                                                  bitacora.IdEmpresa,
                                                                  bitacora.FechaInicio,
                                                                  bitacora.FechaFin,
                                                                  bitacora.Tarea,
                                                                  bitacora.Frecuencia,
                                                                  bitacora.Evidencia,
                                                                  bitacora.Responsable,
                                                                  bitacora.Esfuerzo,
                                                                  bitacora.HoraExtra);

                    foreach (var r in i)
                    {
                        id = Convert.ToInt32(r.ToString());
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
        
        //[dbo].[Bitacora_IngenieriaSeguridad_Delete]
        public int Bitacora_IngenieriaSeguridad_Delete(int IdBitacora)
        {
            int id = 0;

            try
            {
                using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
                {
                    var i = a.Bitacora_IngenieriaSeguridad_Delete(IdBitacora);

                    foreach (var r in i)
                    {
                        id = Convert.ToInt32(r.ToString());
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
        #endregion


        #region SelectsUnicos
        //[dbo].[Bitacora_IngenieriaSeguridad_SelectAll]
        public List<ClaseBitacora_IngenieriaSeguridad> Bitacora_IngenieriaSeguridad_SelectAll()
        {
            List<ClaseBitacora_IngenieriaSeguridad> ListadoBitacoras = new List<ClaseBitacora_IngenieriaSeguridad>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Bitacora_IngenieriaSeguridad_SelectAll();

                foreach (var dato in i)
                {
                    ClaseBitacora_IngenieriaSeguridad bitacora = new ClaseBitacora_IngenieriaSeguridad();

                    bitacora.IdRegistro = dato.IdRegistro;
                    bitacora.IdCategoria = dato.IdCategoria;
                    bitacora.IdEmpresa = dato.IdEmpresa;
                    bitacora.FechaInicio = dato.FechaInicio;
                    bitacora.FechaFin = dato.FechaFin;
                    bitacora.Tarea = dato.Tarea;
                    bitacora.Frecuencia = dato.Frecuencia;
                    bitacora.Evidencia = dato.Evidencia;
                    bitacora.Responsable = dato.ResponsableIS;
                    bitacora.Esfuerzo = dato.Esfuerzo;
                    bitacora.HoraExtra = dato.HoraExtra;

                    ListadoBitacoras.Add(bitacora);
                }

                return ListadoBitacoras;
            }
        }
        
        //[dbo].[Bitacora_IngenieriaSeguridad_SelectByIdResgistro]
        public ClaseBitacora_IngenieriaSeguridad Bitacora_IngenieriaSeguridad_SelectByIdResgistro(int idResgistro)
        {
            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Bitacora_IngenieriaSeguridad_SelectByIdResgistro(idResgistro);

                ClaseBitacora_IngenieriaSeguridad bitacora = new ClaseBitacora_IngenieriaSeguridad();

                foreach (var dato in i)
                {
                    bitacora.IdRegistro = dato.IdRegistro;
                    bitacora.IdCategoria = dato.IdCategoria;
                    bitacora.IdEmpresa = dato.IdEmpresa;
                    bitacora.FechaInicio = dato.FechaInicio;
                    bitacora.FechaFin = dato.FechaFin;
                    bitacora.Tarea = dato.Tarea;
                    bitacora.Frecuencia = dato.Frecuencia;
                    bitacora.Evidencia = dato.Evidencia;
                    bitacora.Responsable = dato.ResponsableIS;
                    bitacora.Esfuerzo = dato.Esfuerzo;
                    bitacora.HoraExtra = dato.HoraExtra;
                }

                return bitacora;
            }
        }
        
        //[dbo].[Bitacora_IngenieriaSeguridad_SelectByResponsable]
        public List<ClaseBitacora_IngenieriaSeguridad> Bitacora_IngenieriaSeguridad_SelectByResponsable(string responsable)
        {
            List<ClaseBitacora_IngenieriaSeguridad> ListadoBitacoras = new List<ClaseBitacora_IngenieriaSeguridad>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Bitacora_IngenieriaSeguridad_SelectByResponsable(responsable);

                foreach (var dato in i)
                {
                    ClaseBitacora_IngenieriaSeguridad bitacora = new ClaseBitacora_IngenieriaSeguridad();

                    bitacora.IdRegistro = dato.IdRegistro;
                    bitacora.IdCategoria = dato.IdCategoria;
                    bitacora.IdEmpresa = dato.IdEmpresa;
                    bitacora.FechaInicio = dato.FechaInicio;
                    bitacora.FechaFin = dato.FechaFin;
                    bitacora.Tarea = dato.Tarea;
                    bitacora.Frecuencia = dato.Frecuencia;
                    bitacora.Evidencia = dato.Evidencia;
                    bitacora.Responsable = dato.ResponsableIS;
                    bitacora.Esfuerzo = dato.Esfuerzo;
                    bitacora.HoraExtra = dato.HoraExtra;

                    ListadoBitacoras.Add(bitacora);
                }

                return ListadoBitacoras;
            }
        }
        #endregion


        #region FiltrosUnicos
        //[dbo].[Bitacora_IngenieriaSeguridad_SelectByEmpresa]
        public List<ClaseBitacora_IngenieriaSeguridad> Bitacora_IngenieriaSeguridad_SelectByEmpresa(int empresa)
        {
            List<ClaseBitacora_IngenieriaSeguridad> ListadoBitacoras = new List<ClaseBitacora_IngenieriaSeguridad>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Bitacora_IngenieriaSeguridad_SelectByEmpresa(empresa);

                foreach (var dato in i)
                {
                    ClaseBitacora_IngenieriaSeguridad bitacora = new ClaseBitacora_IngenieriaSeguridad();

                    bitacora.IdRegistro = dato.IdRegistro;
                    bitacora.IdCategoria = dato.IdCategoria;
                    bitacora.IdEmpresa = dato.IdEmpresa;
                    bitacora.FechaInicio = dato.FechaInicio;
                    bitacora.FechaFin = dato.FechaFin;
                    bitacora.Tarea = dato.Tarea;
                    bitacora.Frecuencia = dato.Frecuencia;
                    bitacora.Evidencia = dato.Evidencia;
                    bitacora.Responsable = dato.ResponsableIS;
                    bitacora.Esfuerzo = dato.Esfuerzo;
                    bitacora.HoraExtra = dato.HoraExtra;

                    ListadoBitacoras.Add(bitacora);
                }

                return ListadoBitacoras;
            }
        }
        
        //[dbo].[Bitacora_IngenieriaSeguridad_SelectByFechaFin]
        public List<ClaseBitacora_IngenieriaSeguridad> Bitacora_IngenieriaSeguridad_SelectByFechaFin(DateTime fechaFin)
        {
            List<ClaseBitacora_IngenieriaSeguridad> ListadoBitacoras = new List<ClaseBitacora_IngenieriaSeguridad>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Bitacora_IngenieriaSeguridad_SelectByFechaFin(fechaFin);

                foreach (var dato in i)
                {
                    ClaseBitacora_IngenieriaSeguridad bitacora = new ClaseBitacora_IngenieriaSeguridad();

                    bitacora.IdRegistro = dato.IdRegistro;
                    bitacora.IdCategoria = dato.IdCategoria;
                    bitacora.IdEmpresa = dato.IdEmpresa;
                    bitacora.FechaInicio = dato.FechaInicio;
                    bitacora.FechaFin = dato.FechaFin;
                    bitacora.Tarea = dato.Tarea;
                    bitacora.Frecuencia = dato.Frecuencia;
                    bitacora.Evidencia = dato.Evidencia;
                    bitacora.Responsable = dato.ResponsableIS;
                    bitacora.Esfuerzo = dato.Esfuerzo;
                    bitacora.HoraExtra = dato.HoraExtra;

                    ListadoBitacoras.Add(bitacora);
                }

                return ListadoBitacoras;
            }
        }
        
        //[dbo].[Bitacora_IngenieriaSeguridad_SelectByFechaInicio]
        public List<ClaseBitacora_IngenieriaSeguridad> Bitacora_IngenieriaSeguridad_SelectByFechaInicio(DateTime fechaInicio)
        {
            List<ClaseBitacora_IngenieriaSeguridad> ListadoBitacoras = new List<ClaseBitacora_IngenieriaSeguridad>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Bitacora_IngenieriaSeguridad_SelectByFechaInicio(fechaInicio);

                foreach (var dato in i)
                {
                    ClaseBitacora_IngenieriaSeguridad bitacora = new ClaseBitacora_IngenieriaSeguridad();

                    bitacora.IdRegistro = dato.IdRegistro;
                    bitacora.IdCategoria = dato.IdCategoria;
                    bitacora.IdEmpresa = dato.IdEmpresa;
                    bitacora.FechaInicio = dato.FechaInicio;
                    bitacora.FechaFin = dato.FechaFin;
                    bitacora.Tarea = dato.Tarea;
                    bitacora.Frecuencia = dato.Frecuencia;
                    bitacora.Evidencia = dato.Evidencia;
                    bitacora.Responsable = dato.ResponsableIS;
                    bitacora.Esfuerzo = dato.Esfuerzo;
                    bitacora.HoraExtra = dato.HoraExtra;

                    ListadoBitacoras.Add(bitacora);
                }

                return ListadoBitacoras;
            }
        }
        
        //[dbo].[Bitacora_IngenieriaSeguridad_SelectByMes]
        public List<ClaseBitacora_IngenieriaSeguridad> Bitacora_IngenieriaSeguridad_SelectByMes(string mes)
        {
            List<ClaseBitacora_IngenieriaSeguridad> ListadoBitacoras = new List<ClaseBitacora_IngenieriaSeguridad>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Bitacora_IngenieriaSeguridad_SelectByMes(mes);

                foreach (var dato in i)
                {
                    ClaseBitacora_IngenieriaSeguridad bitacora = new ClaseBitacora_IngenieriaSeguridad();

                    bitacora.IdRegistro = dato.IdRegistro;
                    bitacora.IdCategoria = dato.IdCategoria;
                    bitacora.IdEmpresa = dato.IdEmpresa;
                    bitacora.FechaInicio = dato.FechaInicio;
                    bitacora.FechaFin = dato.FechaFin;
                    bitacora.Tarea = dato.Tarea;
                    bitacora.Frecuencia = dato.Frecuencia;
                    bitacora.Evidencia = dato.Evidencia;
                    bitacora.Responsable = dato.ResponsableIS;
                    bitacora.Esfuerzo = dato.Esfuerzo;
                    bitacora.HoraExtra = dato.HoraExtra;

                    ListadoBitacoras.Add(bitacora);
                }

                return ListadoBitacoras;
            }
        }
        
        //[dbo].[Bitacora_IngenieriaSeguridad_SelectByServicio]
        public List<ClaseBitacora_IngenieriaSeguridad> Bitacora_IngenieriaSeguridad_SelectByServicio(int idServicio)
        {
            List<ClaseBitacora_IngenieriaSeguridad> ListadoBitacoras = new List<ClaseBitacora_IngenieriaSeguridad>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Bitacora_IngenieriaSeguridad_SelectByServicio(idServicio);

                foreach (var dato in i)
                {
                    ClaseBitacora_IngenieriaSeguridad bitacora = new ClaseBitacora_IngenieriaSeguridad();

                    bitacora.IdRegistro = dato.IdRegistro;
                    bitacora.IdCategoria = dato.IdCategoria;
                    bitacora.IdEmpresa = dato.IdEmpresa;
                    bitacora.FechaInicio = dato.FechaInicio;
                    bitacora.FechaFin = dato.FechaFin;
                    bitacora.Tarea = dato.Tarea;
                    bitacora.Frecuencia = dato.Frecuencia;
                    bitacora.Evidencia = dato.Evidencia;
                    bitacora.Responsable = dato.ResponsableIS;
                    bitacora.Esfuerzo = dato.Esfuerzo;
                    bitacora.HoraExtra = dato.HoraExtra;

                    ListadoBitacoras.Add(bitacora);
                }

                return ListadoBitacoras;
            }
        }

        public List<ClaseBitacora_IngenieriaSeguridad> Bitacora_IngenieriaSeguridad_SelectVariosFiltros(int? idServicio, 
                                                                                                       string responsable, 
                                                                                                       string mes, 
                                                                                                       DateTime? fechaInicio, 
                                                                                                       DateTime? fechaFin, 
                                                                                                       int? empresa,
                                                                                                       int? ano,
                                                                                                       bool? extra)
        {
            List<ClaseBitacora_IngenieriaSeguridad> ListadoBitacoras = new List<ClaseBitacora_IngenieriaSeguridad>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Bitacora_IngenieriaSeguridad_SelectVariosFiltros(idServicio, responsable, mes, fechaInicio, fechaFin, empresa, ano, extra);

                foreach (var dato in i)
                {
                    ClaseBitacora_IngenieriaSeguridad bitacora = new ClaseBitacora_IngenieriaSeguridad();

                    bitacora.IdRegistro = dato.IdRegistro;
                    bitacora.IdCategoria = dato.IdCategoria;
                    bitacora.IdEmpresa = dato.IdEmpresa;
                    bitacora.FechaInicio = dato.FechaInicio;
                    bitacora.FechaFin = dato.FechaFin;
                    bitacora.Tarea = dato.Tarea;
                    bitacora.Frecuencia = dato.Frecuencia;
                    bitacora.Evidencia = dato.Evidencia;
                    bitacora.Responsable = dato.ResponsableIS;
                    bitacora.Esfuerzo = dato.Esfuerzo;
                    bitacora.HoraExtra = dato.HoraExtra;

                    ListadoBitacoras.Add(bitacora);
                }

                return ListadoBitacoras;
            }
        }





        #endregion


        #region FiltrosConUsuario
        //[dbo].[Bitacora_IngenieriaSeguridad_SelectByEmpresa_User]
        public List<ClaseBitacora_IngenieriaSeguridad> Bitacora_IngenieriaSeguridad_SelectByEmpresaAndUser(int empresa, string usuario)
        {
            List<ClaseBitacora_IngenieriaSeguridad> ListadoBitacoras = new List<ClaseBitacora_IngenieriaSeguridad>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Bitacora_IngenieriaSeguridad_SelectByEmpresa_User(empresa, usuario);

                foreach (var dato in i)
                {
                    ClaseBitacora_IngenieriaSeguridad bitacora = new ClaseBitacora_IngenieriaSeguridad();

                    bitacora.IdRegistro = dato.IdRegistro;
                    bitacora.IdCategoria = dato.IdCategoria;
                    bitacora.IdEmpresa = dato.IdEmpresa;
                    bitacora.FechaInicio = dato.FechaInicio;
                    bitacora.FechaFin = dato.FechaFin;
                    bitacora.Tarea = dato.Tarea;
                    bitacora.Frecuencia = dato.Frecuencia;
                    bitacora.Evidencia = dato.Evidencia;
                    bitacora.Responsable = dato.ResponsableIS;
                    bitacora.Esfuerzo = dato.Esfuerzo;
                    bitacora.HoraExtra = dato.HoraExtra;

                    ListadoBitacoras.Add(bitacora);
                }

                return ListadoBitacoras;
            }
        }
        
        //[dbo].[Bitacora_IngenieriaSeguridad_SelectByFechaFin_User]
        public List<ClaseBitacora_IngenieriaSeguridad> Bitacora_IngenieriaSeguridad_SelectByFechaFinAndUser(DateTime fechaFin, string usuario)
        {
            List<ClaseBitacora_IngenieriaSeguridad> ListadoBitacoras = new List<ClaseBitacora_IngenieriaSeguridad>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Bitacora_IngenieriaSeguridad_SelectByFechaFin_User(fechaFin, usuario);

                foreach (var dato in i)
                {
                    ClaseBitacora_IngenieriaSeguridad bitacora = new ClaseBitacora_IngenieriaSeguridad();

                    bitacora.IdRegistro = dato.IdRegistro;
                    bitacora.IdCategoria = dato.IdCategoria;
                    bitacora.IdEmpresa = dato.IdEmpresa;
                    bitacora.FechaInicio = dato.FechaInicio;
                    bitacora.FechaFin = dato.FechaFin;
                    bitacora.Tarea = dato.Tarea;
                    bitacora.Frecuencia = dato.Frecuencia;
                    bitacora.Evidencia = dato.Evidencia;
                    bitacora.Responsable = dato.ResponsableIS;
                    bitacora.Esfuerzo = dato.Esfuerzo;
                    bitacora.HoraExtra = dato.HoraExtra;

                    ListadoBitacoras.Add(bitacora);
                }

                return ListadoBitacoras;
            }
        }
        
        //[dbo].[Bitacora_IngenieriaSeguridad_SelectByFechaInicio_User]
        public List<ClaseBitacora_IngenieriaSeguridad> Bitacora_IngenieriaSeguridad_SelectByFechaInicioAndUser(DateTime fechaInicio, string usuario)
        {
            List<ClaseBitacora_IngenieriaSeguridad> ListadoBitacoras = new List<ClaseBitacora_IngenieriaSeguridad>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Bitacora_IngenieriaSeguridad_SelectByFechaInicio_User(fechaInicio, usuario);

                foreach (var dato in i)
                {
                    ClaseBitacora_IngenieriaSeguridad bitacora = new ClaseBitacora_IngenieriaSeguridad();

                    bitacora.IdRegistro = dato.IdRegistro;
                    bitacora.IdCategoria = dato.IdCategoria;
                    bitacora.IdEmpresa = dato.IdEmpresa;
                    bitacora.FechaInicio = dato.FechaInicio;
                    bitacora.FechaFin = dato.FechaFin;
                    bitacora.Tarea = dato.Tarea;
                    bitacora.Frecuencia = dato.Frecuencia;
                    bitacora.Evidencia = dato.Evidencia;
                    bitacora.Responsable = dato.ResponsableIS;
                    bitacora.Esfuerzo = dato.Esfuerzo;
                    bitacora.HoraExtra = dato.HoraExtra;

                    ListadoBitacoras.Add(bitacora);
                }

                return ListadoBitacoras;
            }
        }

        //[dbo].[Bitacora_IngenieriaSeguridad_SelectByMes_User]
        public List<ClaseBitacora_IngenieriaSeguridad> Bitacora_IngenieriaSeguridad_SelectByMesAndUser(string mes, string usuario)
        {
            List<ClaseBitacora_IngenieriaSeguridad> ListadoBitacoras = new List<ClaseBitacora_IngenieriaSeguridad>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Bitacora_IngenieriaSeguridad_SelectByMes_User(mes, usuario);

                foreach (var dato in i)
                {
                    ClaseBitacora_IngenieriaSeguridad bitacora = new ClaseBitacora_IngenieriaSeguridad();

                    bitacora.IdRegistro = dato.IdRegistro;
                    bitacora.IdCategoria = dato.IdCategoria;
                    bitacora.IdEmpresa = dato.IdEmpresa;
                    bitacora.FechaInicio = dato.FechaInicio;
                    bitacora.FechaFin = dato.FechaFin;
                    bitacora.Tarea = dato.Tarea;
                    bitacora.Frecuencia = dato.Frecuencia;
                    bitacora.Evidencia = dato.Evidencia;
                    bitacora.Responsable = dato.ResponsableIS;
                    bitacora.Esfuerzo = dato.Esfuerzo;
                    bitacora.HoraExtra = dato.HoraExtra;

                    ListadoBitacoras.Add(bitacora);
                }

                return ListadoBitacoras;
            }
        }
        
        //[dbo].[Bitacora_IngenieriaSeguridad_SelectByServicio_User]
        public List<ClaseBitacora_IngenieriaSeguridad> Bitacora_IngenieriaSeguridad_SelectByServicioAndUser(int idServicio, string usuario)
        {
            List<ClaseBitacora_IngenieriaSeguridad> ListadoBitacoras = new List<ClaseBitacora_IngenieriaSeguridad>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Bitacora_IngenieriaSeguridad_SelectByServicio_User(idServicio, usuario);

                foreach (var dato in i)
                {
                    ClaseBitacora_IngenieriaSeguridad bitacora = new ClaseBitacora_IngenieriaSeguridad();

                    bitacora.IdRegistro = dato.IdRegistro;
                    bitacora.IdCategoria = dato.IdCategoria;
                    bitacora.IdEmpresa = dato.IdEmpresa;
                    bitacora.FechaInicio = dato.FechaInicio;
                    bitacora.FechaFin = dato.FechaFin;
                    bitacora.Tarea = dato.Tarea;
                    bitacora.Frecuencia = dato.Frecuencia;
                    bitacora.Evidencia = dato.Evidencia;
                    bitacora.Responsable = dato.ResponsableIS;
                    bitacora.Esfuerzo = dato.Esfuerzo;
                    bitacora.HoraExtra = dato.HoraExtra;

                    ListadoBitacoras.Add(bitacora);
                }

                return ListadoBitacoras;
            }
        }
        #endregion

        
        
         
        
    }
}
