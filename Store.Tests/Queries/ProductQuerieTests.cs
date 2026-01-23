using System;
using System.Collections.Generic;
using System.Linq;
using Store.Domain.Entities;
using Store.Domain.Queries;

namespace Store.Tests.Queries
{
    [TestClass]
    public class ProductQuerieTests
    {

        IList<Product> _products = new List<Product>
            {
              new("Produto 01", 10),
              new("Produto 02", 20),
              new("Produto 03", 30),
              new("Produto 04", 40, false),
              new("Produto 05", 50, false)
            };

        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_a_consulta_de_produtos_ativos_deve_retornar_3()
        {
            // var activeProducts = _products.Where(x => x.Active).Count();
            var activeProducts = _products.AsQueryable().Where(ProductQueries.GetActiveProducts());
            Assert.IsTrue(activeProducts.Count() == 3);
            // Assert.AreEqual(activeProducts.Count(), 3);
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_a_consulta_de_produtos_inativos_deve_retornar_2()
        {
            var inactiveProducts = _products.AsQueryable().Where(ProductQueries.GetInactiveProducts());
            Assert.AreEqual(inactiveProducts.Count(), 2);
        }
    }
}