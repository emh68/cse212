public class Node
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
