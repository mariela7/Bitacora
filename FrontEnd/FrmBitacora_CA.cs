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
using System.Net;

namespace FrontEnd
{
    public partial class FrmBitacora_CA : Form
    {
        public int valid = 0;
        public string ValorNombre = string.Empty;
        public int ValorId;
        public int ValorIdMODIFICAR;
        public DataGridViewRow ValorRowMODIFICAR;
        List<ClaseServiciosDetalle_CertificacionAplicaciones> ListaColumnas;
        string UsuarioConectado = Environment.UserName;
        string ipEquipo = string.Empty;
        DateTime fechaBloqueo;

        List<ClaseLista_CertificacionAplicaciones> ListaListas = new List<ClaseLista_CertificacionAplicaciones>();
        MetodoBitacora_CertificacionAplicaciones mtBitacoraCA = new MetodoBitacora_CertificacionAplicaciones();

        //private static FrmBitacora_CA m_FormDefInstance;
        //public static FrmBitacora_CA DefInstance
        //{
        //    get
        //    {
        //        if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
        //        {
        //            m_FormDefInstance = new FrmBitacora_CA();
        //            m_FormDefInstance.valid = 0;
        //        }
        //        else
        //        {
        //            m_FormDefInstance.BringToFront();
        //            if (m_FormDefInstance.lblBitacora.Text.ToString() != "Nombre Bitácora" && m_FormDefInstance.valid == 0)
        //            {
        //                MessageBox.Show("Para abrir el formulario de un servicio diferente, cierre primero el formulario " + m_FormDefInstance.lblBitacora.Text.ToString() + ".", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //                m_FormDefInstance.valid = 1;
        //            }
        //        }
        //        return m_FormDefInstance;
        //    }
        //    set
        //    {
        //        m_FormDefInstance = value;
        //    }
        //}
        
        public FrmBitacora_CA()
        {
            InitializeComponent();
        }

        private void FrmBitacora_CA_Load(object sender, EventArgs e)
        {
            Globalizar();

            this.WindowState = FormWindowState.Maximized;
            this.Text = ValorNombre;
            this.lblBitacora.Text = ValorNombre;
            LlenarColumnasGrid();

            this.dgvBitacora.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;

            MetodoGeneral miMetodo = new MetodoGeneral();
            ClaseParametros parametro = new ClaseParametros();

            parametro = miMetodo.Parametros_SelectByCodigo("FBL");
            fechaBloqueo = Convert.ToDateTime(parametro.Valor);

            
            ListaListas = mtBitacoraCA.Bitacora_CertificacionApp_SelectLista(13);

            if (ValorIdMODIFICAR > 0)
            {
                this.dgvBitacora.Columns.Add("Cid", "Id");
                this.dgvBitacora.Columns["Cid"].Visible = false;
                this.btnCopiar.Enabled = false;
                copiarFila(ValorRowMODIFICAR);
                this.dgvBitacora.Rows[this.dgvBitacora.Rows.Count - 1].Cells["Cid"].Value = ValorIdMODIFICAR;
                this.btnAgregarRegistro.Enabled = false;
                this.btnQuitarRegistro.Enabled = false;

                bool ApVal = false;

                foreach (var item in ListaListas)
                {
                    if (Convert.ToInt32(item.Valor) == ValorId)
                    {
                        ApVal = true;
                        break;
                    }
                }

                if (ApVal)
                {
                    foreach (DataGridViewRow row in dgvBitacora.Rows)
                    {
                        if ((Convert.ToDateTime(row.Cells["CFechaInicio"].Value)) <= fechaBloqueo)
                        {
                            //No se puede modificar
                            row.Cells["CFechaInicio"].ReadOnly = true;
                            row.Cells["CFechaFin"].ReadOnly = true;
                            row.Cells["CEsfuerzo"].ReadOnly = true;

                            row.Cells["CFechaInicio"].Style.BackColor = Color.LightGray;
                            row.Cells["CFechaFin"].Style.BackColor = Color.LightGray;
                            row.Cells["CEsfuerzo"].Style.BackColor = Color.LightGray;
                        }
                    }
                }
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
            claseLog.Formulario = "Bitácora Certificación de Aplicaciones - " + lblBitacora.Text.Trim();

            MetodoLogsConexion metLog = new MetodoLogsConexion();
            metLog.LogsConexion_Insert(claseLog);
                        
            parametro = miMetodo.Parametros_SelectByCodigo("BBM");
            if (parametro.Valor == "ON")
            {
                MessageBox.Show("La bitácora se encuentra bloqueada por mantenimiento. Por favor contactarse con el administrador para conocer el tiempo de duración del bloqueo.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.ExitThread();
            }
        }

        private void Globalizar()
        {
            //Código para definición de lenguaje y sistema de puntuación de la aplicación
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;
            culture = new System.Globalization.CultureInfo("es-EC");
            culture.NumberFormat.NumberDecimalSeparator = ".";
            culture.NumberFormat.NumberDecimalDigits = 2;
            culture.NumberFormat.PerMilleSymbol = ",";
            culture.NumberFormat.NumberGroupSeparator = ";";
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;

        }

        private void copiarFila(DataGridViewRow miCeldaOriginal)
        {
            this.dgvBitacora.Rows.Add();
            int i = 0;
            foreach (DataGridViewCell item in miCeldaOriginal.Cells)
            {
                this.dgvBitacora.Rows[this.dgvBitacora.Rows.Count - 1].Cells[i].Value = item.Value;
                i++;
            }

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
                if (item.EsLista)
                {
                    DataGridViewComboBoxColumn miColumna = new DataGridViewComboBoxColumn();
                    miColumna.Name = "C" + item.Nombre.Trim();
                    miColumna.HeaderText = item.Nombre.Trim();

                    if (miColumna.HeaderText.ToUpper() == "EMPRESA")
                    {
                        List<string> ListaEmpresasValidas =  miMetodo.EmpresasByServicio(ValorId,"CA");

                        foreach (var items in ListaEmpresasValidas)
                        {
                            miColumna.Items.Add(items);
                        }                        
                    }
                    else
                    {
                        foreach (var items in item.Lista)
                        {
                            miColumna.Items.Add(items.Valor);
                        }
                    }

                    switch (miColumna.HeaderText.ToUpper())
                    {
                        case "EMPRESA": miColumna.Width = 180;
                            break;
                        case "PROYECTO": miColumna.Width = 290;
                            break;
                        default:
                            break;
                    }

                    this.dgvBitacora.Columns.Add(miColumna);
                }
                else
                {
                    DataGridViewTextBoxColumn miColumna = new DataGridViewTextBoxColumn();
                    miColumna.Name = "C" + item.Nombre.Trim();
                    miColumna.HeaderText = item.Nombre.Trim();
                    this.dgvBitacora.Columns.Add(miColumna);
                }
            }

            this.dgvBitacora.Columns.Add("CEsfuerzo", "Esfuerzo");
            this.dgvBitacora.Columns["CEsfuerzo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewColumn column;

            switch (ValorId)
            {
                case 1: //Objetos Sensibles
                    column = dgvBitacora.Columns["CProyecto/Aplicación"];
                    column.Width = 200;

                    column = dgvBitacora.Columns["CProyecto/Aplicación"];
                    column.Width = 200;

                    column = dgvBitacora.Columns["CObjeto Evaluado"];
                    column.Width = 200;

                    break;

                case 2: //Sistemas Operativos
                    column = dgvBitacora.Columns["CProyecto"];
                    column.Width = 200;

                    column = dgvBitacora.Columns["CObservaciones"];
                    column.Width = 200;
                    break;

                case 3: //Software Base
                    column = dgvBitacora.Columns["CProyecto"];
                    column.Width = 200;                    
                    break;

                case 6: //Software Utilitario
                    column = dgvBitacora.Columns["CSolicitante"];
                    column.Width = 200;
                    break;

                case 7: //Vulnerabilidades en aplicativos de producción
                    column = dgvBitacora.Columns["CAplicativo Evaluado"];
                    column.Width = 200;
                    break;

                case 9: //Estándares
                    column = dgvBitacora.Columns["CEstándar/Procedimiento"];
                    column.Width = 200;
                    break;

                case 11: //Informacion Sensible y Logs
                    column = dgvBitacora.Columns["CAplicacion"];
                    column.Width = 200;
                    break;
                    
                case 12: //Nuevos Proyectos
                    column = dgvBitacora.Columns["CTarea"];
                    column.Width = 400;

                    column = dgvBitacora.Columns["CDescripcion tarea"];
                    column.Width = 300;

                    column = dgvBitacora.Columns["CFase"];
                    column.Width = 150;

                    column = dgvBitacora.Columns["CEvidencias"];
                    column.Width = 200;
                    break;

                case 13: //Vulnerabilidades de Infraestructura
                    column = dgvBitacora.Columns["CObservaciones"];
                    column.Width = 200;
                    break;

                case 14: //Cierre de Vulnerabilidades
                    column = dgvBitacora.Columns["CDescripcion"];
                    column.Width = 200;
                    break;

                case 15: //Monitoreo Eventos
                    column = dgvBitacora.Columns["CObservaciones"];
                    column.Width = 200;
                    break;

                case 16: //Autorizaciones Usuarios
                    column = dgvBitacora.Columns["CObservaciones"];
                    column.Width = 200;
                    break;

                default:
                    break;
            }
        }

        private void btnAgregarRegistro_Click(object sender, EventArgs e)
        {
            if (this.dgvBitacora.Columns.Count > 0)
            {
                this.dgvBitacora.Rows.Add(DateTime.Now.ToShortDateString(), DateTime.Now.ToShortDateString());
                dgvBitacora.Rows[dgvBitacora.Rows.Count - 1].Height = 25;
                calcularEsfuerzo();
            }
        }

        private void dgvBitacora_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (e.FormattedValue != null)
                {
                    if ((e.ColumnIndex == 0) || (e.ColumnIndex == dgvBitacora.Columns.Count - 1))
                    {
                        if (e.ColumnIndex == dgvBitacora.Columns.Count - 1) //esfuerzo
                        {
                            if (e.FormattedValue.ToString() == "")
                            {

                            }
                            else
                            {
                                string valor = e.FormattedValue.ToString();
                                valor = valor.Replace(',', '.');

                                dgvBitacora.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = valor;

                                double i = 0;
                                if (!double.TryParse(e.FormattedValue.ToString(), out i))
                                {
                                    MessageBox.Show("El valor ingresado en la columna Esfuerzo debe ser numérico.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    e.Cancel = true;
                                    dgvBitacora.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";

                                }
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            switch (ListaColumnas[e.ColumnIndex - 2].Tipo)
                            {
                                case "Entero":
                                    if (e.FormattedValue.ToString() == "")
                                    {

                                    }
                                    else
                                    {
                                        int i = 0;
                                        if (!int.TryParse(e.FormattedValue.ToString(), out i))
                                        {
                                            MessageBox.Show("El valor ingresado en la columna " + ListaColumnas[e.ColumnIndex - 1].Nombre + " debe ser Entero.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                            e.Cancel = true;
                                            dgvBitacora.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";

                                        }
                                    }
                                   break;                               

                                default:
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnQuitarRegistro_Click(object sender, EventArgs e)
        {
            if (dgvBitacora.SelectedCells.Count > 0)
            {
                foreach (DataGridViewCell item in dgvBitacora.SelectedCells)
                {
                    try
                    {
                        dgvBitacora.Rows.Remove(item.OwningRow);
                        calcularEsfuerzo();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (dgvBitacora.Rows.Count > 0)
            {
                List<ClaseBitacora_CertificacionApp> lstBitacora = new List<ClaseBitacora_CertificacionApp>();
                XmlDocument documento = new XmlDocument();                

                bool ApVal = false;

                foreach (var item in ListaListas)
                {
                    if (Convert.ToInt32(item.Valor) == ValorId)
                    {
                        ApVal = true;
                        break;
                    }
                }

                if (ApVal)
                {
                    foreach (DataGridViewRow row in dgvBitacora.Rows)
                    {
                        try
                        {
                            if ((((Convert.ToDateTime(row.Cells["CFechaInicio"].Value).Date > fechaBloqueo.Date)
                                && (Convert.ToDateTime(row.Cells["CFechaInicio"].Value).Date <= DateTime.Now.Date))
                                &&
                                ((Convert.ToDateTime(row.Cells["CFechaFin"].Value).Date > fechaBloqueo.Date)
                                && (Convert.ToDateTime(row.Cells["CFechaFin"].Value).Date <= DateTime.Now.Date)))
                                &&
                                (Convert.ToDateTime(row.Cells["CFechaFin"].Value) >= Convert.ToDateTime(row.Cells["CFechaInicio"].Value)))
                            {
                                XmlElement bitacora = documento.CreateElement("Servicio");
                                XmlAttribute miAttID = documento.CreateAttribute("idServicio");
                                miAttID.InnerText = ValorId.ToString();
                                bitacora.Attributes.Append(miAttID);

                                XmlAttribute miAttNombre = documento.CreateAttribute("NombreServicio");
                                miAttNombre.InnerText = ValorNombre.ToString();
                                bitacora.Attributes.Append(miAttNombre);
                                ClaseBitacora_CertificacionApp clsBitacora = new ClaseBitacora_CertificacionApp();

                                for (int i = 2; i < ListaColumnas.Count + 2; i++)
                                {
                                    string nombre = ListaColumnas[i - 2].Nombre;
                                    XmlElement valor = documento.CreateElement("C");

                                    XmlAttribute AttNombre = documento.CreateAttribute("Nombre");
                                    AttNombre.InnerText = nombre;
                                    valor.Attributes.Append(AttNombre);

                                    XmlAttribute valorAtributo = documento.CreateAttribute("VALOR");
                                    if (row.Cells[i].Value == null)
                                    {
                                        valorAtributo.InnerText = string.Empty;
                                    }
                                    else
                                    {
                                        valorAtributo.InnerText = row.Cells[i].Value.ToString();
                                    }
                                    valor.Attributes.Append(valorAtributo);
                                    bitacora.AppendChild(valor);
                                }

                                clsBitacora.Detalle = bitacora;
                                clsBitacora.Esfuerzo = Convert.ToDecimal(row.Cells["CEsfuerzo"].Value);
                                clsBitacora.FechaInicio = Convert.ToDateTime(row.Cells["CFechaInicio"].Value);
                                clsBitacora.FechaFin = Convert.ToDateTime(row.Cells["CFechaFin"].Value);
                                clsBitacora.IdServicio = ValorId;
                                clsBitacora.Responsable = UsuarioConectado;
                                clsBitacora.IdBitacora = ValorIdMODIFICAR;

                                lstBitacora.Add(clsBitacora);

                                DateTime fechaFila = new DateTime(0001, 1, 1);
                                DateTime.TryParse(row.Cells["CFechaInicio"].Value.ToString(), out fechaFila);

                                DateTime fechaFinFila = new DateTime(0001, 1, 1);
                                DateTime.TryParse(row.Cells["CFechaFin"].Value.ToString(), out fechaFinFila);

                                if (fechaFila.Date == new DateTime(0001, 1, 1).Date || fechaFinFila.Date == new DateTime(0001, 1, 1).Date)
                                {
                                    //Error
                                    row.Cells["CFechaInicio"].Value = DateTime.Now.Date.ToShortDateString();
                                    row.Cells["CFechaFin"].Value = DateTime.Now.Date.ToShortDateString();
                                    lstBitacora.Clear();
                                    MessageBox.Show("Una de las fechas ingresadas no es válida.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    dgvBitacora.ClearSelection();
                                    row.Selected = true;
                                    break;
                                }

                                switch (ValorId)
                                {
                                    case 12: //Nuevos Proyectos

                                        int fase = 0, tarea = 0;

                                        string f = string.Empty, t = string.Empty;

                                        f = row.Cells["CFase"].Value.ToString();
                                        t = row.Cells["CTarea"].Value.ToString();

                                        fase = Convert.ToInt32(f.Substring(0, f.IndexOf('.')));
                                        tarea = Convert.ToInt32(t.Substring(0, t.IndexOf('.')));

                                        if (fase != tarea)
                                        {
                                            lstBitacora.Clear();
                                            MessageBox.Show("La tarea seleccionada no corresponde a la fase seleccionada.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            dgvBitacora.ClearSelection();
                                            row.Selected = true;
                                            break;
                                        }

                                        if (((row.Cells["CProyecto"].Value) == null)
                                        || ((row.Cells["CFase"].Value) == null)
                                        || ((row.Cells["CTarea"].Value) == null)
                                        || ((row.Cells["CCarga a:"].Value) == null))
                                        {
                                            lstBitacora.Clear();
                                            MessageBox.Show("El proyecto, la fase, la tarea, ni el cargar a deben estar vacíos.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            dgvBitacora.ClearSelection();
                                            row.Selected = true;
                                            break;
                                        }
                                        break;
                                    default:
                                        break;
                                }


                                if (((Convert.ToDouble(row.Cells["CEsfuerzo"].Value)) > 40) || ((Convert.ToDouble(row.Cells["CEsfuerzo"].Value)) == 0))
                                {
                                    lstBitacora.Clear();
                                    MessageBox.Show("El esfuerzo no puede ser mayor a 40 ni igual a 0.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    dgvBitacora.ClearSelection();
                                    row.Selected = true;
                                    break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Alguna de las fechas se encuentra fuera de los rangos permitidos.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //row.Cells["CFechaInicio"]
                                dgvBitacora.ClearSelection();
                                row.Selected = true;
                                lstBitacora.Clear();
                                break;
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Los datos de la fila seleccionada están incompletos o se encuentran incorrectos.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvBitacora.ClearSelection();
                            row.Selected = true;
                            lstBitacora.Clear();
                            break;
                        }
                    }
                }
                else
                {
                    foreach (DataGridViewRow row in dgvBitacora.Rows)
                    {
                        try
                        {
                            if ((((Convert.ToDateTime(row.Cells["CFechaInicio"].Value).Date <= DateTime.Now.Date))
                                &&
                                ((Convert.ToDateTime(row.Cells["CFechaFin"].Value).Date <= DateTime.Now.Date)))
                                &&
                                (Convert.ToDateTime(row.Cells["CFechaFin"].Value) >= Convert.ToDateTime(row.Cells["CFechaInicio"].Value)))
                            {
                                XmlElement bitacora = documento.CreateElement("Servicio");
                                XmlAttribute miAttID = documento.CreateAttribute("idServicio");
                                miAttID.InnerText = ValorId.ToString();
                                bitacora.Attributes.Append(miAttID);

                                XmlAttribute miAttNombre = documento.CreateAttribute("NombreServicio");
                                miAttNombre.InnerText = ValorNombre.ToString();
                                bitacora.Attributes.Append(miAttNombre);
                                ClaseBitacora_CertificacionApp clsBitacora = new ClaseBitacora_CertificacionApp();

                                for (int i = 2; i < ListaColumnas.Count + 2; i++)
                                {
                                    string nombre = ListaColumnas[i - 2].Nombre;
                                    XmlElement valor = documento.CreateElement("C");

                                    XmlAttribute AttNombre = documento.CreateAttribute("Nombre");
                                    AttNombre.InnerText = nombre;
                                    valor.Attributes.Append(AttNombre);

                                    XmlAttribute valorAtributo = documento.CreateAttribute("VALOR");
                                    if (row.Cells[i].Value == null)
                                    {
                                        valorAtributo.InnerText = string.Empty;
                                    }
                                    else
                                    {
                                        valorAtributo.InnerText = row.Cells[i].Value.ToString();
                                    }
                                    valor.Attributes.Append(valorAtributo);
                                    bitacora.AppendChild(valor);
                                }

                                clsBitacora.Detalle = bitacora;
                                clsBitacora.Esfuerzo = Convert.ToDecimal(row.Cells["CEsfuerzo"].Value);
                                clsBitacora.FechaInicio = Convert.ToDateTime(row.Cells["CFechaInicio"].Value);
                                clsBitacora.FechaFin = Convert.ToDateTime(row.Cells["CFechaFin"].Value);
                                clsBitacora.IdServicio = ValorId;
                                clsBitacora.Responsable = UsuarioConectado;
                                clsBitacora.IdBitacora = ValorIdMODIFICAR;

                                lstBitacora.Add(clsBitacora);

                                DateTime fechaFila = new DateTime(0001, 1, 1);
                                DateTime.TryParse(row.Cells["CFechaInicio"].Value.ToString(), out fechaFila);

                                DateTime fechaFinFila = new DateTime(0001, 1, 1);
                                DateTime.TryParse(row.Cells["CFechaFin"].Value.ToString(), out fechaFinFila);

                                if (fechaFila.Date == new DateTime(0001, 1, 1).Date || fechaFinFila.Date == new DateTime(0001, 1, 1).Date)
                                {
                                    //Error
                                    row.Cells["CFechaInicio"].Value = DateTime.Now.Date.ToShortDateString();
                                    row.Cells["CFechaFin"].Value = DateTime.Now.Date.ToShortDateString();
                                    lstBitacora.Clear();
                                    MessageBox.Show("Una de las fechas ingresadas no es válida.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    dgvBitacora.ClearSelection();
                                    row.Selected = true;
                                    break;
                                }

                                switch (ValorId)
                                {
                                    case 12: //Nuevos Proyectos

                                        int fase = 0, tarea = 0;

                                        string f = string.Empty, t = string.Empty;

                                        f = row.Cells["CFase"].Value.ToString();
                                        t = row.Cells["CTarea"].Value.ToString();

                                        fase = Convert.ToInt32(f.Substring(0, f.IndexOf('.')));
                                        tarea = Convert.ToInt32(t.Substring(0, t.IndexOf('.')));

                                        if (fase != tarea)
                                        {
                                            lstBitacora.Clear();
                                            MessageBox.Show("La tarea seleccionada no corresponde a la fase seleccionada.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            dgvBitacora.ClearSelection();
                                            row.Selected = true;
                                            break;
                                        }

                                        if (((row.Cells["CProyecto"].Value) == null)
                                        || ((row.Cells["CFase"].Value) == null)
                                        || ((row.Cells["CTarea"].Value) == null)
                                        || ((row.Cells["CCarga a:"].Value) == null))
                                        {
                                            lstBitacora.Clear();
                                            MessageBox.Show("El proyecto, la fase, la tarea, ni el cargar a deben estar vacíos.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            dgvBitacora.ClearSelection();
                                            row.Selected = true;
                                            break;
                                        }
                                        break;
                                    default:
                                        break;
                                }


                                if (((Convert.ToDouble(row.Cells["CEsfuerzo"].Value)) > 40) || ((Convert.ToDouble(row.Cells["CEsfuerzo"].Value)) == 0))
                                {
                                    lstBitacora.Clear();
                                    MessageBox.Show("El esfuerzo no puede ser mayor a 40 ni igual a 0.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    dgvBitacora.ClearSelection();
                                    row.Selected = true;
                                    break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Alguna de las fechas se encuentra fuera de los rangos permitidos.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //row.Cells["CFechaInicio"]
                                dgvBitacora.ClearSelection();
                                row.Selected = true;
                                lstBitacora.Clear();
                                break;
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Los datos de la fila seleccionada están incompletos o se encuentran incorrectos.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvBitacora.ClearSelection();
                            row.Selected = true;
                            lstBitacora.Clear();
                            break;
                        }
                    }
                }


                

                if ((ValorIdMODIFICAR > 0) && (lstBitacora.Count > 0))
                {
                    try
                    {
                        MetodoBitacora_CertificacionAplicaciones mtBitacora = new MetodoBitacora_CertificacionAplicaciones();
                        int res = mtBitacora.Bitacora_CertificacionApp_UpdateDetalle(lstBitacora);
                        dgvBitacora.Rows.Clear();
                        MessageBox.Show("Los registros han sido actualizados exitosamente.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.txtTotalHoras.Text = "0";
                        this.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Existió un error al grabar la información.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (lstBitacora.Count > 0)
                {
                    try
                    {
                        MetodoBitacora_CertificacionAplicaciones mtBitacora = new MetodoBitacora_CertificacionAplicaciones();
                        int res = mtBitacora.Bitacora_CertificacionApp_InsertarDetalle(lstBitacora);
                        dgvBitacora.Rows.Clear();
                        MessageBox.Show("Los registros han sido guardados exitosamente.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtTotalHoras.Text = "0";
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Existió un error al grabar la información.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            calcularEsfuerzo();
        }

        //DateTimePicker oDateTimePicker = new DateTimePicker();

        private void dgvBitacora_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //    try
            //    {
            //        if ((e.ColumnIndex == 0) && (e.RowIndex > -1))
            //        {
            //            //Initialized a new DateTimePicker Control  
            //            oDateTimePicker = new DateTimePicker();

            //            //Adding DateTimePicker control into DataGridView   
            //            dgvBitacora.Controls.Add(oDateTimePicker);

            //            // Setting the format (i.e. 2014-10-10)  
            //            oDateTimePicker.Format = DateTimePickerFormat.Short;

            //            // It returns the retangular area that represents the Display area for a cell  
            //            Rectangle oRectangle = dgvBitacora.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

            //            //Setting area for DateTimePicker Control  
            //            oDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);

            //            // Setting Location  
            //            oDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);

            //            // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
            //            oDateTimePicker.CloseUp += new EventHandler(oDateTimePicker_CloseUp);

            //            // An event attached to dateTimePicker Control which is fired when any date is selected  
            //            oDateTimePicker.TextChanged += new EventHandler(dateTimePicker_OnTextChange);

            //            // Now make it visible  
            //            oDateTimePicker.Visible = true;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        log.WriteLine("Error(dgvBitacora_CellClick) - " + ex.Message.ToString());
            //        throw;
            //    }
        }

        //private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Saving the 'Selected Date on Calendar' into DataGridView current cell  
        //        dgvBitacora.CurrentCell.Value = oDateTimePicker.Text.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        log.WriteLine("Error(dateTimePicker_OnTextChange) - " + ex.Message.ToString());
        //        throw;
        //    }
        //}

        //void oDateTimePicker_CloseUp(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Hiding the control after use   
        //        oDateTimePicker.Visible = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        log.WriteLine("Error(oDateTimePicker_CloseUp) - " + ex.Message.ToString());
        //        throw;
        //    }
        //}

        private void dgvBitacora_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                

                if ((e.ColumnIndex == 0) || (e.ColumnIndex == 1)) //Fechas
                {

                    DataGridViewCell CeldaActual = dgvBitacora.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    CeldaActual.Style.BackColor = dgvBitacora.Rows[e.RowIndex].Cells[dgvBitacora.Columns.Count - 1].Style.BackColor;

                    DataGridViewCell CeldaFechaInicio = dgvBitacora.Rows[e.RowIndex].Cells[0];
                    DataGridViewCell CeldaFechaFin = dgvBitacora.Rows[e.RowIndex].Cells[1];

                    DateTime ResultadoCA;

                    if (!DateTime.TryParse(CeldaActual.Value.ToString(), out ResultadoCA))
                    {
                        CeldaFechaInicio.Value = DateTime.Now.ToShortDateString(); 
                        CeldaFechaFin.Value = CeldaFechaInicio.Value;
                    }


                    if (CeldaActual.Value.ToString() != "")
                    {
                        bool ApVal = false;

                        foreach (var item in ListaListas)
                        {
                            if (Convert.ToInt32(item.Valor) == ValorId)
                            {
                                ApVal = true;
                                break;
                            }
                        }

                        if (ApVal)
                        {
                            if (Convert.ToDateTime(CeldaActual.Value.ToString()) <= fechaBloqueo)
                            {
                                CeldaActual.Value = fechaBloqueo.AddDays(1).ToShortDateString();
                                MessageBox.Show("No se pueden ingresar registros de fechas anteriores al " + fechaBloqueo.ToShortDateString() + ".", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else if (Convert.ToDateTime(CeldaActual.Value.ToString()) > DateTime.Now)
                            {
                                CeldaActual.Value = DateTime.Now.ToShortDateString();
                                MessageBox.Show("No se pueden ingresar registros de fechas posteriores al día de hoy.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                if ((CeldaFechaInicio.Value.ToString() != string.Empty) && (CeldaFechaFin.Value.ToString() != string.Empty))
                                {
                                    if (Convert.ToDateTime(CeldaFechaFin.Value) < Convert.ToDateTime(CeldaFechaInicio.Value))
                                    {
                                        MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        CeldaFechaFin.Value = CeldaFechaInicio.Value;
                                    }
                                }

                            }
                        }
                        else
                        {
                            if (Convert.ToDateTime(CeldaActual.Value.ToString()) > DateTime.Now)
                            {
                                CeldaActual.Value = DateTime.Now.ToShortDateString();
                                MessageBox.Show("No se pueden ingresar registros de fechas posteriores al día de hoy.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                if ((CeldaFechaInicio.Value.ToString() != string.Empty) && (CeldaFechaFin.Value.ToString() != string.Empty))
                                {
                                    if (Convert.ToDateTime(CeldaFechaFin.Value) < Convert.ToDateTime(CeldaFechaInicio.Value))
                                    {
                                        MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        CeldaFechaFin.Value = CeldaFechaInicio.Value;
                                    }
                                }

                            }
                        }
                    }
                }

                if (dgvBitacora.Columns["CEsfuerzo"].Index == e.ColumnIndex)
                {
                    double valor = 0;
                    string numero = dgvBitacora.Rows[e.RowIndex].Cells["CEsfuerzo"].Value.ToString();
                    numero = numero.Replace(',', '.');
                    dgvBitacora.Rows[e.RowIndex].Cells["CEsfuerzo"].Value = numero;

                    double.TryParse(dgvBitacora.Rows[e.RowIndex].Cells["CEsfuerzo"].Value.ToString(), out valor);
                    dgvBitacora.Rows[e.RowIndex].Cells["CEsfuerzo"].Value = valor;
                    calcularEsfuerzo();
                }



            }
            catch (Exception)
            {

            }
        }

        private void calcularEsfuerzo()
        {
            double total = 0;

            foreach (DataGridViewRow row in dgvBitacora.Rows)
            {
                total = total + Convert.ToDouble(dgvBitacora.Rows[row.Index].Cells["CEsfuerzo"].Value);
            }

            txtTotalHoras.Text = total.ToString();
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            if (this.dgvBitacora.SelectedRows.Count > 0)
            {

                copiarFila(this.dgvBitacora.SelectedRows[0]);
                calcularEsfuerzo();
            }
        }

        private void FrmBitacora_CA_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClaseLogsConexion claseLog = new ClaseLogsConexion();
            claseLog.Accion = "Cerró el formulario";
            claseLog.Autor = Environment.UserName;
            claseLog.IpOrigen = ipEquipo;
            claseLog.Formulario = "Bitácora Certificación de Aplicaciones - " + lblBitacora.Text.Trim();

            MetodoLogsConexion metLog = new MetodoLogsConexion();
            metLog.LogsConexion_Insert(claseLog);
        }

        private void dgvBitacora_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            dgvBitacora.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Empty;
        }
    }
}
