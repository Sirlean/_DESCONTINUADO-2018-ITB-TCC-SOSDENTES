using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SosDentes.BD
{
    class clnBancoDados
    {
        public static SqlConnection AbreBanco()
        {
            string StringConexao = "Data Source=DESKTOP-BN49EH2\\SQLEXPRESS;Initial Catalog=SOS_DENTES;Integrated Security=True";
            
            try
            {
                SqlConnection conn = new SqlConnection(StringConexao);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void FechaBanco(SqlConnection conn)
        {
            try
            {
                if(conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable RetornaTabela(string strQuery)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmdComando = new SqlCommand(strQuery, AbreBanco());
                SqlDataAdapter da = new SqlDataAdapter(cmdComando);
                da.Fill(dt);
                return dt;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro na pesquisa da Tabela" + erro.Message);
            }
            finally
            {
                FechaBanco(AbreBanco());
            }
        }
        public SqlDataReader RetornaLinha(string strQuery)
        {
            try
            {
                SqlDataReader dr;
                SqlCommand sqlComando = new SqlCommand(strQuery, AbreBanco());
                dr = sqlComando.ExecuteReader();
                return dr;
            }
            catch (Exception e)
            {
                throw e;
                throw new Exception("Mensagem");
            }
        }
        public void ExecutaComando(string strQuery)
        {
            try
            {
                SqlCommand sqlComm = new SqlCommand(strQuery, AbreBanco());
                sqlComm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally {
                FechaBanco(AbreBanco());
            }
        }
    }
}
