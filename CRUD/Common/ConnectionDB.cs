using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;

namespace CaptaAvaliacao.Common
{
    public class ConnectionDB
    {
        /*
         Define a conexão com o banco de dados
         */
        private static SqlConnection GetConnection()
        {
            string conexao = String.Format("Data Source=LOCALHOST;Initial Catalog=db_ESTUDO;user id=sa;password=grespan123");
            SqlConnection justConnection = new SqlConnection(conexao);
            justConnection.Open();
            return justConnection;
        }
        /*
         * Método responsável por realizar as consultas no banco de dados
         * Seja um comando select, procedures ou functions
         */
        public static DataTable ExecuteCommand(string sql, CommandType tipoCMD, SqlParameter[]? parameters = null)
        {
            DataTable tabelaRetorno = new DataTable();
            using (SqlConnection conexao = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conexao))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    cmd.CommandType = tipoCMD;
                    SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                    adaptador.Fill(tabelaRetorno);
                    conexao.Close();
                }
            }
            return tabelaRetorno;
        }
    }
}
