namespace Posts.Domain
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public virtual Address Address { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

    }
}
