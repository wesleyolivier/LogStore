using HungryPizza.MinhaApi.Models.DTO;

namespace HungryPizza.MinhaApi.Bussiness.Interfaces.Validacao
{
    public interface IValidacaoQuantidadePizza
    {
        bool Validar(List<PizzaDTO> pizzas);
    }
}
