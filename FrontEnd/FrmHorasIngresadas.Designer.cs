namespace FrontEnd
{
    partial class FrmHorasIngresadas
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlAno = new System.Windows.Forms.ComboBox();
            this.ddlMes = new System.Windows.Forms.ComboBox();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnCargarDatos = new System.Windows.Forms.Button();
            this.dgvHorasIngresadas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorasIngresadas)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 14);
            this.label2.TabIndex = 29;
            this.label2.Text = "Año";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 14);
            this.label1.TabIndex = 28;
            this.label1.Text = "Mes";
            // 
            // ddlAno
            // 
            this.ddlAno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlAno.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlAno.FormattingEnabled = true;
            this.ddlAno.Location = new System.Drawing.Point(73, 12);
            this.ddlAno.Name = "ddlAno";
            this.ddlAno.Size = new System.Drawing.Size(85, 22);
            this.ddlAno.TabIndex = 27;
            // 
            // ddlMes
            // 
            this.ddlMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlMes.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlMes.FormattingEnabled = true;
            this.ddlMes.Location = new System.Drawing.Point(73, 51);
            this.ddlMes.Name = "ddlMes";
            this.ddlMes.Size = new System.Drawing.Size(277, 22);
            this.ddlMes.TabIndex = 26;
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackColor = System.Drawing.Color.White;
            this.btnExportar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.Image = global::FrontEnd.Properties.Resources.MS_Excel_40;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.Location = new System.Drawing.Point(796, 18);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(160, 54);
            this.btnExportar.TabIndex = 31;
            this.btnExportar.Text = "Exportar a Excel";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnCargarDatos
            // 
            this.btnCargarDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCargarDatos.BackColor = System.Drawing.Color.White;
            this.btnCargarDatos.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarDatos.Image = global::FrontEnd.Properties.Resources.Report_Card_40;
            this.btnCargarDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCargarDatos.Location = new System.Drawing.Point(630, 19);
            this.btnCargarDatos.Name = "btnCargarDatos";
            this.btnCargarDatos.Size = new System.Drawing.Size(160, 54);
            this.btnCargarDatos.TabIndex = 30;
            this.btnCargarDatos.Text = "Cargar datos";
            this.btnCargarDatos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCargarDatos.UseVisualStyleBackColor = false;
            this.btnCargarDatos.Click += new System.EventHandler(this.btnCargarDatos_Click);
            // 
            // dgvHorasIngresadas
            // 
            this.dgvHorasIngresadas.AllowUserToAddRows = false;
            this.dgvHorasIngresadas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dgvHorasIngresadas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHorasIngresadas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHorasIngresadas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHorasIngresadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHorasIngresadas.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHorasIngresadas.Location = new System.Drawing.Point(12, 90);
            this.dgvHorasIngresadas.MultiSelect = false;
            this.dgvHorasIngresadas.Name = "dgvHorasIngresadas";
            this.dgvHorasIngresadas.ReadOnly = true;
            this.dgvHorasIngresadas.RowHeadersVisible = false;
            this.dgvHorasIngresadas.Size = new System.Drawing.Size(944, 358);
            this.dgvHorasIngresadas.TabIndex = 32;
            // 
            // FrmHorasIngresadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(968, 460);
            this.Controls.Add(this.dgvHorasIngresadas);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnCargarDatos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlAno);
            this.Controls.Add(this.ddlMes);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmHorasIngresadas";
            this.Text = "Horas Ingresadas";
            this.Load += new System.EventHandler(this.FrmHorasIngresadas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorasIngresadas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlAno;
        private System.Windows.Forms.ComboBox ddlMes;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnCargarDatos;
        private System.Windows.Forms.DataGridView dgvHorasIngresadas;
    }
}