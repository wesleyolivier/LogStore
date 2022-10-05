using HungryPizza.MinhaApi.Models.DTO;
using HungryPizza.MinhaApi.Models.Entidades;

namespace HungryPizza.MinhaApi.Servicos.Interfaces
{
    public interface IPedidoServico
    {
        PedidosResponseDTO RetornarPedidosPorCliente(Cliente cliente, bool crescente = false);

        decimal CalcularValorTotalDoPedido(List<PizzaDTO> pizzas);

        Pedido CriarPedidoCompleto(List<PizzaDTO> pizzasPromessa, ClienteSolicitanteDTO clienteSolicitante);
    }
}
