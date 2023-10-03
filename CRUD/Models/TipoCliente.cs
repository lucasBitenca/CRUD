using CaptaAvaliacao.Data;

namespace CaptaAvaliacao.Models
{
    public class TipoCliente
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public List<TipoCliente> GetListTipoCliente()
        {
            return (List<TipoCliente>)new TipoClienteData().ConvertToListModel();
        }
    }
}
