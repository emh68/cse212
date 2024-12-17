public class ToDoList
{
    private TaskNode head;

    public ToDoList()
    {
        head = null;
    }

    // Add task to the to-do list
    public void AddTask(string taskName, DateTime dueDate, int priority)
    {
        TaskNode newNode = new TaskNode(taskName, dueDate, priority);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            TaskNode current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
            newNode.Previous = current;  // Link back to the previous node
        }
    }

    // Remove a task from the to-do list (doubly linked list)
    public void RemoveTask(string taskName)
    {
        if (head == null)
        {
            Console.WriteLine("The task list is empty.");
            return;
        }

        TaskNode current = head;
        while (current != null)
        {
            if (current.TaskName.Equals(taskName, StringComparison.OrdinalIgnoreCase))
            {
                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;  // Link previous node to next node
                }
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;  // Link next node to previous node
                }
                if (current == head)
                {
                    head = current.Next;  // If removing the head node
                }
                Console.WriteLine($"Task '{taskName}' removed.");
                return;
            }
            current = current.Next;
        }

        Console.WriteLine("Task not found.");
    }

    // Display the to-do list with priority and completion status
    public void DisplayList()
    {
        TaskNode current = head;
        while (current != null)
        {
            Console.WriteLine($"Task: {current.TaskName}, Due: {current.DueDate.ToShortDateString()}, Priority: {current.GetPriorityString()}, {current.GetCompletionStatus()}");
            current = current.Next;
        }
    }

    // Mark a task as completed
    public void MarkTaskAsCompleted(string taskName)
    {
        TaskNode current = head;
        while (current != null)
        {
            if (current.TaskName.Equals(taskName, StringComparison.OrdinalIgnoreCase))
            {
                current.IsCompleted = true;
                Console.WriteLine($"Task '{taskName}' marked as completed.");
                return;
            }
            current = current.Next;
        }

        Console.WriteLine("Task not found.");
    }
}