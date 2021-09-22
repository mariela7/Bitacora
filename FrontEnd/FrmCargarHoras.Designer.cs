namespace FrontEnd
{
    partial class FrmCargarHoras
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
            this.lblNombreArchivo = new System.Windows.Forms.Label();
            this.btnSelectArchivo = new System.Windows.Forms.Button();
            this.dgvExcel = new System.Windows.Forms.DataGridView();
            this.btnSubir = new System.Windows.Forms.Button();
            this.btnGenerarHoras = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombreArchivo
            // 
            this.lblNombreArchivo.AutoSize = true;
            this.lblNombreArchivo.Location = new System.Drawing.Point(187, 26);
            this.lblNombreArchivo.Name = "lblNombreArchivo";
            this.lblNombreArchivo.Size = new System.Drawing.Size(98, 14);
            this.lblNombreArchivo.TabIndex = 1;
            this.lblNombreArchivo.Text = "Seleccionar Ruta";
            // 
            // btnSelectArchivo
            // 
            this.btnSelectArchivo.BackColor = System.Drawing.Color.White;
            this.btnSelectArchivo.Location = new System.Drawing.Point(12, 13);
            this.btnSelectArchivo.Name = "btnSelectArchivo";
            this.btnSelectArchivo.Size = new System.Drawing.Size(169, 40);
            this.btnSelectArchivo.TabIndex = 2;
            this.btnSelectArchivo.Text = "Seleccionar archivo";
            this.btnSelectArchivo.UseVisualStyleBackColor = false;
            this.btnSelectArchivo.Click += new System.EventHandler(this.btnSelectArchivo_Click);
            // 
            // dgvExcel
            // 
            this.dgvExcel.AllowUserToAddRows = false;
            this.dgvExcel.AllowUserToDeleteRows = false;
            this.dgvExcel.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dgvExcel.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExcel.Location = new System.Drawing.Point(12, 108);
            this.dgvExcel.Name = "dgvExcel";
            this.dgvExcel.ReadOnly = true;
            this.dgvExcel.RowHeadersVisible = false;
            this.dgvExcel.Size = new System.Drawing.Size(628, 358);
            this.dgvExcel.TabIndex = 3;
            // 
            // btnSubir
            // 
            this.btnSubir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubir.BackColor = System.Drawing.Color.White;
            this.btnSubir.Location = new System.Drawing.Point(509, 13);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.Size = new System.Drawing.Size(131, 40);
            this.btnSubir.TabIndex = 6;
            this.btnSubir.Text = "Subir";
            this.btnSubir.UseVisualStyleBackColor = false;
            this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
            // 
            // btnGenerarHoras
            // 
            this.btnGenerarHoras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerarHoras.BackColor = System.Drawing.Color.White;
            this.btnGenerarHoras.Location = new System.Drawing.Point(509, 59);
            this.btnGenerarHoras.Name = "btnGenerarHoras";
            this.btnGenerarHoras.Size = new System.Drawing.Size(131, 40);
            this.btnGenerarHoras.TabIndex = 7;
            this.btnGenerarHoras.Text = "Calcular Horas Extras";
            this.btnGenerarHoras.UseVisualStyleBackColor = false;
            this.btnGenerarHoras.Click += new System.EventHandler(this.btnGenerarHoras_Click);
            // 
            // FrmCargarHoras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(652, 478);
            this.Controls.Add(this.btnGenerarHoras);
            this.Controls.Add(this.btnSubir);
            this.Controls.Add(this.dgvExcel);
            this.Controls.Add(this.btnSelectArchivo);
            this.Controls.Add(this.lblNombreArchivo);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmCargarHoras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cargar Horas";
            this.Load += new System.EventHandler(this.FrmCargarHoras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombreArchivo;
        private System.Windows.Forms.Button btnSelectArchivo;
        private System.Windows.Forms.DataGridView dgvExcel;
        private System.Windows.Forms.Button btnSubir;
        private System.Windows.Forms.Button btnGenerarHoras;
    }
}