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
using SosDentes.ClnNegocios;
using SosDentes.Telas;

namespace SosDentes.Login
{
    public partial class frmCadastrar : Form
    {
        public frmCadastrar()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            frmMessageBoxAviso erro = new frmMessageBoxAviso();
            Controle controle = new Controle();
            SqlDataReader dr;

            dr = controle.EmailExistente(txtUsuario.Text);

            if (dr.Read())
            {
                if (txtSenha.Text == "" || txtUsuario.Text == "" || cboCargo.Text == "")
                {
                    MessageBox.Show("TODOS CAMPOS SÃO OBRIGATÓRIOS OU DADOS EXISTENTES", "VERIFIQUE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSenha.Clear();
                    txtUsuario.Clear();
                }
            }
            else
            {
                controle.CadastrarFuncionario(txtUsuario.Text, txtSenha.Text, cboCargo.Text);
                MessageBox.Show("USUÁRIO CADASTRADO COM SUCESSO", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }          
        }
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            txtSenha.PasswordChar = '\0';
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            txtSenha.PasswordChar = '*';
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmPrincipal abrir = new frmPrincipal();
            Close();
        }
    }
}
