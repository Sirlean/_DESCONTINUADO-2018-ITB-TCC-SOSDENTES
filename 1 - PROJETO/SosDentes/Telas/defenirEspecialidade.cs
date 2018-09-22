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
    public partial class defenirEspecialidade : Form
    {
        public DataTable EspecialidadesSelecionadas { get; set; }
        public defenirEspecialidade()
        {
            InitializeComponent();
            lbEspecialidadesSelecionadas.DisplayMember = "Des_servico";
            lbEspecilidades.DisplayMember = "Des_servico";
            btnAdicionar.Enabled = false;
            btnRemover.Enabled = false;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmPesquisarDentista abrir = new frmPesquisarDentista();
            clnUtil.Temp = txtPesquisa.Text;

            abrir.ShowDialog();
            if (string.IsNullOrEmpty(frmPesquisarDentista.Temp2) == false)
            {
                btnAdicionar.Enabled = true;
                btnRemover.Enabled = true;
                txtPesquisa.Text = clnUtil.Temp;
                CarregarEspecialidades();
                CarregarEspecialidadesDentista();
            }



        }

        private void CarregarEspecialidadesDentista()
        {
            clnDentistaServico ObjDentista = new clnDentistaServico();
            DataTable data = ObjDentista.ConsultarEspecialidades(frmPesquisarDentista.Temp2);

            foreach (DataRow item in data.Rows)
            {
                foreach (DataRow especialidade in ((DataTable)lbEspecilidades.DataSource).Rows)
                {
                    if ((int)item["id_servico"] == (int)especialidade["id_servico"])
                    {
                        this.EspecialidadesSelecionadas.Rows.Add(especialidade["id_servico"], especialidade["Des_servico"]);
                        break;
                    }
                }
            }
            this.lbEspecialidadesSelecionadas.DataSource = EspecialidadesSelecionadas;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(frmPesquisarDentista.Temp2))
            {
                MessageBox.Show("O CAMPO PESQUISA É OBRIGATÓRIO", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAdicionar.Enabled = false;
                btnRemover.Enabled = false;
            }
            else
            {
                clnDentistaServico ObjDentista = new clnDentistaServico();
                ObjDentista.RemoverEspecialidades(frmPesquisarDentista.Temp2);

                foreach (DataRow item in EspecialidadesSelecionadas.Rows)
                {
                    string idServico = item["id_servico"].ToString();
                    ObjDentista.GravarEspecialidade(frmPesquisarDentista.Temp2, idServico);
                }
                MessageBox.Show("Especialidades gravadas com sucesso","Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (lbEspecilidades.SelectedItems.Count > 0)
            {
                foreach (DataRowView especialidade in lbEspecilidades.SelectedItems)
                {
                    bool teste = false;
                    foreach (DataRow item in EspecialidadesSelecionadas.Rows)
                    {
                        if ((int)item["id_servico"] == (int)especialidade["id_servico"])
                        {
                            teste = true;
                            break;
                        }
                    }
                    if (teste == false)
                    {

                        this.EspecialidadesSelecionadas.Rows.Add(especialidade["id_servico"], especialidade["Des_servico"]);

                    }
                }
            }
            this.lbEspecialidadesSelecionadas.DataSource = EspecialidadesSelecionadas;
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPesquisa.Text))
            {
                frmPesquisarDentista.Temp2 = string.Empty;
                btnAdicionar.Enabled = false;
                btnRemover.Enabled = false;
            }
        }

        private void defenirEspecialidade_Load(object sender, EventArgs e)
        {
            CarregarEspecialidades();

        }

        private void CarregarEspecialidades()
        {
            clnUtil ObjUtil = new clnUtil();
            DataTable data = ObjUtil.PreencherEspecialidade();
            lbEspecilidades.DataSource = data;
            this.EspecialidadesSelecionadas = data.Clone();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            var itens = lbEspecialidadesSelecionadas.SelectedItems.Cast<DataRowView>().ToArray();
            foreach (DataRowView item in itens)
            {
                foreach (DataRow especialidade in EspecialidadesSelecionadas.Rows)
                {
                    if ((int)item["id_servico"] == (int)especialidade["id_servico"])
                    {
                        EspecialidadesSelecionadas.Rows.Remove(especialidade);
                        break;
                    }
                }
            }
        }

        private void lbEspecilidades_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdicionar_Click(sender, e);
            }
        }
    }
}
