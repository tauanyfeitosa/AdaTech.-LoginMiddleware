using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdaTech._LoginMiddleware.WebAPI.Models
{
    public class User
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public bool Is_ativo { get; set; }
        public bool Is_admin { get; set; }
        public bool Is_staff { get; set;}
        public bool Is_logado { get; set; }

    }
}
