namespace FrontEnd
{
    partial class FrmListas_CA
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
            this.tabCtrlListas = new System.Windows.Forms.TabControl();
            this.tabCtrlAnadirLista = new System.Windows.Forms.TabPage();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnQuitarFila = new System.Windows.Forms.Button();
            this.btnAnadirFila = new System.Windows.Forms.Button();
            this.dgvListas = new System.Windows.Forms.DataGridView();
            this.dgValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreLista = new System.Windows.Forms.TextBox();
            this.tabCtrlEditarLista = new System.Windows.Forms.TabPage();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.btnEditDelete = new System.Windows.Forms.Button();
            this.btnEditAdd = new System.Windows.Forms.Button();
            this.dgvValoresEdicion = new System.Windows.Forms.DataGridView();
            this.dgIdListaEdit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgNombreListaEdit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgValorEdit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ddlListas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabCtrlListas.SuspendLayout();
            this.tabCtrlAnadirLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListas)).BeginInit();
            this.tabCtrlEditarLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValoresEdicion)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCtrlListas
            // 
            this.tabCtrlListas.Controls.Add(this.tabCtrlAnadirLista);
            this.tabCtrlListas.Controls.Add(this.tabCtrlEditarLista);
            this.tabCtrlListas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrlListas.Location = new System.Drawing.Point(0, 0);
            this.tabCtrlListas.Name = "tabCtrlListas";
            this.tabCtrlListas.SelectedIndex = 0;
            this.tabCtrlListas.Size = new System.Drawing.Size(654, 503);
            this.tabCtrlListas.TabIndex = 0;
            this.tabCtrlListas.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabCtrlListas_Selected);
            this.tabCtrlListas.TabIndexChanged += new System.EventHandler(this.tabCtrlListas_TabIndexChanged);
            // 
            // tabCtrlAnadirLista
            // 
            this.tabCtrlAnadirLista.Controls.Add(this.btnNuevo);
            this.tabCtrlAnadirLista.Controls.Add(this.btnGrabar);
            this.tabCtrlAnadirLista.Controls.Add(this.btnQuitarFila);
            this.tabCtrlAnadirLista.Controls.Add(this.btnAnadirFila);
            this.tabCtrlAnadirLista.Controls.Add(this.dgvListas);
            this.tabCtrlAnadirLista.Controls.Add(this.label1);
            this.tabCtrlAnadirLista.Controls.Add(this.txtNombreLista);
            this.tabCtrlAnadirLista.Location = new System.Drawing.Point(4, 23);
            this.tabCtrlAnadirLista.Name = "tabCtrlAnadirLista";
            this.tabCtrlAnadirLista.Padding = new System.Windows.Forms.Padding(3);
            this.tabCtrlAnadirLista.Size = new System.Drawing.Size(646, 476);
            this.tabCtrlAnadirLista.TabIndex = 0;
            this.tabCtrlAnadirLista.Text = "Añadir Lista";
            this.tabCtrlAnadirLista.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.White;
            this.btnNuevo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Image = global::FrontEnd.Properties.Resources.Add_Row_40;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.Location = new System.Drawing.Point(210, 417);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(110, 50);
            this.btnNuevo.TabIndex = 157;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.Color.White;
            this.btnGrabar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Image = global::FrontEnd.Properties.Resources.Save_40;
            this.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrabar.Location = new System.Drawing.Point(326, 417);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(110, 50);
            this.btnGrabar.TabIndex = 156;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnQuitarFila
            // 
            this.btnQuitarFila.BackColor = System.Drawing.Color.White;
            this.btnQuitarFila.Image = global::FrontEnd.Properties.Resources.Delete_Row_40;
            this.btnQuitarFila.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuitarFila.Location = new System.Drawing.Point(146, 53);
            this.btnQuitarFila.Name = "btnQuitarFila";
            this.btnQuitarFila.Size = new System.Drawing.Size(110, 50);
            this.btnQuitarFila.TabIndex = 4;
            this.btnQuitarFila.Text = "Quitar fila";
            this.btnQuitarFila.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitarFila.UseVisualStyleBackColor = false;
            this.btnQuitarFila.Click += new System.EventHandler(this.btnQuitarFila_Click);
            // 
            // btnAnadirFila
            // 
            this.btnAnadirFila.BackColor = System.Drawing.Color.White;
            this.btnAnadirFila.Image = global::FrontEnd.Properties.Resources.Add_Row_40;
            this.btnAnadirFila.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAnadirFila.Location = new System.Drawing.Point(22, 53);
            this.btnAnadirFila.Name = "btnAnadirFila";
            this.btnAnadirFila.Size = new System.Drawing.Size(110, 50);
            this.btnAnadirFila.TabIndex = 3;
            this.btnAnadirFila.Text = "Añadir fila";
            this.btnAnadirFila.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnadirFila.UseVisualStyleBackColor = false;
            this.btnAnadirFila.Click += new System.EventHandler(this.btnAnadirFila_Click);
            // 
            // dgvListas
            // 
            this.dgvListas.AllowUserToAddRows = false;
            this.dgvListas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dgvListas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgValor});
            this.dgvListas.Location = new System.Drawing.Point(23, 111);
            this.dgvListas.Name = "dgvListas";
            this.dgvListas.RowHeadersVisible = false;
            this.dgvListas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListas.Size = new System.Drawing.Size(600, 300);
            this.dgvListas.TabIndex = 2;
            // 
            // dgValor
            // 
            this.dgValor.Frozen = true;
            this.dgValor.HeaderText = "Valor";
            this.dgValor.Name = "dgValor";
            this.dgValor.Width = 500;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre de la Lista";
            // 
            // txtNombreLista
            // 
            this.txtNombreLista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreLista.Location = new System.Drawing.Point(135, 19);
            this.txtNombreLista.Name = "txtNombreLista";
            this.txtNombreLista.Size = new System.Drawing.Size(268, 22);
            this.txtNombreLista.TabIndex = 0;
            // 
            // tabCtrlEditarLista
            // 
            this.tabCtrlEditarLista.Controls.Add(this.btnGuardarCambios);
            this.tabCtrlEditarLista.Controls.Add(this.btnEditDelete);
            this.tabCtrlEditarLista.Controls.Add(this.btnEditAdd);
            this.tabCtrlEditarLista.Controls.Add(this.dgvValoresEdicion);
            this.tabCtrlEditarLista.Controls.Add(this.ddlListas);
            this.tabCtrlEditarLista.Controls.Add(this.label2);
            this.tabCtrlEditarLista.Location = new System.Drawing.Point(4, 23);
            this.tabCtrlEditarLista.Name = "tabCtrlEditarLista";
            this.tabCtrlEditarLista.Padding = new System.Windows.Forms.Padding(3);
            this.tabCtrlEditarLista.Size = new System.Drawing.Size(646, 476);
            this.tabCtrlEditarLista.TabIndex = 1;
            this.tabCtrlEditarLista.Text = "Editar / Eliminar Lista";
            this.tabCtrlEditarLista.UseVisualStyleBackColor = true;
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.BackColor = System.Drawing.Color.White;
            this.btnGuardarCambios.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCambios.Image = global::FrontEnd.Properties.Resources.Save_40;
            this.btnGuardarCambios.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarCambios.Location = new System.Drawing.Point(248, 418);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(150, 50);
            this.btnGuardarCambios.TabIndex = 157;
            this.btnGuardarCambios.Text = "Guardar cambios";
            this.btnGuardarCambios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarCambios.UseVisualStyleBackColor = false;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);
            // 
            // btnEditDelete
            // 
            this.btnEditDelete.BackColor = System.Drawing.Color.White;
            this.btnEditDelete.Image = global::FrontEnd.Properties.Resources.Delete_Row_40;
            this.btnEditDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditDelete.Location = new System.Drawing.Point(139, 47);
            this.btnEditDelete.Name = "btnEditDelete";
            this.btnEditDelete.Size = new System.Drawing.Size(110, 50);
            this.btnEditDelete.TabIndex = 6;
            this.btnEditDelete.Text = "Quitar fila";
            this.btnEditDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditDelete.UseVisualStyleBackColor = false;
            this.btnEditDelete.Click += new System.EventHandler(this.btnEditDelete_Click);
            // 
            // btnEditAdd
            // 
            this.btnEditAdd.BackColor = System.Drawing.Color.White;
            this.btnEditAdd.Image = global::FrontEnd.Properties.Resources.Add_Row_40;
            this.btnEditAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditAdd.Location = new System.Drawing.Point(23, 47);
            this.btnEditAdd.Name = "btnEditAdd";
            this.btnEditAdd.Size = new System.Drawing.Size(110, 50);
            this.btnEditAdd.TabIndex = 5;
            this.btnEditAdd.Text = "Añadir fila";
            this.btnEditAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditAdd.UseVisualStyleBackColor = false;
            this.btnEditAdd.Click += new System.EventHandler(this.btnEditAdd_Click);
            // 
            // dgvValoresEdicion
            // 
            this.dgvValoresEdicion.AllowUserToAddRows = false;
            this.dgvValoresEdicion.AllowUserToDeleteRows = false;
            this.dgvValoresEdicion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvValoresEdicion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgIdListaEdit,
            this.dgNombreListaEdit,
            this.dgValorEdit});
            this.dgvValoresEdicion.Location = new System.Drawing.Point(23, 114);
            this.dgvValoresEdicion.Name = "dgvValoresEdicion";
            this.dgvValoresEdicion.RowHeadersVisible = false;
            this.dgvValoresEdicion.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvValoresEdicion.Size = new System.Drawing.Size(600, 300);
            this.dgvValoresEdicion.TabIndex = 4;
            // 
            // dgIdListaEdit
            // 
            this.dgIdListaEdit.Frozen = true;
            this.dgIdListaEdit.HeaderText = "IdLista";
            this.dgIdListaEdit.Name = "dgIdListaEdit";
            this.dgIdListaEdit.ReadOnly = true;
            this.dgIdListaEdit.Visible = false;
            // 
            // dgNombreListaEdit
            // 
            this.dgNombreListaEdit.Frozen = true;
            this.dgNombreListaEdit.HeaderText = "NombreLista";
            this.dgNombreListaEdit.Name = "dgNombreListaEdit";
            this.dgNombreListaEdit.ReadOnly = true;
            this.dgNombreListaEdit.Visible = false;
            // 
            // dgValorEdit
            // 
            this.dgValorEdit.Frozen = true;
            this.dgValorEdit.HeaderText = "Valor";
            this.dgValorEdit.Name = "dgValorEdit";
            this.dgValorEdit.Width = 500;
            // 
            // ddlListas
            // 
            this.ddlListas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlListas.FormattingEnabled = true;
            this.ddlListas.Location = new System.Drawing.Point(132, 19);
            this.ddlListas.Name = "ddlListas";
            this.ddlListas.Size = new System.Drawing.Size(340, 22);
            this.ddlListas.TabIndex = 3;
            this.ddlListas.SelectedIndexChanged += new System.EventHandler(this.ddlListas_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre de la Lista";
            // 
            // FrmListas_CA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(654, 503);
            this.Controls.Add(this.tabCtrlListas);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeBox = false;
            this.Name = "FrmListas_CA";
            this.Text = "Certificación de Aplicaciones - Listas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmListas_CA_FormClosing);
            this.Load += new System.EventHandler(this.FrmListas_CA_Load);
            this.tabCtrlListas.ResumeLayout(false);
            this.tabCtrlAnadirLista.ResumeLayout(false);
            this.tabCtrlAnadirLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListas)).EndInit();
            this.tabCtrlEditarLista.ResumeLayout(false);
            this.tabCtrlEditarLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValoresEdicion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtrlListas;
        private System.Windows.Forms.TabPage tabCtrlAnadirLista;
        private System.Windows.Forms.TabPage tabCtrlEditarLista;
        private System.Windows.Forms.Button btnQuitarFila;
        private System.Windows.Forms.Button btnAnadirFila;
        private System.Windows.Forms.DataGridView dgvListas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgValor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreLista;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.ComboBox ddlListas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvValoresEdicion;
        private System.Windows.Forms.Button btnEditDelete;
        private System.Windows.Forms.Button btnEditAdd;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgIdListaEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgNombreListaEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgValorEdit;
    }
}