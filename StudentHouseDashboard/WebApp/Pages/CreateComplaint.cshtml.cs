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
        private readonly IComplaintRepository _complaintRepository;
        private readonly IUserRepository _userRepository;
        public CreateComplaintModel(IComplaintRepository complaintRepository, IUserRepository userRepository)
        {
            _complaintRepository = complaintRepository;
            _userRepository = userRepository;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            ComplaintManager complaintManager = new ComplaintManager(_complaintRepository);
            UserManager userManager = new UserManager(_userRepository);
            User user = userManager.GetUserById(int.Parse(User.FindFirstValue("id")));
            complaintManager.CreateComplaint(Complaint.Title, Complaint.Description, user, DateTime.Now, ComplaintStatus.FILED, Complaint.Severity);
            return RedirectToPage("Complaints");
        }
    }
}
