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
using System.Net;

namespace FrontEnd
{
    public partial class FrmBitacoraConsulta : Form
    {
        public string ValorNombre = string.Empty;
        public int ValorId;
        List<ClaseServiciosDetalle_CertificacionAplicaciones> ListaColumnas;
        string UsuarioConectado = Environment.UserName;
        string ipEquipo = string.Empty;

        public FrmBitacoraConsulta()
        {
            InitializeComponent();
        }

        private void FrmBitacoraConsulta_Load(object sender, EventArgs e)
        {
            //Código para definición de lenguaje y sistema de puntuación de la aplicación
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;
            culture = new System.Globalization.CultureInfo("es-EC");
            culture.NumberFormat.NumberDecimalSeparator = ".";
            culture.NumberFormat.NumberDecimalDigits = 2;
            culture.NumberFormat.PerMilleSymbol = ",";
            culture.NumberFormat.NumberGroupSeparator = ";";
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;


            this.WindowState = FormWindowState.Maximized;
            this.Text = ValorNombre;
            this.lblBitacora.Text = ValorNombre;
            LlenarColumnasGrid();
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
            claseLog.Formulario = "Bitácora Certificación de Aplicaciones - Consultas - " + lblBitacora.Text.Trim();

            MetodoLogsConexion metLog = new MetodoLogsConexion();
            metLog.LogsConexion_Insert(claseLog);

            MetodoGeneral miMetodo = new MetodoGeneral();
            ClaseParametros parametro = new ClaseParametros();
            parametro = miMetodo.Parametros_SelectByCodigo("BBM");
            if (parametro.Valor == "ON")
            {
                MessageBox.Show("La bitácora se encuentra bloqueada por mantenimiento. Por favor contactarse con el administrador para conocer el tiempo de duración del bloqueo.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

            this.dgvBitacora.Columns.Add("CFechaInicio", "Fecha Inicio");
            this.dgvBitacora.Columns.Add("CFechaFin", "Fecha Fin");
            foreach (ClaseServiciosDetalle_CertificacionAplicaciones item in ListaColumnas)
            {

                    DataGridViewTextBoxColumn miColumna = new DataGridViewTextBoxColumn();
                    miColumna.Name = "C" + item.Nombre.Trim();
                    miColumna.HeaderText = item.Nombre.Trim();
                    this.dgvBitacora.Columns.Add(miColumna);
            }
            this.dgvBitacora.Columns.Add("CEsfuerzo", "Esfuerzo");
            this.dgvBitacora.Columns["CEsfuerzo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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
            GetLista();
        }

        private void GetLista()
        {
            this.dgvBitacora.Rows.Clear();

            List<ClaseBitacora_CertificacionApp> miLista = new List<ClaseBitacora_CertificacionApp>();
            MetodoBitacora_CertificacionAplicaciones mimetodo = new MetodoBitacora_CertificacionAplicaciones();
            miLista = mimetodo.Bitacora_CertificacionApp_SelectByServicio(Environment.UserName, ValorId, Convert.ToInt32(this.cmbMeses.SelectedValue.ToString()),Convert.ToInt32(this.cmbAnio.SelectedItem.ToString()) );
            double TotalEsfuerzo = 0;
            foreach (var item in miLista)
            {
                this.dgvBitacora.Rows.Add();
                this.dgvBitacora.Rows[this.dgvBitacora.Rows.Count - 1].Cells["CFechaInicio"].Value = item.FechaInicio.ToShortDateString();
                this.dgvBitacora.Rows[this.dgvBitacora.Rows.Count - 1].Cells["CFechaFin"].Value = item.FechaFin.ToShortDateString();                
                this.dgvBitacora.Rows[this.dgvBitacora.Rows.Count - 1].Cells["CEsfuerzo"].Value = item.Esfuerzo;
                LlenarGridXML(item.Detalle, this.dgvBitacora.Rows.Count - 1);
                this.dgvBitacora.Rows[this.dgvBitacora.Rows.Count - 1].Cells["CXML"].Value = item.Detalle;
                this.dgvBitacora.Rows[this.dgvBitacora.Rows.Count - 1].Cells["CId"].Value = item.IdBitacora;
                TotalEsfuerzo = TotalEsfuerzo + Convert.ToDouble( item.Esfuerzo);
            }

            this.TxtTotal.Text = TotalEsfuerzo.ToString();

            dgvBitacora.AutoResizeColumns();

            DataGridViewColumn column;

            switch (ValorId)
            {
                case 1:
                    column = dgvBitacora.Columns["CEvidencia"];
                    column.Width = 200;
                    dgvBitacora.Columns["CEvidencia"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    break;

                case 2:
                    column = dgvBitacora.Columns["CEvidencia"];
                    column.Width = 200;
                    dgvBitacora.Columns["CEvidencia"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    break;

                case 3:
                    column = dgvBitacora.Columns["CEvidencia"];
                    column.Width = 200;
                    dgvBitacora.Columns["CEvidencia"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    break;

                case 6:
                    column = dgvBitacora.Columns["CEvidencia"];
                    column.Width = 200;
                    dgvBitacora.Columns["CEvidencia"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    break;

                case 12: //Nuevos Proyectos
                    column = dgvBitacora.Columns["CTarea"];
                    column.Width = 200;

                    column = dgvBitacora.Columns["CDescripcion tarea"];
                    column.Width = 300;

                    column = dgvBitacora.Columns["CEvidencias"];
                    column.Width = 200;

                    dgvBitacora.Columns["CTarea"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    dgvBitacora.Columns["CDescripcion tarea"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                    dgvBitacora.AutoResizeRows();

                    dgvBitacora.Columns["CEvidencias"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    break;

                case 14:
                    column = dgvBitacora.Columns["CEvidencias"];
                    column.Width = 200;
                    dgvBitacora.Columns["CEvidencias"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    break;

                case 16:
                    column = dgvBitacora.Columns["CEvidencia"];
                    column.Width = 200;
                    dgvBitacora.Columns["CEvidencia"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    break;

                default:
                    break;
            }
            
            dgvBitacora.AutoResizeRows();

            this.dgvBitacora.Columns["CEsfuerzo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.tvDatos.Nodes.Clear();
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

            for (int i = 1; i < miRow.Cells.Count -4; i++)
            {
                miRow.Cells[i+1].Value = miTablaValores.Rows[i - 1][1].ToString();
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
                    //this.dgvBitacora.Rows[this.dgvBitacora.Rows.Count - 1].Cells["CId"].Value
                    int idEliminar;
                    idEliminar = Convert.ToInt32(this.dgvBitacora.SelectedRows[0].Cells["CId"].Value.ToString());

                    MetodoBitacora_CertificacionAplicaciones mtBitacora = new MetodoBitacora_CertificacionAplicaciones();
                    int res = mtBitacora.Bitacora_CertificacionApp_DeleteDetalle(idEliminar);
                    dgvBitacora.Rows.Clear();
                    MessageBox.Show("El registro han sido eliminados exitosamente.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GetLista();
                }
                
                //CODIGO PARA ELIMINAR EL REGISTRO
            }

        }

        private void FrmBitacoraConsulta_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClaseLogsConexion claseLog = new ClaseLogsConexion();
            claseLog.Accion = "Cerró el formulario";
            claseLog.Autor = Environment.UserName;
            claseLog.IpOrigen = ipEquipo;
            claseLog.Formulario = "Bitácora Certificación de Aplicaciones - Consultas - " + lblBitacora.Text.Trim();

            MetodoLogsConexion metLog = new MetodoLogsConexion();
            metLog.LogsConexion_Insert(claseLog);
        }

    }
}
