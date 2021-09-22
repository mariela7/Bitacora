namespace FrontEnd
{
    partial class FrmBitacora_CA
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.txtTotalHoras = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnQuitarRegistro = new System.Windows.Forms.Button();
            this.btnAgregarRegistro = new System.Windows.Forms.Button();
            this.lblBitacora = new System.Windows.Forms.Label();
            this.dgvBitacora = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.btnCopiar);
            this.splitContainer1.Panel1.Controls.Add(this.txtTotalHoras);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnGrabar);
            this.splitContainer1.Panel1.Controls.Add(this.btnQuitarRegistro);
            this.splitContainer1.Panel1.Controls.Add(this.btnAgregarRegistro);
            this.splitContainer1.Panel1.Controls.Add(this.lblBitacora);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvBitacora);
            this.splitContainer1.Size = new System.Drawing.Size(711, 456);
            this.splitContainer1.SplitterDistance = 95;
            this.splitContainer1.TabIndex = 4;
            // 
            // btnCopiar
            // 
            this.btnCopiar.BackColor = System.Drawing.Color.White;
            this.btnCopiar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopiar.Image = global::FrontEnd.Properties.Resources.Copy_40;
            this.btnCopiar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopiar.Location = new System.Drawing.Point(315, 41);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(148, 50);
            this.btnCopiar.TabIndex = 8;
            this.btnCopiar.Text = "Duplicar Registro";
            this.btnCopiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopiar.UseVisualStyleBackColor = false;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // txtTotalHoras
            // 
            this.txtTotalHoras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalHoras.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalHoras.Location = new System.Drawing.Point(608, 5);
            this.txtTotalHoras.Name = "txtTotalHoras";
            this.txtTotalHoras.Size = new System.Drawing.Size(100, 33);
            this.txtTotalHoras.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(514, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Total Horas:";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrabar.BackColor = System.Drawing.Color.White;
            this.btnGrabar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Image = global::FrontEnd.Properties.Resources.Save_40;
            this.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrabar.Location = new System.Drawing.Point(521, 41);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(187, 50);
            this.btnGrabar.TabIndex = 3;
            this.btnGrabar.Text = "Grabar registros";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnQuitarRegistro
            // 
            this.btnQuitarRegistro.BackColor = System.Drawing.Color.White;
            this.btnQuitarRegistro.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarRegistro.Image = global::FrontEnd.Properties.Resources.Delete_Row_40;
            this.btnQuitarRegistro.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuitarRegistro.Location = new System.Drawing.Point(159, 41);
            this.btnQuitarRegistro.Name = "btnQuitarRegistro";
            this.btnQuitarRegistro.Size = new System.Drawing.Size(148, 50);
            this.btnQuitarRegistro.TabIndex = 2;
            this.btnQuitarRegistro.Text = "Eliminar Registro";
            this.btnQuitarRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitarRegistro.UseVisualStyleBackColor = false;
            this.btnQuitarRegistro.Click += new System.EventHandler(this.btnQuitarRegistro_Click);
            // 
            // btnAgregarRegistro
            // 
            this.btnAgregarRegistro.BackColor = System.Drawing.Color.White;
            this.btnAgregarRegistro.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarRegistro.Image = global::FrontEnd.Properties.Resources.Add_Row_40;
            this.btnAgregarRegistro.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarRegistro.Location = new System.Drawing.Point(3, 41);
            this.btnAgregarRegistro.Name = "btnAgregarRegistro";
            this.btnAgregarRegistro.Size = new System.Drawing.Size(148, 50);
            this.btnAgregarRegistro.TabIndex = 1;
            this.btnAgregarRegistro.Text = "Agregar Registro";
            this.btnAgregarRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarRegistro.UseVisualStyleBackColor = false;
            this.btnAgregarRegistro.Click += new System.EventHandler(this.btnAgregarRegistro_Click);
            // 
            // lblBitacora
            // 
            this.lblBitacora.AutoSize = true;
            this.lblBitacora.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBitacora.Location = new System.Drawing.Point(3, 8);
            this.lblBitacora.Name = "lblBitacora";
            this.lblBitacora.Size = new System.Drawing.Size(159, 26);
            this.lblBitacora.TabIndex = 0;
            this.lblBitacora.Text = "Nombre Bitácora";
            // 
            // dgvBitacora
            // 
            this.dgvBitacora.AllowUserToAddRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Lavender;
            this.dgvBitacora.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBitacora.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBitacora.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBitacora.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBitacora.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBitacora.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvBitacora.Location = new System.Drawing.Point(0, 0);
            this.dgvBitacora.Name = "dgvBitacora";
            this.dgvBitacora.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBitacora.Size = new System.Drawing.Size(711, 357);
            this.dgvBitacora.TabIndex = 3;
            this.dgvBitacora.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBitacora_CellClick);
            this.dgvBitacora.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBitacora_CellEndEdit);
            this.dgvBitacora.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvBitacora_CellValidating);
            this.dgvBitacora.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvBitacora_DataError);
            // 
            // FrmBitacora_CA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 456);
            this.Controls.Add(this.splitContainer1);
            this.MinimizeBox = false;
            this.Name = "FrmBitacora_CA";
            this.Text = "Bitácora - Certificación de Aplicaciones";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBitacora_CA_FormClosing);
            this.Load += new System.EventHandler(this.FrmBitacora_CA_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvBitacora;
        private System.Windows.Forms.Label lblBitacora;
        private System.Windows.Forms.Button btnAgregarRegistro;
        private System.Windows.Forms.Button btnQuitarRegistro;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.TextBox txtTotalHoras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCopiar;

    }
}