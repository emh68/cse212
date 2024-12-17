using System;

public class ContactBook
{
    private class Node
    {
        public Contact Contact { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(Contact contact)
        {
            Contact = contact;
            Left = null;
            Right = null;
        }
    }

    private Node root;

    public ContactBook()
    {
        root = null;
    }

    // Method to count total contacts
    public int CountContacts()
    {
        return CountRec(root);
    }

    private int CountRec(Node root)
    {
        if (root == null)
        {
            return 0;
        }

        return 1 + CountRec(root.Left) + CountRec(root.Right);
    }

    // Insert a new contact into the BST, ordered by LastName
    public void Insert(Contact contact)
    {
        root = InsertRec(root, contact);
    }

    private Node InsertRec(Node root, Contact contact)
    {
        // If the tree is empty, create a new node
        if (root == null)
        {
            root = new Node(contact);
            return root;
        }

        // Compare the LastName to maintain BST order
        int comparison = string.Compare(contact.LastName, root.Contact.LastName, StringComparison.OrdinalIgnoreCase);

        // Insert in left subtree if contact's LastName is less than the current node's LastName
        if (comparison < 0)
        {
            root.Left = InsertRec(root.Left, contact);
        }
        // Insert in right subtree if contact's LastName is greater than the current node's LastName
        else if (comparison > 0)
        {
            root.Right = InsertRec(root.Right, contact);
        }
        // If the LastName is the same, insert based on FirstName
        else
        {
            // Handle case where LastName is the same (e.g., check FirstName)
            int firstNameComparison = string.Compare(contact.FirstName, root.Contact.FirstName, StringComparison.OrdinalIgnoreCase);
            if (firstNameComparison < 0)
            {
                root.Left = InsertRec(root.Left, contact);
            }
            else
            {
                root.Right = InsertRec(root.Right, contact);
            }
        }

        return root;
    }

    // Search for a contact by name (either FirstName or LastName)
    public Contact Search(string searchName)
    {
        return SearchRec(root, searchName);
    }

    private Contact SearchRec(Node root, string searchName)
    {
        if (root == null)
        {
            return null;
        }

        // Compare searchName with LastName and FirstName in the tree
        if (root.Contact.LastName.Equals(searchName, StringComparison.OrdinalIgnoreCase) ||
            root.Contact.FirstName.Equals(searchName, StringComparison.OrdinalIgnoreCase))
        {
            return root.Contact;
        }

        int comparison = string.Compare(searchName, root.Contact.LastName, StringComparison.OrdinalIgnoreCase);
        if (comparison < 0)
        {
            return SearchRec(root.Left, searchName); // Search in the left subtree
        }
        else
        {
            return SearchRec(root.Right, searchName); // Search in the right subtree
        }
    }

    // In-order traversal to display contacts in alphabetical order by LastName
    public void DisplayContacts()
    {
        DisplayRec(root);
    }

    private void DisplayRec(Node root)
    {
        if (root != null)
        {
            DisplayRec(root.Left);
            Console.WriteLine(root.Contact.ToString());  // Display the contact
            DisplayRec(root.Right);
        }
    }

    public bool Remove(string firstName, string lastName)
    {
        int initialCount = CountContacts();
        root = RemoveRec(root, firstName, lastName);
        return CountContacts() < initialCount; // Return true if a node was removed
    }

    private Node RemoveRec(Node root, string firstName, string lastName)
    {
        if (root == null)
        {
            return null;
        }

        // Compare by LastName first, then by FirstName
        int lastNameComparison = string.Compare(lastName, root.Contact.LastName, StringComparison.OrdinalIgnoreCase);
        if (lastNameComparison < 0)
        {
            root.Left = RemoveRec(root.Left, firstName, lastName); // Recur to the left
        }
        else if (lastNameComparison > 0)
        {
            root.Right = RemoveRec(root.Right, firstName, lastName); // Recur to the right
        }
        else
        {
            // LastName matches, then compare FirstName
            int firstNameComparison = string.Compare(firstName, root.Contact.FirstName, StringComparison.OrdinalIgnoreCase);
            if (firstNameComparison < 0)
            {
                root.Left = RemoveRec(root.Left, firstName, lastName); // Recur to the left
            }
            else if (firstNameComparison > 0)
            {
                root.Right = RemoveRec(root.Right, firstName, lastName); // Recur to the right
            }
            else
            {
                // Node to be deleted found
                if (root.Left == null)
                {
                    return root.Right;
                }
                else if (root.Right == null)
                {
                    return root.Left;
                }

                // Node with two children: Get the in-order successor
                root.Contact = MinValue(root.Right);
                root.Right = RemoveRec(root.Right, root.Contact.FirstName, root.Contact.LastName);
            }
        }

        return root;
    }


    private Contact MinValue(Node root)
    {
        Contact minValue = root.Contact;
        while (root.Left != null)
        {
            minValue = root.Left.Contact;
            root = root.Left;
        }
        return minValue;
    }
}
