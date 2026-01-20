using System;
using Store.Domain.Entities;

Console.WriteLine("Debug Runner");

var customer = new Customer("Client1", "email@example.com");
var discount = new Discount(10, DateTime.UtcNow.AddDays(10));
var product = new Product("Produto1", 30);
var order = new Order(customer, 10, discount);
order.AddItem(product, 2);

Console.WriteLine($"Items count: {order.Items.Count}");
Console.WriteLine($"Item total: {order.Items[0].Total()}");
Console.WriteLine($"DeliveryFee: {order.DeliveryFee}");
Console.WriteLine($"Discount.IsValid(): {discount.IsValid()}");
Console.WriteLine($"Discount.Value(): {discount.Value()}");
Console.WriteLine($"Order.Total(): {order.Total()}");
order.Pay(60);
Console.WriteLine($"Paid 60; Order.Status: {order.Status}");
order.Pay(order.Total());
Console.WriteLine($"Paid full; Order.Status: {order.Status}");
