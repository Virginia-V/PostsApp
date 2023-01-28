namespace Posts.Domain
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
