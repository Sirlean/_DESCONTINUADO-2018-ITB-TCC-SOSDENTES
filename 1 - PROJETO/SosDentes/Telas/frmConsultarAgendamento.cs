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
    public partial class frmConsultarAgendamento : Form
    {
        clnAgenda ObjAgenda = new clnAgenda();
        public frmConsultarAgendamento()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CarregaDataGrid();
        }
        public void CarregaDataGrid()
        {
            dgv.DataSource = ObjAgenda.RetornaAgendamento();
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].Visible = false;
            dgv.Columns[4].Visible = false;
            dgv.Columns[7].Visible = false;

            dgv.Columns[2].HeaderText = "Nome do Paciente  ";
            //dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns[3].HeaderText = "Celular do Paciente  ";
            //dgv.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns[5].HeaderText = "Nome do Serviço  ";
            //dgv.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns[6].HeaderText = "Tempo de Atendimento  ";
            //dgv.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns[8].HeaderText = "Nome de Dentista  ";
            //dgv.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns[9].HeaderText = "Data de Inicio  ";
            //dgv.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns[10].HeaderText = "Data de Fim  ";
            //dgv.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
    }
}
