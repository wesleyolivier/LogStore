using HungryPizza.MinhaApi.Context;
using HungryPizza.MinhaApi.Data.Interfaces;
using HungryPizza.MinhaApi.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace HungryPizza.MinhaApi.Data.Implementacoes
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly MeuAppDbContext _banco;

        public PedidoRepositorio(MeuAppDbContext banco)
        {
            _banco = banco;
        }

        public IEnumerable<Pedido> RetornarPorCliente(int idCliente)
        {
            return _banco.Pedidos.Include(p => p.Pizzas).Where(p => p.ClienteId == idCliente).OrderByDescending(pp => pp.DataHoraPedido);
        }

        public Pedido RetornarPorId(int id)
        {
            return _banco.Pedidos.Include(p => p.Cliente).FirstOrDefault(p => p.PedidoId == id);
        }

        public IEnumerable<Pedido> RetornarTodos()
        {
            return _banco.Pedidos;
        }

        public Pedido Salvar(Pedido pedido)
        {
            _banco.Pedidos.Add(pedido);
            _banco.SaveChanges();
            return pedido;
        }
    }
}
