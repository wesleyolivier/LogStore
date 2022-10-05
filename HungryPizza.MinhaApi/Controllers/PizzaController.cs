using HungryPizza.MinhaApi.Bussiness.Interfaces;
using HungryPizza.MinhaApi.Models.DTO;
using HungryPizza.MinhaApi.Models.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace HungryPizza.MinhaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        #region Atributos

        private readonly IFachada _fachada;

        #endregion

        #region Construtor

        public PizzaController(IFachada fachada)
        {
            _fachada = fachada;
        }

        #endregion Construtor

        #region Métodos POST

        [HttpPost]
        [Route("CriarPedido")]
        public ActionResult<InclusaoResponseDTO> CriarPedidoClienteJaCadastrado([FromBody] InclusaoRequisicaoDTO requisicao)
        {
            return _fachada.IncluirPedido(requisicao.Cliente, requisicao.PizzasDesejadas);
        }

        #endregion Métodos POST

        #region Métodos GET

        [HttpGet]
        [Route("ListarPedidosPorUsuarioLogado")]
        public ActionResult<PedidosResponseDTO> ListarPedido([FromQuery] ConsultaRequisicaoDTO consulta)
        {
            return _fachada.RetornarPedidoDoCliente(consulta);
        }

        [HttpGet]
        [Route("ListarSabores")]
        public ActionResult<List<Sabor>> ListarSabores() 
        {
            return _fachada.RetornarSabores();
        }

        #endregion Métodos GET
    }
}
