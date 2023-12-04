namespace AllianzeInsure.Data.Entities
{
    public class Payment : Base
    {
        public string Id { get; set; }
        public string InsuranceId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string PaymentType { get; set; }
        public int Amount { get; set; }
        public string TransactionReference { get; set; }
        public bool IsApproved { get; set; }
    }
}