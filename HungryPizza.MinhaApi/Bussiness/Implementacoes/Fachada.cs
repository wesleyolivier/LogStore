using HungryPizza.MinhaApi.Bussiness.Interfaces;
using HungryPizza.MinhaApi.Models.DTO;
using HungryPizza.MinhaApi.Models.Entidades;
using HungryPizza.MinhaApi.Servicos.Interfaces;

namespace HungryPizza.MinhaApi.Bussiness.Implementacoes
{
    public class Fachada : IFachada
    {
        #region Atributos
        
        private readonly IClienteServico _clienteServico;
        private readonly IPedidoServico _pedidoServico;
        private readonly IPizzaServico _pizzaServico;
        private readonly ISaborServico _saborServico;

        #endregion Atributos

        #region Construtor
        public Fachada( IClienteServico clienteServico,
                        IPedidoServico pedidoServico,
                        IPizzaServico pizzaServico,
                        ISaborServico saborServico)
        {            
            _clienteServico = clienteServico;
            _pedidoServico = pedidoServico;
            _pizzaServico = pizzaServico;
            _saborServico = saborServico;
        }

        #endregion

        #region Métodos Públicos

        public InclusaoResponseDTO IncluirPedido(ClienteSolicitanteDTO cliente, List<PizzaDTO> pizzasDesejadas)
        {
            try
            {

                #region Validações

                if (!_clienteServico.ValidarPreenchimentoObjetoCliente(cliente))
                    return new InclusaoResponseDTO { Mensagem = "Preenchimento incorreto, insira Email e senha ou Endereço de entrega caso queira fazer pedido de forma anônima." };

                if (!_clienteServico.ValidarCredenciaisCasoInformada(cliente))
                    return new InclusaoResponseDTO { Mensagem = "Cliente não encontrado ou credenciais incorretas" };

                if (!_pizzaServico.ValidaQuantidadePizzas(pizzasDesejadas))
                    return new InclusaoResponseDTO { Mensagem = "Quantidade de pizzas não aceita. Escolha de 1 até 10." };

                if (!_pizzaServico.ValidaQuantidadeSabores(pizzasDesejadas))
                    return new InclusaoResponseDTO { Mensagem = "Quantidade de sabores não aceito. Escolha de 1 até 2." };

                var respostaSabores = _pizzaServico.ValidarDisponibilidadeSabores(pizzasDesejadas.SelectMany(p => p.Sabores).ToList());
                if (respostaSabores.Indisponiveis)
                    return new InclusaoResponseDTO { Mensagem = $"Sabore(s) indisponíveis: {respostaSabores.Mensagem}" };

                #endregion Validações

                #region Negócio / Alma da API

                var pedidoSalvo = _pedidoServico.CriarPedidoCompleto(pizzasDesejadas, cliente);

                #endregion Negócio / Alma da API                

                return new InclusaoResponseDTO { NumeroDoPedido = pedidoSalvo.PedidoId, Mensagem = "Aguarde, em breve entregaremos." };
            }
            catch (Exception ex)
            {
                return new InclusaoResponseDTO { Mensagem = $"Erro: {ex.ToString()}" };
            }
        }

        public PedidosResponseDTO RetornarPedidoDoCliente(ConsultaRequisicaoDTO consulta)
        {
            if (!_clienteServico.ValidarCredenciais(consulta.Email, consulta.Senha))
                return new PedidosResponseDTO { MensagemErro = "Credenciais incorretas ou Cliente não cadastrado" };

            var pedidosResponse = new PedidosResponseDTO();

            var clienteRetornadoDoBanco = _clienteServico.RetornarPorCredenciais(consulta.Email, consulta.Senha);

            var pedidosEncontrados = _pedidoServico.RetornarPedidosPorCliente(clienteRetornadoDoBanco, consulta.OrdemCrescente);           

            return pedidosEncontrados;
        }

        public List<Sabor> RetornarSabores() 
        {
            return _saborServico.RetornarTodos();
        }

        #endregion Métodos Públicos
    }
}
