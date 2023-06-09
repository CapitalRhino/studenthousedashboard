using System.ComponentModel.DataAnnotations;

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
            get; set;
        }
        public string Description
        {
            get; set;
        }
        [StringLength(255)]
        public string Title
        {
            get; set;
        }
        public DateTime PublishDate
        {
            get; set;
        }
    }
}