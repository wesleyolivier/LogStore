using HungryPizza.MinhaApi.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace HungryPizza.MinhaApi.Context
{
    public class MeuAppDbContext : DbContext
    {
        public MeuAppDbContext(DbContextOptions<MeuAppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)// Crée la migration
        {
            modelBuilder.Entity<Sabor>().Property(p => p.Preco).HasColumnType("decimal(18,2)");

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Sabor> Sabores { get; set; }
        public DbSet<PizzaSaborEscolhido> PizzaSabores { get; set; }
    }
}
