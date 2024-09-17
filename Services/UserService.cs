using PI.BackEnd.API.Data;
using PI.BackEnd.API.Models;
using Microsoft.EntityFrameworkCore;

namespace PI.BackEnd.API.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAndPassword(string email, string password)
        {
            return await _context.User
                .FirstOrDefaultAsync(u => u.Email == email && u.Senha == password);
        }

        public async Task<bool> CreateUser(User newUser)
        {
            if (await _context.User.AnyAsync(u => u.Email == newUser.Email))
                return false;

            _context.User.Add(newUser);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RegisterEvent(EventParticipation newParticipation)
        {
            if (await _context.User.AnyAsync(u => u.Id == newParticipation.UserId))
            {
                if (await _context.Event.AnyAsync(u => u.Id == newParticipation.EventId))
                {
                    Event evento = await _context.Event.FirstOrDefaultAsync(u => u.Id == newParticipation.EventId);
                    int vagasPreenchidas = await _context.EventParticipation.CountAsync(u => u.EventId == evento.Id);
                    if (vagasPreenchidas <= evento.Vagas)
                    {
                        _context.EventParticipation.Add(newParticipation);
                        await _context.SaveChangesAsync();
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
