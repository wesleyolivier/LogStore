using System.ComponentModel;

namespace HungryPizza.MinhaApi.Models.DTO
{
    public class ConsultaRequisicaoDTO
    {
        [DefaultValue("w@w.com")]
        public string Email { get; set; }

        [DefaultValue("123")]
        public string Senha { get; set; }

        [DefaultValue("False")]
        public bool OrdemCrescente { get; set; } = false;
    }
}
