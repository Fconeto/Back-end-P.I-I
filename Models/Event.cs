using PI.BackEnd.API.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PI.BackEnd.API.Models
{
    public class Event
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public DateTime? Data { get; set; }
        public string? HoraInicio { get; set; }
        public string? HoraFim { get; set; }
        public string? Localizacao { get; set; }
        public int UserId { get; set; }
        public string? Descricao { get; set; }
        public int Vagas { get; set; }
    }
}
