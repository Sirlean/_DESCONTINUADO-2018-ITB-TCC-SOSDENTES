using SosDentes.BD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SosDentes.Telas;

namespace SosDentes.ClnNegocios
{
    public class Controle
    {
        
        public bool tem;
        public String mensagem = "";
        
        public SqlDataReader acessar(String login, String senha, String cargo)
        {
            string comando = "select * from logins where email='" + login + "' and senha='" + senha + "' and cargo='" + cargo + "'";
            clnBancoDados bd = new clnBancoDados();
            return bd.RetornaLinha(comando);

        }

        public SqlDataReader EmailExistente(string text)
        {
            string comando = "select email from logins where email = '" + text + "'"; ;
            clnBancoDados bd = new clnBancoDados();
            return bd.RetornaLinha(comando);
        }

        ////public SqlDataReader cadastrar(String email, String senha, String cargo)
        ////{

        ////    clnBancoDados bd = new clnBancoDados();
        ////    return bd.RetornaLinha(comando);
        ////}

        internal void CadastrarFuncionario(string text1, string text2, string text3)
        {
            string comando = "insert into logins (email, senha, cargo) values ('" + text1 + "','" + text2 + "','" + text3 + "')";
            clnBancoDados db = new clnBancoDados();
            db.ExecutaComando(comando);
        }

        //public String cadastrar(String email, String senha, String confSenha)
        //{
        //if (senha.Equals(confSenha))
        //{
        //    comando = "INSERT INTO logins VALUES (@e,@s);";

        //}

    }
}

