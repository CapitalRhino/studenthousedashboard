using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic;
using Models;
using Data;

namespace WebApp.Pages
{
    [Authorize]
    public class EventModel : PageModel
    {
        private readonly IEventRepository eventRepository;

        public EventModel(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }
        public void OnGet(int id)
        {
            EventManager eventManager = new EventManager(eventRepository);
            ViewData.Add("event", eventManager.GetEventById(id));
        }
    }
}
