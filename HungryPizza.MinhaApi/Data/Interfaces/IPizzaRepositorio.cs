using HungryPizza.MinhaApi.Models.Entidades;

namespace HungryPizza.MinhaApi.Data.Interfaces
{
    public interface IPizzaRepositorio
    {
        Pizza Salvar(Pizza pizza);
    }
}
