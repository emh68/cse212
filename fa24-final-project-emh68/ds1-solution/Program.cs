using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int avgHelpTime = 5;
        var callCenter = new CallCenterQueue(avgHelpTime);

        // Enqueue customers
        callCenter.Enqueue("Customer 1");
        callCenter.Enqueue("Customer 2");
        callCenter.Enqueue("Customer 3");
        callCenter.Enqueue("Customer 4");
        callCenter.Enqueue("Customer 5");
        callCenter.Enqueue("Customer 6");
        callCenter.Enqueue("Customer 7");
        callCenter.Enqueue("Customer 8");

        while (true)
        {
            if (callCenter.IsQueueEmpty())
            {
                Console.WriteLine("Everyone in the queue has been helped. Exiting the program.");
                break;
            }

            callCenter.DisplayQueue();

            // Get number of customers served
            int servedCount = GetValidIntegerInput("How many customers have been served? (Enter a number or 'exit')");

            if (servedCount == -1) // User entered "exit"
            {
                Console.WriteLine("Exiting the program.");
                break;
            }

            callCenter.ServeCustomers(servedCount);

            // Get wait time for a specific customer
            int customerNumber = GetValidIntegerInput("Which customer number do you want to check the wait time for? (Enter a number or 'exit')");

            if (customerNumber == -1) // User entered "exit"
            {
                Console.WriteLine("Exiting the program.");
                break;
            }

            string result = callCenter.GetCustomerWaitTime(customerNumber);
            Console.WriteLine(result);
        }
    }

    static int GetValidIntegerInput(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine() ?? string.Empty;

            // Check for "exit"
            if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
            {
                return -1;
            }

            // Validate integer input
            if (int.TryParse(input, out int result) && result >= 0)
            {
                return result;
            }

            Console.WriteLine("Invalid input. Please enter a valid number or 'exit'.");
        }
    }
}
