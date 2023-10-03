namespace CaptaAvaliacao.Data
{
    /*
     * Criação de uma interface que leve em consideração o tipo de objeto que a manipula
     * A implementação da interface garante que todas as classes de nível Data entreguem
     *  uma lista do tipo de objeto compatível com o Model.
     */
    public interface IClienteData<T>
    {
        /*
         * Determinação do método e tipo de dados que todas as classes, que importam a interface, devem implementar
         */
        List<T> ConvertToListModel();
    }
}
