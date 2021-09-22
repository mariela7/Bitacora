using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LogicaNegocios.Clases;
using LogicaNegocios.Metodos;
using System.Xml;
using System.IO;


namespace FrontEnd
{
    public partial class FrmBitacoraReporte : Form
    {
        public string ValorNombre = string.Empty;
        public int ValorId;
        List<ClaseServiciosDetalle_CertificacionAplicaciones> ListaColumnas;
        string UsuarioConectado = Environment.UserName;

        public FrmBitacoraReporte()
        {
            InitializeComponent();
        }

        private void FrmBitacoraConsulta_Load(object sender, EventArgs e)
        {
            
            
            
            this.WindowState = FormWindowState.Maximized;
            this.Text = ValorNombre;
            this.lblBitacora.Text = ValorNombre;
            LlenarColumnasGrid();
            LlenarMeses();

            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;
            culture = new System.Globalization.CultureInfo("es-EC");
            culture.NumberFormat.NumberDecimalSeparator = ".";
            culture.NumberFormat.NumberDecimalDigits = 2;
            culture.NumberFormat.PerMilleSymbol = ",";
            culture.NumberFormat.NumberGroupSeparator = ";";
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;

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
            this.cmbMeses.DataSource = miTablaMeses;
            this.cmbMeses.ValueMember = "Id";
            this.cmbMeses.DisplayMember = "Nombre";

         
            for (int i = 2014; i <= DateTime.Now.Year; i++)
            {
                this.cmbAnio.Items.Add(i);
            }
            this.cmbMeses.SelectedValue = DateTime.Now.Month;
            this.cmbAnio.SelectedItem = DateTime.Now.Year;

        }


        private void LlenarColumnasGrid()
        {
            ListaColumnas = new List<ClaseServiciosDetalle_CertificacionAplicaciones>();
            MetodoBitacora_CertificacionAplicaciones miMetodo = new MetodoBitacora_CertificacionAplicaciones();
            ListaColumnas = miMetodo.Bitacora_CertificacionApp_SelectServiciosDetalles(ValorId);
            this.dgvBitacora.Columns.Clear();

            this.dgvBitacora.Columns.Add("CFecha", "Fecha");
            foreach (ClaseServiciosDetalle_CertificacionAplicaciones item in ListaColumnas)
            {

                    DataGridViewTextBoxColumn miColumna = new DataGridViewTextBoxColumn();
                    miColumna.Name = "C" + item.Nombre.Trim();
                    miColumna.HeaderText = item.Nombre.Trim();
                    this.dgvBitacora.Columns.Add(miColumna);
            }
            this.dgvBitacora.Columns.Add("CResponsable", "Responsable");
            this.dgvBitacora.Columns.Add("CEsfuerzo", "Esfuerzo");
            /*
            this.dgvBitacora.Columns.Add("CId", "ID");
            this.dgvBitacora.Columns["CId"].Visible = false;

            this.dgvBitacora.Columns.Add("CXML", "XML");
            this.dgvBitacora.Columns["CXML"].Visible = false;
             */
        }

        private void ConvertXmlNodeToTreeNode(XmlNode xmlNode,  TreeNodeCollection treeNodes)
        {

            TreeNode newTreeNode = treeNodes.Add(xmlNode.Name);

            switch (xmlNode.NodeType)
            {
                case XmlNodeType.ProcessingInstruction:
                case XmlNodeType.XmlDeclaration:
                    newTreeNode.Text = "<?" + xmlNode.Name + " " +
                      xmlNode.Value + "?>";
                    break;
                case XmlNodeType.Element:
                    if (xmlNode.Name =="C")
                    {
                        newTreeNode.Text = xmlNode.Attributes["Nombre"].Value + ": " + xmlNode.Attributes["VALOR"].Value;
                    }
                    else
                    {
                        newTreeNode.Text =  xmlNode.Name ;
                    }
                    break;
                    
                case XmlNodeType.Attribute:
                    //newTreeNode.Text = "ATTRIBUTE: " + xmlNode.Name;
                    if (xmlNode.Name == "Nombre")
                    {
                        break;
                    }
                    if (xmlNode.Name == "VALOR")
                    {
                        newTreeNode.Text = xmlNode.Value;
                        break;
                    }
                    newTreeNode.Text = xmlNode.Name;
                    break;
                case XmlNodeType.Text:
                case XmlNodeType.CDATA:
                    newTreeNode.Text = xmlNode.Value;
                    break;
                case XmlNodeType.Comment:
                    newTreeNode.Text = "<!--" + xmlNode.Value + "-->";
                    break;
            }

            if (xmlNode.Attributes != null)
            {
                if (xmlNode.Name =="VALOR")
                {
                }
                else
                {
               /*   foreach (XmlAttribute attribute in xmlNode.Attributes)
                    {
                        ConvertXmlNodeToTreeNode(attribute, newTreeNode.Nodes);
                    }*/
                }
                
            }
            foreach (XmlNode childNode in xmlNode.ChildNodes)
            {
                ConvertXmlNodeToTreeNode(childNode, newTreeNode.Nodes);
            }

        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            this.dgvBitacora.Rows.Clear();
            GetLista();
        }

        private void GetLista()
        { 
            List<ClaseBitacora_CertificacionAplicaciones> miLista = new List<ClaseBitacora_CertificacionAplicaciones>();
            MetodoBitacora_CertificacionAplicaciones mimetodo = new MetodoBitacora_CertificacionAplicaciones();
            miLista = mimetodo.Bitacora_CertificacionApp_SelectByServicio_ALL(Environment.UserName, ValorId, Convert.ToInt32(this.cmbMeses.SelectedValue.ToString()),Convert.ToInt32(this.cmbAnio.SelectedItem.ToString()) );

            double TotalEsfuerzo = 0;
            foreach (var item in miLista)
            {
                this.dgvBitacora.Rows.Add();
                this.dgvBitacora.Rows[this.dgvBitacora.Rows.Count - 1].Cells["CFecha"].Value = item.Fecha.ToShortDateString();
                this.dgvBitacora.Rows[this.dgvBitacora.Rows.Count - 1].Cells["CEsfuerzo"].Value = Convert.ToDouble(item.Esfuerzo.ToString()); ;
                this.dgvBitacora.Rows[this.dgvBitacora.Rows.Count - 1].Cells["CResponsable"].Value = item.Responsable;
                LlenarGridXML(item.Detalle, this.dgvBitacora.Rows.Count - 1);
                TotalEsfuerzo = TotalEsfuerzo + Convert.ToDouble(item.Esfuerzo);
            }
        }

        private void dgvBitacora_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LlenarGridXML(XmlNode ValorXML, int RowId)
        {
            DataGridViewRow miRow = this.dgvBitacora.Rows[RowId];

            XmlNode errorNode = ValorXML.SelectSingleNode("/Servicio");

            DataTable miTablaValores = new DataTable("tbvalores");
            miTablaValores.Columns.Add("Nombre");
            miTablaValores.Columns.Add("Valor");

            foreach (XmlNode item in errorNode.ChildNodes)
            {
                miTablaValores.Rows.Add(item.Attributes["Nombre"].Value, item.Attributes["VALOR"].Value);
            }

            for (int i = 1; i < miRow.Cells.Count - 2; i++)
            {
                miRow.Cells[i].Value = miTablaValores.Rows[i - 1][1].ToString();
            }
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName =  this.cmbMeses.Text.ToString()+" - " +ValorNombre + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(dgvBitacora, sfd.FileName); // Here dataGridview1 is your grid view name
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
                char Comilla = Convert.ToChar('"');
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value.ToString().Trim().Replace(Environment.NewLine,"").Replace(Comilla.ToString(),"" )) + "\t";
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
