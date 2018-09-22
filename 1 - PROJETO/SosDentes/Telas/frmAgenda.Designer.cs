namespace SosDentes.Telas
{
    partial class frmAgenda
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
            this.btnSair = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblEspe = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Column1Dia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1Pro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comumn1Esp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblProce = new System.Windows.Forms.Label();
            this.txtPesClien = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAgendar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.Color.Red;
            this.btnSair.Location = new System.Drawing.Point(794, 424);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 23);
            this.btnSair.TabIndex = 75;
            this.btnSair.Text = "SAIR";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(619, 23);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(250, 21);
            this.comboBox2.TabIndex = 73;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            this.comboBox2.Click += new System.EventHandler(this.comboBox2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "DENTISTA",
            "PROTÉTICO",
            "CLÍNICO GERAL"});
            this.comboBox1.Location = new System.Drawing.Point(14, 79);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(266, 21);
            this.comboBox1.TabIndex = 72;
            this.comboBox1.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // lblEspe
            // 
            this.lblEspe.AutoSize = true;
            this.lblEspe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEspe.Location = new System.Drawing.Point(11, 60);
            this.lblEspe.Name = "lblEspe";
            this.lblEspe.Size = new System.Drawing.Size(195, 16);
            this.lblEspe.TabIndex = 71;
            this.lblEspe.Text = "Filtrar Por Dentista/Especialista";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1Dia,
            this.Column1Hora,
            this.Column1Pro,
            this.Comumn1Esp,
            this.Status});
            this.dgv.Location = new System.Drawing.Point(12, 139);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(857, 267);
            this.dgv.TabIndex = 74;
            // 
            // Column1Dia
            // 
            this.Column1Dia.HeaderText = "Dia";
            this.Column1Dia.Name = "Column1Dia";
            this.Column1Dia.ReadOnly = true;
            this.Column1Dia.Width = 150;
            // 
            // Column1Hora
            // 
            this.Column1Hora.HeaderText = "Hora";
            this.Column1Hora.Name = "Column1Hora";
            this.Column1Hora.ReadOnly = true;
            this.Column1Hora.Width = 150;
            // 
            // Column1Pro
            // 
            this.Column1Pro.HeaderText = "Procedimento";
            this.Column1Pro.Name = "Column1Pro";
            this.Column1Pro.ReadOnly = true;
            this.Column1Pro.Width = 200;
            // 
            // Comumn1Esp
            // 
            this.Comumn1Esp.HeaderText = "Especialista";
            this.Comumn1Esp.Name = "Comumn1Esp";
            this.Comumn1Esp.ReadOnly = true;
            this.Comumn1Esp.Width = 200;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 200;
            // 
            // lblProce
            // 
            this.lblProce.AutoSize = true;
            this.lblProce.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProce.Location = new System.Drawing.Point(626, 2);
            this.lblProce.Name = "lblProce";
            this.lblProce.Size = new System.Drawing.Size(152, 16);
            this.lblProce.TabIndex = 70;
            this.lblProce.Text = "Filtrar Por Procedimento";
            // 
            // txtPesClien
            // 
            this.txtPesClien.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtPesClien.Location = new System.Drawing.Point(12, 21);
            this.txtPesClien.Name = "txtPesClien";
            this.txtPesClien.Size = new System.Drawing.Size(455, 20);
            this.txtPesClien.TabIndex = 63;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(9, 2);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(215, 16);
            this.lblCliente.TabIndex = 60;
            this.lblCliente.Text = "Pesquisar Pelo Nome do Paciente";
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.Location = new System.Drawing.Point(505, 21);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(90, 23);
            this.btnPesquisa.TabIndex = 77;
            this.btnPesquisa.Text = "Pesquisar";
            this.btnPesquisa.UseVisualStyleBackColor = true;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "9:00",
            "9:30",
            "10:00",
            "10:30",
            "11:00",
            "11:30",
            "12:00",
            "13:00",
            "13:30",
            "14:00",
            "14:30",
            "15:00",
            "15:30",
            "16:00",
            "16:30",
            "17:00",
            "17:30",
            "18:00",
            "18:30",
            "19:00"});
            this.comboBox4.Location = new System.Drawing.Point(451, 79);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 21);
            this.comboBox4.TabIndex = 81;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(331, 77);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(105, 20);
            this.dateTimePicker1.TabIndex = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(455, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 79;
            this.label1.Text = "HORA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(328, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 78;
            this.label2.Text = "Data ";
            // 
            // btnAgendar
            // 
            this.btnAgendar.Location = new System.Drawing.Point(738, 77);
            this.btnAgendar.Name = "btnAgendar";
            this.btnAgendar.Size = new System.Drawing.Size(104, 25);
            this.btnAgendar.TabIndex = 82;
            this.btnAgendar.Text = "Agendar";
            this.btnAgendar.UseVisualStyleBackColor = true;
            this.btnAgendar.Click += new System.EventHandler(this.btnAgendar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(598, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 83;
            this.label3.Text = "STATUS";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "AGENDADO",
            "CANCELADO",
            "FINALIZADO"});
            this.cboStatus.Location = new System.Drawing.Point(601, 79);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(121, 21);
            this.cboStatus.TabIndex = 84;
            // 
            // frmAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 459);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAgendar);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPesquisa);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblEspe);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.lblProce);
            this.Controls.Add(this.txtPesClien);
            this.Controls.Add(this.lblCliente);
            this.Name = "frmAgenda";
            this.Text = "Agenda";
            this.Load += new System.EventHandler(this.frmAgenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnSair;
        public System.Windows.Forms.ComboBox comboBox2;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.Label lblEspe;
        public System.Windows.Forms.DataGridView dgv;
        public System.Windows.Forms.Label lblProce;
        public System.Windows.Forms.TextBox txtPesClien;
        public System.Windows.Forms.Label lblCliente;
        public System.Windows.Forms.Button btnPesquisa;
        public System.Windows.Forms.ComboBox comboBox4;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnAgendar;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column1Dia;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column1Hora;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column1Pro;
        public System.Windows.Forms.DataGridViewTextBoxColumn Comumn1Esp;
        public System.Windows.Forms.DataGridViewTextBoxColumn Status;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox cboStatus;
    }
}