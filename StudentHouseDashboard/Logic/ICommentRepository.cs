using System.ComponentModel.Design;
using System.Data.SqlClient;
using Models;

namespace Logic;

public interface ICommentRepository
{
    public List<Comment> GetAllCommentsOnAnnouncement(int announcementId);
    public List<Comment> GetAllCommentResponses(int commentId);
    public Comment GetCommentById(int id);
    public void UpdateComment(int id, string description);
    public Comment CreateComment(User author, string description, string title, DateTime publishDate);
    public void CreateCommentOnAnnouncement(User author, string description, string title, DateTime publishDate, int announcementId);
    public void CreateResponseOnComment(User author, string description, string title, DateTime publishDate, int commentId);
    public void DeleteComment(int id);
    public void DeleteCommentOnAnnouncement(int commentId, int announcementId);
    public void DeleteResponseOnComment(int responseId, int commentId);
}