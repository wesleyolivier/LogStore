using HungryPizza.MinhaApi.Data.Implementacoes;
using HungryPizza.MinhaApi.Data.Interfaces;
using HungryPizza.MinhaApi.Models;
using HungryPizza.MinhaApi.Models.DTO;
using HungryPizza.MinhaApi.Models.Entidades;
using HungryPizza.MinhaApi.Servicos.Interfaces;

namespace HungryPizza.MinhaApi.Servicos.Implementacoes
{
    public class PedidoServico : IPedidoServico
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;
        private readonly ISaborRepositorio _saborRepositorio;
        private readonly IPizzaRepositorio _pizzaRepositorio;
        private readonly IPizzaSaborRepositorio _pizzaSaborRepositorio;
        private readonly IClienteServico _clienteServico;

        public PedidoServico(IPedidoRepositorio pedidoRepositorio,
                            ISaborRepositorio saborRepositorio,
                            IPizzaRepositorio pizzaRepositorio,
                            IPizzaSaborRepositorio pizzaSaborRepositorio,
                            IClienteServico clienteServico)
        {
            _pedidoRepositorio = pedidoRepositorio;
            _saborRepositorio = saborRepositorio;
            _pizzaRepositorio = pizzaRepositorio;
            _pizzaSaborRepositorio = pizzaSaborRepositorio;
            _clienteServico = clienteServico;
        }

        public decimal CalcularValorTotalDoPedido(List<PizzaDTO> pizzas)
        {
            decimal valorTotal = 0;
            pizzas.ForEach(pd =>
            {
                decimal precoSabor1 = _saborRepositorio.RetornarPorId(pd.Sabores[0]).Preco;

                valorTotal += pd.Sabores.Count == 1 ? precoSabor1 : (precoSabor1 + _saborRepositorio.RetornarPorId(pd.Sabores[1]).Preco) / 2;
            });

            return valorTotal;
        }

        public PedidosResponseDTO RetornarPedidosPorCliente(Cliente cliente, bool crescente = false)
        {
            var pedidosResponseDTO = new PedidosResponseDTO();

            var pedidosEncontrados = _pedidoRepositorio.RetornarPorCliente(cliente.ClienteId);
            var ordenado = crescente ? pedidosEncontrados?.OrderBy(a => a.DataHoraPedido) : pedidosEncontrados?.OrderByDescending(a => a.DataHoraPedido);

            foreach (var pedido in ordenado)
            {
                var pedidoResponse = new PedidoResponseDTO();

                pedidoResponse.NumeroPedido = pedido.PedidoId;
                pedidoResponse.QuantidadePizzas = pedido.Pizzas.Count;
                pedidoResponse.Email = pedido?.Cliente?.Email;
                pedidoResponse.Senha = "***";
                pedidoResponse.EnderecoParaEntrega = pedido?.EnderecoEntrega;
                pedidoResponse.HorarioSolicitacao = pedido.DataHoraPedido;
                pedidoResponse.ValorTotalDoPedido = pedido.ValorTotal;                

                pedidosResponseDTO.Pedidos.Add(pedidoResponse);
            }

            return pedidosResponseDTO;
        }

        public Pedido CriarPedidoCompleto(List<PizzaDTO> pizzasPromessa, ClienteSolicitanteDTO clienteSolicitante) 
        {
            var dadosEntrega = _clienteServico.RetornarDadosEntregaCliente(clienteSolicitante);

            var pedidoPromessa =
                new Pedido
                {
                    ClienteId = dadosEntrega.IdCliente,
                    EnderecoEntrega = dadosEntrega.EnderecoEntrega,
                    DataHoraPedido = DateTime.Now,
                    ValorTotal = CalcularValorTotalDoPedido(pizzasPromessa)
                };

            var pedidoSalvo = _pedidoRepositorio.Salvar(pedidoPromessa);

            foreach (var pizza in pizzasPromessa)
            {
                int idPizza = _pizzaRepositorio.Salvar(new Pizza { PedidoId = pedidoSalvo.PedidoId }).PizzaId;

                foreach (var codigoSabor in pizza.Sabores)
                {
                    _pizzaSaborRepositorio.Salvar(new PizzaSaborEscolhido { PizzaId = idPizza, SaborId = codigoSabor });
                }
            }

            return pedidoSalvo;
        }
    }
}
