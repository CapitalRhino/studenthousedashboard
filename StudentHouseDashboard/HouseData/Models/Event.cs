using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentHouseDashboard.Models
{
    public class Event : GenericMessage
    {
        public Event(User author, string description, string title, DateTime publishDate, DateTime startDate, DateTime endDate) : base(author, description, title, publishDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate
        {
            get;set;
        }

        public DateTime EndDate
        {
            get;set;
        }
    }
}