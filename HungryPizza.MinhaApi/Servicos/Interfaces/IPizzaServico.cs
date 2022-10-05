using HungryPizza.MinhaApi.Models.DTO;
using static HungryPizza.MinhaApi.Bussiness.Implementacoes.Validacao.ValidacaoDisponibilidadeSabores;

namespace HungryPizza.MinhaApi.Servicos.Interfaces
{
    public interface IPizzaServico
    {
        bool ValidaQuantidadePizzas(List<PizzaDTO> pizzas);
        bool ValidaQuantidadeSabores(List<PizzaDTO> pizzas);

        RespostaDisponibilidaeSabores ValidarDisponibilidadeSabores(List<int> sabores);
    }
}
