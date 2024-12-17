class CallCenterQueue
{
    private Queue<string> queue;
    private int avgHelpTime;
    private int servedCount = 0;

    public CallCenterQueue(int avgHelpTime)
    {
        queue = new Queue<string>();
        this.avgHelpTime = avgHelpTime;
    }

    public void Enqueue(string customer)
    {
        queue.Enqueue(customer);
    }

    public void ServeCustomers(int count)
    {
        for (int i = 0; i < count && queue.Count > 0; i++)
        {
            Console.WriteLine($"Served: {queue.Dequeue()}");
            servedCount++;
        }
    }

    public string GetCustomerWaitTime(int customerNumber)
    {
        if (customerNumber <= servedCount)
        {
            return $"Customer {customerNumber} has already been helped. Please check the queue.";
        }

        int positionInQueue = customerNumber - servedCount;

        if (positionInQueue <= 0 || positionInQueue > queue.Count)
        {
            return $"Customer {customerNumber} is not in the queue.";
        }

        int waitTime = (positionInQueue - 1) * avgHelpTime;
        return $"Customer {customerNumber}'s wait time: {waitTime} minutes.";
    }

    public void DisplayQueue()
    {
        if (queue.Count == 0)
        {
            Console.WriteLine("The queue is empty.");
        }
        else
        {
            Console.WriteLine("Current Queue: " + string.Join(", ", queue));
        }
    }

    public bool IsQueueEmpty()
    {
        return queue.Count == 0;
    }
}