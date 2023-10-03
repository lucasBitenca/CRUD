using CaptaAvaliacao.Common;
using CaptaAvaliacao.Models;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace CaptaAvaliacao.Data
{
    public class ClienteData : IClienteData<Cliente>
    {
        public List<Cliente> ConvertToListModel()
        {
            List<Cliente> listaCliente = new List<Cliente>();
            string sql = @"select Nome, CPF, TipoCliente.Descricao [TipoClienteDesc], Sexo, SituacaoCliente.Descricao [SituacaoClienteDesc] from tb_Cliente cliente
                                inner join tb_TipoCliente tipoCliente on tipoCliente.ID = cliente.TipoCliente
                                inner join tb_SituacaoCliente situacaoCliente on situacaoCliente.ID = cliente.SituacaoCliente";
            DataTable retorno = ConnectionDB.ExecuteCommand(sql, CommandType.Text);
            foreach (DataRow dr in retorno.Rows)
            {
                listaCliente.Add(PopularCliente(dr));
            }
            return listaCliente;
        }
        public Cliente GetCliente(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.CPF))
            {
                return new Cliente();
            }
            else
            {
                string sql = String.Format("select Nome, CPF, TipoCliente, Sexo, SituacaoCliente from tb_Cliente where CPF = @cpf");
                SqlParameter[] parametros = new SqlParameter[] {
                    new SqlParameter("@cpf", cliente.CPF)
                };
                DataTable retorno = ConnectionDB.ExecuteCommand(sql, CommandType.Text, parametros);
                if(retorno.Rows.Count > 0)
                {
                    return PopularCliente(retorno.Rows[0]);
                }
                else
                {
                    return new Cliente();
                }
            }
        }
        public Cliente InserirCliente(Cliente cliente)
        {
            string sql = "sp_InsertCliente";
            return PopularCliente(ManipularCliente(sql, cliente));

        }
        public Cliente AtualizarCliente(Cliente cliente)
        {
            string sql = "sp_UpdateCliente";
            return PopularCliente(ManipularCliente(sql, cliente));
        }
        public bool DeletarCliente(string cpf)
        {
            string sql = "sp_DeleteCliente";
            Cliente cliente = new Cliente();
            cliente.CPF = cpf;
            return ManipularCliente(sql, cliente.CPF) == null ? false : true;
        }
        public DataRow? ManipularCliente(string sql, Cliente cliente)
        {
            SqlParameter[] parametros = new SqlParameter[] {
                new SqlParameter("@nome", cliente.Nome),
                new SqlParameter("@cpf", cliente.CPF),
                new SqlParameter("@tipoCliente", cliente.TipoCliente),
                new SqlParameter("@sexo", cliente.Sexo),
                new SqlParameter("@situacaoCliente", cliente.SituacaoCliente)
            };
            DataTable retorno = ConnectionDB.ExecuteCommand(sql, CommandType.StoredProcedure, parametros);
            return retorno.Rows.Count > 0 ? retorno.Rows[0] : null;
        }
        public DataRow? ManipularCliente(string sql, string cpf)
        {
            SqlParameter[] parametros = new SqlParameter[] {
                new SqlParameter("cpf", cpf)
            };
            DataTable retorno = ConnectionDB.ExecuteCommand(sql, CommandType.StoredProcedure, parametros);
            return retorno.Rows.Count > 0 ? retorno.Rows[0] : null;
        }
        private Cliente PopularCliente(DataRow? dr)
        {
            if(dr == null)
            {
                return new Cliente();
            }
            else
            {
                Cliente cliente = new Cliente();
                cliente.Nome = dr.Table.Columns.Contains("Nome") ? dr["Nome"].ToString() : null;
                cliente.CPF = dr.Table.Columns.Contains("CPF") ? dr["CPF"].ToString() : null;
                cliente.TipoClienteDesc = dr.Table.Columns.Contains("TipoClienteDesc") ? dr["TipoClienteDesc"].ToString() : null;
                cliente.TipoCliente = dr.Table.Columns.Contains("TipoCliente") ? int.Parse(dr["TipoCliente"].ToString()) : -1;
                cliente.Sexo = dr.Table.Columns.Contains("Sexo") ? dr["Sexo"].ToString() : null;
                cliente.SituacaoClienteDesc = dr.Table.Columns.Contains("SituacaoClienteDesc") ? dr["SituacaoClienteDesc"].ToString() : null;
                cliente.SituacaoCliente = dr.Table.Columns.Contains("SituacaoCliente") ? int.Parse(dr["SituacaoCliente"].ToString()) : -1;
                return cliente;
            }
        }
    }
}
