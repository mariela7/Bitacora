using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LogicaNegocios.Clases;
using AccesoDatos;

namespace LogicaNegocios.Metodos
{
    public class MetodoCategorias_IngenieriaSeguridad
    {
        //[dbo].[Categorias_IngenieriaSeguridad_Delete]
        public int Categorias_IngenieriaSeguridad_Delete(int idCategoria)
        {
            int id = 0;

            try
            {
                using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
                {
                    var i = a.Categorias_IngenieriaSeguridad_Delete(idCategoria);

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

        //[dbo].[Categorias_IngenieriaSeguridad_Insert]
        public int Categorias_IngenieriaSeguridad_Insert(ClaseCategorias_IngenieriaSeguridad categoria)
        {
            int id = 0;

            try
            {
                using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
                {
                    var i = a.Categorias_IngenieriaSeguridad_Insert(categoria.DescripcionCategoria, categoria.IdServicio, categoria.Usuario, categoria.Ip);

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

        //[dbo].[Categorias_IngenieriaSeguridad_SelectAll]
        public List<ClaseCategorias_IngenieriaSeguridad> Categorias_IngenieriaSeguridad_SelectAll()
        {
            List<ClaseCategorias_IngenieriaSeguridad> ListadoCategorias = new List<ClaseCategorias_IngenieriaSeguridad>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Categorias_IngenieriaSeguridad_SelectAll();

                foreach (var dato in i)
                {
                    ClaseCategorias_IngenieriaSeguridad categoria = new ClaseCategorias_IngenieriaSeguridad();

                    categoria.IdCategoria = dato.IdCategoria;
                    categoria.DescripcionCategoria = dato.DescripcionCategoria;
                    categoria.EstaActivo = dato.EstaActivo;
                    categoria.IdServicio = dato.IdServicio;
                    categoria.Usuario = dato.Audit_User;
                    categoria.FechaUltimaModificacion = dato.Audit_FechaUltimaModificacion;
                    categoria.Ip = dato.Audit_IpUsuario;

                    ListadoCategorias.Add(categoria);
                }

                return ListadoCategorias;
            }
        }

        //[dbo].[Categorias_IngenieriaSeguridad_SelectbyDescripcion]
        public List<ClaseCategorias_IngenieriaSeguridad> Categorias_IngenieriaSeguridad_SelectByDescripcion(string descripcion)
        {
            List<ClaseCategorias_IngenieriaSeguridad> ListadoCategorias = new List<ClaseCategorias_IngenieriaSeguridad>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Categorias_IngenieriaSeguridad_SelectbyDescripcion(descripcion);

                foreach (var dato in i)
                {
                    ClaseCategorias_IngenieriaSeguridad categoria = new ClaseCategorias_IngenieriaSeguridad();

                    categoria.IdCategoria = dato.IdCategoria;
                    categoria.DescripcionCategoria = dato.DescripcionCategoria;
                    categoria.EstaActivo = dato.EstaActivo;
                    categoria.IdServicio = dato.IdServicio;
                    categoria.Usuario = dato.Audit_User;
                    categoria.FechaUltimaModificacion = dato.Audit_FechaUltimaModificacion;
                    categoria.Ip = dato.Audit_IpUsuario;

                    ListadoCategorias.Add(categoria);
                }

                return ListadoCategorias;
            }
        }

        //[dbo].[Categorias_IngenieriaSeguridad_SelectbyId]
        public ClaseCategorias_IngenieriaSeguridad Categorias_IngenieriaSeguridad_SelectByIdCategoria(int idCategoria)
        {
            ClaseCategorias_IngenieriaSeguridad categoria = new ClaseCategorias_IngenieriaSeguridad();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Categorias_IngenieriaSeguridad_SelectbyId(idCategoria);

                foreach (var dato in i)
                {
                    categoria.IdCategoria = dato.IdCategoria;
                    categoria.DescripcionCategoria = dato.DescripcionCategoria;
                    categoria.EstaActivo = dato.EstaActivo;
                    categoria.IdServicio = dato.IdServicio;
                    categoria.Usuario = dato.Audit_User;
                    categoria.FechaUltimaModificacion = dato.Audit_FechaUltimaModificacion;
                    categoria.Ip = dato.Audit_IpUsuario;
                }

                return categoria;
            }
        }

        //[dbo].[Categorias_IngenieriaSeguridad_SelectbyIdServicio]
        public List<ClaseCategorias_IngenieriaSeguridad> Categorias_IngenieriaSeguridad_SelectbyIdServicio(int idServicio)
        {
            List<ClaseCategorias_IngenieriaSeguridad> ListadoCategorias = new List<ClaseCategorias_IngenieriaSeguridad>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Categorias_IngenieriaSeguridad_SelectbyIdServicio(idServicio);

                foreach (var dato in i)
                {
                    ClaseCategorias_IngenieriaSeguridad categoria = new ClaseCategorias_IngenieriaSeguridad();

                    categoria.IdCategoria = dato.IdCategoria;
                    categoria.DescripcionCategoria = dato.DescripcionCategoria;
                    categoria.EstaActivo = dato.EstaActivo;
                    categoria.IdServicio = dato.IdServicio;
                    categoria.Usuario = dato.Audit_User;
                    categoria.FechaUltimaModificacion = dato.Audit_FechaUltimaModificacion;
                    categoria.Ip = dato.Audit_IpUsuario;

                    ListadoCategorias.Add(categoria);
                }

                return ListadoCategorias;
            }
        }

        //[dbo].[Categorias_IngenieriaSeguridad_Update]
        public int Categorias_IngenieriaSeguridad_Update(ClaseCategorias_IngenieriaSeguridad categoria)
        {
            int id = 0;

            try
            {
                using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
                {
                    var i = a.Categorias_IngenieriaSeguridad_Update(categoria.IdCategoria, categoria.DescripcionCategoria, categoria.Usuario, categoria.Ip);

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
