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
    public partial class FrmCatalogoServicios_IS : Form
    {
        //private static FrmCatalogoServicios_IS m_FormDefInstance;
        //public static FrmCatalogoServicios_IS DefInstance
        //{
        //    get
        //    {
        //        if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
        //        {
        //            m_FormDefInstance = new FrmCatalogoServicios_IS();
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

        int idServicio = 0;
        MetodoServicios_IngenieriaSeguridad metServicio = new MetodoServicios_IngenieriaSeguridad();
        List<ClaseServicios_IngenieriaSeguridad> lstServicio = new List<ClaseServicios_IngenieriaSeguridad>();
        string ipEquipo = string.Empty;

        public FrmCatalogoServicios_IS()
        {
            InitializeComponent();
        }

        private void FrmCatalogoServicios_IS_Load(object sender, EventArgs e)
        {
            idServicio = 0;
            txtDescripcionServicio.Text = string.Empty;
            listServicios.Visible = false;

            List<string> ListaPoseeTareas = new List<string>();
            ListaPoseeTareas.Add("SI");
            ListaPoseeTareas.Add("NO");

            ddlPoseeTarea.DataSource = ListaPoseeTareas;

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

            //InsertarLogConexion
            ClaseLogsConexion claseLog = new ClaseLogsConexion();
            claseLog.Accion = "Abrió el formulario";
            claseLog.Autor = Environment.UserName;
            claseLog.IpOrigen = ipEquipo;
            claseLog.Formulario = "Catálogo de servicios";

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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDescripcionServicio.Text.Trim()) == false)
            {
                lstServicio = metServicio.Servicios_IngenieriaSeguridad_SelectByDescripcion(txtDescripcionServicio.Text.Trim());

                lstServicio = lstServicio.OrderBy(x => x.NombreServicio).ToList();

                listServicios.Items.Clear();

                foreach (var item in lstServicio)
                {
                    listServicios.Items.Add(item.NombreServicio);
                }

                listServicios.Visible = true;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDescripcionServicio.Text.Trim()) == false)
            {
                ClaseServicios_IngenieriaSeguridad clsServicio = new ClaseServicios_IngenieriaSeguridad();
                clsServicio.IdServicio = idServicio;
                clsServicio.NombreServicio = txtDescripcionServicio.Text.Trim();
                clsServicio.Usuario = Environment.UserName;
                clsServicio.Ip = ipEquipo;
                clsServicio.PoseeTareas = false;
                if (ddlPoseeTarea.Text == "SI")
                {
                    clsServicio.PoseeTareas = true;
                }

                int retorno;

                if (idServicio == 0)
                {
                    //ingreso
                    retorno = metServicio.Servicios_IngenieriaSeguridad_Insert(clsServicio);
                }
                else
                {
                    //modificacion
                    retorno = metServicio.Servicios_IngenieriaSeguridad_Update(clsServicio);
                }

                if (retorno > 0)
                {
                    idServicio = 0;
                    txtDescripcionServicio.Text = string.Empty;
                    listServicios.Visible = false;
                    MessageBox.Show("Los datos fueron grabados exitosamente.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    listServicios.Visible = false;
                    MessageBox.Show("Ocurrio un error al tratar de grabar la información.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void listServicios_DoubleClick(object sender, EventArgs e)
        {
            if (listServicios.Items.Count > 0)
            {
                var a = listServicios.SelectedIndex;
                txtDescripcionServicio.Text = lstServicio[listServicios.SelectedIndex].NombreServicio;
                idServicio = lstServicio[listServicios.SelectedIndex].IdServicio;
                listServicios.Visible = false;

                if (lstServicio[listServicios.SelectedIndex].PoseeTareas)
                {
                    ddlPoseeTarea.SelectedIndex = 0;
                }
                else
                {
                    ddlPoseeTarea.SelectedIndex = 1;
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            idServicio = 0;
            txtDescripcionServicio.Text = string.Empty;
            listServicios.Visible = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if ((String.IsNullOrEmpty(txtDescripcionServicio.Text.Trim()) == false) && (idServicio != 0))
            {
                int retorno = metServicio.Servicios_IngenieriaSeguridad_Delete(idServicio);

                if (retorno > 0)
                {
                    idServicio = 0;
                    txtDescripcionServicio.Text = string.Empty;
                    listServicios.Visible = false;
                    MessageBox.Show("Los datos fueron eliminados exitosamente.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    listServicios.Visible = false;
                    MessageBox.Show("Ocurrio un error al tratar de eliminar la información.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmCatalogoServicios_IS_FormClosing(object sender, FormClosingEventArgs e)
        {
            //InsertarLogConexion
            ClaseLogsConexion claseLog = new ClaseLogsConexion();
            claseLog.Accion = "Cerró el formulario";
            claseLog.Autor = Environment.UserName;
            claseLog.IpOrigen = ipEquipo;
            claseLog.Formulario = "Catálogo de servicios";

            MetodoLogsConexion metLog = new MetodoLogsConexion();
            metLog.LogsConexion_Insert(claseLog);
        }

        private void listServicios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }        
    }
}
