using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentHouseDashboard.Models
{
    public class Complaint : IMessage
    {
        public ComplaintStatus Status
        {
            get => default;
            set
            {
            }
        }

        public ComplaintSeverity Severity
        {
            get => default;
            set
            {
            }
        }

        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public User Author { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime PublishDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}