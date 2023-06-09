using System.ComponentModel;

namespace Models
{
    public enum ComplaintSeverity
    {
        [Description("Low")]
        LOW,
        [Description("Normal")]
        NORMAL,
        [Description("High")]
        HIGH,
        [Description("Urgent")]
        URGENT
    }
}