class Playlist
{
    private SongNode? head;
    private SongNode? current;

    // Add a song to the end of the playlist
    public void AddSong(string title, string artist)
    {
        var newSong = new SongNode(title, artist);
        if (head == null)
        {
            head = newSong;
            current = head;
        }
        else
        {
            SongNode temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = newSong;
            newSong.Previous = temp;
        }
    }

    // Display all songs in the playlist
    public void DisplayPlaylist()
    {
        SongNode? temp = head;
        Console.WriteLine("\nCurrent Playlist:");
        if (temp == null)
        {
            Console.WriteLine("The playlist is empty.");
            return;
        }

        while (temp != null)
        {
            Console.WriteLine($"- {temp.Title} by {temp.Artist}");
            temp = temp.Next;
        }
    }

    // Skip to the next song
    public void NextSong()
    {
        if (current != null && current.Next != null)
        {
            current = current.Next;
            Console.WriteLine($"\nNow Playing: {current.Title} by {current.Artist}");
        }
        else
        {
            Console.WriteLine("\nYou are at the end of the playlist.");
        }
    }

    // Go back to the previous song
    public void PreviousSong()
    {
        if (current != null && current.Previous != null)
        {
            current = current.Previous;
            Console.WriteLine($"\nNow Playing: {current.Title} by {current.Artist}");
        }
        else
        {
            Console.WriteLine("\nYou are at the beginning of the playlist.");
        }
    }

    // Display the currently playing song
    public void DisplayCurrentSong()
    {
        if (current != null)
        {
            Console.WriteLine($"\nCurrently Playing: {current.Title} by {current.Artist}");
        }
        else
        {
            Console.WriteLine("\nNo song is currently playing.");
        }
    }
}