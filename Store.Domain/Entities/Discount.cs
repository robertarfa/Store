using System;

namespace Store.Domain.Entities
{
  public class Discount : Entity
  {
    public Discount(decimal amount, DateTime expireDate)
    {
      Amount = amount;
      ExpireDate = expireDate;
    }

    public decimal Amount { get; private set; }
    public DateTime ExpireDate { get; private set; }
  }
}