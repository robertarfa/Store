using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Commands;
using Store.Domain.Handlers;
using Store.Domain.Repositories.Interfaces;
using Store.Tests.Repositories;

namespace Store.Tests.Handlers
{
    [TestClass]
    public class OrderHandlerTest
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IDeliveryFeeRepository _deliveryFeeRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly string InvalidCustomer = "11111111111";
        private readonly string ValidCustomer = "12345678911";
        private readonly string InvalidZipcode = "1234567";
        private readonly string ValidZipcode = "12345678";

        public OrderHandlerTest()
        {
            _customerRepository = new FakeCustomerRepository();
            _deliveryFeeRepository = new FakeDeliveryFeeRepository();
            _discountRepository = new FakeDiscountRepository();
            _productRepository = new FakeProductRepository();
            _orderRepository = new FakeOrderRepository();
        }
        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_cliente_inexistente_o_pedido_nao_deve_ser_gerado()
        {
            var command = new CreateOrderCommand();
            command.Customer = InvalidCustomer;
            command.ZipCode = ValidZipcode;
            command.PromoCode = "123589639";
            command.Items.Add(new CreateOrderItemCommand(FakeProductRepository.ProductId1, 1));
            command.Items.Add(new CreateOrderItemCommand(FakeProductRepository.ProductId2, 1));
            var handler = new OrderHandler(
                    _customerRepository,
                    _deliveryFeeRepository,
                    _discountRepository,
                    _productRepository,
                    _orderRepository
            );

            var result = handler.Handle(command) as GenericCommandResult;

            Assert.IsTrue(handler.Invalid);
            Assert.AreEqual(false, result.Success);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_cep_invalido_o_pedido_não_deve_ser_gerado_normalmente()
        {
            var command = new CreateOrderCommand();
            command.Customer = ValidCustomer;
            command.ZipCode = InvalidZipcode;
            command.PromoCode = "123589639";
            command.Items.Add(new CreateOrderItemCommand(FakeProductRepository.ProductId1, 1));
            command.Items.Add(new CreateOrderItemCommand(FakeProductRepository.ProductId2, 1));
            var handler = new OrderHandler(
                    _customerRepository,
                    _deliveryFeeRepository,
                    _discountRepository,
                    _productRepository,
                    _orderRepository
            );

            var result = handler.Handle(command) as GenericCommandResult;

            Assert.AreEqual(false, command.Valid);
            Assert.AreEqual(false, result.Success);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_promocode_inexistente_o_pedido_deve_ser_gerado_normalmente()
        {
            var command = new CreateOrderCommand();
            command.Customer = ValidCustomer;
            command.ZipCode = ValidZipcode;
            command.PromoCode = "123589639";
            command.Items.Add(new CreateOrderItemCommand(FakeProductRepository.ProductId1, 1));
            command.Items.Add(new CreateOrderItemCommand(FakeProductRepository.ProductId2, 1));
            var handler = new OrderHandler(
                    _customerRepository,
                    _deliveryFeeRepository,
                    _discountRepository,
                    _productRepository,
                    _orderRepository
            );

            var result = handler.Handle(command) as GenericCommandResult;

            Assert.IsTrue(command.Valid);
            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_pedido_sem_itens_o_mesmo_nao_deve_ser_gerado()
        {
            var command = new CreateOrderCommand();
            command.Customer = ValidCustomer;
            command.ZipCode = ValidZipcode;
            command.PromoCode = "123589639";

            var handler = new OrderHandler(
                    _customerRepository,
                    _deliveryFeeRepository,
                    _discountRepository,
                    _productRepository,
                    _orderRepository
            );

            var result = handler.Handle(command) as GenericCommandResult;

            Assert.AreEqual(command.Invalid, false);
            Assert.AreEqual(result.Success, false);
        }


        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_comando_invalido_o_pedido_nao_deve_ser_gerado()
        {
            var command = new CreateOrderCommand();
            command.Customer = "";
            command.ZipCode = "09551010";
            command.PromoCode = "123589639";
            command.Items.Add(new CreateOrderItemCommand(FakeProductRepository.ProductId1, 1));
            command.Items.Add(new CreateOrderItemCommand(FakeProductRepository.ProductId2, 1));
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_comando_valido_o_pedido_deve_ser_gerado()
        {
            var command = new CreateOrderCommand();
            command.Customer = "Cliente 111";
            command.ZipCode = "09551010";
            command.PromoCode = "123589639";
            command.Items.Add(new CreateOrderItemCommand(FakeProductRepository.ProductId1, 1));
            command.Items.Add(new CreateOrderItemCommand(FakeProductRepository.ProductId2, 1));
            // command.Validate();
            var handler = new OrderHandler(
                        _customerRepository,
                        _deliveryFeeRepository,
                        _discountRepository,
                        _productRepository,
                        _orderRepository
            );

            handler.Handle(command);
            Assert.AreEqual(command.Valid, true);
        }
    }
}