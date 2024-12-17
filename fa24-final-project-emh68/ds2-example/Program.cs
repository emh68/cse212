using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        // Initial list of songs
        var availableSongs = new List<(string Title, string Artist)>
        {
            ("Shape of You", "Ed Sheeran"),
            ("Blinding Lights", "The Weeknd"),
            ("Rolling in the Deep", "Adele"),
            ("Bohemian Rhapsody", "Queen"),
            ("Smells Like Teen Spirit", "Nirvana"),
            ("Uptown Funk", "Mark Ronson ft. Bruno Mars"),
            ("Hotel California", "Eagles"),
            ("Billie Jean", "Michael Jackson"),
            ("Imagine", "John Lennon"),
            ("Someone Like You", "Adele"),
            ("Shake It Off", "Taylor Swift"),
            ("Stairway to Heaven", "Led Zeppelin"),
            ("Despacito", "Luis Fonsi ft. Daddy Yankee"),
            ("Thinking Out Loud", "Ed Sheeran"),
            ("Sweet Child O' Mine", "Guns N' Roses"),
            ("Hello", "Adele"),
            ("Bad Guy", "Billie Eilish"),
            ("Old Town Road", "Lil Nas X"),
            ("Havana", "Camila Cabello"),
            ("Let It Be", "The Beatles"),
            ("Wonderwall", "Oasis"),
            ("Hey Jude", "The Beatles"),
            ("Shake It Off", "Taylor Swift"),
            ("Thriller", "Michael Jackson"),
            ("Rolling in the Deep", "Adele"),
            ("Radioactive", "Imagine Dragons"),
            ("Firework", "Katy Perry"),
            ("Born to Run", "Bruce Springsteen"),
            ("Yesterday", "The Beatles"),
            ("Roar", "Katy Perry"),
            ("Happy", "Pharrell Williams"),
            ("Closer", "The Chainsmokers"),
            ("Believer", "Imagine Dragons"),
            ("Toxic", "Britney Spears"),
            ("Livin' on a Prayer", "Bon Jovi")
        };

        Playlist playlist = new Playlist();

        Console.WriteLine("Available Songs:");
        for (int i = 0; i < availableSongs.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {availableSongs[i].Title} by {availableSongs[i].Artist}");
        }

        // Let the user add songs to the playlist
        Console.WriteLine("\nEnter the numbers of the songs to add to the playlist (comma-separated):");
        var input = Console.ReadLine()?.Trim();
        if (!string.IsNullOrWhiteSpace(input))
        {
            var selectedIndices = input.Split(',');

            foreach (var indexStr in selectedIndices)
            {
                if (int.TryParse(indexStr.Trim(), out int index) && index > 0 && index <= availableSongs.Count)
                {
                    var song = availableSongs[index - 1];
                    playlist.AddSong(song.Title, song.Artist);
                }
            }
        }

        // Main playback loop
        string? command;
        do
        {
            Console.WriteLine("\nCommands: pl(a)y | (n)ext | (p)revious | (l)ist | (q)uit");
            Console.Write("Enter a command: ");
            command = Console.ReadLine()?.Trim().ToLower();

            switch (command)
            {
                case "a": // play
                    playlist.DisplayCurrentSong();
                    break;
                case "n": // next
                    playlist.NextSong();
                    break;
                case "p": // previous
                    playlist.PreviousSong();
                    break;
                case "l": // list
                    playlist.DisplayPlaylist();
                    break;
                case "q": // quit
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid command. Try again.");
                    break;
            }
        } while (command != "q");
    }
}
