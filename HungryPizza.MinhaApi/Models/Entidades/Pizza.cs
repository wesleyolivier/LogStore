using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizza.MinhaApi.Models.Entidades
{
    [Table("Pizzas")]
    public class Pizza
    {
        [Key]
        public int PizzaId { get; set; }

        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }

        public virtual List<PizzaSaborEscolhido> Sabores { get; set; }
    }
}
