namespace Posts.Domain
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
