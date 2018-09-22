using SosDentes.ClnNegocios;
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

namespace SosDentes.Telas
{
    public partial class frmCadPaciente : Form
    {
        frmMessageBoxAviso ObjErro = new frmMessageBoxAviso();
        clnPaciente ObjClnPaciente = new clnPaciente();
        clnUtil ObjUtil = new clnUtil();
        public frmCadPaciente()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if ((txtNome.Text == "") || (maskedTextBoxTelCelular.Text == "") || (txtNumerodaCasa.Text == "") || (maskedTextBoxCep.Text == "") ||
               (txtRua.Text == "") || (cboUF.Text == "") || (txtBairro.Text == "") || (txtCidade.Text == "") || (txtEmail.Text == "") || (maskedTextBoxCpf.Text == "") || (maskedTextBoxRG.Text == "") ||
                     (cboSexo.Text == "") || (txtCidade.Text == ""))
            {
                MessageBox.Show("Os campos com * são Obrigatórios", "Item Novo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                ObjClnPaciente.Nome = txtNome.Text;
                ObjClnPaciente.DataNacimento = dateTimePicker1.Text;
                ObjClnPaciente.Email = txtEmail.Text;
                ObjClnPaciente.TelCel = maskedTextBoxTelCelular.Text;
                ObjClnPaciente.RG = maskedTextBoxRG.Text;
                ObjClnPaciente.TelFixo = maskedTextBoxTelFixo.Text;
                ObjClnPaciente.Sexo = cboSexo.Text;
                ObjClnPaciente.RUA = txtRua.Text;
                ObjClnPaciente.CPF = maskedTextBoxCpf.Text;
                ObjClnPaciente.Bairro = txtBairro.Text;
                ObjClnPaciente.Complemento = txtComplemento.Text;
                ObjClnPaciente.NumerodaCasa = txtNumerodaCasa.Text;
                ObjClnPaciente.CEP = maskedTextBoxCep.Text.Replace("-", "");
                ObjClnPaciente.UF = cboUF.Text;
                ObjClnPaciente.Cidade = txtCidade.Text;
                ObjClnPaciente.Observacao = txtObservacao.Text;


                if (txtRegistro.Text == "")
                {
                    ObjClnPaciente.Gravar();
                    MessageBox.Show("Registo gravado com Sucesso", "Item Novo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (txtRegistro.Text != "")
                {
                    ObjClnPaciente.Registro = txtRegistro.Text;
                    ObjClnPaciente.Alterar();
                    MessageBox.Show("Registro Número " + txtRegistro.Text + ", Alterado com sucesso", "alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                Close();

            }
        }


        private void frmCadPaciente_Load(object sender, EventArgs e)
        {
            cboUF.DropDownStyle = ComboBoxStyle.DropDownList;
            PreencherUF();
            txtNome.Focus();
            if (txtRegistro.Text != "")
            {
                SqlDataReader ObjDrDados;
                ObjDrDados = ObjClnPaciente.LocalizarCodigo(txtRegistro.Text);
                if (ObjDrDados.Read())
                {
                    txtNome.Text = ObjDrDados["Nome"].ToString();
                    dateTimePicker1.Text = ObjDrDados["Dt_Nasc"].ToString();
                    txtEmail.Text = ObjDrDados["Email"].ToString();
                    maskedTextBoxTelCelular.Text = ObjDrDados["Celular"].ToString();
                    maskedTextBoxRG.Text = ObjDrDados["RG"].ToString();
                    maskedTextBoxTelFixo.Text = ObjDrDados["Tel_fixo"].ToString();
                    cboSexo.Text = ObjDrDados["Genero"].ToString();
                    txtRua.Text = ObjDrDados["Endereco"].ToString();
                    maskedTextBoxCpf.Text = ObjDrDados["CPF"].ToString();
                    txtBairro.Text = ObjDrDados["Bairro"].ToString();
                    txtComplemento.Text = ObjDrDados["Complemento"].ToString();
                    txtNumerodaCasa.Text = ObjDrDados["numero"].ToString();
                    maskedTextBoxCep.Text = ObjDrDados["CEP"].ToString();
                    cboUF.Text = ObjDrDados["UF"].ToString();
                    txtCidade.Text = ObjDrDados["Cidade"].ToString();
                    txtObservacao.Text = ObjDrDados["Observacao"].ToString();
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
                    txtNumerodaCasa.Focus();
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

        private void maskedTextBoxCpf_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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

