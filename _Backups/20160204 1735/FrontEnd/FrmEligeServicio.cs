using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LogicaNegocios.Metodos;
using LogicaNegocios.Clases;

namespace FrontEnd
{
    public partial class FrmEligeServicio : Form
    {

        string miTipo = "";

        public FrmEligeServicio(string Tipo)
        {
            InitializeComponent();
            miTipo = Tipo;
        }

        private void FrmEligeServicio_Load(object sender, EventArgs e)
        {
            LlenarListaBitacoras();
        }


        List<ClaseServicios_CertificacionAplicaciones> miListaServicios;


        private void LlenarListaBitacoras()
        {
            //Traer Lista
            miListaServicios = new List<ClaseServicios_CertificacionAplicaciones>();
            MetodoBitacora_CertificacionAplicaciones miMetodo = new MetodoBitacora_CertificacionAplicaciones();
            miListaServicios = miMetodo.Bitacora_CertificacionApp_SelectServicios();
            this.dgServicios.Rows.Clear();

            foreach (var item in miListaServicios)
            {
                this.dgServicios.Rows.Add(item.IdServicio, item.Nombre);
            }
        }

        private void dgServicios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (miTipo == "Consulta")
                    {
                         FrmBitacoraConsulta mifrm = new FrmBitacoraConsulta();
                    mifrm.MdiParent = this.MdiParent;
                    mifrm.ValorId = Convert.ToInt32( this.dgServicios[0, e.RowIndex].Value.ToString());
                    mifrm.ValorNombre = this.dgServicios[1, e.RowIndex].Value.ToString();
                    mifrm.Show();
                    }
                    if (miTipo == "Reporte")
                    {
                        FrmBitacoraReporte mifrm = new FrmBitacoraReporte();
                        mifrm.MdiParent = this.MdiParent;
                        mifrm.ValorId = Convert.ToInt32(this.dgServicios[0, e.RowIndex].Value.ToString());
                        mifrm.ValorNombre = this.dgServicios[1, e.RowIndex].Value.ToString();
                        mifrm.Show();
                    }
                   
                    
                    this.Close();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

    }
}
