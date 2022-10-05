using HungryPizza.MinhaApi.Data.Interfaces;
using HungryPizza.MinhaApi.Models.Entidades;
using HungryPizza.MinhaApi.Servicos.Interfaces;

namespace HungryPizza.MinhaApi.Servicos.Implementacoes
{
    public class SaborServico : ISaborServico
    {
        private readonly ISaborRepositorio _saborRepositorio;

        public SaborServico(ISaborRepositorio saborRepositorio)
        {
            _saborRepositorio = saborRepositorio;
        }
        
        public List<Sabor> RetornarTodos()
        {
            return _saborRepositorio.RetornarTodos()?.ToList();
        }
    }
}
