using CaptaAvaliacao.Data;

namespace CaptaAvaliacao.Models
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int TipoCliente { get; set; }
        public string TipoClienteDesc { get; set; }
        public string Sexo { get; set; }
        public int SituacaoCliente { get; set; }
        public string SituacaoClienteDesc { get; set; }
        public List<Cliente> GetListCliente()
        {
            return (List<Cliente>)new ClienteData().ConvertToListModel();
        }
        public Cliente GetCliente()
        {
            return new ClienteData().GetCliente(this);
        }
        public string SetCliente()
        {
            Cliente cliente;
            if (string.IsNullOrEmpty(this.GetCliente().CPF))
            {
                try
                {
                    cliente = new ClienteData().InserirCliente(this);
                    return "Cliente cadastrado com sucesso";
                }
                catch(Exception ex)
                {
                    return ex.Message;
                }
            }
            else
            {
                try
                {
                    cliente = new ClienteData().AtualizarCliente(this);
                    return "Cliente atualizado com sucesso";
                }
                catch(Exception ex)
                {
                    return ex.Message;
                }
            }
        }
        public string DelCliente()
        {
            try
            {
                bool isDeleted = new ClienteData().DeletarCliente(this.CPF);
                if (isDeleted)
                {
                    return "Cliente deletado com sucesso.";
                }
                else
                {
                    return "Erro ao deletar cliente.";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
