using System;

namespace Store.Domain.Entities
{
    public class PromoCode : Entity
    {
        // public int Id { get; set; }
        public string Code { get; set; }
        public decimal Value { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}