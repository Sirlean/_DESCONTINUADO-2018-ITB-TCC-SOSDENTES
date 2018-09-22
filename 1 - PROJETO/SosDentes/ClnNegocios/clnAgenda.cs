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
    class clnAgenda
    {
       
        private string _registro;
        private string _nome, _procedimento, _especialista, _data, _hora;
        string comando;
        clnBancoDados ObjBancoDados = new clnBancoDados();
       
      
        private string _status;
        public string Nome { get => _nome; set => _nome = value; }
        public string Procedimento { get => _procedimento; set => _procedimento = value; }
        public string Especialista { get => _especialista; set => _especialista = value; }
        public string Data { get => _data; set => _data = value; }

        public SqlDataReader LocalizarServico(string text)
        {
            comando = "select * from tipo_servico where Des_servico = '" + text + "'";
            return ObjBancoDados.RetornaLinha(comando);
        }

        public SqlDataReader LocalizarEspecialista(string text)
        {
            comando = "Select id_funcionario from funcionario where nome = '" + text + "'";
            return ObjBancoDados.RetornaLinha(comando);
        }

        public string Hora { get => _hora; set => _hora = value; }
        public string Status { get => _status; set => _status = value; }
        public string Registro { get => _registro; set => _registro = value; }

        public DataTable LocalizarPorNome(string strDescicao)
        {
            comando = "Select id_Paciente, Nome, CPF from Paciente Where nome like '%" + strDescicao + "%' order by id_Paciente";
            return ObjBancoDados.RetornaTabela(comando);
        }

        public DataTable RetornaAgendamento(string strDescricao)
        {
            comando = "select Tratamento.id_Tratamento, Paciente.Nome, Funcionario.Nome, Tipo_Servico.Des_servico, Tratamento.data, Tratamento.hora, Tratamento.status from Tratamento inner join Paciente on Paciente.id_Paciente = Tratamento.id_paciente inner join Funcionario on Funcionario.id_funcionario = Tratamento.id_dentista inner join Tipo_Servico on Tipo_Servico.id_servico = Tratamento.id_servico_FK Where Paciente.Nome like '%" + strDescricao + "%' order by id_tratamento";
            return ObjBancoDados.RetornaTabela(comando);
        }

        //public DataTable RetornaAgendamento()
        //{
        //    comando = "select Tratamento.id_Tratamento, Paciente.Nome, Funcionario.Nome, Tipo_Servico.Des_servico, Tratamento.data, Tratamento.hora, Tratamento.status from Tratamento inner join Paciente on Paciente.id_Paciente = Tratamento.id_paciente inner join Funcionario on Funcionario.id_funcionario = Tratamento.id_dentista inner join Tipo_Servico on Tipo_Servico.id_servico = Tratamento.id_servico_FK ";
        //    return ObjBancoDados.RetornaTabela(comando);
        //}
        internal object LocalizarPorNome(object text)
        {
            throw new NotImplementedException();
        }

        public void GravaNoBanco()
        {
            comando = "INSERT INTO Tratamento "; //(id_paciente, id_servico_FK, data, hora, status, id_dentista)";
            comando += ("VALUES(");
            comando += "'" + _nome + "',";
            comando += "'" + _procedimento + "',";
            comando += "'" + _data + "',";
            comando += "'" + _hora + "',";
            comando += "'" + Status + "',";
            comando += "'" + _especialista + "'";
            comando += ("'1'");
            comando += (")");
            ObjBancoDados.ExecutaComando(comando);
        }
   
        public void ExcluirLogicamente()
        {
            comando = ("UPDATE Tratamento ");
            comando += ("SET ");
            comando += ("Ativo = '" + 0 + " ' ");
            comando += ("WHERE ");
            comando += ("id_tratamento = ' " + _registro + "'");
            ObjBancoDados.ExecutaComando(comando);
        }
    }
}
//public void ExcluirLogicamente()
//{
//    comando = ("UPDATE paciente ");
//    comando += ("SET ");
//    comando += ("Ativo = '" + 0 + " ' ");
//    comando += ("WHERE ");
//    comando += ("id_Paciente = ' " + _registro + "'");
//    ObjBancoDados.ExecutaComando(comando);
//}