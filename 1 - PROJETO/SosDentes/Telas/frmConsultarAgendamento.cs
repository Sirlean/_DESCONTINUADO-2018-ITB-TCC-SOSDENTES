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

namespace SosDentes.Telas
{
    public partial class frmConsultarAgendamento : Form
    {
        clnAgenda ObjAgenda = new clnAgenda();
     

        public frmConsultarAgendamento()
        {
            InitializeComponent();
        }


        public void CarregaDataGrid()
        {
            dgv.DataSource = ObjAgenda.RetornaAgendamento(txtPesquisar.Text);

            dgv.AutoResizeColumns();
            dgv.Columns[0].HeaderText = ("CÓDIGO");
            dgv.Columns[1].HeaderText = ("PACIENTE");
            dgv.Columns[2].HeaderText = ("FUNCIONÁRIO");
            dgv.Columns[3].HeaderText = ("SERVIÇO");
            dgv.Columns[4].HeaderText = ("DATA");
            dgv.Columns[5].HeaderText = ("HORA");
            dgv.Columns[6].HeaderText = ("STATUS");

            if (dgv.RowCount == 0)
            {
             
                btnAlterar.Enabled = false;
                btnCancelar.Enabled = false;
                MessageBox.Show("NÃO FORAM ENCONTRADOS DADOS COM A INFORMAÇÃO " + txtPesquisar.Text, "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgv.DataSource = null;
                txtPesquisar.Text = "";
                txtPesquisar.Focus();
            }
            else
            {
                btnAlterar.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Deseja excluir o Agendamento: " + Convert.ToString(dgv.CurrentRow.Cells[0].Value + "?"),
                        "E X C L U S Ã O", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (DialogResult.Yes == resultado)
            {
                ObjAgenda.Registro = dgv.CurrentRow.Cells[0].Value.ToString();
                ObjAgenda.ExcluirLogicamente();
                MessageBox.Show("Paciente Excluido com Sucesso", "E X C L U S Ã O", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Operação cancelada ", "cancelamento E X C L U S Ã O", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            CarregaDataGrid();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            frmAgenda alt = new frmAgenda();
            alt.Text = ">>> ALTERAR <<<";
            alt.txtPesClien.Enabled = false;
            alt.comboBox2.Enabled = false;
            alt.comboBox1.Enabled = false;
            alt.cboStatus.Enabled = false;
            alt.txtPesClien.Focus();
            alt.ShowDialog();
            CarregaDataGrid();
        }

        private void btnPesquisar_Click_1(object sender, EventArgs e)
        {
            CarregaDataGrid();
        }

        private void frmConsultarAgendamento_Load(object sender, EventArgs e)
        {
           
            btnCancelar.Enabled = false;
            btnAlterar.Enabled = false;
            dgv.RowHeadersVisible = false;
        }
    }
}

