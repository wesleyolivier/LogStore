using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizza.MinhaApi.Models.Entidades
{
    [Table("Pedidos")]
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }

        public DateTime DataHoraPedido { get; set; }

        public string EnderecoEntrega { get; set; }

        public int? ClienteId { get; set; }
        public virtual Cliente? Cliente { get; set; }

        public virtual List<Pizza> Pizzas { get; set; }

        public decimal ValorTotal { get; set; }
    }
}
