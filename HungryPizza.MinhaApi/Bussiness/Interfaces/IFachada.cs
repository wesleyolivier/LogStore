using HungryPizza.MinhaApi.Data.Interfaces;
using HungryPizza.MinhaApi.Models;
using HungryPizza.MinhaApi.Models.DTO;
using HungryPizza.MinhaApi.Models.Entidades;

namespace HungryPizza.MinhaApi.Bussiness.Interfaces
{
    public interface IFachada
    {
        InclusaoResponseDTO IncluirPedido(ClienteSolicitanteDTO cliente, List<PizzaDTO> pizzasDesejadas);

        PedidosResponseDTO RetornarPedidoDoCliente(ConsultaRequisicaoDTO consulta);

        List<Sabor> RetornarSabores();
    }
}
