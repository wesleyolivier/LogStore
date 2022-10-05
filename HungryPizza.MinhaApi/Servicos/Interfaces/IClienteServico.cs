using HungryPizza.MinhaApi.Models.DTO;
using HungryPizza.MinhaApi.Models.Entidades;
using static HungryPizza.MinhaApi.Servicos.Implementacoes.ClienteServico;

namespace HungryPizza.MinhaApi.Servicos.Interfaces
{
    public interface IClienteServico
    {
        Cliente RetornarPorCredenciais(string email, string senha);

        bool ValidarCredenciais(string email, string senha);

        bool ValidarPreenchimentoObjetoCliente(ClienteSolicitanteDTO clienteSolicitante);

        bool ValidarCredenciaisCasoInformada(ClienteSolicitanteDTO clienteSolicitante);

        DadosEntregaCliente RetornarDadosEntregaCliente(ClienteSolicitanteDTO cliente);
    }
}
