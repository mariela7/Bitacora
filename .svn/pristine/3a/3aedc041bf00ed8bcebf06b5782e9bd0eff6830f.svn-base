using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LogicaNegocios.Clases;
using AccesoDatos;

namespace LogicaNegocios.Metodos
{
    public class MetodoServicios_IngenieriaSeguridad
    {
        //[dbo].[Servicios_IngenieriaSeguridad_Delete]
        public int Servicios_IngenieriaSeguridad_Delete(int idServicio)
        {
            int id = 0;

            try
            {
                using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
                {
                    var i = a.Servicios_IngenieriaSeguridad_Delete(idServicio);

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


        //[dbo].[Servicios_IngenieriaSeguridad_Insert]
        public int Servicios_IngenieriaSeguridad_Insert(ClaseServicios_IngenieriaSeguridad servicio)
        {
            int id = 0;

            try
            {
                using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
                {
                    var i = a.Servicios_IngenieriaSeguridad_Insert(servicio.NombreServicio, servicio.PoseeTareas, servicio.Usuario, servicio.Ip);

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


        //[dbo].[Servicios_IngenieriaSeguridad_SelectAll]
        public List<ClaseServicios_IngenieriaSeguridad> Servicios_IngenieriaSeguridad_SelectAll()
        {
            List<ClaseServicios_IngenieriaSeguridad> ListadoServicios = new List<ClaseServicios_IngenieriaSeguridad>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Servicios_IngenieriaSeguridad_SelectAll();

                foreach (var dato in i)
                {
                    ClaseServicios_IngenieriaSeguridad servicio = new ClaseServicios_IngenieriaSeguridad();

                    servicio.IdServicio = dato.IdServicio;
                    servicio.NombreServicio = dato.NombreServicio;
                    servicio.PoseeTareas = dato.PoseeTareas;
                    servicio.Usuario = dato.Audit_User;
                    servicio.FechaUltimaModificacion = dato.Audit_FechaUltimaModificacion;
                    servicio.Ip = dato.Audit_IpUsuario;

                    ListadoServicios.Add(servicio);
                }

                return ListadoServicios;
            }
        }


        //[dbo].[Servicios_IngenieriaSeguridad_SelectbyDescripcion]
        public List<ClaseServicios_IngenieriaSeguridad> Servicios_IngenieriaSeguridad_SelectByDescripcion(string descripcion)
        {
            List<ClaseServicios_IngenieriaSeguridad> ListadoServicios = new List<ClaseServicios_IngenieriaSeguridad>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Servicios_IngenieriaSeguridad_SelectbyDescripcion(descripcion);

                foreach (var dato in i)
                {
                    ClaseServicios_IngenieriaSeguridad servicio = new ClaseServicios_IngenieriaSeguridad();

                    servicio.IdServicio = dato.IdServicio;
                    servicio.NombreServicio = dato.NombreServicio;
                    servicio.PoseeTareas = dato.PoseeTareas;
                    servicio.Usuario = dato.Audit_User;
                    servicio.FechaUltimaModificacion = dato.Audit_FechaUltimaModificacion;
                    servicio.Ip = dato.Audit_IpUsuario;

                    ListadoServicios.Add(servicio);
                }

                return ListadoServicios;
            }
        }


        //[dbo].[Servicios_IngenieriaSeguridad_SelectbyId]
        public ClaseServicios_IngenieriaSeguridad Servicios_IngenieriaSeguridad_SelectById(int idServicio)
        {
            ClaseServicios_IngenieriaSeguridad servicio = new ClaseServicios_IngenieriaSeguridad();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Servicios_IngenieriaSeguridad_SelectbyId(idServicio);

                foreach (var dato in i)
                {
                    servicio.IdServicio = dato.IdServicio;
                    servicio.NombreServicio = dato.NombreServicio;
                    servicio.PoseeTareas = dato.PoseeTareas;
                    servicio.Usuario = dato.Audit_User;
                    servicio.FechaUltimaModificacion = dato.Audit_FechaUltimaModificacion;
                    servicio.Ip = dato.Audit_IpUsuario;
                }

                return servicio;
            }
        }


        //[dbo].[Servicios_IngenieriaSeguridad_Update]
        public int Servicios_IngenieriaSeguridad_Update(ClaseServicios_IngenieriaSeguridad servicio)
        {
            int id = 0;

            try
            {
                using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
                {
                    var i = a.Servicios_IngenieriaSeguridad_Update(servicio.IdServicio, servicio.NombreServicio, servicio.PoseeTareas, servicio.EstaActivo, servicio.Usuario, servicio.Ip);

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
    }
}
