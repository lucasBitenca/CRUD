using CaptaAvaliacao.Common;
using CaptaAvaliacao.Models;
using System.Data;
using System.Data.SqlClient;

namespace CaptaAvaliacao.Data
{
    public class SituacaoClienteData : IClienteData<SituacaoCliente>
    {
        public List<SituacaoCliente> ConvertToListModel()
        {
            List<SituacaoCliente> listaSituacao = new List<SituacaoCliente>();
            string sql = "select ID, Descricao from tb_SituacaoCliente";
            DataTable retorno = ConnectionDB.ExecuteCommand(sql, CommandType.Text);
            foreach(DataRow dr in retorno.Rows)
            {
                SituacaoCliente situacaoCliente = new SituacaoCliente();
                situacaoCliente.Id = int.Parse(dr["ID"].ToString());
                situacaoCliente.Descricao = dr["Descricao"].ToString();
                listaSituacao.Add(situacaoCliente);
            }
            return listaSituacao;
        }
    }
}
