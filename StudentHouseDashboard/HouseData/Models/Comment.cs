﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentHouseDashboard.Models
{
    public class Comment : GenericMessage, IVotable
    {
        public Comment(User author, string description, string title, DateTime publishDate) : base(author, description, title, publishDate)
        {
        }

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