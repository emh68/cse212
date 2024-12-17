public class TaskNode
{
    public string TaskName { get; set; }
    public DateTime DueDate { get; set; }
    public int Priority { get; set; }  // Store priority as integer (1 = High, 2 = Medium, 3 = Low)
    public bool IsCompleted { get; set; }  // Track completion status
    public TaskNode? Next { get; set; }
    public TaskNode? Previous { get; set; }

    // Constructor
    public TaskNode(string taskName, DateTime dueDate, int priority)
    {
        TaskName = taskName;
        DueDate = dueDate;
        Priority = priority;
        IsCompleted = false;  // Default to not completed
        Next = null;
        Previous = null;
    }

    // Get priority as a string
    public string GetPriorityString()
    {
        return Priority switch
        {
            1 => "High",
            2 => "Medium",
            3 => "Low",
            _ => "Unknown" // In case of invalid priority
        };
    }

    // Get completion status as a string
    public string GetCompletionStatus()
    {
        return IsCompleted ? "Completed: [x]" : "Completed: []";
    }
}