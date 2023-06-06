using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class CommentManager
    {
        private ICommentRepository commentRepository;
        public CommentManager(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }
        
        public void CreateCommentToAnnouncement(User author, string description, string title, DateTime publishDate, int announcementId)
        {
            commentRepository.CreateCommentOnAnnouncement(author, description, title, publishDate, announcementId);
        }
        public void CreateResponseToComment(User author, string description, string title, DateTime publishDate, int commentId)
        {
            commentRepository.CreateResponseOnComment(author, description, title, publishDate, commentId);
        }
        public void UpdateComment(int id, string description)
        {
            commentRepository.UpdateComment(id, description);
        }
        public void DeleteCommentOnAnnouncement(int commentId, int announcementId)
        {
            commentRepository.DeleteCommentOnAnnouncement(commentId, announcementId);
        }
        public void DeleteResponseOnComment(int responseId, int commentId)
        {
            commentRepository.DeleteResponseOnComment(responseId, commentId);
        }
    }
}
