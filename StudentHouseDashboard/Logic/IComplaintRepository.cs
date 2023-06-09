using Logic.Exceptions;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IComplaintRepository
    {
        public List<Complaint> GetAllComplaints();
        public Complaint GetComplaintById(int id);
        public List<Complaint> GetComplaintsByPage(int userId, int p, int c);
        public Complaint CreateComplaint(string title, string description, User author, DateTime publishDate, ComplaintStatus status, ComplaintSeverity severity);
        public void UpdateComplaint(int id, string title, string description, ComplaintStatus status, ComplaintSeverity severity);
        public List<Complaint> SearchComplaint(string query);
    }
}
