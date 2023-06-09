using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Models
{
    public enum ComplaintStatus
    {
        [Description("Filed")]
        FILED,
        [Description("Under review")]
        UNDER_REVIEW,
        [Description("Solved")]
        SOLVED,
        [Description("Archived")]
        ARCHIVED
    }
}