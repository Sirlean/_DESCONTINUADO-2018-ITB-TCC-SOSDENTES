namespace SosDentes.Telas
{
    partial class frmMessageBoxAviso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMessageBoxAviso));
            this.pcbCaution = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblErro = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCaution)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbCaution
            // 
            this.pcbCaution.Image = ((System.Drawing.Image)(resources.GetObject("pcbCaution.Image")));
            this.pcbCaution.Location = new System.Drawing.Point(106, -4);
            this.pcbCaution.Name = "pcbCaution";
            this.pcbCaution.Size = new System.Drawing.Size(217, 177);
            this.pcbCaution.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbCaution.TabIndex = 9;
            this.pcbCaution.TabStop = false;
            this.pcbCaution.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(381, 266);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(81, 27);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblErro
            // 
            this.lblErro.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErro.Location = new System.Drawing.Point(5, 160);
            this.lblErro.Name = "lblErro";
            this.lblErro.Size = new System.Drawing.Size(470, 93);
            this.lblErro.TabIndex = 10;
            this.lblErro.Text = "TENTE NOVAMENTE";
            // 
            // frmMessageBoxAviso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 305);
            this.Controls.Add(this.lblErro);
            this.Controls.Add(this.pcbCaution);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMessageBoxAviso";
            this.Text = "frmMessageBoxAviso";
            ((System.ComponentModel.ISupportInitialize)(this.pcbCaution)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pcbCaution;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Label lblErro;
    }
}