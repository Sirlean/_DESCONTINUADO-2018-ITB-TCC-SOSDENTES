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

        }
    }
}
