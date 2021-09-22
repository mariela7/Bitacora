using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Data.OleDb;
using LogicaNegocios.Metodos;
using LogicaNegocios.Clases;

namespace FrontEnd
{
    public partial class FrmCargarHoras : Form
    {
        public FrmCargarHoras()
        {
            InitializeComponent();
        }

        Metodo_HorasExtras metodo = new Metodo_HorasExtras();

        private void btnSelectArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string completo = openFileDialog1.FileName;
                string archivo = openFileDialog1.SafeFileName;
                string ruta = Path.GetDirectoryName(completo);

                lblNombreArchivo.Text = archivo;

                String name = "Hoja1";
                String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                completo +
                                ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                OleDbConnection con = new OleDbConnection(constr);
                OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
                con.Open();

                OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                DataTable data = new DataTable();
                sda.Fill(data);
                dgvExcel.DataSource = data;

                dgvExcel.AutoResizeColumns();

                QuitarDuplicados(dgvExcel);

                btnSubir.Enabled = true;
            }
        }

        private void QuitarDuplicados(DataGridView dgView)
        {
            int m = 0;  // Apunta a la fila actual
            int n = dgView.Rows.Count - 1;  // cantidad de filas en el DataGridView
            int k;
            string estaFila, unaFila;

            while (m < n)
            {
                k = 1;
                estaFila = String.Empty;

                 // Relleno la cadena con los datos de toda la fila
                for (int i = 0; i < dgView.Columns.Count; i++)
                {
                    estaFila = String.Concat(estaFila, dgView.Rows[m].Cells[i].Value.ToString());                    
                }

                while (k < n)
                {
                    unaFila = String.Empty;  // Fila a comparar

                    for (int i = 0; i < dgView.Columns.Count; i++)
                    {
                        unaFila = String.Concat(unaFila, dgView.Rows[k].Cells[i].Value.ToString());                        
                    }

                    if (String.Compare(estaFila, unaFila) == 0 && k != m)
                    {
                        dgView.Rows.RemoveAt(k); // Si son iguales remuevo unaFila solamente
                        n--;     // Tamaño actual del DataGridView, al remover disminuye en uno
                    }
                    else
                    {
                        k++;
                    }
                    //k++;
                }
                m++;
            }
        }        

        private void btnSubir_Click(object sender, EventArgs e)
        {
            int mes = Convert.ToDateTime(dgvExcel.Rows[0].Cells[4].Value.ToString()).Month;

            int resultado = metodo.HorasExtras_Validar("CARGA", mes);

            if (resultado == 0)
            {
                string ultimatix;
                string dia;
                DateTime fechaHora;

                foreach (DataGridViewRow fila in dgvExcel.Rows)
                {
                    if (string.IsNullOrEmpty(fila.Cells[4].Value.ToString()) == false)
                    {
                        ultimatix = fila.Cells[1].Value.ToString();
                        dia = fila.Cells[3].Value.ToString();
                        fechaHora = Convert.ToDateTime(fila.Cells[4].Value.ToString());

                        metodo.SeguridadInformatica_HorasTrabajadas_Insert(ultimatix, dia, fechaHora);
                    }
                }
                MessageBox.Show("Los datos fueron grabados exitosamente.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvExcel.Rows.Clear();

                btnSubir.Enabled = false;
                btnGenerarHoras.Enabled = true;
            }
            else
            {
                MessageBox.Show("Los datos del mes "+ mes.ToString() +" ya fueron cargados a la Base de Datos.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGenerarHoras.Enabled = true;
            }
        }

        private void FrmCargarHoras_Load(object sender, EventArgs e)
        {
            btnSubir.Enabled = false;
            btnGenerarHoras.Enabled = false;

            MetodoGeneral miMetodo = new MetodoGeneral();
            ClaseParametros parametro = new ClaseParametros();
            parametro = miMetodo.Parametros_SelectByCodigo("BBM");
            if (parametro.Valor == "ON")
            {
                MessageBox.Show("La bitácora se encuentra bloqueada por mantenimiento. Por favor contactarse con el administrador para conocer el tiempo de duración del bloqueo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.ExitThread();
            }
        }

        private void btnGenerarHoras_Click(object sender, EventArgs e)
        {
            int mes = Convert.ToDateTime(dgvExcel.Rows[0].Cells[4].Value.ToString()).Month;

            int resultado = metodo.HorasExtras_Validar("CALCULO", mes);

            if (resultado == 0)
            {
                int res = metodo.HorasExtras_Calcular(mes);

                if (res == 1)
                {
                    MessageBox.Show("Los datos fueron generados exitosamente.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //dgvExcel.Rows.Clear();
                    
                    btnGenerarHoras.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al calcular las horas extras.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Las horas extras del mes " + mes.ToString() + " ya fueron calculadas.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGenerarHoras.Enabled = false;
            }
        }
    }
}
