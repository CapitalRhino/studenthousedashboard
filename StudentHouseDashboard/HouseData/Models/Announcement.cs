using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentHouseDashboard.Models
{
    public class Announcement : IMessage, IVotable
    {
        public List<Comment> Comments
        {
            get => default;
            set
            {
            }
        }

        public int IsImportant
        {
            get => default;
            set
            {
            }
        }

        public int IsSticky
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

        public void DownVote()
        {
            throw new NotImplementedException();
        }

        public void UpVote()
        {
            throw new NotImplementedException();
        }
    }
}