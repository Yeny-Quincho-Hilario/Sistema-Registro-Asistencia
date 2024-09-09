namespace RegistroAsistencia
{
    partial class Consulta
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
            this.dgvConsulta = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCurso = new System.Windows.Forms.TextBox();
            this.rbtCurso = new System.Windows.Forms.RadioButton();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.rbtEstado = new System.Windows.Forms.RadioButton();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtEstudiante = new System.Windows.Forms.TextBox();
            this.rbtEstudiante = new System.Windows.Forms.RadioButton();
            this.rbtFecha = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvConsulta
            // 
            this.dgvConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsulta.Location = new System.Drawing.Point(0, 212);
            this.dgvConsulta.Name = "dgvConsulta";
            this.dgvConsulta.Size = new System.Drawing.Size(612, 281);
            this.dgvConsulta.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCurso);
            this.groupBox1.Controls.Add(this.rbtCurso);
            this.groupBox1.Controls.Add(this.txtEstado);
            this.groupBox1.Controls.Add(this.rbtEstado);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.txtEstudiante);
            this.groupBox1.Controls.Add(this.rbtEstudiante);
            this.groupBox1.Controls.Add(this.rbtFecha);
            this.groupBox1.Location = new System.Drawing.Point(21, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(591, 130);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar Asistencia";
            // 
            // txtCurso
            // 
            this.txtCurso.Location = new System.Drawing.Point(373, 73);
            this.txtCurso.Name = "txtCurso";
            this.txtCurso.Size = new System.Drawing.Size(198, 20);
            this.txtCurso.TabIndex = 8;
            this.txtCurso.TextChanged += new System.EventHandler(this.txtCurso_TextChanged);
            // 
            // rbtCurso
            // 
            this.rbtCurso.AutoSize = true;
            this.rbtCurso.Location = new System.Drawing.Point(309, 77);
            this.rbtCurso.Name = "rbtCurso";
            this.rbtCurso.Size = new System.Drawing.Size(52, 17);
            this.rbtCurso.TabIndex = 6;
            this.rbtCurso.Text = "Curso";
            this.rbtCurso.UseVisualStyleBackColor = true;
            this.rbtCurso.CheckedChanged += new System.EventHandler(this.rbtCurso_CheckedChanged);
            // 
            // txtEstado
            // 
            this.txtEstado.Enabled = false;
            this.txtEstado.Location = new System.Drawing.Point(373, 34);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(198, 20);
            this.txtEstado.TabIndex = 7;
            this.txtEstado.TextChanged += new System.EventHandler(this.txtEstado_TextChanged);
            // 
            // rbtEstado
            // 
            this.rbtEstado.AutoSize = true;
            this.rbtEstado.Location = new System.Drawing.Point(309, 37);
            this.rbtEstado.Name = "rbtEstado";
            this.rbtEstado.Size = new System.Drawing.Size(58, 17);
            this.rbtEstado.TabIndex = 6;
            this.rbtEstado.Text = "Estado";
            this.rbtEstado.UseVisualStyleBackColor = true;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(85, 34);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 5;
            this.dtpFecha.Value = new System.DateTime(2023, 12, 20, 0, 0, 0, 0);
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // txtEstudiante
            // 
            this.txtEstudiante.Enabled = false;
            this.txtEstudiante.Location = new System.Drawing.Point(85, 74);
            this.txtEstudiante.Name = "txtEstudiante";
            this.txtEstudiante.Size = new System.Drawing.Size(200, 20);
            this.txtEstudiante.TabIndex = 4;
            this.txtEstudiante.TextChanged += new System.EventHandler(this.txtEstudiante_TextChanged);
            // 
            // rbtEstudiante
            // 
            this.rbtEstudiante.AutoSize = true;
            this.rbtEstudiante.Location = new System.Drawing.Point(4, 74);
            this.rbtEstudiante.Name = "rbtEstudiante";
            this.rbtEstudiante.Size = new System.Drawing.Size(75, 17);
            this.rbtEstudiante.TabIndex = 2;
            this.rbtEstudiante.Text = "Estudiante";
            this.rbtEstudiante.UseVisualStyleBackColor = true;
            this.rbtEstudiante.CheckedChanged += new System.EventHandler(this.rbtEstudiante_CheckedChanged);
            // 
            // rbtFecha
            // 
            this.rbtFecha.AutoSize = true;
            this.rbtFecha.Checked = true;
            this.rbtFecha.Location = new System.Drawing.Point(4, 34);
            this.rbtFecha.Name = "rbtFecha";
            this.rbtFecha.Size = new System.Drawing.Size(55, 17);
            this.rbtFecha.TabIndex = 3;
            this.rbtFecha.TabStop = true;
            this.rbtFecha.Text = "Fecha";
            this.rbtFecha.UseVisualStyleBackColor = true;
            this.rbtFecha.CheckedChanged += new System.EventHandler(this.rbtFecha_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.DarkGray;
            this.label5.Font = new System.Drawing.Font("Bernard MT Condensed", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(194, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(222, 34);
            this.label5.TabIndex = 19;
            this.label5.Text = "CONSULTA GENERAL";
            // 
            // Consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(619, 505);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvConsulta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Consulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta";
            this.Load += new System.EventHandler(this.Consulta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConsulta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.RadioButton rbtEstado;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtEstudiante;
        private System.Windows.Forms.RadioButton rbtEstudiante;
        private System.Windows.Forms.RadioButton rbtFecha;
        private System.Windows.Forms.RadioButton rbtCurso;
        private System.Windows.Forms.TextBox txtCurso;
        private System.Windows.Forms.Label label5;
    }
}