using HungryPizza.MinhaApi.Models.Entidades;

namespace HungryPizza.MinhaApi.Data.Interfaces
{
    public interface ISaborRepositorio
    {
        Sabor RetornarPorId(int idSabor);

        IEnumerable<Sabor> RetornarTodos();
    }
}
