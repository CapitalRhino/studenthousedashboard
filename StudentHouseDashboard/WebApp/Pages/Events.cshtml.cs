using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    [Authorize]
    public class EventsModel : PageModel
    {
        private readonly IEventRepository _eventRepository;

        public EventsModel(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public void OnGet()
        {
            EventManager eventManager = new EventManager(_eventRepository);
            ViewData["events"] = eventManager.GetAllCurrentEvents();
        }
    }
}
