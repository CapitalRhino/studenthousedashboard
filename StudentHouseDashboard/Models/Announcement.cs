namespace Models
{
    public class Announcement : GenericMessage
    {
        public Announcement(int id, User author, string description, string title, DateTime publishDate, bool isImportant, bool isSticky) : base(id, author, description, title, publishDate)
        {
            IsImportant = isImportant;
            IsSticky = isSticky;
        }

        public Announcement()
        {

        }
        public List<Comment> Comments
        {
            get; set;
        }

        public bool IsImportant
        {
            get; set;
        }

        public bool IsSticky
        {
            get; set;
        }
        public override string ToString()
        {
            return $"{Title} ({PublishDate.ToString("g")} - {Author.Name})";
        }
    }
}