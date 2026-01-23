using Flunt.Validations;

namespace Store.Domain.Entities
{
    public class Product : Entity
    {
        public Product(string title, decimal price, bool active = true)
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(title, "Product", "Produto inválido")
                .IsGreaterThan(price, 0, "Price", "O preço não pode ser menor que 0")
            );

            Title = title;
            Price = price;
            Active = active;
        }
        // public int Id { get; set; }
        public string Title { get; private set; }
        public decimal Price { get; private set; }
        public bool Active { get; private set; }
    }
}