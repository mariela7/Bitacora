using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;

namespace LogicaNegocios.Metodos
{
    public class MetodoConocimiento
    {
        public List<Clases.ClaseConocimientoCategoria> GetCategorias()
        {
            List<Clases.ClaseConocimientoCategoria> miLista = new List<Clases.ClaseConocimientoCategoria>();
            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Conocimiento_CategoriasLIsta();

                foreach (var item in i)
                {
                    Clases.ClaseConocimientoCategoria miClase = new Clases.ClaseConocimientoCategoria();
                    miClase.Id = item.Id;
                    miClase.Nombre = item.Nombre;
                    miLista.Add(miClase);
                }
            }

            return miLista;

        }

        public List<Clases.ClaseConocimientoCabecera> GetCabeceras(int IdCat)
        {
            List<Clases.ClaseConocimientoCabecera> miLista = new List<Clases.ClaseConocimientoCabecera>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Conocimiento_CabeceraLIsta(IdCat);

                foreach (var item in i)
                {
                    Clases.ClaseConocimientoCabecera miClase = new Clases.ClaseConocimientoCabecera();
                    miClase.Id = item.Id;
                    miClase.Nombre = item.Nombre;
                    miClase.IdCab = item.IdCat;
                    miLista.Add(miClase);
                }

                return miLista;
            }
        }

        public Clases.ClaseConocimientoDetalle GetDetalle(int IdCab)
        {
            Clases.ClaseConocimientoDetalle miClase = new Clases.ClaseConocimientoDetalle();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Conocimiento_DetalleSelect(IdCab).FirstOrDefault();

                miClase.IdCab = i.IdCab;
                miClase.Texto = i.Texto;
                miClase.Observaciones = i.Observaciones;
                miClase.responsable = i.Responsable;
                miClase.FechaIngreso = i.FechaIngreso;
                
            }

            return miClase;

        }

        public void SaveDetalle(Clases.ClaseConocimientoCabecera Cabecera, Clases.ClaseConocimientoDetalle Detalle)
        {
            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Conocimiento_DetalleInsert(Cabecera.IdCab, Cabecera.Nombre, Detalle.Texto, Detalle.Observaciones, Detalle.responsable);
            }

        }

        public void UpdateDetalle(Clases.ClaseConocimientoCabecera Cabecera, Clases.ClaseConocimientoDetalle Detalle)
        {
            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Conocimiento_DetalleUpdate(Cabecera.Id, Cabecera.IdCab, Cabecera.Nombre, Detalle.Texto, Detalle.Observaciones, Detalle.responsable);
            }

        }

        public void UpdateCategoria(Clases.ClaseConocimientoCategoria Categoria)
        {
            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Conocimiento_CategoriasUpdate(Categoria.Id, Categoria.Nombre);
            }

        }

        public void InsertCategoria(Clases.ClaseConocimientoCategoria Categoria)
        {
            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Conocimiento_CategoriasInsert(Categoria.Nombre);
            }

        }



    }
}
