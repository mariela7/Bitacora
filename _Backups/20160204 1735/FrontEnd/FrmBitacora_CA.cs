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
        public string ValorNombre = string.Empty;
        public int ValorId;
        public int ValorIdMODIFICAR;
        public DataGridViewRow ValorRowMODIFICAR;
        List<ClaseServiciosDetalle_CertificacionAplicaciones> ListaColumnas;
        string UsuarioConectado = Environment.UserName;

        public FrmBitacora_CA()
        {
            InitializeComponent();
        }

        StreamWriter log;

        private void FrmBitacora_CA_Load(object sender, EventArgs e)
        {
            string fecha = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString().PadLeft(2, '0') + DateTime.Today.Day.ToString().PadLeft(2, '0');
            string aaa = Environment.CurrentDirectory;
            string archivoLog = aaa + @"\Log_" + fecha + ".txt";

            if (System.IO.File.Exists(archivoLog))
            {
                File.Delete(archivoLog);
                log = File.CreateText(archivoLog);
            }
            else
            {
                log = File.CreateText(archivoLog);
            }


            this.WindowState = FormWindowState.Maximized;
            this.Text = ValorNombre;
            this.lblBitacora.Text = ValorNombre;
            LlenarColumnasGrid();

            this.dgvBitacora.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;

            if (ValorIdMODIFICAR > 0)
            {
                this.dgvBitacora.Columns.Add("Cid", "Id");

                this.dgvBitacora.Columns["Cid"].Visible = false;

                this.btnCopiar.Enabled = false;
                copiarFila(ValorRowMODIFICAR);

                this.dgvBitacora.Rows[this.dgvBitacora.Rows.Count - 1].Cells["Cid"].Value = ValorIdMODIFICAR;

                //this.dgvBitacora.Rows.Add(ValorRowMODIFICAR);

                this.btnAgregarRegistro.Enabled = false;
                this.btnQuitarRegistro.Enabled = false;
            }

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

            this.dgvBitacora.Columns.Add("CFecha", "Fecha");
            foreach (ClaseServiciosDetalle_CertificacionAplicaciones item in ListaColumnas)
            {
                if (item.EsLista)
                {
                    DataGridViewComboBoxColumn miColumna = new DataGridViewComboBoxColumn();
                    miColumna.Name = "C" + item.Nombre.Trim();
                    miColumna.HeaderText = item.Nombre.Trim();

                    foreach (var items in item.Lista)
                    {
                        miColumna.Items.Add(items.Valor);
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
        }

        private void btnAgregarRegistro_Click(object sender, EventArgs e)
        {
            if (this.dgvBitacora.Columns.Count > 0)
            {
                this.dgvBitacora.Rows.Add(DateTime.Now.ToShortDateString());
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
                    if (e.ColumnIndex == 0 || e.ColumnIndex == dgvBitacora.Columns.Count -1)
                    {

                    }
                    else
                    {
                        try
                        {
                            switch (ListaColumnas[e.ColumnIndex - 1].Tipo)
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
                                            MessageBox.Show("El valor ingresado en la columna " + ListaColumnas[e.ColumnIndex - 1].Nombre + " debe ser Entero.");
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
                            log.WriteLine("Error(dgvBitacora_CellValidating) 1 - " + ex.Message.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.WriteLine("Error(dgvBitacora_CellValidating) 2 - " + ex.Message.ToString());
                throw;
            }
        }

        private void btnQuitarRegistro_Click(object sender, EventArgs e)
        {
            if (dgvBitacora.SelectedCells.Count > 0 )
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

                List<ClaseBitacora_CertificacionAplicaciones> lstBitacora = new List<ClaseBitacora_CertificacionAplicaciones>();
                XmlDocument documento = new XmlDocument();
                foreach (DataGridViewRow row in dgvBitacora.Rows)
                {

                    XmlElement bitacora = documento.CreateElement("Servicio");
                    XmlAttribute miAttID = documento.CreateAttribute("idServicio");
                    miAttID.InnerText = ValorId.ToString();
                    bitacora.Attributes.Append(miAttID);

                    XmlAttribute miAttNombre = documento.CreateAttribute("NombreServicio");
                    miAttNombre.InnerText = ValorNombre.ToString();
                    bitacora.Attributes.Append(miAttNombre);
                    ClaseBitacora_CertificacionAplicaciones clsBitacora = new ClaseBitacora_CertificacionAplicaciones();

                    for (int i = 1; i < ListaColumnas.Count + 1; i++)
                    {
                        string nombre = ListaColumnas[i - 1].Nombre;
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
                    clsBitacora.Fecha = Convert.ToDateTime(row.Cells["CFecha"].Value);
                    clsBitacora.IdServicio = ValorId;
                    clsBitacora.Responsable = UsuarioConectado;
                    clsBitacora.IdBitacora = ValorIdMODIFICAR;

                    lstBitacora.Add(clsBitacora);
                }

                if (ValorIdMODIFICAR > 0 )
                {
                    try
                    {
                        MetodoBitacora_CertificacionAplicaciones mtBitacora = new MetodoBitacora_CertificacionAplicaciones();
                        int res = mtBitacora.Bitacora_CertificacionApp_UpdateDetalle(lstBitacora);
                        dgvBitacora.Rows.Clear();
                        MessageBox.Show("Registros Actualizados con éxito!!!");
                        this.txtTotalHoras.Text = "0";
                        this.Close();
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Error al guardar los registros...!!!");
                    }
                }
                else
                {
                    try
                    {
                        MetodoBitacora_CertificacionAplicaciones mtBitacora = new MetodoBitacora_CertificacionAplicaciones();
                        int res = mtBitacora.Bitacora_CertificacionApp_InsertarDetalle(lstBitacora);
                        dgvBitacora.Rows.Clear();
                        MessageBox.Show("Registros guardados con éxito!!!");
                        this.txtTotalHoras.Text = "0";
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Error al guardar los registros...!!!");
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
                if (dgvBitacora.Columns["CEsfuerzo"].Index == e.ColumnIndex)
                {
                    double valor = 0;
                    double.TryParse(dgvBitacora.Rows[e.RowIndex].Cells["CEsfuerzo"].Value.ToString(), out valor);
                    dgvBitacora.Rows[e.RowIndex].Cells["CEsfuerzo"].Value = valor;
                    calcularEsfuerzo();
                }
            }
            catch (Exception ex)
            {
                log.WriteLine("Error(dgvBitacora_CellEndEdit) - " + ex.Message.ToString());
                throw;
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
            log.Close();

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
            claseLog.Formulario = "Bitácora Ingeniería de Seguridad y Servicios Comunes";

            MetodoLogsConexion metLog = new MetodoLogsConexion();
            metLog.LogsConexion_Insert(claseLog);
        }

        private void dgvBitacora_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            dgvBitacora.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Empty;
        }
    }
}
