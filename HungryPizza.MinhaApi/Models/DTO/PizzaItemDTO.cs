namespace HungryPizza.MinhaApi.Models.DTO
{
    public class PizzaItemDTO
    {
        public decimal CalcularValor()
        {
            return Sabores?.Count == 1 ? Sabores[0].PrecoUnitarioDoSabor : (Sabores[0].PrecoUnitarioDoSabor + Sabores[1].PrecoUnitarioDoSabor) / 2;
        }
        public List<SaborDetalheDTO> Sabores { get; set; } = new List<SaborDetalheDTO>();
    }
}
