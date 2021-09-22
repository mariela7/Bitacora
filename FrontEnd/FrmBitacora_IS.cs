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
    public partial class FrmBitacora_IS : Form
    {
        //private static FrmBitacora_IS m_FormDefInstance;
        //public static FrmBitacora_IS DefInstance
        //{
        //    get
        //    {
        //        if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
        //        {
        //            m_FormDefInstance = new FrmBitacora_IS();
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

        public int IdBitacora;
        public int IdCategoria;
        public int IdServicio;

        public FrmBitacora_IS()
        {
            InitializeComponent();
        }

        MetodoCategorias_IngenieriaSeguridad metCategoria = new MetodoCategorias_IngenieriaSeguridad();
        MetodoEmpresas_IngenieriaSeguridad metEmpresa = new MetodoEmpresas_IngenieriaSeguridad();
        MetodoBitacora_IngenieriaSeguridad metBitacora = new MetodoBitacora_IngenieriaSeguridad();
        MetodoServicios_IngenieriaSeguridad metServicio = new MetodoServicios_IngenieriaSeguridad();

        List<ClaseCategorias_IngenieriaSeguridad> ListaCategorias = new List<ClaseCategorias_IngenieriaSeguridad>();
        List<ClaseEmpresas_IngenieriaSeguridad> ListaEmpresas = new List<ClaseEmpresas_IngenieriaSeguridad>();
        List<ClaseServicios_IngenieriaSeguridad> ListaServicios = new List<ClaseServicios_IngenieriaSeguridad>();

        string UsuarioConectado = Environment.UserName;

        #region Funciones
        public void LlenarEmpresa()
        {
            ListaEmpresas = metEmpresa.Empresas_IngenieriaSeguridad_SelectAll();
            ListaEmpresas = ListaEmpresas.OrderBy(x => x.NombreEmpresa).ToList();
            ddlEmpresa.DataSource = ListaEmpresas;
            ddlEmpresa.ValueMember = "IdEmpresa";
            ddlEmpresa.DisplayMember = "NombreEmpresa";

            LlenarServicios(ddlEmpresa.Text.Trim());
        }

        public void LlenarServicios(string empresa)
        {
            ListaServicios = new List<ClaseServicios_IngenieriaSeguridad>();
            ListaServicios = metServicio.Servicios_IngenieriaSeguridad_SelectByEmpresa(empresa);
            ListaServicios = ListaServicios.OrderBy(x => x.NombreServicio).ToList();
            ddlServicio.DataSource = ListaServicios;
            ddlServicio.ValueMember = "IdServicio";
            ddlServicio.DisplayMember = "NombreServicio";

            if (ListaServicios.Count > 0)
            {
                LlenarCategorias(ListaServicios[ddlServicio.SelectedIndex].IdServicio);
            }
            else
            {
                ddlCategoria.Visible = false;
                lblCategoria.Visible = false;
            }
        }

        public void LlenarCategorias(int idServicio)
        {
            bool poseeTareas = ListaServicios[ddlServicio.SelectedIndex].PoseeTareas;

            if (poseeTareas)
            {
                ddlCategoria.Visible = true;
                lblCategoria.Visible = true;

                ListaCategorias = metCategoria.Categorias_IngenieriaSeguridad_SelectbyIdServicio(idServicio);
                ListaCategorias = ListaCategorias.OrderBy(x => x.DescripcionCategoria).ToList();
                ddlCategoria.DataSource = ListaCategorias;
                ddlCategoria.ValueMember = "IdCategoria";
                ddlCategoria.DisplayMember = "DescripcionCategoria";
            }
            else
            {
                ddlCategoria.Visible = false;
                lblCategoria.Visible = false;
            }
        }

        public void LimpiarCampos()
        {
            txtTarea.Text = string.Empty;
            txtEsfuerzo.Text = string.Empty;
            txtEvidencia.Text = string.Empty;
            mtcFecha.SelectionEnd = DateTime.Now;
            IdBitacora = 0;
            IdCategoria = 0;
            IdServicio = 0;
            chkHoraExtra.Checked = false;
        }

        public void LlenarCajas()
        {
            if (IdBitacora != 0)
            {
                ClaseBitacora_IngenieriaSeguridad clsBitacora = new ClaseBitacora_IngenieriaSeguridad();
                clsBitacora = metBitacora.Bitacora_IngenieriaSeguridad_SelectByIdResgistro(IdBitacora);

                ddlEmpresa.SelectedValue = clsBitacora.IdEmpresa;
                ddlServicio.SelectedValue = IdServicio;
                ddlCategoria.SelectedValue = IdCategoria;

                mtcFecha.SelectionStart = clsBitacora.FechaInicio;
                mtcFecha.SelectionEnd = clsBitacora.FechaFin;
                txtTarea.Text = clsBitacora.Tarea;
                txtEvidencia.Text = clsBitacora.Evidencia;
                txtEsfuerzo.Text = clsBitacora.Esfuerzo.ToString();
            }
        }

        private string EliminarSaltosDeLinea(string cadena)
        {
            cadena = cadena.Replace(System.Environment.NewLine, " ");

            cadena = cadena.Replace(System.Environment.NewLine, " ");

            cadena = cadena.Replace("\"", "");

            return cadena;
        }
        #endregion

        #region Validaciones
        private void txtEsfuerzo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= 48 && e.KeyChar <= 57) ||
                (e.KeyChar == 46) ||
                (e.KeyChar == 8) ||
                (e.KeyChar == 127) ||
                (Control.ModifierKeys == Keys.Control)) == false)
            {
                MessageBox.Show("Son válidos números y el símbolo \".\" únicamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtTarea_KeyPress(object sender, KeyPressEventArgs e)
        {
            int letra = e.KeyChar;

            if (((e.KeyChar >= 48 && e.KeyChar <= 57) ||
                    (e.KeyChar >= 65 && e.KeyChar <= 90) ||
                    (e.KeyChar >= 97 && e.KeyChar <= 122) ||
                    (e.KeyChar == 8) || (e.KeyChar == 95) || (e.KeyChar == 44) || (e.KeyChar == 46) || (e.KeyChar == 41) ||
                    (e.KeyChar == 45) || (e.KeyChar == 32) || (e.KeyChar == 127) || (e.KeyChar == 40) || (e.KeyChar == 58) || (e.KeyChar == 92) ||
                    (e.KeyChar == 160) || (e.KeyChar == 130) || (e.KeyChar == 161) || (e.KeyChar == 162) || (e.KeyChar == 163) || (e.KeyChar == 239) ||

                    (e.KeyChar == 193) || (e.KeyChar == 201) || (e.KeyChar == 205) || (e.KeyChar == 211) || (e.KeyChar == 218) ||

                    (e.KeyChar == 225) || (e.KeyChar == 233) || (e.KeyChar == 237) || (e.KeyChar == 243) || (e.KeyChar == 250) ||
                    (e.KeyChar == 209) || (e.KeyChar == 241) ||
                    (Control.ModifierKeys == Keys.Control)) == false)

                //09, AZ, az, ◘_,.)-\⌂(:\áé\áéíóú´úÁÉÍÓÚ

            {
                MessageBox.Show("Ingresar letras y números solamente. También se permite el uso de '-' y '_'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtEvidencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= 48 && e.KeyChar <= 57) ||
                    (e.KeyChar >= 65 && e.KeyChar <= 90) ||
                    (e.KeyChar >= 97 && e.KeyChar <= 122) ||
                    (e.KeyChar == 8) || (e.KeyChar == 95) || (e.KeyChar == 44) || (e.KeyChar == 46) || (e.KeyChar == 41) ||
                    (e.KeyChar == 45) || (e.KeyChar == 32) || (e.KeyChar == 127) || (e.KeyChar == 40) || (e.KeyChar == 58) || (e.KeyChar == 92) ||
                    (e.KeyChar == 160) || (e.KeyChar == 130) || (e.KeyChar == 161) || (e.KeyChar == 162) || (e.KeyChar == 163) || (e.KeyChar == 239) ||
                    (e.KeyChar == 225) || (e.KeyChar == 233) || (e.KeyChar == 237) || (e.KeyChar == 243) || (e.KeyChar == 250) ||
                    (e.KeyChar == 209) || (e.KeyChar == 241) ||
                    (Control.ModifierKeys == Keys.Control)) == false)
            {
                MessageBox.Show("Ingresar letras y números solamente. También se permite el uso de '-' y '_'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtTarea_Leave(object sender, EventArgs e)
        {
            string cajaTexto = txtTarea.Text.Trim();
            bool error = false;

            for (int i = 0; i < cajaTexto.Length; i++)
            {
                int codLetra = Encoding.ASCII.GetBytes(cajaTexto[i].ToString())[0];

                if ((codLetra >= 48 && codLetra <= 57) ||
                    (codLetra >= 65 && codLetra <= 90) ||
                    (codLetra >= 97 && codLetra <= 122) ||
                    (codLetra == 95) || (codLetra == 44) || (codLetra == 46) || (codLetra == 41) ||
                    (codLetra == 45) || (codLetra == 32) || (codLetra == 40) || (codLetra == 58) || (codLetra == 92) ||
                    (codLetra == 160) || (codLetra == 130) || (codLetra == 161) || (codLetra == 162) || (codLetra == 163) || (codLetra == 239) || 
                    (codLetra == 181) || (codLetra == 144) || (codLetra == 214) || (codLetra == 224) || (codLetra == 233) || 
                    (codLetra == 63) ||
                    (cajaTexto[i].ToString() == "á") || (cajaTexto[i].ToString() == "é")
                        || (cajaTexto[i].ToString() == "í") || (cajaTexto[i].ToString() == "ó") || (cajaTexto[i].ToString() == "ú") ||
                    (cajaTexto[i].ToString() == "Á") || (cajaTexto[i].ToString() == "É")
                        || (cajaTexto[i].ToString() == "Í") || (cajaTexto[i].ToString() == "Ó") || (cajaTexto[i].ToString() == "Ú")
                    )
                {
                    errorProviderTarea.SetError(this.txtTarea, String.Empty);
                    errorProviderTarea.Clear();
                }
                else
                {
                    txtTarea.Focus();
                    string caracter = string.Empty;
                    if (Encoding.ASCII.GetBytes(cajaTexto[i].ToString())[0] == 13)
                    {
                        caracter = "Enter";
                    }
                    else
                    {
                        caracter = cajaTexto[i].ToString();
                    }

                    errorProviderTarea.SetError(this.txtTarea, "EL cáracter \"" + caracter + "\" no está permitido.");
                    error = true;
                    break;
                }
            }

            if (error == false)
            {
                errorProviderTarea.Clear();
            }
        }

        private void txtEvidencia_Leave(object sender, EventArgs e)
        {
            string cajaTexto = txtEvidencia.Text.Trim();
            for (int i = 0; i < cajaTexto.Length; i++)
            {

                int codLetra = Encoding.ASCII.GetBytes(cajaTexto[i].ToString())[0];

                if ((codLetra >= 48 && codLetra <= 57) ||
                    (codLetra >= 65 && codLetra <= 90) ||
                    (codLetra >= 97 && codLetra <= 122) ||
                    (codLetra == 95) || (codLetra == 44) || (codLetra == 46) || (codLetra == 41) ||
                    (codLetra == 45) || (codLetra == 32) || (codLetra == 40) || (codLetra == 58) || (codLetra == 92) ||
                    (codLetra == 160) || (codLetra == 130) || (codLetra == 161) || (codLetra == 162) || (codLetra == 163) || (codLetra == 239)
                    || (codLetra == 63)
                    ||
                    (cajaTexto[i].ToString() == "á") || (cajaTexto[i].ToString() == "é")
                        || (cajaTexto[i].ToString() == "í") || (cajaTexto[i].ToString() == "ó") || (cajaTexto[i].ToString() == "ú")
                    )
                {
                    errorProviderEvidencia.SetError(this.txtEvidencia, String.Empty);
                }
                else if ((cajaTexto[i].ToString() == "á") || (cajaTexto[i].ToString() == "é")
                        || (cajaTexto[i].ToString() == "í") || (cajaTexto[i].ToString() == "ó") || (cajaTexto[i].ToString() == "ú"))
                {
                }
                else
                {
                    txtEvidencia.Focus();
                    errorProviderEvidencia.SetError(this.txtEvidencia, "EL cáracter \"" + cajaTexto[i].ToString() + "\" no está permitido.");
                    break;
                }
            }
        }

        private void txtEsfuerzo_Leave(object sender, EventArgs e)
        {
            int puntos = 0;

            for (int i = 0; i < txtEsfuerzo.Text.Trim().Length; i++)
            {
                if (txtEsfuerzo.Text.Trim()[i] == '.')
                {
                    puntos++;
                }
            }

            if (puntos > 1)
            {
                txtEsfuerzo.Focus();
                errorProviderEsfuerzo.SetError(this.txtEsfuerzo, "Ingresar letras y números solamente.");
                MessageBox.Show("No puede colocar más de un \".\".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                errorProviderEsfuerzo.SetError(this.txtEsfuerzo, String.Empty);
            }
        }
        #endregion

        string ipEquipo = string.Empty;

        private void FrmBitacora_IS_Load(object sender, EventArgs e)
        {
            //Código para definición de lenguaje y sistema de puntuación de la aplicación
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;
            culture = new System.Globalization.CultureInfo("es-EC");
            culture.NumberFormat.NumberDecimalSeparator = ".";
            culture.NumberFormat.NumberDecimalDigits = 2;
            culture.NumberFormat.PerMilleSymbol = ",";
            culture.NumberFormat.NumberGroupSeparator = ";";
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;


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

            LlenarEmpresa();

            ClaseLogsConexion claseLog = new ClaseLogsConexion();
            claseLog.Accion = "Abrió el formulario";
            claseLog.Autor = Environment.UserName;
            claseLog.IpOrigen = ipEquipo;
            claseLog.Formulario = "Bitácora Ingeniería de Seguridad y Servicios Comunes";

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

        private void FrmBitacora_IS_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClaseLogsConexion claseLog = new ClaseLogsConexion();
            claseLog.Accion = "Cerró el formulario";
            claseLog.Autor = Environment.UserName;
            claseLog.IpOrigen = ipEquipo;
            claseLog.Formulario = "Bitácora Ingeniería de Seguridad y Servicios Comunes";

            MetodoLogsConexion metLog = new MetodoLogsConexion();
            metLog.LogsConexion_Insert(claseLog);
        }

        private void ddlServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlServicio.SelectedIndex >= 0)
            {                
                if (ListaServicios.Count > 0)
                {
                    LlenarCategorias(ListaServicios[ddlServicio.SelectedIndex].IdServicio);
                }
                else
                {
                    ddlCategoria.Visible = false;
                    lblCategoria.Visible = false;
                }
            }
        }

        private void ddlEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarServicios(ddlEmpresa.Text);
            if (ListaServicios.Count > 0)
            {
                LlenarCategorias(ListaServicios[ddlServicio.SelectedIndex].IdServicio);
            }
            else
            {
                ddlCategoria.Visible = false;
                lblCategoria.Visible = false;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if ((String.IsNullOrEmpty(ddlServicio.Text.Trim()) == false)
                && (String.IsNullOrEmpty(ddlCategoria.Text.Trim()) == false)
                && (String.IsNullOrEmpty(ddlEmpresa.Text.Trim()) == false)
                && (String.IsNullOrEmpty(txtTarea.Text.Trim()) == false)
                && (String.IsNullOrEmpty(txtEvidencia.Text.Trim()) == false)
                && (String.IsNullOrEmpty(txtEsfuerzo.Text.Trim()) == false))
            {
                DateTime mesAtras = DateTime.Now;
                mesAtras = mesAtras.AddMonths(-1);

                int day, month, year;
                day = 1;
                month = mesAtras.Month;
                year = mesAtras.Year;

                DateTime minDate = new DateTime(year, month, day);

                if ((mtcFecha.SelectionStart.Date >= minDate.Date) && (mtcFecha.SelectionEnd.Date <= DateTime.Now.Date) && (mtcFecha.SelectionStart.Date <= DateTime.Now.Date))
                {
                    ClaseBitacora_IngenieriaSeguridad bitacora = new ClaseBitacora_IngenieriaSeguridad();

                    bitacora.IdRegistro = IdBitacora;
                    bitacora.IdCategoria = ListaCategorias[ddlCategoria.SelectedIndex].IdCategoria;
                    bitacora.IdEmpresa = ListaEmpresas[ddlEmpresa.SelectedIndex].IdEmpresa;
                    bitacora.Tarea = EliminarSaltosDeLinea(txtTarea.Text.Trim());
                    bitacora.Esfuerzo = Convert.ToDecimal(txtEsfuerzo.Text.Trim().Replace('.', ','));
                    bitacora.Evidencia = EliminarSaltosDeLinea(txtEvidencia.Text.Trim());
                    bitacora.FechaInicio = mtcFecha.SelectionStart;
                    bitacora.FechaFin = mtcFecha.SelectionEnd;
                    bitacora.Responsable = UsuarioConectado;
                    bitacora.HoraExtra = chkHoraExtra.Checked;

                    int retorno = 0;

                    if (IdBitacora > 0)
                    {
                        //MODIFICAR
                        retorno = metBitacora.Bitacora_IngenieriaSeguridad_Update(bitacora);
                    }
                    else
                    {
                        //INSERTAR
                        retorno = metBitacora.Bitacora_IngenieriaSeguridad_Insert(bitacora);
                    }


                    if (retorno > 0)
                    {
                        LimpiarCampos();
                        MessageBox.Show("Los datos fueron grabados exitosamente.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error al tratar de grabar la información.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("La fecha se encuentra fuera de los rangos permitidos.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor llenar todos los campos.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRuta_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string dir = openFileDialog1.FileName;
                string destino = Path.GetDirectoryName(dir);

                txtEvidencia.Text = destino;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBusquedaBitacora_IS frmBusquedaBitacora = new FrmBusquedaBitacora_IS();
            frmBusquedaBitacora.StartPosition = FormStartPosition.CenterScreen;
            frmBusquedaBitacora.ShowDialog();
            IdBitacora = frmBusquedaBitacora.IdRegistro;
            IdServicio = frmBusquedaBitacora.IdServicio;
            IdCategoria = frmBusquedaBitacora.IdCategoria;
            LlenarCajas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (IdBitacora != 0)
            {
                int retorno = 0;
                retorno = metBitacora.Bitacora_IngenieriaSeguridad_Delete(IdBitacora);

                if (retorno > 0)
                {
                    LimpiarCampos();
                    MessageBox.Show("Los datos fueron eliminados exitosamente.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al tratar de grabar la información.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No existe ningún dato seleccionado para eliminar.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            LlenarEmpresa();
            LlenarServicios(ddlEmpresa.Text);
            if (ListaServicios.Count > 0)
            {
                LlenarCategorias(ListaServicios[ddlServicio.SelectedIndex].IdServicio);
            }
            else
            {
                ddlCategoria.Visible = false;
                lblCategoria.Visible = false;
            }
        }
    }
}
