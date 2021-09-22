namespace FrontEnd
{
    partial class FrmHorasExtrasIndividual
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
            this.dgvHorasExtras = new System.Windows.Forms.DataGridView();
            this.dgSePuedeEliminar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgIdRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgMes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTiempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgEsExtra = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgHorasAprobadas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgJustificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ddlMes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCargar = new System.Windows.Forms.Button();
            this.txtDatos = new System.Windows.Forms.TextBox();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.btnGrabarRegistros = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTotalHorasExtras = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorasExtras)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHorasExtras
            // 
            this.dgvHorasExtras.AllowUserToAddRows = false;
            this.dgvHorasExtras.AllowUserToDeleteRows = false;
            this.dgvHorasExtras.AllowUserToOrderColumns = true;
            this.dgvHorasExtras.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dgvHorasExtras.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHorasExtras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHorasExtras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHorasExtras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgSePuedeEliminar,
            this.dgIdRegistro,
            this.dgMes,
            this.dgDia,
            this.dgFechaInicio,
            this.dgFechaFin,
            this.dgTiempo,
            this.dgEsExtra,
            this.dgHorasAprobadas,
            this.dgJustificacion});
            this.dgvHorasExtras.Location = new System.Drawing.Point(15, 168);
            this.dgvHorasExtras.Name = "dgvHorasExtras";
            this.dgvHorasExtras.RowHeadersVisible = false;
            this.dgvHorasExtras.Size = new System.Drawing.Size(1085, 236);
            this.dgvHorasExtras.TabIndex = 0;
            this.dgvHorasExtras.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHorasExtras_CellEndEdit);
            // 
            // dgSePuedeEliminar
            // 
            this.dgSePuedeEliminar.HeaderText = "Eliminar?";
            this.dgSePuedeEliminar.Name = "dgSePuedeEliminar";
            this.dgSePuedeEliminar.ReadOnly = true;
            // 
            // dgIdRegistro
            // 
            this.dgIdRegistro.HeaderText = "IdRegistro";
            this.dgIdRegistro.Name = "dgIdRegistro";
            this.dgIdRegistro.ReadOnly = true;
            // 
            // dgMes
            // 
            this.dgMes.HeaderText = "Mes";
            this.dgMes.Name = "dgMes";
            this.dgMes.ReadOnly = true;
            // 
            // dgDia
            // 
            this.dgDia.HeaderText = "Dia";
            this.dgDia.Name = "dgDia";
            this.dgDia.ReadOnly = true;
            // 
            // dgFechaInicio
            // 
            this.dgFechaInicio.HeaderText = "Fecha y Hora Inicio";
            this.dgFechaInicio.Name = "dgFechaInicio";
            this.dgFechaInicio.ReadOnly = true;
            // 
            // dgFechaFin
            // 
            this.dgFechaFin.HeaderText = "Fecha y Hora Fin";
            this.dgFechaFin.Name = "dgFechaFin";
            this.dgFechaFin.ReadOnly = true;
            // 
            // dgTiempo
            // 
            this.dgTiempo.HeaderText = "Tiempo";
            this.dgTiempo.Name = "dgTiempo";
            this.dgTiempo.ReadOnly = true;
            // 
            // dgEsExtra
            // 
            this.dgEsExtra.HeaderText = "Hora Extra SI/NO";
            this.dgEsExtra.Name = "dgEsExtra";
            this.dgEsExtra.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgEsExtra.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgHorasAprobadas
            // 
            this.dgHorasAprobadas.HeaderText = "Horas Aprobadas";
            this.dgHorasAprobadas.Name = "dgHorasAprobadas";
            // 
            // dgJustificacion
            // 
            this.dgJustificacion.HeaderText = "Justificación";
            this.dgJustificacion.Name = "dgJustificacion";
            this.dgJustificacion.Width = 300;
            // 
            // ddlMes
            // 
            this.ddlMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlMes.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlMes.FormattingEnabled = true;
            this.ddlMes.Location = new System.Drawing.Point(45, 7);
            this.ddlMes.Name = "ddlMes";
            this.ddlMes.Size = new System.Drawing.Size(277, 22);
            this.ddlMes.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 14);
            this.label1.TabIndex = 19;
            this.label1.Text = "Mes:";
            // 
            // btnCargar
            // 
            this.btnCargar.BackColor = System.Drawing.Color.White;
            this.btnCargar.Image = global::FrontEnd.Properties.Resources.Report_Card_40;
            this.btnCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCargar.Location = new System.Drawing.Point(328, 3);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(140, 50);
            this.btnCargar.TabIndex = 20;
            this.btnCargar.Text = "Cargar Datos";
            this.btnCargar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // txtDatos
            // 
            this.txtDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDatos.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatos.Location = new System.Drawing.Point(15, 134);
            this.txtDatos.Name = "txtDatos";
            this.txtDatos.ReadOnly = true;
            this.txtDatos.Size = new System.Drawing.Size(1085, 27);
            this.txtDatos.TabIndex = 22;
            // 
            // btnAddRow
            // 
            this.btnAddRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRow.BackColor = System.Drawing.Color.White;
            this.btnAddRow.Image = global::FrontEnd.Properties.Resources.Add_Row_40;
            this.btnAddRow.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddRow.Location = new System.Drawing.Point(814, 6);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(150, 50);
            this.btnAddRow.TabIndex = 23;
            this.btnAddRow.Text = "Añadir registro";
            this.btnAddRow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddRow.UseVisualStyleBackColor = false;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteRow.BackColor = System.Drawing.Color.White;
            this.btnDeleteRow.Image = global::FrontEnd.Properties.Resources.Delete_Row_40;
            this.btnDeleteRow.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteRow.Location = new System.Drawing.Point(814, 57);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(150, 50);
            this.btnDeleteRow.TabIndex = 24;
            this.btnDeleteRow.Text = "Eliminar registro";
            this.btnDeleteRow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteRow.UseVisualStyleBackColor = false;
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // btnGrabarRegistros
            // 
            this.btnGrabarRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrabarRegistros.BackColor = System.Drawing.Color.White;
            this.btnGrabarRegistros.Image = global::FrontEnd.Properties.Resources.Save_40;
            this.btnGrabarRegistros.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabarRegistros.Location = new System.Drawing.Point(987, 36);
            this.btnGrabarRegistros.Name = "btnGrabarRegistros";
            this.btnGrabarRegistros.Size = new System.Drawing.Size(113, 72);
            this.btnGrabarRegistros.TabIndex = 25;
            this.btnGrabarRegistros.Text = "Grabar Resgitros";
            this.btnGrabarRegistros.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGrabarRegistros.UseVisualStyleBackColor = false;
            this.btnGrabarRegistros.Click += new System.EventHandler(this.btnGrabarRegistros_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtTotalHorasExtras);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ddlMes);
            this.panel1.Controls.Add(this.btnDeleteRow);
            this.panel1.Controls.Add(this.btnCargar);
            this.panel1.Controls.Add(this.btnAddRow);
            this.panel1.Location = new System.Drawing.Point(15, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(971, 116);
            this.panel1.TabIndex = 26;
            // 
            // txtTotalHorasExtras
            // 
            this.txtTotalHorasExtras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalHorasExtras.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalHorasExtras.Location = new System.Drawing.Point(702, 12);
            this.txtTotalHorasExtras.Name = "txtTotalHorasExtras";
            this.txtTotalHorasExtras.ReadOnly = true;
            this.txtTotalHorasExtras.Size = new System.Drawing.Size(100, 26);
            this.txtTotalHorasExtras.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(581, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 14);
            this.label2.TabIndex = 25;
            this.label2.Text = "Total de Horas Extras:";
            // 
            // FrmHorasExtrasIndividual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1112, 416);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGrabarRegistros);
            this.Controls.Add(this.txtDatos);
            this.Controls.Add(this.dgvHorasExtras);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.Name = "FrmHorasExtrasIndividual";
            this.Text = "Validación de Horas Extras";
            this.Load += new System.EventHandler(this.FrmHorasExtrasIndividual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorasExtras)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHorasExtras;
        private System.Windows.Forms.ComboBox ddlMes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.TextBox txtDatos;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Button btnDeleteRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSePuedeEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgIdRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgMes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFechaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTiempo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgEsExtra;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgHorasAprobadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgJustificacion;
        private System.Windows.Forms.Button btnGrabarRegistros;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTotalHorasExtras;
        private System.Windows.Forms.Label label2;
    }
}