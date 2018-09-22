using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SosDentes.BD;

namespace SosDentes.ClnNegocios
{
    class clnDentistaServico
    {
       
        private string _dentista, _servico;
        public string Dentista { get => _dentista; set => _dentista = value; }
        public string Servico { get => _servico; set => _servico = value; }
    


        string comando;
        clnBancoDados ObjBancoDados = new clnBancoDados();


        public DataTable LocalizarPorDentista(string strDescicao)
        {
            comando = "Select id_Funcionario, Nome, CPF, Cargo from funcionario Where nome like '%" + strDescicao + "%' order by id_Funcionario";
            return ObjBancoDados.RetornaTabela(comando);
        }

        public DataTable RetornaEspecialidade()
        {
            comando = "select ds.id_servico, ds.id_dentista, Funcionario.CARGO ,Tipo_Servico.Des_servico from dentista_servico ds inner join Tipo_Servico on ds.id_servico = Tipo_Servico.id_servico inner join Funcionario on ds.id_dentista = Funcionario.id_funcionario where Funcionario.CARGO = 'Dentista'";
            return ObjBancoDados.RetornaTabela(comando);
        }

        public DataTable ConsultarEspecialidades(string idDentista)
        {
            comando = "select id_servico from dentista_servico where id_dentista = " + idDentista;
            return ObjBancoDados.RetornaTabela(comando);
        }

        public void GravarEspecialidade(string idDentista, string idServico)
        {
            comando = "INSERT INTO dentista_servico(id_dentista, id_servico) ";
            comando += ("VALUES(");
            comando += "'" + idDentista + "',";
            comando += "'" + idServico + "'";
            comando += (")");
            ObjBancoDados.ExecutaComando(comando);
        }
        public void RemoverEspecialidades(string idDentista)
        {
            comando =  " delete from dentista_servico ";
            comando += " Where id_dentista = " + idDentista;
            ObjBancoDados.ExecutaComando(comando);
        }
    }
}
