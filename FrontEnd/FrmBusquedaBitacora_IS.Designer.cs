namespace FrontEnd
{
    partial class FrmBusquedaBitacora_IS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkHoraExtra = new System.Windows.Forms.CheckBox();
            this.ddlHorasExtras = new System.Windows.Forms.ComboBox();
            this.btnExportar = new System.Windows.Forms.Button();
            this.chkfechafin = new System.Windows.Forms.CheckBox();
            this.chkFechaInicio = new System.Windows.Forms.CheckBox();
            this.chkServicio = new System.Windows.Forms.CheckBox();
            this.chkAno = new System.Windows.Forms.CheckBox();
            this.ddlAno = new System.Windows.Forms.ComboBox();
            this.chkMes = new System.Windows.Forms.CheckBox();
            this.ddlMes = new System.Windows.Forms.ComboBox();
            this.chkEmpresa = new System.Windows.Forms.CheckBox();
            this.chkTodos = new System.Windows.Forms.CheckBox();
            this.ddlEmpresa = new System.Windows.Forms.ComboBox();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.btnCargarDatos = new System.Windows.Forms.Button();
            this.ddlCategoria = new System.Windows.Forms.ComboBox();
            this.dgvBitacora = new System.Windows.Forms.DataGridView();
            this.dgIdRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgIdServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgIdCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTarea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFrecuencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgEvidencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgEsfuerzo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalHoras = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.chkHoraExtra);
            this.groupBox1.Controls.Add(this.ddlHorasExtras);
            this.groupBox1.Controls.Add(this.btnExportar);
            this.groupBox1.Controls.Add(this.chkfechafin);
            this.groupBox1.Controls.Add(this.chkFechaInicio);
            this.groupBox1.Controls.Add(this.chkServicio);
            this.groupBox1.Controls.Add(this.chkAno);
            this.groupBox1.Controls.Add(this.ddlAno);
            this.groupBox1.Controls.Add(this.chkMes);
            this.groupBox1.Controls.Add(this.ddlMes);
            this.groupBox1.Controls.Add(this.chkEmpresa);
            this.groupBox1.Controls.Add(this.chkTodos);
            this.groupBox1.Controls.Add(this.ddlEmpresa);
            this.groupBox1.Controls.Add(this.dtpFechaFin);
            this.groupBox1.Controls.Add(this.dtpFechaInicio);
            this.groupBox1.Controls.Add(this.btnCargarDatos);
            this.groupBox1.Controls.Add(this.ddlCategoria);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1203, 140);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar por:";
            // 
            // chkHoraExtra
            // 
            this.chkHoraExtra.AutoSize = true;
            this.chkHoraExtra.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHoraExtra.ForeColor = System.Drawing.Color.Black;
            this.chkHoraExtra.Location = new System.Drawing.Point(15, 109);
            this.chkHoraExtra.Name = "chkHoraExtra";
            this.chkHoraExtra.Size = new System.Drawing.Size(106, 18);
            this.chkHoraExtra.TabIndex = 37;
            this.chkHoraExtra.Text = "¿Horas extras?";
            this.chkHoraExtra.UseVisualStyleBackColor = true;
            this.chkHoraExtra.CheckedChanged += new System.EventHandler(this.chkHoraExtra_CheckedChanged);
            // 
            // ddlHorasExtras
            // 
            this.ddlHorasExtras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlHorasExtras.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlHorasExtras.FormattingEnabled = true;
            this.ddlHorasExtras.Location = new System.Drawing.Point(136, 107);
            this.ddlHorasExtras.Name = "ddlHorasExtras";
            this.ddlHorasExtras.Size = new System.Drawing.Size(85, 22);
            this.ddlHorasExtras.TabIndex = 36;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.White;
            this.btnExportar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.Color.Black;
            this.btnExportar.Image = global::FrontEnd.Properties.Resources.MS_Excel_40;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.Location = new System.Drawing.Point(445, 78);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(150, 50);
            this.btnExportar.TabIndex = 35;
            this.btnExportar.Text = "Exportar a Excel";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // chkfechafin
            // 
            this.chkfechafin.AutoSize = true;
            this.chkfechafin.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkfechafin.ForeColor = System.Drawing.Color.Black;
            this.chkfechafin.Location = new System.Drawing.Point(708, 80);
            this.chkfechafin.Name = "chkfechafin";
            this.chkfechafin.Size = new System.Drawing.Size(92, 18);
            this.chkfechafin.TabIndex = 34;
            this.chkfechafin.Text = "Por fecha fin";
            this.chkfechafin.UseVisualStyleBackColor = true;
            this.chkfechafin.CheckedChanged += new System.EventHandler(this.chkfechafin_CheckedChanged);
            // 
            // chkFechaInicio
            // 
            this.chkFechaInicio.AutoSize = true;
            this.chkFechaInicio.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFechaInicio.ForeColor = System.Drawing.Color.Black;
            this.chkFechaInicio.Location = new System.Drawing.Point(708, 51);
            this.chkFechaInicio.Name = "chkFechaInicio";
            this.chkFechaInicio.Size = new System.Drawing.Size(110, 18);
            this.chkFechaInicio.TabIndex = 33;
            this.chkFechaInicio.Text = "Por fecha inicio";
            this.chkFechaInicio.UseVisualStyleBackColor = true;
            this.chkFechaInicio.CheckedChanged += new System.EventHandler(this.chkFechaInicio_CheckedChanged);
            // 
            // chkServicio
            // 
            this.chkServicio.AutoSize = true;
            this.chkServicio.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkServicio.ForeColor = System.Drawing.Color.Black;
            this.chkServicio.Location = new System.Drawing.Point(708, 109);
            this.chkServicio.Name = "chkServicio";
            this.chkServicio.Size = new System.Drawing.Size(88, 18);
            this.chkServicio.TabIndex = 32;
            this.chkServicio.Text = "Por Servicio";
            this.chkServicio.UseVisualStyleBackColor = true;
            this.chkServicio.CheckedChanged += new System.EventHandler(this.chkServicio_CheckedChanged);
            // 
            // chkAno
            // 
            this.chkAno.AutoSize = true;
            this.chkAno.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAno.ForeColor = System.Drawing.Color.Black;
            this.chkAno.Location = new System.Drawing.Point(15, 80);
            this.chkAno.Name = "chkAno";
            this.chkAno.Size = new System.Drawing.Size(67, 18);
            this.chkAno.TabIndex = 31;
            this.chkAno.Text = "Por Año";
            this.chkAno.UseVisualStyleBackColor = true;
            this.chkAno.CheckedChanged += new System.EventHandler(this.chkAno_CheckedChanged);
            // 
            // ddlAno
            // 
            this.ddlAno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlAno.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlAno.FormattingEnabled = true;
            this.ddlAno.Location = new System.Drawing.Point(136, 78);
            this.ddlAno.Name = "ddlAno";
            this.ddlAno.Size = new System.Drawing.Size(85, 22);
            this.ddlAno.TabIndex = 30;
            // 
            // chkMes
            // 
            this.chkMes.AutoSize = true;
            this.chkMes.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMes.ForeColor = System.Drawing.Color.Black;
            this.chkMes.Location = new System.Drawing.Point(15, 51);
            this.chkMes.Name = "chkMes";
            this.chkMes.Size = new System.Drawing.Size(69, 18);
            this.chkMes.TabIndex = 29;
            this.chkMes.Text = "Por mes";
            this.chkMes.UseVisualStyleBackColor = true;
            this.chkMes.CheckedChanged += new System.EventHandler(this.chkMes_CheckedChanged);
            // 
            // ddlMes
            // 
            this.ddlMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlMes.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlMes.FormattingEnabled = true;
            this.ddlMes.Location = new System.Drawing.Point(136, 49);
            this.ddlMes.Name = "ddlMes";
            this.ddlMes.Size = new System.Drawing.Size(180, 22);
            this.ddlMes.TabIndex = 28;
            // 
            // chkEmpresa
            // 
            this.chkEmpresa.AutoSize = true;
            this.chkEmpresa.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEmpresa.ForeColor = System.Drawing.Color.Black;
            this.chkEmpresa.Location = new System.Drawing.Point(708, 22);
            this.chkEmpresa.Name = "chkEmpresa";
            this.chkEmpresa.Size = new System.Drawing.Size(94, 18);
            this.chkEmpresa.TabIndex = 27;
            this.chkEmpresa.Text = "Por empresa";
            this.chkEmpresa.UseVisualStyleBackColor = true;
            this.chkEmpresa.CheckedChanged += new System.EventHandler(this.chkEmpresa_CheckedChanged);
            // 
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            this.chkTodos.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTodos.ForeColor = System.Drawing.Color.Black;
            this.chkTodos.Location = new System.Drawing.Point(15, 22);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Size = new System.Drawing.Size(58, 18);
            this.chkTodos.TabIndex = 26;
            this.chkTodos.Text = "Todos";
            this.chkTodos.UseVisualStyleBackColor = true;
            this.chkTodos.CheckedChanged += new System.EventHandler(this.chkTodos_CheckedChanged);
            // 
            // ddlEmpresa
            // 
            this.ddlEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlEmpresa.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlEmpresa.FormattingEnabled = true;
            this.ddlEmpresa.Location = new System.Drawing.Point(836, 20);
            this.ddlEmpresa.Name = "ddlEmpresa";
            this.ddlEmpresa.Size = new System.Drawing.Size(277, 22);
            this.ddlEmpresa.TabIndex = 12;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Location = new System.Drawing.Point(836, 78);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(277, 22);
            this.dtpFechaFin.TabIndex = 10;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Location = new System.Drawing.Point(836, 49);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(277, 22);
            this.dtpFechaInicio.TabIndex = 9;
            // 
            // btnCargarDatos
            // 
            this.btnCargarDatos.BackColor = System.Drawing.Color.White;
            this.btnCargarDatos.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarDatos.ForeColor = System.Drawing.Color.Black;
            this.btnCargarDatos.Image = global::FrontEnd.Properties.Resources.Report_Card_40;
            this.btnCargarDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCargarDatos.Location = new System.Drawing.Point(445, 22);
            this.btnCargarDatos.Name = "btnCargarDatos";
            this.btnCargarDatos.Size = new System.Drawing.Size(150, 50);
            this.btnCargarDatos.TabIndex = 7;
            this.btnCargarDatos.Text = "Cargar datos";
            this.btnCargarDatos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCargarDatos.UseVisualStyleBackColor = false;
            this.btnCargarDatos.Click += new System.EventHandler(this.btnCargarDatos_Click);
            // 
            // ddlCategoria
            // 
            this.ddlCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCategoria.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlCategoria.FormattingEnabled = true;
            this.ddlCategoria.Location = new System.Drawing.Point(836, 107);
            this.ddlCategoria.Name = "ddlCategoria";
            this.ddlCategoria.Size = new System.Drawing.Size(302, 22);
            this.ddlCategoria.TabIndex = 6;
            // 
            // dgvBitacora
            // 
            this.dgvBitacora.AllowUserToAddRows = false;
            this.dgvBitacora.AllowUserToDeleteRows = false;
            this.dgvBitacora.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dgvBitacora.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBitacora.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBitacora.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBitacora.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgIdRegistro,
            this.dgIdServicio,
            this.dgServicio,
            this.dgIdCategoria,
            this.dgCategoria,
            this.dgEmpresa,
            this.dgFechaInicio,
            this.dgFechaFin,
            this.dgTarea,
            this.dgFrecuencia,
            this.dgEvidencia,
            this.dgEsfuerzo});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBitacora.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBitacora.Location = new System.Drawing.Point(0, 146);
            this.dgvBitacora.Name = "dgvBitacora";
            this.dgvBitacora.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBitacora.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBitacora.RowHeadersVisible = false;
            this.dgvBitacora.Size = new System.Drawing.Size(1188, 283);
            this.dgvBitacora.TabIndex = 2;
            this.dgvBitacora.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBitacora_CellDoubleClick);
            // 
            // dgIdRegistro
            // 
            this.dgIdRegistro.HeaderText = "IdRegistro";
            this.dgIdRegistro.Name = "dgIdRegistro";
            this.dgIdRegistro.ReadOnly = true;
            this.dgIdRegistro.Visible = false;
            // 
            // dgIdServicio
            // 
            this.dgIdServicio.HeaderText = "IdServicio";
            this.dgIdServicio.Name = "dgIdServicio";
            this.dgIdServicio.ReadOnly = true;
            this.dgIdServicio.Visible = false;
            // 
            // dgServicio
            // 
            this.dgServicio.HeaderText = "Servicio";
            this.dgServicio.Name = "dgServicio";
            this.dgServicio.ReadOnly = true;
            this.dgServicio.Width = 200;
            // 
            // dgIdCategoria
            // 
            this.dgIdCategoria.HeaderText = "IdCategoria";
            this.dgIdCategoria.Name = "dgIdCategoria";
            this.dgIdCategoria.ReadOnly = true;
            this.dgIdCategoria.Visible = false;
            // 
            // dgCategoria
            // 
            this.dgCategoria.HeaderText = "Categoria";
            this.dgCategoria.Name = "dgCategoria";
            this.dgCategoria.ReadOnly = true;
            this.dgCategoria.Width = 150;
            // 
            // dgEmpresa
            // 
            this.dgEmpresa.HeaderText = "Empresa";
            this.dgEmpresa.Name = "dgEmpresa";
            this.dgEmpresa.ReadOnly = true;
            // 
            // dgFechaInicio
            // 
            this.dgFechaInicio.HeaderText = "Fecha Inicio";
            this.dgFechaInicio.Name = "dgFechaInicio";
            this.dgFechaInicio.ReadOnly = true;
            // 
            // dgFechaFin
            // 
            this.dgFechaFin.HeaderText = "Fecha Fin";
            this.dgFechaFin.Name = "dgFechaFin";
            this.dgFechaFin.ReadOnly = true;
            // 
            // dgTarea
            // 
            this.dgTarea.HeaderText = "Tarea";
            this.dgTarea.Name = "dgTarea";
            this.dgTarea.ReadOnly = true;
            this.dgTarea.Width = 250;
            // 
            // dgFrecuencia
            // 
            this.dgFrecuencia.HeaderText = "Frecuencia";
            this.dgFrecuencia.Name = "dgFrecuencia";
            this.dgFrecuencia.ReadOnly = true;
            // 
            // dgEvidencia
            // 
            this.dgEvidencia.HeaderText = "Evidencia";
            this.dgEvidencia.Name = "dgEvidencia";
            this.dgEvidencia.ReadOnly = true;
            this.dgEvidencia.Width = 300;
            // 
            // dgEsfuerzo
            // 
            this.dgEsfuerzo.HeaderText = "Esfuerzo";
            this.dgEsfuerzo.Name = "dgEsfuerzo";
            this.dgEsfuerzo.ReadOnly = true;
            this.dgEsfuerzo.Width = 80;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1009, 440);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Total Horas:";
            // 
            // txtTotalHoras
            // 
            this.txtTotalHoras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalHoras.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalHoras.Location = new System.Drawing.Point(1103, 431);
            this.txtTotalHoras.Name = "txtTotalHoras";
            this.txtTotalHoras.Size = new System.Drawing.Size(100, 29);
            this.txtTotalHoras.TabIndex = 5;
            // 
            // FrmBusquedaBitacora_IS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1203, 471);
            this.Controls.Add(this.txtTotalHoras);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvBitacora);
            this.MaximumSize = new System.Drawing.Size(1219, 728);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1219, 498);
            this.Name = "FrmBusquedaBitacora_IS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bitácora Ingeniería de Seguridad - Búsqueda";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBusquedaBitacora_IS_FormClosing);
            this.Load += new System.EventHandler(this.FrmBusquedaBitacora_IS_Load);
            this.Resize += new System.EventHandler(this.FrmBusquedaBitacora_IS_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCargarDatos;
        private System.Windows.Forms.ComboBox ddlCategoria;
        private System.Windows.Forms.DataGridView dgvBitacora;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.ComboBox ddlEmpresa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalHoras;
        private System.Windows.Forms.CheckBox chkTodos;
        private System.Windows.Forms.CheckBox chkEmpresa;
        private System.Windows.Forms.CheckBox chkMes;
        private System.Windows.Forms.ComboBox ddlMes;
        private System.Windows.Forms.CheckBox chkAno;
        private System.Windows.Forms.ComboBox ddlAno;
        private System.Windows.Forms.CheckBox chkServicio;
        private System.Windows.Forms.CheckBox chkfechafin;
        private System.Windows.Forms.CheckBox chkFechaInicio;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.CheckBox chkHoraExtra;
        private System.Windows.Forms.ComboBox ddlHorasExtras;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgIdRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgIdServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgIdCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFechaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTarea;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFrecuencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEvidencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEsfuerzo;
    }
}