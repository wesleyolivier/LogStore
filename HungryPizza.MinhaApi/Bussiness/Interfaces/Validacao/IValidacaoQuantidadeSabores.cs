using HungryPizza.MinhaApi.Models.DTO;

namespace HungryPizza.MinhaApi.Bussiness.Interfaces.Validacao
{
    public interface IValidacaoQuantidadeSabores
    {
        bool Validar(List<PizzaDTO> pizzas);
    }
}
