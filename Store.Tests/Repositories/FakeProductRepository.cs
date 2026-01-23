using System;
using System.Collections.Generic;
using Store.Domain.Entities;
using Store.Domain.Repositories.Interfaces;

namespace Store.Tests.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        public IEnumerable<Product> Get(IEnumerable<Guid> ids)
        {
            IList<Product> products = new List<Product>
            {
              new("Produto 01", 20),
              new("Produto 02", 20),
              new("Produto 03", 20),
              new("Produto 04", 20, false),
              new("Produto 05", 20, false)
            };

            return products;
        }
    }
}
