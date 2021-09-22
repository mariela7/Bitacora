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
    public partial class FrmBaseConocimientoCategorias : Form
    {
        public FrmBaseConocimientoCategorias()
        {
            InitializeComponent();
        }

        private void FrmBaseConocimientoCategorias_Load(object sender, EventArgs e)
        {

            IDMODIFICAR= 0;
            VALORMODIFICAR= "";
            getCategorias();
        }


        int IDMODIFICAR;
        string VALORMODIFICAR;

        private void getCategorias()
        {
            this.LBCategorias.Items.Clear();
            List<LogicaNegocios.Clases.ClaseConocimientoCategoria> miListaCat = new List<LogicaNegocios.Clases.ClaseConocimientoCategoria>();
            LogicaNegocios.Metodos.MetodoConocimiento miMetodo = new LogicaNegocios.Metodos.MetodoConocimiento();

            miListaCat = miMetodo.GetCategorias();

            foreach (var item in miListaCat)
            {
                ComboboxItem miItem = new ComboboxItem();
                miItem.Text = item.Nombre;
                miItem.Value = item.Id;
                this.LBCategorias.Items.Add(miItem);
            }


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (IDMODIFICAR == 0)
            {
                List<LogicaNegocios.Clases.ClaseConocimientoCategoria> miListaCat = new List<LogicaNegocios.Clases.ClaseConocimientoCategoria>();
                LogicaNegocios.Metodos.MetodoConocimiento miMetodo = new LogicaNegocios.Metodos.MetodoConocimiento();

                miListaCat = miMetodo.GetCategorias();

                int ban = 0; 
                foreach (LogicaNegocios.Clases.ClaseConocimientoCategoria item in miListaCat)
                {
                    if (item.Nombre == TxtNombre.Text.Trim())
                    {
                        MessageBox.Show("La Categoría ya existe. Favor validar el nombre.", 
                                        "Seguridad Informática",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);

                        ban = 1;
                    }
                }

                if (ban == 0 )
                {
                    LogicaNegocios.Clases.ClaseConocimientoCategoria NCategoria = new LogicaNegocios.Clases.ClaseConocimientoCategoria();
                    NCategoria.Nombre = this.TxtNombre.Text.Trim();
                    miMetodo.InsertCategoria(NCategoria);
                    MessageBox.Show("Los datos fueron grabados exitosamente.",
                                    "Seguridad Informática",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    btnModificar.Enabled = true;
                }
            }
            else
            {
                List<LogicaNegocios.Clases.ClaseConocimientoCategoria> miListaCat = new List<LogicaNegocios.Clases.ClaseConocimientoCategoria>();
                LogicaNegocios.Metodos.MetodoConocimiento miMetodo = new LogicaNegocios.Metodos.MetodoConocimiento();

                miListaCat = miMetodo.GetCategorias();

                int ban = 0;
                foreach (LogicaNegocios.Clases.ClaseConocimientoCategoria item in miListaCat)
                {
                    if (item.Nombre == TxtNombre.Text.Trim())
                    {
                        MessageBox.Show("La Categoría ya existe. Favor validar el nombre.",
                                    "Seguridad Informática",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Stop);



                        ban = 1;
                    }
                }

                if (ban == 0)
                {
                    LogicaNegocios.Clases.ClaseConocimientoCategoria NCategoria = new LogicaNegocios.Clases.ClaseConocimientoCategoria();
                    NCategoria.Id = IDMODIFICAR;
                    NCategoria.Nombre = this.TxtNombre.Text.Trim();
                    miMetodo.UpdateCategoria(NCategoria);
                    MessageBox.Show("Los datos fueron actualizados exitosamente.",
                                    "Seguridad Informática",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }

            }

            getCategorias();
            this.TxtNombre.Clear();
            this.btnNueva.Enabled = true;
            this.TxtNombre.ReadOnly = true;
            this.LBCategorias.Enabled = true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.btnNueva.Enabled = false;
            this.LBCategorias.Enabled = false;
            this.TxtNombre.ReadOnly = false;
            IDMODIFICAR = 0;
            
            ComboboxItem miItem = (ComboboxItem)this.LBCategorias.SelectedItem;
            IDMODIFICAR= Convert.ToInt32( miItem.Value);
            this.TxtNombre.Text = miItem.Text;
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            IDMODIFICAR = 0;
            btnModificar.Enabled = false;
            this.LBCategorias.Enabled = false;
            this.TxtNombre.ReadOnly = false;
            this.TxtNombre.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.btnNueva.Enabled = true;
            this.btnModificar.Enabled = true;
            this.LBCategorias.Enabled = true;
            this.TxtNombre.ReadOnly = false;
            this.TxtNombre.Clear();
            getCategorias();

        }
    }
}
