﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentHouseDashboard.Models
{
    public interface IVotable
    {
        void UpVote();
        void DownVote();
    }
}