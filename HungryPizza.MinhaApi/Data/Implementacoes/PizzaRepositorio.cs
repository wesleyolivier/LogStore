using HungryPizza.MinhaApi.Context;
using HungryPizza.MinhaApi.Data.Interfaces;
using HungryPizza.MinhaApi.Models.Entidades;

namespace HungryPizza.MinhaApi.Data.Implementacoes
{
    public class PizzaRepositorio : IPizzaRepositorio
    {
        private readonly MeuAppDbContext _banco;

        public PizzaRepositorio(MeuAppDbContext banco)
        {
            _banco = banco;
        }

        public Pizza Salvar(Pizza pizza)
        {
            _banco.Pizzas.Add(pizza);
            _banco.SaveChanges();
            return pizza;
        }
    }
}
