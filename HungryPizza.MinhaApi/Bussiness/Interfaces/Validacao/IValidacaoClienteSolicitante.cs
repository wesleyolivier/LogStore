using HungryPizza.MinhaApi.Models.DTO;

namespace HungryPizza.MinhaApi.Bussiness.Interfaces.Validacao
{
    public interface IValidacaoClienteSolicitante
    {
        bool Validar(ClienteSolicitanteDTO clienteSolicitante);
    }
}
