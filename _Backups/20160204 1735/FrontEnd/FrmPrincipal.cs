using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using System.Security.Principal;
using System.Net;
using System.DirectoryServices.AccountManagement;

using LogicaNegocios.Metodos;
using LogicaNegocios.Clases;

namespace FrontEnd
{
    public partial class FrmPrincipal : Form
    {
        string usr = string.Empty;
        string dom = string.Empty; 

        #region ListasGenericas
        List<ClaseServicios_CertificacionAplicaciones> miListaServicios;
        List<string> ListaAutorizados = new List<string>();
        #endregion

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            MdiClient ctlMDI;

            // Loop through all of the form's controls looking
            // for the control of type MdiClient.
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    // Attempt to cast the control to type MdiClient.
                    ctlMDI = (MdiClient)ctl;

                    // Set the BackColor of the MdiClient control.
                    ctlMDI.BackColor = Color.White;
                }
                catch (InvalidCastException exc)
                {
                    // Catch and ignore the error if casting failed.
                }
            }


            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;
            culture = new System.Globalization.CultureInfo("es-EC");
            culture.NumberFormat.NumberDecimalSeparator = ",";
            culture.NumberFormat.NumberDecimalDigits = 2;
            culture.NumberFormat.PerMilleSymbol = ".";
            culture.NumberFormat.NumberGroupSeparator = ";";
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;

            try
            {
                usr = Environment.UserName;
                dom = Environment.UserDomainName;
            }
            catch (Exception)
            {
                MessageBox.Show("No puede utilizar esta aplicación. Usted no tiene permisos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                this.Close();
            }

            bool IsGrupo = false;

            List<string> result = new List<string>();
            string grupo = string.Empty;

            try
            {
                PrincipalContext pc = new PrincipalContext((Environment.UserDomainName == Environment.MachineName ? ContextType.Machine : ContextType.Domain), Environment.UserDomainName);

                GroupPrincipal gp = GroupPrincipal.FindByIdentity(pc, "UIO\\GF_IngenieriaSeguridad_UIO");
                UserPrincipal up = UserPrincipal.FindByIdentity(pc, usr);
                IsGrupo = up.IsMemberOf(gp);
            }
            catch (Exception)
            {
                MessageBox.Show("No puede utilizar esta aplicación. Usted no tiene permisos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            if ((IsGrupo) && (dom == "UIO"))
            {
                toolStripTextBoxUsuarioLogeado.Text = Environment.UserName;
            }
            else
            {
                MessageBox.Show("Usted no es un usuario permitido para acceder a esta aplicación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

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
            claseLog.Accion = "Inició sesión";
            claseLog.Autor = Environment.UserName;
            claseLog.IpOrigen = ipEquipo;
            claseLog.Formulario = "Principal";

            MetodoLogsConexion metLog = new MetodoLogsConexion();
            metLog.LogsConexion_Insert(claseLog);
            LlenarListaBitacoras();

            MetodoGeneral  miMetodo = new MetodoGeneral();

            ListaAutorizados = miMetodo.GetAutorizados();

        }
        
        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
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
            claseLog.Accion = "Cerró sesión";
            claseLog.Autor = Environment.UserName;
            claseLog.IpOrigen = ipEquipo;
            claseLog.Formulario = "Principal";

            MetodoLogsConexion metLog = new MetodoLogsConexion();
            metLog.LogsConexion_Insert(claseLog);
        }

        private void LlenarListaBitacoras()
        { 
            //Traer Lista
            miListaServicios = new List<ClaseServicios_CertificacionAplicaciones>();
            MetodoBitacora_CertificacionAplicaciones miMetodo = new MetodoBitacora_CertificacionAplicaciones();
            miListaServicios = miMetodo.Bitacora_CertificacionApp_SelectServicios();

            foreach (var item in miListaServicios)
            {
                toolStripMenuItem_CA_Bitacora.DropDownItems.Add(item.Nombre);
                toolStripMenuItem_CA_Bitacora.DropDownItems[toolStripMenuItem_CA_Bitacora.DropDownItems.Count - 1].Click += new EventHandler(AbrirFrmBitacora_CA);
            }
        }

        private void AbrirFrmBitacora_CA(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolStripDropDownItem miSender = (System.Windows.Forms.ToolStripDropDownItem)sender;
            foreach (var item in miListaServicios)
            {
                if (item.Nombre == miSender.Text)
                {
                    FrmBitacora_CA miBitacora = new FrmBitacora_CA();
                    miBitacora.ValorId = item.IdServicio;
                    miBitacora.ValorNombre = item.Nombre;
                    miBitacora.MdiParent = this;
                    miBitacora.WindowState = FormWindowState.Maximized;
                    miBitacora.Show();
                    break;
                }
            }            
        }

        private void toolStripMenuItem_Empresas_Click(object sender, EventArgs e)
        {
            FrmEmpresas_IS frmEmpresas = new FrmEmpresas_IS();
            frmEmpresas.MdiParent = this;
            frmEmpresas.Show();
        }

        private void toolStripMenuItem_IS_Catalogo_Click(object sender, EventArgs e)
        {
            int ban = 0;

            foreach (var item in ListaAutorizados)
            {
                if (item.ToUpper() == Environment.UserName.ToUpper())
                {
                    ban = 1;
                }
            }

            if (ban == 1)
            {
                FrmCatalogoServicios_IS frmCatalogo = new FrmCatalogoServicios_IS();
                frmCatalogo.MdiParent = this;
                frmCatalogo.StartPosition = FormStartPosition.CenterScreen;
                frmCatalogo.Show();
            }
            else
            {
                MessageBox.Show("Usuario no autorizado para realizar esta acción");
            }
        }

        private void toolStripMenuItem_IS_Ingreso_Click(object sender, EventArgs e)
        {
            FrmBitacora_IS frmBitacora = new FrmBitacora_IS();
            frmBitacora.MdiParent = this;
            frmBitacora.StartPosition = FormStartPosition.CenterScreen;
            frmBitacora.Show();
        }

        private void toolStripMenuItem_IS_Reporte_Click(object sender, EventArgs e)
        {
            FrmReporteTodo_IS frmReporte = new FrmReporteTodo_IS();
            frmReporte.MdiParent = this;
            frmReporte.Show();
        }

        private void toolStripMenuItem_CA_Listas_Click(object sender, EventArgs e)
        {
            int ban = 0;

            foreach (var item in ListaAutorizados)
            {
                if (item.ToUpper() == Environment.UserName.ToUpper())
                {
                    ban = 1;
                }
            }

            if (ban == 1)
            {
                FrmListas_CA frmLista = new FrmListas_CA();
                frmLista.MdiParent = this;
                frmLista.WindowState = FormWindowState.Maximized;
                frmLista.Show();
            }
            else
            {
                MessageBox.Show("Usuario no autorizado para realizar esta acción");
            }
        }

        private void toolStripMenuItem_CA_Consultas_Click(object sender, EventArgs e)
        {
            FrmEligeServicio frmBase = new FrmEligeServicio("Consulta");
            frmBase.MdiParent = this;
            frmBase.WindowState = FormWindowState.Maximized;
            frmBase.Show();
        }

        private void toolStripMenuItem_CA_Reporte_Click(object sender, EventArgs e)
        {
            FrmEligeServicio frmBase = new FrmEligeServicio("Reporte");
            frmBase.MdiParent = this;
            frmBase.WindowState = FormWindowState.Maximized;
            frmBase.Show();
        }

        private void toolStripMenuItem_BC_Consulta_Click(object sender, EventArgs e)
        {
            FrmBaseConocimiento frmBase = new FrmBaseConocimiento();
            frmBase.MdiParent = this;
            frmBase.WindowState = FormWindowState.Maximized;
            frmBase.Show();
        }

        private void toolStripMenuItem_BC_Ingreso_Click(object sender, EventArgs e)
        {
            int ban = 0;

            foreach (var item in ListaAutorizados)
            {
                if (item.ToUpper() == Environment.UserName.ToUpper())
                {
                    ban = 1;
                }
            }

            if (ban == 1)
            {
                FrmBaseConocimientoIngreso frmBase = new FrmBaseConocimientoIngreso();
                frmBase.MdiParent = this;
                frmBase.WindowState = FormWindowState.Maximized;
                frmBase.Show();
            }
            else
            {
                MessageBox.Show("Usuario no autorizado para realizar esta acción");
            }
        }

        private void toolStripMenuItem_BC_Categoria_Click(object sender, EventArgs e)
        {
            int ban = 0;

            foreach (var item in ListaAutorizados)
            {
                if (item.ToUpper() == Environment.UserName.ToUpper())
                {
                    ban = 1;
                }
            }

            if (ban == 1)
            {
                FrmBaseConocimientoCategorias frmBase = new FrmBaseConocimientoCategorias();
                frmBase.MdiParent = this;
                frmBase.WindowState = FormWindowState.Maximized;
                frmBase.Show();
            }
            else
            {
                MessageBox.Show("Usuario no autorizado para realizar esta acción");
            }
        }
    }
}
