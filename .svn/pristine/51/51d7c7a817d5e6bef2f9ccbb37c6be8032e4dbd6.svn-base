using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AccesoDatos;
using LogicaNegocios.Clases;

namespace LogicaNegocios.Metodos
{
    public class MetodoMatrizVulnerabilidades
    {
        public string MatrizVulnerabilidades_Insert(ClaseMatrizVulnerabilidades clMatriz)
        {
            string retorno = string.Empty;

            try
            {
                using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
                {
                    var i = a.MatrizVulnerabilidades_Insert(clMatriz.IdEmpresa,
                                                            clMatriz.CodigoUnico,
                                                            clMatriz.CodigoProveedor, 
                                                            clMatriz.Proveedor, 
                                                            clMatriz.FechaIdentificacion, 
                                                            clMatriz.DocumentoFuente, 
                                                            clMatriz.Aplicacion, 
                                                            clMatriz.Nivel, 
                                                            clMatriz.Activo, 
                                                            clMatriz.EquipoModulo, 
                                                            clMatriz.TipoVulnerabilidad,
                                                            clMatriz.Descripcion,
                                                            clMatriz.Impacto,
                                                            clMatriz.Probabilidad,
                                                            clMatriz.Criticidad,
                                                            clMatriz.Recomendacion,
                                                            clMatriz.Estado,
                                                            clMatriz.FechaCierre,
                                                            clMatriz.TipoCierre,
                                                            clMatriz.CodigoSolucion,
                                                            clMatriz.ResponsableSI);

                    foreach (var r in i)
                    {
                        retorno = r.ToString();
                    }
                }
            }
            catch (Exception)
            {
                retorno = string.Empty;
                throw;
            }
            return retorno;
        }

        public string MatrizVulnerabilidades_Update(int idVulnerabilidad, string estado, DateTime fechaCierre, string tipoCierre, string codigoSolucion)
        {
            string retorno = string.Empty;

            try
            {
                using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
                {
                    var i = a.MatrizVulnerabilidades_Update(idVulnerabilidad, estado, fechaCierre, tipoCierre, codigoSolucion);

                    foreach (var r in i)
                    {
                        retorno = r.ToString();
                    }
                }
            }
            catch (Exception)
            {
                retorno = string.Empty;
                throw;
            }
            return retorno;
        }
        
        public List<ClaseMatrizVulnerabilidades> MatrizVulnerabilidades_SelectByCodigoSiTCS(string CodigoSiTCS)
        {
            List<ClaseMatrizVulnerabilidades> Listado = new List<ClaseMatrizVulnerabilidades>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.MatrizVulnerabilidades_SelectByCodigoSiTCS(CodigoSiTCS);

                foreach (var dato in i)
                {
                    ClaseMatrizVulnerabilidades clase = new ClaseMatrizVulnerabilidades();

                    clase.IdVulnerabilidad = dato.IdVulnerabilidad;
                    clase.IdEmpresa = dato.IdEmpresa;
                    clase.CodigoUnico = dato.CodigoUnico;
                    clase.CodigoProveedor = dato.CodigoProveedor;
                    clase.CodigoSiTCS = dato.CodigoSiTcs;
                    clase.Proveedor = dato.Proveedor;
                    clase.FechaIdentificacion = Convert.ToDateTime(dato.FechaDeIdentificacion);
                    clase.DocumentoFuente = dato.DocumentoFuente;
                    clase.Aplicacion = dato.Aplicacion;
                    clase.Nivel = dato.Nivel;
                    clase.Activo = dato.ActivoConLaVulnerabilidad;
                    clase.EquipoModulo = dato.EquipoOModulo;
                    clase.TipoVulnerabilidad =  dato.TipoVulnerabilidad;
                    clase.Descripcion = dato.Descripcion;
                    clase.Impacto = dato.Impacto;
                    clase.Probabilidad = dato.Probabilidad;
                    clase.Criticidad = dato.Criticidad;
                    clase.Recomendacion = dato.Recomendacion;
                    clase.Estado = dato.Estado;
                    clase.FechaCierre = Convert.ToDateTime(dato.FechaCierre);
                    clase.TipoCierre = dato.TipoDeCierre;
                    clase.CodigoSolucion = dato.CodigoDeSolucion;
                    clase.ResponsableSI = dato.ResponsableSI;

                    Listado.Add(clase);
                }

                return Listado;
            }
        }

        public List<ClaseMatrizVulnerabilidades> MatrizVulnerabilidades_SelectByCodigoSiTCS_NoCerradas(string CodigoSiTCS, int idEmpresa)
        {
            List<ClaseMatrizVulnerabilidades> Listado = new List<ClaseMatrizVulnerabilidades>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.MatrizVulnerabilidades_SelectByCodigoSiTCSYNoCerradas(CodigoSiTCS, idEmpresa);

                foreach (var dato in i)
                {
                    ClaseMatrizVulnerabilidades clase = new ClaseMatrizVulnerabilidades();

                    clase.IdVulnerabilidad = dato.IdVulnerabilidad;
                    clase.IdEmpresa = dato.IdEmpresa;
                    clase.CodigoUnico = dato.CodigoUnico;
                    clase.CodigoProveedor = dato.CodigoProveedor;
                    clase.CodigoSiTCS = dato.CodigoSiTcs;
                    clase.Proveedor = dato.Proveedor;
                    clase.FechaIdentificacion = Convert.ToDateTime(dato.FechaDeIdentificacion);
                    clase.DocumentoFuente = dato.DocumentoFuente;
                    clase.Aplicacion = dato.Aplicacion;
                    clase.Nivel = dato.Nivel;
                    clase.Activo = dato.ActivoConLaVulnerabilidad;
                    clase.EquipoModulo = dato.EquipoOModulo;
                    clase.TipoVulnerabilidad = dato.TipoVulnerabilidad;
                    clase.Descripcion = dato.Descripcion;
                    clase.Impacto = dato.Impacto;
                    clase.Probabilidad = dato.Probabilidad;
                    clase.Criticidad = dato.Criticidad;
                    clase.Recomendacion = dato.Recomendacion;
                    clase.Estado = dato.Estado;
                    clase.FechaCierre = Convert.ToDateTime(dato.FechaCierre);
                    clase.TipoCierre = dato.TipoDeCierre;
                    clase.CodigoSolucion = dato.CodigoDeSolucion;
                    clase.ResponsableSI = dato.ResponsableSI;

                    Listado.Add(clase);
                }

                return Listado;
            }
        }

        /*Detalle*/
        public int MatrizVulnerabilidades_Detalle_Insert(ClaseMatrizVulnerabilidades_Detalle matrizDetalle)
        {
            int id = 0;

            try
            {
                using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
                {
                    var i = a.MatrizVulnerabilidades_Detalle_Insert(matrizDetalle.IdVulnerabilidad,
                                                                    matrizDetalle.Estado,
                                                                    matrizDetalle.Fecha,
                                                                    matrizDetalle.Accion,
                                                                    matrizDetalle.TipoActividad,
                                                                    matrizDetalle.Evidencia);

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

        public List<ClaseMatrizVulnerabilidades_Detalle> MatrizVulnerabilidades_Detalle_SelectByIdVulnerabilidad(int idVulnerabilidad)
        {
            List<ClaseMatrizVulnerabilidades_Detalle> Listado = new List<ClaseMatrizVulnerabilidades_Detalle>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.MatrizVulnerabilidades_Detalle_SelectByIdVulnerabilidad(idVulnerabilidad);

                foreach (var dato in i)
                {
                    ClaseMatrizVulnerabilidades_Detalle clase = new ClaseMatrizVulnerabilidades_Detalle();

                    clase.Accion = dato.Accion;
                    clase.Estado = dato.Estado;
                    clase.Evidencia = dato.Evidencia;
                    clase.Fecha = Convert.ToDateTime(dato.Fecha);
                    clase.IdVulnerabilidad = dato.IdVulnerabilidad;
                    clase.TipoActividad = dato.TipoActividad;

                    Listado.Add(clase);
                }

                return Listado;
            }
        }

        public List<ClaseMatrizVulnerabilidades_Detalle> MatrizVulnerabilidades_Detalle_SelectByIdVul(int idVulnerabilidad)
        {
            List<ClaseMatrizVulnerabilidades_Detalle> Listado = new List<ClaseMatrizVulnerabilidades_Detalle>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.MatrizVulnerabilidades_Detalle_SelectByIdVul(idVulnerabilidad);

                foreach (var dato in i)
                {
                    ClaseMatrizVulnerabilidades_Detalle clase = new ClaseMatrizVulnerabilidades_Detalle();

                    clase.Accion = dato.Accion;
                    clase.Estado = dato.Estado;
                    clase.Evidencia = dato.Evidencia;
                    clase.Fecha = Convert.ToDateTime(dato.Fecha);
                    clase.IdVulnerabilidad = dato.IdVulnerabilidad;
                    clase.TipoActividad = dato.TipoActividad;

                    Listado.Add(clase);
                }

                return Listado;
            }
        }
    }
}
