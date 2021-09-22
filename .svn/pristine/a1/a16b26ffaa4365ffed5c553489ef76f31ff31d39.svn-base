using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;

namespace LogicaNegocios.Metodos
{
    public class MetodoGeneral
    {
        public List<int> ObtenerAnos()
        {
            List<int> Listado = new List<int>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.ObtenerAno();

                foreach (var dato in i)
                {
                    int ano;

                    ano = dato.Value;                    

                    Listado.Add(ano);
                }

                return Listado;
            }
        }
        
        public List<string> GetAutorizados()
        {
            List<string> miLista = new List<string>();

            using (BD_SeguridadInformaticaEntities a = new BD_SeguridadInformaticaEntities())
            {
                var i = a.Autorizados_List();

                foreach (var dato in i)
                {
                    miLista.Add(dato);
                }

                return miLista;
            }
        
        }

    }
}
