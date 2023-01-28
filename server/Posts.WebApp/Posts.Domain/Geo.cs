namespace Posts.Domain
{
    public class Geo : BaseEntity
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
    }
}
