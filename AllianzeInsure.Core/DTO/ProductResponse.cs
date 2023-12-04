namespace AllianzeInsure.Core.DTO
{
    public class ProductResponse
    {
        public string? Id { get; set; }
        public string? BodyTpe { get; set; }
        public decimal Premium { get; set; }
        public decimal Discount { get; set; }
    }
}