using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net;
using LogicaNegocios.Clases;
using LogicaNegocios.Metodos;
using System.IO;
using System.DirectoryServices;



namespace FrontEnd
{
    public partial class FrmHorasIngresadas : Form
    {
        public FrmHorasIngresadas()
        {
            InitializeComponent();
        }

        MetodoGeneral metGeneral = new MetodoGeneral();

        List<int> ListaAnos = new List<int>();
        string ipEquipo = string.Empty;
        string mes = string.Empty;

        private void FrmHorasIngresadas_Load(object sender, EventArgs e)
        {
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

        private void btnCargarDatos_Click(object sender, EventArgs e)
        {
            dgvHorasIngresadas.Rows.Clear();

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

            List<ClaseHoraIngresada> lista = new List<ClaseHoraIngresada>();

            lista = metGeneral.ReporteHorasIngresadas(mes, Convert.ToInt32(ddlAno.Text));

            //LLENAR COLUMNAS
           
            dgvHorasIngresadas.Columns.Clear();

            List<string> listaColumnas = new List<string>();
            listaColumnas = lista.Select(x => x.Empresa).Distinct().ToList().OrderBy(a => a).ToList();

            this.dgvHorasIngresadas.Columns.Add("dgResponsable", "Responsable");
            this.dgvHorasIngresadas.Columns.Add("dgNombreCompleto", "Nombre Completo");

            foreach (var item in listaColumnas)
            {
                DataGridViewTextBoxColumn miColumna = new DataGridViewTextBoxColumn();
                miColumna.Name = "dg" + LimpiarNombreColumna(item.ToString());
                miColumna.HeaderText = item.ToString();
                this.dgvHorasIngresadas.Columns.Add(miColumna);
                dgvHorasIngresadas.Columns[miColumna.Name].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            this.dgvHorasIngresadas.Columns.Add("dgTotal", "Total Horas");
            dgvHorasIngresadas.Columns["dgTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHorasIngresadas.Columns["dgTotal"].DefaultCellStyle.Font = new Font(Font, System.Drawing.FontStyle.Bold);
            
            List<string> listaPersona = new List<string>();
            listaPersona = lista.Select(x => x.Responsable).Distinct().ToList();

            foreach (var item in listaPersona)
            {
                dgvHorasIngresadas.Rows.Add();
                dgvHorasIngresadas.Rows[dgvHorasIngresadas.Rows.Count - 1].Cells["dgResponsable"].Value = item;
                dgvHorasIngresadas.Rows[dgvHorasIngresadas.Rows.Count - 1].Cells["dgNombreCompleto"].Value = GetFullName(item).ToUpper();
            }

            dgvHorasIngresadas.Rows.Add();
            dgvHorasIngresadas.Rows[dgvHorasIngresadas.Rows.Count - 1].Cells["dgResponsable"].Value = "Total por Empresa";
            dgvHorasIngresadas.Rows[dgvHorasIngresadas.Rows.Count - 1].Cells["dgResponsable"].Style.Font = new Font(Font, System.Drawing.FontStyle.Bold);

            foreach (var item in lista)
            {
                int fila = -1;

                foreach (DataGridViewRow row in dgvHorasIngresadas.Rows)
                {
                    //compararString(dgvHorasIngresadas.Rows[row.Index].Cells["dgResponsable"].Value.ToString(), item.Responsable.ToString())
                    if (compararString(dgvHorasIngresadas.Rows[row.Index].Cells["dgResponsable"].Value.ToString(), item.Responsable.ToString()))
                    {
                        fila = row.Index;
                        break;
                    }
                }

                string columnName = string.Empty;

                int totColumn = dgvHorasIngresadas.Columns.Count - 2;

                for (int i = 2; i <= totColumn; i++)
                {
                    //compararString(dgvHorasIngresadas.Columns[i].Name.ToString(), ("dg" + LimpiarNombreColumna(item.Empresa.ToString()))
                    if (compararString(dgvHorasIngresadas.Columns[i].Name.ToString(), ("dg" + LimpiarNombreColumna(item.Empresa.ToString()))))
                    {
                        columnName = dgvHorasIngresadas.Columns[i].Name;
                        break;
                    }
                }

                if ((fila >= 0) && (string.IsNullOrEmpty(columnName) == false))
                {
                    dgvHorasIngresadas.Rows[fila].Cells[columnName].Value = Convert.ToDecimal(dgvHorasIngresadas.Rows[fila].Cells[columnName].Value) + Convert.ToDecimal(item.Esfuerzo);
                    //TOTAL FILAS
                    dgvHorasIngresadas.Rows[fila].Cells["dgTotal"].Value = Convert.ToDecimal(dgvHorasIngresadas.Rows[fila].Cells["dgTotal"].Value) + Convert.ToDecimal(item.Esfuerzo);
                    //TOTAL COLUMNAS
                    dgvHorasIngresadas.Rows[dgvHorasIngresadas.Rows.Count - 1].Cells[columnName].Value = Convert.ToDecimal(dgvHorasIngresadas.Rows[dgvHorasIngresadas.Rows.Count - 1].Cells[columnName].Value) + Convert.ToDecimal(item.Esfuerzo);
                    dgvHorasIngresadas.Rows[dgvHorasIngresadas.Rows.Count - 1].Cells[columnName].Style.Font = new Font(Font, System.Drawing.FontStyle.Bold);

                }
            }

            dgvHorasIngresadas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            double total = 0;

            foreach (DataGridViewRow row in dgvHorasIngresadas.Rows)
            {
                total = total + Convert.ToDouble(dgvHorasIngresadas.Rows[row.Index].Cells["dgTotal"].Value);
            }

            dgvHorasIngresadas.Rows[dgvHorasIngresadas.Rows.Count - 1].Cells["dgTotal"].Value = total.ToString();
            dgvHorasIngresadas.Rows[dgvHorasIngresadas.Rows.Count - 1].Cells["dgTotal"].Style.Font = new Font(Font, System.Drawing.FontStyle.Bold);
            
            foreach (DataGridViewColumn column in dgvHorasIngresadas.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            //foreach (DataGridViewRow rw in this.dgvHorasIngresadas.Rows)
            //{
            //    for (int i = 1; i < rw.Cells.Count; i++)
            //    {
            //        if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
            //        {
            //            // here is your message box...
            //            dgvHorasIngresadas.Rows[rw.Index].Cells[i].Value = 0;
            //        }
            //    } 
            //}
        }

        public string LimpiarNombreColumna(string colu)
        {
            string nombreC = colu.Replace(" ", "");
            nombreC = nombreC.Replace("á", "a");
            nombreC = nombreC.Replace("é", "e");
            nombreC = nombreC.Replace("í", "i");
            nombreC = nombreC.Replace("ó", "o");
            nombreC = nombreC.Replace("ú", "u");
            nombreC = nombreC.Replace("-", "_");

            return nombreC;
        }

        public bool compararString(string palabraUno, string palabraDos)
        {
            if (palabraUno == palabraDos)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvHorasIngresadas.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Documents (*.xls)|*.xls";
                sfd.FileName = this.ddlAno.Text.ToString() + " - " + this.ddlMes.Text.ToString() + " - " + "Asignacion.xls";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //ToCsV(dataGridView1, @"c:\export.xls");
                    ToCsV(dgvHorasIngresadas, sfd.FileName); // Here dataGridview1 is your grid view name

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
                char Comilla = Convert.ToChar('"');
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                {
                    string contenido = string.Empty;
                    if (dGV.Rows[i].Cells[j].Value == null || dGV.Rows[i].Cells[j].Value == DBNull.Value || String.IsNullOrWhiteSpace(dGV.Rows[i].Cells[j].Value.ToString()))
                    {
                        contenido = "0";
                    }
                    else
                    {
                        contenido = dGV.Rows[i].Cells[j].Value.ToString();
                    }
                    stLine = stLine.ToString() + Convert.ToString(contenido.Trim().Replace(Environment.NewLine, "").Replace(Comilla.ToString(), "")) + "\t";
                }
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

        private static string GetFullName(string user)
        {
            try
            {
                DirectoryEntry de = new DirectoryEntry("WinNT://" + Environment.UserDomainName + "/" + user);
                return de.Properties["fullName"].Value.ToString();
            }
            catch { return ""; }
        }

    }
}
