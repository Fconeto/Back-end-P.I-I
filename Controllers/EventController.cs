using Microsoft.AspNetCore.Mvc;
using PI.BackEnd.API.Models;
using PI.BackEnd.API.Services;

namespace PI.BackEnd.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly EventService _events;

        public EventController(EventService events)
        {
            _events = events;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Event newEvent)
        {
            var success = await _events.CreateEvent(newEvent);
            if (!success)
                return BadRequest("Já existe um evento para está sala nesse horário.");

            return Ok("Evento criado com sucesso.");
        }

        //O metodo abaixo deve retornar a lista de eventos
        [HttpGet("eventos")]
        public async Task<IActionResult> GetEvents()
        {
            var eventsList = await _events.GetEvents();
            if (eventsList == null || !eventsList.Any())
                return NotFound("Não possui eventos cadastrados.");  // Usar NotFound para indicar que não foram encontrados eventos

            return Ok(eventsList);  // Retornar a lista de eventos
        }

    }
}
