using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AccesoDatos;
using LogicaNegocios.Clases;

namespace LogicaNegocios.Metodos
{
    public class Metodo_HorasExtras
    {
        public void SeguridadInformatica_HorasTrabajadas_Insert(string ultimatix, string dia, DateTime fechaHora)
        {
            try
            {
                using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
                {
                    a.SeguridadInformatica_HorasTrabajadas_Insert(ultimatix, dia, fechaHora);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ClaseHoraExtra> HorasExtras_ByUsuarioAndMes(string responsable, int mes)
        {
            List<ClaseHoraExtra> Listado = new List<ClaseHoraExtra>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.HorasExtras_ByUsuario(responsable, mes);

                foreach (var dato in i)
                {
                    ClaseHoraExtra objeto = new ClaseHoraExtra();

                    objeto.IdRegistro = dato.IdRegistro;
                    objeto.Ultimatix = dato.Ultimatix;
                    objeto.UsuarioRed = dato.UsuarioRed;
                    objeto.NombreCompleto = dato.NombreCompleto;
                    objeto.Supervisor = dato.Supervisor;
                    objeto.Mes = dato.Mes;
                    objeto.Dia = dato.Dia;
                    objeto.FechaHoraInicio = dato.FechaHoraInicio;
                    objeto.FechaHoraFin = dato.FechaHoraFin;
                    objeto.HoraExtra = dato.Extra;
                    objeto.Tiempo = dato.Tiempo;
                    objeto.EsExtra = dato.EsExtra;
                    objeto.HorasAprobadas = dato.HorasAprobadas;
                    objeto.Justificacion = dato.Justificacion;
                    objeto.Aprobada = dato.Aprobada;

                    Listado.Add(objeto);
                }

                return Listado;
            }
        }

        public int HorasExtras_Validar(string validar, int mes)
        { 
            int existe = 0;

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.HorasExtras_ValidarSubirYCalcular(validar, mes);

                foreach (var r in i)
                {
                    existe = Convert.ToInt32(r.ToString());
                }

                return existe;
            }
        }

        public int HorasExtras_Calcular(int mes)
        {
            int existe = 0;

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.HorasExtras_Generar(mes);

                foreach (var r in i)
                {
                    existe = Convert.ToInt32(r.ToString());
                }

                return existe;
            }
        }

        public int HorasExtras_Grabar(List<ClaseHoraExtra> detalle)
        {
            int id = 1;

            try
            {
                using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
                {
                    foreach (ClaseHoraExtra item in detalle)
                    {
                        if (item.InsertUpdate.ToString() == "I")
                        {
                            var i = a.SoloHorasExtras_Insert(item.Ultimatix,
                                                             item.UsuarioRed,
                                                             item.NombreCompleto,
                                                             item.Supervisor,
                                                             item.Mes,
                                                             item.Dia, 
                                                             item.FechaHoraInicio,
                                                             item.FechaHoraFin,
                                                             item.HoraExtra,
                                                             item.Tiempo,
                                                             item.EsExtra,
                                                             item.HorasAprobadas,
                                                             item.Justificacion,
                                                             item.Aprobada);
                        }
                        else
                        {
                            var i = a.SoloHorasExtras_Update(item.IdRegistro,
                                                             item.EsExtra,
                                                             item.HorasAprobadas,
                                                             item.Justificacion);
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

    }
}
