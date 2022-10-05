using HungryPizza.MinhaApi.Context;
using HungryPizza.MinhaApi.Data.Interfaces;
using HungryPizza.MinhaApi.Models.Entidades;

namespace HungryPizza.MinhaApi.Data.Implementacoes
{
    public class PizzaSaborRepositorio : IPizzaSaborRepositorio
    {
        private readonly MeuAppDbContext _banco;

        public PizzaSaborRepositorio(MeuAppDbContext banco)
        {
            _banco = banco;
        }

        public PizzaSaborEscolhido Salvar(PizzaSaborEscolhido pizzaSabor)
        {
            _banco.PizzaSabores.Add(pizzaSabor);
            _banco.SaveChanges();
            return pizzaSabor;
        }

        public IEnumerable<PizzaSaborEscolhido> RetornarPorPizzaId(int pizzaId)
        {
            return _banco.PizzaSabores.Where(p => p.PizzaId == pizzaId);            
        }

        public PizzaSaborEscolhido RetornarPorId(int id)
        {
            return _banco.PizzaSabores.FirstOrDefault(p => p.PizzaSaborEscolhidoId == id);
        }
    }
}
