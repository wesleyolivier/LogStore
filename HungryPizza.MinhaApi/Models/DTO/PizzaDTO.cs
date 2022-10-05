using System.ComponentModel;

namespace HungryPizza.MinhaApi.Models.DTO
{
    public class PizzaDTO
    {
        [DefaultValue("[1,2,3]")]
        public List<int> Sabores { get; set; } = new List<int>();        
    }
}
