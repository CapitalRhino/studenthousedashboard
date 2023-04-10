using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentHouseDashboard.Models
{
    public class Announcement : GenericMessage, IVotable
    {
        public Announcement(int id, User author, string description, string title, DateTime publishDate, bool isImportant, bool isSticky) : base(id, author, description, title, publishDate)
        {
            IsImportant = isImportant;
            IsSticky = isSticky;
        }

        public List<Comment> Comments
        {
            get;set;
        }

        public bool IsImportant
        {
            get;set;
        }

        public bool IsSticky
        {
            get; set;
        }

        public void DownVote()
        {
            throw new NotImplementedException();
        }

        public void UpVote()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return $"{Title} ({PublishDate.ToString("g")} - {Author.Name})";
        }
    }
}