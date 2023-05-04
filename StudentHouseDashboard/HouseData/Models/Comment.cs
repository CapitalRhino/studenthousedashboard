using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentHouseDashboard.Models
{
    public class Comment : GenericMessage, IVotable
    {
        public Comment(int id, User author, string description, string title, DateTime publishDate) : base(id, author, description, title, publishDate)
        {
            Responses = new List<Comment>();
        }
        
        public List<Comment> Responses { get; set; }
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
            return $"{Author.Name} ({PublishDate.ToString("g")}) - {Description.PadRight(100).Trim()}";
        }
    }
}