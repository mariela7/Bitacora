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
    public partial class FrmBaseConocimientoBuscar : Form
    {
        public FrmBaseConocimientoBuscar()
        {
            InitializeComponent();
        }

        public int NuevoID = 0;
        public string NuevoNombre = string.Empty;
        public int NuevaCat;
        string ipEquipo = string.Empty;

        private void FrmBaseConocimientoBuscar_Load(object sender, EventArgs e)
        {
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
            claseLog.Formulario = "Base de Conocimientos - Búsqueda";

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

        private void CmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CmbCategorias.SelectedIndex >= 0)
                {
                    ComboboxItem miItem = (ComboboxItem)CmbCategorias.SelectedItem;

                    getCabeceras((int)miItem.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getCabeceras(int IdCat)
        {
            DGCabeceras.Rows.Clear();
            List<LogicaNegocios.Clases.ClaseConocimientoCabecera> miListaCab = new List<LogicaNegocios.Clases.ClaseConocimientoCabecera>();
            LogicaNegocios.Metodos.MetodoConocimiento miMetodo = new LogicaNegocios.Metodos.MetodoConocimiento();

            miListaCab = miMetodo.GetCabeceras(IdCat);

            foreach (var item in miListaCab)
            {

                ComboboxItem miItem = new ComboboxItem();
                miItem.Text = item.Nombre;
                miItem.Value = item.Id;

                DGCabeceras.Rows.Add(item.Id, item.Nombre);
                //LBItems.Items.Add(miItem);
            }

        }

        private void DGCabeceras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                NuevoID = Convert.ToInt32(DGCabeceras.Rows[e.RowIndex].Cells[0].Value.ToString());
                NuevoNombre = DGCabeceras.Rows[e.RowIndex].Cells[1].Value.ToString();
                NuevaCat = this.CmbCategorias.SelectedIndex;
                this.Close();
            }
        }

        private void FrmBaseConocimientoBuscar_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClaseLogsConexion claseLog = new ClaseLogsConexion();
            claseLog.Accion = "Cerró el formulario";
            claseLog.Autor = Environment.UserName;
            claseLog.IpOrigen = ipEquipo;
            claseLog.Formulario = "Base de Conocimientos - Búsqueda";

            MetodoLogsConexion metLog = new MetodoLogsConexion();
            metLog.LogsConexion_Insert(claseLog);
        }
    }
}
