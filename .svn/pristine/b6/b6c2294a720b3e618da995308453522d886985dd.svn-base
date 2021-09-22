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
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace FrontEnd
{
    public partial class FrmFacturacion : Form
    {
        //private static FrmFacturacion m_FormDefInstance;
        //public static FrmFacturacion DefInstance
        //{
        //    get
        //    {
        //        if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
        //        {
        //            m_FormDefInstance = new FrmFacturacion();
        //        }
        //        else
        //        {
        //            m_FormDefInstance.BringToFront();
        //        }
        //        return m_FormDefInstance;
        //    }
        //    set
        //    {
        //        m_FormDefInstance = value;
        //    }
        //}

        public FrmFacturacion()
        {
            InitializeComponent();
        }

        MetodoEmpresas_IngenieriaSeguridad metEmpresa = new MetodoEmpresas_IngenieriaSeguridad();
        MetodoGeneral metGeneral = new MetodoGeneral();

        List<ClaseEmpresas_IngenieriaSeguridad> ListaEmpresas = new List<ClaseEmpresas_IngenieriaSeguridad>();
        List<int> ListaAnos = new List<int>();
        string mes = string.Empty;
        string ipEquipo = string.Empty;

        private void FrmFacturacion_Load(object sender, EventArgs e)
        {
            ListaEmpresas = metEmpresa.Empresas_IngenieriaSeguridad_SelectAll();

            ClaseEmpresas_IngenieriaSeguridad empresaTodas = new ClaseEmpresas_IngenieriaSeguridad();
            empresaTodas.IdEmpresa = 0;
            empresaTodas.NombreEmpresa = "Todas";

            ListaEmpresas.Add(empresaTodas);

            ListaEmpresas = ListaEmpresas.OrderBy(x => x.NombreEmpresa).ToList();
            ddlEmpresa.DataSource = ListaEmpresas;
            ddlEmpresa.ValueMember = "IdEmpresa";
            ddlEmpresa.DisplayMember = "NombreEmpresa";

            ListaAnos = metGeneral.ObtenerAnos();
            ddlAno.DataSource = ListaAnos;
            LlenarMeses();

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
            claseLog.Formulario = "Facturación";

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

        private void LlenarMeses()
        {
            DataTable miTablaMeses = new DataTable("miTabla");
            miTablaMeses.Columns.Add("Id");
            miTablaMeses.Columns.Add("Nombre");
            for (int i = 1; i <= 12; i++)
            {
                miTablaMeses.Rows.Add(i, System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i).ToUpper());
            }
            this.ddlMes.DataSource = miTablaMeses;
            this.ddlMes.ValueMember = "Id";
            this.ddlMes.DisplayMember = "Nombre";

            this.ddlMes.SelectedValue = DateTime.Now.Month;
            this.ddlAno.SelectedItem = DateTime.Now.Year;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            DataGridView grd = new DataGridView();
            grd = dgvFacturacion;

            if (grd.Rows.Count > 0)
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.FileName = this.ddlAno.Text.ToString() + "-" + mes + "-" + this.ddlMes.Text.ToString() + " - " + this.ddlEmpresa.Text.ToString() + " - Reporte Facturacion.xls";

                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    string destino = string.Empty;

                    if (fichero.FileName != "")
                    {
                        destino = fichero.FileName;
                    }

                    //Especificar la ruta y nombre con el que se guardará el archivo
                    string filenam3 = destino;

                    ToCsV(dgvFacturacion, filenam3);

                    MessageBox.Show("El reporte fue generado exitosamente.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }
        
        private void btnCargarDatos_Click(object sender, EventArgs e)
        {
            dgvFacturacion.Rows.Clear();

            switch (ddlMes.Text)
            {
                case "ENERO":
                    mes = "01";
                    break;
                case "FEBRERO":
                    mes = "02";
                    break;
                case "MARZO":
                    mes = "03";
                    break;
                case "ABRIL":
                    mes = "04";
                    break;
                case "MAYO":
                    mes = "05";
                    break;
                case "JUNIO":
                    mes = "06";
                    break;
                case "JULIO":
                    mes = "07";
                    break;
                case "AGOSTO":
                    mes = "08";
                    break;
                case "SEPTIEMBRE":
                    mes = "09";
                    break;
                case "OCTUBRE":
                    mes = "10";
                    break;
                case "NOVIEMBRE":
                    mes = "11";
                    break;
                default:
                    mes = "12";
                    break;
            }

            List<ClaseFacturacion> lista = new List<ClaseFacturacion>();

            lista = metGeneral.ReporteFacturacionByMes(mes, Convert.ToInt32(ddlAno.Text), Convert.ToInt32(((LogicaNegocios.Clases.ClaseEmpresas_IngenieriaSeguridad)(ddlEmpresa.SelectedItem)).IdEmpresa), ((LogicaNegocios.Clases.ClaseEmpresas_IngenieriaSeguridad)(ddlEmpresa.SelectedItem)).NombreEmpresa);

            
            foreach (var item in lista)
            {
                dgvFacturacion.Rows.Add();
                dgvFacturacion.Rows[dgvFacturacion.Rows.Count - 1].Cells["cEmpresa"].Value = item.Empresa;
                dgvFacturacion.Rows[dgvFacturacion.Rows.Count - 1].Cells["cMes"].Value = ddlMes.Text.Substring(0,3);
                dgvFacturacion.Rows[dgvFacturacion.Rows.Count - 1].Cells["cFechaInicio"].Value = item.FechaInicio.ToShortDateString();
                dgvFacturacion.Rows[dgvFacturacion.Rows.Count - 1].Cells["cFechaFin"].Value = item.FechaFin.ToShortDateString();
                dgvFacturacion.Rows[dgvFacturacion.Rows.Count - 1].Cells["cServicio"].Value = item.Servicio;
                dgvFacturacion.Rows[dgvFacturacion.Rows.Count - 1].Cells["cTarea"].Value = item.Tarea;
                dgvFacturacion.Rows[dgvFacturacion.Rows.Count - 1].Cells["cResponsable"].Value = item.Responsable;
                if (item.Evidencia == null)
                {
                    dgvFacturacion.Rows[dgvFacturacion.Rows.Count - 1].Cells["cEvidencia"].Value = item.Evidencia;
                }
                else
                {
                    dgvFacturacion.Rows[dgvFacturacion.Rows.Count - 1].Cells["cEvidencia"].Value = Regex.Replace(item.Evidencia, @"\t|\n|\r", " ");
                }
                dgvFacturacion.Rows[dgvFacturacion.Rows.Count - 1].Cells["cEsfuerzo"].Value = Math.Round(item.Horas, 2);
            }
            
            dgvFacturacion.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void FrmFacturacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClaseLogsConexion claseLog = new ClaseLogsConexion();
            claseLog.Accion = "Cerró el formulario";
            claseLog.Autor = Environment.UserName;
            claseLog.IpOrigen = ipEquipo;
            claseLog.Formulario = "Facturación";

            MetodoLogsConexion metLog = new MetodoLogsConexion();
            metLog.LogsConexion_Insert(claseLog);
        }
    }
}
