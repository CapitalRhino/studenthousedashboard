﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentHouseDashboard.Models
{
    public interface IVotable
    {
        void UpVote()
        {
            throw new NotImplementedException();
        }
        void DownVote()
        {
            throw new NotImplementedException();
        }
    }
}