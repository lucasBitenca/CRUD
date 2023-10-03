using CaptaAvaliacao.Data;
namespace CaptaAvaliacao.Models
{
    public class SituacaoCliente
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public List<SituacaoCliente> GetListSituacaoCliente()
        {
            return (List<SituacaoCliente>)new SituacaoClienteData().ConvertToListModel();
        }

    }
}
