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
    public partial class FrmEmpresas_IS : Form
    {
        int idEmpresa = 0;
        string ipEquipo;

        MetodoEmpresas_IngenieriaSeguridad metEmpresa = new MetodoEmpresas_IngenieriaSeguridad();

        List<ClaseEmpresas_IngenieriaSeguridad> lstEmpresa = new List<ClaseEmpresas_IngenieriaSeguridad>();

        public FrmEmpresas_IS()
        {
            InitializeComponent();
        }

        private void FrmEmpresas_IS_Load(object sender, EventArgs e)
        {
            idEmpresa = 0;
            txtNombreEmpresa.Text = string.Empty;
            listEmpresas.Visible = false;

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
            claseLog.Formulario = "Empresas";

            MetodoLogsConexion metLog = new MetodoLogsConexion();
            metLog.LogsConexion_Insert(claseLog);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombreEmpresa.Text.Trim()) == false)
            {
                lstEmpresa = metEmpresa.Empresas_IngenieriaSeguridad_SelectByNombreEmpresa(txtNombreEmpresa.Text.Trim());

                lstEmpresa = lstEmpresa.OrderBy(x => x.NombreEmpresa).ToList();

                listEmpresas.Items.Clear();

                foreach (var item in lstEmpresa)
                {
                    listEmpresas.Items.Add(item.NombreEmpresa);
                }

                listEmpresas.Visible = true;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombreEmpresa.Text.Trim()) == false)
            {
                ClaseEmpresas_IngenieriaSeguridad clsEmpresa = new ClaseEmpresas_IngenieriaSeguridad();
                clsEmpresa.IdEmpresa = idEmpresa;
                clsEmpresa.NombreEmpresa = txtNombreEmpresa.Text.Trim();
                clsEmpresa.Usuario = Environment.UserName;
                clsEmpresa.Ip = ipEquipo;

                int retorno;

                if (idEmpresa == 0)
                {
                    //ingreso
                    retorno = metEmpresa.Empresas_IngenieriaSeguridad_Insert(clsEmpresa);
                }
                else
                {
                    //modificacion
                    retorno = metEmpresa.Empresas_IngenieriaSeguridad_Update(clsEmpresa);
                }

                if (retorno > 0)
                {
                    idEmpresa = 0;
                    txtNombreEmpresa.Text = string.Empty;
                    listEmpresas.Visible = false;
                    MessageBox.Show("Los datos fueron grabados exitosamente.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    listEmpresas.Visible = false;
                    MessageBox.Show("Ocurrio un error al tratar de grabar la información.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void listEmpresas_DoubleClick(object sender, EventArgs e)
        {
            if (listEmpresas.Items.Count > 0)
            {
                var a = listEmpresas.SelectedIndex;
                txtNombreEmpresa.Text = lstEmpresa[listEmpresas.SelectedIndex].NombreEmpresa;
                idEmpresa = lstEmpresa[listEmpresas.SelectedIndex].IdEmpresa;
                listEmpresas.Visible = false;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            idEmpresa = 0;
            txtNombreEmpresa.Text = string.Empty;
            listEmpresas.Visible = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if ((String.IsNullOrEmpty(txtNombreEmpresa.Text.Trim()) == false) && (idEmpresa != 0))
            {
                int retorno = metEmpresa.Empresas_IngenieriaSeguridad_Delete(idEmpresa);

                if (retorno > 0)
                {
                    idEmpresa = 0;
                    txtNombreEmpresa.Text = string.Empty;
                    listEmpresas.Visible = false;
                    MessageBox.Show("Los datos fueron eliminados exitosamente.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    listEmpresas.Visible = false;
                    MessageBox.Show("Ocurrio un error al tratar de eliminar la información.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmEmpresas_IS_FormClosing(object sender, FormClosingEventArgs e)
        {
            //InsertarLogConexion
            ClaseLogsConexion claseLog = new ClaseLogsConexion();
            claseLog.Accion = "Cerró el formulario";
            claseLog.Autor = Environment.UserName;
            claseLog.IpOrigen = ipEquipo;
            claseLog.Formulario = "Empresas";

            MetodoLogsConexion metLog = new MetodoLogsConexion();
            metLog.LogsConexion_Insert(claseLog);
        }
    }
}
