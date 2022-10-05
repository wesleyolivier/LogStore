using HungryPizza.MinhaApi.Bussiness.Implementacoes.Validacao;
using HungryPizza.MinhaApi.Bussiness.Interfaces.Validacao;
using HungryPizza.MinhaApi.Data.Interfaces;
using HungryPizza.MinhaApi.Models.DTO;
using HungryPizza.MinhaApi.Models.Entidades;
using HungryPizza.MinhaApi.Servicos.Interfaces;

namespace HungryPizza.MinhaApi.Servicos.Implementacoes
{
    public class ClienteServico : IClienteServico
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IValidacaoClienteSolicitante _validacaoClienteSolicitante;
        private readonly IValidacaoCredenciais _validacaoCredenciais;

        public ClienteServico(IClienteRepositorio clienteRepositorio,
                            IValidacaoClienteSolicitante validacaoClienteSolicitante,
                            IValidacaoCredenciais validacaoCredenciais)
        {
            _clienteRepositorio = clienteRepositorio;
            _validacaoClienteSolicitante = validacaoClienteSolicitante;
            _validacaoCredenciais = validacaoCredenciais;
        }
        
        public Cliente RetornarPorCredenciais(string email, string senha)
        {
            return _clienteRepositorio.Retornar(email, senha);
        }

        public bool ValidarCredenciais(string email, string senha)
        {
            return _clienteRepositorio.Retornar(email, senha) != null;
        }

        public bool ValidarCredenciaisCasoInformada(ClienteSolicitanteDTO clienteSolicitante)
        {
            if(!string.IsNullOrEmpty(clienteSolicitante.EnderecoParaEntrega))
                return true;
            
            return _validacaoCredenciais.Validar(clienteSolicitante);
        }

        public bool ValidarPreenchimentoObjetoCliente(ClienteSolicitanteDTO clienteSolicitante)
        {
            return _validacaoClienteSolicitante.Validar(clienteSolicitante);
        }

        public DadosEntregaCliente RetornarDadosEntregaCliente(ClienteSolicitanteDTO cliente)
        {
            string enderecoEntrega;
            int? idCliente = default(int?);
            if (string.IsNullOrEmpty(cliente.EnderecoParaEntrega))//Considera usuário cadastrado
            {
                var clienteRetornadoDoBanco = _clienteRepositorio.Retornar(cliente.Email, cliente.Senha);
                idCliente = clienteRetornadoDoBanco.ClienteId;
                enderecoEntrega = clienteRetornadoDoBanco.Endereco;
            }
            else//Não considera usuário cadastrado e utiliza endereço fornecido
                enderecoEntrega = cliente.EnderecoParaEntrega;

            return new DadosEntregaCliente { IdCliente = idCliente, EnderecoEntrega = enderecoEntrega };
        }

        public class DadosEntregaCliente
        {
            public int? IdCliente { get; set; }
            public string EnderecoEntrega { get; set; }
        }
    }
}
