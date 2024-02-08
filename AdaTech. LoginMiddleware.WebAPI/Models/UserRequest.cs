using System.ComponentModel.DataAnnotations;

namespace AdaTech._LoginMiddleware.WebAPI.Models
{
    public class UserRequest
    {
        [Required]
        public string Senha { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}
