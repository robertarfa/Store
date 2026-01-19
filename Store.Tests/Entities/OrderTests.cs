using System;
using Store.Domain.Entities;
using Store.Domain.Enums;

namespace Store.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {

        private readonly Customer _customer = new Customer("Client1", "email@email.com.br");
        private readonly Discount _discount = new Discount(10, DateTime.UtcNow.AddDays(10));

        [TestMethod]
        [TestCategory("Entities")]
        public void Dado_um_novo_pedido_valido_ele_deve_gerar_um_numero_com_8_caracteres()
        {
            var newOrder = new Order(_customer, 10, _discount);

            Assert.AreEqual(8, newOrder.Number.Length);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void Dado_um_pagamento_do_pedido_seu_status_deve_ser_aguardando_entrega()
        {
            var newOrder = new Order(_customer, 10, _discount);

            Assert.AreEqual(EOrderStatus.WaitingPayment, newOrder.Status);

        }
    }
}