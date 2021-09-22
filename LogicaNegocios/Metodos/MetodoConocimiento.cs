using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AccesoDatos;
using LogicaNegocios.Clases;

namespace LogicaNegocios.Metodos
{
    public class MetodoConocimiento
    {
        public List<ClaseConocimientoCategoria> GetCategorias()
        {
            List<ClaseConocimientoCategoria> miLista = new List<ClaseConocimientoCategoria>();
            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Conocimiento_CategoriasLIsta();

                foreach (var item in i)
                {
                    ClaseConocimientoCategoria miClase = new ClaseConocimientoCategoria();
                    miClase.Id = item.Id;
                    miClase.Nombre = item.Nombre;
                    miLista.Add(miClase);
                }
            }

            return miLista;

        }

        public List<ClaseConocimientoCabecera> GetCabeceras(int IdCat)
        {
            List<ClaseConocimientoCabecera> miLista = new List<ClaseConocimientoCabecera>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Conocimiento_CabeceraLIsta(IdCat);

                foreach (var item in i)
                {
                    ClaseConocimientoCabecera miClase = new ClaseConocimientoCabecera();
                    miClase.Id = item.Id;
                    miClase.Nombre = item.Nombre;
                    miClase.IdCab = item.IdCat;
                    miLista.Add(miClase);
                }

                return miLista;
            }
        }

        public ClaseConocimientoDetalle GetDetalle(int IdCab)
        {
            ClaseConocimientoDetalle miClase = new ClaseConocimientoDetalle();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Conocimiento_DetalleSelect(IdCab).FirstOrDefault();

                miClase.IdCab = i.IdCab;
                miClase.Texto = i.Texto;
                miClase.Observaciones = i.Observaciones;
                miClase.responsable = i.Responsable;
                miClase.FechaIngreso = i.FechaIngreso;
                miClase.FechaActualizacion = i.FechaActualizacion;
            }

            return miClase;
        }

        public void SaveDetalle(ClaseConocimientoCabecera Cabecera, ClaseConocimientoDetalle Detalle)
        {
            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Conocimiento_DetalleInsert(Cabecera.IdCab, Cabecera.Nombre, Detalle.Texto, Detalle.Observaciones, Detalle.responsable);
            }

        }

        public void UpdateDetalle(ClaseConocimientoCabecera Cabecera, ClaseConocimientoDetalle Detalle)
        {
            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Conocimiento_DetalleUpdate(Cabecera.Id, Cabecera.IdCab, Cabecera.Nombre, Detalle.Texto, Detalle.Observaciones, Detalle.responsable);
            }

        }

        public void UpdateCategoria(ClaseConocimientoCategoria Categoria)
        {
            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Conocimiento_CategoriasUpdate(Categoria.Id, Categoria.Nombre);
            }

        }

        public void InsertCategoria(ClaseConocimientoCategoria Categoria)
        {
            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Conocimiento_CategoriasInsert(Categoria.Nombre);
            }

        }
    }
}
