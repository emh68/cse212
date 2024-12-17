class SongNode
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public SongNode? Next { get; set; }
    public SongNode? Previous { get; set; }

    public SongNode(string title, string artist)
    {
        Title = title;
        Artist = artist;
        Next = null;
        Previous = null;
    }
}