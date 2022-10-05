using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HungryPizza.MinhaApi.Models.Entidades
{
    [Table("PizzaSaboresEscolhidos")]
    public class PizzaSaborEscolhido
    {
        [Key]
        public int PizzaSaborEscolhidoId { get; set; }
        public int PizzaId { get; set; }
        public virtual Pizza Pizza { get; set; }

        public int SaborId { get; set; }
        public virtual Sabor Sabor { get; set; }
    }
}
