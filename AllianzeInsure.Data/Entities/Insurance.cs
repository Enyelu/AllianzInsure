namespace AllianzeInsure.Data.Entities
{
    public class Insurance
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? VehicleMake { get; set; }
        public string? VehicleModel { get; set; }
        public string? RegistrationNumber {  get; set; }
        public string? BodyType { get; set; }
    }
}