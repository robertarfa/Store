using System;
using System.Linq;
using Store.Domain.Entities;
using Store.Domain.Enums;

namespace Store.Tests.Entities
{
    [TestClass]
    public class CustomerTests
    {


        [TestMethod]
        [TestCategory("Entities")]
        public void Dado_o_cadastro_de_um_novo_cliente_o_cadastro_deve_ser_valido()
        {
            var newCustomer = new Customer("Nome", "email@email.com");

            Assert.IsTrue(newCustomer.Valid);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void Dado_o_cadastro_de_um_novo_cliente_sem_nome_o_cadastro_deve_ser_invalido()
        {
            var newCustomer = new Customer(null, "email@email.com");

            Assert.IsFalse(newCustomer.Valid);
        }
        [TestMethod]
        [TestCategory("Entities")]
        public void Dado_o_cadastro_de_um_novo_cliente_sem_email_o_cadastro_deve_ser_invalido()
        {
            var newCustomer = new Customer("Nome", null);

            Assert.IsFalse(newCustomer.Valid);
        }
    }
}