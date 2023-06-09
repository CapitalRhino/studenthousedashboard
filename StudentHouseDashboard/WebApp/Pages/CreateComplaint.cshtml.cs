using Data;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using System.Security.Claims;

namespace WebApp.Pages
{
    [Authorize]
    public class CreateComplaintModel : PageModel
    {
        [BindProperty]
        public Complaint Complaint { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            ComplaintManager complaintManager = new ComplaintManager(new ComplaintRepository());
            UserManager userManager = new UserManager(new UserRepository());
            User user = userManager.GetUserById(int.Parse(User.FindFirstValue("id")));
            complaintManager.CreateComplaint(Complaint.Title, Complaint.Description, user, DateTime.Now, ComplaintStatus.FILED, Complaint.Severity);
            return RedirectToPage("Complaints");
        }
    }
}
