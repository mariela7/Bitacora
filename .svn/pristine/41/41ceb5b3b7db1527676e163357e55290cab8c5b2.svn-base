using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LogicaNegocios;

namespace FrontEnd
{
    public partial class FrmBaseConocimiento : Form
    {
        public FrmBaseConocimiento()
        {
            InitializeComponent();
        }

        private void FrmBaseConocimiento_Load(object sender, EventArgs e)
        {
            this.LBLNombreCab.Text = "";
            getCategorias();
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

            this.TxtDetalle.Clear();
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
            this.TxtDetalle.Clear();
            this.TxtObservaciones.Clear();
            this.TxtResponsable.Clear();
            this.TxtFechaIngreso.Clear();
            this.LBLNombreCab.Text = "";


            LogicaNegocios.Clases.ClaseConocimientoDetalle miDet = new LogicaNegocios.Clases.ClaseConocimientoDetalle();
            LogicaNegocios.Metodos.MetodoConocimiento miMetodo = new LogicaNegocios.Metodos.MetodoConocimiento();

            miDet = miMetodo.GetDetalle(IdCab);

            this.LBLNombreCab.Text = LBItems.SelectedItem.ToString();
            this.TxtDetalle.Text = miDet.Texto;
            this.TxtObservaciones.Text = miDet.Observaciones;
            this.TxtResponsable.Text = miDet.responsable;
            this.TxtFechaIngreso.Text = miDet.FechaIngreso.ToShortDateString();
            


        }



        private void CmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CmbCategorias.SelectedIndex >=0)
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

