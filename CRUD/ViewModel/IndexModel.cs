using CaptaAvaliacao.Models;

namespace CaptaAvaliacao.ViewModel
{
    public class IndexModel
    {
        public Cliente Cliente { get; set; }
        public string msgRetorno { get; set; }
        public IndexModel()
        {
            Cliente = new Cliente();
            msgRetorno = string.Empty;
        }
    }
}
