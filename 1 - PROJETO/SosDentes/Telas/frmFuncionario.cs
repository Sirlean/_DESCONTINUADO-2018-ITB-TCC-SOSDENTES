using SosDentes.BD;
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
using System.Data.SqlClient;
using System.IO;

namespace SosDentes.Telas
{
    public partial class frmFuncionario : Form
    {
        string comando;
        clnFuncionario ObjFuncionario = new clnFuncionario();
        clnBancoDados ObjBancoDados = new clnBancoDados();
        public frmFuncionario()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

            frmCadFuncionario ObjCadastroFuncionario = new frmCadFuncionario();

            ObjCadastroFuncionario.Text = ">>> NOVO CADASTRO <<<";
            ObjCadastroFuncionario.txtRegistro.Enabled = false;
            ObjCadastroFuncionario.ShowDialog();
            CarregaDataGrid();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            CarregaDataGrid();
        }
        public void CarregaDataGrid()
        {
            dgv.DataSource = ObjFuncionario.LocalizarPorNome(txtPesquisa.Text);
            dgv.Columns[0].HeaderText = ("CÓDIGO");

            dgv.AutoResizeColumns();

            if (dgv.RowCount == 0)
            {
                btnConsulta.Enabled = false;
                btnEdita.Enabled = false;
                btnExcluir.Enabled = false;
                MessageBox.Show("NÃO FORAM ENCONTRADOS DADOS COM A INFORMAÇÃO " + txtPesquisa.Text, "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgv.DataSource = null;
                txtPesquisa.Text = "";
                txtPesquisa.Focus();
            }
            else
            {
                btnConsulta.Enabled = true;
                btnEdita.Enabled = true;
                btnExcluir.Enabled = true;
            }
        }

        public DataTable LocalizarPorNome(string strDescricao)
        {
            comando = "Select id_Funcionario, Nome,Tel_fixo,RG,CPF from Funcionario where nome like '%" +
                strDescricao + "%' and Ativo='1' order by id_Funcionario";


            return ObjBancoDados.RetornaTabela(comando);
        }

        private void frmFuncionario_Load(object sender, EventArgs e)
        {
            btnConsulta.Enabled = false;
            btnEdita.Enabled = false;
            btnExcluir.Enabled = false;
            dgv.RowHeadersVisible = false;
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            {
                frmCadFuncionario ObjCadastroFuncionario = new frmCadFuncionario();
                ObjCadastroFuncionario.Text = ">>> CONSULTAR<<<";
                ObjCadastroFuncionario.btnGravar.Visible = false;
                ObjCadastroFuncionario.txtBairro.Enabled = false;
                ObjCadastroFuncionario.txtRua.Visible = false;
                ObjCadastroFuncionario.maskedTextBoxCep.Enabled = false;
                ObjCadastroFuncionario.txtNome.Enabled = false;
                ObjCadastroFuncionario.txtNumero.Enabled = false;
                ObjCadastroFuncionario.maskedTextBoxFixo.Enabled = false;
                ObjCadastroFuncionario.txtEmail.Enabled = false;
                ObjCadastroFuncionario.txtCidade.Enabled = false;
                ObjCadastroFuncionario.maskedTextBoxRG.Enabled = false;
                ObjCadastroFuncionario.maskedTextBoxCelular.Enabled = false;
                ObjCadastroFuncionario.cboUF.Enabled = false;
                ObjCadastroFuncionario.txtComplemento.Enabled = false;
                ObjCadastroFuncionario.dateTimePicker1.Enabled = false;
                ObjCadastroFuncionario.maskedTextBoxCpf.Enabled = false;
                ObjCadastroFuncionario.cboGenero.Enabled = false;             
                ObjCadastroFuncionario.cboCargo.Enabled = false;
                
                ObjCadastroFuncionario.cboUF.DropDownStyle = ComboBoxStyle.DropDownList;
                ObjCadastroFuncionario.txtRegistro.Enabled = false;



                ObjCadastroFuncionario.txtRegistro.Text = Convert.ToString(dgv.CurrentRow.Cells[0].Value);

                ObjCadastroFuncionario.ShowDialog();
                CarregaDataGrid();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Deseja excluir o Paciente: " + Convert.ToString(dgv.CurrentRow.Cells[0].Value + "?"),
               "E X C L U S Ã O", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (DialogResult.Yes == resultado)
            {
                ObjFuncionario.Registro = dgv.CurrentRow.Cells[0].Value.ToString();
                ObjFuncionario.ExcluirLogicamente();
                MessageBox.Show("Paciente Excluido com Sucesso", "E X C L U S Ã O", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Operação cancelada ", "cancelamento E X C L U S Ã O", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            CarregaDataGrid();
        }

        private void btnEdita_Click(object sender, EventArgs e)
        {
            frmCadFuncionario ObjCadastroAgenda = new frmCadFuncionario();
            ObjCadastroAgenda.Text = ">>> ALTERAR <<<";
            ObjCadastroAgenda.txtRegistro.Enabled = false;
            ObjCadastroAgenda.btnGravar.Text = "&Alterar";
            ObjCadastroAgenda.maskedTextBoxRG.Enabled = false;
            ObjCadastroAgenda.maskedTextBoxCpf.Enabled = false;
            ObjCadastroAgenda.cboCargo.Enabled = false;
            ObjCadastroAgenda.txtRegistro.Text = Convert.ToString(dgv.CurrentRow.Cells[0].Value);
            ObjCadastroAgenda.txtNome.Focus();
            ObjCadastroAgenda.ShowDialog();
            CarregaDataGrid();
        }
    }
}
