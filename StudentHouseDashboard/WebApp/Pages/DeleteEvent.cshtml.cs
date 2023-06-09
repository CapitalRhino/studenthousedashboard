using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using System.Security.Claims;

namespace WebApp.Pages
{
    [Authorize]
    public class DeleteEventModel : PageModel
    {
        private readonly IEventRepository eventRepository;

        public DeleteEventModel(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }
        [BindProperty]
        public int EventId { get; set; }
        public void OnGet(int id)
        {
            EventManager eventManager = new EventManager(eventRepository);
            if (id != null)
            {
                Event @event = eventManager.GetEventById(id);
                if (@event.Author.ID == int.Parse(User.FindFirstValue("id")) || User.IsInRole("ADMIN"))
                {
                    ViewData["event"] = @event;
                }
            }
        }
        public IActionResult OnPost()
        {
            EventManager eventManager = new EventManager(eventRepository);
            eventManager.DeleteEvent(EventId);
            return RedirectToPage("Events");
        }
    }
}
