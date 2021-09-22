using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LogicaNegocios.Clases;
using AccesoDatos;

namespace LogicaNegocios.Metodos
{
    public class MetodoLogsConexion
    {
        //[dbo].[LogsConexion_Insert]
        public void LogsConexion_Insert(ClaseLogsConexion log)
        {
            try
            {
                using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
                {
                    a.LogsConexion_Insert(log.Accion, log.Autor, log.IpOrigen, log.Formulario);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
