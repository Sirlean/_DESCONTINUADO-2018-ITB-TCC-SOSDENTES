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
    public partial class frmPesquisarDentista : Form
    {
        public frmPesquisarDentista()
        {
            InitializeComponent();
        }
        public static string Temp2;

        private void frmPesquisarDentista_Load(object sender, EventArgs e)
        {
            CarregaDataGrid();
        }
        public void CarregaDataGrid()
        {
            //frmAgenda cad = new frmAgenda();
            clnDentistaServico ObjDentista = new clnDentistaServico();
            dgv.DataSource = ObjDentista.LocalizarPorDentista(clnUtil.Temp);
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            clnUtil.Temp = dgv.CurrentRow.Cells[1].Value.ToString();
            frmPesquisarDentista.Temp2 = dgv.CurrentRow.Cells[0].Value.ToString();
            Close();
        }
    }
}
