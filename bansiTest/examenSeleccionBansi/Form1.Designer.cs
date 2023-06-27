namespace examenSeleccionBansi
{
    partial class Form1
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
            this.txtBoxResultado = new System.Windows.Forms.TextBox();
            this.labelResultado = new System.Windows.Forms.Label();
            this.checkBoxWS = new System.Windows.Forms.CheckBox();
            this.txtBoxDescripcion = new System.Windows.Forms.TextBox();
            this.labelDescripcion = new System.Windows.Forms.Label();
            this.txtBoxNombre = new System.Windows.Forms.TextBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.txtBoxId = new System.Windows.Forms.TextBox();
            this.labelId = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtBoxResultado);
            this.splitContainer1.Panel1.Controls.Add(this.labelResultado);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxWS);
            this.splitContainer1.Panel1.Controls.Add(this.txtBoxDescripcion);
            this.splitContainer1.Panel1.Controls.Add(this.labelDescripcion);
            this.splitContainer1.Panel1.Controls.Add(this.txtBoxNombre);
            this.splitContainer1.Panel1.Controls.Add(this.labelNombre);
            this.splitContainer1.Panel1.Controls.Add(this.txtBoxId);
            this.splitContainer1.Panel1.Controls.Add(this.labelId);
            this.splitContainer1.Panel1.Controls.Add(this.btnConsultar);
            this.splitContainer1.Panel1.Controls.Add(this.btnActualizar);
            this.splitContainer1.Panel1.Controls.Add(this.btnEliminar);
            this.splitContainer1.Panel1.Controls.Add(this.btnAgregar);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 146;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtBoxResultado
            // 
            this.txtBoxResultado.Enabled = false;
            this.txtBoxResultado.Location = new System.Drawing.Point(564, 19);
            this.txtBoxResultado.Multiline = true;
            this.txtBoxResultado.Name = "txtBoxResultado";
            this.txtBoxResultado.Size = new System.Drawing.Size(224, 109);
            this.txtBoxResultado.TabIndex = 13;
            // 
            // labelResultado
            // 
            this.labelResultado.AutoSize = true;
            this.labelResultado.Location = new System.Drawing.Point(507, 22);
            this.labelResultado.Name = "labelResultado";
            this.labelResultado.Size = new System.Drawing.Size(61, 13);
            this.labelResultado.TabIndex = 12;
            this.labelResultado.Text = "Resultado: ";
            // 
            // checkBoxWS
            // 
            this.checkBoxWS.AutoSize = true;
            this.checkBoxWS.Location = new System.Drawing.Point(311, 104);
            this.checkBoxWS.Name = "checkBoxWS";
            this.checkBoxWS.Size = new System.Drawing.Size(75, 17);
            this.checkBoxWS.TabIndex = 11;
            this.checkBoxWS.Text = "Usar WS?";
            this.checkBoxWS.UseVisualStyleBackColor = true;
            // 
            // txtBoxDescripcion
            // 
            this.txtBoxDescripcion.Location = new System.Drawing.Point(98, 86);
            this.txtBoxDescripcion.MaxLength = 255;
            this.txtBoxDescripcion.Multiline = true;
            this.txtBoxDescripcion.Name = "txtBoxDescripcion";
            this.txtBoxDescripcion.Size = new System.Drawing.Size(159, 42);
            this.txtBoxDescripcion.TabIndex = 9;
            // 
            // labelDescripcion
            // 
            this.labelDescripcion.AutoSize = true;
            this.labelDescripcion.Location = new System.Drawing.Point(23, 89);
            this.labelDescripcion.Name = "labelDescripcion";
            this.labelDescripcion.Size = new System.Drawing.Size(63, 13);
            this.labelDescripcion.TabIndex = 8;
            this.labelDescripcion.Text = "Descripcion";
            // 
            // txtBoxNombre
            // 
            this.txtBoxNombre.Location = new System.Drawing.Point(98, 49);
            this.txtBoxNombre.MaxLength = 255;
            this.txtBoxNombre.Name = "txtBoxNombre";
            this.txtBoxNombre.Size = new System.Drawing.Size(159, 20);
            this.txtBoxNombre.TabIndex = 7;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(23, 49);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(44, 13);
            this.labelNombre.TabIndex = 6;
            this.labelNombre.Text = "Nombre";
            // 
            // txtBoxId
            // 
            this.txtBoxId.Location = new System.Drawing.Point(98, 15);
            this.txtBoxId.Name = "txtBoxId";
            this.txtBoxId.Size = new System.Drawing.Size(159, 20);
            this.txtBoxId.TabIndex = 5;
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(23, 18);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(16, 13);
            this.labelId.TabIndex = 4;
            this.labelId.Text = "Id";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(410, 66);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 3;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(311, 66);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(410, 20);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(311, 20);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 300);
            this.dataGridView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox txtBoxId;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox txtBoxDescripcion;
        private System.Windows.Forms.Label labelDescripcion;
        private System.Windows.Forms.TextBox txtBoxNombre;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.CheckBox checkBoxWS;
        private System.Windows.Forms.Label labelResultado;
        private System.Windows.Forms.TextBox txtBoxResultado;
    }
}

