using Microsoft.EntityFrameworkCore;
using PI.BackEnd.API.Data;
using PI.BackEnd.API.Models;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PI.BackEnd.API.Services
{
    public class EventService
    {
        private readonly ApplicationDbContext _context;

        public EventService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateEvent(Event newEvent)
        {
            if (await _context.Event.AnyAsync(u => u.Data == newEvent.Data && u.HoraInicio == newEvent.HoraInicio && u.Localizacao == newEvent.Localizacao))
                return false;
            _context.Event.Add(newEvent);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Event>> GetEvents()
        {
            return await _context.Event.ToListAsync();
        }


    }
}
