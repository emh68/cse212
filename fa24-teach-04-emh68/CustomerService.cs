using System.Reflection.Metadata;
using Microsoft.VisualBasic;

namespace teach_04;
/*
 * CSE212 
 * (c) BYU-Idaho
 * 04-Teach - Problem 2
 * 
 * It is a violation of BYU-Idaho Honor Code to post or share this code with others or 
 * to post it online.  Storage into a personal and private repository (e.g. private
 * GitHub repository, unshared Google Drive folder) is acceptable.
 *
 */

/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: CustomerService instance with valid size 5, 6, etc.
        // Expected Result: The maximum size should be the valid size.

        Console.WriteLine("Test 1");

        // Defect(s) Found: 

        Console.WriteLine("=================");
        var cs = new CustomerService(5);
        Console.WriteLine(cs);
        Console.WriteLine();

        // Test 2
        // Scenario: 
        // Expected Result: 
        Console.WriteLine("Test 2");

        // Defect(s) Found: 

        Console.WriteLine("=================");
        var qs = new CustomerService(0);
        Console.WriteLine(qs);

        // Test 3
        // Scenario:
        // Expected Result:

        Console.WriteLine("Test 3");

        // Defect(s) Found: 

        Console.WriteLine("=================");
        var nfq = new CustomerService(3);
        Console.WriteLine("Before adding a customer: ");
        Console.WriteLine(nfq);
        nfq.AddNewCustomer();
        Console.WriteLine("After adding one customer: ");
        Console.WriteLine(nfq);

        // Test 4
        // Scenario:
        // Expected Result:

        Console.WriteLine("Test 4");

        // Defect(s) Found: 

        Console.WriteLine("=================");
        var fq = new CustomerService(2);
        Console.WriteLine(fq);
        fq.AddNewCustomer();
        fq.AddNewCustomer();
        fq.AddNewCustomer();
        Console.WriteLine(fq);


        // Add more Test Cases As Needed Below
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer()
    {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer()
    {
        // _queue.RemoveAt(0);
        // var customer = _queue[0];
        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + String.Join(", ", _queue) + "]";
    }
}