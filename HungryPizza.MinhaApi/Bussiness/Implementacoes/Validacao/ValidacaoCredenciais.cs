using HungryPizza.MinhaApi.Bussiness.Interfaces.Validacao;
using HungryPizza.MinhaApi.Data.Interfaces;
using HungryPizza.MinhaApi.Models.DTO;

namespace HungryPizza.MinhaApi.Bussiness.Implementacoes.Validacao
{
    public class ValidacaoCredenciais : IValidacaoCredenciais
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ValidacaoCredenciais(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }
        
        public bool Validar(ClienteSolicitanteDTO clienteSolicitante)
        {
            return _clienteRepositorio.Retornar(clienteSolicitante.Email, clienteSolicitante.Senha) != null;
        }
    }
}
