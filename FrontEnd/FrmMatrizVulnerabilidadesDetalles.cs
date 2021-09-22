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
    public partial class FrmMatrizVulnerabilidadesDetalles : Form
    {
        public FrmMatrizVulnerabilidadesDetalles()
        {
            InitializeComponent();
        }

        public int idVulnerabilidad;
        string ipEquipo = string.Empty;

        private void FrmMatrizVulnerabilidadesDetalles_Load(object sender, EventArgs e)
        {
            dgvMatrizDetalle.Rows.Clear();

            List<ClaseMatrizVulnerabilidades_Detalle> lstDetalle = new List<ClaseMatrizVulnerabilidades_Detalle>();
            MetodoMatrizVulnerabilidades mtMatriz = new MetodoMatrizVulnerabilidades();

            lstDetalle = mtMatriz.MatrizVulnerabilidades_Detalle_SelectByIdVul(idVulnerabilidad);

            foreach (ClaseMatrizVulnerabilidades_Detalle fila in lstDetalle)
            {
                dgvMatrizDetalle.Rows.Add();

                dgvMatrizDetalle.Rows[dgvMatrizDetalle.Rows.Count - 1].Cells["dgAccion"].Value = fila.Accion;
                dgvMatrizDetalle.Rows[dgvMatrizDetalle.Rows.Count - 1].Cells["dgActividad"].Value = fila.TipoActividad;
                dgvMatrizDetalle.Rows[dgvMatrizDetalle.Rows.Count - 1].Cells["dgEstado"].Value = fila.Estado;
                dgvMatrizDetalle.Rows[dgvMatrizDetalle.Rows.Count - 1].Cells["dgEvidencia"].Value = fila.Evidencia;
                dgvMatrizDetalle.Rows[dgvMatrizDetalle.Rows.Count - 1].Cells["dgFecha"].Value = fila.Fecha;
            }

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
            claseLog.Formulario = "Matriz Vulnerabilidades - Detalles";

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

        private void FrmMatrizVulnerabilidadesDetalles_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClaseLogsConexion claseLog = new ClaseLogsConexion();
            claseLog.Accion = "Cerró el formulario";
            claseLog.Autor = Environment.UserName;
            claseLog.IpOrigen = ipEquipo;
            claseLog.Formulario = "Matriz Vulnerabilidades - Detalles";

            MetodoLogsConexion metLog = new MetodoLogsConexion();
            metLog.LogsConexion_Insert(claseLog);
        }
    }
}
