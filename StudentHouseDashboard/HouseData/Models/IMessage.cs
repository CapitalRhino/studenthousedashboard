using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentHouseDashboard.Models
{
    public interface IMessage
    {
        string Title { get; set; }
        string Description { get; set; }
        User Author { get; set; }
        DateTime PublishDate { get; set; }
    }
}