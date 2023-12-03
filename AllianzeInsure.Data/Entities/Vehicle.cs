namespace AllianzeInsure.Data.Entities
{
    public  class Vehicle : Base
    {
        public string? Make {  get; set; }
        public string? Model { get; set; }
        public int? Year { get; set; }
    }
}