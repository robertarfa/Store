using System;
using System.Linq;
using Store.Domain.Entities;
using Store.Domain.Enums;

namespace Store.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {

        private readonly Customer _customer = new Customer("Client1", "email@email.com.br");
        private readonly Discount _discount = new Discount(10, DateTime.UtcNow.AddDays(10));
        private readonly Product _product = new Product("Produto1", 30);

        [TestMethod]
        [TestCategory("Entities")]
        public void Dado_um_novo_pedido_valido_ele_deve_gerar_um_numero_com_8_caracteres()
        {
            var newOrder = new Order(_customer, 10, _discount);

            Assert.AreEqual(8, newOrder.Number.Length);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void Dado_um_novo_pedido_seu_status_deve_ser_aguardando_pagamento()
        {
            var newOrder = new Order(_customer, 10, _discount);
            Assert.AreEqual(EOrderStatus.WaitingPayment, newOrder.Status);

        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pagamento_do_pedido_seu_status_deve_ser_aguardando_entrega()
        {
            var newOrder = new Order(_customer, 10, _discount);
            newOrder.AddItem(_product, 2);
            newOrder.Pay(60);
            Assert.AreEqual(EOrderStatus.WaitingDelivery, newOrder.Status);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pedido_cancelado_seu_status_deve_ser_cancelado()
        {
            var newOrder = new Order(_customer, 10, _discount);
            newOrder.Cancel();
            Assert.AreEqual(EOrderStatus.Cancelled, newOrder.Status);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_item_sem_produto_o_mesmo_nao_deve_ser_adicionado()
        {
            var newOrder = new Order(_customer, 10, _discount);
            newOrder.AddItem(null, 2);
            Assert.IsFalse(newOrder.Valid);
            Assert.AreEqual(1, newOrder.Notifications.Count);
            Assert.AreEqual("Produto inválido", newOrder.Notifications.First().Message);
        }
    }
}