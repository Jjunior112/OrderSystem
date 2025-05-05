using System.Text.RegularExpressions;

public class User
{
    public Guid UserId { get; private set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string UserName { get; set; }

    public string UserEmail { get; set; }

    public string UserPassword { get; set; }

    public string Address { get; set; }

    public string Reference { get; set; }

    public DateTime CreatedAt { get; set; }

    public User(string firstName, string lastName, string userEmail, string userPassword, string address, string reference)
    {
        if (string.IsNullOrEmpty(firstName)) throw new ArgumentException("UserName cannot be null or empty.");

        if (string.IsNullOrEmpty(lastName)) throw new ArgumentException("UserName cannot be null or empty.");

        if (string.IsNullOrEmpty(userEmail) || !Regex.IsMatch(userEmail, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))

            throw new ArgumentException("Invalid email format.");

        if (string.IsNullOrEmpty(userPassword)) throw new ArgumentException("Password cannot be null or empty.");

        if (string.IsNullOrEmpty(address)) throw new ArgumentException("Address cannot be null or empty.");

        if (string.IsNullOrEmpty(reference)) throw new ArgumentException("Reference cannot be null or empty.");


        UserId = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        UserName = SetUserName(firstName, lastName);
        UserEmail = userEmail;
        UserPassword = userPassword;
        Address = address;
        Reference = reference;
        CreatedAt = DateTime.UtcNow;
    }

    private string SetUserName(string firstName, string lastName)
    {
        char firstInitial = char.ToLower(firstName[0]);

        string cleanLastName = lastName.Trim().ToLower();

        Random random = new Random();

        int randomNumber = random.Next(1000, 10000);

        string userName = firstInitial + cleanLastName + randomNumber;

        return userName;
    }
}