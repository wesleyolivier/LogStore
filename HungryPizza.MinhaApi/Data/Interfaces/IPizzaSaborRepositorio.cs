using HungryPizza.MinhaApi.Models.Entidades;

namespace HungryPizza.MinhaApi.Data.Interfaces
{
    public interface IPizzaSaborRepositorio
    {
        PizzaSaborEscolhido Salvar(PizzaSaborEscolhido pizzaSabor);

        IEnumerable<PizzaSaborEscolhido> RetornarPorPizzaId(int pizzaId);

        PizzaSaborEscolhido RetornarPorId(int id);
    }
}
