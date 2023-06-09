using System.ComponentModel;

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