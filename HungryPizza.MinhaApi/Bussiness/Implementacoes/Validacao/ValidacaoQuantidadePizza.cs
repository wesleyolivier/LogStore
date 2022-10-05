using HungryPizza.MinhaApi.Bussiness.Interfaces;
using HungryPizza.MinhaApi.Bussiness.Interfaces.Validacao;
using HungryPizza.MinhaApi.Models.DTO;

namespace HungryPizza.MinhaApi.Bussiness.Implementacoes.Validacao
{
    public class ValidacaoQuantidadePizza : IValidacaoQuantidadePizza
    {
        public bool Validar(List<PizzaDTO> pizzas)
        {
            return pizzas?.Count() > 0 && pizzas?.Count() <= 10;
        }
    }
}
