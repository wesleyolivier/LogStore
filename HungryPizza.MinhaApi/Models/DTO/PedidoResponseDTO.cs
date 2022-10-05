namespace HungryPizza.MinhaApi.Models.DTO
{
    public class PedidoResponseDTO : ClienteSolicitanteDTO
    {
        public DateTime HorarioSolicitacao { get; set; }
        public int NumeroPedido { get; set; }
        public int QuantidadePizzas { get; set; }

        public decimal ValorTotalDoPedido { get; set; }

        public List<PizzaItemDTO> PizzasDestePedido { get; set; } = new List<PizzaItemDTO>();
    }    
}
