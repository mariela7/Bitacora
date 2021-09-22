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

namespace FrontEnd
{
    public partial class FrmHorasExtrasIndividual : Form
    {
        public FrmHorasExtrasIndividual()
        {
            InitializeComponent();
        }

        string nombreCompleto = string.Empty;
        string ultimatix = string.Empty;
        string supervisor = string.Empty;
        string UsuarioConectado = Environment.UserName;

        private void LlenarMeses()
        {
            DataTable miTablaMeses = new DataTable("miTabla");
            miTablaMeses.Columns.Add("Id");
            miTablaMeses.Columns.Add("Nombre");
            for (int i = 1; i <= 12; i++)
            {
                miTablaMeses.Rows.Add(i, System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i).ToUpper());
            }
            this.ddlMes.DataSource = miTablaMeses;
            this.ddlMes.ValueMember = "Id";
            this.ddlMes.DisplayMember = "Nombre";

            this.ddlMes.SelectedValue = DateTime.Now.Month;
        }

        private void FrmHorasExtrasIndividual_Load(object sender, EventArgs e)
        {
            LlenarMeses();

            MetodoGeneral miMetodo = new MetodoGeneral();
            ClaseParametros parametro = new ClaseParametros();
            parametro = miMetodo.Parametros_SelectByCodigo("BBM");
            if (parametro.Valor == "ON")
            {
                MessageBox.Show("La bitácora se encuentra bloqueada por mantenimiento. Por favor contactarse con el administrador para conocer el tiempo de duración del bloqueo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.ExitThread();
            }
        }
        
        private void btnCargar_Click(object sender, EventArgs e)
        {
            string responsable = null;
            int mes = 0;

            responsable = UsuarioConectado;

            switch (ddlMes.Text)
            {
                case "ENERO":
                    mes = 1;
                    break;
                case "FEBRERO":
                    mes = 2;
                    break;
                case "MARZO":
                    mes = 3;
                    break;
                case "ABRIL":
                    mes = 4;
                    break;
                case "MAYO":
                    mes = 5;
                    break;
                case "JUNIO":
                    mes = 6;
                    break;
                case "JULIO":
                    mes = 7;
                    break;
                case "AGOSTO":
                    mes = 8;
                    break;
                case "SEPTIEMBRE":
                    mes = 9;
                    break;
                case "OCTUBRE":
                    mes = 10;
                    break;
                case "NOVIEMBRE":
                    mes = 11;
                    break;
                default:
                    mes = 12;
                    break;
            }

            Metodo_HorasExtras metodo = new Metodo_HorasExtras();
            List<ClaseHoraExtra> listado = new List<ClaseHoraExtra>();

            listado = metodo.HorasExtras_ByUsuarioAndMes(/*responsable*/"calcocer", mes);

            if (listado.Count == 0)
            {
                MessageBox.Show("Usted no tiene horas extras registradas en el mes " + ddlMes.Text, "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                dgvHorasExtras.Rows.Clear();

                txtDatos.Text = listado[0].Ultimatix + " - " + listado[0].NombreCompleto;
                nombreCompleto = listado[0].NombreCompleto;
                ultimatix = listado[0].Ultimatix;
                supervisor = listado[0].Supervisor;

                foreach (var item in listado)
                {
                    dgvHorasExtras.Rows.Add();
                    dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgSePuedeEliminar"].Value = "NO";
                    dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgIdRegistro"].Value = item.IdRegistro.ToString();
                    //dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgMes"].Value = item.Mes.ToString();

                    switch (item.Mes)
                    {
                        case 1:
                            dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgMes"].Value = "ENERO";
                            break;
                        case 2:
                            dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgMes"].Value = "FEBRERO";
                            break;
                        case 3:
                            dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgMes"].Value = "MARZO";
                            break;
                        case 4:
                            dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgMes"].Value = "ABRIL";
                            break;
                        case 5:
                            dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgMes"].Value = "MAYO";
                            break;
                        case 6:
                            dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgMes"].Value = "JUNIO";
                            break;
                        case 7:
                            dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgMes"].Value = "JULIO";
                            break;
                        case 8:
                            dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgMes"].Value = "AGOSTO";
                            break;
                        case 9:
                            dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgMes"].Value = "SEPTIEMBRE";
                            break;
                        case 10:
                            dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgMes"].Value = "OCTUBRE";
                            break;
                        case 11:
                            dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgMes"].Value = "NOVIEMBRE";
                            break;
                        default:
                            dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgMes"].Value = "DICIEMBRE";
                            break;
                    }

                    dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgDia"].Value = item.Dia.ToString();
                    dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgFechaInicio"].Value = item.FechaHoraInicio.ToString();
                    dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgFechaFin"].Value = item.FechaHoraFin.ToString();
                    dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgTiempo"].Value = item.Tiempo.ToString();
                    if ((item.EsExtra == false) || (item.EsExtra == null))
                    {
                        dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgEsExtra"].Value = false;
                    }
                    else
                    {
                        dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgEsExtra"].Value = true;
                    }

                    if (string.IsNullOrEmpty(item.Justificacion) == false)
                    {
                        dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgJustificacion"].Value = item.Justificacion.ToString();
                    }

                    if (item.HorasAprobadas != null)
                    {
                        dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgHorasAprobadas"].Value = item.HorasAprobadas.ToString();
                    }
                    else
                    {
                        dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgHorasAprobadas"].Value = "00:00:00";
                    }

                }

                dgvHorasExtras.AutoResizeColumns();
                DataGridViewColumn column = dgvHorasExtras.Columns["dgJustificacion"];
                column.Width = 300;

                DataGridViewColumn column2 = dgvHorasExtras.Columns["dgDia"];
                column2.Width = 100;

                CalcularTiempoExtra();
            }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {            
            this.dgvHorasExtras.Rows.Add();

            dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgSePuedeEliminar"].Value = "SI";            
            dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgIdRegistro"].Value = 0;
            dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgMes"].Value = dgvHorasExtras.Rows[0].Cells["dgMes"].Value;

            //this.dataGridView1[1, 1] = new DataGridViewComboBoxCell();
            dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgDia"] = new DataGridViewComboBoxCell();
            DataGridViewComboBoxCell cbCell = (DataGridViewComboBoxCell)dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgDia"];
            cbCell.Items.Add("Lunes");
            cbCell.Items.Add("Martes");
            cbCell.Items.Add("Miércoles");
            cbCell.Items.Add("Jueves");
            cbCell.Items.Add("Viernes");
            cbCell.Items.Add("Sabado");
            cbCell.Items.Add("Domingo");

            dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgDia"].ReadOnly = false;

            int mesSelect = Convert.ToInt32(ddlMes.SelectedValue);

            DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, mesSelect, 1);

            dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgFechaInicio"].Value = firstDayOfMonth;
            dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgFechaInicio"].ReadOnly = false;

            dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgFechaFin"].Value = firstDayOfMonth;
            dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgFechaFin"].ReadOnly = false;

            dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgTiempo"].Value = Convert.ToDateTime(dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgFechaFin"].Value) - Convert.ToDateTime(dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgFechaInicio"].Value);
            
            dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgEsExtra"].Value = true;
            dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgEsExtra"].ReadOnly = true;

            dgvHorasExtras.Rows[dgvHorasExtras.Rows.Count - 1].Cells["dgHorasAprobadas"].Value = "00:00:00";

            CalcularTiempoExtra();
        }

        private void dgvHorasExtras_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            bool error = false;

            int mes = 0;

            switch (ddlMes.Text)
            {
                case "ENERO":
                    mes = 1;
                    break;
                case "FEBRERO":
                    mes = 2;
                    break;
                case "MARZO":
                    mes = 3;
                    break;
                case "ABRIL":
                    mes = 4;
                    break;
                case "MAYO":
                    mes = 5;
                    break;
                case "JUNIO":
                    mes = 6;
                    break;
                case "JULIO":
                    mes = 7;
                    break;
                case "AGOSTO":
                    mes = 8;
                    break;
                case "SEPTIEMBRE":
                    mes = 9;
                    break;
                case "OCTUBRE":
                    mes = 10;
                    break;
                case "NOVIEMBRE":
                    mes = 11;
                    break;
                default:
                    mes = 12;
                    break;
            }

            try
            {
                int row = e.RowIndex;
                int color = 0;

                if ((dgvHorasExtras.Columns["dgFechaInicio"].Index == e.ColumnIndex) || (dgvHorasExtras.Columns["dgFechaFin"].Index == e.ColumnIndex))
                {
                    /*FECHA INICIO MAYOR O IGUAL QUE FECHA FIN*/
                    if ((Convert.ToDateTime(dgvHorasExtras.Rows[row].Cells["dgFechaFin"].Value)) > (Convert.ToDateTime(dgvHorasExtras.Rows[row].Cells["dgFechaInicio"].Value)))
                    {
                        color = row % 2;
                        if (color == 0)
                        {
                            dgvHorasExtras.Rows[row].Cells["dgFechaFin"].Style.BackColor = Color.White;
                            dgvHorasExtras.Rows[row].Cells["dgFechaInicio"].Style.BackColor = Color.White;
                            error = false;
                        }
                        else
                        {
                            dgvHorasExtras.Rows[row].Cells["dgFechaFin"].Style.BackColor = Color.LightBlue;
                            dgvHorasExtras.Rows[row].Cells["dgFechaInicio"].Style.BackColor = Color.LightBlue;
                            error = false;
                        }

                        dgvHorasExtras.Rows[row].Cells["dgTiempo"].Value = Convert.ToDateTime(dgvHorasExtras.Rows[row].Cells["dgFechaFin"].Value) 
                                                                            - Convert.ToDateTime(dgvHorasExtras.Rows[row].Cells["dgFechaInicio"].Value);
                        CalcularTiempoExtra();
                    }
                    else
                    {
                        dgvHorasExtras.Rows[row].Cells["dgFechaFin"].Style.BackColor = Color.Red;
                        dgvHorasExtras.Rows[row].Cells["dgFechaInicio"].Style.BackColor = Color.Red;
                        error = true;
                    }

                    /*MES NO CORRESPONDE*/
                    if (Convert.ToDateTime(dgvHorasExtras.Rows[row].Cells["dgFechaFin"].Value).Month != mes)
                    {
                        dgvHorasExtras.Rows[row].Cells["dgFechaFin"].Style.BackColor = Color.Orange;
                        error = true;
                    }
                    else
                    {
                        color = row % 2;
                        if (error == false)
                        {
                            if (color == 0)
                            {
                                dgvHorasExtras.Rows[row].Cells["dgFechaFin"].Style.BackColor = Color.White;
                                error = false;
                            }
                            else
                            {
                                dgvHorasExtras.Rows[row].Cells["dgFechaFin"].Style.BackColor = Color.LightBlue;
                                error = false;
                            }
                        }                        
                    }

                    if (Convert.ToDateTime(dgvHorasExtras.Rows[row].Cells["dgFechaInicio"].Value).Month != mes)
                    {
                        dgvHorasExtras.Rows[row].Cells["dgFechaInicio"].Style.BackColor = Color.Orange;
                        error = true;
                    }
                    else
                    {
                        color = row % 2;
                        if (error == false)
                        {
                            if (color == 0)
                            {
                                dgvHorasExtras.Rows[row].Cells["dgFechaInicio"].Style.BackColor = Color.White;
                                error = false;
                            }
                            else
                            {
                                dgvHorasExtras.Rows[row].Cells["dgFechaInicio"].Style.BackColor = Color.LightBlue;
                                error = false;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            if (dgvHorasExtras.SelectedCells.Count > 0)
            {
                foreach (DataGridViewCell item in dgvHorasExtras.SelectedCells)
                {
                    try
                    {
                        if (dgvHorasExtras.Rows[item.RowIndex].Cells["dgSePuedeEliminar"].Value.ToString() == "SI")
                        {
                            dgvHorasExtras.Rows.Remove(item.OwningRow);
                        }
                        else
                        {
                            MessageBox.Show("El registro no puede ser eliminado.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }

                    }
                    catch (Exception)
                    {

                    }
                }
            }

            CalcularTiempoExtra();
        }

        private void CalcularTiempoExtra()
        {
            TimeSpan total = new TimeSpan(0, 0, 0);

            foreach (DataGridViewRow row in dgvHorasExtras.Rows)
            {
                total = total + TimeSpan.Parse(dgvHorasExtras.Rows[row.Index].Cells["dgTiempo"].Value.ToString());
            }

            txtTotalHorasExtras.Text = Convert.ToInt32(total.TotalHours).ToString() + ":" + total.Minutes.ToString();
        }

        private void btnGrabarRegistros_Click(object sender, EventArgs e)
        {
            int totalExtras = 0;
            int mesAnterior = DateTime.Now.AddMonths(-1).Month;

            if (Convert.ToInt32(ddlMes.SelectedValue) != mesAnterior)
            {
                MessageBox.Show("No es posible modificar datos anteriores.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Stop);                
            }
            else
            {
                if (dgvHorasExtras.Rows.Count > 0)
                {
                    List<ClaseHoraExtra> listadoGuardar = new List<ClaseHoraExtra>();

                    foreach (DataGridViewRow row in dgvHorasExtras.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["dgEsExtra"].Value) == true)
                        {
                            totalExtras++;

                            if (row.Cells["dgSePuedeEliminar"].Value.ToString() == "NO")
                            {
                                if ((row.Cells["dgHorasAprobadas"].Value.ToString() != "00:00:00")
                                    && (row.Cells["dgJustificacion"].Value != null) 
                                    && (string.IsNullOrEmpty(row.Cells["dgJustificacion"].Value.ToString()) == false)

                                    && (row.Cells["dgFechaFin"].Style.BackColor != Color.Red)
                                    && (row.Cells["dgFechaInicio"].Style.BackColor != Color.Red)
                                    && (row.Cells["dgFechaFin"].Style.BackColor != Color.Orange)
                                    && (row.Cells["dgFechaInicio"].Style.BackColor != Color.Orange))
                                {
                                    //Se puede guardar - UPDATE
                                    if ((row.Index % 2) == 0)
                                    {
                                        dgvHorasExtras.Rows[row.Index].Cells["dgHorasAprobadas"].Style.BackColor = Color.White;
                                        dgvHorasExtras.Rows[row.Index].Cells["dgJustificacion"].Style.BackColor = Color.White;
                                    }
                                    else
                                    {
                                        dgvHorasExtras.Rows[row.Index].Cells["dgHorasAprobadas"].Style.BackColor = Color.LightBlue;
                                        dgvHorasExtras.Rows[row.Index].Cells["dgJustificacion"].Style.BackColor = Color.LightBlue;
                                    }

                                    ClaseHoraExtra objetoAdd = new ClaseHoraExtra();
                                    objetoAdd.InsertUpdate = 'U';
                                    objetoAdd.Aprobada = null;
                                    objetoAdd.Dia = row.Cells["dgDia"].Value.ToString();
                                    objetoAdd.EsExtra = Convert.ToBoolean(row.Cells["dgEsExtra"].Value);
                                    objetoAdd.FechaHoraFin = Convert.ToDateTime(row.Cells["dgFechaFin"].Value);
                                    objetoAdd.FechaHoraInicio = Convert.ToDateTime(row.Cells["dgFechaInicio"].Value);
                                    objetoAdd.HoraExtra = true;
                                    objetoAdd.HorasAprobadas = TimeSpan.Parse(row.Cells["dgHorasAprobadas"].Value.ToString());
                                    objetoAdd.IdRegistro = Convert.ToInt32(row.Cells["dgIdRegistro"].Value);
                                    objetoAdd.Justificacion = row.Cells["dgJustificacion"].Value.ToString();
                                    objetoAdd.Mes = Convert.ToInt32(ddlMes.SelectedValue);
                                    objetoAdd.NombreCompleto = nombreCompleto;
                                    objetoAdd.Supervisor = supervisor;
                                    objetoAdd.Tiempo = TimeSpan.Parse(row.Cells["dgTiempo"].Value.ToString());
                                    objetoAdd.Ultimatix = ultimatix;
                                    objetoAdd.UsuarioRed = UsuarioConectado;

                                    listadoGuardar.Add(objetoAdd);
                                }
                                else
                                {
                                    MessageBox.Show("Faltan datos para poder guardar la información. O los datos contienen errores, por favor validar que no existan celdas de color rojo o naranja.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    if (row.Cells["dgHorasAprobadas"].Value.ToString() == "00:00:00")
                                    {
                                        dgvHorasExtras.Rows[row.Index].Cells["dgHorasAprobadas"].Style.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        if ((row.Index % 2) == 0)
                                        {
                                            dgvHorasExtras.Rows[row.Index].Cells["dgHorasAprobadas"].Style.BackColor = Color.White;
                                        }
                                        else
                                        {
                                            dgvHorasExtras.Rows[row.Index].Cells["dgHorasAprobadas"].Style.BackColor = Color.LightBlue;
                                        }
                                    }

                                    if ((row.Cells["dgJustificacion"].Value == null) || (string.IsNullOrEmpty(row.Cells["dgJustificacion"].Value.ToString()) == false))
                                    {
                                        dgvHorasExtras.Rows[row.Index].Cells["dgJustificacion"].Style.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        if ((row.Index % 2) == 0)
                                        {
                                            dgvHorasExtras.Rows[row.Index].Cells["dgJustificacion"].Style.BackColor = Color.White;
                                        }
                                        else
                                        {
                                            dgvHorasExtras.Rows[row.Index].Cells["dgJustificacion"].Style.BackColor = Color.LightBlue;
                                        }
                                    }

                                    break;
                                }
                            }
                            else
                            {
                                if ((row.Cells["dgDia"].Value.ToString() != "")
                                    && (row.Cells["dgTiempo"].Value.ToString() != "00:00:00")
                                    && (row.Cells["dgHorasAprobadas"].Value.ToString() != "00:00:00")
                                    && ((row.Cells["dgJustificacion"].Value != null)
                                    && (string.IsNullOrEmpty(row.Cells["dgJustificacion"].Value.ToString()) == false))

                                    && (row.Cells["dgFechaFin"].Style.BackColor != Color.Red)
                                    && (row.Cells["dgFechaInicio"].Style.BackColor != Color.Red)
                                    && (row.Cells["dgFechaFin"].Style.BackColor != Color.Orange)
                                    && (row.Cells["dgFechaInicio"].Style.BackColor != Color.Orange))
                                {
                                    //Se puede guardar - INSERT
                                    if ((row.Index % 2) == 0)
                                    {
                                        dgvHorasExtras.Rows[row.Index].Cells["dgDia"].Style.BackColor = Color.White;
                                        dgvHorasExtras.Rows[row.Index].Cells["dgTiempo"].Style.BackColor = Color.White;
                                        dgvHorasExtras.Rows[row.Index].Cells["dgHorasAprobadas"].Style.BackColor = Color.White;
                                        dgvHorasExtras.Rows[row.Index].Cells["dgJustificacion"].Style.BackColor = Color.White;
                                    }
                                    else
                                    {
                                        dgvHorasExtras.Rows[row.Index].Cells["dgDia"].Style.BackColor = Color.LightBlue;
                                        dgvHorasExtras.Rows[row.Index].Cells["dgTiempo"].Style.BackColor = Color.LightBlue;
                                        dgvHorasExtras.Rows[row.Index].Cells["dgHorasAprobadas"].Style.BackColor = Color.LightBlue;
                                        dgvHorasExtras.Rows[row.Index].Cells["dgJustificacion"].Style.BackColor = Color.LightBlue;
                                    }

                                    ClaseHoraExtra objetoAdd = new ClaseHoraExtra();
                                    objetoAdd.InsertUpdate = 'I';
                                    objetoAdd.Aprobada = null;
                                    objetoAdd.Dia = row.Cells["dgDia"].Value.ToString();
                                    objetoAdd.EsExtra = Convert.ToBoolean(row.Cells["dgEsExtra"].Value);
                                    objetoAdd.FechaHoraFin = Convert.ToDateTime(row.Cells["dgFechaFin"].Value);
                                    objetoAdd.FechaHoraInicio = Convert.ToDateTime(row.Cells["dgFechaInicio"].Value);
                                    objetoAdd.HoraExtra = true;
                                    objetoAdd.HorasAprobadas = TimeSpan.Parse(row.Cells["dgHorasAprobadas"].Value.ToString());
                                    objetoAdd.IdRegistro = Convert.ToInt32(row.Cells["dgIdRegistro"].Value);
                                    objetoAdd.Justificacion = row.Cells["dgJustificacion"].Value.ToString();
                                    objetoAdd.Mes = Convert.ToInt32(ddlMes.SelectedValue);
                                    objetoAdd.NombreCompleto = nombreCompleto;
                                    objetoAdd.Supervisor = supervisor;
                                    objetoAdd.Tiempo = TimeSpan.Parse(row.Cells["dgTiempo"].Value.ToString());
                                    objetoAdd.Ultimatix = ultimatix;
                                    objetoAdd.UsuarioRed = UsuarioConectado;

                                    listadoGuardar.Add(objetoAdd);
                                }
                                else
                                {
                                    MessageBox.Show("Faltan datos para poder guardar la información. O los datos contienen errores, por favor validar que no existan celdas de color rojo o naranja.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    if (row.Cells["dgDia"].Value.ToString() == "")
                                    {
                                        dgvHorasExtras.Rows[row.Index].Cells["dgDia"].Style.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        if ((row.Index % 2) == 0)
                                        {
                                            dgvHorasExtras.Rows[row.Index].Cells["dgDia"].Style.BackColor = Color.White;
                                        }
                                        else
                                        {
                                            dgvHorasExtras.Rows[row.Index].Cells["dgDia"].Style.BackColor = Color.LightBlue;
                                        }
                                    }

                                    if (row.Cells["dgTiempo"].Value.ToString() == "00:00:00")
                                    {
                                        dgvHorasExtras.Rows[row.Index].Cells["dgTiempo"].Style.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        if ((row.Index % 2) == 0)
                                        {
                                            dgvHorasExtras.Rows[row.Index].Cells["dgTiempo"].Style.BackColor = Color.White;
                                        }
                                        else
                                        {
                                            dgvHorasExtras.Rows[row.Index].Cells["dgTiempo"].Style.BackColor = Color.LightBlue;
                                        }
                                    }

                                    if (row.Cells["dgHorasAprobadas"].Value.ToString() == "00:00:00")
                                    {
                                        dgvHorasExtras.Rows[row.Index].Cells["dgHorasAprobadas"].Style.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        if ((row.Index % 2) == 0)
                                        {
                                            dgvHorasExtras.Rows[row.Index].Cells["dgHorasAprobadas"].Style.BackColor = Color.White;
                                        }
                                        else
                                        {
                                            dgvHorasExtras.Rows[row.Index].Cells["dgHorasAprobadas"].Style.BackColor = Color.LightBlue;
                                        }
                                    }

                                    if ((row.Cells["dgJustificacion"].Value == null) || (string.IsNullOrEmpty(row.Cells["dgJustificacion"].Value.ToString()) == false))
                                    {
                                        dgvHorasExtras.Rows[row.Index].Cells["dgJustificacion"].Style.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        if ((row.Index % 2) == 0)
                                        {
                                            dgvHorasExtras.Rows[row.Index].Cells["dgJustificacion"].Style.BackColor = Color.White;
                                        }
                                        else
                                        {
                                            dgvHorasExtras.Rows[row.Index].Cells["dgJustificacion"].Style.BackColor = Color.LightBlue;
                                        }
                                    }

                                    break;
                                }
                            }
                        }
                    }

                    if (listadoGuardar.Count == totalExtras)
                    {
                        Metodo_HorasExtras metodo = new Metodo_HorasExtras();
                        int resultado = 0;
                        resultado = metodo.HorasExtras_Grabar(listadoGuardar);

                        if (resultado > 0)
                        {
                            MessageBox.Show("Los datos fueron grabados exitosamente.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Ocurrio un error al tratar de grabar la información.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No existen horas extras en el mes indicado.", "Seguridad Informática", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
