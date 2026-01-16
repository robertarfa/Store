namespace Store.Domain.Entities;

public class Customer : Entity
{
    // public int Id { get; set; } vai para Entity
    //private set para privar que seja alterada externamente, será alterada somente via construtor.

    public Customer(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
}
