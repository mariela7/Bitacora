using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LogicaNegocios.Clases;
using AccesoDatos;
using System.Data;

namespace LogicaNegocios.Metodos
{
    public class MetodoEmpresas_IngenieriaSeguridad
    {
        //[dbo].[Empresas_IngenieriaSeguridad_Delete]
        public int Empresas_IngenieriaSeguridad_Delete(int idEmpresa)
        {
            int id = 0;

            try
            {
                using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
                {
                    var i = a.Empresas_IngenieriaSeguridad_Delete(idEmpresa);

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

        //[dbo].[Empresas_IngenieriaSeguridad_Insert]
        public int Empresas_IngenieriaSeguridad_Insert(ClaseEmpresas_IngenieriaSeguridad empresa)
        {
            int id = 0;

            try
            {
                using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
                {
                    var i = a.Empresas_IngenieriaSeguridad_Insert(empresa.NombreEmpresa, empresa.Usuario, empresa.Ip);

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

        //[dbo].[Empresas_IngenieriaSeguridad_SelectAll]
        public List<ClaseEmpresas_IngenieriaSeguridad> Empresas_IngenieriaSeguridad_SelectAll()
        {
            List<ClaseEmpresas_IngenieriaSeguridad> ListadoEmpresas = new List<ClaseEmpresas_IngenieriaSeguridad>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Empresas_IngenieriaSeguridad_SelectAll();

                foreach (var dato in i)
                {

                    ClaseEmpresas_IngenieriaSeguridad empresa = new ClaseEmpresas_IngenieriaSeguridad();
                    empresa.IdEmpresa = dato.IdEmpresa;
                    empresa.NombreEmpresa = dato.NombreEmpresa;
                    empresa.Usuario = dato.Audit_User;
                    empresa.FechaUltimaModificacion = dato.Audit_FechaUltimaModificacion;
                    empresa.Ip = dato.Audit_IpUsuario;

                    ListadoEmpresas.Add(empresa);
                }

                return ListadoEmpresas;
            }
        }

        //[dbo].[Empresas_IngenieriaSeguridad_SelectByIdEmpresa]
        public ClaseEmpresas_IngenieriaSeguridad Empresas_IngenieriaSeguridad_SelectByIdEmpresa(int idEmpresa)
        {
            ClaseEmpresas_IngenieriaSeguridad empresa = new ClaseEmpresas_IngenieriaSeguridad();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Empresas_IngenieriaSeguridad_SelectByIdEmpresa(idEmpresa);

                foreach (var dato in i)
                {
                    empresa.IdEmpresa = dato.IdEmpresa;
                    empresa.NombreEmpresa = dato.NombreEmpresa;
                    empresa.Usuario = dato.Audit_User;
                    empresa.FechaUltimaModificacion = dato.Audit_FechaUltimaModificacion;
                    empresa.Ip = dato.Audit_IpUsuario;
                }

                return empresa;
            }
        }

        //[dbo].[Empresas_IngenieriaSeguridad_Update]
        public int Empresas_IngenieriaSeguridad_Update(ClaseEmpresas_IngenieriaSeguridad empresa)
        {
            int id = 0;

            try
            {
                using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
                {
                    var i = a.Empresas_IngenieriaSeguridad_Update(empresa.IdEmpresa, empresa.NombreEmpresa, empresa.Usuario, empresa.Ip);

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

        //[dbo].[Empresas_IngenieriaSeguridad_SelectByIdEmpresa]
        public List<ClaseEmpresas_IngenieriaSeguridad> Empresas_IngenieriaSeguridad_SelectByNombreEmpresa(string nombreEmpresa)
        {
            List<ClaseEmpresas_IngenieriaSeguridad> ListadoEmpresas = new List<ClaseEmpresas_IngenieriaSeguridad>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Empresas_IngenieriaSeguridad_SelectbyNombreEmpresa(nombreEmpresa);

                foreach (var dato in i)
                {
                    ClaseEmpresas_IngenieriaSeguridad empresa = new ClaseEmpresas_IngenieriaSeguridad();

                    empresa.IdEmpresa = dato.IdEmpresa;
                    empresa.NombreEmpresa = dato.NombreEmpresa;
                    empresa.Usuario = dato.Audit_User;
                    empresa.FechaUltimaModificacion = dato.Audit_FechaUltimaModificacion;
                    empresa.Ip = dato.Audit_IpUsuario;

                    ListadoEmpresas.Add(empresa);
                }

                return ListadoEmpresas;
            }
        }
    }
}
