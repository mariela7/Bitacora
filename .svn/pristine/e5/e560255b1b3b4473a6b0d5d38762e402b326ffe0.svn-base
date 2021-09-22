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
    public partial class FrmBitacora_ServiciosCA : Form
    {
        //private static FrmBitacora_ServiciosCA m_FormDefInstance;
        //public static FrmBitacora_ServiciosCA DefInstance
        //{
        //    get
        //    {
        //        if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
        //        {
        //            m_FormDefInstance = new FrmBitacora_ServiciosCA();
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

        public FrmBitacora_ServiciosCA()
        {
            InitializeComponent();
        }

        List<ClaseServicios_CertificacionAplicaciones> miListaServicios;
        List<ClaseServicios_CertificacionAplicaciones> miListaServicios_Depurada;
        List<ClaseEmpresas_IngenieriaSeguridad> ListaEmpresas = new List<ClaseEmpresas_IngenieriaSeguridad>();
        List<ClaseLista_CertificacionAplicaciones> ListaListas = new List<ClaseLista_CertificacionAplicaciones>();
        ClaseParametros parametro = new ClaseParametros();

        MetodoBitacora_CertificacionAplicaciones mtBitacoraCA = new MetodoBitacora_CertificacionAplicaciones();
        MetodoEmpresas_IngenieriaSeguridad mtEmpresa = new MetodoEmpresas_IngenieriaSeguridad();
        MetodoGeneral mtGeneral = new MetodoGeneral();
        MetodoMatrizVulnerabilidades mtMatrizVulnerabilidades = new MetodoMatrizVulnerabilidades();

        int idVulnerabilidad;
        string UsuarioConectado = Environment.UserName;
        string ipEquipo = string.Empty;

        #region Funciones
        public void LlenarEmpresa()
        {
            ListaEmpresas = mtEmpresa.Empresas_IngenieriaSeguridad_SelectAll();
            ListaEmpresas = ListaEmpresas.OrderBy(x => x.NombreEmpresa).ToList();
            ddlEmpresa.DataSource = ListaEmpresas;
            ddlEmpresa.ValueMember = "IdEmpresa";
            ddlEmpresa.DisplayMember = "NombreEmpresa";

            LlenarServicios(ddlEmpresa.Text.Trim());
        }

        public void LlenarServicios(string empresa)
        {
            //Traer Lista
            miListaServicios = new List<ClaseServicios_CertificacionAplicaciones>();
            miListaServicios = mtBitacoraCA.Bitacora_CertificacionApp_SelectServiciosByEmpresa(empresa);

            miListaServicios_Depurada = new List<ClaseServicios_CertificacionAplicaciones>();

            foreach (ClaseServicios_CertificacionAplicaciones item in miListaServicios)
            {
                int existe = 0;
                existe = mtBitacoraCA.Bitacora_CertificacionApp_ServicioEliminado(item.IdServicio, item.Nombre);

                if (existe == 0)
                {
                    miListaServicios_Depurada.Add(item);
                }
            }

            miListaServicios_Depurada = miListaServicios_Depurada.OrderBy(x => x.Nombre).ToList();
            ddlServicio.DataSource = miListaServicios_Depurada;
            ddlServicio.ValueMember = "IdServicio";
            ddlServicio.DisplayMember = "Nombre";
        }

        private string EliminarSaltosDeLinea(string cadena)
        {
            cadena = cadena.Replace(System.Environment.NewLine, " ");

            cadena = cadena.Replace(System.Environment.NewLine, " ");

            cadena = cadena.Replace("\"", "");

            return cadena;
        }

        public void LimpiarCampos()
        {
            LlenarEmpresa();
            LlenarServicios(ddlEmpresa.Text);
            gbxCierreVulnerabilidades.Visible = false;
            lblCodigoSolucion.Visible = false;
            txtCodigoCierre.Visible = false;
            lblTipoCierre.Visible = false;
            ddlTipoCierre.Visible = false;

            dtpFecha.Value = DateTime.Now;
            txtTarea.Text = string.Empty;
            txtEvidencia.Text = string.Empty;
            txtEsfuerzo.Text = string.Empty;
            idVulnerabilidad = 0;
            lbxVulnerabilidad.Items.Clear();
            txtCodigoCierre.Text = string.Empty;
        }

        #endregion

        private void FrmBitacora_ServiciosCA_Load(object sender, EventArgs e)
        {
            LimpiarCampos();

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
            claseLog.Formulario = "Bitácora Certificación de Aplicaciones";

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

        private void ddlEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarServicios(ddlEmpresa.Text);
        }

        private void ddlServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlServicio.Text.Trim() == "Cierre de Vulnerabilidades")
            {
                //Estado
                parametro = new ClaseParametros();
                parametro = mtGeneral.Parametros_SelectByCodigo("LEV");
                ListaListas = mtBitacoraCA.Bitacora_CertificacionApp_SelectLista(Convert.ToInt32(parametro.Valor));

                ListaListas = ListaListas.OrderBy(x => x.Valor).ToList();
                ddlEstado.DataSource = ListaListas;
                ddlEstado.ValueMember = "Valor";
                ddlEstado.DisplayMember = "Valor";

                //Tipo Actividad
                parametro = new ClaseParametros();
                parametro = mtGeneral.Parametros_SelectByCodigo("LTA");
                ListaListas = mtBitacoraCA.Bitacora_CertificacionApp_SelectLista(Convert.ToInt32(parametro.Valor));

                ListaListas = ListaListas.OrderBy(x => x.Valor).ToList();
                ddlTipoActividad.DataSource = ListaListas;
                ddlTipoActividad.ValueMember = "Valor";
                ddlTipoActividad.DisplayMember = "Valor";

                //Tipo Cierre
                parametro = new ClaseParametros();
                parametro = mtGeneral.Parametros_SelectByCodigo("LTC");
                ListaListas = mtBitacoraCA.Bitacora_CertificacionApp_SelectLista(Convert.ToInt32(parametro.Valor));

                ListaListas = ListaListas.OrderBy(x => x.Valor).ToList();
                ddlTipoCierre.DataSource = ListaListas;
                ddlTipoCierre.ValueMember = "Valor";
                ddlTipoCierre.DisplayMember = "Valor";

                gbxCierreVulnerabilidades.Visible = true;
            }
            else
            {
                gbxCierreVulnerabilidades.Visible = false;
            }
        }

        private void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEstado.Text == "Cerrada")
            {
                lblCodigoSolucion.Visible = true;
                txtCodigoCierre.Visible = true;
                lblTipoCierre.Visible = true;
                ddlTipoCierre.Visible = true;
            }
            else
            {
                lblCodigoSolucion.Visible = false;
                txtCodigoCierre.Visible = false;
                lblTipoCierre.Visible = false;
                ddlTipoCierre.Visible = false;
            }
        }

        private void btnConsultarVulnerabilidad_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCodigoSiTcs.Text))
            {
                MessageBox.Show("Debe ingresar un código para poder consultar una vulnerabilidad.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                lbxVulnerabilidad.Items.Clear();

                List<ClaseMatrizVulnerabilidades> listadoVulnerabilidades = new List<ClaseMatrizVulnerabilidades>();
                listadoVulnerabilidades = mtMatrizVulnerabilidades.MatrizVulnerabilidades_SelectByCodigoSiTCS_NoCerradas(txtCodigoSiTcs.Text.Trim(), ListaEmpresas[ddlEmpresa.SelectedIndex].IdEmpresa);

                if (listadoVulnerabilidades.Count == 1)
                {
                    //Un registro
                    ClaseEmpresas_IngenieriaSeguridad empresa = new ClaseEmpresas_IngenieriaSeguridad();
                    empresa = mtEmpresa.Empresas_IngenieriaSeguridad_SelectByIdEmpresa(listadoVulnerabilidades[0].IdEmpresa);

                    idVulnerabilidad = listadoVulnerabilidades[0].IdVulnerabilidad;
                    lbxVulnerabilidad.Items.Add("* Empresa: " + empresa.NombreEmpresa);
                    lbxVulnerabilidad.Items.Add("* Código SI-TCS: " + listadoVulnerabilidades[0].CodigoSiTCS);
                    lbxVulnerabilidad.Items.Add("* Código Único: " + listadoVulnerabilidades[0].CodigoUnico);
                    lbxVulnerabilidad.Items.Add("* Código Proveedor: " + listadoVulnerabilidades[0].CodigoProveedor);
                    lbxVulnerabilidad.Items.Add("* Proveedor: " + 
                            listadoVulnerabilidades[0].Proveedor.ToString().Substring(
                            listadoVulnerabilidades[0].Proveedor.ToString().IndexOf('-') + 1, 
                            (listadoVulnerabilidades[0].Proveedor.ToString().Length - 
                            (listadoVulnerabilidades[0].Proveedor.ToString().IndexOf('-') + 1))).Trim());
                    lbxVulnerabilidad.Items.Add("* Fecha Identificación: " + listadoVulnerabilidades[0].FechaIdentificacion.ToShortDateString());
                    lbxVulnerabilidad.Items.Add("* Aplicación: " +
                            listadoVulnerabilidades[0].Aplicacion.ToString().Substring(
                            listadoVulnerabilidades[0].Aplicacion.ToString().IndexOf('-') + 1,
                            (listadoVulnerabilidades[0].Aplicacion.ToString().Length - 
                            (listadoVulnerabilidades[0].Aplicacion.ToString().IndexOf('-') + 1))).Trim());
                    lbxVulnerabilidad.Items.Add("* Nivel: " +
                            listadoVulnerabilidades[0].Nivel.ToString().Substring(
                            listadoVulnerabilidades[0].Nivel.ToString().IndexOf('-') + 1,
                            (listadoVulnerabilidades[0].Nivel.ToString().Length -
                            (listadoVulnerabilidades[0].Nivel.ToString().IndexOf('-') + 1))).Trim());
                    lbxVulnerabilidad.Items.Add("* Activo con la vulnerabilidad: " +
                            listadoVulnerabilidades[0].Activo.ToString().Substring(
                            listadoVulnerabilidades[0].Activo.ToString().IndexOf('-') + 1,
                            (listadoVulnerabilidades[0].Activo.ToString().Length -
                            (listadoVulnerabilidades[0].Activo.ToString().IndexOf('-') + 1))).Trim());
                    lbxVulnerabilidad.Items.Add("* Equipo/Modulo: " + listadoVulnerabilidades[0].EquipoModulo);
                    lbxVulnerabilidad.Items.Add("* Tipo de vulnerabilidad: " +
                            listadoVulnerabilidades[0].TipoVulnerabilidad.ToString().Substring(
                            listadoVulnerabilidades[0].TipoVulnerabilidad.ToString().IndexOf('-') + 1,
                            (listadoVulnerabilidades[0].TipoVulnerabilidad.ToString().Length -
                            (listadoVulnerabilidades[0].TipoVulnerabilidad.ToString().IndexOf('-') + 1))).Trim());
                    lbxVulnerabilidad.Items.Add("* Impacto: " + listadoVulnerabilidades[0].Impacto);
                    lbxVulnerabilidad.Items.Add("* Probabilidad: " + listadoVulnerabilidades[0].Probabilidad);
                    lbxVulnerabilidad.Items.Add("* Criticidad: " + listadoVulnerabilidades[0].Criticidad);
                    
                    ddlEstado.SelectedValue = listadoVulnerabilidades[0].Estado;
                    //lbxVulnerabilidad.Items.Add(listadoVulnerabilidades[0].FechaCierre);
                    //lbxVulnerabilidad.Items.Add(listadoVulnerabilidades[0].TipoCierre);
                    //lbxVulnerabilidad.Items.Add(listadoVulnerabilidades[0].CodigoSolucion);
                }
                else if (listadoVulnerabilidades.Count == 0)
                {
                    //Ninguno
                    MessageBox.Show("No hay códigos coincidentes con vulnerabilidades abiertas.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    //Mas de 1
                    MessageBox.Show("Hay más de una coincidencia. Consulte el código primero.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            switch (ddlServicio.Text.Trim())
            {
                case "Objetos Sensibles":
                    Console.WriteLine("Case 1");
                    break;
                case "Sistemas Operativos":
                    Console.WriteLine("Case 2");
                    break;
                case "Software Base":
                    Console.WriteLine("Case 2");
                    break;
                case "Software Utilitario":
                    Console.WriteLine("Case 2");
                    break;
                case "Vulnerabilidades en aplicativos de producción":
                    Console.WriteLine("Case 2");
                    break;
                case "Estándares":
                    Console.WriteLine("Case 2");
                    break;
                case "Nuevos Proyectos":
                    Console.WriteLine("Case 2");
                    break;
                case "Vulnerabilidades de Infraestructura":
                    Console.WriteLine("Case 2");
                    break;
                case "Cierre de Vulnerabilidades":
                    if ((ddlEmpresa.SelectedIndex >= 0)
                    && (ddlServicio.SelectedIndex >= 0)
                    && (String.IsNullOrEmpty(dtpFecha.Value.ToShortDateString()) == false)
                    && (String.IsNullOrEmpty(txtTarea.Text.Trim()) == false)
                    && (String.IsNullOrEmpty(txtEvidencia.Text.Trim()) == false)
                    && (String.IsNullOrEmpty(txtEsfuerzo.Text.Trim()) == false)
                    && (idVulnerabilidad > 0)
                    && (lbxVulnerabilidad.Items.Count > 0)
                    && (ddlEstado.SelectedIndex >= 0)
                    && (ddlTipoActividad.SelectedIndex >= 0))
                    {
                        ClaseBitacora_CertificacionAplicaciones clBitacora = new ClaseBitacora_CertificacionAplicaciones();
                        clBitacora.Esfuerzo = Convert.ToDecimal(txtEsfuerzo.Text.Trim());
                        clBitacora.Evidencia = txtEvidencia.Text.Trim();
                        clBitacora.Fecha = dtpFecha.Value;
                        clBitacora.HoraExtra = chkHoraExtra.Checked;
                        clBitacora.IdEmpresa = ListaEmpresas[ddlEmpresa.SelectedIndex].IdEmpresa;
                        clBitacora.IdServicio = miListaServicios_Depurada[ddlServicio.SelectedIndex].IdServicio;
                        clBitacora.ResponsableSI = UsuarioConectado;
                        clBitacora.Tarea = EliminarSaltosDeLinea(txtTarea.Text.Trim());

                        int bitacora = 0, matriz = 0;

                        bitacora = mtBitacoraCA.Bitacora_CertificacionAplicaciones_Insert(clBitacora);

                        ClaseMatrizVulnerabilidades_Detalle clMatrizDetalle = new ClaseMatrizVulnerabilidades_Detalle();
                        clMatrizDetalle.Accion = EliminarSaltosDeLinea(txtTarea.Text.Trim());
                        clMatrizDetalle.Estado = ddlEstado.Text.Trim();
                        clMatrizDetalle.Evidencia = txtEvidencia.Text.Trim();
                        clMatrizDetalle.Fecha = dtpFecha.Value;
                        clMatrizDetalle.IdVulnerabilidad = idVulnerabilidad;
                        clMatrizDetalle.TipoActividad = ddlTipoActividad.Text.Trim();

                        matriz = mtMatrizVulnerabilidades.MatrizVulnerabilidades_Detalle_Insert(clMatrizDetalle);

                        if (ddlEstado.Text == "Cerrada")
                        {
                            if ((ddlTipoCierre.SelectedIndex > 0) && (String.IsNullOrEmpty(txtCodigoCierre.Text.Trim()) == false))
                            {
                                mtMatrizVulnerabilidades.MatrizVulnerabilidades_Update(idVulnerabilidad, ddlEstado.Text.Trim(), dtpFecha.Value, ddlTipoCierre.Text.Trim(), txtCodigoCierre.Text.Trim());
                            }
                        }

                        if (bitacora > 0)
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
                        MessageBox.Show("Por favor llenar todos los campos.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;
                case "Autorizaciones Usuarios":
                    Console.WriteLine("Case 2");
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }

        private void FrmBitacora_ServiciosCA_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClaseLogsConexion claseLog = new ClaseLogsConexion();
            claseLog.Accion = "Cerró el formulario";
            claseLog.Autor = Environment.UserName;
            claseLog.IpOrigen = ipEquipo;
            claseLog.Formulario = "Bitácora Certificación de Aplicaciones";

            MetodoLogsConexion metLog = new MetodoLogsConexion();
            metLog.LogsConexion_Insert(claseLog);
        }
    }
}
