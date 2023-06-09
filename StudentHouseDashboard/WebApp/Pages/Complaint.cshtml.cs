using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    [Authorize]
    public class ComplaintModel : PageModel
    {
        private readonly IComplaintRepository _complaintRepository;

        public ComplaintModel(IComplaintRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }
        public void OnGet(int id)
        {
            ComplaintManager complaintManager = new ComplaintManager(_complaintRepository);
            ViewData.Add("complaint", complaintManager.GetComplaintById(id));
        }
    }
}
