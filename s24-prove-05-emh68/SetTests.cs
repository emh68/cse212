namespace prove_05;

public static class SetTests
{
    public static void Run()
    {
        Console.WriteLine("\n=========== PROBLEM 1 TESTS ===========");
        var s1 = new HashSet<int>(new[] { 1, 2, 3, 4, 5 });
        var s2 = new HashSet<int>(new[] { 4, 5, 6, 7, 8 });
        Console.WriteLine(Intersection(s1, s2).AsString()); // <Set>{4, 5}
        Console.WriteLine(Union(s1, s2).AsString()); // <Set>{1, 2, 3, 4, 5, 6, 7, 8}
        Console.WriteLine("---------");

        s1 = new HashSet<int>(new[] { 1, 2, 3, 4, 5 });
        s2 = new HashSet<int>(new[] { 6, 7, 8, 9, 10 });
        Console.WriteLine(Intersection(s1, s2).AsString()); // <Set>{}
        Console.WriteLine(Union(s1, s2).AsString()); // <Set>{1, 2, 3, 4, 5, 6, 7, 8, 9, 10}

        Console.WriteLine("\n=========== PROBLEM 2 TESTS ===========");
        DisplayPairs(new[] { "am", "at", "ma", "if", "fi" });
        // ma & am
        // fi & if
        Console.WriteLine("---------");
        DisplayPairs(new[] { "ab", "bc", "cd", "de", "ba" });
        // ba & ab
        Console.WriteLine("---------");
        DisplayPairs(new[] { "ab", "ba", "ac", "ad", "da", "ca" });
        // ba & ab
        // da & ad
        // ca & ac
        Console.WriteLine("---------");
        DisplayPairs(new[] { "ab", "ac" }); // No pairs displayed
        Console.WriteLine("---------");
        DisplayPairs(new[] { "ab", "aa", "ba" });
        // ba & ab
        Console.WriteLine("---------");
        DisplayPairs(new[] { "23", "84", "49", "13", "32", "46", "91", "99", "94", "31", "57", "14" });
        // 32 & 23
        // 94 & 49
        // 31 & 13
    }

    /// <summary>
    /// Performs a set intersection operation.
    /// </summary>
    /// <param name="set1">A set of integers</param>
    /// <param name="set2">A set of integers</param>
    private static HashSet<int> Intersection(HashSet<int> set1, HashSet<int> set2)
    {
        var result = new HashSet<int>();
        // Iterate over the integers in set1
        foreach (int i in set1)
        {
            // If set2 contains the same integer(s) in set1 get the integers and add them to the set
            if (set2.Contains(i))
            {
                result.Add(i);
            }
        }
        // TODO Problem 1.1 (don't forget to fill out the 05-prove-response.md)
        // Return the resulting set which is where the intersection occurs
        return result;
    }

    /// <summary>
    /// Performs a set union operation.
    /// </summary>
    /// <param name="set1">A set of integers</param>
    /// <param name="set2">A set of integers</param>
    private static HashSet<int> Union(HashSet<int> set1, HashSet<int> set2)
    {
        // Create HashSet object set1
        var result = new HashSet<int>(set1);
        // For each integer in set2 add it to the set. 
        foreach (int i in set2)
        {
            result.Add(i);
        }
        // TODO Problem 1.2 (don't forget to fill out the 05-prove-response.md)
        // Since HashSets do not include duplicates the duplicates are not included in the resulting set.
        return result;
    }

    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for displaying all symmetric pairs of words.  
    ///
    /// For example, if <c>words</c> was: <c>[am, at, ma, if, fi]</c>, we would display:
    /// <code>
    /// am &amp; ma
    /// if &amp; fi
    /// </code>
    /// The order of the display above does not matter. <c>at</c> would not 
    /// be displayed because <c>ta</c> is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember no the assumption above
    /// that there were no duplicates) and therefore should not be displayed.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    private static void DisplayPairs(string[] words)
    {

        var seenWords = new HashSet<string>();
        // To track printed pairs so no duplicates
        var printedPairs = new HashSet<string>();

        // Iterate over words 
        foreach (string word in words)
        {
            // Create a key based on character counts
            // For two-character words, this will be a simple character pair representation
            string key = word[0] < word[1] ? $"{word[0]}{word[1]}" : $"{word[1]}{word[0]}";

            // Check if the key has been seen already.
            if (seenWords.Contains(key))
            {
                // Create a pair identifier to ensure unique output
                string pairIdentifier = $"{key}&{word}";

                // If the pair hasn't been printed yet, print it and add to printedPairs
                if (!printedPairs.Contains(pairIdentifier))
                {
                    Console.WriteLine($"Found pair: {word} & {key}");
                    // Add to track printed pairs
                    printedPairs.Add(pairIdentifier);
                }
            }
            else
            {
                // Add the key to the seenWords set.
                seenWords.Add(key);
            }
        }
    }
}
