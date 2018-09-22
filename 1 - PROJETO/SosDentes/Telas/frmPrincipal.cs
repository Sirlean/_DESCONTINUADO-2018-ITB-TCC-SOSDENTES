using SosDentes.Login;
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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void pACIENTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadPaciente abrir = new frmCadPaciente();
            abrir.ShowDialog();
        }

        private void dENTISTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadFuncionario abrir = new frmCadFuncionario();
            abrir.ShowDialog();
        }

        private void sAIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void pESQUISAPORAGENDAMENTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgenda abrir = new frmAgenda();
            abrir.ShowDialog();
        }
        private void pacienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPaciente abrir = new frmPaciente();
            abrir.ShowDialog();

        }

        private void funcionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFuncionario abrir = new frmFuncionario();
            abrir.ShowDialog();
        }

        private void cadastrarLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrar abrir = new frmCadastrar();
            
            abrir.ShowDialog();
            
        }

        private void agendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultarAgendamento abrir = new frmConsultarAgendamento();
            abrir.ShowDialog();
        }

        private void paciente_Click(object sender, EventArgs e)
        {
            frmPaciente abrir = new frmPaciente();
            abrir.ShowDialog();
        }

        private void funcionario_Click(object sender, EventArgs e)
        {
            frmFuncionario abrir = new frmFuncionario();
            abrir.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmAgenda abrir = new frmAgenda();
            abrir.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            frmConsultarAgendamento abrir = new frmConsultarAgendamento();
            abrir.ShowDialog();
        }

        private void dentistaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            defenirEspecialidade  abrir = new defenirEspecialidade();
            abrir.ShowDialog();
        }
    }
}
