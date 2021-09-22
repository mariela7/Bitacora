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
    public partial class FrmBaseConocimientoBuscar : Form
    {
        public FrmBaseConocimientoBuscar()
        {
            InitializeComponent();
        }

        public int NuevoID = 0;
        public string NuevoNombre = string.Empty;
        public int NuevaCat;

        private void FrmBaseConocimientoBuscar_Load(object sender, EventArgs e)
        {
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
    }
}
