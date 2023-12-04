namespace AllianzeInsure.Core.DTO
{
    public class CreateProductDto
    {
        public string? BodyTpe { get; set; }
        public decimal Premium { get; set; }
        public decimal Discount { get; set; }
    }
}