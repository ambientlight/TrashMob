﻿
namespace TrashMob.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using TrashMob.Shared.Persistence;

    [ApiController]
    [Route("api/eventtypes")]
    public class EventsTypesController : ControllerBase
    {
        private readonly IEventTypeRepository eventTypeRepository;

        public EventsTypesController(IEventTypeRepository eventTypeRepository)
        {
            this.eventTypeRepository = eventTypeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetEventTypes()
        {
            var result = await eventTypeRepository.GetAllEventTypes().ConfigureAwait(false);
            return Ok(result);
        }
    }
}
