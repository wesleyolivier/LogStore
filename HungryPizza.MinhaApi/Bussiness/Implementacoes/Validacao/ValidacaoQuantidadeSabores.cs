using HungryPizza.MinhaApi.Bussiness.Interfaces;
using HungryPizza.MinhaApi.Bussiness.Interfaces.Validacao;
using HungryPizza.MinhaApi.Models.DTO;

namespace HungryPizza.MinhaApi.Bussiness.Implementacoes.Validacao
{
    public class ValidacaoQuantidadeSabores : IValidacaoQuantidadeSabores
    {        
        public bool Validar(List<PizzaDTO> pizzas)
        {
            bool quantidadeSaboresOk = true;

            pizzas.ForEach(pd =>
            {
                if (pd.Sabores.Count < 1 || pd.Sabores.Count > 2)
                {
                    quantidadeSaboresOk = false;
                    return;
                }
            });

            return quantidadeSaboresOk;
        }
    }
}
