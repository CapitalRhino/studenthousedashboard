﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentHouseDashboard.Models
{
    public class Event : IMessage, IVotable
    {
        public int StartDate
        {
            get => default;
            set
            {
            }
        }

        public int EndDate
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