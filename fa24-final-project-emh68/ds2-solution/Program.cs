using System;

class Program
{
    static void Main()
    {
        ToDoList toDoList = new ToDoList();

        while (true)
        {
            Console.WriteLine("\nTo-Do List Management");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add a task");
            Console.WriteLine("2. Remove a task");
            Console.WriteLine("3. Mark a task as completed");
            Console.WriteLine("4. Display all tasks");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Add a task
                    Console.Write("Enter task name: ");
                    string taskName = Console.ReadLine();

                    Console.Write("Enter due date (yyyy-mm-dd): ");
                    DateTime dueDate;
                    while (!DateTime.TryParse(Console.ReadLine(), out dueDate))
                    {
                        Console.Write("Invalid date. Please enter a valid due date (yyyy-mm-dd): ");
                    }

                    Console.WriteLine("Enter priority (1 = high, 2 = medium, 3 = low): ");
                    int priority;
                    while (!int.TryParse(Console.ReadLine(), out priority) || priority < 1 || priority > 3)
                    {
                        Console.WriteLine("Invalid priority. Please enter 1, 2, or 3.");
                    }

                    toDoList.AddTask(taskName, dueDate, priority);
                    break;

                case "2":
                    // Remove a task
                    Console.Write("Enter task name to remove: ");
                    string removeTaskName = Console.ReadLine();
                    toDoList.RemoveTask(removeTaskName);
                    break;

                case "3":
                    // Mark a task as completed
                    Console.Write("Enter task name to mark as completed: ");
                    string completedTaskName = Console.ReadLine();
                    toDoList.MarkTaskAsCompleted(completedTaskName);
                    break;

                case "4":
                    // Display all tasks
                    Console.WriteLine("\nTo-Do List:");
                    toDoList.DisplayList(); // Display updated task list with completion status
                    break;

                case "5":
                    // Exit the program
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}