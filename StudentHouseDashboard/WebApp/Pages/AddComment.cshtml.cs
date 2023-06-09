using Logic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using System.Security.Claims;

namespace WebApp.Pages
{
    public class AddCommentModel : PageModel
    {
        [BindProperty]
        public Comment Comment { get; set; }

        [BindProperty]
        public string Type { get; set; }

        [BindProperty]
        public int ParentId { get; set; }

        [BindProperty]
        public string PreviousPage { get; set; }

        private readonly IAnnouncementRepository _announcementRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IComplaintRepository _complaintRepository;
        private readonly IUserRepository _userRepository;

        public AddCommentModel(ICommentRepository commentRepository, IAnnouncementRepository announcementRepository, IComplaintRepository complaintRepository, IUserRepository userRepository)
        {
            _announcementRepository = announcementRepository;
            _commentRepository = commentRepository;
            _complaintRepository = complaintRepository;
            _userRepository = userRepository;
        }

        public void OnGet(string t, int id)
        {
            AnnouncementManager announcementManager = new AnnouncementManager(_announcementRepository);
            CommentManager commentManager = new CommentManager(_commentRepository);
            ComplaintManager complaintManager = new ComplaintManager(_complaintRepository);
            Type = t;
            ParentId = id;
            PreviousPage = Request.Headers["Referer"].ToString();
            switch (Type)
            {
                case "announcement":
                    ViewData["parent"] = announcementManager.GetAnnouncementById(ParentId);
                    break;
                case "comment":
                    ViewData["parent"] = commentManager.GetCommentById(ParentId);
                    break;
                case "complaint":
                    ViewData["parent"] = complaintManager.GetComplaintById(ParentId);
                    break;
                default:
                    break;
            }
        }
        public RedirectResult OnPost()
        {
            CommentManager commentManager = new CommentManager(_commentRepository);
            UserManager userManager = new UserManager(_userRepository);
            User currentUser = userManager.GetUserById(int.Parse(User.FindFirstValue("id")));
            switch (Type)
            {
                case "announcement":
                    commentManager.CreateCommentOnAnnouncement(currentUser, Comment.Description, Comment.Title, DateTime.Now, ParentId);
                    break;
                case "comment":
                    commentManager.CreateResponseOnComment(currentUser, Comment.Description, Comment.Title, DateTime.Now, ParentId);
                    break;
                case "complaint":
                    commentManager.CreateCommentOnComplaint(currentUser, Comment.Description, Comment.Title, DateTime.Now, ParentId);
                    break;
                default:
                    break;
            }
            return Redirect(PreviousPage);
        }
    }
}
