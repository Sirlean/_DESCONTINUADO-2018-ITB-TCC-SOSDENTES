using SosDentes.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SosDentes.ClnNegocios
{
    class clnPaciente
    {
        string comando; //COMANDOS DE SQL QUE SERÃO ENVIADOS 

        clnBancoDados ObjBancoDados = new clnBancoDados();

        private string _registro, _nome, _CPF, _RG, _dataNacimento, _sexo, _telFixo, _telCel, _email, _CEP, _RUA, _UF,
             _bairro, _cidade, _numerodaCasa, _complemento, _observacao;

        public string Registro { get => _registro; set => _registro = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string CPF { get => _CPF; set => _CPF = value; }
        public string RG { get => _RG; set => _RG = value; }
        public string DataNacimento { get => _dataNacimento; set => _dataNacimento = value; }
        public string Sexo { get => _sexo; set => _sexo = value; }
        public string TelFixo { get => _telFixo; set => _telFixo = value; }
        public string TelCel { get => _telCel; set => _telCel = value; }
        public string Email { get => _email; set => _email = value; }
        public string CEP { get => _CEP; set => _CEP = value; }
        public string RUA { get => _RUA; set => _RUA = value; }
        public string UF { get => _UF; set => _UF = value; }
        public string Bairro { get => _bairro; set => _bairro = value; }
        public string Cidade { get => _cidade; set => _cidade = value; }
        public string NumerodaCasa { get => _numerodaCasa; set => _numerodaCasa = value; }
        public string Complemento { get => _complemento; set => _complemento = value; }
        public string Observacao { get => _observacao; set => _observacao = value; }

        public DataTable LocalizarPorNome(string strDescicao)
        {
            comando = "Select id_Paciente, Nome,Tel_Fixo,rg,cpf from paciente Where nome like '%" + strDescicao + "%' and Ativo='1' order by id_Paciente";
            return ObjBancoDados.RetornaTabela(comando);
        }
        public SqlDataReader LocalizarCodigo(string registro)
        {
            comando = "select * from Paciente where id_Paciente ='" + registro + "'";
            return ObjBancoDados.RetornaLinha(comando);
        }

        public void ExcluirLogicamente()
        {
            comando = ("UPDATE paciente ");
            comando += ("SET ");
            comando += ("Ativo = '" + 0 + " ' ");
            comando += ("WHERE ");
            comando += ("id_Paciente = ' " + _registro + "'");
            ObjBancoDados.ExecutaComando(comando);
        }
        public void Gravar()
        {
            comando = "INSERT INTO paciente ";
            comando += ("VALUES(");
            comando += ("'" + _nome + "',");
            comando += ("'" + _dataNacimento + "',");
            comando += ("'" + _email + "',");
            comando += ("'" + _telCel + "',");
            comando += ("'" + _RG + "',");
            comando += ("'" + _telFixo + "',");
            comando += ("'" + _sexo + "',");
            comando += ("'" + _RUA + "',");
            comando += ("'" + _CPF + "',");
            comando += ("'" + _bairro + "',");
            comando += ("'" + _complemento + "',");
            comando += ("'" + _numerodaCasa + "',");
            comando += ("'" + _CEP + "',");
            comando += ("'" + _UF + "',");
            comando += ("'" + _cidade + "',");
            comando += ("'" + _observacao + "',");
            comando += ("'1'");
            comando += (")");
            ObjBancoDados.ExecutaComando(comando);
        }
        public void Alterar()
        {

            comando = ("UPDATE Paciente ");
            comando += ("SET ");
            comando += ("Nome = '" + _nome + "',");
            comando += ("Dt_Nasc = '" + _dataNacimento + "',");
            comando += ("Email = '" + _email + "',");
            comando += ("Celular = '" + _telCel + "',");
            comando += ("RG = '" + _RG + "',");
            comando += ("Tel_Fixo = '" + _telFixo + "',");
            comando += ("Genero = '" + _sexo + "',");
            comando += ("Endereco = '" + _RUA + "',");
            comando += ("CPF = '" + _CPF + "',");
            comando += ("Bairro = '" + _bairro + "',");
            comando += ("Complemento = '" + _complemento + "',");
            comando += ("numero = '" + _numerodaCasa + "',");
            comando += ("CEP = '" + _CEP + "',");
            comando += ("UF = '" + _UF + "',");
            comando += ("Cidade = '" + _cidade + "',");
            comando += ("Observacao = '" + _observacao + "',");
            comando += ("Ativo = '1'");
            comando += ("WHERE ");
            comando += ("id_Paciente = ' " + _registro + "'");
            ObjBancoDados.ExecutaComando(comando);

        }
    }
}