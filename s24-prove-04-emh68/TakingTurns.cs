namespace prove_04;

/*
 * CSE212 
 * (c) BYU-Idaho
 * 04-Prove - Problem 1
 * 
 * It is a violation of BYU-Idaho Honor Code to post or share this code with others or 
 * to post it online.  Storage into a personal and private repository (e.g. private
 * GitHub repository, unshared Google Drive folder) is acceptable.
 *
 */
public static class TakingTurns
{
    public static void Test()
    {
        // TODO Problem 1 - Run test cases and fix the code to match requirements
        // Test Cases

        // Test 1
        // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3) and
        //           run until the queue is empty
        // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
        Console.WriteLine("Test 1");
        var players = new TakingTurnsQueue();
        players.AddPerson("Bob", 2);
        players.AddPerson("Tim", 5);
        players.AddPerson("Sue", 3);
        // Console.WriteLine(players);    // This can be un-commented out for debug help
        while (players.Length > 0)

            players.GetNextPerson();

        // Defect(s) Found: 

        Console.WriteLine("---------");

        // Test 2
        // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3)
        //           After running 5 times, add George with 3 turns.  Run until the queue is empty.
        // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, George, Sue, Tim, George, Tim, George
        Console.WriteLine("Test 2");
        players = new TakingTurnsQueue();
        players.AddPerson("Bob", 2);
        players.AddPerson("Tim", 5);
        players.AddPerson("Sue", 3);
        for (int i = 0; i < 5; i++)
        {
            players.GetNextPerson();
            // Console.WriteLine(players);
        }

        players.AddPerson("George", 3);
        // Console.WriteLine(players);
        while (players.Length > 0)
            players.GetNextPerson();


        // Defect(s) Found: Queues must be in order and to follow the FIFO (First In First Out) principal thus, 
        // using insert here does not work correctly. Instead we need to ensure when someone in the queue is dequeued if they still
        // have turns then they are added back to the queue and enqueued. This part of the code is what causes the issue: _queue.Insert(0, person);
        // it is in the Enqueue method of the PersonQueue class. The correct code is the following: _queue.Add(person);

        Console.WriteLine("---------");

        // Test 3
        // Scenario: Create a queue with the following people and turns: Bob (2), Tim (Forever), Sue (3)
        //           Run 10 times.
        // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
        Console.WriteLine("Test 3");
        players = new TakingTurnsQueue();
        players.AddPerson("Bob", 2);
        players.AddPerson("Tim", 0);
        players.AddPerson("Sue", 3);
        // Console.WriteLine(players);
        for (int i = 0; i < 10; i++)
        {
            players.GetNextPerson();
            // Console.WriteLine(players);
        }
        // Defect(s) Found: The GetNextPerson method did not include proper logic to account for someone having infinite turns (turns = 0), like Tim. 
        // Thus Tim was not getting Enqueued again or in other words added back to the queue after being dequeued even though he has infinite turns.
        // To correct this I added the following logic to the GetNextPerson method: 
        // else if (person.Turns <= 0) {
        //        _people.Enqueue(person);
        //    }

        Console.WriteLine("---------");

        // Test 4
        // Scenario: Try to get the next person from an empty queue
        // Expected Result: Error message should be displayed
        Console.WriteLine("Test 4");
        players = new TakingTurnsQueue();
        players.GetNextPerson();
        // Defect(s) Found:
    }
}