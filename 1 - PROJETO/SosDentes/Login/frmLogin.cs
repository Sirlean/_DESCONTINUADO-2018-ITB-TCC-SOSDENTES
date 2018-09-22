using SosDentes.ClnNegocios;
using SosDentes.Telas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using SosDentes.Login;

namespace SosDentes
{
    public partial class frmLogin : Form
    {
        frmPrincipal abrir = new frmPrincipal();
        frmMessageBoxAviso erro = new frmMessageBoxAviso();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            SqlDataReader dr;
            dr = controle.acessar(txtUsuario.Text, txtSenha.Text, cboNivel.Text);

            if (dr.Read())
            {


                if ((cboNivel.Text.Equals("RECEPCIONISTA")) == true)
                {
                    frmPrincipal abrir = new frmPrincipal();
                    MessageBox.Show("LOGADO COM SUCESSO","DADOS VÁLIDOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 
                    abrir.Hide();
                    abrir.ShowDialog();
                    Close();
                }

                else if ((cboNivel.Text.Equals("DENTISTA")) == true)
                {
                    frmPrincipal abrir = new frmPrincipal();
                    MessageBox.Show("LOGADO COM SUCESSO", "DADOS VÁLIDOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    abrir.menuCad.Visible = false;
                 
                    abrir.menuConsultas.Visible = false;
                    abrir.menuLogin.Visible = false;
                    abrir.paciente.Enabled = false;
                    abrir.funcionario.Enabled = false;
                    abrir.Hide();
                    abrir.ShowDialog();
                    Close();
                }
                else
                {
                    erro.pcbCaution.Visible = true;
                    erro.lblErro.Text = "DADOS INCORRETOS VERFIQUE???";
                    erro.ShowDialog();
                }
            }
            else
            {
                erro.pcbCaution.Visible = true;
                erro.lblErro.Text = "DADOS INCORRETOS VERFIQUE???";
                erro.ShowDialog();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {

            txtSenha.PasswordChar = '\0';
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            txtSenha.PasswordChar = '*';
        }

        private void cboNivel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEntrar_Click(sender, e);
            }
        }
    }
}
