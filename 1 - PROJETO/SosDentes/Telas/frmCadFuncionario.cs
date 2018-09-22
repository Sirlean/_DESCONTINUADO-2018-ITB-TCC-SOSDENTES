using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using SosDentes.ClnNegocios;

namespace SosDentes.Telas
{
    public partial class frmCadFuncionario : Form
    {
        frmMessageBoxAviso ObjErro = new frmMessageBoxAviso();
        clnFuncionario ObjClnFuncionario = new clnFuncionario();
        clnUtil ObjUtil = new clnUtil();
        public frmCadFuncionario()
        {
            InitializeComponent();
        }

        private void maskedTextBoxCep_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                SqlDataReader drDados;
                string cep = maskedTextBoxCep.Text.Replace("-", "");
                drDados = ObjUtil.ProcuraCep(cep);
                if (drDados.Read())
                {
                    txtRua.Text = Convert.ToString(drDados["descricao"]);
                    cboUF.Text = Convert.ToString(drDados["UF"]);
                    txtBairro.Text = Convert.ToString(drDados["Bairro"]);
                    txtCidade.Text = Convert.ToString(drDados["cidade"]);
                    txtNumero.Focus();
                }

                else
                {
                    MessageBox.Show("Cep não encontrado" + maskedTextBoxCep.Text, "Cep", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtRua.Text = "";
                    cboUF.Text = "";
                    cboUF.Text = "";
                    txtBairro.Text = "";
                    txtCidade.Text = "";

                    maskedTextBoxCep.Clear(); maskedTextBoxCep.Focus();
                    maskedTextBoxCep.Mask = "00000-999";
                    maskedTextBoxCep.SelectionStart = 0;
                }
            }
        }

        private void frmCadFuncionario_Load(object sender, EventArgs e)
        {
            cboUF.DropDownStyle = ComboBoxStyle.DropDownList;
            PreencherUF();
            txtNome.Focus();
            if (txtRegistro.Text != "")
            {
                SqlDataReader ObjDrDados;
                ObjDrDados = ObjClnFuncionario.LocalizarCodigo(txtRegistro.Text);
                if (ObjDrDados.Read())
                {
                    txtNome.Text = ObjDrDados["Nome"].ToString();
                    dateTimePicker1.Text = ObjDrDados["Dt_Nasc"].ToString();
                    maskedTextBoxRG.Text = ObjDrDados["RG"].ToString();
                    maskedTextBoxCpf.Text = ObjDrDados["CPF"].ToString();
                    cboGenero.Text = ObjDrDados["Genero"].ToString();
                    txtEmail.Text = ObjDrDados["Email"].ToString();
                    maskedTextBoxFixo.Text = ObjDrDados["Tel_fixo"].ToString();
                    maskedTextBoxCelular.Text = ObjDrDados["Celular"].ToString();
                    txtRua.Text = ObjDrDados["Endereco"].ToString();
                    txtNumero.Text = ObjDrDados["numero"].ToString();
                    txtBairro.Text = ObjDrDados["Bairro"].ToString();
                    txtComplemento.Text = ObjDrDados["Complemento"].ToString();
                    txtCidade.Text = ObjDrDados["Cidade"].ToString();
                    maskedTextBoxCep.Text = ObjDrDados["Cep"].ToString();
                    cboCargo.Text = ObjDrDados["CARGO"].ToString();
                    cboUF.Text = ObjDrDados["UF"].ToString();
                }
                txtNome.Focus();
                    
            }
        }
        public void PreencherUF()
        {
            cboUF.DataSource = ObjUtil.PreencherUF();
            cboUF.ValueMember = "UF";
            cboUF.DisplayMember = "UF";
            cboUF.SelectedIndex = 23;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

            if ((txtNome.Text == "") || (maskedTextBoxCelular.Text == "") || (txtNumero.Text == "") || (maskedTextBoxCep.Text == "") ||
              (txtRua.Text == "") || (cboUF.Text == "") || (txtBairro.Text == "") || (txtCidade.Text == "") || (txtEmail.Text == "") || (maskedTextBoxCpf.Text == "") || (maskedTextBoxRG.Text == "") ||
                    (cboGenero.Text == "") || (txtCidade.Text == "") || (cboCargo.Text == ""))
            {
                MessageBox.Show("Os campos com * são Obrigatórios", "Item Novo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                ObjClnFuncionario.Nome = txtNome.Text;
                ObjClnFuncionario.DataNacimento = dateTimePicker1.Text;
                ObjClnFuncionario.Email = txtEmail.Text;
                ObjClnFuncionario.TelCel = maskedTextBoxCelular.Text;
                ObjClnFuncionario.RG = maskedTextBoxRG.Text;
                ObjClnFuncionario.TelFixo = maskedTextBoxFixo.Text;
                ObjClnFuncionario.Sexo = cboGenero.Text;
                ObjClnFuncionario.RUA = txtRua.Text;
                ObjClnFuncionario.CPF = maskedTextBoxCpf.Text;
                ObjClnFuncionario.Bairro = txtBairro.Text;
                ObjClnFuncionario.Complemento = txtComplemento.Text;
                ObjClnFuncionario.Numero = txtNumero.Text;
                ObjClnFuncionario.CEP = maskedTextBoxCep.Text.Replace("-", "");
                ObjClnFuncionario.Cidade = txtCidade.Text;
                ObjClnFuncionario.Cargo = cboCargo.Text;
                ObjClnFuncionario.UF = cboUF.Text;

                if (txtRegistro.Text == "")
                {
                    ObjClnFuncionario.Gravar();
                    MessageBox.Show("Registo gravado com Sucesso", "Item Novo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (txtRegistro.Text != "")
                {
                    ObjClnFuncionario.Registro = txtRegistro.Text;
                    ObjClnFuncionario.Alterar();
                    MessageBox.Show("Registro Número " + txtRegistro.Text + ", Alterado com sucesso", "alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                Close();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (clnUtil.validarRegEx(txtEmail.Text))
                {
                    MessageBox.Show("E-MAIL INFORMADO É VÁLIDO! POR FAVOR, CONTINUE O CADASTRO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ObjErro.pcbCaution.Visible = true;
                    ObjErro.lblErro.Text = "Email inválido";
                    ObjErro.ShowDialog();
                }
            }
        }

        private void maskedTextBoxCpf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (clnUtil.ValidaCpf(maskedTextBoxCpf.Text) == false)
                {
                    MessageBox.Show("CPF INVÁLIDO DIGITE NOVAMENTE", "Erro Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("CPF INFORMADO É VÁLIDO! POR FAVOR, CONTINUE O CADASTRO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}

