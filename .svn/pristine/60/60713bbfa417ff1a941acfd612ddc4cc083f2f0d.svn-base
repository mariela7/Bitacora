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
    public partial class FrmBaseConocimiento : Form
    {
        //private static FrmBaseConocimiento m_FormDefInstance;
        //public static FrmBaseConocimiento DefInstance
        //{
        //    get
        //    {
        //        if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
        //        {
        //            m_FormDefInstance = new FrmBaseConocimiento();
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

        string ipEquipo = string.Empty;

        public FrmBaseConocimiento()
        {
            InitializeComponent();
        }

        private void FrmBaseConocimiento_Load(object sender, EventArgs e)
        {
            this.LBLNombreCab.Text = "";
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
            claseLog.Formulario = "Base de Conocimientos";

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
        
        private void getCabeceras(int IdCat)
        {
            this.LBItems.Items.Clear();
            //this.TxtDetalle.Clear();
            rtxtContenido.Clear();
            this.TxtObservaciones.Clear();
            this.TxtResponsable.Clear();
            this.TxtFechaIngreso.Clear();
            this.LBLNombreCab.Text = "";

            List<LogicaNegocios.Clases.ClaseConocimientoCabecera> miListaCab = new List<LogicaNegocios.Clases.ClaseConocimientoCabecera>();
            LogicaNegocios.Metodos.MetodoConocimiento miMetodo = new LogicaNegocios.Metodos.MetodoConocimiento();

            miListaCab = miMetodo.GetCabeceras(IdCat);

            foreach (var item in miListaCab)
            {

                ComboboxItem miItem = new ComboboxItem();
                miItem.Text = item.Nombre;
                miItem.Value = item.Id;

                LBItems.Items.Add(miItem);
            }

        }

        private void getDetalle(int IdCab)
        {
            //this.TxtDetalle.Clear();
            rtxtContenido.Clear();
            this.TxtObservaciones.Clear();
            this.TxtResponsable.Clear();
            this.TxtFechaIngreso.Clear();
            this.LBLNombreCab.Text = "";


            LogicaNegocios.Clases.ClaseConocimientoDetalle miDet = new LogicaNegocios.Clases.ClaseConocimientoDetalle();
            LogicaNegocios.Metodos.MetodoConocimiento miMetodo = new LogicaNegocios.Metodos.MetodoConocimiento();

            miDet = miMetodo.GetDetalle(IdCab);

            this.LBLNombreCab.Text = LBItems.SelectedItem.ToString();
            //this.TxtDetalle.Text = miDet.Texto;
            rtxtContenido.Rtf = miDet.Texto;
            this.TxtObservaciones.Text = miDet.Observaciones;
            this.TxtResponsable.Text = miDet.responsable;
            this.TxtFechaIngreso.Text = miDet.FechaIngreso.ToShortDateString();
            this.txtFechaActualizacion.Text = miDet.FechaActualizacion.ToShortDateString();
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

        private void LBItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (LBItems.SelectedIndex >= 0)
                {
                    ComboboxItem miItem = (ComboboxItem)LBItems.SelectedItem;

                    getDetalle((int)miItem.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmBaseConocimiento_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClaseLogsConexion claseLog = new ClaseLogsConexion();
            claseLog.Accion = "Cerró el formulario";
            claseLog.Autor = Environment.UserName;
            claseLog.IpOrigen = ipEquipo;
            claseLog.Formulario = "Base de Conocimientos";

            MetodoLogsConexion metLog = new MetodoLogsConexion();
            metLog.LogsConexion_Insert(claseLog);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

}

