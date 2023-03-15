using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public Contact Contact { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            ViewData["confirm"] = $"Thank you for contacting us, {Contact.Name}! We promise to return a response in a timely manner to the following e-mail address: {Contact.Email}";
        }
    }
}
