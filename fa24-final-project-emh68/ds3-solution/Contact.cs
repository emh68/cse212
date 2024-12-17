public class Contact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }

    public Contact(string firstName, string lastName, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
    }

    public override string ToString()
    {
        // Format as "Name: LastName, FirstName Phone: PhoneNumber"
        return $"Name: {LastName}, {FirstName} Phone: {PhoneNumber}";
    }
}
