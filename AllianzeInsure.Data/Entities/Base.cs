namespace AllianzeInsure.Data.Entities
{
    public class Base
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime CreatedBy { get; set; }
        public DateTime ModifiedBy { get; set; }
    }
}