using System;

namespace Store.Domain.Entities
{
    public class PromoCode : Entity
    {
        public PromoCode(string code, decimal value, DateTime expireDate)
        {
            Code = code;
            Value = value;
            ExpireDate = expireDate;
        }
        // public int Id { get; set; }
        public string Code { get; set; }
        public decimal Value { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}