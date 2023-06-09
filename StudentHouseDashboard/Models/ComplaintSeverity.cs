using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

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