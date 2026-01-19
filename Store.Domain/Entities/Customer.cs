using Flunt.Validations;

namespace Store.Domain.Entities;

public class Customer : Entity
{
    // public int Id { get; set; } vai para Entity
    //private set para privar que seja alterada externamente, será alterada somente via construtor.

    public Customer(string name, string email)
    {
        Name = name;
        Email = email;

        AddNotifications(
           new Contract()
           .Requires()
           .IsNotNull(name, "CustomerName", "Nome do cliente inválido")
           .IsNotNull(email, "CustomerEmail", "Email do Cliente inválido")
       );
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
}
