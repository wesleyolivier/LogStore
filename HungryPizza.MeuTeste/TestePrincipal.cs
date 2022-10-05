using Xunit.Sdk;

namespace HungryPizza.MeuTeste
{
    [TestClass]
    public class TestePrincipal
    {
        [TestMethod]
        public void TesteValidacaoObjetoUsuarioApto()
        {
            var cliente = new HungryPizza.MinhaApi.Models.DTO.ClienteSolicitanteDTO { Email = "w@w.com", Senha = "123" };
            var validacao = new HungryPizza.MinhaApi.Bussiness.Implementacoes.Validacao.ValidacaoClienteSolicitante();
            Assert.IsTrue(validacao.Validar(cliente));
        }

        [TestMethod]
        public void TesteValidacaoObjetoUsuarioInapto()
        {
            var cliente = new HungryPizza.MinhaApi.Models.DTO.ClienteSolicitanteDTO { Email = "", Senha = "123" };
            var validacao = new HungryPizza.MinhaApi.Bussiness.Implementacoes.Validacao.ValidacaoClienteSolicitante();
            Assert.IsFalse(validacao.Validar(cliente));
        }
    }
}