namespace prove_04;

/*
 * CSE212 
 * (c) BYU-Idaho
 * 02-Prove - Problem 2
 * 
 * It is a violation of BYU-Idaho Honor Code to post or share this code with others or 
 * to post it online.  Storage into a personal and private repository (e.g. private
 * GitHub repository, unshared Google Drive folder) is acceptable.
 *
 */
public static class Priority
{
    public static void Test()
    {
        // TODO Problem 2 - Write and run test cases and fix the code to match requirements
        // Example of creating and using the priority queue
        // var priorityQueue = new PriorityQueue();
        // Console.WriteLine(priorityQueue);

        // Test Cases

        // Test 1
        // Scenario: Create a queue with the following people and turns to determine if the Dequeue function 
        // removes the person with the highest priority: Matt (2), Ben (1), Joe (7), April (5), Julie (9)
        // Expected Result: Julie (Pri: 9)
        Console.WriteLine("Test 1");
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Matt", 2);
        priorityQueue.Enqueue("Ben", 1);
        priorityQueue.Enqueue("Joe", 7);
        priorityQueue.Enqueue("April", 5);
        priorityQueue.Enqueue("Julie", 9);

        Console.WriteLine(priorityQueue);
        priorityQueue.Dequeue();
        var dequeuedPlayer = priorityQueue.Dequeue();
        Console.WriteLine(dequeuedPlayer);
        // Console.WriteLine(players);

        // Defect(s) Found: The following line of code doesn't iterate over/count the last item in the queue thus if 
        // the last player/person has the highest priority they will not be counted.  for (int index = 1; index < _queue.Count - 1; index++)
        // to fix this we can simple get the _queue.Count without subtracting 1 and that will count the last item in the queue.  for (int index = 1; index < _queue.Count; index++)

        Console.WriteLine("---------");

        // Test 2
        // Scenario: Create a queue with more than one person having the same priority to determine if the Dequeue function removes 
        // the person with the highest priority, taking in to consideration more than one person has the same priority and following 
        // the LIFO principle: Matt (2), Ben (1), Jim (9), Joe (7), April (5), Julie (9)
        // Expected Result: Jim (Pri: 9)
        Console.WriteLine("Test 2");
        priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Matt", 2);
        priorityQueue.Enqueue("Ben", 1);
        priorityQueue.Enqueue("Jim", 9);
        priorityQueue.Enqueue("Joe", 7);
        priorityQueue.Enqueue("April", 5);
        priorityQueue.Enqueue("Julie", 9);

        Console.WriteLine(priorityQueue);
        priorityQueue.Dequeue();
        var dequeuedPerson = priorityQueue.Dequeue();
        Console.WriteLine(dequeuedPerson);


        // Defect(s) Found: The code appeared to be finding the first person with the highest priority and 
        // then removing them instead of simply returning that person with the highest priority. We want to use Dequeue to return the person, not removeAt. 

        Console.WriteLine("---------");

        // Test 3
        // Scenario: 
        // Expected Result: 
        Console.WriteLine("Test 3");
        priorityQueue = new PriorityQueue();
        // players = new PriorityQueue();
        // players.Enqueue("Matt", 2);
        // players.Enqueue("Ben", 1);
        // players.Enqueue("Jim", 9);
        // players.Enqueue("Joe", 7);
        // players.Enqueue("April", 5);
        // players.Enqueue("Julie", 9);

        Console.WriteLine(priorityQueue);
        // players.Dequeue();
        var dequeuedCustomer = priorityQueue.Dequeue();
        Console.WriteLine(dequeuedCustomer);

        // Defect(s) Found: 

        Console.WriteLine("---------");
    }
}