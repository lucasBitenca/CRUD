using CaptaAvaliacao.Models;

namespace CaptaAvaliacao.ViewModel
{
    public class CadastroCliente
    {
        public Cliente cliente {  get; set; }
        public List<TipoCliente> tpCliente { get; set; }
        public List<SituacaoCliente> situacaoClientes { get; set; }

        public CadastroCliente() {
            tpCliente = new TipoCliente().GetListTipoCliente();
            situacaoClientes = new SituacaoCliente().GetListSituacaoCliente();
        }
    }
}
