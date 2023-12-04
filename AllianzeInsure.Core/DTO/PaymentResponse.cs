namespace AllianzeInsure.Core.DTO
{
    public class PaymentResponse
    {
        public string? Id { get; set; }
        public string PaymentType { get; set; }
        public string Email { get; set; }
        public int Amount { get; set; }
    }
}
