using SosDentes.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using static System.Convert;


namespace SosDentes
{
    class clnUtil
    {
        private string _cpf;
        private static string temp;

        string comando = "";
        clnBancoDados ObjbancoDados = new clnBancoDados();

        private static string tempCpf;
        public static string Temp { get => temp; set => temp = value; }
        public string Cpf { get => _cpf; set => _cpf = value; }
        public static string TempCpf { get => tempCpf; set => tempCpf = value; }

        public DataTable PreencherUF()
        {
            comando = "Select UF from T_UF";
            return ObjbancoDados.RetornaTabela(comando);
        }

        public DataTable PreencherTipoServico()
        {
            comando = "Select id_servico, Des_servico from Tipo_Servico";
            return ObjbancoDados.RetornaTabela(comando);
        }

        public DataTable PreencherDentista(string id_servico)
        {
            comando = "select f.nome 'DENTISTA', ts.Des_servico 'SERVICO' from dentista_servico ds " +
                      "inner join Tipo_Servico ts  on ts.id_servico =  ds.id_servico " + 
                      "inner join Funcionario f  on f.id_funcionario = ds.id_dentista " + 
                       " where f.CARGO = 'DENTISTA' and ts.des_servico = '" + id_servico +"'";   
            return ObjbancoDados.RetornaTabela(comando);
        }



        public SqlDataReader ProcuraCep(string cep)
        {
            comando = "SELECT * FROM [dbo].[CepFiltradas$] WHERE CEP= '" + cep + "'";
            return ObjbancoDados.RetornaLinha(comando);
        }

        public DataTable PreencherEspecialidade()
        {
            DataTable data = new DataTable();
            data.Columns.Add("id_servico", typeof(int));
            data.Columns.Add("Des_servico", typeof(string));
            data.Rows.Add(1, "Restauração");
            data.Rows.Add(2, "Limpeza");
            data.Rows.Add(3, "Extração");
            data.Rows.Add(4, "Canal");

            return data;
        }

        public static bool validarRegEx(string email)
        {

            Regex regExpEmail = new Regex("^[A-Za-z0-9](([_.-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([.-]?[a-zA-Z0-9]+)*)([.][A-Za-z]{2,4})$");
            Match match = regExpEmail.Match(email);

            if (match.Success)
            return true;
            else
            return false;
        }

        public static bool ValidaCpf(string Cpf)
        {

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;

            int soma;
            int resto;

            Cpf = Cpf.Trim();
            Cpf = Cpf.Replace(".", "").Replace("-", "");

            if (Cpf.Length != 11)
            {
                return false;
            }
            tempCpf = Cpf.Substring(0, 9);

            soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * (multiplicador1[i]);
            }
            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            int soma2 = 0;

            for (int i = 0; i < 10; i++)
            {
                soma2 += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            }

            resto = soma2 % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = digito + resto.ToString();
            return Cpf.EndsWith(digito);
        }
    }
}
