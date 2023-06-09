using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using System.Security.Claims;

namespace WebApp.Pages
{
    [Authorize]
    public class EditEventModel : PageModel
    {
        private readonly IEventRepository _eventRepository;
        private readonly IUserRepository _userRepository;

        public EditEventModel(IEventRepository eventRepository, IUserRepository userRepository)
        {
            _eventRepository = eventRepository;
            _userRepository = userRepository;
        }
        [BindProperty]
        public Event Event { get; set; }
        public void OnGet(int? id)
        {
            EventManager eventManager = new EventManager(_eventRepository);
            if (id != null)
            {
                Event @event = eventManager.GetEventById(id.Value);
                if (@event.Author.ID == int.Parse(User.FindFirstValue("id")) || User.IsInRole("ADMIN")    )
                {
                    ViewData["event"] = @event;
                }
            }
        }
        public IActionResult OnPost(bool? n)
        {
            if (n != null && n.Value)
            {
                UserManager userManager = new UserManager(_userRepository);
                User user = userManager.GetUserById(int.Parse(User.FindFirstValue("id")));
                EventManager eventManager = new EventManager(_eventRepository);
                eventManager.CreateEvent(Event.Title, Event.Description, user, DateTime.Now, Event.StartDate, Event.EndDate);
            }
            else
            {
                EventManager eventManager = new EventManager(_eventRepository);
                eventManager.UpdateEvent(Event.ID, Event.Title, Event.Description, Event.StartDate, Event.EndDate);
            }
            
            return RedirectToPage("Events");
        }
    }
}
