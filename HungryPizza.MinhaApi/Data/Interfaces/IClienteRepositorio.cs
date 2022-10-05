using HungryPizza.MinhaApi.Models.Entidades;

namespace HungryPizza.MinhaApi.Data.Interfaces
{
    public interface IClienteRepositorio
    {
        Cliente Retornar(string email, string senha);
    }
}
