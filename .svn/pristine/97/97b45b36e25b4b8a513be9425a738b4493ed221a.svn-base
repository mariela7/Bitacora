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
    public partial class FrmReporteTodo_IS : Form
    {
        //private static FrmReporteTodo_IS m_FormDefInstance;
        //public static FrmReporteTodo_IS DefInstance
        //{
        //    get
        //    {
        //        if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
        //        {
        //            m_FormDefInstance = new FrmReporteTodo_IS();
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

        MetodoCategorias_IngenieriaSeguridad metCategoria = new MetodoCategorias_IngenieriaSeguridad();
        MetodoEmpresas_IngenieriaSeguridad metEmpresa = new MetodoEmpresas_IngenieriaSeguridad();
        MetodoServicios_IngenieriaSeguridad metServicio = new MetodoServicios_IngenieriaSeguridad();
        MetodoGeneral metGeneral = new MetodoGeneral();

        List<ClaseCategorias_IngenieriaSeguridad> ListaServicios = new List<ClaseCategorias_IngenieriaSeguridad>();
        List<ClaseEmpresas_IngenieriaSeguridad> ListaEmpresas = new List<ClaseEmpresas_IngenieriaSeguridad>();
        List<int> ListaAnos = new List<int>();
        string ipEquipo = string.Empty;

        public FrmReporteTodo_IS()
        {
            InitializeComponent();
        }

        private void FrmReporteTodo_IS_Load(object sender, EventArgs e)
        {
            chkTodos.Checked = false;
            chkMes.Checked = false;
            chkAno.Checked = false;
            chkHoraExtra.Checked = false;
            chkEmpresa.Checked = false;
            chkResponsable.Checked = false;
            chkServicio.Checked = false;

            ddlMes.Visible = false;
            ddlAno.Visible = false;
            ddlHorasExtras.Visible = false;
            ddlEmpresa.Visible = false;
            ddlCategoria.Visible = false;

            dgvBitacora.Rows.Clear();

            //dgvBitacora.Location = new Point(0, 134);
            //int tamanoFRM = this.Size.Height;
            //int tamanoGrid = dgvBitacora.Size.Width;
            //dgvBitacora.Size = new Size(tamanoGrid, tamanoFRM - 215);

            ddlEmpresa.Visible = false;
            ddlMes.Visible = false;
            txtResponsable.Visible = false;
            ddlCategoria.Visible = false;

            ListaServicios = metCategoria.Categorias_IngenieriaSeguridad_SelectAll();
            ListaServicios = ListaServicios.OrderBy(x => x.DescripcionCategoria).ToList();
            ddlCategoria.DataSource = ListaServicios;
            ddlCategoria.ValueMember = "IdCategoria";
            ddlCategoria.DisplayMember = "DescripcionCategoria";


            ListaAnos = metGeneral.ObtenerAnos();
            ddlAno.DataSource = ListaAnos;
            LlenarMeses();

            ListaEmpresas = metEmpresa.Empresas_IngenieriaSeguridad_SelectAll();
            ListaEmpresas = ListaEmpresas.OrderBy(x => x.NombreEmpresa).ToList();
            ddlEmpresa.DataSource = ListaEmpresas;
            ddlEmpresa.ValueMember = "IdEmpresa";
            ddlEmpresa.DisplayMember = "NombreEmpresa";

            List<string> ListaTipoHora = new List<string>();
            ListaTipoHora.Add("SI");
            ListaTipoHora.Add("NO");
            ddlHorasExtras.DataSource = ListaTipoHora;

            //InsertarLogConexion
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
            claseLog.Formulario = "Reporte bitácora - Todos los usuarios";

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

            if ((chkTodos.Checked == false) && (chkMes.Checked == false) && (chkAno.Checked == false) && (chkHoraExtra.Checked == false) && (chkEmpresa.Checked == false) && (chkResponsable.Checked == false) && (chkServicio.Checked == false))
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

            if (chkResponsable.Checked)
            {
                responsable = txtResponsable.Text.Trim();
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
                    dgvBitacora.Rows[dgvBitacora.Rows.Count - 1].Cells["dgServicio"].Value = "HISTORICO";
                }
                else
                {
                    dgvBitacora.Rows[dgvBitacora.Rows.Count - 1].Cells["dgServicio"].Value = clsServicio.NombreServicio.ToString();
                }
                dgvBitacora.Rows[dgvBitacora.Rows.Count - 1].Cells["dgCategoria"].Value = clsCategoria.DescripcionCategoria.ToString();
                dgvBitacora.Rows[dgvBitacora.Rows.Count - 1].Cells["dgEmpresa"].Value = clsEmpresa.NombreEmpresa.ToString();
                dgvBitacora.Rows[dgvBitacora.Rows.Count - 1].Cells["dgFechaInicio"].Value = item.FechaInicio.ToShortDateString();
                dgvBitacora.Rows[dgvBitacora.Rows.Count - 1].Cells["dgFechaFin"].Value = item.FechaFin.ToShortDateString();
                dgvBitacora.Rows[dgvBitacora.Rows.Count - 1].Cells["dgTarea"].Value = item.Tarea.ToString();
                dgvBitacora.Rows[dgvBitacora.Rows.Count - 1].Cells["dgResponsable"].Value = item.Responsable.ToString();
                dgvBitacora.Rows[dgvBitacora.Rows.Count - 1].Cells["dgFrecuencia"].Value = item.Frecuencia.ToString();
                dgvBitacora.Rows[dgvBitacora.Rows.Count - 1].Cells["dgEvidencia"].Value = item.Evidencia.ToString();
                dgvBitacora.Rows[dgvBitacora.Rows.Count - 1].Cells["dgEsfuerzo"].Value = item.Esfuerzo;
            }

            double total = 0;
            foreach (DataGridViewRow row in dgvBitacora.Rows)
            {
                total = total + Convert.ToDouble(dgvBitacora.Rows[row.Index].Cells["dgEsfuerzo"].Value);
            }

            txtTotalHoras.Text = total.ToString();
        }

        private void FrmReporteTodo_IS_Resize(object sender, EventArgs e)
        {
            //dgvBitacora.Location = new Point(0, 134);
            //int tamanoFRM = this.Size.Height;
            //int tamanoGrid = dgvBitacora.Size.Width;
            //dgvBitacora.Size = new Size(tamanoGrid, tamanoFRM - 215);
        }

        private void FrmReporteTodo_IS_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClaseLogsConexion claseLog = new ClaseLogsConexion();
            claseLog.Accion = "Cerró el formulario";
            claseLog.Autor = Environment.UserName;
            claseLog.IpOrigen = ipEquipo;
            claseLog.Formulario = "Reporte bitácora - Todos los usuarios";

            MetodoLogsConexion metLog = new MetodoLogsConexion();
            metLog.LogsConexion_Insert(claseLog);
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

        private void chkResponsable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkResponsable.Checked)
            {
                chkTodos.Checked = false;

                dgvBitacora.Rows.Clear();

                txtResponsable.Visible = true;
                txtResponsable.Text = Environment.UserName;
            }
            else
            {
                txtResponsable.Visible = false;
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

        private void chkEmpresa_CheckedChanged_1(object sender, EventArgs e)
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

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked)
            {
                ddlEmpresa.Visible = false;
                ddlMes.Visible = false;
                txtResponsable.Visible = false;
                ddlCategoria.Visible = false;
                ddlAno.Visible = false;
                ddlHorasExtras.Visible = false;

                dgvBitacora.Rows.Clear();

                chkEmpresa.Checked = false;
                chkMes.Checked = false;
                chkAno.Checked = false;
                chkResponsable.Checked = false;
                chkServicio.Checked = false;
                chkHoraExtra.Checked = false;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            DataGridView grd = new DataGridView();
            grd = dgvBitacora;

            if (grd.Rows.Count > 0)
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.FileName = this.ddlMes.Text.ToString() + " - Reporte total.xls";

                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    string destino = string.Empty;

                    if (fichero.FileName != "")
                    {
                        destino = fichero.FileName;
                    }

                    //Especificar la ruta y nombre con el que se guardará el archivo
                    string filenam3 = destino;

                    ToCsV(dgvBitacora, filenam3);

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
            {
                string columnName = dGV.Columns[j].Name;
                if (columnName.ToUpper().Substring(0, 4) != "DGID")
                {
                    sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
                }
            }
            stOutput += sHeaders + "\r\n";

            // Export data.
            for (int i = 0; i < dGV.RowCount; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                {
                    string columnName = dGV.Columns[j].Name;
                    if (columnName.ToUpper().Substring(0, 4) != "DGID")
                    {
                        stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value.ToString().Replace(Environment.NewLine, "").Replace("\r\n", "")) + "\t";
                    }
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
    }
}
