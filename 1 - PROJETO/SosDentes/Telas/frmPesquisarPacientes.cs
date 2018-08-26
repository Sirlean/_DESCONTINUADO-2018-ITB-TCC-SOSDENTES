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
    
    public partial class frmPesquisarPacientes : Form
    {
        
        public frmPesquisarPacientes()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            CarregaDataGrid();
        }
        public void CarregaDataGrid()
        {
            //frmAgenda cad = new frmAgenda();
            clnAgenda ObjAgenda = new clnAgenda();
            dgv.DataSource = ObjAgenda.LocalizarPorNome(clnUtil.Temp);
        }

        private void frmPesquisarPacientes_Load(object sender, EventArgs e)
        {
            CarregaDataGrid();
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {

            clnUtil.Temp = dgv.CurrentRow.Cells[1].Value.ToString();
            frmAgenda.Temp2 = dgv.CurrentRow.Cells[0].Value.ToString();
            Close();
        }
    }
}
