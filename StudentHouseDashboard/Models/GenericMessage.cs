using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public abstract class GenericMessage
    {
        protected GenericMessage(int id, User author, string description, string title, DateTime publishDate)
        {
            ID = id;
            Author = author;
            Description = description;
            Title = title;
            PublishDate = publishDate;
        }
        protected GenericMessage()
        {
            
        }
        public int ID
        {
            get; set;
        }

        public User Author
        {
            get;set;
        }
        public string Description
        {
            get;set;
        }
        public string Title
        {
            get;set;
        }
        public DateTime PublishDate
        {
            get; set;
        }
    }
}