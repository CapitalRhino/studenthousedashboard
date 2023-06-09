using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic;
using Models;
using System.Security.Claims;

namespace WebApp.Pages
{
    [Authorize]
    public class ComplaintsModel : PageModel
    {
        public ComplaintManager ComplaintManager { get; set; }
        private readonly IComplaintRepository _complaintRepository;

        public ComplaintsModel(IComplaintRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }

        public void OnGet(int? p, int? c) // page, count
        {
            ComplaintManager = new ComplaintManager(_complaintRepository);
            if (!(p < 0))
            {
                p = 1;
            }
            if (!(c < 1))
            {
                c = 10;
            }
            ViewData.Add("complaints", ComplaintManager.GetComplaintsByPage(int.Parse(User.FindFirstValue("id")), p.Value - 1, c.Value));
            ViewData.Add("page", p);
            ViewData.Add("count", c);
            ViewData.Add("allCount", ComplaintManager.GetAllComplaints().Count);
        }
    }
}
