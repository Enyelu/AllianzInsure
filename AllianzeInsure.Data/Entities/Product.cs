﻿namespace AllianzeInsure.Data.Entities
{
    public class Product : Base
    {
        public string? BodyTpe {  get; set; }
        public decimal Premium { get; set; }
        public decimal Discount { get; set; }
    }
}