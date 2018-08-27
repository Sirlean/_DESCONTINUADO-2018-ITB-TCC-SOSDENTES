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

        public DataTable LocalizarPorNome(string strDescicao)
        {
            comando = "Select id_Paciente, Nome, CPF from Paciente Where nome like '%" + strDescicao + "%' order by id_Paciente";
            return ObjBancoDados.RetornaTabela(comando);
        }

        public DataTable RetornaAgendamento()
        {
            //comando = "select p.Nome,f.Nome,tipo.Des_servico,t.data,t.hora,t.status FROM tratamento t, paciente p, dentista_servico d, Funcionario f, Tipo_Servico tipo WHERE t.id_paciente = p.id_paciente and f.id_funcionario = d.id_dentista";
            comando = "select * FROM view_agendamento";
            return ObjBancoDados.RetornaTabela(comando);
        }



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
            //comando += "'" + _data + "',";
            //comando += "'" + _hora + "',";
            comando += "convert(datetime, '" + _data + " " + _hora + "', 103), ";
            comando += "'" + Status + "',";
            comando += "'" + _especialista + "'";
            comando += (")");
            ObjBancoDados.ExecutaComando(comando);

        }
        public bool ValidarDataAgendamento(string DataInicio, string DataFim, string idDentista)
        {
            comando = " Select * from view_agendamento ";
            comando += " where ( id_dentista = '" + idDentista + "' and DataFim <> '" + DataInicio + "' and '" + DataInicio + "' between DataInicio and DataFim ) ";
            comando += " or ( id_dentista = '" + idDentista + "' and DataInicio <> '" + DataFim + "' and '" + DataFim + "' between DataInicio and DataFim ) ";
            DataTable dados = ObjBancoDados.RetornaTabela(comando);
            return dados.Rows.Count > 0;
        }
    }
}
