using HungryPizza.MinhaApi.Models.DTO;
using static HungryPizza.MinhaApi.Bussiness.Implementacoes.Validacao.ValidacaoDisponibilidadeSabores;

namespace HungryPizza.MinhaApi.Bussiness.Interfaces.Validacao
{
    public interface IValidacaoDisponibilidadeSabores
    {
        RespostaDisponibilidaeSabores Validar(List<int> sabores);
    }
}
