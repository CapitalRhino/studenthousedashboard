using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic;
using Models;
using System.Security.Claims;
using System.Dynamic;

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
