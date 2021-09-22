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
using System.Net;

namespace FrontEnd
{
    public partial class FrmEligeServicio : Form
    {
        string miTipo = "";
        List<ClaseServicios_CertificacionAplicaciones> miListaServicios;
        string ipEquipo = string.Empty;

        public FrmEligeServicio(string Tipo)
        {
            InitializeComponent();
            miTipo = Tipo;
        }

        private void FrmEligeServicio_Load(object sender, EventArgs e)
        {
            LlenarListaBitacoras();

            //InsertarLogConexion
            ipEquipo = string.Empty;
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    ipEquipo = ip.ToString();

                    if (ipEquipo.Substring(0, 2) == "10")
                    {
                        break;
                    }
                }
            }

            ClaseLogsConexion claseLog = new ClaseLogsConexion();
            claseLog.Accion = "Abrió el formulario";
            claseLog.Autor = Environment.UserName;
            claseLog.IpOrigen = ipEquipo;
            claseLog.Formulario = "Elige servicio para consulta";

            MetodoLogsConexion metLog = new MetodoLogsConexion();
            metLog.LogsConexion_Insert(claseLog);

            MetodoGeneral miMetodo = new MetodoGeneral();
            ClaseParametros parametro = new ClaseParametros();
            parametro = miMetodo.Parametros_SelectByCodigo("BBM");
            if (parametro.Valor == "ON")
            {
                MessageBox.Show("La bitácora se encuentra bloqueada por mantenimiento. Por favor contactarse con el administrador para conocer el tiempo de duración del bloqueo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.ExitThread();
            }
        }
        
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

        private void FrmEligeServicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClaseLogsConexion claseLog = new ClaseLogsConexion();
            claseLog.Accion = "Cerró el formulario";
            claseLog.Autor = Environment.UserName;
            claseLog.IpOrigen = ipEquipo;
            claseLog.Formulario = "Elige servicio para consulta";

            MetodoLogsConexion metLog = new MetodoLogsConexion();
            metLog.LogsConexion_Insert(claseLog);
        }
    }
}
