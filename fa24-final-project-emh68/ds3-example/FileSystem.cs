public class FileSystem
{
    // Represents a node (file or folder) in the file system
    private class Node
    {
        public string Name { get; set; }  // Name of the file/folder
        public bool IsFile { get; set; }  // Flag to indicate if the node is a file
        public List<Node> Children { get; } = new();  // List of child nodes (files/folders)
        public Node? Parent { get; set; }  // Parent folder of this node

        // Constructor to create a new node (file/folder)
        public Node(string name, bool isFile)
        {
            Name = name;
            IsFile = isFile;
            Parent = null;  // Initially, the node has no parent
        }
    }

    private readonly Node root;  // The root of the file system (a folder)

    // Constructor to initialize the file system with a root folder
    public FileSystem()
    {
        root = new Node("root", false);  // Root folder (not a file)
    }

    // Runs the program's main logic
    public void Run()
    {
        DisplayFileStructure();  // Show the file structure when the program starts

        while (true)
        {
            DisplayMenu();  // Display the menu options

            // Read user input and validate choice
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 9)
            {
                Console.WriteLine("Invalid choice! Press Enter to try again.");
                Console.ReadLine();
                continue;  // Display the menu again
            }

            bool actionSuccessful = false;  // Check if the action was successful

            // Perform the chosen action based on user input
            switch (choice)
            {
                case 1:
                    actionSuccessful = AddFile();
                    break;
                case 2:
                    actionSuccessful = RemoveFile();
                    break;
                case 3:
                    actionSuccessful = MoveFile();
                    break;
                case 4:
                    actionSuccessful = AddFolder();
                    break;
                case 5:
                    actionSuccessful = RemoveFolder();
                    break;
                case 6:
                    actionSuccessful = MoveFolder();
                    break;
                case 7:
                    SearchFile();
                    break;
                case 8:
                    DisplayFileStructure();  // Show file structure when option 8 is selected
                    break;
                case 9:
                    return;  // Exit the program
            }

            // If the action was successful, show the updated file structure
            if (actionSuccessful)
            {
                DisplayFileStructure();  // Update and show the file structure
            }
        }
    }

    // Displays the main menu options
    private static void DisplayMenu()
    {
        Console.WriteLine("\nMenu:");
        Console.WriteLine("1. Add a File");
        Console.WriteLine("2. Remove a File");
        Console.WriteLine("3. Move a File");
        Console.WriteLine("4. Add a Folder");
        Console.WriteLine("5. Remove a Folder");
        Console.WriteLine("6. Move a Folder");
        Console.WriteLine("7. Search for a File");
        Console.WriteLine("8. Display File Structure");
        Console.WriteLine("9. Exit");
        Console.Write("Choose an option: ");
    }

    // Displays the entire file system structure starting from root
    private void DisplayFileStructure()
    {
        Console.WriteLine("\nFile System Structure:");
        DisplayStructure(root, "", true);  // Display the root and its children
    }

    // Recursive function to display a node and its children
    private static void DisplayStructure(Node node, string indent, bool isLast)
    {
        Console.Write(indent);
        if (isLast)
        {
            Console.Write("└── ");  // Draw branch for last child
            indent += "    ";  // Add indentation for the next line
        }
        else
        {
            Console.Write("├── ");  // Draw branch for non-last child
            indent += "|   ";  // Add indentation for the next line
        }
        Console.WriteLine($"{(node.IsFile ? "(File)" : "(Folder)")} {node.Name}");

        // Recursively display all children of the current node
        for (int i = 0; i < node.Children.Count; i++)
        {
            DisplayStructure(node.Children[i], indent, i == node.Children.Count - 1);
        }
    }

    // Adds a new file to the file system
    private bool AddFile()
    {
        Console.Write("Enter file name (with extension i.e. .txt or .jpg): ");
        string? fileName = Console.ReadLine();
        if (string.IsNullOrEmpty(fileName))
        {
            Console.WriteLine("File name cannot be empty.");
            return false;
        }
        return AddNode(fileName, true);  // Add the file node
    }

    // Removes a file from the file system
    private bool RemoveFile()
    {
        Console.Write("Enter file name to remove: ");
        string? fileName = Console.ReadLine();
        if (string.IsNullOrEmpty(fileName))
        {
            Console.WriteLine("File name cannot be empty.");
            return false;
        }
        return RemoveNode(fileName, true);  // Remove the file node
    }

    // Moves a file to a new folder
    private bool MoveFile()
    {
        Console.Write("Enter file name to move: ");
        string? fileName = Console.ReadLine();
        if (string.IsNullOrEmpty(fileName))
        {
            Console.WriteLine("File name cannot be empty.");
            return false;
        }
        return MoveNode(fileName, true);  // Move the file node
    }

    // Adds a new folder to the file system
    private bool AddFolder()
    {
        Console.Write("Enter folder name: ");
        string? folderName = Console.ReadLine();
        if (string.IsNullOrEmpty(folderName))
        {
            Console.WriteLine("Folder name cannot be empty.");
            return false;
        }
        return AddNode(folderName, false);  // Add the folder node
    }

    // Removes a folder from the file system
    private bool RemoveFolder()
    {
        Console.Write("Enter folder name to remove: ");
        string? folderName = Console.ReadLine();
        if (string.IsNullOrEmpty(folderName))
        {
            Console.WriteLine("Folder name cannot be empty.");
            return false;
        }
        return RemoveNode(folderName, false);  // Remove the folder node
    }

    // Moves a folder to a new location
    private bool MoveFolder()
    {
        Console.Write("Enter folder name to move: ");
        string? folderName = Console.ReadLine();
        if (string.IsNullOrEmpty(folderName))
        {
            Console.WriteLine("Folder name cannot be empty.");
            return false;
        }
        return MoveNode(folderName, false);  // Move the folder node
    }

    // Searches for a specific file in the system
    private void SearchFile()
    {
        Console.Write("Enter file name to search: ");
        string? fileName = Console.ReadLine();
        if (string.IsNullOrEmpty(fileName))
        {
            Console.WriteLine("File name cannot be empty.");
            return;
        }

        Node? result = SearchNode(root, fileName, true);  // Search for the file node

        if (result != null)
        {
            Console.WriteLine($"File '{fileName}' found in folder '{result.Parent?.Name ?? "root"}'.");
        }
        else
        {
            Console.WriteLine($"File '{fileName}' not found.");
        }
    }

    // Adds a file or folder to the system under a specified parent
    private bool AddNode(string name, bool isFile)
    {
        Console.Write("Enter parent folder name (i.e. root): ");
        string? parentName = Console.ReadLine();
        if (string.IsNullOrEmpty(parentName))
        {
            Console.WriteLine("Parent name cannot be empty.");
            return false;
        }

        Node? parent = SearchNode(root, parentName, false);  // Find the parent folder
        if (parent == null)
        {
            Console.WriteLine($"Parent folder '{parentName}' does not exist.");
            return false;
        }

        if (parent.IsFile)
        {
            Console.WriteLine("Cannot add a file or folder under another file.");
            return false;
        }

        parent.Children.Add(new Node(name, isFile) { Parent = parent });  // Add new node
        Console.WriteLine($"{(isFile ? "File" : "Folder")} '{name}' added to '{parentName}'.");
        return true;
    }

    // Removes a file or folder from the system
    private bool RemoveNode(string name, bool isFile)
    {
        Node? node = SearchNode(root, name, isFile);

        if (node == null)
        {
            Console.WriteLine($"{(isFile ? "File" : "Folder")} '{name}' not found.");
            return false;
        }

        node.Parent?.Children.Remove(node);  // Remove the node from its parent's children
        Console.WriteLine($"{(isFile ? "File" : "Folder")} '{name}' removed.");
        return true;
    }

    // Moves a file or folder to a different folder
    private bool MoveNode(string name, bool isFile)
    {
        Node? node = SearchNode(root, name, isFile);

        if (node == null)
        {
            Console.WriteLine($"{(isFile ? "File" : "Folder")} '{name}' not found.");
            return false;
        }

        Console.Write("Enter new parent folder name: ");
        string? newParentName = Console.ReadLine();
        if (string.IsNullOrEmpty(newParentName))
        {
            Console.WriteLine("New parent name cannot be empty.");
            return false;
        }

        Node? newParent = SearchNode(root, newParentName, false);  // Find the new parent folder
        if (newParent == null || newParent.IsFile)
        {
            Console.WriteLine($"Invalid parent folder '{newParentName}'.");
            return false;
        }

        node.Parent?.Children.Remove(node);  // Remove node from current parent
        node.Parent = newParent;  // Set the new parent for the node
        newParent.Children.Add(node);  // Add node under the new parent

        Console.WriteLine($"{(isFile ? "File" : "Folder")} '{name}' moved to '{newParentName}'.");
        return true;
    }

    // Searches for a node (file/folder) by name in the file system
    private static Node? SearchNode(Node parent, string name, bool isFile)
    {
        foreach (Node child in parent.Children)
        {
            if (child.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && child.IsFile == isFile)
            {
                return child;  // Found the node with the matching name
            }

            // Recursively search through all children
            Node? found = SearchNode(child, name, isFile);
            if (found != null)
            {
                return found;
            }
        }

        return null;  // Node not found
    }
}