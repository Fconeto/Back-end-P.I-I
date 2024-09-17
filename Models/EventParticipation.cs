using PI.BackEnd.API.Models;

namespace PI.BackEnd.API.Models
{
    public class EventParticipation
    {
        public int? Id { get; set; }
        public int? EventId { get; set; }
        public int? UserId { get; set; }
    }
}
