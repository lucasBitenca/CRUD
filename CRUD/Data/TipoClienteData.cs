using CaptaAvaliacao.Common;
using CaptaAvaliacao.Models;
using System.Data.SqlClient;

using System.Data;

namespace CaptaAvaliacao.Data
{
    public class TipoClienteData : IClienteData<TipoCliente>
    {
        public List<TipoCliente> ConvertToListModel()
        {
            List<TipoCliente> listaTpCliente = new List<TipoCliente>();
            string sql = "select ID, Descricao from tb_TipoCliente";
            DataTable retorno = ConnectionDB.ExecuteCommand(sql, CommandType.Text);
            foreach (DataRow dr in retorno.Rows)
            {
                TipoCliente tipoCliente = new TipoCliente();
                tipoCliente.Id = int.Parse(dr["ID"].ToString());
                tipoCliente.Descricao = dr["Descricao"].ToString();
                listaTpCliente.Add(tipoCliente);
            }
            return listaTpCliente;
        }
    }
}
