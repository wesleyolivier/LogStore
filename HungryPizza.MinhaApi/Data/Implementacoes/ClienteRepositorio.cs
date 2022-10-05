using HungryPizza.MinhaApi.Context;
using HungryPizza.MinhaApi.Data.Interfaces;
using HungryPizza.MinhaApi.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace HungryPizza.MinhaApi.Data.Implementacoes
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly MeuAppDbContext _banco;

        public ClienteRepositorio(MeuAppDbContext banco)
        {
            _banco = banco;
        }

        public Cliente Retornar(string email, string senha)
        {
            return _banco.Clientes.FirstOrDefault(p => p.Email == email && p.Senha == senha);
        }        
    }
}
