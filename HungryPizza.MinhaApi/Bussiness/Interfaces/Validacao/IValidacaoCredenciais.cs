using HungryPizza.MinhaApi.Models;
using HungryPizza.MinhaApi.Models.DTO;

namespace HungryPizza.MinhaApi.Bussiness.Interfaces.Validacao
{
    public interface IValidacaoCredenciais
    {
        bool Validar(ClienteSolicitanteDTO clienteSolicitante);
    }
}
