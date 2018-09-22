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

namespace SosDentes.Telas
{
    public partial class frmAgenda : Form
    {
        clnAgenda ObjAgenda = new clnAgenda();
        public static string texto;
        clnUtil ObjUtil = new clnUtil();
        public static string Temp2;

        public frmAgenda()
        {
            InitializeComponent();
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            if (txtPesClien.Text == "" || comboBox2.Text == "" || comboBox1.Text == "" || comboBox4.Text == "" || cboStatus.Text == "" || dateTimePicker1.Text == "")
            {
                MessageBox.Show("TODOS OS CAMPOS SÃO OBRIGATÓRIOS ", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                clnAgenda ObjAgenda = new clnAgenda();
                SqlDataReader idServico;
                idServico = ObjAgenda.LocalizarServico(comboBox2.Text);
                idServico.Read();
                ObjAgenda.Procedimento = idServico["id_servico"].ToString();
                idServico.Read();
                ObjAgenda.Nome = Temp2;
                idServico.Read();
                idServico = ObjAgenda.LocalizarEspecialista(comboBox1.Text);
                idServico.Read();
                string id_especialista = idServico["id_funcionario"].ToString();
                ObjAgenda.Especialista = id_especialista;
                ObjAgenda.Hora = comboBox4.Text.Replace(":", "");
                string data = dateTimePicker1.Text.Replace("/", "");
                ObjAgenda.Status = cboStatus.Text.ToString();
                ObjAgenda.Data = data;
                ObjAgenda.GravaNoBanco();
                InsereAgendaGrid();
                MessageBox.Show("AGENDADO COM SUCESSO", "AGENDAMENTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //CarregaDataGrid();
        }


        public void InsereAgendaGrid()
        {

            dgv.Columns[0].HeaderText = ("Data");
            dgv.Columns[1].HeaderText = ("Hora");
            dgv.Columns[2].HeaderText = ("Procedimento");
            dgv.Columns[3].HeaderText = ("Especialista");
            dgv.Columns[4].HeaderText = ("Status");

            dgv.AutoResizeColumns();

            dgv.Rows.Add();
            dgv.CurrentRow.Cells[0].Value = dateTimePicker1.Text;
            dgv.CurrentRow.Cells[1].Value = comboBox4.Text;
            dgv.CurrentRow.Cells[2].Value = comboBox2.Text;
            dgv.CurrentRow.Cells[3].Value = comboBox1.Text;
            dgv.CurrentRow.Cells[4].Value = cboStatus.Text;
        }
        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            frmPesquisarPacientes abrir = new frmPesquisarPacientes();
            clnUtil.Temp = txtPesClien.Text;
           
            abrir.ShowDialog();

            txtPesClien.Text = clnUtil.Temp;

            if (!(txtPesClien.Equals("") || txtPesClien == null))
            {
                comboBox2.Enabled = true;
                PreencherTipoServico();
            }

        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            comboBox2.Enabled = false;
            comboBox1.Enabled = false;
        }

        public void PreencherTipoServico()
        {
            comboBox2.DataSource = ObjUtil.PreencherTipoServico();
            comboBox2.ValueMember = "Des_Servico";
            comboBox2.DisplayMember = "Des_servico";
            // comboBox2.SelectedIndex = 1;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {


            comboBox1.Enabled = true;
            comboBox1.Text = "";
            PreencherDentista();


        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            PreencherTipoServico();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {

            PreencherDentista();
        }
        public void PreencherDentista()
        {
            string nome_servico = (comboBox2.SelectedValue).ToString();
            comboBox1.DataSource = ObjUtil.PreencherDentista(nome_servico);
            comboBox1.ValueMember = "DENTISTA";
            comboBox1.DisplayMember = "DENTISTA";
            //comboBox1.ValueMember = "id_dentista";
            //comboBox1.DisplayMember = "id_dentista";

            //    comboBox1.SelectedIndex = 1;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }
        //private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        //{
        //    comboBox1.Enabled = true;
        //    PreencherDentista();
        //}

    }
}
