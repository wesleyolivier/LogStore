using HungryPizza.MinhaApi.Bussiness.Interfaces;
using HungryPizza.MinhaApi.Bussiness.Interfaces.Validacao;
using HungryPizza.MinhaApi.Models.DTO;

namespace HungryPizza.MinhaApi.Bussiness.Implementacoes.Validacao
{
    public class ValidacaoClienteSolicitante : IValidacaoClienteSolicitante
    {
        public bool Validar(ClienteSolicitanteDTO clienteSolicitante)
        {
            return (!string.IsNullOrEmpty(clienteSolicitante.Email) && !string.IsNullOrEmpty(clienteSolicitante.Email)) || !string.IsNullOrEmpty(clienteSolicitante.EnderecoParaEntrega);                
        }
    }
}
