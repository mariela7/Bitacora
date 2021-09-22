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
    public partial class FrmListas_CA : Form
    {
        MetodoBitacora_CertificacionAplicaciones metBitacora = new MetodoBitacora_CertificacionAplicaciones();
        List<ClaseLista_CertificacionAplicaciones> Lista2 = new List<ClaseLista_CertificacionAplicaciones>();

        List<string> ValoresEliminar = new List<string>();

        public FrmListas_CA()
        {
            InitializeComponent();
        }

        private void btnAnadirFila_Click(object sender, EventArgs e)
        {
            dgvListas.Rows.Add();
            dgvListas.Rows[dgvListas.Rows.Count - 1].Height = 25;
        }

        private void btnQuitarFila_Click(object sender, EventArgs e)
        {
            if (dgvListas.Rows.Count > 0)
            {
                dgvListas.Rows.Remove(dgvListas.CurrentRow);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombreLista.Text = string.Empty;
            dgvListas.Rows.Clear();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            List<ClaseLista_CertificacionAplicaciones> lstLista = new List<ClaseLista_CertificacionAplicaciones>();

            foreach (DataGridViewRow item in dgvListas.Rows)
            {
                ClaseLista_CertificacionAplicaciones clsLista = new ClaseLista_CertificacionAplicaciones();
                clsLista.NombreLista = txtNombreLista.Text.Trim();
                clsLista.Valor = item.Cells["dgValor"].Value.ToString();

                lstLista.Add(clsLista);
            }

            int retorno = metBitacora.Bitacora_CertificacionApp_InsertLista(lstLista);

            if (retorno > 0)
            {
                txtNombreLista.Text = string.Empty;
                dgvListas.Rows.Clear();
                MessageBox.Show("Los datos fueron grabados exitosamente.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al tratar de grabar la información.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabCtrlListas_TabIndexChanged(object sender, EventArgs e)
        {
            string a = tabCtrlListas.SelectedTab.Text;
        }

        private void tabCtrlListas_Selected(object sender, TabControlEventArgs e)
        {
            if (tabCtrlListas.SelectedIndex == 1)
            {
                Lista2.Clear();
                //Editar/Eliminar
                List<ClaseLista_CertificacionAplicaciones> Listas = new List<ClaseLista_CertificacionAplicaciones>();
                Listas = metBitacora.Bitacora_CertificacionApp_ListaSelectAll();
                
                string a = string.Empty;

                Listas = Listas.OrderBy(x => x.IdLista).ToList();

                foreach (ClaseLista_CertificacionAplicaciones item in Listas)
                {
                    ClaseLista_CertificacionAplicaciones Clase2 = new ClaseLista_CertificacionAplicaciones();
                    if ((item.IdLista + "-" + item.NombreLista) != a)
                    {
                        Clase2.IdLista = item.IdLista;
                        Clase2.NombreLista = item.NombreLista;

                        Lista2.Add(Clase2);
                    }
                    a = item.IdLista + "-" + item.NombreLista;
                }

                Lista2 = Lista2.OrderBy(x => x.IdLista).ToList();
                ddlListas.DataSource = Lista2;
                ddlListas.ValueMember = "IdLista";
                ddlListas.DisplayMember = "NombreLista";
            }            
        }

        List<ClaseLista_CertificacionAplicaciones> ListaElementos = new List<ClaseLista_CertificacionAplicaciones>();

        private void ddlListas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            dgvValoresEdicion.Rows.Clear();

            int i = Lista2[ddlListas.SelectedIndex].IdLista;

            ListaElementos.Clear();
            ListaElementos = metBitacora.Bitacora_CertificacionApp_SelectLista(i);

            foreach (var item in ListaElementos)
            {
                item.NombreLista = Lista2[ddlListas.SelectedIndex].NombreLista;
            }

            foreach (var item in ListaElementos)
            {
                dgvValoresEdicion.Rows.Add();
                dgvValoresEdicion.Rows[dgvValoresEdicion.Rows.Count - 1].Height = 25;
                
                dgvValoresEdicion.Rows[dgvValoresEdicion.Rows.Count - 1].Cells["dgIdListaEdit"].Value = item.IdLista.ToString();
                dgvValoresEdicion.Rows[dgvValoresEdicion.Rows.Count - 1].Cells["dgNombreListaEdit"].Value = Lista2[ddlListas.SelectedIndex].NombreLista;
                dgvValoresEdicion.Rows[dgvValoresEdicion.Rows.Count - 1].Cells["dgValorEdit"].Value = item.Valor.ToString();
            }
        }

        private void btnEditAdd_Click(object sender, EventArgs e)
        {
            dgvValoresEdicion.Rows.Add();
            dgvValoresEdicion.Rows[dgvValoresEdicion.Rows.Count - 1].Height = 25;

            dgvValoresEdicion.Rows[dgvValoresEdicion.Rows.Count - 1].Cells["dgIdListaEdit"].Value = 1;
            dgvValoresEdicion.Rows[dgvValoresEdicion.Rows.Count - 1].Cells["dgNombreListaEdit"].Value = Lista2[ddlListas.SelectedIndex].NombreLista;
        }

        List<ClaseLista_CertificacionAplicaciones> ListaCambios = new List<ClaseLista_CertificacionAplicaciones>();

        private void btnEditDelete_Click(object sender, EventArgs e)
        {
            if (dgvValoresEdicion.Rows.Count > 0)
            {
                ClaseLista_CertificacionAplicaciones Valor = new ClaseLista_CertificacionAplicaciones();
                Valor.IdLista = 0;
                Valor.NombreLista = dgvValoresEdicion.CurrentRow.Cells["dgNombreListaEdit"].Value.ToString();
                Valor.Valor = dgvValoresEdicion.CurrentRow.Cells["dgValorEdit"].Value.ToString();

                ListaCambios.Add(Valor);

                dgvValoresEdicion.Rows.Remove(dgvValoresEdicion.CurrentRow);
            }
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in dgvValoresEdicion.Rows)
            {
                if (Convert.ToInt32(fila.Cells["dgIdListaEdit"].Value) != Convert.ToInt32(Lista2[ddlListas.SelectedIndex].IdLista))
                {
                    ClaseLista_CertificacionAplicaciones Valor = new ClaseLista_CertificacionAplicaciones();
                    Valor.IdLista = 1;
                    Valor.NombreLista = fila.Cells["dgNombreListaEdit"].Value.ToString();
                    Valor.Valor = fila.Cells["dgValorEdit"].Value.ToString();

                    ListaCambios.Add(Valor);
                }
            }

            if (ListaCambios.Count > 0)
            {
                metBitacora.Bitacora_CertificacionApp_EditarLista(ListaCambios);
                CargarGrilla();
                MessageBox.Show("Los datos fueron grabados modificados.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaCambios.Clear();
            }
        }
    }
}
