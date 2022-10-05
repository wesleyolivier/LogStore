using HungryPizza.MinhaApi.Bussiness.Interfaces.Validacao;
using HungryPizza.MinhaApi.Data.Interfaces;

namespace HungryPizza.MinhaApi.Bussiness.Implementacoes.Validacao
{
    public class ValidacaoDisponibilidadeSabores : IValidacaoDisponibilidadeSabores
    {
        private readonly ISaborRepositorio _saborRepositorio;

        public ValidacaoDisponibilidadeSabores(ISaborRepositorio saborRepositorio)
        {
            _saborRepositorio = saborRepositorio;
        }

        public RespostaDisponibilidaeSabores Validar(List<int> sabores)
        {
            string mensagem = string.Empty;
            bool todosDisponiveis = true;

            sabores.ForEach(s =>
            {
                var saborVindoDoBanco = _saborRepositorio.RetornarPorId(s);

                if (!saborVindoDoBanco.Disponivel)
                {
                    mensagem += saborVindoDoBanco.Nome + ";";
                    todosDisponiveis = false;
                }
            });

            return new RespostaDisponibilidaeSabores
            {
                Indisponiveis = !todosDisponiveis,
                Mensagem = mensagem
            };
        }

        public class RespostaDisponibilidaeSabores
        {
            public bool Indisponiveis { get; set; }
            public string Mensagem { get; set; }
        }
    }
}
