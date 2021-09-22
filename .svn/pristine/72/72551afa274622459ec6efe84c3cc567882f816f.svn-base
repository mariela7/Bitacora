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

namespace FrontEnd
{
    public partial class FrmBaseConocimientoIngreso : Form
    {
        //private static FrmBaseConocimientoIngreso m_FormDefInstance;
        //public static FrmBaseConocimientoIngreso DefInstance
        //{
        //    get
        //    {
        //        if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
        //        {
        //            m_FormDefInstance = new FrmBaseConocimientoIngreso();
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

        string UsuarioConectado = Environment.UserName;
        private int idBuscar;
        private string nombreBuscar;
        string ipEquipo = string.Empty;

        public FrmBaseConocimientoIngreso()
        {
            InitializeComponent();
        }        
        
        private void FrmBaseConocimientoIngreso_Load(object sender, EventArgs e)
        {
            Limpiar();
            getCategorias();

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
            claseLog.Formulario = "Base de Conocimientos - Ingreso";

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

        private void getCategorias()
        {
            this.CmbCategorias.Items.Clear();
            List<LogicaNegocios.Clases.ClaseConocimientoCategoria> miListaCat = new List<LogicaNegocios.Clases.ClaseConocimientoCategoria>();
            LogicaNegocios.Metodos.MetodoConocimiento miMetodo = new LogicaNegocios.Metodos.MetodoConocimiento();

            miListaCat = miMetodo.GetCategorias();

            foreach (var item in miListaCat)
            {
                ComboboxItem miItem = new ComboboxItem();
                miItem.Text = item.Nombre;
                miItem.Value = item.Id;
                this.CmbCategorias.Items.Add(miItem);
            }
        }

        private void Limpiar()
        {
            idBuscar = 0;
            nombreBuscar = string.Empty;
            /*this.txtDetalle.Clear();*/
            rtxtContenido.Clear();
            this.TxtNombre.Clear();
            this.TxtObservaciones.Clear();
        }

        private void getDetalle(int IdCab)
        {
            //Limpiar();

            LogicaNegocios.Clases.ClaseConocimientoDetalle miDet = new LogicaNegocios.Clases.ClaseConocimientoDetalle();
            LogicaNegocios.Metodos.MetodoConocimiento miMetodo = new LogicaNegocios.Metodos.MetodoConocimiento();

            miDet = miMetodo.GetDetalle(IdCab);

            this.TxtNombre.Text = nombreBuscar;
            //this.txtDetalle.Text = miDet.Texto;
            rtxtContenido.Rtf = miDet.Texto;
            this.TxtObservaciones.Text = miDet.Observaciones;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtxtContenido.Text.Trim()/*this.txtDetalle.Text.Trim()*/) || string.IsNullOrEmpty(this.TxtNombre.Text.Trim()) || string.IsNullOrEmpty(this.TxtObservaciones.Text.Trim()) || this.CmbCategorias.SelectedIndex < 0)
            {
                MessageBox.Show("Favor completar todos los campos.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (idBuscar == 0)
                {
                    LogicaNegocios.Clases.ClaseConocimientoDetalle miDet = new LogicaNegocios.Clases.ClaseConocimientoDetalle();
                    LogicaNegocios.Clases.ClaseConocimientoCabecera micab = new LogicaNegocios.Clases.ClaseConocimientoCabecera();
                    LogicaNegocios.Metodos.MetodoConocimiento miMetodo = new LogicaNegocios.Metodos.MetodoConocimiento();

                    micab.Nombre = this.TxtNombre.Text.Trim();

                    ComboboxItem miItem = (ComboboxItem)this.CmbCategorias.SelectedItem;
                    micab.IdCab = Convert.ToInt32(miItem.Value);

                    //string richText = new TextRange(richTextBox1.Rtf .Document.ContentStart, richTextBox1.Document.ContentEnd).Text;
                    //string s = WebUtility.HtmlEncode(richText);


                    miDet.Texto = rtxtContenido.Rtf; //this.txtDetalle.Text.Trim();
                    miDet.Observaciones = this.TxtObservaciones.Text.Trim();
                    miDet.responsable = UsuarioConectado;

                    try
                    {
                        miMetodo.SaveDetalle(micab, miDet);
                        MessageBox.Show("Datos guardados exitosamente.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    LogicaNegocios.Clases.ClaseConocimientoDetalle miDet = new LogicaNegocios.Clases.ClaseConocimientoDetalle();
                    LogicaNegocios.Clases.ClaseConocimientoCabecera micab = new LogicaNegocios.Clases.ClaseConocimientoCabecera();
                    LogicaNegocios.Metodos.MetodoConocimiento miMetodo = new LogicaNegocios.Metodos.MetodoConocimiento();

                    micab.Nombre = this.TxtNombre.Text.Trim();


                    ComboboxItem miItem = (ComboboxItem)this.CmbCategorias.SelectedItem;
                    micab.IdCab = Convert.ToInt32(miItem.Value);

                    micab.Id = idBuscar;

                    miDet.Texto = rtxtContenido.Rtf;//this.txtDetalle.Text.Trim();
                    miDet.Observaciones = this.TxtObservaciones.Text.Trim();
                    miDet.responsable = UsuarioConectado;

                    try
                    {
                        miMetodo.UpdateDetalle(micab, miDet);

                        //AQUI HAY Q HACER UN UPDATE
                        MessageBox.Show("Datos guardados exitosamente.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            FrmBaseConocimientoBuscar mifrm = new FrmBaseConocimientoBuscar();
            mifrm.ShowDialog();
            idBuscar = mifrm.NuevoID;
            nombreBuscar = mifrm.NuevoNombre;
            if (idBuscar > 0)
            {
                getDetalle(idBuscar);
            }
            
            this.CmbCategorias.SelectedIndex = Convert.ToInt32(mifrm.NuevaCat);
        }

        private void btnNegrita_Click(object sender, EventArgs e)
        {
            int inicio = rtxtContenido.SelectionStart;
            int largo = rtxtContenido.SelectionLength;

            if (rtxtContenido.SelectionFont != null)
            {
                System.Drawing.Font currentFont = rtxtContenido.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (rtxtContenido.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }

                rtxtContenido.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFontStyle
                );
            }

            rtxtContenido.Focus();
            rtxtContenido.Select(inicio, largo);
        }

        private void btnCursiva_Click(object sender, EventArgs e)
        {
            int inicio = rtxtContenido.SelectionStart;
            int largo = rtxtContenido.SelectionLength;

            if (rtxtContenido.SelectionFont != null)
            {
                System.Drawing.Font currentFont = rtxtContenido.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (rtxtContenido.SelectionFont.Italic == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Italic;
                }

                rtxtContenido.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFontStyle
                );
            }

            rtxtContenido.Focus();
            rtxtContenido.Select(inicio, largo);
        }

        private void btnSubrayado_Click(object sender, EventArgs e)
        {
            int inicio = rtxtContenido.SelectionStart;
            int largo = rtxtContenido.SelectionLength;

            if (rtxtContenido.SelectionFont != null)
            {
                System.Drawing.Font currentFont = rtxtContenido.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (rtxtContenido.SelectionFont.Underline == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Underline;
                }

                rtxtContenido.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFontStyle
                );
            }

            rtxtContenido.Focus();
            rtxtContenido.Select(inicio, largo);
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            int inicio = rtxtContenido.SelectionStart;
            int largo = rtxtContenido.SelectionLength;

            if (rtxtContenido.SelectionFont != null)
            {
                int actualSize = Convert.ToInt32(rtxtContenido.SelectionFont.Size);
                string actualFont = rtxtContenido.Font.Name;

                int newSize = actualSize + 1;

                if (newSize <= 14)
                {
                    System.Drawing.Font currentFont = rtxtContenido.SelectionFont;

                    rtxtContenido.SelectionFont = new Font(
                           currentFont.FontFamily,
                           newSize,
                           currentFont.Style
                        );
                }
            }

            rtxtContenido.Focus();
            rtxtContenido.Select(inicio, largo);
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            int inicio = rtxtContenido.SelectionStart;
            int largo = rtxtContenido.SelectionLength;

            if (rtxtContenido.SelectionFont != null)
            {
                int actualSize = Convert.ToInt32(rtxtContenido.SelectionFont.Size);
                string actualFont = rtxtContenido.Font.Name;

                int newSize = actualSize - 1;

                if (newSize >= 8)
                {
                    System.Drawing.Font currentFont = rtxtContenido.SelectionFont;

                    rtxtContenido.SelectionFont = new Font(
                           currentFont.FontFamily,
                           newSize,
                           currentFont.Style
                        );
                }
            }

            rtxtContenido.Focus();
            rtxtContenido.Select(inicio, largo);
        }

        private void FrmBaseConocimientoIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClaseLogsConexion claseLog = new ClaseLogsConexion();
            claseLog.Accion = "Cerró el formulario";
            claseLog.Autor = Environment.UserName;
            claseLog.IpOrigen = ipEquipo;
            claseLog.Formulario = "Base de Conocimientos - Ingreso";

            MetodoLogsConexion metLog = new MetodoLogsConexion();
            metLog.LogsConexion_Insert(claseLog);
        }
    }
}
