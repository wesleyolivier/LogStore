using HungryPizza.MinhaApi.Bussiness.Interfaces.Validacao;
using HungryPizza.MinhaApi.Models.DTO;
using HungryPizza.MinhaApi.Servicos.Interfaces;
using static HungryPizza.MinhaApi.Bussiness.Implementacoes.Validacao.ValidacaoDisponibilidadeSabores;

namespace HungryPizza.MinhaApi.Servicos.Implementacoes
{
    public class PizzaServico : IPizzaServico
    {
        private readonly IValidacaoQuantidadePizza _validacaoQuantidadePizza;
        private readonly IValidacaoQuantidadeSabores _validacaoQuantidadeSabores;
        private readonly IValidacaoDisponibilidadeSabores _validacaoDisponibilidadeSabores;

        public PizzaServico(IValidacaoQuantidadePizza validacaoQuantidadePizza,
                            IValidacaoQuantidadeSabores validacaoQuantidadeSabores,
                            IValidacaoDisponibilidadeSabores validacaoDisponibilidadeSabores)
        {
            _validacaoQuantidadePizza = validacaoQuantidadePizza;
            _validacaoQuantidadeSabores = validacaoQuantidadeSabores;
            _validacaoDisponibilidadeSabores = validacaoDisponibilidadeSabores;
        }

        public bool ValidaQuantidadePizzas(List<PizzaDTO> pizzas)
        {
            return _validacaoQuantidadePizza.Validar(pizzas);
        }

        public bool ValidaQuantidadeSabores(List<PizzaDTO> pizzas)
        {
            return _validacaoQuantidadeSabores.Validar(pizzas);
        }

        public RespostaDisponibilidaeSabores ValidarDisponibilidadeSabores(List<int> sabores) 
        {
            return _validacaoDisponibilidadeSabores.Validar(sabores);
        }        
    }
}
