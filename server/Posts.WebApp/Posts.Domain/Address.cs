namespace Posts.Domain
{
    public class Address : BaseEntity
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Geo Geo { get; set; }

    }
}
