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
    class clnFuncionario
    {
        private string comando;

        clnBancoDados ObjBancoDados = new clnBancoDados();


        private string _registro, _nome, _CPF, _RG, _dataNacimento, _sexo, _telFixo, _telCel, _email, _CEP, _RUA, _UF,
            _bairro, _cidade, _numero, _complemento, _cargo;

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
        public string Numero { get => _numero; set => _numero = value; }
        public string Complemento { get => _complemento; set => _complemento = value; }
        public string Cargo { get => _cargo; set => _cargo = value; }

        public DataTable LocalizarPorNome(string strDescicao)
        {
            comando = "Select id_funcionario, Nome,Tel_Fixo,RG,CPF from Funcionario Where Nome like '%" + strDescicao + "%' and Ativo='1' order by id_funcionario";
            return ObjBancoDados.RetornaTabela(comando);
        }
        public SqlDataReader LocalizarCodigo(string registro)
        {
            comando = "select * from Funcionario where id_funcionario ='" + registro + "'";
            return ObjBancoDados.RetornaLinha(comando);
        }
        public void ExcluirLogicamente()
        {
            comando = ("UPDATE Funcionario ");
            comando += ("SET ");
            comando += ("Ativo = '" + 0 + " ' ");
            comando += ("WHERE ");
            comando += ("id_funcionario = ' " + _registro + "'");
            ObjBancoDados.ExecutaComando(comando);
        }
        public void Gravar()
        {
            comando = "INSERT INTO Funcionario ";
            comando += ("VALUES(");
            comando += ("'" + _nome + "',");
            comando += ("'" + _dataNacimento + "',");
            comando += ("'" + _RG + "',");
            comando += ("'" + _CPF + "',");
            comando += ("'" + _sexo + "',");
            comando += ("'" + _email + "',");
            comando += ("'" + _telFixo + "',");
            comando += ("'" + _telCel + "',");
            comando += ("'" + _RUA + "',");
            comando += ("'" + _numero + "',");
            comando += ("'" + _bairro + "',");
            comando += ("'" + _complemento + "',");
            comando += ("'" + _cidade + "',");
            comando += ("'" + _CEP + "',");
            comando += ("'" + _cargo + "',");
            comando += ("'" + _UF + "',");
            comando += ("'1'");
            comando += (")");
            ObjBancoDados.ExecutaComando(comando);
        }
        public void Alterar()
        {

            comando = ("UPDATE Funcionario ");
            comando += ("SET ");
            comando += ("Nome = '" + _nome + "',");
            comando += ("Dt_Nasc = '" + _dataNacimento + "',");
            comando += ("RG = '" + _RG + "',");
            comando += ("CPF = '" + _CPF + "',");
            comando += ("Genero = '" + _sexo + "',");
            comando += ("Email = '" + _email + "',");
            comando += ("Tel_Fixo = '" + _telFixo + "',");
            comando += ("Celular = '" + _telCel + "',");
            comando += ("Endereco = '" + _RUA + "',");
            comando += ("numero = '" + _numero + "',");
            comando += ("Bairro = '" + _bairro + "',");
            comando += ("Complemento = '" + _complemento + "',");
            comando += ("Cidade = '" + _cidade + "',");
            comando += ("Cep = '" + _CEP + "',");
            comando += ("CARGO = '" + _cargo + "',");
            comando += ("UF = '" + _UF + "',");   
            comando += ("Ativo = '1'");
            comando += ("WHERE ");
            comando += ("id_funcionario = ' " + _registro + "'");
            ObjBancoDados.ExecutaComando(comando);
        }

    }
}
