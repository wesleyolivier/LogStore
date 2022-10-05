using HungryPizza.MinhaApi.Context;
using HungryPizza.MinhaApi.Data.Interfaces;
using HungryPizza.MinhaApi.Models.Entidades;

namespace HungryPizza.MinhaApi.Data.Implementacoes
{
    public class SaborRepositorio : ISaborRepositorio
    {
        private readonly MeuAppDbContext _banco;

        public SaborRepositorio(MeuAppDbContext banco)
        {
            _banco = banco;
        }

        public Sabor RetornarPorId(int idSabor)
        {
            return _banco.Sabores.FirstOrDefault(s => s.SaborId == idSabor);
        }

        public IEnumerable<Sabor> RetornarTodos()
        {
            return _banco.Sabores;
        }


    }
}
