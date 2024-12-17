namespace prove_09;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        if (value == Data)
        {
            return;
        }
        else if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        // Check if the BST contains the value, if yes then return true
        if (value == Data)
        {
            return true;
        }
        else if (value < Data)
        {
            // Check the left subtree
            return Left != null && Left.Contains(value);
        }
        else
        {   // Check the right subtree
            return Right != null && Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        // If the tree only has a root node then the height is 1
        if (Left is null && Right is null)
        {
            return 1;
        }

        int leftHeight = (Left != null) ? Left.GetHeight() : 0;
        int RightHeight = (Right != null) ? Right.GetHeight() : 0;
        return 1 + Math.Max(leftHeight, RightHeight);
    }
}