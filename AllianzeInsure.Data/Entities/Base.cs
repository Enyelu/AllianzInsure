namespace AllianzeInsure.Data.Entities
{
    public class Base
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedOn { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}