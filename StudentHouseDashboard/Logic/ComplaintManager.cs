using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ComplaintManager
    {
        private IComplaintRepository complaintRepository;
        public ComplaintManager(IComplaintRepository complaintRepository) 
        {
            this.complaintRepository = complaintRepository;
        }
        public List<Complaint> GetAllComplaints()
        {
            return complaintRepository.GetAllComplaints();
        }
        public Complaint GetComplaintById(int id)
        {
            return complaintRepository.GetComplaintById(id);
        }
        public List<Complaint> GetComplaintsByPage(int userId, int p, int c)
        {
            return complaintRepository.GetComplaintsByPage(userId, p, c);
        }
        public Complaint CreateComplaint(string title, string description, User author, DateTime publishDate, ComplaintStatus status, ComplaintSeverity severity)
        {
            return complaintRepository.CreateComplaint(title, description, author, publishDate, status, severity);
        }
        public void UpdateComplaint(int id, string title, string description, ComplaintStatus status, ComplaintSeverity severity)
        {
            complaintRepository.UpdateComplaint(id, title, description, status, severity);
        }
        public List<Complaint> SearchComplaint(string query)
        {
            return complaintRepository.SearchComplaint(query);
        }
    }
}
