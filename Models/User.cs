using PI.BackEnd.API.Models;

namespace PI.BackEnd.API.Models
{
    public class User
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string? Ocupacao { get; set; }
        
    }
}
