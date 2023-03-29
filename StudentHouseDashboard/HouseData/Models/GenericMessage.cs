using StudentHouseDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentHouseDashboard
{
    public abstract class GenericMessage
    {
        private User author;
        private string description;
        private string title;
        private DateTime publishDate;

        protected GenericMessage(User author, string description, string title, DateTime publishDate)
        {
            Author = author;
            Description = description;
            Title = title;
            PublishDate = publishDate;
        }

        public User Author
        {
            get => author;
            set => author = value;
        }
        public string Description
        {
            get => description;
            set => description = value;
        }
        public string Title
        {
            get => title;
            set => title = value;
        }
        public DateTime PublishDate
        {
            get => publishDate;
            set => publishDate = value;
        }
    }
}