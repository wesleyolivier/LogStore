using System.ComponentModel;

namespace HungryPizza.MinhaApi.Models.DTO
{
    public class ClienteSolicitanteDTO
    {
        [DefaultValue("w@w.com")]
        public string Email { get; set; }

        [DefaultValue("123")]
        public string Senha { get; set; }

        /// <summary>
        /// Deve ser preenchido caso seja usuário anônimo.
        /// </summary>
        [DefaultValue("")]
        public string? EnderecoParaEntrega { get; set; }
    }
}
