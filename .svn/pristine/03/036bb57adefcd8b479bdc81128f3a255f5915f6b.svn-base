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
using System.IO;

namespace FrontEnd
{
    public partial class FrmBusquedaBitacora_IS : Form
    {
        MetodoCategorias_IngenieriaSeguridad metCategoria = new MetodoCategorias_IngenieriaSeguridad();
        MetodoEmpresas_IngenieriaSeguridad metEmpresa = new MetodoEmpresas_IngenieriaSeguridad();
        MetodoServicios_IngenieriaSeguridad metServicio = new MetodoServicios_IngenieriaSeguridad();
        MetodoGeneral metGeneral = new MetodoGeneral();

        List<ClaseCategorias_IngenieriaSeguridad> ListaServicios = new List<ClaseCategorias_IngenieriaSeguridad>();
        List<ClaseEmpresas_IngenieriaSeguridad> ListaEmpresas = new List<ClaseEmpresas_IngenieriaSeguridad>();
        List<int> ListaAnos = new List<int>();

        public int IdRegistro;
        public int IdServicio;
        public int IdCategoria;

        string UsuarioConectado = Environment.UserName;

        public FrmBusquedaBitacora_IS()
        {
            InitializeComponent();
        }

        private void FrmBusquedaBitacora_IS_Load(object sender, EventArgs e)
        {
            chkTodos.Checked = false;
            chkMes.Checked = false;
            chkAno.Checked = false;
            chkHoraExtra.Checked = false;
            chkEmpresa.Checked = false;
            chkServicio.Checked = false;
            chkFechaInicio.Checked = false;
            chkfechafin.Checked = false;

            ddlMes.Visible = false;
            ddlAno.Visible = false;
            ddlHorasExtras.Visible = false;
            ddlEmpresa.Visible = false;
            ddlCategoria.Visible = false;
            dtpFechaInicio.Visible = false;
            dtpFechaFin.Visible = false;

            dgvBitacora.Rows.Clear();

            dgvBitacora.Location = new Point(0, 134);
            int tamanoFRM = this.Size.Height;
            int tamanoGrid = dgvBitacora.Size.Width;
            dgvBitacora.Size = new Size(tamanoGrid, tamanoFRM - 215);

            ListaServicios = metCategoria.Categorias_IngenieriaSeguridad_SelectAll();
            ListaServicios = ListaServicios.OrderBy(x => x.DescripcionCategoria).ToList();
            ddlCategoria.DataSource = ListaServicios;
            ddlCategoria.ValueMember = "IdCategoria";
            ddlCategoria.DisplayMember = "DescripcionCategoria";


            ListaEmpresas = metEmpresa.Empresas_IngenieriaSeguridad_SelectAll();
            ListaEmpresas = ListaEmpresas.OrderBy(x => x.NombreEmpresa).ToList();
            ddlEmpresa.DataSource = ListaEmpresas;
            ddlEmpresa.ValueMember = "IdEmpresa";
            ddlEmpresa.DisplayMember = "NombreEmpresa";


            //List<string> ListaMeses = new List<string>();
            //ListaMeses.Add("ENERO");
            //ListaMeses.Add("FEBRERO");
            //ListaMeses.Add("MARZO");
            //ListaMeses.Add("ABRIL");
            //ListaMeses.Add("MAYO");
            //ListaMeses.Add("JUNIO");
            //ListaMeses.Add("JULIO");
            //ListaMeses.Add("AGOSTO");
            //ListaMeses.Add("SEPTIEMBRE");
            //ListaMeses.Add("OCTUBRE");
            //ListaMeses.Add("NOVIEMBRE");
            //ListaMeses.Add("DICIEMBRE");

            //ddlMes.DataSource = ListaMeses;

            //ListaAnos = metGeneral.ObtenerAnos();
            //ddlAno.DataSource = ListaAnos;

            LlenarMeses();

            List<string> ListaTipoHora = new List<string>();
            ListaTipoHora.Add("SI");
            ListaTipoHora.Add("NO");
            ddlHorasExtras.DataSource = ListaTipoHora;

            //InsertarLogConexion
            string ipEquipo = string.Empty;
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
            claseLog.Formulario = "Reporte individual";

            MetodoLogsConexion metLog = new MetodoLogsConexion();
            metLog.LogsConexion_Insert(claseLog);
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


            for (int i = 2014; i <= DateTime.Now.Year; i++)
            {
                this.ddlAno.Items.Add(i);
            }
            this.ddlMes.SelectedValue = DateTime.Now.Month;
            this.ddlAno.SelectedItem = DateTime.Now.Year;

        }

        private void btnCargarDatos_Click(object sender, EventArgs e)
        {
            int? idServicio = null;
            string responsable = null;
            string mes = null;
            DateTime? fechaInicio = null;
            DateTime? fechaFin = null;
            int? empresa = null;
            int? ano = null;
            bool? extra = null;

            MetodoBitacora_IngenieriaSeguridad metBitacora = new MetodoBitacora_IngenieriaSeguridad();
            List<ClaseBitacora_IngenieriaSeguridad> listBitacora = new List<ClaseBitacora_IngenieriaSeguridad>();

            responsable =  UsuarioConectado;

            if ((chkTodos.Checked == false) && (chkMes.Checked == false) && (chkAno.Checked == false) 
                && (chkHoraExtra.Checked == false) && (chkEmpresa.Checked == false) && (chkServicio.Checked == false)
                && (chkFechaInicio.Checked == false) && (chkfechafin.Checked == false))
            {
                //NO HAY NADA SELECCIONADO
                MessageBox.Show("No existe ningún filtro seleccionado.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (chkTodos.Checked)
            {
                idServicio = null;
                responsable = null;
                mes = null;
                fechaInicio = null;
                fechaFin = null;
                empresa = null;
                ano = null;
                extra = null;
            }

            if (chkEmpresa.Checked)
            {
                empresa = Convert.ToInt32(((LogicaNegocios.Clases.ClaseEmpresas_IngenieriaSeguridad)(ddlEmpresa.SelectedItem)).IdEmpresa);
            }

            if (chkMes.Checked)
            {
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
            }

            if (chkServicio.Checked)
            {
                idServicio = Convert.ToInt32(((LogicaNegocios.Clases.ClaseCategorias_IngenieriaSeguridad)(ddlCategoria.SelectedItem)).IdCategoria);
            }

            if (chkAno.Checked)
            {
                ano = Convert.ToInt32(ddlAno.Text);
            }

            if (chkHoraExtra.Checked)
            {
                switch (ddlHorasExtras.Text)
                {
                    case "SI":
                        extra = Convert.ToBoolean(1);
                        break;
                    default:
                        extra = Convert.ToBoolean(0);
                        break;
                }
            }

            if (chkFechaInicio.Checked)
            {
                fechaInicio = Convert.ToDateTime(dtpFechaInicio.Value.ToShortDateString());
                //2014-11-17 00:00:00.000
            }

            if (chkfechafin.Checked)
            {
                fechaFin = Convert.ToDateTime(dtpFechaFin.Value.ToShortDateString());
            }

            dgvBitacora.Rows.Clear();

            listBitacora = metBitacora.Bitacora_IngenieriaSeguridad_SelectVariosFiltros(idServicio, responsable, mes, fechaInicio, fechaFin, empresa, ano, extra);

            foreach (var item in listBitacora)
            {
                ClaseCategorias_IngenieriaSeguridad clsCategoria = new ClaseCategorias_IngenieriaSeguridad();
                clsCategoria = metCategoria.Categorias_IngenieriaSeguridad_SelectByIdCategoria(item.IdCategoria);

                ClaseEmpresas_IngenieriaSeguridad clsEmpresa = new ClaseEmpresas_IngenieriaSeguridad();
                clsEmpresa = metEmpresa.Empresas_IngenieriaSeguridad_SelectByIdEmpresa(item.IdEmpresa);

                ClaseServicios_IngenieriaSeguridad clsServicio = new ClaseServicios_IngenieriaSeguridad();
                clsServicio = metServicio.Servicios_IngenieriaSeguridad_SelectById(clsCategoria.IdServicio);

                dgvBitacora.Rows.Add();
                dgvBitacora.Rows[dgvBitacora.Rows.Count - 1].Cells["dgIdRegistro"].Value = item.IdRegistro.ToString();
                if (clsCategoria.EstaActivo == false)
                {
                    dgvBitacora.Rows[dgvBitacora.Rows.Count - 1].Cells["dgIdServicio"].Value = 0;
                    dgvBitacora.Rows[dgvBitacora.Rows.Count - 1].Cells["dgServicio"].Value = "HISTORICO";
                }
                else
                {
                    dgvBitacora.Rows[dgvBitacora.Rows.Count - 1].Cells["dgIdServicio"].Value = clsServicio.IdServicio.ToString();
                    dgvBitacora.Rows[dgvBitacora.Rows.Count - 1].Cells["dgServicio"].Value = clsServicio.NombreServicio.ToString();
                }
                dgvBitacora.Rows[dgvBitacora.Rows.Count - 1].Cells["dgIdCategoria"].Value = clsCategoria.IdCategoria.ToString();
                dgvBitacora.Rows[dgvBitacora.Rows.Count - 1].Cells["dgCategoria"].Value = clsCategoria.DescripcionCategoria.ToString();
                dgvBitacora.Rows[dgvBitacora.Rows.Count - 1].Cells["dgEmpresa"].Value = clsEmpresa.NombreEmpresa.ToString();
                dgvBitacora.Rows[dgvBitacora.Rows.Count - 1].Cells["dgFechaInicio"].Value = item.FechaInicio.ToShortDateString();
                dgvBitacora.Rows[dgvBitacora.Rows.Count - 1].Cells["dgFechaFin"].Value = item.FechaFin.ToShortDateString();
                dgvBitacora.Rows[dgvBitacora.Rows.Count - 1].Cells["dgTarea"].Value = item.Tarea.ToString();
                dgvBitacora.Rows[dgvBitacora.Rows.Count - 1].Cells["dgFrecuencia"].Value = item.Frecuencia.ToString();
                dgvBitacora.Rows[dgvBitacora.Rows.Count - 1].Cells["dgEvidencia"].Value = item.Evidencia.ToString();
                dgvBitacora.Rows[dgvBitacora.Rows.Count - 1].Cells["dgEsfuerzo"].Value = item.Esfuerzo.ToString();
            }

            double total = 0;
            foreach (DataGridViewRow row in dgvBitacora.Rows)
            {
                total = total + Convert.ToDouble(dgvBitacora.Rows[row.Index].Cells["dgEsfuerzo"].Value);
            }

            txtTotalHoras.Text = total.ToString();
        }

        private void FrmBusquedaBitacora_IS_Resize(object sender, EventArgs e)
        {
            dgvBitacora.Location = new Point(0, 134);
            int tamanoFRM = this.Size.Height;
            int tamanoGrid = dgvBitacora.Size.Width;
            dgvBitacora.Size = new Size(tamanoGrid, tamanoFRM - 215);
        }

        private void dgvBitacora_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DateTime fechaInicio = Convert.ToDateTime(dgvBitacora.Rows[dgvBitacora.CurrentRow.Index].Cells["dgFechaInicio"].Value);

            DateTime fechaTope = Convert.ToDateTime("01/" + DateTime.Now.AddMonths(-1).Month.ToString().PadLeft(2,'0').ToString() + "/" + DateTime.Now.AddMonths(-1).Year.ToString());

            if (fechaInicio < fechaTope)
            {
                MessageBox.Show("No se puede editar datos anteriores.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else 
            {
                IdRegistro = Convert.ToInt32(dgvBitacora.Rows[dgvBitacora.CurrentRow.Index].Cells["dgIdRegistro"].Value);
                IdCategoria = Convert.ToInt32(dgvBitacora.Rows[dgvBitacora.CurrentRow.Index].Cells["dgIdCategoria"].Value);
                IdServicio = Convert.ToInt32(dgvBitacora.Rows[dgvBitacora.CurrentRow.Index].Cells["dgIdServicio"].Value);
                this.Close();
            }
        }

        private void FrmBusquedaBitacora_IS_FormClosing(object sender, FormClosingEventArgs e)
        {
            //InsertarLogConexion
            string ipEquipo = string.Empty;
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
            claseLog.Accion = "Cerró el formulario";
            claseLog.Autor = Environment.UserName;
            claseLog.IpOrigen = ipEquipo;
            claseLog.Formulario = "Reporte individual";

            MetodoLogsConexion metLog = new MetodoLogsConexion();
            metLog.LogsConexion_Insert(claseLog);
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked)
            {
                ddlMes.Visible = false;
                ddlAno.Visible = false;
                ddlHorasExtras.Visible = false;
                ddlEmpresa.Visible = false;
                dtpFechaInicio.Visible = false;
                dtpFechaFin.Visible = false;
                ddlCategoria.Visible = false;

                dgvBitacora.Rows.Clear();
                
                chkMes.Checked = false;
                chkAno.Checked = false;
                chkHoraExtra.Checked = false;
                chkEmpresa.Checked = false;
                chkFechaInicio.Checked = false;
                chkfechafin.Checked = false;
                chkServicio.Checked = false;
                
            }
        }

        private void chkEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEmpresa.Checked)
            {
                chkTodos.Checked = false;

                dgvBitacora.Rows.Clear();

                ddlEmpresa.Visible = true;
            }
            else
            {
                ddlEmpresa.Visible = false;
            }
        }

        private void chkMes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMes.Checked)
            {
                chkTodos.Checked = false;

                dgvBitacora.Rows.Clear();

                ddlMes.Visible = true;
                chkAno.Checked = true;
            }
            else
            {
                ddlMes.Visible = false;
                chkAno.Checked = false;
            }
        }

        private void chkAno_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAno.Checked)
            {
                chkTodos.Checked = false;

                dgvBitacora.Rows.Clear();

                ddlAno.Visible = true;
            }
            else
            {
                ddlAno.Visible = false;
            }
        }

        private void chkServicio_CheckedChanged(object sender, EventArgs e)
        {
            if (chkServicio.Checked)
            {
                chkTodos.Checked = false;

                dgvBitacora.Rows.Clear();

                ddlCategoria.Visible = true;
            }
            else
            {
                ddlCategoria.Visible = false;
            }
        }

        private void chkHoraExtra_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHoraExtra.Checked)
            {
                chkTodos.Checked = false;

                dgvBitacora.Rows.Clear();

                ddlHorasExtras.Visible = true;
            }
            else
            {
                ddlHorasExtras.Visible = false;
            }
        }

        private void chkFechaInicio_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFechaInicio.Checked)
            {
                chkTodos.Checked = false;

                dgvBitacora.Rows.Clear();

                dtpFechaInicio.Visible = true;
            }
            else
            {
                dtpFechaInicio.Visible = false;
            }
        }

        private void chkfechafin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkfechafin.Checked)
            {
                chkTodos.Checked = false;

                dgvBitacora.Rows.Clear();

                dtpFechaFin.Visible = true;
            }
            else
            {
                dtpFechaFin.Visible = false;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            DataGridView grd = new DataGridView();
            grd = dgvBitacora;

            if (grd.Rows.Count > 0)
            {
                GenExcell ge = new GenExcell();
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    string destino = string.Empty;

                    if (fichero.FileName != "")
                    {
                        destino = fichero.FileName;
                    }

                    //Especificar la ruta y nombre con el que se guardará el archivo
                    string filenam3 = destino;

                    //ge.DoExcell(dgvBitacora, filenam3);
                    ToCsV(dgvBitacora, filenam3); 
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
            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value.ToString().Replace(Environment.NewLine, "").Replace("\r\n","")) + "\t";
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

        internal class GenExcell
        {
            StreamWriter w;

            public int DoExcell(DataGridView dgv, string ruta)
            {
                FileStream fs = new FileStream(ruta, FileMode.Create, FileAccess.ReadWrite);

                w = new StreamWriter(fs);
                EscribeCabecera();

                EscribeLinea(dgv);

                EscribePiePagina();
                w.Close();
                return 0;
            }

            public void EscribeCabecera()
            {
                StringBuilder html = new StringBuilder();
                html.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">");
                html.Append("<html>");
                html.Append("<head>");
                html.Append("<title>www.devjoker.com</title>");
                html.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />");
                html.Append("</head>");
                html.Append("<body>");
                html.Append("<p>");
                html.Append("<table>");
                html.Append("<tr style=\"font-weight:bold;font-size: 16px;\">");
                html.Append("<td bgcolor=\"#8DB4E2\">SERVICIO</td>");
                html.Append("<td bgcolor=\"#8DB4E2\">EMPRESA</td>");
                html.Append("<td bgcolor=\"#8DB4E2\">FECHA INICIO</td>");
                html.Append("<td bgcolor=\"#8DB4E2\">FECHA FIN</td>");
                html.Append("<td bgcolor=\"#8DB4E2\">TAREA</td>");
                html.Append("<td bgcolor=\"#8DB4E2\">FRECUENCIA</td>");
                html.Append("<td bgcolor=\"#8DB4E2\">EVIDENCIA</td>");
                html.Append("<td bgcolor=\"#8DB4E2\">ESFUERZO</td>");
                html.Append("</tr>");
                w.Write(html.ToString());
            }

            public void EscribeLinea(DataGridView dgv)
            {
                string bgColor = "", fontColor = "";

                fontColor = " style=\"font-size: 14px; vertical-align: middle;\" ";

                int i = 0;

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (i % 2 == 0)
                    {
                        bgColor = " bgcolor=\"white\" ";
                    }
                    else
                    {
                        bgColor = " bgcolor=\"#DCE6F1\" ";
                    }

                    char pad = '0';

                    string a = row.Cells["dgIdRegistro"].Value.ToString();
                    //dgCategoria;
                    //dgEmpresa;
                    //dgEsfuerzo;
                    //dgEvidencia;
                    //dgFechaFin;
                    //dgFechaInicio;
                    //dgFrecuencia;
                    //dgIdRegistro;
                    //dgTarea;

                    //26/01/2015
                    string FechaInicio = Convert.ToDateTime(row.Cells["dgFechaInicio"].Value.ToString()).Day.ToString().PadLeft(2, pad) + "/" +
                        Convert.ToDateTime(row.Cells["dgFechaInicio"].Value.ToString()).Month.ToString().PadLeft(2, pad) + "/" +
                        Convert.ToDateTime(row.Cells["dgFechaInicio"].Value.ToString()).Year;

                    string FechaFin = Convert.ToDateTime(row.Cells["dgFechaFin"].Value.ToString()).Day.ToString().PadLeft(2, pad) + "/" +
                        Convert.ToDateTime(row.Cells["dgFechaFin"].Value.ToString()).Month.ToString().PadLeft(2, pad) + "/" +
                        Convert.ToDateTime(row.Cells["dgFechaFin"].Value.ToString()).Year;

                    w.Write(@"<tr ><td {0} {1}>" + row.Cells["dgCategoria"].Value.ToString() + "</td>" +
                        "<td {0} {1}>" + row.Cells["dgEmpresa"].Value.ToString() + "</td>" +
                        "<td {0} {1}>" + FechaInicio + "</td>" +
                        "<td {0} {1}>" + FechaFin + "</td>" +
                        "<td {0} {1}>" + row.Cells["dgTarea"].Value.ToString() + "</td>" +
                        "<td {0} {1}>" + row.Cells["dgFrecuencia"].Value.ToString() + "</td>" +
                        "<td {0} {1}>" + row.Cells["dgEvidencia"].Value.ToString() + "</td>" +
                        "<td {0} {1}>" + row.Cells["dgEsfuerzo"].Value.ToString() + "</td>" +
                        "</tr>", bgColor, fontColor);

                    i++;
                }
            }

            public void EscribePiePagina()
            {
                StringBuilder html = new StringBuilder();
                html.Append("  </table>");
                html.Append("</p>");
                html.Append(" </body>");
                html.Append("</html>");
                w.Write(html.ToString());
            }
        }
    }
}
