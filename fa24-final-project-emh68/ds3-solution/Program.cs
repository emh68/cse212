using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var contactBook = new ContactBook();

        // Insert new contacts with FirstName, LastName, and PhoneNumber
        contactBook.Insert(new Contact("Alice", "Simmons", "958-242-3266"));
        contactBook.Insert(new Contact("Bob", "Barker", "208-546-5678"));
        contactBook.Insert(new Contact("Robert", "Frost", "321-515-8757"));
        contactBook.Insert(new Contact("Fred", "Michaels", "491-255-4351"));
        contactBook.Insert(new Contact("April", "Martin", "415-255-4351"));
        contactBook.Insert(new Contact("Leo", "Long", "323-356-8974"));
        contactBook.Insert(new Contact("Marsha", "Hendricks", "408-479-3021"));
        contactBook.Insert(new Contact("Fred", "Michaels", "650-589-7365"));
        contactBook.Insert(new Contact("John", "Doe", "213-689-1457"));
        contactBook.Insert(new Contact("Alice", "Johnson", "408-712-9835"));
        contactBook.Insert(new Contact("Michael", "Smith", "818-823-5672"));
        contactBook.Insert(new Contact("Sarah", "Brown", "510-934-2876"));
        contactBook.Insert(new Contact("James", "White", "619-045-7983"));
        contactBook.Insert(new Contact("Linda", "Clark", "925-156-3842"));

        bool continueRunning = true;

        while (continueRunning)
        {
            // Display the menu to the user
            Console.WriteLine("\nContact Management System:");
            Console.WriteLine("1. Add a Contact");
            Console.WriteLine("2. Search for a Contact");
            Console.WriteLine("3. Remove a Contact");
            Console.WriteLine("4. Display All Contacts");
            Console.WriteLine("5. Exit");
            Console.Write("Please choose an option (1-5): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Add a contact
                    Console.Write("Enter the first name of the contact: ");
                    string addFirstName = Console.ReadLine();
                    Console.Write("Enter the last name of the contact: ");
                    string addLastName = Console.ReadLine();
                    Console.Write("Enter the contact phone number: ");
                    string addPhoneNumber = Console.ReadLine();
                    contactBook.Insert(new Contact(addFirstName, addLastName, addPhoneNumber));
                    Console.WriteLine($"Contact {addFirstName} {addLastName} added successfully.");
                    break;

                case "2":
                    // Search for a contact
                    Console.Write("Enter the name of the contact to search for: ");
                    string searchName = Console.ReadLine();
                    var searchResult = contactBook.Search(searchName);
                    if (searchResult != null)
                    {
                        Console.WriteLine($"Found contact: {searchResult.ToString()}");
                    }
                    else
                    {
                        Console.WriteLine("Contact not found.");
                    }
                    break;

                case "3":
                    // Remove a contact
                    Console.Write("Enter the first name of the contact to remove: ");
                    string removeFirstName = Console.ReadLine();
                    Console.Write("Enter the last name of the contact to remove: ");
                    string removeLastName = Console.ReadLine();

                    bool removed = contactBook.Remove(removeFirstName, removeLastName);
                    if (removed)
                    {
                        Console.WriteLine($"Contact {removeFirstName} {removeLastName} removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Contact not found.");
                    }
                    break;

                case "4":
                    // Display all contacts
                    Console.WriteLine("\nAll Contacts:");
                    contactBook.DisplayContacts();
                    break;

                case "5":
                    // Exit the program
                    continueRunning = false;
                    Console.WriteLine("Exiting program...");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
