namespace HungryPizza.MinhaApi.Models.DTO
{
    public class PedidosResponseDTO 
    {
        public string MensagemErro { get; set; }

        public List<PedidoResponseDTO> Pedidos { get; set; } = new List<PedidoResponseDTO>();
    }
}
