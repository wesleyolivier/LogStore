using HungryPizza.MinhaApi.Models.Entidades;

namespace HungryPizza.MinhaApi.Data.Interfaces
{
    public interface IPedidoRepositorio
    {
        Pedido RetornarPorId(int id);
        IEnumerable<Pedido> RetornarTodos();

        IEnumerable<Pedido> RetornarPorCliente(int idCliente);

        Pedido Salvar(Pedido pedido);
    }
}
