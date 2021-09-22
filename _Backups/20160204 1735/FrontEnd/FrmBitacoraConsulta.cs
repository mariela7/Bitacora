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

namespace FrontEnd
{
    public partial class FrmBitacoraConsulta : Form
    {
        public string ValorNombre = string.Empty;
        public int ValorId;
        List<ClaseServiciosDetalle_CertificacionAplicaciones> ListaColumnas;
        string UsuarioConectado = Environment.UserName;

        public FrmBitacoraConsulta()
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
            this.dgvBitacora.Columns.Add("CEsfuerzo", "Esfuerzo");
            this.dgvBitacora.Columns.Add("CId", "ID");
            this.dgvBitacora.Columns["CId"].Visible = false;

            this.dgvBitacora.Columns.Add("CXML", "XML");
            this.dgvBitacora.Columns["CXML"].Visible = false;
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
            miLista = mimetodo.Bitacora_CertificacionApp_SelectByServicio(Environment.UserName, ValorId, Convert.ToInt32(this.cmbMeses.SelectedValue.ToString()),Convert.ToInt32(this.cmbAnio.SelectedItem.ToString()) );
            double TotalEsfuerzo = 0;
            foreach (var item in miLista)
            {
                this.dgvBitacora.Rows.Add();
                this.dgvBitacora.Rows[this.dgvBitacora.Rows.Count - 1].Cells["CFecha"].Value = item.Fecha.ToShortDateString();
                this.dgvBitacora.Rows[this.dgvBitacora.Rows.Count - 1].Cells["CEsfuerzo"].Value = item.Esfuerzo;
                LlenarGridXML(item.Detalle, this.dgvBitacora.Rows.Count - 1);
                this.dgvBitacora.Rows[this.dgvBitacora.Rows.Count - 1].Cells["CXML"].Value = item.Detalle;
                this.dgvBitacora.Rows[this.dgvBitacora.Rows.Count - 1].Cells["CId"].Value = item.IdBitacora;
                TotalEsfuerzo = TotalEsfuerzo + Convert.ToDouble( item.Esfuerzo);
            }
            this.TxtTotal.Text = TotalEsfuerzo.ToString();
        }

        private void dgvBitacora_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 )
            {
                this.tvDatos.Nodes.Clear();
                ConvertXmlNodeToTreeNode((XmlNode)this.dgvBitacora.Rows[e.RowIndex].Cells["CXML"].Value, this.tvDatos.Nodes);
                this.tvDatos.ExpandAll();
            }
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

            for (int i = 1; i < miRow.Cells.Count -3; i++)
            {
                miRow.Cells[i].Value = miTablaValores.Rows[i - 1][1].ToString();
            }
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvBitacora.SelectedRows.Count > 0)
            {
                DataGridView miDGV = new DataGridView();
                foreach (DataGridViewColumn item in this.dgvBitacora.Columns)
                {
                    miDGV.Columns.Add(item.Name, item.HeaderText); ;
                }

                miDGV.Columns.Remove("CXML");

                int idModificar;
                idModificar = Convert.ToInt32( this.dgvBitacora.SelectedRows[0].Cells["CId"].Value.ToString());

                miDGV.Rows.Clear();
                miDGV.Rows.Add();

                int i = 0;

                foreach (DataGridViewColumn item in miDGV.Columns)
                {
                    miDGV.Rows[0].Cells[i].Value = this.dgvBitacora.SelectedRows[0].Cells[i].Value.ToString();
                    i++;
                }

                FrmBitacora_CA miBitacora = new FrmBitacora_CA();
                miBitacora.ValorId = ValorId;
                miBitacora.ValorNombre = ValorNombre;
                miBitacora.MdiParent = this.MdiParent;
                miBitacora.WindowState = FormWindowState.Maximized;
                miBitacora.ValorIdMODIFICAR = idModificar;
                miBitacora.ValorRowMODIFICAR = miDGV.Rows[0];
                miBitacora.Show();
                
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvBitacora.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Esta seguro que desea eliminar este registro? \n Esta acción no se puede deshacer.","Advertencia",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
                {
                    
                }
                
                //CODIGO PARA ELIMINAR EL REGISTRO
            }

        }

    }
}
