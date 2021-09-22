namespace FrontEnd
{
    partial class FrmBaseConocimiento
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.CmbCategorias = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LBItems = new System.Windows.Forms.ListBox();
            this.rtxtContenido = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtFechaIngreso = new System.Windows.Forms.TextBox();
            this.TxtResponsable = new System.Windows.Forms.TextBox();
            this.TxtObservaciones = new System.Windows.Forms.TextBox();
            this.LBLNombreCab = new System.Windows.Forms.Label();
            this.TxtDetalle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFechaActualizacion = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.txtFechaActualizacion);
            this.splitContainer1.Panel2.Controls.Add(this.rtxtContenido);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.TxtFechaIngreso);
            this.splitContainer1.Panel2.Controls.Add(this.TxtResponsable);
            this.splitContainer1.Panel2.Controls.Add(this.TxtObservaciones);
            this.splitContainer1.Panel2.Controls.Add(this.LBLNombreCab);
            this.splitContainer1.Panel2.Controls.Add(this.TxtDetalle);
            this.splitContainer1.Size = new System.Drawing.Size(840, 504);
            this.splitContainer1.SplitterDistance = 290;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel1.Controls.Add(this.CmbCategorias);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.LBItems);
            this.splitContainer2.Size = new System.Drawing.Size(290, 504);
            this.splitContainer2.SplitterDistance = 59;
            this.splitContainer2.TabIndex = 0;
            // 
            // CmbCategorias
            // 
            this.CmbCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCategorias.FormattingEnabled = true;
            this.CmbCategorias.Location = new System.Drawing.Point(9, 27);
            this.CmbCategorias.Name = "CmbCategorias";
            this.CmbCategorias.Size = new System.Drawing.Size(271, 22);
            this.CmbCategorias.TabIndex = 1;
            this.CmbCategorias.SelectedIndexChanged += new System.EventHandler(this.CmbCategorias_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Categoría";
            // 
            // LBItems
            // 
            this.LBItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBItems.FormattingEnabled = true;
            this.LBItems.ItemHeight = 14;
            this.LBItems.Location = new System.Drawing.Point(0, 0);
            this.LBItems.Name = "LBItems";
            this.LBItems.Size = new System.Drawing.Size(290, 441);
            this.LBItems.TabIndex = 0;
            this.LBItems.SelectedIndexChanged += new System.EventHandler(this.LBItems_SelectedIndexChanged);
            // 
            // rtxtContenido
            // 
            this.rtxtContenido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtContenido.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtContenido.Location = new System.Drawing.Point(11, 95);
            this.rtxtContenido.Name = "rtxtContenido";
            this.rtxtContenido.Size = new System.Drawing.Size(523, 274);
            this.rtxtContenido.TabIndex = 8;
            this.rtxtContenido.Text = "";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(311, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha Ingreso:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(311, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ingresado por:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 384);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Observaciones";
            // 
            // TxtFechaIngreso
            // 
            this.TxtFechaIngreso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtFechaIngreso.Location = new System.Drawing.Point(399, 41);
            this.TxtFechaIngreso.Name = "TxtFechaIngreso";
            this.TxtFechaIngreso.ReadOnly = true;
            this.TxtFechaIngreso.Size = new System.Drawing.Size(134, 22);
            this.TxtFechaIngreso.TabIndex = 4;
            // 
            // TxtResponsable
            // 
            this.TxtResponsable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtResponsable.Location = new System.Drawing.Point(400, 15);
            this.TxtResponsable.Name = "TxtResponsable";
            this.TxtResponsable.ReadOnly = true;
            this.TxtResponsable.Size = new System.Drawing.Size(134, 22);
            this.TxtResponsable.TabIndex = 3;
            // 
            // TxtObservaciones
            // 
            this.TxtObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtObservaciones.BackColor = System.Drawing.Color.White;
            this.TxtObservaciones.Location = new System.Drawing.Point(11, 402);
            this.TxtObservaciones.Multiline = true;
            this.TxtObservaciones.Name = "TxtObservaciones";
            this.TxtObservaciones.ReadOnly = true;
            this.TxtObservaciones.Size = new System.Drawing.Size(521, 85);
            this.TxtObservaciones.TabIndex = 2;
            // 
            // LBLNombreCab
            // 
            this.LBLNombreCab.AutoSize = true;
            this.LBLNombreCab.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLNombreCab.Location = new System.Drawing.Point(7, 10);
            this.LBLNombreCab.Name = "LBLNombreCab";
            this.LBLNombreCab.Size = new System.Drawing.Size(164, 23);
            this.LBLNombreCab.TabIndex = 0;
            this.LBLNombreCab.Text = "[Nombre Cabecera]";
            // 
            // TxtDetalle
            // 
            this.TxtDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtDetalle.BackColor = System.Drawing.Color.White;
            this.TxtDetalle.Location = new System.Drawing.Point(464, 364);
            this.TxtDetalle.Multiline = true;
            this.TxtDetalle.Name = "TxtDetalle";
            this.TxtDetalle.ReadOnly = true;
            this.TxtDetalle.Size = new System.Drawing.Size(68, 34);
            this.TxtDetalle.TabIndex = 1;
            this.TxtDetalle.Visible = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(279, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "Fecha Actualización:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtFechaActualizacion
            // 
            this.txtFechaActualizacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFechaActualizacion.Location = new System.Drawing.Point(399, 67);
            this.txtFechaActualizacion.Name = "txtFechaActualizacion";
            this.txtFechaActualizacion.ReadOnly = true;
            this.txtFechaActualizacion.Size = new System.Drawing.Size(134, 22);
            this.txtFechaActualizacion.TabIndex = 9;
            this.txtFechaActualizacion.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // FrmBaseConocimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(840, 504);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeBox = false;
            this.Name = "FrmBaseConocimiento";
            this.Text = "Base de Conocimiento - Consulta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBaseConocimiento_FormClosing);
            this.Load += new System.EventHandler(this.FrmBaseConocimiento_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ComboBox CmbCategorias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox LBItems;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtFechaIngreso;
        private System.Windows.Forms.TextBox TxtResponsable;
        private System.Windows.Forms.TextBox TxtObservaciones;
        private System.Windows.Forms.TextBox TxtDetalle;
        private System.Windows.Forms.Label LBLNombreCab;
        private System.Windows.Forms.RichTextBox rtxtContenido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFechaActualizacion;
    }
}