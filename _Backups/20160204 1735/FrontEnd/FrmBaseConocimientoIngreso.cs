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
    public partial class FrmBaseConocimientoIngreso : Form
    {
        public FrmBaseConocimientoIngreso()
        {
            InitializeComponent();
        }
        string UsuarioConectado = Environment.UserName;
        private int IDBUSCAR;
        private string NOMBREBUSCAR;

        private void FrmBaseConocimientoIngreso_Load(object sender, EventArgs e)
        {
            Limpiar();
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

        private void Limpiar()
        {
            IDBUSCAR = 0;
            NOMBREBUSCAR = string.Empty;
            this.txtDetalle.Clear();
            this.TxtNombre.Clear();
            this.TxtObservaciones.Clear();
        }


        private void getDetalle(int IdCab)
        {
            //Limpiar();

            LogicaNegocios.Clases.ClaseConocimientoDetalle miDet = new LogicaNegocios.Clases.ClaseConocimientoDetalle();
            LogicaNegocios.Metodos.MetodoConocimiento miMetodo = new LogicaNegocios.Metodos.MetodoConocimiento();

            miDet = miMetodo.GetDetalle(IdCab);

            this.TxtNombre.Text = NOMBREBUSCAR;
            this.txtDetalle.Text = miDet.Texto;
            this.TxtObservaciones.Text = miDet.Observaciones;

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(this.txtDetalle.Text.Trim()) || string.IsNullOrEmpty(this.TxtNombre.Text.Trim()) || string.IsNullOrEmpty(this.TxtObservaciones.Text.Trim()) || this.CmbCategorias.SelectedIndex < 0)
            {
                MessageBox.Show("Favor completar todos los campos.");
            }
            else
            {
             if (IDBUSCAR == 0 )
                        {
                            LogicaNegocios.Clases.ClaseConocimientoDetalle miDet = new LogicaNegocios.Clases.ClaseConocimientoDetalle();
                            LogicaNegocios.Clases.ClaseConocimientoCabecera micab = new LogicaNegocios.Clases.ClaseConocimientoCabecera();
                            LogicaNegocios.Metodos.MetodoConocimiento miMetodo = new LogicaNegocios.Metodos.MetodoConocimiento();


                            micab.Nombre = this.TxtNombre.Text.Trim();
                

                            ComboboxItem miItem = (ComboboxItem)this.CmbCategorias.SelectedItem;
                            micab.IdCab = Convert.ToInt32 ( miItem.Value);

                            miDet.Texto = this.txtDetalle.Text.Trim();
                            miDet.Observaciones = this.TxtObservaciones.Text.Trim();
                            miDet.responsable = UsuarioConectado;

                            try
                            {
                                miMetodo.SaveDetalle(micab, miDet);
                                MessageBox.Show("Datos guardados exitosamente");
                                Limpiar();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
             else
                     {
                         LogicaNegocios.Clases.ClaseConocimientoDetalle miDet = new LogicaNegocios.Clases.ClaseConocimientoDetalle();
                         LogicaNegocios.Clases.ClaseConocimientoCabecera micab = new LogicaNegocios.Clases.ClaseConocimientoCabecera();
                         LogicaNegocios.Metodos.MetodoConocimiento miMetodo = new LogicaNegocios.Metodos.MetodoConocimiento();


                         micab.Nombre = this.TxtNombre.Text.Trim();


                         ComboboxItem miItem = (ComboboxItem)this.CmbCategorias.SelectedItem;
                         micab.IdCab = Convert.ToInt32(miItem.Value);

                         micab.Id = IDBUSCAR;

                         miDet.Texto = this.txtDetalle.Text.Trim();
                         miDet.Observaciones = this.TxtObservaciones.Text.Trim();
                         miDet.responsable = UsuarioConectado;

                         try
                         {
                             miMetodo.UpdateDetalle(micab, miDet);

                             //AQUI HAY Q HACER UN UPDATE
                             MessageBox.Show("Datos guardados exitosamente");
                             Limpiar();
                         }
                         catch (Exception ex)
                         {
                             MessageBox.Show(ex.Message);
                         }
                     }
            }

           

          
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            FrmBaseConocimientoBuscar mifrm = new FrmBaseConocimientoBuscar();
            mifrm.ShowDialog();
            IDBUSCAR = mifrm.NuevoID;
            NOMBREBUSCAR = mifrm.NuevoNombre;
            getDetalle(IDBUSCAR);
            this.CmbCategorias.SelectedIndex = Convert.ToInt32(mifrm.NuevaCat);
        }



    }
}
