**CSE 212 – Programming with Data Structures**

**W05 Prove – Response Document**

------------------------------------------

_It is a violation of BYU-Idaho Honor Code to post or share this document with others or to post it online.  Storage into a personal and private repository (e.g. private GitHub repository, unshared Google Drive folder) is acceptable._

------------------------------------------

**Question 1:**  From Part 1, how did you answer the interview question for the Set Operations problem (should be no more than 30 seconds if spoken aloud)?

To find the intersection without using the Intersection function, we can iterate through each element in set1 and check if it exists in set2. If it does, we add it to the result set. The result set will contain only the elements present in both sets. If set1 and set2 do not contain any of the same values then the result set will be empty.

To find the union without using the Union function, we can add all elements from set1 to the result set, then add all elements from set2. Since hash sets automatically handle duplicates, the result set will contain all unique elements from both sets.

**Question 2:**  From Part 2, how did you answer the interview question for the Find Pairs problem (should be no more than 30 seconds if spoken aloud)?

To find the anagrams using O(n) time we use a HashSet and for each two-letter word in the list, we create a key by reversing the letters. We then check if this reversed key is already in the HashSet. If the key is, then it means we have a matching pair and we print both words. If the key is not found then we add the original word to the HashSet.
------------------------------------------

_Remember:  Make sure all of your changes are committed and pushed to the `main` branch of your_ **prove-05-[username]** _repository_

_Also, submit this document and a link to your repository in I-Learn_
