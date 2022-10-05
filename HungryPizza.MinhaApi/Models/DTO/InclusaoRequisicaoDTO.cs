namespace HungryPizza.MinhaApi.Models.DTO
{
    public class InclusaoRequisicaoDTO
    {
        public ClienteSolicitanteDTO Cliente { get; set; }
        public List<PizzaDTO> PizzasDesejadas { get; set; }
    }
}
