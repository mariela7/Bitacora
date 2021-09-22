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
using System.Xml;
using System.IO;

namespace FrontEnd
{
    public partial class FrmReporteProyectos : Form
    {
        public FrmReporteProyectos()
        {
            InitializeComponent();
        }

        MetodoEmpresas_IngenieriaSeguridad metEmpresa = new MetodoEmpresas_IngenieriaSeguridad();
        MetodoBitacora_CertificacionAplicaciones metCA = new MetodoBitacora_CertificacionAplicaciones();

        List<ClaseEmpresas_IngenieriaSeguridad> ListaEmpresas = new List<ClaseEmpresas_IngenieriaSeguridad>();
        List<ClaseLista_CertificacionAplicaciones> ListaProyectos = new List<ClaseLista_CertificacionAplicaciones>();


        private void FrmReporteProeyctos_Load(object sender, EventArgs e)
        {
            ListaEmpresas = metEmpresa.Empresas_IngenieriaSeguridad_SelectAll();

            ClaseEmpresas_IngenieriaSeguridad empresaTodas = new ClaseEmpresas_IngenieriaSeguridad();
            empresaTodas.IdEmpresa = 0;
            empresaTodas.NombreEmpresa = "TODAS";

            ListaEmpresas.Add(empresaTodas);

            ListaEmpresas = ListaEmpresas.OrderBy(x => x.NombreEmpresa).ToList();
            ddlEmpresa.DataSource = ListaEmpresas;
            ddlEmpresa.ValueMember = "IdEmpresa";
            ddlEmpresa.DisplayMember = "NombreEmpresa";

            int emp = ddlEmpresa.Items.Count;
            ddlEmpresa.SelectedIndex = emp - 1;

            ListaProyectos = metCA.Bitacora_CertificacionApp_SelectLista(4);
            ListaProyectos = ListaProyectos.OrderBy(x => x.Valor).ToList();
            ddlProyecto.DataSource = ListaProyectos;
            ddlProyecto.ValueMember = "Valor";
            ddlProyecto.DisplayMember = "Valor";

            int pry = ddlProyecto.Items.Count;
            ddlProyecto.SelectedIndex = pry - 1;

            MetodoGeneral miMetodo = new MetodoGeneral();
            ClaseParametros parametro = new ClaseParametros();
            parametro = miMetodo.Parametros_SelectByCodigo("BBM");
            if (parametro.Valor == "ON")
            {
                MessageBox.Show("La bitácora se encuentra bloqueada por mantenimiento. Por favor contactarse con el administrador para conocer el tiempo de duración del bloqueo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.ExitThread();
            }
        }

        private void btnCargarDatos_Click(object sender, EventArgs e)
        {
            this.dgvProyectos.Rows.Clear();
            GetLista();

            dgvProyectos.AutoResizeColumns();

            DataGridViewColumn column = dgvProyectos.Columns["dgTarea"];
            column.Width = 200;

            column = dgvProyectos.Columns["dgDescripcionTarea"];
            column.Width = 300;

            column = dgvProyectos.Columns["dgEvidencias"];
            column.Width = 200;

            dgvProyectos.Columns["dgTarea"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvProyectos.Columns["dgDescripcionTarea"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvProyectos.AutoResizeRows();

            dgvProyectos.Columns["dgEvidencias"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvProyectos.Sort(dgFechaInicio, ListSortDirection.Ascending);

            double total = 0;

            foreach (DataGridViewRow row in dgvProyectos.Rows)
            {
                total = total + Convert.ToDouble(dgvProyectos.Rows[row.Index].Cells["dgEsfuerzo"].Value);
            }

            this.dgvProyectos.Columns["dgEsfuerzo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            txtTotalHoras.Text = total.ToString();
        }

        private void GetLista()
        {
            List<ClaseBitacora_CertificacionApp> miLista = new List<ClaseBitacora_CertificacionApp>();
            MetodoGeneral mimetodo = new MetodoGeneral();
            miLista = mimetodo.ReporteTodosLosProyectos(ddlEmpresa.Text, Convert.ToDateTime(dtpFechaInicio.Value.ToShortDateString()), Convert.ToDateTime(dtpFechaFin.Value.ToShortDateString()), ddlProyecto.Text);

            double TotalEsfuerzo = 0;
            foreach (var item in miLista)
            {
                this.dgvProyectos.Rows.Add();
                this.dgvProyectos.Rows[this.dgvProyectos.Rows.Count - 1].Cells["dgFechaInicio"].Value = item.FechaInicio.ToShortDateString();
                this.dgvProyectos.Rows[this.dgvProyectos.Rows.Count - 1].Cells["dgFechaFin"].Value = item.FechaFin.ToShortDateString();                
                this.dgvProyectos.Rows[this.dgvProyectos.Rows.Count - 1].Cells["dgEsfuerzo"].Value = Convert.ToDouble(item.Esfuerzo.ToString()); ;
                this.dgvProyectos.Rows[this.dgvProyectos.Rows.Count - 1].Cells["dgResponsable"].Value = item.Responsable;
                LlenarGridXML(item.Detalle, this.dgvProyectos.Rows.Count - 1);
                TotalEsfuerzo = TotalEsfuerzo + Convert.ToDouble(item.Esfuerzo);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            DataGridView grd = new DataGridView();
            grd = dgvProyectos;

            if (grd.Rows.Count > 0)
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.FileName = "EMPRESA_" + ddlEmpresa.Text + " - PROYECTO_" + ddlProyecto.Text + " - " +
                    DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".xls";

                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    string destino = string.Empty;

                    if (fichero.FileName != "")
                    {
                        destino = fichero.FileName;
                    }

                    //Especificar la ruta y nombre con el que se guardará el archivo
                    string filenam3 = destino;

                    ToCsV(dgvProyectos, filenam3);

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

        private void LlenarGridXML(XmlNode ValorXML, int RowId)
        {
            DataGridViewRow miRow = this.dgvProyectos.Rows[RowId];

            XmlNode errorNode = ValorXML.SelectSingleNode("/Servicio");

            DataTable miTablaValores = new DataTable("tbvalores");
            miTablaValores.Columns.Add("Nombre");
            miTablaValores.Columns.Add("Valor");

            foreach (XmlNode item in errorNode.ChildNodes)
            {
                miTablaValores.Rows.Add(item.Attributes["Nombre"].Value, item.Attributes["VALOR"].Value);
            }

            for (int i = 1; i < miRow.Cells.Count - 3; i++)
            {
                miRow.Cells[i + 1].Value = miTablaValores.Rows[i - 1][1].ToString();
            }

        }
    }
}
