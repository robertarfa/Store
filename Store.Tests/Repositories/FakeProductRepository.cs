using System;
using System.Collections.Generic;
using Store.Domain.Entities;
using Store.Domain.Repositories.Interfaces;

namespace Store.Tests.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        public static readonly Guid ProductId1 = Guid.Parse("00000000-0000-0000-0000-000000000001");
        public static readonly Guid ProductId2 = Guid.Parse("00000000-0000-0000-0000-000000000002");
        public static readonly Guid ProductId3 = Guid.Parse("00000000-0000-0000-0000-000000000003");
        public static readonly Guid ProductId4 = Guid.Parse("00000000-0000-0000-0000-000000000004");
        public static readonly Guid ProductId5 = Guid.Parse("00000000-0000-0000-0000-000000000005");

        public IEnumerable<Product> Get(IEnumerable<Guid> ids)
        {
            IList<Product> products = new List<Product>();

            var product1 = new Product("Produto 01", 20);
            SetProductId(product1, ProductId1);
            products.Add(product1);

            var product2 = new Product("Produto 02", 20);
            SetProductId(product2, ProductId2);
            products.Add(product2);

            var product3 = new Product("Produto 03", 20);
            SetProductId(product3, ProductId3);
            products.Add(product3);

            var product4 = new Product("Produto 04", 20, false);
            SetProductId(product4, ProductId4);
            products.Add(product4);

            var product5 = new Product("Produto 05", 20, false);
            SetProductId(product5, ProductId5);
            products.Add(product5);

            return products;
        }

        private void SetProductId(Product product, Guid id)
        {
            var propertyInfo = typeof(Product).BaseType.GetProperty("Id");
            propertyInfo.SetValue(product, id);
        }
    }
}
