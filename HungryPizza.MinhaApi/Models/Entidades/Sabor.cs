using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizza.MinhaApi.Models.Entidades
{
    [Table("Sabores")]
    public class Sabor
    {
        [Key]
        public int SaborId { get; set; }
        public string Nome { get; set; }

        public decimal Preco { get; set; }
        public bool Disponivel { get; set; }

        public virtual List<PizzaSaborEscolhido> PizzaSabor { get; set; }
    }
}
