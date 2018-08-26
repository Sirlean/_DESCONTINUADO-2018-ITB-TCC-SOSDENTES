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

namespace SosDentes.Telas
{
    public partial class frmPaciente : Form
    {
        string comando;
        clnPaciente ObjPaciente = new clnPaciente();
        clnBancoDados ObjBancoDados = new clnBancoDados();

        public frmPaciente()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            frmCadPaciente ObjCadastroPaciente = new frmCadPaciente();

            ObjCadastroPaciente.Text = ">>> NOVO CADASTRO <<<";
            ObjCadastroPaciente.txtRegistro.Enabled = false;
            ObjCadastroPaciente.ShowDialog();
            CarregaDataGrid();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            CarregaDataGrid();
        }
        public void CarregaDataGrid()
        {
            dgv.DataSource = ObjPaciente.LocalizarPorNome(txtPesquisa.Text);
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
            comando = "Select id_Paciente, Nome,Tel_fixo,RG,CPF from Paciente where nome like '%" +
                strDescricao + "%' and Ativo='1' order by id_paciente";


            return ObjBancoDados.RetornaTabela(comando);
        }

        private void frmPaciente_Load(object sender, EventArgs e)
        {
            btnConsulta.Enabled = false;
            btnEdita.Enabled = false;
            btnExcluir.Enabled = false;
            dgv.RowHeadersVisible = false;
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            frmCadPaciente ObjCadastroPaciente = new frmCadPaciente();
            ObjCadastroPaciente.Text = ">>> CONSULTAR <<<";
            ObjCadastroPaciente.btnGravar.Visible = false;
            ObjCadastroPaciente.txtBairro.Enabled = false;
            ObjCadastroPaciente.txtCidade.Enabled = false;
            ObjCadastroPaciente.txtRua.Enabled = false;
            ObjCadastroPaciente.maskedTextBoxCep.Enabled = false;
            ObjCadastroPaciente.txtNome.Enabled = false;
            ObjCadastroPaciente.txtNumerodaCasa.Enabled = false;
            ObjCadastroPaciente.maskedTextBoxTelFixo.Enabled = false;
            ObjCadastroPaciente.txtEmail.Enabled = false;
            ObjCadastroPaciente.txtObservacao.Enabled = false;
            ObjCadastroPaciente.maskedTextBoxRG.Enabled = false;
            ObjCadastroPaciente.maskedTextBoxTelCelular.Enabled = false;
            ObjCadastroPaciente.cboUF.Enabled = false;
            ObjCadastroPaciente.txtComplemento.Enabled = false;
            ObjCadastroPaciente.dateTimePicker1.Enabled = false;
            ObjCadastroPaciente.maskedTextBoxCpf.Enabled = false;
            ObjCadastroPaciente.cboSexo.Enabled = false;
            ObjCadastroPaciente.txtRegistro.Enabled = false;

            ObjCadastroPaciente.cboUF.DropDownStyle = ComboBoxStyle.DropDownList;

            ObjCadastroPaciente.txtRegistro.Text = Convert.ToString(dgv.CurrentRow.Cells[0].Value);

            ObjCadastroPaciente.ShowDialog();
            CarregaDataGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Deseja excluir o Paciente: " + Convert.ToString(dgv.CurrentRow.Cells[0].Value + "?"),
                "E X C L U S Ã O", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (DialogResult.Yes == resultado)
            {
                ObjPaciente.Registro = dgv.CurrentRow.Cells[0].Value.ToString();
                ObjPaciente.ExcluirLogicamente();
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
            frmCadPaciente ObjCadastroAgenda = new frmCadPaciente();
            ObjCadastroAgenda.Text = ">>> ALTERAR <<<";
            ObjCadastroAgenda.txtRegistro.Enabled = false;
            ObjCadastroAgenda.btnGravar.Text = "&Alterar";
            ObjCadastroAgenda.maskedTextBoxCpf.Enabled = false;
            ObjCadastroAgenda.maskedTextBoxRG.Enabled = false;
            ObjCadastroAgenda.dateTimePicker1.Enabled = false;
            ObjCadastroAgenda.cboSexo.Enabled = false;
            ObjCadastroAgenda.txtRegistro.Text = Convert.ToString(dgv.CurrentRow.Cells[0].Value);
            ObjCadastroAgenda.txtNome.Focus();
            ObjCadastroAgenda.ShowDialog();
            CarregaDataGrid();
        }
    }
}
