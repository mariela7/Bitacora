namespace FrontEnd
{
    partial class FrmBitacora_IS
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
            this.components = new System.ComponentModel.Container();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlServicio = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTarea = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEvidencia = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEsfuerzo = new System.Windows.Forms.TextBox();
            this.mtcFecha = new System.Windows.Forms.MonthCalendar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ddlEmpresa = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnRuta = new System.Windows.Forms.Button();
            this.chkHoraExtra = new System.Windows.Forms.CheckBox();
            this.errorProviderTarea = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderEvidencia = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderEsfuerzo = new System.Windows.Forms.ErrorProvider(this.components);
            this.ddlCategoria = new System.Windows.Forms.ComboBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderTarea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEvidencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEsfuerzo)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 14);
            this.label3.TabIndex = 10;
            this.label3.Text = "Servicio:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 26);
            this.label1.TabIndex = 9;
            this.label1.Text = "Bitacora";
            // 
            // ddlServicio
            // 
            this.ddlServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlServicio.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlServicio.FormattingEnabled = true;
            this.ddlServicio.Location = new System.Drawing.Point(96, 87);
            this.ddlServicio.Name = "ddlServicio";
            this.ddlServicio.Size = new System.Drawing.Size(321, 22);
            this.ddlServicio.TabIndex = 2;
            this.ddlServicio.SelectedIndexChanged += new System.EventHandler(this.ddlServicio_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(467, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "Fecha:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tarea:";
            // 
            // txtTarea
            // 
            this.txtTarea.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTarea.Location = new System.Drawing.Point(96, 171);
            this.txtTarea.Multiline = true;
            this.txtTarea.Name = "txtTarea";
            this.txtTarea.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTarea.Size = new System.Drawing.Size(321, 69);
            this.txtTarea.TabIndex = 4;
            this.txtTarea.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTarea_KeyPress);
            this.txtTarea.Leave += new System.EventHandler(this.txtTarea_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(28, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "Evidencia:";
            // 
            // txtEvidencia
            // 
            this.txtEvidencia.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEvidencia.Location = new System.Drawing.Point(96, 246);
            this.txtEvidencia.Multiline = true;
            this.txtEvidencia.Name = "txtEvidencia";
            this.txtEvidencia.Size = new System.Drawing.Size(321, 75);
            this.txtEvidencia.TabIndex = 6;
            this.txtEvidencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEvidencia_KeyPress);
            this.txtEvidencia.Leave += new System.EventHandler(this.txtEvidencia_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(467, 280);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 14);
            this.label8.TabIndex = 10;
            this.label8.Text = "Esfuerzo:";
            // 
            // txtEsfuerzo
            // 
            this.txtEsfuerzo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEsfuerzo.Location = new System.Drawing.Point(588, 280);
            this.txtEsfuerzo.Name = "txtEsfuerzo";
            this.txtEsfuerzo.Size = new System.Drawing.Size(53, 23);
            this.txtEsfuerzo.TabIndex = 8;
            this.txtEsfuerzo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEsfuerzo_KeyPress);
            this.txtEsfuerzo.Leave += new System.EventHandler(this.txtEsfuerzo_Leave);
            // 
            // mtcFecha
            // 
            this.mtcFecha.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtcFecha.Location = new System.Drawing.Point(588, 108);
            this.mtcFecha.MaxSelectionCount = 31;
            this.mtcFecha.Name = "mtcFecha";
            this.mtcFecha.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ddlEmpresa
            // 
            this.ddlEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlEmpresa.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlEmpresa.FormattingEnabled = true;
            this.ddlEmpresa.Location = new System.Drawing.Point(96, 42);
            this.ddlEmpresa.Name = "ddlEmpresa";
            this.ddlEmpresa.Size = new System.Drawing.Size(321, 22);
            this.ddlEmpresa.TabIndex = 1;
            this.ddlEmpresa.SelectedIndexChanged += new System.EventHandler(this.ddlEmpresa_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(28, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 14);
            this.label9.TabIndex = 22;
            this.label9.Text = "Empresa:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.White;
            this.btnBuscar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = global::FrontEnd.Properties.Resources.Search_40;
            this.btnBuscar.Location = new System.Drawing.Point(774, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(60, 60);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnBuscar, "Buscar registro de bitácora");
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnRuta
            // 
            this.btnRuta.BackColor = System.Drawing.Color.White;
            this.btnRuta.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRuta.Image = global::FrontEnd.Properties.Resources.Open_Folder_40;
            this.btnRuta.Location = new System.Drawing.Point(35, 265);
            this.btnRuta.Name = "btnRuta";
            this.btnRuta.Size = new System.Drawing.Size(50, 50);
            this.btnRuta.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnRuta, "Abrir ubicación de la evidencia");
            this.btnRuta.UseVisualStyleBackColor = false;
            this.btnRuta.Click += new System.EventHandler(this.btnRuta_Click);
            // 
            // chkHoraExtra
            // 
            this.chkHoraExtra.AutoSize = true;
            this.chkHoraExtra.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkHoraExtra.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHoraExtra.Location = new System.Drawing.Point(467, 42);
            this.chkHoraExtra.Name = "chkHoraExtra";
            this.chkHoraExtra.Size = new System.Drawing.Size(132, 18);
            this.chkHoraExtra.TabIndex = 156;
            this.chkHoraExtra.Text = "¿Es una hora extra?";
            this.chkHoraExtra.UseVisualStyleBackColor = true;
            // 
            // errorProviderTarea
            // 
            this.errorProviderTarea.ContainerControl = this;
            // 
            // errorProviderEvidencia
            // 
            this.errorProviderEvidencia.ContainerControl = this;
            // 
            // errorProviderEsfuerzo
            // 
            this.errorProviderEsfuerzo.ContainerControl = this;
            // 
            // ddlCategoria
            // 
            this.ddlCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCategoria.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlCategoria.FormattingEnabled = true;
            this.ddlCategoria.Location = new System.Drawing.Point(96, 132);
            this.ddlCategoria.Name = "ddlCategoria";
            this.ddlCategoria.Size = new System.Drawing.Size(321, 22);
            this.ddlCategoria.TabIndex = 157;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.Location = new System.Drawing.Point(28, 136);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(61, 14);
            this.lblCategoria.TabIndex = 158;
            this.lblCategoria.Text = "Categoría:";
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.White;
            this.btnNuevo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Image = global::FrontEnd.Properties.Resources.Create_New_40;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.Location = new System.Drawing.Point(492, 337);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(110, 50);
            this.btnNuevo.TabIndex = 155;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.White;
            this.btnEliminar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Image = global::FrontEnd.Properties.Resources.Delete_40;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.Location = new System.Drawing.Point(724, 337);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(110, 50);
            this.btnEliminar.TabIndex = 11;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.Color.White;
            this.btnGrabar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Image = global::FrontEnd.Properties.Resources.Save_40;
            this.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrabar.Location = new System.Drawing.Point(608, 337);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(110, 50);
            this.btnGrabar.TabIndex = 9;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // FrmBitacora_IS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(846, 409);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.chkHoraExtra);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.ddlEmpresa);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnRuta);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.mtcFecha);
            this.Controls.Add(this.txtEsfuerzo);
            this.Controls.Add(this.txtEvidencia);
            this.Controls.Add(this.txtTarea);
            this.Controls.Add(this.ddlServicio);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlCategoria);
            this.MinimizeBox = false;
            this.Name = "FrmBitacora_IS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bitácora - Ingeniería de Seguridad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBitacora_IS_FormClosing);
            this.Load += new System.EventHandler(this.FrmBitacora_IS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderTarea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEvidencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEsfuerzo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlServicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTarea;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEvidencia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEsfuerzo;
        private System.Windows.Forms.MonthCalendar mtcFecha;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnRuta;
        private System.Windows.Forms.ComboBox ddlEmpresa;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.CheckBox chkHoraExtra;
        private System.Windows.Forms.ErrorProvider errorProviderTarea;
        private System.Windows.Forms.ErrorProvider errorProviderEvidencia;
        private System.Windows.Forms.ErrorProvider errorProviderEsfuerzo;
        private System.Windows.Forms.ComboBox ddlCategoria;
        private System.Windows.Forms.Label lblCategoria;
    }
}